using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Login;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FormListadoPreguntas : Form
    {
        public FormListadoPreguntas()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormListadoPreguntas_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //Llenar DataGridView con las preguntas realizadas
            SqlCommand commandRea = new SqlCommand();
            commandRea.CommandType = CommandType.StoredProcedure;
            commandRea.CommandText = Constantes.procedimientoListarRespuestas;
            commandRea.Parameters.AddWithValue("@Id_Usuario", FormSeleccionRol.usuario.user_id);
            Procedimientos.llenarDataGridView(commandRea, dgvRealizadas, "DataGridView Preguntas Realizadas");

            //Llenar DataGridView con las preguntas por responder
            SqlCommand commandResp = new SqlCommand();
            commandResp.CommandType = CommandType.StoredProcedure;
            commandResp.CommandText = Constantes.procedimientoListarPreguntas;
            commandResp.Parameters.AddWithValue("@Id_Usuario", FormSeleccionRol.usuario.user_id);
            Procedimientos.llenarDataGridView(commandResp, dgvResponder, "DataGridView Preguntas por Responder");


        }
    }
}
