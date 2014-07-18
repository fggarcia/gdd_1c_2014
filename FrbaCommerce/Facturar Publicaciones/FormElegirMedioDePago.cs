using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Login;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FormElegirMedioDePago : Form
    {
        char[] espacios = { ' ' };
        public string cantidad;

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
            Procedimientos.LlenarComboBoxCuotas(comboCuotas);
        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            bool passed = this.ValidateChildren();
            comboBoxMedioPago.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textNroTarjeta.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);

            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoFacturar;
            command.Parameters.AddWithValue("@p_Id_Usuario", FormSeleccionRol.usuario.user_id);
            command.Parameters.AddWithValue("@p_Cantidad", cantidad);
            if (textNroTarjeta.Text.TrimEnd(espacios).TrimStart(espacios) != "")
                command.Parameters.AddWithValue("@p_Numero_Tarjeta", textNroTarjeta.Text);
            else
                command.Parameters.AddWithValue("@p_Numero_Tarjeta", null);
            command.Parameters.AddWithValue("@p_Cantidad_Cuotas", comboCuotas.Text);
            command.Parameters.AddWithValue("@p_Tipo_Pago", comboBoxMedioPago.Text);
            Procedimientos.ejecutarStoredProcedure(command, "Facturación", true);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            FormFacturarPublicaciones formFacturar = new FormFacturarPublicaciones();
            formFacturar.MdiParent = this.MdiParent;
            this.MdiParent.Size = formFacturar.Size + Constantes.aumentoTamanio;
            this.Close();
            formFacturar.Show();
        }
    }
}
