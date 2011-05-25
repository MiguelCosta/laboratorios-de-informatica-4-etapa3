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
    public partial class Init : Form
    {
        public Init()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register r= new Register();
            r.Show();
            //this.Dispose();
            
            

        }



    }
}

