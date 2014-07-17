using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FrbaCommerce.Login;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class FormSeleccionACalificar : Form
    {
        public FormSeleccionACalificar()
        {
            InitializeComponent();
        }

        private void FormSeleccionACalificar_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            buttonContinuar.Enabled = false;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.procedimientoListarVendedoresCalificar;
            command.Parameters.AddWithValue("@p_Id_Comprador", FormSeleccionRol.usuario.user_id);
            Procedimientos.llenarDataGridView(command, dgvACalificar, "DataGridView Vendedores");
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            FormCalificarAlVendedor formCalificar = new FormCalificarAlVendedor();
            formCalificar.MdiParent = this.MdiParent;
            this.MdiParent.Size = formCalificar.Size + Constantes.aumentoTamanio;
            formCalificar.Show();
            SqlConnection conn = Procedimientos.abrirConexion();
            MessageBox.Show(Convert.ToString(dgvACalificar.CurrentRow.Cells[0].Value));
            MessageBox.Show(Convert.ToString(dgvACalificar.CurrentRow.Cells[1].Value));
            formCalificar.idHistorialCompra = Convert.ToString(dgvACalificar.CurrentRow.Cells[0].Value);
            formCalificar.idVendedor = Convert.ToString(dgvACalificar.CurrentRow.Cells[1].Value);
            Procedimientos.cerrarConexion(conn);
            this.Close();
        }

        private void dgvACalificar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonContinuar.Enabled = true;
        }
    }
}
