using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;



namespace SQLite_Management_Studio
{
    
    public partial class frmMain : Form
    {
        frmNewTable frm;

        test frm_test;

        SQLWorker obj_sql;

        TreeNode curr_node = null;
        TreeNode tmp_node = null;

        DataTable tbl = null;
    
        public frmMain()
        {
            InitializeComponent();
            obj_sql = new SQLWorker();

           //TabPage pg = new TabPage("Editor 1");
           


        }

        private void ConnectionAdd_Click(object sender, EventArgs e)
        {
             frm = new frmNewTable();
             frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            Connections_Ref();
        }

        private void Connections_Ref()
        {
            if (System.IO.File.Exists("Conn_Config.xml") == false)
            {
                System.IO.StreamWriter wrt = new System.IO.StreamWriter("Conn_Config.xml");
                wrt.WriteLine (@"<?xml version=""1.0""?>");
                wrt.WriteLine("<connections>");
                wrt.WriteLine("</connections>");
                wrt.Close();
            }


            TreeNode conns = new TreeNode();
            conns.Name = "CONN";
            conns.Text = "Connections";
            conns.Tag = "CONN";

            tv_connections.Nodes.Add(conns);

            DataSet ds = new DataSet();

            ds.ReadXml("Conn_Config.xml");

            if (ds.Tables.Count ==0)
                return;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode main_nodes = new TreeNode();
                main_nodes.Name = "PATH";
                main_nodes.Text = dr[0].ToString();
                main_nodes.Tag = dr[1].ToString();


                tv_connections.Nodes["CONN"].Nodes.Add(main_nodes);
            }

            conns.Expand();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_test = new test();
            frm_test.Show();
        }

        private void tv_connections_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tv_connections_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Name == "PATH")
                {
                    if (cls_connection.conn_list.ContainsKey(e.Node.Text))
                    {
                        menu_connect.Items[0].Enabled = false;
                        menu_connect.Items[1].Enabled = true;
                    }
                    else
                    {
                        menu_connect.Items[0].Enabled = true;
                        menu_connect.Items[1].Enabled = false;
                    }
                    e.Node.ContextMenuStrip = menu_connect;
                    curr_node = e.Node;
                    //menu_connect.Show();
                }
                else if (e.Node.Name == "CONN")
                {
                    e.Node.ContextMenuStrip = menu_connection;
                    curr_node = e.Node;

                }

                else if (e.Node.Name == "TABLE")
                {
                    e.Node.ContextMenuStrip = menu_table;
                    curr_node = e.Node;
                }
                
                    


            }

            txt_status.Text = e.Node.Name;

            if (e.Node.Name == "TABLE")//|| e.Node.Name =="VIEW"
            {
                txt_query.Text  = "";
                dg_data.DataSource  = null;

                tbl = obj_sql.Execute_DataTable("SELECT sql FROM sqlite_master WHERE  tbl_name='" + e.Node.Text + "'", cls_connection.conn_list[e.Node.Tag.ToString()]);

                if (tbl.Rows.Count != 0)
                    txt_query.Text = tbl.Rows[0][0].ToString();
                else
                {
                    txt_status.Text = obj_sql.opr_msg;
                    return ;
                }
                // MessageBox.Show(e.Node.Tag.ToString());

                tbl = obj_sql.Execute_DataTable("SELECT * from " + e.Node.Text + " limit 100", cls_connection.conn_list[e.Node.Tag.ToString()]);

                if (tbl.Rows.Count != 0)
                    dg_data.DataSource = tbl;
                else
                    txt_status.Text = obj_sql.opr_msg;


                DataTable tbl_struct = new DataTable();
                DataColumn col_name = new DataColumn("Column Name");
                tbl_struct.Columns.Add(col_name);

                DataColumn col_dtyp = new DataColumn("Column DataType");
                tbl_struct.Columns.Add(col_dtyp);

                dg_struct.DataSource = null;
                

                Regex rg = new Regex(@"\(.*\)");
                string qry = rg.Match(txt_query.Text).Value;
                if (qry.Trim().Length == 0)
                    return;
                qry = qry.Substring(1);
                qry = qry.Substring(0, qry.Length - 1).Trim();
                string qry_copy=qry;

                foreach (Match match in Regex.Matches(qry, @"\(.*?\)"))
                    qry_copy =qry_copy .Replace(match.ToString(),match.Value.Replace(",","|"));


                string[] qry_stuct = qry_copy.Split(',');




                
               

                for (int i = 0; i < tbl.Columns .Count  ; i++)
                {
                    DataRow dr = tbl_struct.NewRow();

                    
                    qry_stuct[i] = qry_stuct[i].Replace("\t", " ");
                    qry_stuct[i] = qry_stuct[i].Replace("\n", " ");
                    qry_stuct[i] = qry_stuct[i].Trim();

                    string[] tmp_s = qry_stuct[i].Split(' ');
                    try
                    {
                       // dr[0] = tbl.Columns[i].ColumnName;
                        //dr[1] = tbl.Columns[i].DataType;

                        dr[0] = tmp_s[0].Replace("\"","").Replace("[","").Replace("]","");
                        dr[1] = tmp_s[1].Replace("|",",");
                    }
                    catch { }
                    

                
                    

                    tbl_struct.Rows.Add(dr);
                }

                dg_struct.DataSource = tbl_struct;

            }

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cls_connection.add_connection(curr_node.Text, curr_node.Tag.ToString()) == true)
            {
                string conn_nm = curr_node.Text;

                TreeNode objs = new TreeNode();
                objs.Name = "OBJ";
                objs.Text = "Tables";
                objs.Tag = conn_nm ;
                curr_node.Nodes.Add(objs);



                SQLiteDataReader dr = obj_sql.Execute_DataReader("SELECT * FROM sqlite_master WHERE type='table'", cls_connection.conn_list[curr_node.Text]);

                if (dr.HasRows)
                {
                   

                    while (dr.Read())
                    {
                        TreeNode tbls = new TreeNode();
                        tbls.Name = "TABLE";
                        tbls.Text = dr["name"].ToString();
                        tbls.Tag = conn_nm;
                        curr_node.Nodes[0].Nodes.Add(tbls);



                    }

                }

                dr.Close();

                objs.Expand();

                //curr_node.Expand();


                objs = new TreeNode();
                objs.Name = "OBJ";
                objs.Text = "Views";
                objs.Tag =  conn_nm;
                curr_node.Nodes.Add(objs);



                 dr = obj_sql.Execute_DataReader("SELECT * FROM sqlite_master WHERE type='view'", cls_connection.conn_list[curr_node.Text]);

                if (dr.HasRows)
                {


                    while (dr.Read())
                    {
                        TreeNode tbls = new TreeNode();
                        tbls.Name = "VIEW";
                        tbls.Text = dr["name"].ToString();
                        tbls.Tag = conn_nm;

                        objs.Nodes.Add(tbls);



                    }

                }

                dr.Close();

            }
            else
            {
                MessageBox.Show(cls_connection.Result);
            }

            
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cls_connection.close_connection(curr_node.Text);

            curr_node.Nodes.Clear();
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewTable frm = new frmNewTable();



            frm.set_connection(cls_connection.conn_list[curr_node.Text],curr_node.Text);

            frm.ShowDialog();

        }

        private void addConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AddConnection frm = new frm_AddConnection();

            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curr_node.Nodes.Clear();

            string conn_nm = curr_node.Text;

            TreeNode objs = new TreeNode();
            objs.Name = "OBJ";
            objs.Text = "Tables";
            objs.Tag = conn_nm;
            curr_node.Nodes.Add(objs);



            SQLiteDataReader dr = obj_sql.Execute_DataReader("SELECT * FROM sqlite_master WHERE type='table'", cls_connection.conn_list[curr_node.Text]);

            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    TreeNode tbls = new TreeNode();
                    tbls.Name = "TABLE";
                    tbls.Text = dr["name"].ToString();
                    tbls.Tag = conn_nm;
                    curr_node.Nodes[0].Nodes.Add(tbls);



                }

            }

            dr.Close();

            objs.Expand();

            //curr_node.Expand();


            objs = new TreeNode();
            objs.Name = "OBJ";
            objs.Text = "Views";
            objs.Tag = conn_nm;
            curr_node.Nodes.Add(objs);



            dr = obj_sql.Execute_DataReader("SELECT * FROM sqlite_master WHERE type='view'", cls_connection.conn_list[curr_node.Text]);

            if (dr.HasRows)
            {


                while (dr.Read())
                {
                    TreeNode tbls = new TreeNode();
                    tbls.Name = "VIEW";
                    tbls.Text = dr["name"].ToString();
                    tbls.Tag = conn_nm;

                    objs.Nodes.Add(tbls);



                }

            }

            dr.Close();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_AddConnection frm = new frm_AddConnection();

            frm.ShowDialog();
        }

        private void menu_connection_Opening(object sender, CancelEventArgs e)
        {

        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Refreshing this will close all opened connections. Do you want continue", "Refresh", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tv_connections.Nodes.Clear();

                Connections_Ref();

                cls_connection.conn_list.Clear();
            }
        }

        private void deleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this connection", "Delete Connection", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string str=curr_node.Text;

                cls_connection.close_connection(str);

                curr_node.Nodes.Clear();

                TreeNode rm = curr_node;

                curr_node = rm.Parent;

                rm.Remove();


                cls_connection.RemoveConnection(str);
 
            }
        }

        private void tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage pg = tb.SelectedTab;

            if (pg.Name != "tb_Add")
                return;

            TabPage pg_new = new TabPage();

            pg_new.Text = "Editor " + (tb.TabCount-1).ToString();
            pg_new.Size = tb.Size;

            SQLWorkbook sq = new SQLWorkbook();
            sq.Size = pg_new.Size;

            pg_new.Controls.Add(sq);

            tb.TabPages.Insert(tb.SelectedIndex, pg_new);
            tb.SelectedIndex = tb.SelectedIndex-1;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close to all Editors?", "Close Tab", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (TabPage pg in tb.TabPages)
                {
                    if (pg.Name != "tb_Struct" && pg.Name != "tb_Add")
                        tb.TabPages.Remove(pg);
                }

                tb.SelectedIndex = 0;
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabPage pg_new = new TabPage();

            pg_new.Text = "Editor " + (tb.TabCount - 1).ToString();
            pg_new.Size = tb.Size;

            SQLWorkbook sq = new SQLWorkbook();
            sq.Size = pg_new.Size;

            pg_new.Controls.Add(sq);

            tb.TabPages.Insert(tb.TabPages.Count -1, pg_new);
            tb.SelectedIndex = tb.TabPages.Count - 2;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TabPage pg = tb.SelectedTab;
            if (pg.Name != "tb_Struct" && pg.Name != "tb_Add")
                tb.TabPages.Remove(pg);
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(null, null);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            refreshToolStripMenuItem1_Click(null, null);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
    

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete all records?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLWorker sq = new SQLWorker();

                sq.Execute_Query("delete from " + curr_node.Text, cls_connection.conn_list[curr_node.Tag.ToString()]);

 
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Insert frm = new frm_Insert(curr_node.Text, curr_node.Tag.ToString());
            frm.ShowDialog();
        }
    }
}
