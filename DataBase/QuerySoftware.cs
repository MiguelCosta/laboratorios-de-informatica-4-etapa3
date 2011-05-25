using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataBase
{
    public class QuerySoftware : Connect
    {
        /*Construtor */
        public QuerySoftware()
            : base()
        {

        }

        /*Construtor*/
        public QuerySoftware(SqlConnection myConnection)
        {
            this.MyConnection = myConnection;
        }

        public DataTable querySoftwareUser(string username)
        {
            string select = "SELECT software.id_software AS ID, software.name AS NAME, software.link AS LINK " +
                                    "FROM [LI4].[dbo].[software]   " +
                                        "WHERE username = '" + username + "' ";
            SqlDataReader mySoftware = executeQuery(select);
            DataTable tabelaSoftwareDoUser = new DataTable();
            tabelaSoftwareDoUser.Load(mySoftware);

            foreach (DataRow linha in tabelaSoftwareDoUser.Rows)
            {
                Console.WriteLine("\n\nLinha");
                foreach (var valor in linha.ItemArray)
                {
                    Console.Write(valor+"\t");
                }
            }

            return tabelaSoftwareDoUser;
        }


        // recebe uma query e executa
        public SqlDataReader executeQuery(string select)
        {
            SqlDataReader mySoftware = null;

            SqlCommand myCommand = new SqlCommand(select,_myConnection);
            mySoftware = myCommand.ExecuteReader();

            return mySoftware;

        }
    }
}
