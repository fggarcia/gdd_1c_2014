using System;
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

        private void FormComprarOfertar2_Load(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            CargarDataGridView(null);
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
    }
}