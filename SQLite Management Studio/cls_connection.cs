using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.Xml;
using System.Collections.Specialized;

namespace SQLite_Management_Studio
{
    /// <summary>
    /// Connection Manager
    /// </summary>
    public class ConnectionManager : INotifyCollectionChanged, IDisposable
    {
        public Dictionary<int, SavedConnections> conn_list = new Dictionary<int, SavedConnections>();
        private const string ConfigDb = "Data Source=Config.db";
        private const string ConfigTable = "ConnectionMaster";
        //Singletons
        private ConnectionManager()
        {
            conn_list = new Dictionary<int, SavedConnections>();
            CollectionChanged = null;
            IsConfigOk();
            RefreshAllSavedConnections();
            CollectionChanged += ConnectionManager_CollectionChanged;
        }

        private void ConnectionManager_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RefreshAllSavedConnections();
        }

        //bad code refractor
        private static ConnectionManager connectionManager = null;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public static ConnectionManager GetConnectionManager()
        {
            if (connectionManager == null)
            {
                connectionManager = new ConnectionManager();
            }
            return connectionManager;
        }
        private SQLiteConnection GetConfigConnection()
        {
            try
            {
                SQLiteConnection ConfigConnection = new SQLiteConnection($"Data Source = {ConfigDb}");
                ConfigConnection.Open();
                return ConfigConnection;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public bool ConnectSavedConection(int Id)
        {
            if (IsConnectionExists(Id) && !conn_list[Id].IsConnectionActive)
            {
                conn_list[Id].GetActiveConnection();
            }
            return conn_list[Id].IsConnectionActive;
        }
        public bool IsConnectionExists(int Id)
        {
            return conn_list.ContainsKey(Id);
        }
        public void SaveConnection(string nm, string pth)
        {
            try
            {
                var savedConnection = new SavedConnections(nm, pth);
                using (var connConfig = new SQLiteConnection(ConfigDb))
                {
                    connConfig.Open();
                    string query = string.Format("INSERT INTO {0}(NAME,PATH) values ('{1}','{2}')", ConfigTable, nm, pth);
                    new SQLiteCommand(query, connConfig).ExecuteNonQuery();
                }
                if (CollectionChanged != null)
                {
                    CollectionChanged(this,
                        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RemoveConnection(int Id)
        {
            using (var connConfig = new SQLiteConnection(ConfigDb))
            {
                connConfig.Open();
                string query = string.Format("DELETE FROM {0} WHERE ID=", ConfigTable, Id);
                new SQLiteCommand(query, connConfig).ExecuteNonQuery();
                if (CollectionChanged != null)
                {
                    CollectionChanged(this,
                        new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
                }
            }
        }
        private bool IsConfigOk()
        {
            try
            {
                using (var configConnection = GetConfigConnection())
                {
                    //checkif master table exists
                    string selectQuery = "SELECT* FROM sqlite_master WHERE type = 'table' and name = 'ConnectionMaster'";
                    var comm = configConnection.CreateCommand();
                    comm.CommandText = selectQuery;
                    using (var dr = comm.ExecuteReader())
                    {
                        if (dr == null || dr.HasRows == false)
                        {
                            string createQuery = "CREATE TABLE ConnectionMaster(ID INTEGER NOT NULL CONSTRAINT \"PK_Users\" PRIMARY KEY AUTOINCREMENT,NAME TEXT NOT NULL, PATH TEXT NOT NULL, PASSWORD TEXT)";
                            var comm2 = configConnection.CreateCommand();
                            comm2.CommandText = createQuery;
                            comm2.ExecuteNonQuery();
                        }
                    }

                }
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        private void RefreshAllSavedConnections()
        {
            try
            {
                using (var connConfig = new SQLiteConnection(ConfigDb))
                {
                    connConfig.Open();
                    var comm = connConfig.CreateCommand();
                    comm.CommandText = "SELECT * FROM " + ConfigTable;
                    List<int> lstIds = new List<int>();
                    using (var rd = comm.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            var obj = new SavedConnections()
                            {
                                ID = Convert.ToInt32(rd[0]),
                                Name = rd["NAME"].ToString(),
                                Path = rd["PATH"].ToString(),
                                Password = rd["PASSWORD"].ToString(),
                                IsConnectionActive = false
                            };

                            //Refresh Connection without closing existing connection
                            if (!IsConnectionExists(obj.ID))
                            {
                                conn_list.Add(obj.ID, obj);
                            }
                            lstIds.Add(obj.ID);
                        }
                    }
                    var removedConnections = conn_list.Where(x => lstIds.All(y => y != x.Key));
                    foreach (var item in removedConnections)
                    {
                        conn_list[item.Key].Dispose();
                        conn_list.Remove(item.Key);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }
        public SavedConnections GetConnection(int Id)
        {
            try
            {
                if (IsConnectionExists(Id))
                {
                    return conn_list[Id];
                }
                else
                {
                    throw new Exception("No connection found.");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public void Dispose()
        {
            foreach (var item in conn_list.Values)
            {
                item.Dispose();
            }
        }
    }
    public class SavedConnections : IDisposable
    {
        private string nm;
        private string pth;
        public SavedConnections()
        { }
        public SavedConnections(string nm, string pth)
        {
            this.nm = nm;
            this.pth = pth;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Password { get; set; }
        public bool IsConnectionActive { get; set; }
        private SQLiteConnection ActiveConnection { get; set; }
        public SQLiteConnection GetActiveConnection()
        {
            try
            {
                if (ActiveConnection == null)
                {
                    ActiveConnection = new SQLiteConnection($"Data Source={this.Path}");
                    ActiveConnection.Open();
                    ActiveConnection.StateChange += ActiveConnection_StateChange;
                }
                if (ActiveConnection.State != System.Data.ConnectionState.Open)
                {
                    ActiveConnection.Open();
                }
                return ActiveConnection;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void ActiveConnection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if (ActiveConnection.State == System.Data.ConnectionState.Open)
            {
                this.IsConnectionActive = true;
            }
            else
            {
                this.IsConnectionActive = false;
            }
        }

        public void Dispose()
        {
            if (ActiveConnection != null)
            {
                ActiveConnection.Close();
            }
        }
    }
}
