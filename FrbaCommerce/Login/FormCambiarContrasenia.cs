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
        public FormCambiarContrasenia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textPassword.Validating += new CancelEventHandler(Validaciones.validarPassword_Validating);
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoCambiarPassword;
            command.Parameters.AddWithValue("@p_Id_Usuario", VarGlobables.usuario.user_id);
            command.Parameters.AddWithValue("@p_Pass", textPassword.Text);
            Procedimientos.ejecutarStoredProcedure(command, "Cambio de Password", true);
        }
    }
}
