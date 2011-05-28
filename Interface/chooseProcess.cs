using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class chooseProcess : Form
    {
        private Business.DataBaseUser _dataBase;

        public chooseProcess(Business.DataBaseUser dataBase)
        {
            InitializeComponent();
            _dataBase = dataBase;

            Business.User user = _dataBase.User;
            
            refresfTable();

        }

        private void refresfTable()
        {
            // actualizar a tabela inicial
            DataTable tabela_softwares = new DataTable();
            tabela_softwares.Columns.Add("ID");
            tabela_softwares.Columns.Add("Name");
            tabela_softwares.Columns.Add("Link");

            // adicionar as colunas (nome das caracteristicas)
            foreach (Business.Characteristic c in _dataBase.Charac.Values)
            {
                tabela_softwares.Columns.Add(c.Name);
            }

            // adiciona as linhas (info dos softwares)
            foreach (Business.Software s in _dataBase.Software_list.Values)
            {
                // coloca todas as caracteristicas numa List
                List<string> values = new List<string>();
                values.Add(""+s.Id);
                values.Add(s.Name);
                values.Add(s.Link);
                foreach (string cV in s.Charac.Values)
                {
                    values.Add(cV);
                }
                // passa para um array, para ser possivel adicionar uma linha
                string[] array = values.ToArray();
                tabela_softwares.Rows.Add(array);
            }

            // cria uma nova vista para a tabela
            DataView view = new DataView(tabela_softwares);
            dataGridViewTabelaSoftware.DataSource = view;

        }


        private void FormChooseProcess_FormClosing(object sender, EventArgs e)
        {
            Close();
        }


        private void viewSoftwareWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultWebpage cwp = new ConsultWebpage(_dataBase);
            cwp.Show();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void editSoftwareListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSWList editList = new EditSWList();
            editList.Show();
        }

    }
}
