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


        /*######## vai criar todas as caracteristicas do utilizador e colocar na base de dados ########*/
        public void querySoftwareUserCarcteristics(Business.DataBaseUser base_dados)
        {
            // username do utilizador
            string username = base_dados.User.Username;

            // softwares que o utilizador possui
            DataTable softwares = querySoftwareUser(username);

            // ids das caracteristicas que esses softwares tem
            DataTable ids_caracteristicas = queryID_Caracteristicas_Lista_Softwares(softwares);

            // agora é preciso pegar nesses ids e procurar na tabela de caracteristicas


        }



        /* cria uma tabela com os ids das caracteristicas que uma lista de softwares possui */
        public DataTable queryID_Caracteristicas_Lista_Softwares(DataTable softwares)
        {
            DataTable result = new DataTable();

            // id do software para procurar as caracteristicas
            DataRow linha = softwares.Rows[0];
            int id_software = (int)linha["ID"];

            string select_caracteristicas_de_um_software = @" SELECT software_list.caracteristics_id 
                                                                FROM [LI4].[dbo].[software_list], [LI4].[dbo].[software] 
                                                                WHERE software_list.id_software =" + id_software +
                                                                " AND software_list.id_software = software.id_software";
            // tabela com todos os ids_desse software
            result = executeQuery_DataTable(select_caracteristicas_de_um_software);

            return result;
        }

        /* pega numa tabela com os ids das caracteristicas e vai criar um Dictionary com as caracteristicas */
        public Dictionary<string, Business.Characteristic> queryCriar_as_caracteristicas(DataTable ids_caracteristicas)
        {
            Dictionary<string, Business.Characteristic> caracteristicas = new Dictionary<string, Business.Characteristic>();

            foreach (DataRow linha in ids_caracteristicas.Rows)
            {
                // através do id vai criar uma caracteristica
                int id = (int)linha[0];
                Business.Characteristic carac = queryCriaCaracteristica(id);
                // adiciona a caracteristica ao Dictionary
                //caracteristicas.Add(carac.Id, carac);
            }

            return caracteristicas;
        }

        /* pega num id e cria a Caracteristica */
        public Business.Characteristic queryCriaCaracteristica(int id)
        {
            Business.Characteristic result = new Business.YesNoCharacteristic();

            string select_type_caracteristica = @"SELECT caracteristics_id AS ID, caracteristics_type AS TYPE, catacyeristics_name AS NAME, value AS VALUE, value_order AS VALUE_ORDER
                                                    FROM [LI4].[dbo].[caracteristics]
                                                    WHERE caracteristics_id =" + id;

            DataTable info_da_caracteristica = executeQuery_DataTable(select_type_caracteristica);
            string tipo;

            // vai buscar à tabela o tipo 
            DataRow linha = info_da_caracteristica.Rows[0];
            tipo = (string) linha["TYPE"];

            // se for do tipo booleano
            if (tipo.Equals("bool")){
                int id_carac = (int) linha["ID"];
                string name = (string) linha["NAME"];

                result = new Business.YesNoCharacteristic(id_carac,name,false);
            }

            // se for do tipo numerico
            if (tipo.Equals("numeric")){
                int id_carac = (int) linha["ID"];
                string name = (string) linha["NAME"];
                // para que o value ??
                result = new Business.NumericCharacteristic(id_carac,name,0);
            }
            if (tipo.Equals("qualitative")) result = new Business.QualitativeCharacteristic();



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


        // recebe uma query, executa e devolve uma tabela com os resultados
        public DataTable executeQuery_DataTable(string select)
        {
            SqlDataReader mySoftware = null;

            SqlCommand myCommand = new SqlCommand(select, _myConnection);
            mySoftware = myCommand.ExecuteReader();


            DataTable result = new DataTable();
            result.Load(mySoftware);

            return result;
        }

    }
}
