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


namespace FrbaCommerce.ABM_Rol
{
    public partial class FormABMRolAlta : Form
    {
        public FormABMRolAlta(String rolNombre, ComboBox comboFuncionalidades)
        {
            InitializeComponent();
            nombreRol.Text = rolNombre;
            if (!rolNombre.Equals(null))
            {
                //Llenar listBox con funcionalidades del Rol que me pasan
            }
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void buttonAgregarFunc_Click(object sender, EventArgs e)
        {
            if (!comboBox1.SelectedItem.Equals(null))
            {
                listBox1.Items.Add(comboBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una funcionalidad", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormABMRolAlta_Load(object sender, EventArgs e)
        {
            Procedimientos.LlenarComboBox(comboBox1, "LOS_OPTIMISTAS.Funcionalidad", "Descripcion", "Descripcion", null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!listBox1.SelectedItem.Equals(null))
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una funcionalidad de las incluidas", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!listBox1.SelectedItem.Equals(null))
            {
                SqlCommand rolSP = new SqlCommand();
                rolSP.Parameters.AddWithValue("@p_Descripcion_Rol", nombreRol.Text);
                Procedimientos.ejecutarStoredProcedure(rolSP, "CrearRol", false);

                for (int i = 0; i < listBox1.Items.Count - 1; i++)
                {
                    string funcionalidad = listBox1.Items[i].ToString();
                    SqlCommand funcionalidadSP = new SqlCommand();
                    funcionalidadSP.Parameters.AddWithValue("@p_Id_Rol", nombreRol.Text);
                    funcionalidadSP.Parameters.AddWithValue("@p_Id_Funcionalidad", funcionalidad);
                    Procedimientos.ejecutarStoredProcedure(funcionalidadSP, "AgregarFuncionalidad", false);
                }
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Debe incluir funcionalidades", "FrbaCommerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}