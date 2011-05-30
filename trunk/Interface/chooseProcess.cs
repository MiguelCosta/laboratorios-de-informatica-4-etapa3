﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DataGridViewNumericUpDownElements;


namespace Interface
{

    public partial class chooseProcess : Form
    {
        private Business.DataBaseUser _dataBase;
        public List<int> ids_dos_softwaresSeleccionados;
        public Dictionary<int, string> caracteristicas_escolhidas;
        public Business.DecisionSuport decision;
        public Dictionary<string, float> tabelaSmartNorm;
        public Dictionary<string, double> pesosFinaisClassAHP;

        public chooseProcess(Business.DataBaseUser dataBase)
        {
            InitializeComponent();
            _dataBase = dataBase;

            // estruturas auxiliares para calculo da decisão
            decision = new Business.DecisionSuport();
            tabelaSmartNorm = new Dictionary<string, float>();

            Business.User user = _dataBase.User;

            // configurações iniciais
            refreshTableSoftwares();
            refreshTableCaracteristics();
            buttonTestCons.Enabled = false;
            buttonNextDefinitonWeigths.Enabled = false;

            // formata as tabelas
            // smart();
        }

        private void smart()
        {
            DataGridViewNumericUpDownColumn UpDnColumn = new DataGridViewNumericUpDownColumn();
            UpDnColumn.HeaderText = "Weights";
            UpDnColumn.Width = 130;
            // Set the Minimum, Maximum, and initial Value.
            UpDnColumn.Maximum = 1000;
            UpDnColumn.Minimum = 10;

            // Add UpDnColumn onto DataGridView layout  
            dataGridViewSmart.Columns.Add(UpDnColumn);

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

        private void refreshTableSmart()
        {
            DataTable pesos = new DataTable();
            pesos.Columns.Add("ID");
            pesos.Columns.Add("Name");

            foreach (KeyValuePair<int, string> pair in caracteristicas_escolhidas)
            {
                pesos.Rows.Add(pair.Key, pair.Value);
            }

            DataView view = new DataView(pesos);
            dataGridViewSmart.DataSource = view;
        }

        private void refreshTableAHP()
        {
            DataTable pesos = new DataTable();
            pesos.Columns.Add("Best Software");
            foreach (string name in caracteristicas_escolhidas.Values)
            {
                pesos.Columns.Add(name);
                pesos.Rows.Add(name);
            }

            DataView view = new DataView(pesos);
            dataGridViewAHP.DataSource = view;

            int i = 0;
            int num_ca = caracteristicas_escolhidas.Count;

            while (i < num_ca)
            {
                dataGridViewAHP[i + 1, i].Value = "1";
                i++;
            }
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

        public void loadObject(String filename)
        {
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            _dataBase = (Business.DataBaseUser)bformatter.Deserialize(stream);
            stream.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "beSmart files (*.beSmart)|*.beSmart|All files (*.*)|*.*";
            DialogResult ret = o.ShowDialog();
            String filename = o.FileName;

            if (ret == DialogResult.OK)
            {
                loadObject(filename);
                refreshTableSoftwares();
                refreshTableCaracteristics();
                MessageBox.Show("Agora já deve estar...!");
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
            // apagar a estrutura
            caracteristicas_escolhidas = new Dictionary<int, string>();
            caracteristicas_escolhidas.Clear();


            string linhas_selecionadas = "Select Characteristics ID:\n";

            // vai a todas as linhas das tabelas ver quais estão seleccionadas
            foreach (DataGridViewRow linha in dataGridViewCharacteristics.Rows)
            {
                if (linha.Cells[0].Value != null)
                {

                    // convert para int o ID
                    int id = System.Convert.ToInt32(linha.Cells[1].Value);
                    string name = (string)linha.Cells[2].Value;
                    caracteristicas_escolhidas.Add(id, name);
                    linhas_selecionadas += id + "\n";
                }
            }
            //MessageBox.Show(linhas_selecionadas);

            // condição para se ter de seleccionar mais de 2 softwares
            if (caracteristicas_escolhidas.Count < 1)
            {
                MessageBox.Show("Select at least one characteristics!");
            }
            else
            {
                tabControlSeparates.SelectedTab = tabPageClassificaoes;
                progressBar1.Value = 75;
                refreshTableSmart();
                refreshTableAHP();
            }


        }

        private void buttonPreviewDefiniotWeigths_Click(object sender, EventArgs e)
        {
            tabControlSeparates.SelectedTab = tabPageChooseCriteria;
            progressBar1.Value = 25;
        }

        private void buttonNextDefinitonWeigths_Click(object sender, EventArgs e)
        {





            tabControlSeparates.SelectedTab = tabPageDefinitionPriorities;
        }

        private string procuraIdCha(string name)
        {
            string r = "";
            foreach (KeyValuePair<int, string> pair in caracteristicas_escolhidas)
            {
                if (pair.Value.Equals(name)) r = "" + pair.Key;
            }

            return r;
        }

        private void buttonTestCons_Click(object sender, EventArgs e)
        {
            Dictionary<int, double> matrixC = new Dictionary<int, double>();
            Dictionary<int, double> matrixD = new Dictionary<int, double>();
            matrixC = decision.calculaMatrizC(decision.TableAHP, pesosFinaisClassAHP);
            matrixD = decision.calculaMatrizD(matrixC, pesosFinaisClassAHP);
            double taxa = decision.taxaConsitencia(matrixD);

            if (taxa <= 0.10)
            {
                MessageBox.Show("The consistency Rate is good: " + taxa);
                labelConsistencyRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(19)))));
            }
            else
            {
                MessageBox.Show("The consistency Rate is bad: " + taxa);
                labelConsistencyRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }

            // actualiza a label com a taxa
            labelConsistencyRate.Text = ""+taxa;
            // activa o botão next
            buttonNextDefinitonWeigths.Enabled = true;
        }

        private void buttonCalFinalWe_Click(object sender, EventArgs e)
        {
            int flag = 0;
            foreach (DataGridViewColumn coluna in dataGridViewAHP.Columns)
            {
                if (flag == 0)
                {
                    flag = 1;
                }
                else
                {
                    string name = coluna.Name.ToString();
                    string idA = procuraIdCha(name);
                    foreach (DataGridViewRow linha in dataGridViewAHP.Rows)
                    {
                        string nameB = linha.Cells[0].Value.ToString();
                        string idB = procuraIdCha(nameB);
                        string pointsStr = linha.Cells[name].Value.ToString();
                        float pointf = (float)System.Convert.ToDouble(pointsStr);
                        //MessageBox.Show("idA: " + idA + "\tName: " + name + "\nIDB: " + idB + "\tNameB: " + nameB + "\nPoints: " + pointf);
                        decision.registerClassAHP(idA, idB, pointf);

                    }
                }
            }

            Dictionary<string, Dictionary<string, float>> tabelaNormAHP = new Dictionary<string, Dictionary<string, float>>();
            tabelaNormAHP = decision.normalizeAHP(decision.TableAHP);
            pesosFinaisClassAHP = new Dictionary<string, double>();
            pesosFinaisClassAHP = decision.pesosFinais(tabelaNormAHP);


            DataTable pesos = new DataTable();
            pesos.Columns.Add("ID");
            pesos.Columns.Add("Weight");
            foreach (KeyValuePair<string, double> pair in pesosFinaisClassAHP)
            {
                pesos.Rows.Add(pair.Key, pair.Value);
            }

            DataView view = new DataView(pesos);
            dataGridViewPesosAHP.DataSource = view;


            /*
            foreach (KeyValuePair<string, double> pair in pesosFinaisClassAHP)
            {
                MessageBox.Show(pair.Key + "\t" + pair.Value);
            }*/

            // activa o butão de consistência
            buttonTestCons.Enabled = true;
            buttonCalcSmart.Enabled = false;
        }

        private void buttonCalcSmart_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow linha in dataGridViewSmart.Rows)
            {
                string idChar = linha.Cells[1].Value.ToString();
                int points = System.Convert.ToInt32(linha.Cells[0].Value.ToString());
                decision.registerClass(idChar, points);
            }

            tabelaSmartNorm.Clear();
            tabelaSmartNorm = decision.normalizeSMART(decision.TableCH);


            DataTable pesos = new DataTable();
            pesos.Columns.Add("ID");
            pesos.Columns.Add("Weight");
            foreach (KeyValuePair<string, float> pair in tabelaSmartNorm)
            {
                pesos.Rows.Add(pair.Key, pair.Value);
            }

            DataView view = new DataView(pesos);
            dataGridViewPesosFinaisSmart.DataSource = view;

            buttonNextDefinitonWeigths.Enabled = true;
            buttonCalFinalWe.Enabled = false;
        }


    }
}
