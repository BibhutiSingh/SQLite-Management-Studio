using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLite_Management_Studio
{
    public class ConnectionManagerV2
    {
        private const string ConfigDb = "Config.db";
        private const string ConfigTable = "ConnectionMaster";
        private static ConnectionManagerV2 connectionManager;
        private readonly List<IConnectionClient> clients;
        public Dictionary<int, SavedConnections> conn_list = new Dictionary<int, SavedConnections>();

        private ConnectionManagerV2()
        {
            clients = new List<IConnectionClient>();
            RefreshAllSavedConnections();
        }

        public static ConnectionManagerV2 GetConnectionManager()
        {
            if (connectionManager == null) connectionManager = new ConnectionManagerV2();
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
            //Refresh Connections
            RefreshAllSavedConnections();
            foreach (var item in clients) item.NotifyChange(connectionChangeType);
        }

        #region ConnectionConfig

        private SQLiteConnection GetConfigConnection()
        {
            var ConfigConnection = new SQLiteConnection($"Data Source = {ConfigDb}");
            ConfigConnection.Open();

            //check if ConfigDb is ok
            var com = new SQLiteCommand(ConfigConnection);
            com.CommandText = $"select count(*) from sqlite_master where type='table' and name ='{ConfigTable}'";
            var res = Convert.ToInt32(com.ExecuteScalar());
            if (res == 0)
            {
                com.CommandText =
                    $"CREATE TABLE {ConfigTable} (ID INTEGER NOT NULL CONSTRAINT \"PK_Users\" PRIMARY KEY AUTOINCREMENT,NAME TEXT NOT NULL, PATH TEXT NOT NULL, PASSWORD TEXT)";
                com.ExecuteNonQuery();
            }

            return ConfigConnection;
        }

        #endregion

        private void RefreshAllSavedConnections()
        {
            using (var connConfig = GetConfigConnection())
            {
                var comm = connConfig.CreateCommand();
                comm.CommandText = "SELECT * FROM " + ConfigTable;
                var lstIds = new List<int>();
                using (var rd = comm.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var obj = new SavedConnections
                        {
                            ID = Convert.ToInt32(rd[0]),
                            Name = rd["NAME"].ToString(),
                            Path = rd["PATH"].ToString(),
                            Password = rd["PASSWORD"].ToString(),
                            IsConnectionActive = false
                        };

                        //Refresh Connection without closing existing connection
                        if (!conn_list.ContainsKey(obj.ID)) conn_list.Add(obj.ID, obj);
                        lstIds.Add(obj.ID);
                    }
                }
            }
        }

        public void SaveConnection(string nm, string pth)
        {
            var savedConnection = new SavedConnections(nm, pth);
            using (var connConfig = GetConfigConnection())
            {
                var query = string.Format("INSERT INTO {0}(NAME,PATH) values ('{1}','{2}')", ConfigTable, nm, pth);
                new SQLiteCommand(query, connConfig).ExecuteNonQuery();
            }

            NotifyAll(ConnectionChangeType.Add);
        }

        public bool ConnectSavedConection(int Id)
        {
            if (conn_list.ContainsKey(Id) && !conn_list[Id].IsConnectionActive) conn_list[Id].GetActiveConnection();
            NotifyAll(ConnectionChangeType.Connected);
            return conn_list[Id].IsConnectionActive;
        }

        public void RemoveConnection(int Id)
        {
            using (var connConfig = GetConfigConnection())
            {
                var query = string.Format("DELETE FROM {0} WHERE ID={1}", ConfigTable, Id);
                new SQLiteCommand(query, connConfig).ExecuteNonQuery();
                NotifyAll(ConnectionChangeType.Removed);
            }
        }

        public SavedConnections GetConnection(int Id)
        {
            if (conn_list.ContainsKey(Id))
                return conn_list[Id];
            throw new Exception("No connection found.");
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