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
    public partial class FormABMRolModificar : Form
    {
        private Rol rol;

        public FormABMRolModificar()
        {
            InitializeComponent();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.listarRoles;
            Procedimientos.llenarDataGridView(command, dgvRoles, "DataGridView Rol");
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMRol formAbmRol = new FormABMRol();
            formAbmRol.MdiParent = this.MdiParent;
            MdiParent.Size = formAbmRol.Size + Constantes.aumentoTamanio;
            this.Close();
            formAbmRol.Show();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

            string descripcionRol = dgvRoles.CurrentRow.Cells["Descripcion"].Value.ToString();

            Boolean rolHabilitado;

            if(dgvRoles.CurrentRow.Cells["Habilitado"].Value.Equals(false)){
                rolHabilitado = false;
            }else{
                rolHabilitado = true;
            }

            FormABMRolAlta formAbmRolAlta = new FormABMRolAlta(descripcionRol, rolHabilitado);
            formAbmRolAlta.MdiParent = this.MdiParent;
            MdiParent.Size = formAbmRolAlta.Size + Constantes.aumentoTamanio;
            this.Close();

            formAbmRolAlta.Show();
        
        }

        private void FormABMRolModificar_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (!comboBox1.SelectedItem.Equals(null))
            //{
                SqlCommand bajaRolSP = new SqlCommand();
                bajaRolSP.CommandText = Constantes.bajaRol;
                bajaRolSP.Parameters.AddWithValue("@p_Descripcion_Rol", dgvRoles.CurrentRow.Cells["Descripcion"].Value.ToString());
                Procedimientos.ejecutarStoredProcedure(bajaRolSP, "BajaRol", false);

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Constantes.listarRoles;
                Procedimientos.llenarDataGridView(command, dgvRoles, "DataGridView Rol");

                MessageBox.Show("Fue eliminado correctamente", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un rol", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
