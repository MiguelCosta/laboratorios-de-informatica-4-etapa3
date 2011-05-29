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
        private Business.DataBaseUser _dataBase;
        private DataBase.Connect _conn;
        private DataBase.QueryUser _queryUser;

        public Init(Business.DataBaseUser dataBase, DataBase.Connect conn, DataBase.QueryUser queryUser)
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';

            // copia o apontador da data base recebida como parametro
            _dataBase = dataBase;
            _conn = conn;
            _queryUser = queryUser;

            textBoxUsername.Text = "extra_database";
            textBoxPassword.Text = "extra_database";

        }



        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string name = textBoxUsername.Text;
            string pass = textBoxPassword.Text;

            bool login = false;
            login = _queryUser.queryUserLogin(name, pass);

            if (login)
            {
                Business.User u = _queryUser.login(name,pass);
                _dataBase.User = u;
                MessageBox.Show("Login com sucesso!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Login incorrecto");
            }
            
        }

        private void buttonRegisterNow_Click_1(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }



    }

    
}

