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
    public partial class frmNewTable : Form
    {

       public  SQLiteConnection conn;
       

        string tmp_str1;
        string tmp_str2;

        string opr_msg = "";
        bool opr_flag = false;

        SQLWorker obj_sql;
        public frmNewTable()
        {
            InitializeComponent();
            obj_sql = new SQLWorker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.CheckFileExists = false;

            if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = opd.FileName;

                if (System.IO.File.Exists(textBox1.Text) == false)
                {
                    if (MessageBox.Show("File Doesn't exists. Do you want to create the file?", "Create file", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        //System.IO.File.Create(textBox1.Text);
                        SQLiteConnection.CreateFile(textBox1.Text);
                    else
                        textBox1.Text = string.Empty;


                }


            }
            else
            {
                textBox1.Text = "";
            }
        }



        public  void button4_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length != 0) && (textBox1.Text != string.Empty))
            {
                conn = new SQLiteConnection("Data Source="+textBox1.Text);
                try
                {
                    conn.Open();
                    lblstatus.Text = "Status: Connected";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in connection: " + ex.Message);
                    lblstatus.Text = "Status: Not Connected";
                }
            
            }
        }

  
        private void button3_Click(object sender, EventArgs e)
        {
            if (check_integrity() == false)
            {
                MessageBox.Show(opr_msg);
                return;
            }

            tmp_str2 = "create table " + txt_tbl .Text .Trim () + " ( ";

            foreach (DataGridViewRow rw in dg.Rows)
            {
                if (rw.IsNewRow)
                    break;

                if (rw.Cells[1].Value.ToString() == "VARCHAR" || rw.Cells[1].Value.ToString() == "NUMERIC")
                    tmp_str2 = tmp_str2 + rw.Cells[0].Value.ToString() + " " + rw.Cells[1].Value.ToString() + "(" + rw.Cells[2].Value.ToString() + ")";
                else if(rw.Cells[1].Value.ToString() == "DECIMAL")
                    tmp_str2 = tmp_str2 + rw.Cells[0].Value.ToString() + " " + rw.Cells[1].Value.ToString() + "(" + rw.Cells[3].Value.ToString() + "," +rw.Cells[4].Value.ToString() + ")";
                else
                    tmp_str2 = tmp_str2 + rw.Cells[0].Value.ToString() + " " + rw.Cells[1].Value.ToString() ;


                if (rw.Cells[6].Value != null )
                    tmp_str2 = tmp_str2 + " " + rw.Cells[6].Value.ToString() + ",";
                else
                    tmp_str2 = tmp_str2 + ",";

            }
            

            tmp_str1 = tmp_str2.Remove(tmp_str2.Length-1) + ")";

            //obj_sql.Execute_Query(tmp_str1, conn);

            //if (obj_sql.opr_flag == true)
            //{
            //    MessageBox.Show("Table Created!!!");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show(obj_sql.opr_msg);
            //}
        }

        private void dg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            dg.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;

            if (e.ColumnIndex == 1)
            {
                string vals = dg.Rows[e.RowIndex].Cells[1].Value.ToString();
                switch (vals)
                {
                    case "VARCHAR":
                        dg.Rows[e.RowIndex].Cells[2].Value = "20";
                        dg.Rows[e.RowIndex].Cells[3].ReadOnly= true;
                        dg.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                        break;

                    case "NUMERIC":
                        dg.Rows[e.RowIndex].Cells[2].Value = "10";
                        dg.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                        dg.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                        break;


                    case "DECIMAL":
                        dg.Rows[e.RowIndex].Cells[2].ReadOnly = true;
                        dg.Rows[e.RowIndex].Cells[2].Value = "";
                        dg.Rows[e.RowIndex].Cells[3].Value  = "10";
                        dg.Rows[e.RowIndex].Cells[4].Value = "2";
                        break;
                    default:
                              dg.Rows[e.RowIndex].Cells[2].ReadOnly = true;
                        dg.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                        dg.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                        dg.Rows[e.RowIndex].Cells[2].Value = "";
                        break;


                }
                    


            }

            dg.Refresh();
        }


        private bool check_integrity()
        {
            bool res = true;
            if (txt_tbl.Text == string.Empty || txt_tbl.Text.Length == 0)
            {
                opr_msg = "Table name can not be empty.";

                return false; }

            if (lblstatus.Text.ToUpper() != "STATUS: CONNECTED")
            {
                opr_msg = "Connection is invalid.";
                return false;
            }

            if (dg.Rows.Count < 1)
            {
                opr_msg = "No Columns created.";
                return false;
            }

           // MessageBox.Show(dg.Rows.Count.ToString ());

            foreach (DataGridViewRow rw in dg.Rows)
            {
                if (rw.IsNewRow)
                    break;

                rw.Cells[0].Style.BackColor = Color.White;
                if (rw.Cells[0].Value == null || rw.Cells[0].Value.ToString() == string.Empty)
                {
                    opr_msg = "Correct highlighted errors.";
                    rw.Cells[0].Style.BackColor = Color.DarkSalmon;
                    res = false;

                }


                rw.Cells[2].Style.BackColor = Color.White;
                if ((rw.Cells[1].Value.ToString() == "VARCHAR" || rw.Cells[1].Value.ToString() == "NUMERIC") && (rw.Cells[2].Value == null || rw.Cells[2].Value.ToString() == string.Empty))
                {
                    opr_msg = "Correct highlighted errors.";
                    rw.Cells[2].Style.BackColor = Color.DarkSalmon;
                    res = false;

                }


                rw.Cells[3].Style.BackColor = Color.White;
                if ((rw.Cells[1].Value.ToString() == "DECIMAL") && (rw.Cells[3].Value == null || rw.Cells[3].Value.ToString() == string.Empty))
                {
                    opr_msg = "Correct highlighted errors.";
                    rw.Cells[3].Style.BackColor = Color.DarkSalmon;
                    res = false;

                }


                rw.Cells[4].Style.BackColor = Color.White;
                if ((rw.Cells[1].Value.ToString() == "DECIMAL") && (rw.Cells[4].Value == null || rw.Cells[4].Value.ToString() == string.Empty))
                {
                    opr_msg = "Correct highlighted errors.";
                    rw.Cells[4].Style.BackColor = Color.DarkSalmon;
                    res = false;

                }
            }

            
                
            return res;
        }

        private void dg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dg.Rows[e.RowIndex].Cells[1].Value = "VARCHAR";
        }

        private void frmNewTable_Load(object sender, EventArgs e)
        {
            dg.Rows[0].Cells[1].Value = "VARCHAR";
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void set_connection(SQLiteConnection cn,string pth="CONNECTION PATH")
        {
            textBox1.Text = pth;
          textBox1.Enabled = false;
            
            conn = cn;
            lblstatus.Text = "Status: Connected";
        }

       
    }
}
