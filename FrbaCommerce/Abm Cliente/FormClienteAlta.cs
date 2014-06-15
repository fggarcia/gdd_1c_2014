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
            Procedimientos.LlenarComboBox(comboBoxTdoc, "LOS_OPTIMISTAS.Tipo_Documento", "Id_Tipo_Documento", "Id_Tipo_Documento", null, null);
            
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
            if (Cliente.validarCampos(textNombre.Text, textApellido.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password))
            {
                Cliente.crear(textNombre.Text, textApellido.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormABMCliente formCliente = new FormABMCliente();
            this.Hide();
            formCliente.ShowDialog();
        }
    }
}
