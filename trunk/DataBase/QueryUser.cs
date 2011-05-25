using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataBase
{

    class QueryUser : Connect
    {
        /* Query que pergunta se existe um utilizador com aquele username e password */
        public bool queryUserLogin(string username, string password)
        {
            bool r = false;
            SqlDataReader myReader = null;
            string select = "SELECT [username] AS username "+ 
                                    "FROM [LI4].[dbo].[user] "+
                                        "WHERE username = '"+username+"' "+
                                        "AND password='"+password+"'";

            SqlCommand myCommand = new SqlCommand(select, _myConnection);

            myReader = myCommand.ExecuteReader();
            
            if (myReader.Read() != null) r = true;

            // devolve o resultado
            return r;
        }

    }
}
