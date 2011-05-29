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
        public List<int> ids_dos_softwaresSeleccionados;

        public chooseProcess(Business.DataBaseUser dataBase)
        {
            InitializeComponent();
            //initComponentsConfig();
            _dataBase = dataBase;

            Business.User user = _dataBase.User;
            refreshTableSoftwares();
            refreshTableCaracteristics();

        }

        private void initComponentsConfig()
        {

        }

        private void refreshTableSoftwares()
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
                values.Add("" + s.Id);
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

        private void refreshTableCaracteristics()
        {
            DataTable tabela_caracteristicas = new DataTable();
            tabela_caracteristicas.Columns.Add("ID");
            tabela_caracteristicas.Columns.Add("Name");
            foreach (Business.Characteristic c in _dataBase.Charac.Values)
            {
                tabela_caracteristicas.Rows.Add(c.Id, c.Name);
            }

            DataView view = new DataView(tabela_caracteristicas);
            dataGridViewCharacteristics.DataSource = view;

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
            o.Filter = "beSmart files (*.beSmart)|*.beSmart|All files (*.*)|*.*";
            DialogResult ret = o.ShowDialog();

            if (ret == DialogResult.OK)
            {
                MessageBox.Show("Ainda nao esta a funcionar!");
            }
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "beSmart files (*.beSmart)|*.beSmart|All files (*.*)|*.*";
            DialogResult ret = s.ShowDialog();

            if (ret == DialogResult.OK)
            {
                string name = s.FileName;
                _dataBase.saveInObject(name);

            }
        }

        private void buttonNextChooseSoftwares_Click(object sender, EventArgs e)
        {
            // para apagar a lista já existente
            ids_dos_softwaresSeleccionados = new List<int>();

            string linhas_selecionadas = "Select Softwares ID:\n";

            // vai a todas as linhas das tabelas ver quais estão seleccionadas
            foreach (DataGridViewRow linha in dataGridViewTabelaSoftware.Rows)
            {
                if (linha.Cells[0].Value != null)
                {
                    // convert para int o ID
                    int id = System.Convert.ToInt32(linha.Cells[1].Value);
                    ids_dos_softwaresSeleccionados.Add(id);
                    linhas_selecionadas += id + "\n";
                }
            }
            //MessageBox.Show(linhas_selecionadas);

            // condição para se ter de seleccionar mais de 2 softwares
            if (ids_dos_softwaresSeleccionados.Capacity < 2 || ids_dos_softwaresSeleccionados.Capacity > 16)
            {
                MessageBox.Show("Select between 2 and 16 softwares!");
            }
            else
            {
                tabControlSeparates.SelectedTab = tabPageChooseCriteria;
                progressBar1.Value = 25;
            }
        }

        private void buttonViewWebPage_Click(object sender, EventArgs e)
        {
            ConsultWebpage cwp = new ConsultWebpage(_dataBase);
            cwp.Show();
        }

        private void buttonPreviewToSoftwares_Click(object sender, EventArgs e)
        {
            tabControlSeparates.SelectedTab = tabPageChooseSoftwares;
            progressBar1.Value = 0;
        }

        private void buttonNextChooseCriteria_Click(object sender, EventArgs e)
        {
            tabControlSeparates.SelectedTab = tabPageClassificaoes;
            progressBar1.Value = 50;
        }

        private void buttonPreviewDefiniotWeigths_Click(object sender, EventArgs e)
        {
            tabControlSeparates.SelectedTab = tabPageChooseCriteria;
            progressBar1.Value = 25;
        }

        private void buttonNextDefinitonWeigths_Click(object sender, EventArgs e)
        {
            tabControlSeparates.SelectedTab = tabPageDefinitionPriorities;
            progressBar1.Value = 75;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


    }
}
