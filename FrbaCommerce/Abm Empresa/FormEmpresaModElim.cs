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
            this.Close();
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
            FormEmpresaModificacion formEmpresaMod = new FormEmpresaModificacion();
            formEmpresaMod.MdiParent = this.MdiParent;
            MdiParent.Size = formEmpresaMod.Size + Constantes.aumentoTamanio;
            formEmpresaMod.Show();
            SqlConnection conn = Procedimientos.abrirConexion();
            formEmpresaMod.idUsuario = Convert.ToString(dgvEmpresa.CurrentRow.Cells[0].Value);
            Procedimientos.cerrarConexion(conn);
            this.Close();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMEmpresa formABMEmpres = new FormABMEmpresa();
            formABMEmpres.MdiParent = this.MdiParent;
            MdiParent.Size = formABMEmpres.Size + Constantes.aumentoTamanio;
            this.Close();
            formABMEmpres.Show();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvEmpresa);
        }

        private void dgvEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
