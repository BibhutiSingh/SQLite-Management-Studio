using System;
using System.Data;
using System.Data.SQLite;

namespace SQLite_Management_Studio
{
    public class SQLWorker
    {
        private SQLiteCommand com;
        private SQLiteDataAdapter da;
        private SQLiteDataReader dr;

        private DataSet ds = null;
        private DataTable tbl;
        public SqlWorkerQueryResult WorkerResult { get; set; }

        private SQLiteConnection GetConnection(int Id)
        {
            return ConnectionManagerV2.GetConnectionManager().GetConnection(Id).GetActiveConnection();
        }

        public void Execute_Query(string com_str, int connId)
        {
            WorkerResult = new SqlWorkerQueryResult(com_str);
            WorkerResult.Start();
            try
            {
                com = GetConnection(connId).CreateCommand();
                com.CommandText = com_str;
                var cnt = com.ExecuteNonQuery();
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
                for (var i = 0; i < prm.Length; i++) com.Parameters.Add(prm[i]);
                var cnt = com.ExecuteNonQuery();
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
                var cnt = tbl != null ? tbl.Rows.Count : 0;
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
                var cnt = 0;
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
        public DateTime endTime;
        public DateTime startTime;

        public SqlWorkerQueryResult()
        {
        }

        public SqlWorkerQueryResult(string query)
        {
            Query = query;
        }

        public bool Result { get; set; }
        public string Message { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public int RowsAffected { get; set; }
        public string Query { get; set; }

        public void Start()
        {
            startTime = DateTime.Now;
        }

        public void End()
        {
            endTime = DateTime.Now;
            TimeTaken = endTime - startTime;
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