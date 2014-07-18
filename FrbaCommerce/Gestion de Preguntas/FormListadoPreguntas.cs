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
            buttonResponder.Enabled = false;
        }

        private void dgvResponder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonResponder.Enabled = true;
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

        private void buttonResponder_Click(object sender, EventArgs e)
        {
            FormResponderPregunta formResponder = new FormResponderPregunta();
            formResponder.MdiParent = this.MdiParent;
            MdiParent.Size = formResponder.Size + Constantes.aumentoTamanio;
            formResponder.Show();
            SqlConnection conn = Procedimientos.abrirConexion();
            formResponder.idUsuario = Convert.ToString(dgvResponder.CurrentRow.Cells[0].Value);
            formResponder.idPregunta = Convert.ToString(dgvResponder.CurrentRow.Cells[3].Value);
            formResponder.pregunta = Convert.ToString(dgvResponder.CurrentRow.Cells[4].Value);
            Procedimientos.cerrarConexion(conn);
            this.Close();
        }
    }
}
