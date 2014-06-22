using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using FrbaCommerce.ABM_Rol;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormABMRolBaja : Form
    {
        public FormABMRolBaja()
        {
            InitializeComponent();
        }

        private void FormABMRolBaja_Load(object sender, EventArgs e)
        {
            Procedimientos.LlenarComboBox(comboBox1, "LOS_OPTIMISTAS.Rol", "Id_Rol", "Descripcion", null, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.SelectedItem.Equals(null))
            {
                SqlCommand bajaRolSP = new SqlCommand();
                bajaRolSP.Parameters.AddWithValue("@p_Descripcion_Rol", comboBox1.SelectedItem.ToString());
                Procedimientos.ejecutarStoredProcedure(bajaRolSP, "BajaRol", false);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBuscarRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMRol formAbmRol = new FormABMRol();
            formAbmRol.MdiParent = this.MdiParent;
            MdiParent.Size = formAbmRol.Size + Constantes.aumentoTamanio;
            this.Close();
            formAbmRol.Show();
        }


    }
}
