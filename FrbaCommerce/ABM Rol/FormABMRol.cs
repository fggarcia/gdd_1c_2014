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
    public partial class FormABMRol : Form
    {
        public FormABMRol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonInhabilitar_Click(object sender, EventArgs e)
        {

        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormABMRolAlta formAltaRol = new FormABMRolAlta();
            formAltaRol.MdiParent = this.MdiParent;
            MdiParent.Size = formAltaRol.Size + Constantes.aumentoTamanio;
            formAltaRol.Show();
            this.Close();
        }

        private void FormABMRol_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormABMRolModificar formModificarRol = new FormABMRolModificar();
            formModificarRol.MdiParent = this.MdiParent;
            MdiParent.Size = formModificarRol.Size + Constantes.aumentoTamanio;
            formModificarRol.Show();
            this.Close();
        }

        private void buttonInhabilitar_Click_1(object sender, EventArgs e)
        {
            FormABMRolInhabilitar formInhabilitarRol = new FormABMRolInhabilitar();
            formInhabilitarRol.MdiParent = this.MdiParent;
            MdiParent.Size = formInhabilitarRol.Size + Constantes.aumentoTamanio;
            formInhabilitarRol.Show();
            this.Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
