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
            if (!comboBoxRol.SelectedValue.Equals(null))
            {
                if (comboBoxRol.SelectedText.Equals(Constantes.RolCliente))
                {
                    FormClienteAlta formCliente = new FormClienteAlta();
                    this.Hide();
                    formCliente.ShowDialog();
                    this.Close();
                }
                if (comboBoxRol.SelectedText.Equals(Constantes.RolEmpresa))
                {
                    FormEmpresaAlta formEmpresa = new FormEmpresaAlta();
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
            Procedimientos.LlenarComboBox(comboBoxRol, "LOS_OPTIMISTAS.Rol", "Id_Rol", "Descripcion", null, null);
        }
    }
}
