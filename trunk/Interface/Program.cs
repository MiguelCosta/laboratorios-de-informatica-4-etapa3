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

            MessageBox.Show(dataBase.toString());

            // insere as caracteristicas na base de dados            
            querySoftware.querySoftwareUserCarcteristics(dataBase);

            MessageBox.Show(dataBase.toString());

            // inseres os softwares na base de dados
            querySoftware.querySoftwareUserSoftwares(dataBase);
            MessageBox.Show(dataBase.toString());

            // Apresenta a nova janela
           
            chooseProcess cp = new chooseProcess(dataBase);
            Application.Run(cp);


            
        }


    }
}
