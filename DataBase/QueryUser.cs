using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataBase
{

    public class QueryUser : Connect
    {
        public QueryUser()
            : base()
        {

        }


        public QueryUser(SqlConnection myConnection)
        {
            this.MyConnection = myConnection;
        }


        /* Query que pergunta se existe um utilizador com aquele username e password */
        public bool queryUserLogin(string username, string password)
        {
            // resultado
            bool r = false;

            SqlDataReader myReader = null;

            string select = "SELECT [username] AS username " +
                                    "FROM [LI4].[dbo].[user] " +
                                        "WHERE username = '" + username + "' " +
                                        "AND password='" + password + "'";

            SqlCommand myCommand = new SqlCommand(select, this.MyConnection);

            myReader = myCommand.ExecuteReader();

            if (myReader.Read()) r = true;

            return r;
        }

    }
}
