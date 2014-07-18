using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FormResponderPregunta : Form
    {
        public string idUsuario;
        public string pregunta;
        public string idPregunta;
        char[] espacios = {' '};

        public FormResponderPregunta()
        {
            InitializeComponent();
        }

        private void FormResponderPregunta_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            textPregunta.Text = pregunta;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoSubirRespuesta;
            command.Parameters.AddWithValue("@Id_Pregunta", idPregunta);
            command.Parameters.AddWithValue("@Id_Usuario", idUsuario);
            command.Parameters.AddWithValue("@Preg_Respuesta", textRespuesta.Text);
            if (textRespuesta.Text.TrimEnd(espacios).TrimStart(espacios) != "")
                Procedimientos.ejecutarStoredProcedure(command, "Respuesta", true);
            else
                MessageBox.Show("Debe introducir la respuesta para continuar", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormListadoPreguntas formListado = new FormListadoPreguntas();
            formListado.MdiParent = this.MdiParent;
            MdiParent.Size = formListado.Size + Constantes.aumentoTamanio;
            formListado.Show();
            this.Close();
        }
    }
}
