namespace SQLite_Management_Studio
{
    partial class frmNewTable
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.txt_tbl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_precision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_null = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_constraints = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(553, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dg
            // 
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_type,
            this.col_length,
            this.col_precision,
            this.col_scale,
            this.col_null,
            this.col_constraints});
            this.dg.Location = new System.Drawing.Point(20, 75);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(787, 292);
            this.dg.TabIndex = 2;
            this.dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellContentClick);
            this.dg.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellValueChanged);
            this.dg.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_RowsAdded);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(702, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(591, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(702, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 30);
            this.button4.TabIndex = 5;
            this.button4.Text = "Connect";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(17, 390);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(115, 13);
            this.lblstatus.TabIndex = 6;
            this.lblstatus.Text = "Status: Not Connected";
            // 
            // txt_tbl
            // 
            this.txt_tbl.Location = new System.Drawing.Point(88, 49);
            this.txt_tbl.Name = "txt_tbl";
            this.txt_tbl.Size = new System.Drawing.Size(482, 20);
            this.txt_tbl.TabIndex = 7;
            this.txt_tbl.Text = "table1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Table Name";
            // 
            // col_name
            // 
            this.col_name.HeaderText = "Column Name";
            this.col_name.Name = "col_name";
            // 
            // col_type
            // 
            this.col_type.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.col_type.HeaderText = "Data Type";
            this.col_type.Items.AddRange(new object[] {
            "VARCHAR",
            "INT",
            "BIGINT",
            "NUMERIC",
            "DECIMAL",
            "BOOLEAN",
            "DATE",
            "DATETIME ",
            "BLOB"});
            this.col_type.Name = "col_type";
            // 
            // col_length
            // 
            this.col_length.HeaderText = "Length";
            this.col_length.Name = "col_length";
            this.col_length.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_precision
            // 
            this.col_precision.HeaderText = "Precision";
            this.col_precision.Name = "col_precision";
            // 
            // col_scale
            // 
            this.col_scale.HeaderText = "Scale";
            this.col_scale.Name = "col_scale";
            // 
            // col_null
            // 
            this.col_null.HeaderText = "Not Null";
            this.col_null.Name = "col_null";
            // 
            // col_constraints
            // 
            this.col_constraints.HeaderText = "Constraints";
            this.col_constraints.Items.AddRange(new object[] {
            "PRIMARY KEY",
            "UNIQUE"});
            this.col_constraints.Name = "col_constraints";
            // 
            // frmNewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_tbl);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmNewTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Table";
            this.Load += new System.EventHandler(this.frmNewTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblstatus;
       public  System.Windows.Forms.TextBox txt_tbl;
       private System.Windows.Forms.Label label1;
       private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
       private System.Windows.Forms.DataGridViewComboBoxColumn col_type;
       private System.Windows.Forms.DataGridViewTextBoxColumn col_length;
       private System.Windows.Forms.DataGridViewTextBoxColumn col_precision;
       private System.Windows.Forms.DataGridViewTextBoxColumn col_scale;
       private System.Windows.Forms.DataGridViewCheckBoxColumn col_null;
       private System.Windows.Forms.DataGridViewComboBoxColumn col_constraints;
    }
}