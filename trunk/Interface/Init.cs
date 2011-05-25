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

    public partial class Init : Form
    {
        private chooseProcess ch_form;

        public Init()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            ch_form = new chooseProcess();
            ch_form.VisibleChanged += new EventHandler(_form2_VisibleChanged);
        }

        void _form2_VisibleChanged(object sender, EventArgs e)
        {
            if (!ch_form.Visible)
                Show();
        }

        private void FormInit_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            ch_form.Show();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegisterNow_Click_1(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {


        }


    }

    
}

