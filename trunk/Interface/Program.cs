using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business;
using System.Data;

namespace Interface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Base de Dados Geral do Utulizador
            DataBaseUser dataBase = new DataBaseUser();

            // liga à base de dados
            DataBase.Connect conn;
            DataBase.QueryUser queryUser;
            DataBase.QuerySoftware querySoftware;

            conn = new DataBase.Connect();
            conn.openMyConnection();
            queryUser = new DataBase.QueryUser(conn._myConnection);
            querySoftware = new DataBase.QuerySoftware(conn._myConnection);


            // Apresenta o Login
            Init abertura = new Init(dataBase, conn, queryUser);
            Application.Run(abertura);

            // DataTable com os softwares do User
            DataTable tabelaSoftware = querySoftware.querySoftwareUser(dataBase.User.Username);

            // Apresenta a nova janela
            MessageBox.Show(dataBase.User.toString());
            chooseProcess cp = new chooseProcess(dataBase, tabelaSoftware);
            Application.Run(cp);


            
        }


    }
}
