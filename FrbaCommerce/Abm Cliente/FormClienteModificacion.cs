using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FormClienteModificacion : Form
    {
        public string idUsuario;

        public FormClienteModificacion()
        {
            InitializeComponent();
        }

        private void FormABMClienteModificacion_Load(object sender, EventArgs e)
        {
            Procedimientos.LlenarComboBox(comboBoxTdoc, "LOS_OPTIMISTAS.Tipo_Documento", "Id_Tipo_Documento", "Id_Tipo_Documento", null, null);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            bool camposOK = Cliente.validarCamposModificacion(textNombre, textApellido, textCalle, textNro, textPiso, textDepto, textDia, textMes, textAnio, textTelefono, comboBoxTdoc, textNumeroDoc, textCodP, textLocalidad, textMail, textPassword);

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            bool passed = this.ValidateChildren();

            if (passed == false)
            {
                MessageBox.Show("Por favor completar el formulario correctamente");
                return;
            }
            if (camposOK)
            {
                Cliente.modificar(textNombre.Text, textApellido.Text, textCalle.Text, textNro.Text, textPiso.Text, textDepto.Text, textDia.Text, textMes.Text, textAnio.Text, textTelefono.Text, comboBoxTdoc.Text, textNumeroDoc.Text, textCodP.Text, textLocalidad.Text, textMail.Text, textPassword.Text, idUsuario);
                FormABMCliente formABMCliente = new FormABMCliente();
                formABMCliente.MdiParent = this.MdiParent;
                this.Close();
                formABMCliente.Show();
            }
            else
            {
                FormABMCliente formABMCliente = new FormABMCliente();
                formABMCliente.MdiParent = this.MdiParent;
                MdiParent.Size = formABMCliente.Size + Constantes.aumentoTamanio;
                this.Close();
                formABMCliente.Show();
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormABMCliente formABMCliente = new FormABMCliente();
            formABMCliente.MdiParent = this.MdiParent;
            MdiParent.Size = formABMCliente.Size + Constantes.aumentoTamanio;
            this.Close();
            formABMCliente.Show();
        }

        private void FormClienteModificacion_Load(object sender, EventArgs e)
        {
        }

        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoHabilitarUsuario;
            command.Parameters.AddWithValue("@p_Id_Usuario", idUsuario);
            Procedimientos.ejecutarStoredProcedure(command, "Habilitacion de usuario", false);
        }
    }
}
