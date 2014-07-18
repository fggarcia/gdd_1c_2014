using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FormConfirmarComprarOfertar : Form
    {
        private Publicacion publication;
        private bool isBidding;

        public FormConfirmarComprarOfertar(Publicacion publication)
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            this.publication = publication;
            InitializeComponent();
            setDisabledFields();

            txtDescription.Text = publication.description;
            txtType.Text = publication.typeDescription;
            txtVisibility.Text = publication.visibilityDescription;
            txtStock.Text = publication.stock.ToString();

            if (publication.typeDescription.Equals("SUBASTA"))
            {
                this.isBidding = true;
                lblPrice.Text = "Precio Subasta";
                lblBidding.Text = "Precio subasta actual $" + publication.prices.ToString();
                txtPrice.Enabled = true;
                txtCountTo.Text = publication.countForSale.ToString();
                addBiddingValidation();
                btnOk.Text = "Ofertar";
            }
            else
            {
                this.isBidding = false;
                lblBidding.Visible = false;
                txtPrice.Text = publication.prices.ToString();
                txtCountTo.Enabled = true;
                txtCountTo.Text = "1";
                addBuyValidation();
                btnOk.Text = "Comprar";
            }

            if (publication.statusDescription.Equals("PAUSADA"))
            {
                MessageBox.Show("Esta publicacion se encuentra pausada", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDisabledFields();
                btnOk.Enabled = false;
            }
        }

        private void addBuyValidation(){
            txtCountTo.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtCountTo.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
        }

        private void addBiddingValidation()
        {
            txtPrice.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            txtPrice.Validating += new CancelEventHandler(Validaciones.validarCampoNumericoFlotante_Validating);
        }

        private void FormConfirmarComprarOfertar_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void setDisabledFields()
        {
            txtDescription.Enabled = false;
            txtType.Enabled = false;
            txtPrice.Enabled = false;
            txtCountTo.Enabled = false;
            txtStock.Enabled = false;
            txtVisibility.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormComprarOfertar formComprarOfertar = new FormComprarOfertar();
            formComprarOfertar.MdiParent = this.MdiParent;
            MdiParent.Size = formComprarOfertar.Size + Constantes.aumentoTamanio;
            formComprarOfertar.Show();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Usuarios user = VarGlobables.usuario;
            if (isBidding)
            {
                Double biddingPrice = Convert.ToDouble(txtPrice.Text);

                if (biddingPrice <= publication.prices)
                {
                    MessageBox.Show("Su monto ofrecido no es superior a la oferta actual", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand command = new SqlCommand();

                command.Parameters.AddWithValue("@Id_Usuario", user.user_id);
                command.Parameters.AddWithValue("@Id_Publicacion", publication.id);
                command.Parameters.AddWithValue("@Bidding_Price", biddingPrice);
                command.Parameters.AddWithValue("@Visibility_Description", publication.visibilityDescription);

                command.CommandText = Constantes.procedimientoPerformSubasta;
                Procedimientos.ejecutarStoredProcedure(command, "Se proceso correctamente su oferta", true);
                this.btnCancel.PerformClick();
            }
            else
            {
                Int16 countToBuy = Convert.ToInt16(txtCountTo.Text);

                if (countToBuy % publication.countForSale != 0)
                {
                    MessageBox.Show("La cantidad que ud desea comprar no es multiplico de la cantidad por la cual se vende",
                        "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (countToBuy > publication.stock)
                {
                    MessageBox.Show("La cantidad que ud desea comprar es mayor a la cantidad de stock actual",
                        "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand command = new SqlCommand();

                command.Parameters.AddWithValue("@Id_Usuario", user.user_id);
                command.Parameters.AddWithValue("@Id_Publicacion", publication.id);
                command.Parameters.AddWithValue("@CountToBuy", countToBuy);
                command.Parameters.AddWithValue("@Visibility_Description", publication.visibilityDescription);

                command.CommandText = Constantes.procedimientoPerformCompra;
                Procedimientos.ejecutarStoredProcedure(command, "Se proceso correctamente su compra", true);
                this.btnCancel.PerformClick();
            }
        }

        private Double getPriceBidding()
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand checkFreePublication = new SqlCommand();
            conn = Procedimientos.abrirConexion();
            checkFreePublication.Parameters.AddWithValue("@Id_Publicacion", publication.id);

            checkFreePublication.CommandText = Constantes.procedimientoObtenerPrecioSubasta;
            checkFreePublication.CommandType = CommandType.StoredProcedure;

            var returnParameter = checkFreePublication.Parameters.Add("@NoSuperaCondicion", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            Int32 conditionFreePublication = Convert.ToInt32(returnParameter.Value);

            Procedimientos.cerrarConexion(conn);

            return conditionFreePublication;
        }
    }
}
