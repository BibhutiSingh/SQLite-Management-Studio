using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLite_Management_Studio
{
    public partial class frm_Insert : Form
    {
        string tbl_name = "";
        int connId;

        Label[] lbl;
        TextBox[] txt;

        DataTable tbl=null ;

        SQLiteCommand com = null;
        SQLiteDataAdapter da = null;
        


        public frm_Insert(string tbl ,int conns  )
        {
            InitializeComponent();

            tbl_name = tbl;
            connId = conns;


        }

        private void frm_Insert_Load(object sender, EventArgs e)
        {
            Draw_Form();
        }


        private void Draw_Form()
        {


            da = null;//new SQLiteDataAdapter("select * from " + tbl_name + " where 1=2", connId);

            tbl = new DataTable();
            da.Fill(tbl);

            int tmp = tbl.Columns .Count;

            lbl = new Label[tmp];
            txt = new TextBox[tmp];

            for (int i = 0; i < tmp; i++)
            {
                lbl[i] = new Label();
                lbl[i].Text  = tbl.Columns[i].ColumnName;
                lbl[i].Left = 10;
                lbl[i].Top = 15 + (i * 30);
                lbl[i].Height = 30;
                lbl[i].Width = 100;


                txt[i] = new TextBox();
                txt[i].Width = 200;
                txt[i].Left = 130;
                txt[i].Height = 30;
                txt[i].Top = 15 + (i * 30);

                pnl.Controls.Add(lbl[i]);
                pnl.Controls.Add(txt[i]);

                

 
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string com_str = "insert into " + tbl_name + " values (";
            string tmp_str = "";
            string cols="";

            int tmp = tbl.Columns .Count;

            SQLiteParameter[] prm=new SQLiteParameter[tmp];

            for (int i = 0; i < tmp; i++)
            {
                prm[i] = new SQLiteParameter("@p" + (i + 1).ToString(), tbl.Columns[i].DataType);
                try
                {
                    switch (tbl.Columns[i].DataType.ToString().ToUpper())
                    {
                        case "SYSTEM.STRING":
                            prm[i].Value = txt[i].Text;
                            break;
                        case "SYSTEM.DATETIME":
                        case "SYSTEM.DATE":
                            prm[i].Value = DateTime.Parse (txt[i].Text ).ToString("s");
                            break;
                        case "SYSTEM.DOUBLE":
                        case "SYSTEM.DECIMAL":
                            prm[i].Value = double .Parse  (txt[i].Text);
                            break;
                        default :
                            prm[i].Value = int.Parse(txt[i].Text);
                            break;

 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }

                cols += lbl[i].Text + ",";
                tmp_str += "@p" + (i + 1).ToString() + ",";


 
            }

            cols = cols.Substring(0, cols.Length - 1);
            tmp_str = tmp_str.Substring(0, tmp_str.Length - 1);

            com_str = "insert into " + tbl_name + "(" + cols + ") values (" + tmp_str + ")";

            //MessageBox.Show(com_str);

            SQLWorker sq = new SQLWorker();

            sq.Execute_Query(com_str, connId, prm);

            if (sq.WorkerResult.Result == true)
                MessageBox.Show("Record added");
            else
                MessageBox.Show(sq.WorkerResult.Message);

           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
