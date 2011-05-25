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
        public SqlConnection _myConnection;
        private string _username;
        private string _password;
        private string _server;
        private string _name_database;
        private int _timeout;

        /**
         * Constructor default
         * */
        public Connect()
        {
            // username and password is Windows Authentication: Trusted_Connection=yes
            _username = "nada";
            _password = "nada";
            _server = "MIGUEL-PC\\SQLEXPRESS";
            _name_database = "LI4";
            _timeout = 5;
            _myConnection = new SqlConnection("user id=" + _username +
                                             ";password=" + _password +
                                             ";server=" + _server +
                                             ";Trusted_Connection=yes" +
                                             ";database=" + _name_database +
                                             ";connection timeout=" + _timeout +
                                             ";MultipleActiveResultSets = True");
            


        }

        /**
         * Constructor with parameters
         * */
        public Connect(string username, string password, string server, string name_database, int timeout)
        {
            _username = username;
            _password = password;
            _server = server;
            _name_database = name_database;
            _timeout = timeout;
            // username and password is Windows Authentication: Trusted_Connection=yes
            _myConnection = new SqlConnection("user id=" + _username +
                                             ";password=" + _password +
                                             ";server=" + _server +
                                             ";Trusted_Connection=yes" +
                                             ";database=" + _name_database + 
                                             ";connection timeout=" + _timeout+
                                             ";MultipleActiveResultSets = True");
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
            set { _myConnection = value; }
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
