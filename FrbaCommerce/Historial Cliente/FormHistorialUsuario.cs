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
            
            //Llenar DataGridView con las ofertas de subastas ganadas
            SqlCommand commandSG = new SqlCommand();
            commandSG.CommandType = CommandType.StoredProcedure;
            commandSG.CommandText = Constantes.procedimientoListadoSubastasGanadas;
            commandSG.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandSG, dgvSubGanadas, "DataGridView Subastas Ganadas");

            //Llenar DataGridView con las ofertas de subastas no ganadas
            SqlCommand commandSNG = new SqlCommand();
            commandSNG.CommandType = CommandType.StoredProcedure;
            commandSNG.CommandText = Constantes.procedimientoListadoSubastasNoGanadas;
            commandSNG.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandSNG, dgvSubNoGanadas, "DataGridView Subastas No Ganadas");
            
            //Llenar DataGridView compras del usuario
            SqlCommand commandC = new SqlCommand();
            commandC.CommandType = CommandType.StoredProcedure;
            commandC.CommandText = Constantes.procedimientoListadoCompras;
            commandC.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandC, dgvCompras, "DataGridView Compras");

            //Llenar DataGridView compras del usuario
            SqlCommand commandV = new SqlCommand();
            commandV.CommandType = CommandType.StoredProcedure;
            commandV.CommandText = Constantes.procedimientoListadoVentas;
            commandV.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandV, dgvVentas, "DataGridView Ventas");

            //Llenar DataGridView calificaciones otorgadas
            SqlCommand commandCalO = new SqlCommand();
            commandCalO.CommandType = CommandType.StoredProcedure;
            commandCalO.CommandText = Constantes.procedimientoListadoCalificacionesOtorgadas;
            commandCalO.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandCalO, dgvCalOtorgadas, "DataGridView Calificaciones");

            //Llenar DataGridView calificaciones recibidas
            SqlCommand commandCalR = new SqlCommand();
            commandCalR.CommandType = CommandType.StoredProcedure;
            commandCalR.CommandText = Constantes.procedimientoListadoCalificacionesRecibidas;
            commandCalR.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(commandCalR, dgvCalRecibidas, "DataGridView Calificaciones");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
