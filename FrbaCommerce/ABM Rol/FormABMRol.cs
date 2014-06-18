using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormABMRol : Form
    {
        public FormABMRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonInhabilitar_Click(object sender, EventArgs e)
        {

        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormABMRolAlta formRolAlta = new FormABMRolAlta();
            this.Hide();
            formRolAlta.ShowDialog();
            this.Close();
        }
    }
}
