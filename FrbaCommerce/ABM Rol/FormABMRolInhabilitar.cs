using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormABMRolInhabilitar : Form
    {
        public FormABMRolInhabilitar()
        {
            InitializeComponent();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.listarRoles;
            Procedimientos.llenarDataGridView(command, dataGridView1, "DataGridView Inhabilitar Rol");
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMRol formAbmRol = new FormABMRol();
            formAbmRol.MdiParent = this.MdiParent;
            MdiParent.Size = formAbmRol.Size + Constantes.aumentoTamanio;
            this.Close();
            formAbmRol.Show();
        }

        private void buttonInhabilitar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormABMRolInhabilitar_Load(object sender, EventArgs e)
        {

        }
    }
}
