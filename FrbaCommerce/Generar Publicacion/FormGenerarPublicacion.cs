using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        private const bool INMEDIATE_PURCHASE = false;
        private const bool BIDDING = true;

        public FormGenerarPublicacion()
        {
            InitializeComponent();
        }

        private void FormGenerarPublicacion_Load(object sender, EventArgs e)
        {

        }

        private void btnBidding_Click(object sender, EventArgs e)
        {
            FormGenerarPublicacionAM formGenerarPublicacionAM = new FormGenerarPublicacionAM(BIDDING);
            formGenerarPublicacionAM.MdiParent = this.MdiParent;
            MdiParent.Size = formGenerarPublicacionAM.Size + Constantes.aumentoTamanio;
            formGenerarPublicacionAM.Show();
            this.Close();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            FormGenerarPublicacionAM formGenerarPublicacionAM = new FormGenerarPublicacionAM(INMEDIATE_PURCHASE);
            formGenerarPublicacionAM.MdiParent = this.MdiParent;
            MdiParent.Size = formGenerarPublicacionAM.Size + Constantes.aumentoTamanio;
            formGenerarPublicacionAM.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
