using System;
using System.Windows.Forms;

namespace SQLite_Management_Studio
{
    public partial class frm_AddConnection : Form
    {
        public frm_AddConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var opd = new OpenFileDialog();
            opd.CheckFileExists = false;

            if (opd.ShowDialog() == DialogResult.OK)
                textBox1.Text = opd.FileName;
            else
                textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
                try
                {
                    ConnectionManagerV2.GetConnectionManager().SaveConnection(textBox2.Text, textBox1.Text);
                    MessageBox.Show("Connection Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}