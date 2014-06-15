using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FormABMEmpresa : Form
    {
        public FormABMEmpresa()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormEmpresaAlta formAltaEmpresa = new FormEmpresaAlta();
            formAltaEmpresa.username = Procedimientos.generarUsername();
            formAltaEmpresa.password = Procedimientos.generarPassword();
            MessageBox.Show("El username es: " + formAltaEmpresa.username + "y el password: " + formAltaEmpresa.password);
            this.Hide();
            formAltaEmpresa.ShowDialog();
            this.Close();
        }

        private void FormABMEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void buttonModificarEliminar_Click(object sender, EventArgs e)
        {
            FormEmpresaModElim formModElim = new FormEmpresaModElim();
            this.Hide();
            formModElim.ShowDialog();
            this.Close();
        }
    }
}
