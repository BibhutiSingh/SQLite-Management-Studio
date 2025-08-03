using SQLite_Management_Studio.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SQLite_Management_Studio
{
    public partial class SQLWorkbook : UserControl, IConnectionClient
    {
        private readonly SQLWorker sql = new SQLWorker();

        private DataTable tbl;

        private readonly DataTable tbl_res = new DataTable();


        private string temp1;
        private string temp2;
        private Thread th;

        public SQLWorkbook()
        {
            InitializeComponent();

            var col1 = new DataColumn("Time");
            tbl_res.Columns.Add(col1);
            var col2 = new DataColumn("Query");
            tbl_res.Columns.Add(col2);

            var col3 = new DataColumn("Result");
            tbl_res.Columns.Add(col3);
            dgres.DataSource = tbl_res;
            Refresh_Connection();
            txt.ApplySqlHighlighting();
        }

        public void NotifyChange(ConnectionChangeType connectionChangeType)
        {
            switch (connectionChangeType)
            {
                case ConnectionChangeType.Add:
                    break;
                case ConnectionChangeType.Connected:
                case ConnectionChangeType.Disconnected:
                case ConnectionChangeType.Removed:
                    Refresh_Connection();
                    break;
            }
        }


        private void Refresh_Connection()
        {
            var conns = ConnectionManagerV2.GetConnectionManager().conn_list
                .Values
                .Where(x => x.IsConnectionActive)
                .ToList();
            if (conns != null && conns.Count > 0)
            {
                cmb_connections.DataSource = conns;
                cmb_connections.DisplayMember = "Name";
                cmb_connections.ValueMember = "ID";
            }
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
            if (cmb_connections.Text == "" || cmb_connections.Text.Length == 0)
            {
                MessageBox.Show("No connection Selected. Please Refresh Connection list.");
            }


            else
            {
                dg.DataSource = null;
                if (txt.SelectedText.Length == 0)
                    tbl = sql.Execute_DataTable(txt.Text, Convert.ToInt32(cmb_connections.SelectedValue));
                else
                    tbl = sql.Execute_DataTable(txt.SelectedText, Convert.ToInt32(cmb_connections.SelectedValue));


                dg.DataSource = tbl;

                var dr = tbl_res.NewRow();

                dr[0] = DateTime.Now;
                if (txt.SelectedText.Length == 0)
                    dr[1] = txt.Text;
                else
                    dr[1] = txt.SelectedText;


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
                pnl_Export.Visible = true;

            //frm_Export frm = new frm_Export(this);
            //frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void UpdateExport(int curr, int tot, string mode)
        {
            if (mode == "DONE")
            {
                txt_Status.Text = "Result Expoted";
                prg.Value = 0;
                th = null;
            }
            else
            {
                var per = curr / (double)tot;
                per = Math.Ceiling(per * 100);

                prg.Value = (int)per;
            }
        }

        public void Export()
        {
            //MessageBox.Show(fln + " " + dlm);
            //return;

            var wrt = new StreamWriter(temp1, false);
            dlg_UpdateExport del = UpdateExport;

            var ln = "";

            for (var i = 0; i < dg.RowCount; i++)
            {
                ln = "";
                //Thread.Sleep(1000);
                for (var j = 0; j < dg.ColumnCount; j++) ln += dg[j, i].Value + temp2;
                ln = ln.Substring(0, ln.Length - 1);


                wrt.WriteLine(ln);

                Invoke(del, i + 1, dg.RowCount, "PROG");
            }

            wrt.Close();
            Invoke(del, 4, 4, "DONE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.FileName = "Result.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
                textBox1.Text = dlg.FileName;
            else
                textBox1.Text = "C:\\Result.txt";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Give deliminator");
            }
            else
            {
                temp1 = textBox1.Text;
                temp2 = textBox3.Text;

                txt_Status.Text = "Exporting Result";
                th = new Thread(Export);
                th.Start();


                pnl_Export.Visible = false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            pnl_Export.Visible = false;
        }

        private void split_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txt_Click(object sender, EventArgs e)
        {
        }

        private delegate void dlg_UpdateExport(int curr, int tot, string mode);
    }
}