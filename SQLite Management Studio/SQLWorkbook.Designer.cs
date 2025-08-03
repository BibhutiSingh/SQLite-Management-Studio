namespace SQLite_Management_Studio
{
    partial class SQLWorkbook
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            split = new System.Windows.Forms.SplitContainer();
            txt = new ScintillaNET.Scintilla();
            cmb_connections = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            btn_clear = new System.Windows.Forms.Button();
            btn_run = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            pnl_Export = new System.Windows.Forms.Panel();
            btn_ok = new System.Windows.Forms.Button();
            btn_Cancel = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            btn_Export = new System.Windows.Forms.Button();
            dg = new System.Windows.Forms.DataGridView();
            tabPage2 = new System.Windows.Forms.TabPage();
            button1 = new System.Windows.Forms.Button();
            dgres = new System.Windows.Forms.DataGridView();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            txt_Status = new System.Windows.Forms.ToolStripStatusLabel();
            prg = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)split).BeginInit();
            split.Panel1.SuspendLayout();
            split.Panel2.SuspendLayout();
            split.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            pnl_Export.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgres).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // split
            // 
            split.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            split.Dock = System.Windows.Forms.DockStyle.Fill;
            split.Location = new System.Drawing.Point(0, 0);
            split.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            split.Name = "split";
            split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            split.Panel1.Controls.Add(txt);
            split.Panel1.Controls.Add(cmb_connections);
            split.Panel1.Controls.Add(label1);
            split.Panel1.Controls.Add(btn_clear);
            split.Panel1.Controls.Add(btn_run);
            split.Panel1.Paint += split_Panel1_Paint;
            // 
            // split.Panel2
            // 
            split.Panel2.Controls.Add(tabControl1);
            split.Panel2.Controls.Add(statusStrip1);
            split.Size = new System.Drawing.Size(962, 635);
            split.SplitterDistance = 230;
            split.SplitterWidth = 5;
            split.TabIndex = 0;
            // 
            // txt
            // 
            txt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt.AutocompleteListSelectedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            txt.LexerName = null;
            txt.Location = new System.Drawing.Point(15, 44);
            txt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txt.Name = "txt";
            txt.Size = new System.Drawing.Size(926, 172);
            txt.TabIndex = 5;
            txt.Click += txt_Click;
            // 
            // cmb_connections
            // 
            cmb_connections.FormattingEnabled = true;
            cmb_connections.Location = new System.Drawing.Point(94, 13);
            cmb_connections.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmb_connections.Name = "cmb_connections";
            cmb_connections.Size = new System.Drawing.Size(176, 23);
            cmb_connections.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "Connection";
            // 
            // btn_clear
            // 
            btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_clear.Location = new System.Drawing.Point(724, 8);
            btn_clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new System.Drawing.Size(105, 30);
            btn_clear.TabIndex = 2;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_run
            // 
            btn_run.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_run.Location = new System.Drawing.Point(836, 8);
            btn_run.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_run.Name = "btn_run";
            btn_run.Size = new System.Drawing.Size(105, 30);
            btn_run.TabIndex = 1;
            btn_run.Text = "Run";
            btn_run.UseVisualStyleBackColor = true;
            btn_run.Click += btn_run_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(4, 3);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(944, 366);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pnl_Export);
            tabPage1.Controls.Add(btn_Export);
            tabPage1.Controls.Add(dg);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Size = new System.Drawing.Size(936, 338);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Result Grid";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl_Export
            // 
            pnl_Export.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            pnl_Export.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnl_Export.Controls.Add(btn_ok);
            pnl_Export.Controls.Add(btn_Cancel);
            pnl_Export.Controls.Add(button5);
            pnl_Export.Controls.Add(label3);
            pnl_Export.Controls.Add(textBox3);
            pnl_Export.Controls.Add(label2);
            pnl_Export.Controls.Add(textBox1);
            pnl_Export.Location = new System.Drawing.Point(172, 62);
            pnl_Export.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pnl_Export.Name = "pnl_Export";
            pnl_Export.Size = new System.Drawing.Size(571, 179);
            pnl_Export.TabIndex = 7;
            pnl_Export.Visible = false;
            pnl_Export.Paint += panel1_Paint;
            // 
            // btn_ok
            // 
            btn_ok.BackColor = System.Drawing.SystemColors.Control;
            btn_ok.Location = new System.Drawing.Point(318, 121);
            btn_ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new System.Drawing.Size(114, 35);
            btn_ok.TabIndex = 17;
            btn_ok.Text = "OK";
            btn_ok.UseVisualStyleBackColor = false;
            btn_ok.Click += btn_ok_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.BackColor = System.Drawing.SystemColors.Control;
            btn_Cancel.Location = new System.Drawing.Point(440, 121);
            btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(114, 35);
            btn_Cancel.TabIndex = 16;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.SystemColors.Control;
            button5.Location = new System.Drawing.Point(440, 30);
            button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(114, 35);
            button5.TabIndex = 15;
            button5.Text = "Select Path";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 73);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 15);
            label3.TabIndex = 14;
            label3.Text = "Delimator";
            // 
            // textBox3
            // 
            textBox3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBox3.Location = new System.Drawing.Point(23, 91);
            textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(532, 22);
            textBox3.TabIndex = 13;
            textBox3.Text = "|";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 23);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 15);
            label2.TabIndex = 12;
            label2.Text = "Path";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(21, 42);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(411, 23);
            textBox1.TabIndex = 11;
            textBox1.Text = "C:\\Result.txt";
            // 
            // btn_Export
            // 
            btn_Export.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Export.Location = new System.Drawing.Point(812, 7);
            btn_Export.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new System.Drawing.Size(108, 29);
            btn_Export.TabIndex = 4;
            btn_Export.Text = "Export Result";
            btn_Export.UseVisualStyleBackColor = true;
            btn_Export.Click += btn_Export_Click;
            // 
            // dg
            // 
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.Location = new System.Drawing.Point(12, 39);
            dg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dg.Name = "dg";
            dg.ReadOnly = true;
            dg.Size = new System.Drawing.Size(909, 284);
            dg.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(dgres);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Size = new System.Drawing.Size(936, 337);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Result Panel";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(832, 7);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(88, 29);
            button1.TabIndex = 3;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgres
            // 
            dgres.AllowUserToAddRows = false;
            dgres.AllowUserToDeleteRows = false;
            dgres.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgres.Location = new System.Drawing.Point(13, 39);
            dgres.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgres.Name = "dgres";
            dgres.ReadOnly = true;
            dgres.Size = new System.Drawing.Size(906, 280);
            dgres.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lbl_Status, txt_Status, prg });
            statusStrip1.Location = new System.Drawing.Point(0, 374);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(960, 24);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl_Status
            // 
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new System.Drawing.Size(63, 19);
            lbl_Status.Text = "Last Query";
            // 
            // txt_Status
            // 
            txt_Status.Name = "txt_Status";
            txt_Status.Size = new System.Drawing.Size(0, 19);
            // 
            // prg
            // 
            prg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            prg.Name = "prg";
            prg.Size = new System.Drawing.Size(117, 18);
            // 
            // SQLWorkbook
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(split);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "SQLWorkbook";
            Size = new System.Drawing.Size(962, 635);
            split.Panel1.ResumeLayout(false);
            split.Panel1.PerformLayout();
            split.Panel2.ResumeLayout(false);
            split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)split).EndInit();
            split.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            pnl_Export.ResumeLayout(false);
            pnl_Export.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dg).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgres).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmb_connections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgres;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Status;
        private System.Windows.Forms.ToolStripStatusLabel txt_Status;
        private System.Windows.Forms.ToolStripProgressBar prg;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Panel pnl_Export;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private ScintillaNET.Scintilla txt;
    }
}
