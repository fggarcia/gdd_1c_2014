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
    public partial class FormEmpresaAlta : Form
    {
        public string username;
        public string password;

        public FormEmpresaAlta()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (Empresa.validarCampos(textRazonSocial.Text, textCuit.Text, textNombreC.Text, textTelefono.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textCodP.Text, textLocalidad.Text, textCiudad.Text, textDia.Text, textMes.Text, textAnio.Text, textMail.Text, username, password))
            {
                Empresa.crearEmpresa(textRazonSocial.Text, textCuit.Text, textNombreC.Text, textTelefono.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textCodP.Text, textLocalidad.Text, textCiudad.Text, textDia.Text, textMes.Text, textAnio.Text, textMail.Text, username, password);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormABMEmpresa formCliente = new FormABMEmpresa();
            this.Hide();
            formCliente.ShowDialog();
        }
    }
}
