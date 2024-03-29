﻿using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SQLite_Management_Studio
{
    public partial class frmMain : Form, IConnectionClient
    {
        private readonly ConnectionManagerV2 connectionManager;

        private TreeNode curr_node;
        private frmNewTable frm;

        private test frm_test;

        private readonly SQLWorker obj_sql;

        private DataTable tbl;
        private TreeNode tmp_node = null;

        public frmMain()
        {
            InitializeComponent();
            obj_sql = new SQLWorker();
            connectionManager = ConnectionManagerV2.GetConnectionManager();
            connectionManager.Register(this);
        }

        public void NotifyChange(ConnectionChangeType connectionChangeType)
        {
            switch (connectionChangeType)
            {
                case ConnectionChangeType.Add:
                    break;
                case ConnectionChangeType.Connected:
                    break;
                case ConnectionChangeType.Disconnected:
                    break;
                case ConnectionChangeType.Removed:
                    Connections_Ref();
                    break;
            }
        }

        private void ConnectionAdd_Click(object sender, EventArgs e)
        {
            frm = new frmNewTable();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Connections_Ref();
            tv_connections.ImageList = imgList;
            var sq = new SQLWorkbook();
            sq.Size = tabPage1.Size;
            tabPage1.Controls.Add(sq);
            connectionManager.Register(sq);
        }

        private void Connections_Ref()
        {
            tv_connections.Nodes.Clear();
            var conns = new TreeNode();
            conns.Name = "CONN";
            conns.Text = "Connections";
            conns.Tag = "CONN";
            conns.ImageIndex = conns.SelectedImageIndex = 0;

            tv_connections.Nodes.Add(conns);

            foreach (var item in connectionManager.conn_list.Values)
            {
                var main_nodes = new TreeNode();
                main_nodes.Name = "PATH";
                main_nodes.Text = item.Name;
                main_nodes.ToolTipText = item.Path;
                main_nodes.Tag = item.ID;
                conns.ImageIndex = conns.SelectedImageIndex = 0;
                tv_connections.Nodes["CONN"].Nodes.Add(main_nodes);
                if (item.IsConnectionActive) tv_connections.Nodes["CONN"].LastNode.Expand();
            }

            conns.Expand();
        }

        private void RefreshConnectionTree()
        {
            curr_node.Nodes.Clear();
            var currConnId = Convert.ToInt32(curr_node.Tag);
            var nodeTable = new TreeNode();
            nodeTable.Name = "OBJ";
            nodeTable.Text = "Tables";
            nodeTable.Tag = currConnId;
            nodeTable.ImageIndex = nodeTable.SelectedImageIndex = 1;

            var nodeView = new TreeNode();
            nodeView.Name = "OBJ";
            nodeView.Text = "Views";
            nodeView.Tag = currConnId;
            nodeView.ImageIndex = nodeView.SelectedImageIndex = 2;

            try
            {
                using (var dr = obj_sql.Execute_DataReader(
                           "SELECT * FROM sqlite_master WHERE type in ('table','view')",
                           currConnId))
                {
                    while (dr.Read())
                    {
                        var tbls = new TreeNode();
                        tbls.Name = dr["type"].ToString().ToUpper();
                        tbls.Text = dr["name"].ToString();
                        tbls.Tag = currConnId;
                        if (dr["type"].ToString().ToUpper() == "TABLE")
                        {
                            tbls.ImageIndex = tbls.SelectedImageIndex = 1;
                            nodeTable.Nodes.Add(tbls);
                        }
                        else
                        {
                            tbls.ImageIndex = tbls.SelectedImageIndex = 2;
                            nodeView.Nodes.Add(tbls);
                        }
                    }
                }


                curr_node.Nodes.Add(nodeTable);
                curr_node.Nodes.Add(nodeView);
                curr_node.Expand();
                //update connection manager
                connectionManager.ConnectSavedConection(currConnId);

                //throw new NullReferenceException("Test");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                //Debugger.Break();
            }
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

            if (e.Node.Name == "TABLE" || e.Node.Name == "VIEW")
            {
                var connId = Convert.ToInt32(e.Node.Tag);

                txt_query.Text = "";
                dg_data.DataSource = null;

                tbl = obj_sql.Execute_DataTable("SELECT sql FROM sqlite_master WHERE  tbl_name='"
                                                + e.Node.Text + "'", connId);
                if (tbl.Rows.Count != 0)
                {
                    txt_query.Text = tbl.Rows[0][0].ToString();
                }
                else
                {
                    txt_status.Text = obj_sql.WorkerResult.Message;
                    return;
                }
                // MessageBox.Show(e.Node.Tag.ToString());

                tbl = obj_sql.Execute_DataTable("SELECT * from [" + e.Node.Text + "] limit 100"
                    , connId);

                if (tbl.Rows.Count != 0)
                    dg_data.DataSource = tbl;
                else
                    txt_status.Text = obj_sql.WorkerResult.Message;


                using (var dr = obj_sql.Execute_DataReader($"SELECT * FROM [{e.Node.Text}] WHERE 1=2",
                           connId))
                {
                    dg_struct.DataSource = dr.GetSchemaTable().AsEnumerable()
                        .Select(x => new
                        {
                            ColumnOrdinal = x.Field<int>("ColumnOrdinal"),
                            ColumnName = x.Field<string>("ColumnName"),
                            DataTypeName = x.Field<string>("DataTypeName"),
                            AllowDBNull = x.Field<bool>("AllowDBNull"),
                            IsKey = x.Field<bool>("IsKey"),
                            IsAutoIncrement = x.Field<bool>("IsAutoIncrement")
                        }).ToList();
                }
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
            var frm = new frm_AddConnection();

            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshConnectionTree();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frm_AddConnection();

            frm.ShowDialog();
        }

        private void menu_connection_Opening(object sender, CancelEventArgs e)
        {
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tv_connections.Nodes.Clear();
            Connections_Ref();
        }

        private void deleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this connection", "Delete Connection",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var currConnId = Convert.ToInt32(curr_node.Tag);
                connectionManager.RemoveConnection(currConnId);
                RefreshConnectionTree();
            }
        }

        private void tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pg = tb.SelectedTab;

            if (pg.Name != "tb_Add")
                return;

            var pg_new = new TabPage();

            pg_new.Text = "Editor " + (tb.TabCount - 1);
            pg_new.Size = tb.Size;

            var sq = new SQLWorkbook();
            connectionManager.Register(sq);
            sq.Size = pg_new.Size;

            pg_new.Controls.Add(sq);

            tb.TabPages.Insert(tb.SelectedIndex, pg_new);
            tb.SelectedIndex = tb.SelectedIndex - 1;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close to all Editors?", "Close Tab", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                foreach (TabPage pg in tb.TabPages)
                    if (pg.Name != "tb_Struct" && pg.Name != "tb_Add")
                        tb.TabPages.Remove(pg);

                tb.SelectedIndex = 0;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var pg_new = new TabPage();

            pg_new.Text = "Editor " + (tb.TabCount - 1);
            pg_new.Size = tb.Size;

            var sq = new SQLWorkbook();
            connectionManager.Register(sq);
            sq.Size = pg_new.Size;

            pg_new.Controls.Add(sq);

            tb.TabPages.Insert(tb.TabPages.Count - 1, pg_new);
            tb.SelectedIndex = tb.TabPages.Count - 2;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var pg = tb.SelectedTab;
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
            if (MessageBox.Show("Are you sure to Delete all records?", "Delete", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                var sq = new SQLWorker();

                sq.Execute_Query("delete from " + curr_node.Text,
                    Convert.ToInt32(curr_node.Tag));
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_Insert frm = new frm_Insert(curr_node.Text, curr_node.Tag.ToString());
            //frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}