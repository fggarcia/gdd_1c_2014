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

        private void FormEmpresaModificacion_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (Empresa.validarCamposModificacion(textNombre.Text, textApellido.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, textPassword.Text))
            {
                Empresa.modificar(textNombre.Text, textApellido.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, textPassword.Text, idUsuario);
            }
        }
    }
}
