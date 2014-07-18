﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Login;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FormComprarOfertar : Form
    {
        DataSet ds;
        DataTable dtSource;
        int cantPaginas;
        int maxRec;
        int tamanioPagina = 20;
        int paginaActual;
        int recNo;
        bool hayRegistros;

        public FormComprarOfertar()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            CargarDataGridView(null);
        }

        private void CargarPagina()
        {
            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            dtTemp = dtSource.Clone();

            if (paginaActual == cantPaginas)
            {
                endRec = maxRec;
            }
            else
            {
                endRec = tamanioPagina * paginaActual;
            }
            startRec = recNo;

            for (i = startRec; i < endRec; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
                recNo += 1;
            }
            dgvPublicaciones.DataSource = dtTemp;
            MostrarInfoPagina();
        }

        private void MostrarInfoPagina()
        {
            labelPaginaActual.Text = "Página " + paginaActual.ToString() + "/ " + cantPaginas.ToString();
        }

        private void CargarDataGridView(string descripcion)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand(Constantes.procedimientoMostrarPublicacionesComprarOfertar, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_IdUsuario", FormSeleccionRol.usuario.user_id);
            //command.Parameters.AddWithValue("@p_Description", descripcion);

            SqlDataAdapter da = new SqlDataAdapter(command);

            ds = new DataSet();
            da.Fill(ds, "Publicaciones");
            dtSource = ds.Tables["Publicaciones"];

            maxRec = dtSource.Rows.Count;
            cantPaginas = maxRec / tamanioPagina;

            if ((maxRec % tamanioPagina) > 0)
            {
                cantPaginas += 1;
            }
            paginaActual = 1;

            var reader = command.ExecuteReader();
            hayRegistros = reader.Read();
            if (hayRegistros)
            {
                CargarPagina();
            }
        }

        private void FormComprarOfertar_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonPrimera_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            recNo = 0;
            if (hayRegistros)
            {
                CargarPagina();
            }
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            paginaActual += 1;
            if (paginaActual > cantPaginas)
            {
                paginaActual = cantPaginas;
            }
            if (hayRegistros & paginaActual <= cantPaginas)
            {
                CargarPagina();
            }
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == cantPaginas)
            {
                recNo = tamanioPagina * (paginaActual - 2);
            }

            paginaActual -= 1;

            if (paginaActual > 1)
            {
                recNo = tamanioPagina * (paginaActual - 1);
            }
            if (hayRegistros & paginaActual >= 1)
            {
                CargarPagina();
            }
        }

        private void buttonUltimo_Click(object sender, EventArgs e)
        {
            paginaActual = cantPaginas;
            recNo = tamanioPagina * (paginaActual - 1);
            if (hayRegistros)
            {
                CargarPagina();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CargarDataGridView(txtDescription.Text);
        }

        private void btnBuyBidding_Click(object sender, EventArgs e)
        {
            if (dgvPublicaciones.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una publicacion a comprar/ofertar", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string type = Convert.ToString(dgvPublicaciones.CurrentRow.Cells[3].Value);
            Int32 id_publicacion = Convert.ToInt32(dgvPublicaciones.CurrentRow.Cells[0].Value);
            bool bidding = type.Equals("SUBASTA");
            SqlConnection conn = Procedimientos.abrirConexion();
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_obtenerPublicacion";
            SqlCommand command = new SqlCommand(nombreStoredProcedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_Id_Publicacion", id_publicacion);

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

            FormConfirmarComprarOfertar formConfirmarComprarOfertar = new FormConfirmarComprarOfertar(publication);
            formConfirmarComprarOfertar.MdiParent = this.MdiParent;
            MdiParent.Size = formConfirmarComprarOfertar.Size + Constantes.aumentoTamanio;
            formConfirmarComprarOfertar.Show();
            this.Close();
        }
    }
}