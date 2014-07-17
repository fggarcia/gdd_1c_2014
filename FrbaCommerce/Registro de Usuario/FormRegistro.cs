using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Empresa;
using System.Data.SqlClient;
using FrbaCommerce.Login;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
            //ver como pasarle a los formularios el nombre de usuario y contraseña.
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool passed = this.ValidateChildren();

            if (passed == false)
            {
                MessageBox.Show("Por favor completar el formulario correctamente");
                return;
            }

            if (!comboBoxRol.SelectedValue.Equals(null))
            {
                Usuarios usuario = new Usuarios(textNombreUsuario.Text, FormLogin.getSha256(textContrasenia.Text));
                if (comboBoxRol.Text.ToUpper().Equals(Constantes.RolCliente.ToUpper()))
                {
                    FormClienteAlta formCliente = new FormClienteAlta(usuario);
                    this.Hide();
                    formCliente.ShowDialog();
                    this.Close();
                    
                }
                if (comboBoxRol.Text.ToUpper().Equals(Constantes.RolEmpresa.ToUpper()))
                {
                    FormEmpresaAlta formEmpresa = new FormEmpresaAlta(usuario);
                    this.Hide();
                    formEmpresa.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            Procedimientos.LlenarComboBoxDesdeProcedure(comboBoxRol, "LOS_OPTIMISTAS.proc_registrarUsuarioRoles", "Id_Rol", "Descripcion", null, null);

            // Inicializo las validaciones 
            this.AutoValidate = AutoValidate.EnableAllowFocusChange; // Sirve para que te deje hacer focus en otro control aunque de error

            textNombreUsuario.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textContrasenia.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);

            textNombreUsuario.Validating += new CancelEventHandler(Validaciones.validarUnicidadUsername_Validating);
        }

        private void textContrasenia_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
