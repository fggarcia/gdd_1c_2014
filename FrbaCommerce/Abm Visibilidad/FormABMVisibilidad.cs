using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class FormABMVisibilidad : Form
    {
        public FormABMVisibilidad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormABMVisibilidadModificar formABMVisibilidadModificar = new FormABMVisibilidadModificar();
            formABMVisibilidadModificar.MdiParent = this.MdiParent;
            MdiParent.Size = formABMVisibilidadModificar.Size + Constantes.aumentoTamanio;
            formABMVisibilidadModificar.Show();
            this.Close();
        }

        private void FormABMVisibilidad_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvVisibilidad.CurrentRow != null)
            {
                Visibilidad visibilidad = new Visibilidad();
                visibilidad.id = Convert.ToInt32(dgvVisibilidad.CurrentRow.Cells[0].Value);
                visibilidad.description = Convert.ToString(dgvVisibilidad.CurrentRow.Cells[1].Value);
                visibilidad.price = Convert.ToDouble(dgvVisibilidad.CurrentRow.Cells[2].Value);
                visibilidad.percentage = Convert.ToDouble(dgvVisibilidad.CurrentRow.Cells[3].Value);
                visibilidad.weight = Convert.ToInt32(dgvVisibilidad.CurrentRow.Cells[4].Value);
                visibilidad.enable = Convert.ToInt32(dgvVisibilidad.CurrentRow.Cells[5].Value);
                FormABMVisibilidadModificar formABMVisibilidadModificar = new FormABMVisibilidadModificar(visibilidad);
                formABMVisibilidadModificar.MdiParent = this.MdiParent;
                MdiParent.Size = formABMVisibilidadModificar.Size + Constantes.aumentoTamanio;
                formABMVisibilidadModificar.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro de la tabla a modificar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvVisibilidad.CurrentRow != null)
            {
                Visibilidad visibilidad = new Visibilidad();
                Visibilidad.deshabilitarVisibilidad(Convert.ToString(dgvVisibilidad.CurrentRow.Cells[0].Value));
                btnClean.PerformClick();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro de la tabla a modificar");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Visibilidad.buscar(textCode.Text, textDescription.Text, textWeight.Text, dgvVisibilidad);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Procedimientos.limpiarTextBoxes(this);
            Procedimientos.limpiarDataGridViews(dgvVisibilidad);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
