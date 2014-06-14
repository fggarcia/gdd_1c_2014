using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FormABMCliente : Form
    {
        public FormABMCliente()
        {
            InitializeComponent();
        }
        
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormClienteModElim formModElim = new FormClienteModElim();
            this.Hide();
            formModElim.ShowDialog();
            this.Close();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormClienteAlta formAltaCliente = new FormClienteAlta();
            formAltaCliente.username = Cliente.generarUsername();
            formAltaCliente.password = Cliente.generarPassword();
            this.Hide();
            formAltaCliente.ShowDialog();
            this.Close();
        }
    }
}
