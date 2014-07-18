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

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FormFacturarPublicaciones : Form
    {
        Usuarios usuario;
        public FormFacturarPublicaciones()
        {
            InitializeComponent();
            usuario = FormSeleccionRol.usuario;
        }

        private void FormFacturarPublicaciones_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //Llenar DataGridView con las Facturas pendientes
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.procedimientoListadoFacturasPendientes;
            command.Parameters.AddWithValue("@p_Id_Usuario", usuario.user_id);
            Procedimientos.llenarDataGridView(command, dgvPublicaciones, "DataGridView Facturas Pendientes"); 
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            textCantidad.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            int cantidad = dgvPublicaciones.RowCount;
            if (cantidad == 0) MessageBox.Show("No posee facturas a pagar", "FrbaCommerce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (Convert.ToInt32(textCantidad.Text) > 0)
            {
                FormElegirMedioDePago formMedioPago = new FormElegirMedioDePago();
                formMedioPago.cantidad = textCantidad.Text;
                formMedioPago.MdiParent = this.MdiParent;
                this.MdiParent.Size = formMedioPago.Size + Constantes.aumentoTamanio;
                this.Close();
                formMedioPago.Show();
            }
            else MessageBox.Show("La cantidad a pagar debe ser mayor a cero", "FrbaCommerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
