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
    public partial class FormClienteModElim : Form
    {
        public FormClienteModElim()
        {
            InitializeComponent();
            buttonModificar.Enabled = false;
            buttonEliminar.Enabled = false;
            Procedimientos.LlenarComboBox(comboBoxTipoDoc, "LOS_OPTIMISTAS.Tipo_Documento", "Id_Tipo_Documento", "Id_Tipo_Documento", null, null);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Cliente.buscar(textBoxNombre.Text, textBoxApellido.Text, comboBoxTipoDoc.Text, textBoxnDoc.Text, textBoxEmail.Text, dgvCliente);
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonModificar.Enabled = true;
            buttonEliminar.Enabled = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            string idUsuario = Convert.ToString(dgvCliente.CurrentRow.Cells[0].Value);
            Cliente.eliminar(idUsuario);
            Procedimientos.cerrarConexion(conn);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        { 
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarComboBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvCliente);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormClienteModificacion formClienteMod = new FormClienteModificacion();
            formClienteMod.MdiParent = this.MdiParent;
            formClienteMod.Show();
            SqlConnection conn = Procedimientos.abrirConexion();
            formClienteMod.idUsuario = Convert.ToString(dgvCliente.CurrentRow.Cells[0].Value);
            Procedimientos.cerrarConexion(conn);
            this.Close();
            
        }


        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            Cliente.buscar(textBoxNombre.Text, textBoxApellido.Text, comboBoxTipoDoc.Text, textBoxnDoc.Text, textBoxEmail.Text, dgvCliente);
        }

        private void FormClienteModElim_Load(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMCliente formABMCliente = new FormABMCliente();
            formABMCliente.MdiParent = this.MdiParent;
            this.Close();
            formABMCliente.Show();
        }

    }
}
