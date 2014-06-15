using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FormEmpresaModElim : Form
    {
        public FormEmpresaModElim()
        {
            InitializeComponent();
            buttonModificar.Enabled = false;
            buttonEliminar.Enabled = false;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            string idUsuario = Convert.ToString(dgvEmpresa.CurrentRow.Cells[0].Value);
            Empresa.eliminar(idUsuario);
            Procedimientos.cerrarConexion(conn);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Empresa.buscar(textRazonSocial.Text, textCuit.Text, textMail.Text, dgvEmpresa);
        }

        private void dgvEmpresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonModificar.Enabled = true;
            buttonEliminar.Enabled = true;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEmpresaModificacion form = new FormEmpresaModificacion();
            SqlConnection conn = Procedimientos.abrirConexion();
            form.idUsuario = Convert.ToString(dgvEmpresa.CurrentRow.Cells[0].Value);
            Procedimientos.cerrarConexion(conn);
            form.ShowDialog();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMEmpresa formCliente = new FormABMEmpresa();
            this.Hide();
            formCliente.ShowDialog();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvEmpresa);
        }


    }
}
