﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            SqlCommand myCommand = new SqlCommand(select, _myConnection);
            myReader = myCommand.ExecuteReader();

            // se tiver algo para ler é porque existe o utilizador
            if (myReader.Read()) r = true;

            return r;
        }

        /* Verifica se um username ou email já está registado na base de dados */
        public bool queryUserLoginUsername(string username, string email)
        {
            // resultado
            bool r = false;
            SqlDataReader myReader = null;
            string select = "SELECT [username] AS username " +
                                    "FROM [LI4].[dbo].[user] " +
                                        "WHERE username = '" + username + "' " +
                                        "OR email='" + email + "'";

            SqlCommand myCommand = new SqlCommand(select, _myConnection);
            myReader = myCommand.ExecuteReader();

            // se tiver algo para ler é porque existe o utilizador
            if (myReader.Read()) r = true;

            return r;
        }

        /*Cria um User com os dados da Base de Dados*/
        public Business.User login(string username, string password)
        {
            Business.User u = new Business.User();
            SqlDataReader myReader = null;
            string select = "SELECT [username] AS USERNAME, [password] AS PASSWORD, [email] AS EMAIL" +
                                " FROM [LI4].[dbo].[user] " +
                                " WHERE username = '" + username + "' " +
                                    "AND password = '" + password + "'";
            SqlCommand myCommand = new SqlCommand(select, _myConnection);
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                u.Username = (string)myReader["USERNAME"];
                u.Password = (string)myReader["PASSWORD"];
                u.Email = (string)myReader["EMAIL"];
            }

            return u;
        }

        /*Insere um user*/
        public bool insertUser(string username, string mail, string password)
        {
            
            string insert = @"INSERT INTO [LI4].[dbo].[user] VALUES ('" + username + "','" + password + "','" + mail + "',CURRENT_TIMESTAMP);";
            MessageBox.Show(insert);

            SqlCommand command = new SqlCommand(insert, _myConnection);

            SqlTransaction tr = _myConnection.BeginTransaction();
            command.Transaction = tr;

            try
            {
                command.ExecuteNonQuery();
                
                tr.Commit();
                MessageBox.Show("Efectuado");
                return true;
            }
            catch (SqlException e)
            {
                tr.Rollback();
                return false;
            }

        }


    }
}
