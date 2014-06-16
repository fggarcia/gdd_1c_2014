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
            comboBox1.DataSource = admin.obtenerRolesDe(usuario);
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Id_Rol";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
