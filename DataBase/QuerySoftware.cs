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


        /*#############################################################################################*/
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
            Dictionary<int, Business.Characteristic> car = queryCriar_as_caracteristicas(ids_caracteristicas);

            /*
            MessageBox.Show("Aqui_1");
            foreach (Business.Characteristic c in car.Values)
            {
                MessageBox.Show(c.toString());
            }
            */
            base_dados.Charac = car;
        }




        /* cria uma tabela com os ids das caracteristicas que uma lista de softwares possui */
        public DataTable queryID_Caracteristicas_Lista_Softwares(DataTable softwares)
        {
            DataTable result = new DataTable();

            try
            {
                // id do software para procurar as caracteristicas
                DataRow linha = softwares.Rows[0];
                int id_software = (int)linha["ID"];

                string select_caracteristicas_de_um_software = @" SELECT software_list.caracteristics_id 
                                                                FROM [LI4].[dbo].[software_list], [LI4].[dbo].[software] 
                                                                WHERE software_list.id_software =" + id_software +
                                                                    " AND software_list.id_software = software.id_software";
                // tabela com todos os ids_desse software
                result = executeQuery_DataTable(select_caracteristicas_de_um_software);
            }
            catch (Exception e)
            {
                MessageBox.Show("Não contêm caracteristicas associadas ao utilizador!");
                Console.WriteLine(e.Message);
            }
            return result;
        }

        /* pega numa tabela com os ids das caracteristicas e vai criar um Dictionary com as caracteristicas */
        public Dictionary<int, Business.Characteristic> queryCriar_as_caracteristicas(DataTable ids_caracteristicas)
        {
            Dictionary<int, Business.Characteristic> caracteristicas = new Dictionary<int, Business.Characteristic>();

            foreach (DataRow linha in ids_caracteristicas.Rows)
            {
                // através do id vai criar uma caracteristica
                int id = (int)linha[0];
                Business.Characteristic carac = queryCriaCaracteristica(id);
                // adiciona a caracteristica ao Dictionary
                caracteristicas.Add(carac.Id, carac);
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

            // toda a informacao da caracteristica
            DataTable info_da_caracteristica = executeQuery_DataTable(select_type_caracteristica);
            string tipo;

            // vai buscar à tabela o tipo 
            DataRow linha = info_da_caracteristica.Rows[0];
            tipo = (string)linha["TYPE"];

            // se for do tipo booleano
            if (tipo.Equals("bool"))
            {
                int id_carac = (int)linha["ID"];
                string name = (string)linha["NAME"];

                result = new Business.YesNoCharacteristic(id_carac, name, false);
            }

            // se for do tipo numerico
            if (tipo.Equals("numeric"))
            {
                int id_carac = (int)linha["ID"];
                string name = (string)linha["NAME"];
                // para que o value ??
                result = new Business.NumericCharacteristic(id_carac, name, 0);
            }

            if (tipo.Equals("qualitative"))
            {
                result = new Business.QualitativeCharacteristic();
                // usa o metodo auxiliar que recebe toda a info e cria a caracteristica
                result = creatQualitativeCharacteristic(info_da_caracteristica);
            }

            return result;
        }

        // metodo auxiliar para criar uma QualitativeCharacteristic
        public Business.QualitativeCharacteristic creatQualitativeCharacteristic(DataTable info)
        {
            Business.QualitativeCharacteristic r = new Business.QualitativeCharacteristic();

            // para só inserir uma vez o nome e o id da caracteristica
            bool nome_e_id_adicionados = false;
            // para adicionar os valores à caracteristica
            foreach (DataRow linha in info.Rows)
            {
                if (!nome_e_id_adicionados)
                {
                    int id_carac = (int)linha["ID"];
                    string name = (string)linha["NAME"];
                    r.Id = id_carac;
                    r.Name = name;
                    // para nao voltar a adicionar o nome e o id
                    nome_e_id_adicionados = true;
                }
                string value = (string)linha["VALUE"];
                int value_order = (int)linha["VALUE_ORDER"];
                Business.Value v = new Business.Value(value, value_order);
                r.addValue(v);
            }

            return r;
        }

        /*#############################################################################################*/

        /*#############################################################################################*/
        /*########### vai criar todos os softwares do utilizador e colocar na base de dados ###########*/
        public void querySoftwareUserSoftwares(Business.DataBaseUser base_dados)
        {
            // username do utilizador
            string username = base_dados.User.Username;

            // vai buscar todos os softwares do utilizador
            DataTable softwares = querySoftwareUser(username);

            // dictionary com os softwares
            Dictionary<int, Business.Software> software_list = querySoftwareUserCreateDictionarySoftware(softwares);

            // coloca os softwares na base de dados
            base_dados.Software_list = software_list;


        }

        // recebe a informacao dos softwares, vai associar as caracteristicas e cria-los
        public Dictionary<int, Business.Software> querySoftwareUserCreateDictionarySoftware(DataTable softwares)
        {
            // resultado de todos os softwares
            Dictionary<int, Business.Software> software_list = new Dictionary<int, Business.Software>();

            foreach (DataRow linha in softwares.Rows)
            {
                int id_software = (int)linha["ID"];
                string name = (string)linha["NAME"];
                string link = (string)linha["LINK"];
                // tabela com as caracteristicas de um software
                DataTable caracteristicas_do_software = querySoftwareCaracteristicsOfSoftware(id_software);
                // cria um software
                Business.Software software = querySoftwareCreateSoftwareWithCaracteristics(id_software, name, link, caracteristicas_do_software);
                //MessageBox.Show(software.toString());
                // adiciona à lista de softwares
                software_list.Add(software.Id, software);
            }

            return software_list;
        }

        
        // devolve uma tabela com o id e o valor das caracteristicas do software
        public DataTable querySoftwareCaracteristicsOfSoftware(int id_software)
        {
            string select = @"SELECT    [id_software]           AS ID_SOFTWARE, 
                                        [caracteristics_id]     AS ID_CARACTERISTICS, 
                                        [caracteristics_value]  AS CARACTERISTICS_VALUE
                                    FROM [LI4].[dbo].[software_list]
                                    WHERE id_software =" + id_software;

            DataTable caracteristicas_do_software = executeQuery_DataTable(select);
            return caracteristicas_do_software;
        }



        // através de uma tabela com as caracteristicas vai criar o software
        public Business.Software querySoftwareCreateSoftwareWithCaracteristics(int id_software, string nome, string link, DataTable caracteristicas_do_software)
        {
            Business.Software sof = new Business.Software();
            sof.Id = id_software;
            sof.Name = nome;
            sof.Link = link;

            Dictionary<int, string> charac = new Dictionary<int, string>();
            foreach (DataRow linha in caracteristicas_do_software.Rows)
            {
                int caracteristics_id = (int)linha["ID_CARACTERISTICS"];
                string caracteristics_value = (string)linha["CARACTERISTICS_VALUE"];
                charac.Add(caracteristics_id, caracteristics_value);
            }
            // coloca as caracteristicas no software
            sof.Charac = charac;
            return sof;
        }
        /*#############################################################################################*/

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
