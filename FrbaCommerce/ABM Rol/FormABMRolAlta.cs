using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormABMRolAlta : Form
    {
        public FormABMRolAlta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormABMRol formAbmRol = new FormABMRol();
            formAbmRol.MdiParent = this.MdiParent;
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
            Procedimientos.LlenarComboBox(comboBox1, "LOS_OPTIMISTAS.Funcionalidad", "Id_Funcionalidad", "Descripcion", null, null);
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

        }
    }
}
