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
    public partial class FormABMRolModificar : Form
    {
        public FormABMRolModificar()
        {
            InitializeComponent();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMRol formAbmRol = new FormABMRol();
            formAbmRol.MdiParent = this.MdiParent;
            MdiParent.Size = formAbmRol.Size + Constantes.aumentoTamanio;
            this.Close();
            formAbmRol.Show();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
