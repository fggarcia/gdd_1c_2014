using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Login
{
    public partial class FormSeleccionRol : Form
    {
        public Usuarios usuario;

        public FormSeleccionRol(Usuarios user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void FormSeleccionRol_Load(object sender, EventArgs e)
        {
            Administracion admin = new Administracion();
            List<Rol> rolesUsuario = admin.obtenerRolesDe(usuario);
            if (rolesUsuario.Count > 0)
            {
                comboBox1.Items.Clear();
                comboBox1.DataSource = null;
                comboBox1.DataSource = rolesUsuario;
                comboBox1.DisplayMember = "Descripcion";
                comboBox1.ValueMember = "Id_Rol";
            }
            else
            {
                MessageBox.Show("El usuario no posee roles habilitados", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ir a un Form y cargar solo las funcionalidades que tenga el usuario.
            usuario.Id_Rol = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            FormMenu formMenu = new FormMenu(usuario);
            this.Hide();
            formMenu.ShowDialog();
            this.Close();
        }
    }
}
