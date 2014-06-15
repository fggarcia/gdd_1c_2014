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
            formAltaCliente.username = Procedimientos.generarUsername();
            formAltaCliente.password = Procedimientos.generarPassword();
            MessageBox.Show("El username es: " + formAltaCliente.username + "y el password: " + formAltaCliente.password);
            this.Hide();
            formAltaCliente.ShowDialog();
            this.Close();
        }

        private void FormABMCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
