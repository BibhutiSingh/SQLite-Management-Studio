using System;
using System.Data;
using System.Windows.Forms;

namespace SQLite_Management_Studio
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();

            ds.ReadXml("Conn_Config.xml");
        }
    }
}