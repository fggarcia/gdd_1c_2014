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
    public partial class FormABMEmpresa : Form
    {
        public FormABMEmpresa()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormEmpresaAlta formAltaEmpresa = new FormEmpresaAlta();
            formAltaEmpresa.MdiParent = this.MdiParent;
            MdiParent.Size = formAltaEmpresa.Size + Constantes.aumentoTamanio;
            formAltaEmpresa.Show();
            this.Close();

            SqlConnection conn = Procedimientos.abrirConexion();
            formAltaEmpresa.username = Procedimientos.generarUsername();
            while (Validaciones.validacionUsernameYaExiste(conn, formAltaEmpresa.username, false))
            {
                formAltaEmpresa.username = Procedimientos.generarUsername();
            }
            conn.Close();
            formAltaEmpresa.password = Procedimientos.generarPassword();
            MessageBox.Show("Username: " + formAltaEmpresa.username + "Password: " + formAltaEmpresa.password, "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void FormABMEmpresa_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonModificarEliminar_Click(object sender, EventArgs e)
        {
            FormEmpresaModElim formModElim = new FormEmpresaModElim();
            formModElim.MdiParent = this.MdiParent;
            MdiParent.Size = formModElim.Size + Constantes.aumentoTamanio;
            formModElim.Show();
            this.Close();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
