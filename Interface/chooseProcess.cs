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

        public chooseProcess(Business.DataBaseUser dataBase)
        {
            InitializeComponent();
            _dataBase = dataBase;

            Business.User user = _dataBase.User;

        }


        private void FormChooseProcess_FormClosing(object sender, EventArgs e)
        {
            Close();
        }


        private void viewSoftwareWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultWebpage cwp = new ConsultWebpage();
            cwp.Show();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void editSoftwareListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSWList editList = new EditSWList();
            editList.Show();
        }

    }
}
