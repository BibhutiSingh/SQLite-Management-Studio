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
    
        #region Class Communication
        
       
        public bool opr_flag=true  ;
        public string opr_msg = "SUCCESS";

        void opr_res(bool flg, string msg = "SUCCESS")
        {
            opr_flag = flg;
            opr_msg = msg;
        }

        #endregion


        SQLiteCommand com=null;
        SQLiteDataAdapter da=null;
        SQLiteDataReader dr=null;

        DataSet ds=null;
        DataTable tbl = null;


        public void Execute_Query(string com_str, SQLiteConnection conn)
        {
            com = new SQLiteCommand(com_str, conn);

            try
            {
                com.ExecuteNonQuery();
                opr_res(true);
            }
            catch (Exception ex)
            {
                opr_res(false, "Error in executing query:" + ex.Message + "\nSQL QUERY:" + com_str);

            }

        }

        public void Execute_Query(string com_str, SQLiteConnection conn,SQLiteParameter [] prm)
        {
            com = new SQLiteCommand(com_str, conn);

            for (int i = 0; i < prm.Length; i++)
            {
                com.Parameters.Add(prm[i]);
            }

            try
            {
                com.ExecuteNonQuery();
                opr_res(true);
            }
            catch (Exception ex)
            {
                opr_res(false, "Error in executing query:" + ex.Message + "\nSQL QUERY:" + com_str);

            }

        }


        public DataSet  Execute_DataSet(string com_str, SQLiteConnection conn)
        {
            da = new  SQLiteDataAdapter (com_str, conn);
            ds = new DataSet();



            try
            {
                da.Fill(ds);
                opr_res(true);
            }
            catch (Exception ex)
            {
                opr_res(false, "Error in executing query:" + ex.Message + "\nSQL QUERY:" + com_str);

            }

            return ds;
        }

        public DataTable Execute_DataTable(string com_str, SQLiteConnection conn)
        {
            da = new SQLiteDataAdapter(com_str, conn);
            tbl = new DataTable();

            try
            {
                da.Fill(tbl);
                opr_res(true);
            }
            catch (Exception ex)
            { opr_res(false, "Error in executing query:" + ex.Message + "\nSQL QUERY:" + com_str); }

            return tbl;

        }


        public SQLiteDataReader Execute_DataReader(string com_str, SQLiteConnection conn)
        {
            //if (dr.IsClosed==false  )
            //{ dr.Close(); }

            com = new SQLiteCommand(com_str, conn);
            



            try
            {
                dr = com.ExecuteReader();
                opr_res(true);
            }
            catch (Exception ex)
            {
                opr_res(false, "Error in executing query:" + ex.Message + "\nSQL QUERY:" + com_str);

            }

            return dr;
        }



    }
}
