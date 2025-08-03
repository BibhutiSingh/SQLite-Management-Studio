namespace SQLite_Management_Studio
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            txt_status = new System.Windows.Forms.ToolStripStatusLabel();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menu_connect = new System.Windows.Forms.ContextMenuStrip(components);
            connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menu_table = new System.Windows.Forms.ContextMenuStrip(components);
            insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menu_connection = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tv_connections = new System.Windows.Forms.TreeView();
            tb = new System.Windows.Forms.TabControl();
            tb_Struct = new System.Windows.Forms.TabPage();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage2 = new System.Windows.Forms.TabPage();
            dg_struct = new System.Windows.Forms.DataGridView();
            tabPage3 = new System.Windows.Forms.TabPage();
            dg_data = new System.Windows.Forms.DataGridView();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txt_query = new ScintillaNET.Scintilla();
            tb_Add = new System.Windows.Forms.TabPage();
            imgList = new System.Windows.Forms.ImageList(components);
            label3 = new System.Windows.Forms.Label();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            menu_connect.SuspendLayout();
            menu_table.SuspendLayout();
            menu_connection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tb.SuspendLayout();
            tb_Struct.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_struct).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_data).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { txt_status });
            statusStrip1.Location = new System.Drawing.Point(0, 733);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(1298, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // txt_status
            // 
            txt_status.Name = "txt_status";
            txt_status.Size = new System.Drawing.Size(42, 17);
            txt_status.Text = "Status:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, testToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1298, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.Visible = false;
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            testToolStripMenuItem.Text = "Test";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // menu_connect
            // 
            menu_connect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem, addToolStripMenuItem, addConnectionToolStripMenuItem, propertiesToolStripMenuItem, refreshToolStripMenuItem, deleteConnectionToolStripMenuItem });
            menu_connect.Name = "menu_connect";
            menu_connect.Size = new System.Drawing.Size(173, 158);
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tablesToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            addToolStripMenuItem.Text = "Add";
            // 
            // tablesToolStripMenuItem
            // 
            tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            tablesToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            tablesToolStripMenuItem.Text = "Tables";
            tablesToolStripMenuItem.Click += tablesToolStripMenuItem_Click;
            // 
            // addConnectionToolStripMenuItem
            // 
            addConnectionToolStripMenuItem.Name = "addConnectionToolStripMenuItem";
            addConnectionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            addConnectionToolStripMenuItem.Text = "Add Connection";
            addConnectionToolStripMenuItem.Click += addConnectionToolStripMenuItem_Click;
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            propertiesToolStripMenuItem.Text = "Properties";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // deleteConnectionToolStripMenuItem
            // 
            deleteConnectionToolStripMenuItem.Name = "deleteConnectionToolStripMenuItem";
            deleteConnectionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            deleteConnectionToolStripMenuItem.Text = "Delete Connection";
            deleteConnectionToolStripMenuItem.Click += deleteConnectionToolStripMenuItem_Click;
            // 
            // menu_table
            // 
            menu_table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { insertToolStripMenuItem, deleteToolStripMenuItem, dropToolStripMenuItem });
            menu_table.Name = "menu_table";
            menu_table.Size = new System.Drawing.Size(108, 70);
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            insertToolStripMenuItem.Text = "Insert";
            insertToolStripMenuItem.Click += insertToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // dropToolStripMenuItem
            // 
            dropToolStripMenuItem.Name = "dropToolStripMenuItem";
            dropToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            dropToolStripMenuItem.Text = "Drop";
            // 
            // menu_connection
            // 
            menu_connection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, refreshToolStripMenuItem1 });
            menu_connection.Name = "menu_connect";
            menu_connection.Size = new System.Drawing.Size(162, 48);
            menu_connection.Opening += menu_connection_Opening;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            toolStripMenuItem1.Text = "Add Connection";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // refreshToolStripMenuItem1
            // 
            refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            refreshToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            refreshToolStripMenuItem1.Text = "Refresh";
            refreshToolStripMenuItem1.Click += refreshToolStripMenuItem1_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(tv_connections);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tb);
            splitContainer1.Size = new System.Drawing.Size(1298, 733);
            splitContainer1.SplitterDistance = 295;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            splitContainer1.Resize += splitContainer1_SizeChanged;
            // 
            // tv_connections
            // 
            tv_connections.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tv_connections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tv_connections.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tv_connections.Location = new System.Drawing.Point(-1, 24);
            tv_connections.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tv_connections.Name = "tv_connections";
            tv_connections.Size = new System.Drawing.Size(297, 708);
            tv_connections.TabIndex = 2;
            tv_connections.AfterSelect += tv_connections_AfterSelect;
            tv_connections.NodeMouseClick += tv_connections_NodeMouseClick;
            // 
            // tb
            // 
            tb.Controls.Add(tb_Struct);
            tb.Controls.Add(tb_Add);
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.Location = new System.Drawing.Point(0, 0);
            tb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb.Name = "tb";
            tb.SelectedIndex = 0;
            tb.Size = new System.Drawing.Size(996, 731);
            tb.TabIndex = 1;
            tb.SelectedIndexChanged += tb_SelectedIndexChanged;
            // 
            // tb_Struct
            // 
            tb_Struct.Controls.Add(tabControl1);
            tb_Struct.Controls.Add(label1);
            tb_Struct.Controls.Add(txt_query);
            tb_Struct.Location = new System.Drawing.Point(4, 24);
            tb_Struct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Struct.Name = "tb_Struct";
            tb_Struct.Size = new System.Drawing.Size(988, 703);
            tb_Struct.TabIndex = 1;
            tb_Struct.Text = "Structure & Data";
            tb_Struct.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(15, 227);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(954, 457);
            tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dg_struct);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Size = new System.Drawing.Size(946, 429);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Structure";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dg_struct
            // 
            dg_struct.AllowUserToAddRows = false;
            dg_struct.AllowUserToDeleteRows = false;
            dg_struct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dg_struct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dg_struct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_struct.Location = new System.Drawing.Point(18, 18);
            dg_struct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dg_struct.Name = "dg_struct";
            dg_struct.ReadOnly = true;
            dg_struct.Size = new System.Drawing.Size(920, 388);
            dg_struct.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dg_data);
            tabPage3.Controls.Add(label2);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage3.Size = new System.Drawing.Size(946, 429);
            tabPage3.TabIndex = 1;
            tabPage3.Text = "Data";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dg_data
            // 
            dg_data.AllowUserToAddRows = false;
            dg_data.AllowUserToDeleteRows = false;
            dg_data.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dg_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_data.Location = new System.Drawing.Point(19, 30);
            dg_data.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dg_data.Name = "dg_data";
            dg_data.ReadOnly = true;
            dg_data.Size = new System.Drawing.Size(901, 374);
            dg_data.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(2, 6);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(144, 15);
            label2.TabIndex = 4;
            label2.Text = "Sample Data(100 Records)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 18);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Query";
            // 
            // txt_query
            // 
            txt_query.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt_query.AutocompleteListSelectedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            txt_query.Font = new System.Drawing.Font("Courier New", 12F);
            txt_query.LexerName = null;
            txt_query.Location = new System.Drawing.Point(15, 36);
            txt_query.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            txt_query.Name = "txt_query";
            txt_query.Size = new System.Drawing.Size(954, 185);
            txt_query.TabIndex = 0;
            // 
            // tb_Add
            // 
            tb_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            tb_Add.Location = new System.Drawing.Point(4, 24);
            tb_Add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Add.Name = "tb_Add";
            tb_Add.Size = new System.Drawing.Size(988, 703);
            tb_Add.TabIndex = 2;
            tb_Add.Text = "   +";
            tb_Add.UseVisualStyleBackColor = true;
            // 
            // imgList
            // 
            imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = System.Drawing.Color.Transparent;
            imgList.Images.SetKeyName(0, "Database.png");
            imgList.Images.SetKeyName(1, "table.png");
            imgList.Images.SetKeyName(2, "View.png");
            imgList.Images.SetKeyName(3, "column.png");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 6);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 15);
            label3.TabIndex = 5;
            label3.Text = "All Connections";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1298, 755);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "frmMain";
            Text = "SQLite Management Studio";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += frmMain_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menu_connect.ResumeLayout(false);
            menu_table.ResumeLayout(false);
            menu_connection.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tb.ResumeLayout(false);
            tb_Struct.ResumeLayout(false);
            tb_Struct.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_struct).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dg_data).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tb;
        private System.Windows.Forms.TreeView tv_connections;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menu_connect;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menu_table;
        private SQLWorkbook sqlWorkbook1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel txt_status;
        private System.Windows.Forms.ContextMenuStrip menu_connection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.TabPage tb_Struct;
        private ScintillaNET.Scintilla txt_query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem deleteConnectionToolStripMenuItem;
        private System.Windows.Forms.TabPage tb_Add;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dg_struct;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dg_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropToolStripMenuItem;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Label label3;
    }
}