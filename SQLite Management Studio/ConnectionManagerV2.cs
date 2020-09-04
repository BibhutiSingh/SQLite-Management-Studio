using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SQLite_Management_Studio
{
    public class ConnectionManagerV2
    {
        private List<IConnectionClient> clients;
        public Dictionary<int, SavedConnections> conn_list = new Dictionary<int, SavedConnections>();
        private const string ConfigDb = "Config.db";
        private const string ConfigTable = "ConnectionMaster";
        private ConnectionManagerV2()
        {
            clients = new List<IConnectionClient>();
            RefreshAllSavedConnections();
        }
        private static ConnectionManagerV2 connectionManager = null;
        public static ConnectionManagerV2 GetConnectionManager()
        {
            if (connectionManager == null)
            {
                connectionManager = new ConnectionManagerV2();
            }
            return connectionManager;
        }
        public void Register(IConnectionClient connectionClient)
        {
            clients.Add(connectionClient);
        }
        public void UnRegister(IConnectionClient connectionClient)
        {
            clients.Remove(connectionClient);
        }
        private void NotifyAll(ConnectionChangeType connectionChangeType)
        {
            foreach (var item in clients)
            {
                item.NotifyChange(connectionChangeType);
            }
        }
        #region ConnectionConfig
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
        #endregion
        private void RefreshAllSavedConnections()
        {
            try
            {
                using (var connConfig = GetConfigConnection())
                {
                    var comm = connConfig.CreateCommand();
                    comm.CommandText = "SELECT * FROM " + ConfigTable;
                    List<int> lstIds = new List<int>();
                    using (var rd = comm.ExecuteReader())
                    {
                        while (rd.Read())
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
                            if (!conn_list.ContainsKey(obj.ID))
                            {
                                conn_list.Add(obj.ID, obj);
                            }
                            lstIds.Add(obj.ID);
                        }
                    }
                    var removedConnections = conn_list.Where(x => lstIds.All(y => y != x.Key));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SaveConnection(string nm, string pth)
        {
            try
            {
                var savedConnection = new SavedConnections(nm, pth);
                using (var connConfig = GetConfigConnection())
                {
                    string query = string.Format("INSERT INTO {0}(NAME,PATH) values ('{1}','{2}')", ConfigTable, nm, pth);
                    new SQLiteCommand(query, connConfig).ExecuteNonQuery();
                }
                NotifyAll(ConnectionChangeType.Add);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ConnectSavedConection(int Id)
        {
            if (conn_list.ContainsKey(Id) && !conn_list[Id].IsConnectionActive)
            {
                conn_list[Id].GetActiveConnection();
                
            }
            NotifyAll(ConnectionChangeType.Connected);
            return conn_list[Id].IsConnectionActive;
        }
        public void RemoveConnection(int Id)
        {
            using (var connConfig = GetConfigConnection())
            {
                string query = string.Format("DELETE FROM {0} WHERE ID={1}", ConfigTable, Id);
                new SQLiteCommand(query, connConfig).ExecuteNonQuery();
                NotifyAll(ConnectionChangeType.Removed);
            }
        }
        public SavedConnections GetConnection(int Id)
        {
            try
            {
                if (conn_list.ContainsKey(Id))
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
    }
    public enum ConnectionChangeType
    {
        Add,
        Connected,
        Disconnected,
        Removed
    }
    public interface IConnectionClient
    {
        void NotifyChange(ConnectionChangeType connectionChangeType);

    }
}
