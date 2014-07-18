using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FormABMCliente : Form
    {
        public FormABMCliente()
        {
            InitializeComponent();
        }
        
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormClienteModElim formModElim = new FormClienteModElim();
            formModElim.MdiParent = this.MdiParent;
            this.MdiParent.Size = formModElim.Size + Constantes.aumentoTamanio;
            formModElim.Show();
            this.Close();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormClienteAlta formAltaCliente = new FormClienteAlta();
            formAltaCliente.MdiParent = this.MdiParent;
            this.MdiParent.Size = formAltaCliente.Size + Constantes.aumentoTamanio;
            formAltaCliente.Show();
            this.Close();

            SqlConnection conn = Procedimientos.abrirConexion();
            formAltaCliente.username = Procedimientos.generarUsername();
            while (Validaciones.validacionUsernameYaExiste(conn, formAltaCliente.username, false))
            {
                formAltaCliente.username = Procedimientos.generarUsername();
            }
            conn.Close();
            formAltaCliente.password = Procedimientos.generarPassword();
            MessageBox.Show("Username: " + formAltaCliente.username + " Password: " + formAltaCliente.password, "Usuario creado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void FormABMCliente_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
