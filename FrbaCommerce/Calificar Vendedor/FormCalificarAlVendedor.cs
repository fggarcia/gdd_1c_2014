using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class FormCalificarAlVendedor : Form
    {
        public string idUsuario;

        public FormCalificarAlVendedor()
        {
            InitializeComponent();
        }

        private void FormCalificarAlVendedor_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked))
            {
                MessageBox.Show("Debe seleccionar una calificación para poder continuar", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            FormSeleccionACalificar formSeleccionCalificar = new FormSeleccionACalificar();
            formSeleccionCalificar.MdiParent = this.MdiParent;
            this.MdiParent.Size = formSeleccionCalificar.Size + Constantes.aumentoTamanio;
            formSeleccionCalificar.Show();
            this.Close();
        }
    }
}
