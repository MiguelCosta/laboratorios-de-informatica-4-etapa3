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
        public DataBase.QueryUser _queryUser;

        public Register(DataBase.QueryUser queryUser)
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 10;
            textBoxPasswordConfirmation.PasswordChar = '*';
            //textBoxPasswordConfirmation.MaxLength = 10;

            _queryUser = queryUser;
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            string name = textBoxUserName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string passwordConfirmation = textBoxPasswordConfirmation.Text;

            MessageBox.Show(name+"\n"+email+"\n"+password+"\n"+passwordConfirmation);

            bool r = _queryUser.queryUserLoginUsername(name,email);
            if (r)
            {
                MessageBox.Show("The register is already in Database.");
            }
            else
            {
                if (!name.Equals("") && !email.Equals("") && password.Equals(passwordConfirmation))
                {
                    _queryUser.insertUser(name, email, password);
                    MessageBox.Show("You are successful register.");
                }
                else
                {
                    MessageBox.Show("The information isn't correct!");
                }
            }
            

        }


        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }


    }
}
