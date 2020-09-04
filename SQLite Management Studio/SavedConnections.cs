
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SQLite_Management_Studio
{
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
                    ActiveConnection.StateChange += ActiveConnection_StateChange;
                    ActiveConnection.Open();
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
