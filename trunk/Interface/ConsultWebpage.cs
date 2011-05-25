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
    public partial class ConsultWebpage : Form
    {
        public ConsultWebpage()
        {
            InitializeComponent();
        }

        private void ConsultWebpage_FormClosing(Object sender, FormClosingEventArgs e) 
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vai buscar os softwares a bd
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultWebpage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lI4DataSet.software' table. You can move, or remove it, as needed.
            this.softwareTableAdapter.Fill(this.lI4DataSet.software);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
