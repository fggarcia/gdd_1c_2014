using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Login
{
    public partial class FormCambiarContrasenia : Form
    {
        String usuario;
        public FormCambiarContrasenia(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textPassword.Validating += new CancelEventHandler(Validaciones.validarPassword_Validating);
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoCambiarPassword;
            command.Parameters.AddWithValue("@p_Id_Usuario", usuario);
            command.Parameters.AddWithValue("@p_Pass", FormLogin.getSha256(textPassword.Text));
            Procedimientos.ejecutarStoredProcedure(command, "Cambio de Password", true);
            this.Close();
        }
    }
}
