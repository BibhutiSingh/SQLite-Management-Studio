using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace SQLite_Management_Studio
{
    public class SQLWorker
    {
        SQLiteCommand com = null;
        SQLiteDataAdapter da = null;
        SQLiteDataReader dr = null;

        DataSet ds = null;
        DataTable tbl = null;
        public SqlWorkerQueryResult WorkerResult { get; set; }
        private SQLiteConnection GetConnection(int Id)
        {
            return ConnectionManager.GetConnectionManager().GetConnection(Id).GetActiveConnection();
        }
        public void Execute_Query(string com_str, int connId)
        {
            WorkerResult = new SqlWorkerQueryResult(com_str);
            WorkerResult.Start();
            try
            {
                com = GetConnection(connId).CreateCommand();
                com.CommandText = com_str;
                int cnt = com.ExecuteNonQuery();
                WorkerResult.Success(cnt);
            }
            catch (Exception ex)
            {

                WorkerResult.Error(ex.Message);
            }
            WorkerResult.End();
        }
        public void Execute_Query(string com_str, int connId, SQLiteParameter[] prm)
        {
            WorkerResult = new SqlWorkerQueryResult(com_str);
            WorkerResult.Start();
            try
            {
                com = GetConnection(connId).CreateCommand();
                com.CommandText = com_str;
                for (int i = 0; i < prm.Length; i++)
                {
                    com.Parameters.Add(prm[i]);
                }
                int cnt = com.ExecuteNonQuery();
                WorkerResult.Success(cnt);
            }
            catch (Exception ex)
            {

                WorkerResult.Error(ex.Message);
            }
            WorkerResult.End();

        }
        public DataTable Execute_DataTable(string com_str, int connId)
        {
            WorkerResult = new SqlWorkerQueryResult(com_str);
            WorkerResult.Start();
            try
            {
                da = new SQLiteDataAdapter(com_str, GetConnection(connId));
                tbl = new DataTable();
                da.Fill(tbl);
                int cnt = tbl != null ? tbl.Rows.Count : 0;
                WorkerResult.Success(cnt);
            }
            catch (Exception ex)
            {

                WorkerResult.Error(ex.Message);
            }
            WorkerResult.End();
            return tbl;

        }
        public SQLiteDataReader Execute_DataReader(string com_str, int connId)
        {
            WorkerResult = new SqlWorkerQueryResult(com_str);
            WorkerResult.Start();
            try
            {
                com = GetConnection(connId).CreateCommand();
                com.CommandText = com_str;
                dr = com.ExecuteReader();
                int cnt = 0;
                WorkerResult.Success(cnt);

            }
            catch (Exception ex)
            {

                WorkerResult.Error(ex.Message);
            }
            WorkerResult.End();

            return dr;
        }
    }

    public class SqlWorkerQueryResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public int RowsAffected { get; set; }
        public string Query { get; set; }
        public SqlWorkerQueryResult()
        {

        }
        public SqlWorkerQueryResult(string query)
        {
            Query = query;
        }
        public DateTime startTime;
        public DateTime endTime;
        public void Start()
        {
            this.startTime = DateTime.Now;
        }
        public void End()
        {
            this.endTime = DateTime.Now;
            this.TimeTaken = this.endTime - this.startTime;
        }
        internal void Success(int affectedCount = 0)
        {
            Result = true;
            Message = "Success";
            RowsAffected = affectedCount;
        }
        internal void Error(string message)
        {
            Result = false;
            Message = message;
            RowsAffected = 0;
        }
    }

}
