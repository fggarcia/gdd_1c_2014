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
    public partial class FormABMClienteAlta : Form
    {

        public FormABMClienteAlta()
        {
            InitializeComponent();
            
        }

        //**********************************************************
        //*  GENERACION DE USERNAME Y PASSWORD AUTOMATICOS
        //**********************************************************

        //TODO Aca habría que preguntar si ya existe username y password, es decir
        //si se está registrando un usuario ya ingresó estos datos y no habría que pisarlos
        public static string generarUsername()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        public static string generarPassword()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        string username = generarUsername();
        string password = generarPassword();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (Cliente.validarCampos(textNombre.Text, textApellido.Text, textCalle.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password))
            {
                if (Cliente.crearCliente(textNombre.Text, textApellido.Text, textCalle.Text, textDpto.Text, textPiso.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password) > 0)
                {
                    MessageBox.Show("Usuario creado correctamente");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxTdoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
