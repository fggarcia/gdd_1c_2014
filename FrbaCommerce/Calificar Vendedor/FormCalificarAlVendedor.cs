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

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class FormCalificarAlVendedor : Form
    {
        public string idHistorialCompra;
        public string idVendedor;
        public int calificacion;

        public FormCalificarAlVendedor()
        {
            InitializeComponent();
        }

        private void FormCalificarAlVendedor_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked))
            {
                MessageBox.Show("Debe seleccionar una calificación para poder continuar", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radioButton1.Checked) calificacion = 1;
                if (radioButton2.Checked) calificacion = 2;
                if (radioButton3.Checked) calificacion = 3;
                if (radioButton4.Checked) calificacion = 4;
                if (radioButton5.Checked) calificacion = 5;

                SqlCommand command = new SqlCommand();
                command.CommandText = Constantes.procedimientoCalificar;
                command.Parameters.AddWithValue("@p_Id_Historial_Compra", idHistorialCompra);
                command.Parameters.AddWithValue("@p_Id_Vendedor", idVendedor);
                command.Parameters.AddWithValue("@p_Id_Comprador", FormSeleccionRol.usuario.user_id);
                command.Parameters.AddWithValue("@p_Detalle", textDetalle.Text);
                command.Parameters.AddWithValue("@p_Calificacion", calificacion);
                Procedimientos.ejecutarStoredProcedure(command, "Calificación", true);
            }

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormSeleccionACalificar formSeleccionCalificar = new FormSeleccionACalificar();
            formSeleccionCalificar.MdiParent = this.MdiParent;
            this.MdiParent.Size = formSeleccionCalificar.Size + Constantes.aumentoTamanio;
            formSeleccionCalificar.Show();
            this.Close();
        }
    }
}
