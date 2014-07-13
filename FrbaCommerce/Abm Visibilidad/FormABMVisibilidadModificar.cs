using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class FormABMVisibilidadModificar : Form
    {

        public bool isNew;

        private void agregarValidaciones(){
            this.AutoValidate = AutoValidate.EnableAllowFocusChange; // Sirve para que te deje hacer focus en otro control aunque de error

            textCode.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textCode.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            textDescription.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textDescription.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            textPrice.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textPrice.Validating += new CancelEventHandler(Validaciones.validarCampoNumericoFlotante_Validating);
            textPercentage.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textPercentage.Validating += new CancelEventHandler(Validaciones.validarCampoNumericoFlotante_Validating);
            textWeight.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            textWeight.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
        }
        public FormABMVisibilidadModificar(Visibilidad visibilidad)
        {
            InitializeComponent();
            this.isNew = false;
            this.agregarValidaciones();
            this.textCode.Text = Convert.ToString(visibilidad.id);
            this.textCode.Enabled = false;
            this.textDescription.Text = visibilidad.description;
            this.textDescription.Enabled = false;
            this.textPrice.Text = Convert.ToString(visibilidad.price);
            this.textPercentage.Text = Convert.ToString(visibilidad.percentage);
            this.textWeight.Text = Convert.ToString(visibilidad.weight);
            if (visibilidad.enable > 0)
            {
                this.chkEnable.Checked = true;
            }
            else
            {
                this.chkEnable.Checked = false;
            }
        }

        public FormABMVisibilidadModificar()
        {
            InitializeComponent();
            this.agregarValidaciones();
            this.isNew = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.closeWindow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();

            int enable;

            if (chkEnable.Checked)
            {
                enable = 1;
            }
            else
            {
                enable = 0;
            }

            command.Parameters.AddWithValue("@id_visibilidad", Convert.ToInt32(textCode.Text));
            command.Parameters.AddWithValue("@descripcion", textDescription.Text);
            command.Parameters.AddWithValue("@precio", Convert.ToDouble(textPrice.Text));
            command.Parameters.AddWithValue("@porcentaje", Convert.ToDouble(textPercentage.Text));
            command.Parameters.AddWithValue("@peso", textWeight.Text);
            command.Parameters.AddWithValue("@habilitado", enable);

            if (isNew)
            {
                command.CommandText = Constantes.procedimientoModificarVisibilidad;
                Procedimientos.ejecutarStoredProcedure(command, "nueva visibilidad", true);
            }
            else
            {
                command.CommandText = Constantes.procedimientoModificarVisibilidad;
                Procedimientos.ejecutarStoredProcedure(command, "modificar visibilidad", true);
            }
            
            this.closeWindow();
        }
        private void closeWindow()
        {
            FormABMVisibilidad formABMVisibilidad = new FormABMVisibilidad();
            formABMVisibilidad.MdiParent = this.MdiParent;
            MdiParent.Size = formABMVisibilidad.Size + Constantes.aumentoTamanio;
            this.Close();
            formABMVisibilidad.Show();
        }
    }
}
