using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business;

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

            // Apresenta o Login
            Init abertura = new Init(dataBase);
            Application.Run(abertura);

            MessageBox.Show(dataBase.User.toString());
            chooseProcess cp = new chooseProcess(dataBase);
            Application.Run(cp);

            
        }
    }
}
