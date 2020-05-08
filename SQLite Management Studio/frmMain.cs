﻿using System;
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
        ConnectionManager connectionManager;

        public frmMain()
        {
            InitializeComponent();
            obj_sql = new SQLWorker();
            connectionManager = ConnectionManager.GetConnectionManager();
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
            TreeNode conns = new TreeNode();
            conns.Name = "CONN";
            conns.Text = "Connections";
            conns.Tag = "CONN";

            tv_connections.Nodes.Add(conns);



            foreach (var item in connectionManager.conn_list.Values)
            {
                TreeNode main_nodes = new TreeNode();
                main_nodes.Name = "PATH";
                main_nodes.Text = item.Name;
                main_nodes.ToolTipText = item.Path;
                main_nodes.Tag = item.ID;
                tv_connections.Nodes["CONN"].Nodes.Add(main_nodes);
            }

            conns.Expand();
        }
        private void RefreshConnectionTree()
        {
            curr_node.Nodes.Clear();
            int currConnId = Convert.ToInt32(curr_node.Tag);
            TreeNode nodeTable = new TreeNode();
            nodeTable.Name = "OBJ";
            nodeTable.Text = "Tables";
            nodeTable.Tag = currConnId;

            TreeNode nodeView = new TreeNode();
            nodeView.Name = "OBJ";
            nodeView.Text = "Views";
            nodeView.Tag = currConnId;
            using (SQLiteDataReader dr = obj_sql.Execute_DataReader("SELECT * FROM sqlite_master WHERE type in ('table','view')",
                 currConnId))
            {
                while (dr.Read())
                {
                    TreeNode tbls = new TreeNode();
                    tbls.Name = dr["type"].ToString().ToUpper();
                    tbls.Text = dr["name"].ToString();
                    tbls.Tag = currConnId;
                    if (dr["type"].ToString().ToUpper() == "TABLE")
                    {
                        nodeTable.Nodes.Add(tbls);
                    }
                    else
                    {
                        nodeView.Nodes.Add(tbls);
                    }

                }
            }

            curr_node.Nodes.Add(nodeTable);
            curr_node.Nodes.Add(nodeView);
            curr_node.Expand();
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
                var connId = Convert.ToInt32(e.Node.Tag);

                txt_query.Text = "";
                dg_data.DataSource = null;

                tbl = obj_sql.Execute_DataTable("SELECT sql FROM sqlite_master WHERE  tbl_name='"
                    + e.Node.Text + "'", connId);
                if (tbl.Rows.Count != 0)
                    txt_query.Text = tbl.Rows[0][0].ToString();
                else
                {
                    txt_status.Text = obj_sql.WorkerResult.Message;
                    return;
                }
                // MessageBox.Show(e.Node.Tag.ToString());

                tbl = obj_sql.Execute_DataTable("SELECT * from " + e.Node.Text + " limit 100"
                    , connId);

                if (tbl.Rows.Count != 0)
                    dg_data.DataSource = tbl;
                else
                    txt_status.Text = obj_sql.WorkerResult.Message;


                DataTable tbl_struct = new DataTable();
                DataColumn col_name = new DataColumn("Column Name");
                tbl_struct.Columns.Add(col_name);

                DataColumn col_dtyp = new DataColumn("Column DataType");
                tbl_struct.Columns.Add(col_dtyp);

                foreach (DataColumn item in tbl.Columns)
                {
                    var rw = tbl_struct.NewRow();
                    rw[0] = item.ColumnName;
                    rw[1] = item.DataType.ToString();

                    tbl_struct.Rows.Add(rw);
                }

                dg_struct.DataSource = null;
                dg_struct.DataSource = tbl_struct;

            }

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshConnectionTree();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curr_node.Nodes.Clear();
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //New Table

        }

        private void addConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AddConnection frm = new frm_AddConnection();

            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshConnectionTree();
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
            }
        }

        private void deleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this connection", "Delete Connection", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int currConnId = Convert.ToInt32(curr_node.Tag);
                connectionManager.RemoveConnection(currConnId);

            }
        }

        private void tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage pg = tb.SelectedTab;

            if (pg.Name != "tb_Add")
                return;

            TabPage pg_new = new TabPage();

            pg_new.Text = "Editor " + (tb.TabCount - 1).ToString();
            pg_new.Size = tb.Size;

            SQLWorkbook sq = new SQLWorkbook();
            sq.Size = pg_new.Size;

            pg_new.Controls.Add(sq);

            tb.TabPages.Insert(tb.SelectedIndex, pg_new);
            tb.SelectedIndex = tb.SelectedIndex - 1;
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

            tb.TabPages.Insert(tb.TabPages.Count - 1, pg_new);
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

                sq.Execute_Query("delete from " + curr_node.Text,
                    Convert.ToInt32(curr_node.Tag));


            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_Insert frm = new frm_Insert(curr_node.Text, curr_node.Tag.ToString());
            //frm.ShowDialog();
        }
    }
}
