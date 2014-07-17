using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Editar_Publicacion;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FormGenerarPublicacionAM : Form
    {
        private bool bidding;
        private bool edition;
        private Publicacion publication;
        
        public FormGenerarPublicacionAM(bool bidding, Publicacion publication)
        {
            this.publication = publication;
            this.edition = true;
            InitializeComponent();
            addValidation();
            this.bidding = bidding;
            this.dtpFrom.Enabled = false;
            this.dtpTo.Enabled = false;

            this.loadCombos();
            if (this.bidding)
            {
                this.label3.Text = "Precio Subasta";
            }

            this.cmbStatus.Enabled = false;
            this.cmbVisibility.Enabled = false;
            this.txtCountBuy.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtPrice.Enabled = false;
            this.txtStock.Enabled = false;
            this.dtpFrom.Enabled = false;
            this.dtpTo.Enabled = false;
            this.chkEnableQuestion.Enabled = false;

            cmbStatus.SelectedIndex = cmbStatus.FindStringExact(publication.statusDescription);
            cmbVisibility.SelectedIndex = cmbVisibility.FindStringExact(publication.visibilityDescription);
            txtDescription.Text = publication.description;
            txtPrice.Text = publication.prices.ToString();
            txtCountBuy.Text = publication.countForSale.ToString();
            txtStock.Text = publication.stock.ToString();
            chkEnableQuestion.Checked = publication.acceptQuestions;

            switch (publication.statusDescription)
            {
                case "ACTIVA":
                    this.label8.Text = "Aumentar Stock";
                    this.txtStock.Enabled = true;
                    this.txtStock.Text = "0";
                    this.txtDescription.Enabled = true;
                    break;
                case "BORRADOR":
                    this.cmbStatus.Enabled = true;
                    this.cmbVisibility.Enabled = true;
                    this.txtCountBuy.Enabled = true;
                    this.txtDescription.Enabled = true;
                    this.txtPrice.Enabled = true;
                    this.txtStock.Enabled = true;
                    this.dtpFrom.Enabled = true;
                    this.dtpTo.Enabled = true;
                    this.chkEnableQuestion.Enabled = true;
                    break;
                case "FINALIZADA":
                    this.btnSave.Enabled = false;
                    break;
                case "PAUSADA":
                    this.btnSave.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        public FormGenerarPublicacionAM(bool bidding)
        {
            this.publication = null;
            this.edition = false;
            InitializeComponent();
            addValidation();
            this.bidding = bidding;
            this.dtpFrom.Value.AddHours(0 - this.dtpFrom.Value.Hour);
            this.dtpFrom.Value.AddMinutes(0 - this.dtpFrom.Value.Minute);
            this.dtpFrom.Value.AddMilliseconds(0 - this.dtpFrom.Value.Millisecond);
            this.dtpTo.Value = this.dtpFrom.Value.AddMonths(1);
            this.dtpFrom.Enabled = false;
            this.dtpTo.Enabled = false;

            this.loadCombos();
            if (this.bidding)
            {
                this.label3.Text = "Precio Subasta";
            }
            MessageBox.Show("Recuerde que solo puede tener 3 publicaciones gratuitas activas", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormGenerarPublicacionAM_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void addValidation()
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            cmbVisibility.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            cmbStatus.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtDescription.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtDescription.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            txtCountBuy.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtCountBuy.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            txtPrice.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtPrice.Validating += new CancelEventHandler(Validaciones.validarCampoNumericoFlotante_Validating);
            txtStock.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtStock.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
        }

        private void loadCombos()
        {
            Procedimientos.LlenarComboBox(cmbVisibility,"LOS_OPTIMISTAS.Visibilidad","Id_Visibilidad","Descripcion",null,"Peso");
            Procedimientos.LlenarComboBox(cmbStatus, "LOS_OPTIMISTAS.Estado", "Id_Estado", "Descripcion", null, "Id_Estado");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (edition)
            {
                FormEditarPublicacion formEditarPublicacion = new FormEditarPublicacion();
                formEditarPublicacion.MdiParent = this.MdiParent;
                MdiParent.Size = formEditarPublicacion.Size + Constantes.aumentoTamanio;
                formEditarPublicacion.Show();
            }
            else
            {
                FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion();
                formGenerarPublicacion.MdiParent = this.MdiParent;
                MdiParent.Size = formGenerarPublicacion.Size + Constantes.aumentoTamanio;
                formGenerarPublicacion.Show();
            }
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edition)
            {
                this.editPublication();
            }
            else
            {
                this.newPublication();
            }
        }

        private void editPublication()
        {
            Usuarios user = VarGlobables.usuario;
            SqlConnection conn = Procedimientos.abrirConexion();
            String nameStoredProcedure = "LOS_OPTIMISTAS.proc_EditarPublicacion";
            
            SqlCommand command = new SqlCommand();

            int id_tipo_publicacion;

            if (bidding)
            {
                id_tipo_publicacion = 2;
            }
            else
            {
                id_tipo_publicacion = 1;
            }

            command.Parameters.AddWithValue("@Id_Usuario", user.user_id);
            command.Parameters.AddWithValue("@Id_Publicacion", publication.id);

            if(publication.statusDescription.Equals("ACTIVA")){
                command.Parameters.AddWithValue("@Agregar_Stock", txtStock.Text);
            }else{
                command.Parameters.AddWithValue("@Agregar_Stock", 0);
            }

            command.Parameters.AddWithValue("@Id_Visibilidad", cmbVisibility.SelectedValue);
            command.Parameters.AddWithValue("@Id_Estado", cmbStatus.SelectedValue);
            command.Parameters.AddWithValue("@Id_Tipo_Publicacion", id_tipo_publicacion);
            command.Parameters.AddWithValue("@precio", Convert.ToDouble(txtPrice.Text));
            command.Parameters.AddWithValue("@Fecha_Inicio", dtpFrom.Value);
            command.Parameters.AddWithValue("@Fecha_Vencimiento", dtpTo.Value);
            command.Parameters.AddWithValue("@Permite_Preguntas", chkEnableQuestion.Checked);
            command.Parameters.AddWithValue("@Cant_por_Venta", txtCountBuy.Text);
            command.Parameters.AddWithValue("@Descripcion", txtDescription.Text);
            command.Parameters.AddWithValue("@Cantidad", txtStock.Text);

            command.CommandText = nameStoredProcedure;
            Procedimientos.ejecutarStoredProcedure(command, "Editacion de Publicación", true);
            this.btnCancel.PerformClick();

        }

        private void newPublication()
        {
            Usuarios usuario = VarGlobables.usuario;

            SqlConnection conn = Procedimientos.abrirConexion();
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_ObtenerIdPublicacionGratuita";
            SqlCommand getIdFreeCommand = new SqlCommand(nombreStoredProcedure, conn);
            getIdFreeCommand.CommandType = CommandType.StoredProcedure;

            var returnParameter = getIdFreeCommand.Parameters.Add("@Id_Gratis", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            getIdFreeCommand.ExecuteNonQuery();

            Int32 id_free = Convert.ToInt32(returnParameter.Value);

            Procedimientos.cerrarConexion(conn);

            if (Convert.ToInt32(cmbVisibility.SelectedValue) == id_free)
            {
                SqlCommand checkFreePublication = new SqlCommand();
                conn = Procedimientos.abrirConexion();
                checkFreePublication.Parameters.AddWithValue("@Id_Usuario", usuario.user_id);

                checkFreePublication.CommandText = Constantes.procedimientoChequearTresPublicacionesGratuitas;
                checkFreePublication.CommandType = CommandType.StoredProcedure;

                returnParameter = getIdFreeCommand.Parameters.Add("@NoSuperaCondicion", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                Int32 conditionFreePublication = Convert.ToInt32(returnParameter.Value);

                Procedimientos.cerrarConexion(conn);

                if (conditionFreePublication == 1)
                {
                    MessageBox.Show("Uds ya tiene al menos 3 publicaciones gratuitas activas", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            SqlCommand command = new SqlCommand();

            int id_tipo_publicacion;

            if (bidding)
            {
                id_tipo_publicacion = 2;
            }
            else
            {
                id_tipo_publicacion = 1;
            }

            command.Parameters.AddWithValue("@Id_Usuario", usuario.user_id);
            command.Parameters.AddWithValue("@Id_Visibilidad", cmbVisibility.SelectedValue);
            command.Parameters.AddWithValue("@Id_Estado", cmbStatus.SelectedValue);
            command.Parameters.AddWithValue("@Id_Tipo_Publicacion", id_tipo_publicacion);
            command.Parameters.AddWithValue("@precio", Convert.ToDouble(txtPrice.Text));
            command.Parameters.AddWithValue("@Fecha_Inicio", dtpFrom.Value);
            command.Parameters.AddWithValue("@Fecha_Vencimiento", dtpTo.Value);
            command.Parameters.AddWithValue("@Permite_Preguntas", chkEnableQuestion.Checked);
            command.Parameters.AddWithValue("@Cant_por_Venta", txtCountBuy.Text);
            command.Parameters.AddWithValue("@Descripcion", txtDescription.Text);
            command.Parameters.AddWithValue("@Cantidad", txtStock.Text);

            command.CommandText = Constantes.procedimientoGenerarPublicacion;
            Procedimientos.ejecutarStoredProcedure(command, "Generación de Publicación", true);
            this.btnCancel.PerformClick();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
