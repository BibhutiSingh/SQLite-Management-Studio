using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLite_Management_Studio
{
    public partial class frm_Export : Form
    {
        SQLWorkbook sqw;
        public frm_Export(SQLWorkbook sq)
        {
            InitializeComponent();
            sqw = sq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog dlg = new FolderBrowserDialog();

            //if (dlg.ShowDialog() == DialogResult.OK)
            //    textBox1.Text = dlg.SelectedPath;
            //else
            //    textBox1.Text = "C:\\";

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Result.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
                textBox1.Text = dlg.FileName;
            else
                textBox1.Text = "C:\\Result.txt";

        }

        private void frm_Export_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                MessageBox.Show("Give deliminator");
            else
                //sqw.Export(textBox1 .Text.Trim() ,textBox3 .Text);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
