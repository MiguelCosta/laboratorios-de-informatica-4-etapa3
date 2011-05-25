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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 10;
            textBoxPasswordConfirmation.PasswordChar = '*';
            textBoxPasswordConfirmation.MaxLength = 10;
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

           //ler texto e adicionar user na bd
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
