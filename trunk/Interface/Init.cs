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
             ch = new Form2();
        _form2.VisibleChanged += new EventHandler(_form2_VisibleChanged);
    }

    void _form2_VisibleChanged(object sender, EventArgs e)
    {
        if (!_form2.Visible)
            Show();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
        _form2.Show();
    }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
        
        }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegisterNow_Click_1(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
            //this.Dispose();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            
            chooseProcess cp = new chooseProcess();
            cp.Show();
            this.Close();
            cp.Show();
            //chooseProcess newp = (chooseProcess)Application.OpenForms["chooseProcess"];
            //newp.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



    }
}

