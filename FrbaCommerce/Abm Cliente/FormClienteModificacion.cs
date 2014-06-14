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
        public FormClienteModificacion()
        {
            InitializeComponent();
        }

        private void FormABMClienteModificacion_Load(object sender, EventArgs e)
        {
            textNombre.Text = Procedimientos.obtenerDato("LOS_OPTIMISTAS.Usuario", "Nombre", groupBoxDatos.Text);
            textApellido.Text = Procedimientos.obtenerDato("LOS_OPTIMISTAS.Usuario", "Apellido", groupBoxDatos.Text);
            comboBoxTdoc.Text = Procedimientos.obtenerDato("LOS_OPTIMISTAS.Usuario", "Nombre", groupBoxDatos.Text);
            textNombre.Text = Procedimientos.obtenerDato("LOS_OPTIMISTAS.Usuario", "Nombre", groupBoxDatos.Text);
            textNombre.Text = Procedimientos.obtenerDato("LOS_OPTIMISTAS.Usuario", "Nombre", groupBoxDatos.Text);
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormABMClienteModificacion_Load_1(object sender, EventArgs e)
        {

        }
    }
}
