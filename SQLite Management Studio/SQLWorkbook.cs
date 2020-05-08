using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SQLite_Management_Studio
{
    public partial class SQLWorkbook : UserControl
    {

        SQLWorker sql = new SQLWorker();

        DataTable tbl = null;

        DataTable tbl_res =new DataTable ();


        string temp1;
        string temp2;
        Thread th;

        public SQLWorkbook()
        {
            InitializeComponent();


           DataColumn col1=new DataColumn ("Time");
            tbl_res .Columns .Add (col1 );
               DataColumn col2=new DataColumn ("Query");
            tbl_res .Columns .Add (col2 );
           
               DataColumn col3=new DataColumn ("Result");
            tbl_res .Columns .Add (col3 );


            dgres.DataSource = tbl_res;

            Refresh_Connection();

        }

        void Refresh_Connection()
        {
            cmb_connections.DataSource = ConnectionManager.GetConnectionManager().conn_list.Values.ToList();

            cmb_connections.DisplayMember = "Name";
            cmb_connections.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh_Connection();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            dg.DataSource = null;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (cmb_connections.Text == "" || cmb_connections.Text.Length == 0 )
                MessageBox.Show("No connection Selected. Please Refresh Connection list.");

                
            else
            {
                dg.DataSource = null;
                if(txt.SelectionLength==0)
                    tbl = sql.Execute_DataTable(txt.Text, Convert.ToInt32( cmb_connections.SelectedValue));
                else
                    tbl = sql.Execute_DataTable(txt.SelectedText, Convert.ToInt32(cmb_connections.SelectedValue));


                

                dg.DataSource = tbl;

                DataRow dr = tbl_res.NewRow();

                dr[0] = DateTime.Now;
                if (txt.SelectionLength == 0)
                    dr[1] = txt.Text;
                else
                    dr[1] = txt.SelectedText ;

                
                dr[2] = sql.WorkerResult.Message;


                tbl_res.Rows.Add(dr);

                if (sql.WorkerResult.Result)
                {
                    txt_Status.Text = "SUCCESS";
                    txt_Status.ForeColor = Color.ForestGreen;
                    tabControl1.SelectedIndex = 0;

                }
                else
                {
                    txt_Status.Text = "ERROR";
                    txt_Status.ForeColor = Color.IndianRed;
                    tabControl1.SelectedIndex = 1;
                   
 
                }
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_res.Clear();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (dg.DataSource == null)
                MessageBox.Show("No Result to export.");
            else
            {
            pnl_Export.Visible = true;

            }

            //frm_Export frm = new frm_Export(this);
            //frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private delegate void dlg_UpdateExport(int curr,int tot, string mode);

        private void UpdateExport(int curr, int tot, string mode)
        {
            if (mode.ToString() == "DONE")
            {
                txt_Status.Text = "Result Expoted";
                prg.Value = 0;
                th.Suspend();
                th = null;
            }
            else
            {
                double per = (double)curr / (double)tot;
                per = Math.Ceiling(per * 100);

                prg.Value =(int) per;
                
            }


        }

        public void Export()
        {
            //MessageBox.Show(fln + " " + dlm);
            //return;

            StreamWriter wrt = new StreamWriter(temp1 , false);
            dlg_UpdateExport del = new dlg_UpdateExport(UpdateExport);

            string ln = "";

            for (int i = 0; i < dg.RowCount; i++)
            {
                ln = "";
                //Thread.Sleep(1000);
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    ln += dg[j, i].Value.ToString()+ temp2;
                    
                   

                    
 
                }
                ln = ln.Substring(0, ln.Length - 1);

                

                wrt.WriteLine(ln);
                
                this .Invoke (del,new object[]{(i+1),dg.RowCount ,"PROG"});

            }

            wrt.Close();
            this.Invoke(del, new object[] {4, 4, "DONE"});

        }

        private void button5_Click(object sender, EventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Result.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
                textBox1.Text = dlg.FileName;
            else
                textBox1.Text = "C:\\Result.txt";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                MessageBox.Show("Give deliminator");
            else
            {
                temp1 = textBox1.Text;
                temp2 = textBox3.Text;

                txt_Status.Text = "Exporting Result";
             th = new Thread(new ThreadStart(Export));
                th.Start();


              
                pnl_Export.Visible = false;
            }


         
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            pnl_Export.Visible = false;
        }
    }
}
