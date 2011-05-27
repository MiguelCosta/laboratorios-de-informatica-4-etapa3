using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class chooseProcess : Form
    {
        private Business.DataBaseUser _dataBase;
        private DataTable _dataTableSoft;

        public chooseProcess(Business.DataBaseUser dataBase, DataTable tabelaSoftware)
        {
            InitializeComponent();
            _dataBase = dataBase;

            Business.User user = _dataBase.User;
            _dataTableSoft = tabelaSoftware;

            dataGridViewTabelaSoftware.DataSource = tabelaSoftware;

            MessageBox.Show("login2: "+user.toString());
            

        }



        private void FormChooseProcess_FormClosing(object sender, EventArgs e)
        {
            Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chooseProcess_Load(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void viewSoftwareWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultWebpage cwp = new ConsultWebpage();
            cwp.Show();
            
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
