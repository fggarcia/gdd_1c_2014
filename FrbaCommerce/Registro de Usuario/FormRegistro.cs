using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Registro.crearCliente(textNombreUsuario.Text, textContrasenia.Text, 0) > 0)
            {
                MessageBox.Show("Cuenta creada con éxito");
            }
            else
            {
                MessageBox.Show("No se ha creado la cuenta");
            }

        }
    }
}
