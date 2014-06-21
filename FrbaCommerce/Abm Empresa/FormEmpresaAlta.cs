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
            Empresa.validarCamposCreacion(textRazonSocial, textCuit, textNombreC, textTelefono, textCalle, textNro, textPiso, textDepto, textCodP, textLocalidad, textCiudad, textDia, textMes, textAnio, textMail, username, password);

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            bool passed = this.ValidateChildren();

            if (passed == false)
            {
                MessageBox.Show("Por favor completar el formulario correctamente");
                return;
            }

            Empresa.crearEmpresa(textRazonSocial.Text, textCuit.Text, textNombreC.Text, textTelefono.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textCodP.Text, textLocalidad.Text, textCiudad.Text, textDia.Text, textMes.Text, textAnio.Text, textMail.Text, username, password);
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormABMEmpresa formABMEmpresa = new FormABMEmpresa();
            formABMEmpresa.MdiParent = this.MdiParent;
            MdiParent.Size = formABMEmpresa.Size + Constantes.aumentoTamanio;
            this.Close();
            formABMEmpresa.Show();
        }

        private void FormEmpresaAlta_Load(object sender, EventArgs e)
        {
        }

    }
}
