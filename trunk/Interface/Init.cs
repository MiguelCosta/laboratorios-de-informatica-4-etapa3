using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase;


namespace Interface
{

    public partial class Init : Form
    {
        private Connect conn;
        private QueryUser queryUser;

        public Init()
        {
            InitializeComponent();
            //this.MaximumSize = new System.Drawing.Size(453, 371);
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 10;
            connecteToDataBase();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            bool login = false;
            login = queryUser.queryUserLogin(username, password);

            if (login)
            {
                MessageBox.Show("Login com sucesso!");
                chooseProcess cp = new chooseProcess();
                cp.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Username: " + username);
                MessageBox.Show("Password: " + password);
            }
            // (varivelUsername = textBoxUsername.Text;
            //variavelPass = textBoxPassword.Text;
            
            
        }

        private void buttonRegisterNow_Click_1(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void connecteToDataBase()
        {
            conn = new Connect();
            conn.openMyConnection();
            queryUser = new QueryUser(conn._myConnection);
        }


    }

    
}

