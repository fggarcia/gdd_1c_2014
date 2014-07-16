using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FormEditarPublicacion : Form
    {
        public FormEditarPublicacion()
        {
            InitializeComponent();
            this.cargarCombos();
        }

        private void FormEditarPublicacion_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarComboBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvPublication);
        }

        private void cargarCombos()
        {
            Procedimientos.LlenarComboBox(cmbStatus, "LOS_OPTIMISTAS.Estado", "Id_Estado", "Descripcion", null, null);
            Procedimientos.LlenarComboBox(cmbVisibility, "LOS_OPTIMISTAS.Visibilidad", "Id_Visibilidad", "Descripcion", null, null);
            Procedimientos.LlenarComboBox(cmbType, "LOS_OPTIMISTAS.Tipo_Publicacion", "Id_Tipo_Publicacion", "Descripcion", null, null);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.procedimientoMostrarPublicaciones;

            Usuarios usuario = VarGlobables.usuario;

            command.Parameters.AddWithValue("@p_IdUsuario", usuario.user_id);

            if (txtDescription.Text == string.Empty)
                command.Parameters.AddWithValue("@p_Description", null);
            else
                command.Parameters.AddWithValue("@p_Description", txtDescription.Text);

            if (cmbType.SelectedValue == null)
                command.Parameters.AddWithValue("@p_Type", null);
            else
                command.Parameters.AddWithValue("@p_Type", cmbType.SelectedValue);

            if (cmbStatus.SelectedValue == null)
                command.Parameters.AddWithValue("@p_Status", null);
            else
                command.Parameters.AddWithValue("@p_Status", cmbStatus.SelectedValue);

            if (cmbVisibility.SelectedValue == null)
                command.Parameters.AddWithValue("@p_Visibility", null);
            else
                command.Parameters.AddWithValue("@p_Visibility", cmbVisibility.SelectedValue);

            Procedimientos.llenarDataGridView(command, dgvPublication, "DataGridView Publicaciones");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPublication.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una publicacion a editar", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string type = Convert.ToString(dgvPublication.CurrentRow.Cells[4].Value);
            bool bidding = type.Equals("SUBASTA");
            SqlConnection conn = Procedimientos.abrirConexion();
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_obtenerPublicacion";
            SqlCommand command = new SqlCommand(nombreStoredProcedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_Id_Publicacion", dgvPublication.CurrentRow.Cells[0].Value);
            command.Parameters.AddWithValue("@p_Id_Usuario", VarGlobables.usuario.user_id);

            SqlDataReader reader = command.ExecuteReader();

            Publicacion publication = new Publicacion();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    publication.id = Convert.ToInt32(reader["Id_Publicacion"]);
                    publication.description = reader["Descripcion"].ToString();
                    publication.stock = Convert.ToInt32(reader["Stock"]);
                    publication.status = Convert.ToInt32(reader["Id_Estado"]);
                    publication.statusDescription = reader["estadoDescripcion"].ToString();
                    publication.type = Convert.ToInt32(reader["Id_Tipo_Publicacion"]);
                    publication.typeDescription = reader["tipoDescripcion"].ToString();
                    publication.visibility = Convert.ToInt32(reader["Id_Visibilidad"]);
                    publication.visibilityDescription = reader["visibilidadDescripcion"].ToString();
                    publication.dateFrom = Convert.ToDateTime(reader["Fecha_Inicio"]);
                    publication.dateTo = Convert.ToDateTime(reader["Fecha_Vencimiento"]);
                    publication.prices = Convert.ToDouble(reader["Precio"]);
                    publication.countForSale = Convert.ToInt32(reader["Cant_por_venta"]);
                    publication.acceptQuestions = Convert.ToBoolean(reader["Permite_Preguntas"]);
                }
            }

            Procedimientos.cerrarConexion(conn);
            FormGenerarPublicacionAM formGenerarPublicacionAM = new FormGenerarPublicacionAM(bidding, publication);
            formGenerarPublicacionAM.MdiParent = this.MdiParent;
            MdiParent.Size = formGenerarPublicacionAM.Size + Constantes.aumentoTamanio;
            formGenerarPublicacionAM.Show();
            this.Close();
        }
    }
}
