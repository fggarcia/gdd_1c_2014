using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FormElegirMedioDePago : Form
    {
        public FormElegirMedioDePago()
        {
            InitializeComponent();
            Procedimientos.LlenarComboBox(comboBoxMedioPago, "LOS_OPTIMISTAS.Tipo_Pago", "Id_Tipo_Pago", "Descripcion", null, null);
        }

        private void FormElegirMedioDePago_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
