using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DataBase
{
    public class Connect
    {
        private SqlConnection _myConnection;

        /**
         * Constructor default
         * */
        public Connect()
        {
            // username and password is Windows Authentication: Trusted_Connection=yes
            _myConnection = new SqlConnection("user id=nao_interessa;" +
                                             "password=nao_interessa;" +
                                             "server=MIGUEL-PC\\SQLEXPRESS;" +
                                             "Trusted_Connection=yes;" +
                                             "database=LI4;" +
                                             "connection timeout=10");
            


        }

        /**
         * Constructor with parameters
         * */
        public Connect(string username, string password, string server, string name_database, int timeout)
        {
            // username and password is Windows Authentication: Trusted_Connection=yes
            _myConnection = new SqlConnection("user id=" + username + ";" +
                                             "password=" + password + ";" +
                                             "server=" + server + ";" +
                                             "Trusted_Connection=yes;" +
                                             "database=" + name_database + ";" +
                                             "connection timeout=" + timeout);
        }

        /**
         * Constructor with Connect
         * */
        public Connect(Connect c)
        {
            _myConnection = c.MyConnection;

        }

        /**
         * Methods get
         * */
        public SqlConnection MyConnection
        {
            get { return _myConnection; }
        }

        /**
         * Open MyConnection
         * */
        public void openMyConnection()
        {
            try
            {
                _myConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Impossible connect to data base!\n\n" + e.ToString());
                Console.WriteLine("Error: Impossible connect to data base!\n" + e.ToString());
                
            }
        }

        /**
         * Close MyConnection
         * */
        public void closeMyConnection()
        {
            try
            {
                _myConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Impossible disconnect to data base!\n\n" + e.ToString());
                Console.WriteLine("Error: Impossible disconnect to data base!\n" + e.ToString());
            }
        }
    }
}
