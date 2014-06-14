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
    public partial class FormClienteAlta : Form
    {
        public string username;
        public string password;

        public FormClienteAlta()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
            if (Cliente.validarCampos(textNombre.Text, textApellido.Text, textDomicilio.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password))
            {
                Cliente.crearCliente(textNombre.Text, textApellido.Text, textDomicilio.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormABMCliente formCliente = new FormABMCliente();
            this.Hide();
            formCliente.ShowDialog();
        }

        private void comboBoxTdoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormABMClienteAlta_Load(object sender, EventArgs e)
        {

        }

        private void groupBoxDatos_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxAltaCliente_Enter(object sender, EventArgs e)
        {

        }
    }
}
