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
        }

        private void FormComprarOfertar_Load(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "LOS_OPTIMISTAS.proc_ListarRubros";
            Procedimientos.EjecutarProcedimientoDataGridView(command, dgvRubros, "");
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
            dgvPublicaciones.RowHeadersVisible = false;
            dgvPublicaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPublicaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPublicaciones.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvPublicaciones.Columns)
            {
                if (!column.Name.Equals("checkbox") && !column.Name.Equals("chk"))
                    column.ReadOnly = true;
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
            command.Parameters.AddWithValue("@p_Description", descripcion);

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
            recNo = 0;
            var reader = command.ExecuteReader();
            hayRegistros = reader.Read();
            if (hayRegistros)
            {
                CargarPagina();
            }
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
             if (paginaActual >= cantPaginas)
             {
                 paginaActual = cantPaginas;
             }
             if (hayRegistros & paginaActual < cantPaginas)
             {
                 paginaActual += 1;
                 CargarPagina();
             }
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
             if (paginaActual == cantPaginas)
             {
                 recNo = tamanioPagina * (paginaActual - 2);
             }

             if (paginaActual > 2 )
             {
                 recNo = tamanioPagina * (paginaActual - 3);
             }

             if (paginaActual == 2)
             {
                 recNo = tamanioPagina * (paginaActual - 2);
             }

             if (hayRegistros & paginaActual > 1)
             {
                 paginaActual -= 1;
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

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            var comandos = new List<SqlDataAdapter>();
            DataTable dataTable = new DataTable();
            dgvPublicaciones.DataSource = null;

            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chk"].Value))
                {
                    string id_Rubro = Convert.ToString(row.Cells[1].Value);
                    dgvPublicaciones.RowHeadersVisible = false;
                    dgvPublicaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPublicaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPublicaciones.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in dgvPublicaciones.Columns)
                    {
                        if (!column.Name.Equals("checkbox") && !column.Name.Equals("chk"))
                            column.ReadOnly = true;
                    }

                    SqlConnection conn = Procedimientos.abrirConexion();
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("p_Id_Usuario", FormSeleccionRol.usuario.user_id);
                    comando.Parameters.AddWithValue("p_Id_Rubro", id_Rubro);
                    comando.CommandText = "LOS_OPTIMISTAS.proc_ListarPublicacionesPorRubro";
                    comando.Connection = conn;
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comando);
                    comandos.Add(sqlDataAdapter);
                }
            }

            foreach (SqlDataAdapter comando in comandos)
            {
                
                comando.Fill(dataTable);
            }

            dgvPublicaciones.DataSource = dataTable;
                
            bool sinRubro = false;

            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["chk"].Value))
                {
                    sinRubro = true;
                }
            }
            if (sinRubro)
            {
                CargarDataGridView(txtDescription.Text);
            }

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarComboBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvPublicaciones);
        }
    }

}
