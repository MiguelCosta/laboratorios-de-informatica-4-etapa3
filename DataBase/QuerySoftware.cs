using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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

        /*Selecciona os softwares de um utilizador sem as caracteristicas */
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
                    Console.Write(valor + "\t");
                }
            }

            return tabelaSoftwareDoUser;
        }

        /*Selecciona os softwares de um utilizador com as caracteristicas */
        public DataTable querySoftwareUserWithCarcteristics(string username)
        {
            DataTable result = new DataTable();
            DataTable softwares = querySoftwareUser(username);

            // string auxiliar para mostras os id_s das strings
            String nomes_das_colunas = "";

            // adiciona as colunas ID, NAME e LINK à tabela
            foreach (DataColumn coluna in softwares.Columns)
            {
                result.Columns.Add(coluna.ToString());
                nomes_das_colunas = nomes_das_colunas + coluna.ToString() + "\n";
            }

            // vai buscar um software à lista de softwares
            DataRow linha = softwares.Rows[0];
            int id_software = (int)linha["ID"];

            // agora precisa de saber em que carateristicas é que esse software está caracterizado
            // por isso vou à tabela software_list buscar os nomes das caracteristicas com o id do software

            string select_nomes_caracteristicas = " SELECT caracteristics.catacyeristics_name " +
                                                    " FROM [LI4].[dbo].[software_list], [LI4].[dbo].[caracteristics] " +
                                                    " WHERE software_list.id_software =" + id_software +
                                                    " AND software_list.caracteristics_id = caracteristics.caracteristics_id " +
                                                    " GROUP BY caracteristics.catacyeristics_name";

            // executa a query e coloca numa tabela
            SqlDataReader nomes_caracteristicas = executeQuery(select_nomes_caracteristicas);
            DataTable tabelaNomeCaracteristicas = new DataTable();
            tabelaNomeCaracteristicas.Load(nomes_caracteristicas);

            foreach (DataRow linha_nome_caracteristica in tabelaNomeCaracteristicas.Rows)
            {
                string nome_da_caracteristica = (string)linha_nome_caracteristica[0];
                result.Columns.Add(nome_da_caracteristica);
                nomes_das_colunas = nomes_das_colunas + nome_da_caracteristica + "\n";
            }

            MessageBox.Show("Colunas adiciondas:\n" + nomes_das_colunas);

            // agora já temos as caracteristicas todas, falta ir buscar o valor para cada registo
            // vai a todas as linhas de cada software
            foreach (DataRow linha_de_caracteristicas in softwares.Rows)
            {
                int software_id = (int)linha["ID"];
                string software_name = (string)linha["NAME"];
                string software_link = (string)linha["LINK"];
                // select para buscar as caracteristicas de um software
                string select_caracteristicas_de_um_software = " SELECT software_list.caracteristics_value" +
                                                                " FROM [LI4].[dbo].[software_list], [LI4].[dbo].[software]" +
                                                                " WHERE software_list.id_software =" + software_id +
                                                                " AND software_list.id_software = software.id_software";

                // cria uma tabela com as caracteristicas do software
                SqlDataReader caracteristicas_do_software = executeQuery(select_caracteristicas_de_um_software);
                DataTable tabela_com_as_caracteristicas_de_um_software = new DataTable();
                tabela_com_as_caracteristicas_de_um_software.Load(caracteristicas_do_software);


            }

            return result;

        }


        // recebe uma query e executa
        public SqlDataReader executeQuery(string select)
        {
            SqlDataReader mySoftware = null;

            SqlCommand myCommand = new SqlCommand(select, _myConnection);
            mySoftware = myCommand.ExecuteReader();

            return mySoftware;

        }
    }
}
