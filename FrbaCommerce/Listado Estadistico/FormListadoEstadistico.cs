using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace FrbaCommerce.Listado_Estadistico
{
    public partial class FormListadoEstadistico : Form
    {

        public const string año2014 = "2014";

        public const string primerTrimestre = "1er Trimestre";
        public const string segundoTrimestre = "2do Trimestre";
        public const string tercerTrimestre = "3er Trimestre";
        public const string cuartoTrimestre = "4to Trimestre";

        public FormListadoEstadistico()
        {
            InitializeComponent();
        }

        private void FormListadoEstadistico_Load(object sender, EventArgs e)
        {

            // Inicializo las validaciones 
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            cmbAño.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            cmbTrimestre.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);

            cmbAño.Items.Add(año2014);
            cmbAño.SelectedItem = año2014;

            cmbTrimestre.Items.Add(primerTrimestre);
            cmbTrimestre.Items.Add(segundoTrimestre);
            cmbTrimestre.Items.Add(tercerTrimestre);
            cmbTrimestre.Items.Add(cuartoTrimestre);
            cmbTrimestre.SelectedItem = primerTrimestre;

            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private DataTable getTop5(string storedProcedure)
        {
            DataTable tableTop5 = new DataTable();

            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoModificarCliente;

            command.Parameters.AddWithValue("@fecha_desde", obtenerFechaDesdeTrimestre(cmbAño.Text, cmbTrimestre.Text));
            command.Parameters.AddWithValue("@fecha_hasta", obtenerFechaHastaTrimestre(cmbAño.Text, cmbTrimestre.Text));

            Procedimientos.llenarDataTable(command, CommandType.StoredProcedure, tableTop5);

            return tableTop5;
        }

        private DateTime obtenerFechaDesdeTrimestre(String año, String trimestre)
        {
            String mesDesde = obtenerMesDesdeTrimestre(trimestre);

            return new DateTime(Convert.ToInt32(año), Convert.ToInt32(mesDesde), 1, 0, 0, 0); // Se pone 00:00:00 porque quiero el instante inicial del dia
        }

        private String obtenerMesDesdeTrimestre(String trimestre)
        {
            String mesDesde = "00";

            switch (trimestre)
            {
                case primerTrimestre:
                    mesDesde = "01";
                    break;
                case segundoTrimestre:
                    mesDesde = "04";
                    break;
                case tercerTrimestre:
                    mesDesde = "07";
                    break;
                case cuartoTrimestre:
                    mesDesde = "10";
                    break;
            }

            return mesDesde;
        }

        private DateTime obtenerFechaHastaTrimestre(String año, String trimestre)
        {
            String mesHasta = obtenerMesHastaTrimestre(trimestre);

            Int32 añoNumerico = mesHasta.Equals("12") ? Convert.ToInt32(año) + 1 : Convert.ToInt32(año);
            Int32 mesNumerico = mesHasta.Equals("12") ? 1 : Convert.ToInt32(mesHasta);

            return new DateTime(añoNumerico, Convert.ToInt32(mesHasta), 1, 0, 0, 0); // Se pone 00:00:00 porque quiero el instante inicial del dia
        }

        private String obtenerMesHastaTrimestre(String trimestre)
        {
            String mesHasta = "00";

            switch (trimestre)
            {
                case primerTrimestre:
                    mesHasta = "04";
                    break;
                case segundoTrimestre:
                    mesHasta = "07";
                    break;
                case tercerTrimestre:
                    mesHasta = "10";
                    break;
                case cuartoTrimestre:
                    mesHasta = "12";
                    break;
            }

            return mesHasta;
        }

        private void setDataGridViewSettings(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            //dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.ReadOnly = true;
            }

        }

        private void getTotalColumn(DataTable tablaTop5, DataGridView dgv)
        {
            dgv.Columns.Add("TOTAL", "TOTAL");

            for (int j = 0; j < tablaTop5.Rows.Count; j++)
            {
                dgv.Rows[j].Cells["Total"].Value = tablaTop5.Rows[j]["Cantidad"].ToString();
            }
        }

        private void clearDataGridView(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

        }

        private void getMonthColumns(string storedProcedureName, string parameter1, DataTable tablaTop5, DataGridView dataGridView)
        {
            obtenerMesHastaTrimestre(cmbTrimestre.Text);
            int mesInicialTrimestre = Convert.ToInt32(obtenerMesDesdeTrimestre(cmbTrimestre.Text));
            int mesFinalTrimestre = Convert.ToInt32(obtenerMesHastaTrimestre(cmbTrimestre.Text));

            DateTimeFormatInfo dtInfo = new CultureInfo("es-ES", false).DateTimeFormat;

            for (int i = mesInicialTrimestre; i <= mesFinalTrimestre; i++)
            {
                dataGridView.Columns.Add(dtInfo.GetMonthName(i), dtInfo.GetMonthName(i).ToUpper());

                for (int j = 0; j < tablaTop5.Rows.Count; j++)
                {
                    DataTable tableResultadoMensual = new DataTable();

                    SqlCommand command = new SqlCommand();

                    command.CommandText = storedProcedureName;

                    command.Parameters.AddWithValue(parameter1, Convert.ToInt32(tablaTop5.Rows[j][0].ToString()));

                    command.Parameters.AddWithValue("@fecha_desde", obtenerFechaDesdeTrimestre(cmbAño.Text, cmbTrimestre.Text));
                    command.Parameters.AddWithValue("@fecha_hasta", obtenerFechaHastaTrimestre(cmbAño.Text, cmbTrimestre.Text));

                    Procedimientos.llenarDataTable(command, CommandType.StoredProcedure, tableResultadoMensual);

                    if (tableResultadoMensual.Rows.Count > 0)
                        dataGridView.Rows[j].Cells[dtInfo.GetMonthName(i)].Value = tableResultadoMensual.Rows[0]["Cantidad"].ToString();

                }
            }
        }

        private void getDescriptionColumns(DataTable tablaTop5, DataGridView dgvEstadisticas)
        {
            foreach (DataColumn column in tablaTop5.Columns)
            {
                if (column.ColumnName != "Cantidad")
                {
                    dgvEstadisticas.Columns.Add(column.ColumnName, column.ColumnName.ToUpper());
                    for (int i = 0; i < tablaTop5.Rows.Count; i++)
                    {
                        if (column.Ordinal == 0)
                            dgvEstadisticas.Rows.Add();
                        dgvEstadisticas.Rows[i].Cells[column.ColumnName].Value = tablaTop5.Rows[i][column.ColumnName].ToString();
                    }
                }
            }
        }

        private bool validateForm()
        {

            bool passed = this.ValidateChildren();

            if (passed == false)
            {
                MessageBox.Show("Por favor completar el formulario correctamente");
            }

            return passed;
        }

        private void generarListadoEstadistico(String storeProcedureTop5, String storeProcedureMensual, String parameterSPMensual)
        {
            clearDataGridView(dgvListadoEstadistico);

            DataTable tableTop5 = getTop5(storeProcedureTop5);

            getDescriptionColumns(tableTop5, dgvListadoEstadistico);

            getMonthColumns(storeProcedureMensual, parameterSPMensual, tableTop5, dgvListadoEstadistico);

            getTotalColumn(tableTop5, dgvListadoEstadistico);

            setDataGridViewSettings(dgvListadoEstadistico); 
        }

        private void btnMayorFacturacion_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                return;
            }

            generarListadoEstadistico(Constantes.procedimientoMayorFacturacionTOP5, Constantes.procedimientoMayorFacturacionMensual, "@id_vendedor");

        }

        private void btnProductosNoVendidos_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                return;
            }

            generarListadoEstadistico(Constantes.procedimientoProductosNoVendidosTOP5, Constantes.procedimientoProductosNoVendidosMensual, "@id_vendedor");

        }

        private void btnMayorCalificacion_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                return;
            }

            generarListadoEstadistico(Constantes.procedimientoMayorCalificacionTOP5, Constantes.procedimientoMayorCalificacionMensual, "@id_vendedor");

        }

        private void btnPublicacionesSinCalificar_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                return;
            }

            generarListadoEstadistico(Constantes.procedimientoPublicacionesSinCalificarTOP5, Constantes.procedimientoPublicacionesSinCalificarMensual, "@id_cliente");

        }
    }
}
