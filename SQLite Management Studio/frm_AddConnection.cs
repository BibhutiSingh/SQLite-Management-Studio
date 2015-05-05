﻿using System;
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
    public partial class frm_AddConnection : Form
    {
        public frm_AddConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.CheckFileExists = false;

            if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                

               
                    textBox1.Text = opd.FileName;



               


            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length != 0) && (textBox1.Text != string.Empty))
            {
                if (cls_connection.SaveConnection(textBox2.Text, textBox1.Text) == true)
                    MessageBox.Show("Connection Added");
                else
                    MessageBox.Show(cls_connection.Result);




            }
        }
    }
}
