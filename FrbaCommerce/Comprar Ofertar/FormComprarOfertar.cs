using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FormComprarOfertar : Form
    {
        public FormComprarOfertar()
        {
            InitializeComponent();
            this.txtEntry.Enabled = false;
        }

        private void FormComprarOfertas_Load(object sender, EventArgs e)
        {
            // Inicializo las validaciones 
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.procedimientoMostrarPublicacionesComprarOfertar;

            Usuarios usuario = VarGlobables.usuario;

            command.Parameters.AddWithValue("@p_IdUsuario", usuario.user_id);

            if (txtDescription.Text == string.Empty)
                command.Parameters.AddWithValue("@p_Description", null);
            else
                command.Parameters.AddWithValue("@p_Description", txtDescription.Text);

            Procedimientos.llenarDataGridView(command, dgvBuy, "DataGridView Comprar Ofertar");
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvBuy);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
