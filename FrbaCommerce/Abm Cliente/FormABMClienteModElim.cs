using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FrbaCommerce.Abm_Cliente
{
    public partial class FormABMClienteModElim : Form
    {
        public FormABMClienteModElim()
        {
            InitializeComponent();
            buttonModificar.Enabled = false;
            buttonEliminar.Enabled = false;
            //Procedimientos.LlenarComboBox(comboBoxTipoDoc, "LOS_OPTIMISTAS.Tipo_Documento", "Id_Documento", "Descripcion", null, null);
        }

        private void FormABMClienteModElim_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBoxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Cliente.buscar(textBoxNombre.Text, textBoxApellido.Text, comboBoxTipoDoc.Text, textBoxnDoc.Text, textBoxEmail.Text, dgvCliente);
        }

        private void dgvCliente_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonModificar.Enabled = true;
            buttonEliminar.Enabled = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            string tipoDocumento = Convert.ToString(dgvCliente.CurrentRow.Cells[2].Value);
            string nroDocumento = Convert.ToString(dgvCliente.CurrentRow.Cells[3].Value);
            SqlCommand command = new SqlCommand(string.Format("SELECT Id_Usuario FROM LOS_OPTIMISTAS.Cliente WHERE Dni = '{0}' AND Tipo_Documento = '{1}'", nroDocumento, tipoDocumento), conn);
            Cliente.eliminarCliente(command.CommandText);
            Procedimientos.cerrarConexion(conn);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        { 
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarComboBoxes(this);
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            string tipoDocumento = Convert.ToString(dgvCliente.CurrentRow.Cells[2].Value);
            string nroDocumento = Convert.ToString(dgvCliente.CurrentRow.Cells[3].Value);
            SqlCommand command = new SqlCommand(string.Format("SELECT Id_Usuario FROM LOS_OPTIMISTAS.Cliente WHERE Dni = '{0}' AND Tipo_Documento = '{1}'", nroDocumento, tipoDocumento), conn);
            FormABMClienteModificacion form = new FormABMClienteModificacion();
            form.groupBoxDatos.Text = command.CommandText;
            Procedimientos.cerrarConexion(conn);
        }

    }
}
