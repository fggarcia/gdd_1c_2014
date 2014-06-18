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
    public partial class FormEmpresaModificacion : Form
    {
        public string idUsuario;

        public FormEmpresaModificacion()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            bool camposOK = Empresa.validarCamposModificacion(textRazonSocial, textCuit, textNombreC, textTelefono, textCalle, textNro, textPiso, textDepto, textCodP, textLocalidad, textCiudad, textDia, textMes, textAnio, textMail, textPassword);
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            bool passed = this.ValidateChildren();

            if (passed == false)
            {
                MessageBox.Show("Por favor completar el formulario correctamente");
                return;
            }
            if (camposOK)
            {
                Empresa.modificar(textRazonSocial.Text, textCuit.Text, textNombreC.Text, textTelefono.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textCodP.Text, textLocalidad.Text, textCiudad.Text, textDia.Text, textMes.Text, textAnio.Text, textMail.Text, textPassword.Text, idUsuario);
            }
            else
            {
                this.Hide();
                FormABMEmpresa form = new FormABMEmpresa();
                form.ShowDialog();
            }
        }
    }
}
