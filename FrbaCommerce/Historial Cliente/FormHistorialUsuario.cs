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

namespace FrbaCommerce.Historial_Cliente
{
    public partial class FormHistorialUsuario : Form
    {
        Usuarios usuario;
        public FormHistorialUsuario()
        {
            InitializeComponent();
            usuario = FormSeleccionRol.usuario;
        }

        private void FormHistorialUsuario_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //Llenar DataGridView con las ofertas de subastas
            SqlCommand commandS = new SqlCommand();
            commandS.CommandType = CommandType.StoredProcedure;
            commandS.CommandText = Constantes.procedimientoListadoSubastas;
            commandS.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandS, dgvOfertas, "DataGridView Ofertas");

            //Llenar DataGridView compras / ventas del usuario
            SqlCommand commandCV = new SqlCommand();
            commandCV.CommandType = CommandType.StoredProcedure;
            commandCV.CommandText = Constantes.procedimientoListadoComprasVentas;
            commandCV.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandCV, dgvCompras, "DataGridView Compras");

            SqlCommand commandCal = new SqlCommand();
            commandCal.CommandType = CommandType.StoredProcedure;
            commandCal.CommandText = Constantes.procedimientoListadoCalificaciones;
            commandCal.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandCal, dgvCalificaciones, "DataGridView Calificaciones");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
