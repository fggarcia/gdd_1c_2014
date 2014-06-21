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
    public partial class FormABMRolBaja : Form
    {
        public FormABMRolBaja()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxBuscarRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMRol formAbmRol = new FormABMRol();
            formAbmRol.MdiParent = this.MdiParent;
            MdiParent.Size = formAbmRol.Size + Constantes.aumentoTamanio;
            this.Close();
            formAbmRol.Show();
        }
    }
}
