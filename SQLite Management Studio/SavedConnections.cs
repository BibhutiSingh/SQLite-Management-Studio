using System;
using System.Data;
using System.Data.SQLite;

namespace SQLite_Management_Studio
{
    public class SavedConnections : IDisposable
    {
        private string nm;
        private string pth;

        public SavedConnections()
        {
        }

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

        public void Dispose()
        {
            if (ActiveConnection != null) ActiveConnection.Close();
        }

        public SQLiteConnection GetActiveConnection()
        {
            if (ActiveConnection == null)
            {
                ActiveConnection = new SQLiteConnection($"Data Source={Path}");
                ActiveConnection.StateChange += ActiveConnection_StateChange;
                ActiveConnection.Open();
            }

            if (ActiveConnection.State != ConnectionState.Open) ActiveConnection.Open();
            return ActiveConnection;
        }

        private void ActiveConnection_StateChange(object sender, StateChangeEventArgs e)
        {
            if (ActiveConnection.State == ConnectionState.Open)
                IsConnectionActive = true;
            else
                IsConnectionActive = false;
        }
    }
}