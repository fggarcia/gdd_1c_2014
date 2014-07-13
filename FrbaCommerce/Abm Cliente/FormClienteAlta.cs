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

        public FormClienteAlta(Usuarios usuario)
        {
            InitializeComponent();
            username = usuario.user_id;
            password = usuario.password;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            bool camposOK = Cliente.validarCamposCreacion(textNombre, textApellido, textCalle, textNro, textPiso, textDepto, textDia, textMes, textAnio, textTelefono, comboBoxTdoc, textNumeroDoc, textCodP, textLocalidad, textMail, username, password);

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            bool passed = this.ValidateChildren();

            if (passed == false)
            {
                MessageBox.Show("Por favor completar el formulario correctamente");
                return;
            }

            if (camposOK)
            {
                Cliente.crear(textNombre.Text, textApellido.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, username, password);
            }
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormABMCliente formABMCliente = new FormABMCliente();
            formABMCliente.MdiParent = this.MdiParent;
            this.MdiParent.Size = formABMCliente.Size + Constantes.aumentoTamanio;
            this.Close();
            formABMCliente.Show();
        }

        private void FormClienteAlta_Load(object sender, EventArgs e)
        {
        }

    }
}
