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
            //this.MaximumSize = new System.Drawing.Size(453, 371);
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 10;
            ch_form = new chooseProcess();
            ch_form.VisibleChanged += new EventHandler(_form2_VisibleChanged);
        }

        void _form2_VisibleChanged(object sender, EventArgs e)
        {
            if (!ch_form.Visible)
                Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
           

            // (varivelUsername = textBoxUsername.Text;
            //variavelPass = textBoxPassword.Text;
            
                this.Hide();
                ch_form.Show();
            
        }

        private void buttonRegisterNow_Click_1(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }



    }

    
}

