namespace FrbaCommerce.Listado_Estadistico
{
    partial class formListadoEstadistico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.btnProductosNoVendidos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMayorFacturacion = new System.Windows.Forms.Button();
            this.btnMayorCalificacion = new System.Windows.Forms.Button();
            this.btnPublicacionesSinCalificar = new System.Windows.Forms.Button();
            this.dgvListadoEstadistico = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(64, 12);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(121, 21);
            this.cmbAño.TabIndex = 0;
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Location = new System.Drawing.Point(64, 52);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(121, 21);
            this.cmbTrimestre.TabIndex = 1;
            // 
            // btnProductosNoVendidos
            // 
            this.btnProductosNoVendidos.Location = new System.Drawing.Point(203, 16);
            this.btnProductosNoVendidos.Name = "btnProductosNoVendidos";
            this.btnProductosNoVendidos.Size = new System.Drawing.Size(122, 57);
            this.btnProductosNoVendidos.TabIndex = 2;
            this.btnProductosNoVendidos.Text = "Vendedores con mayor cantidad de Prod. No Vendidos";
            this.btnProductosNoVendidos.UseVisualStyleBackColor = true;
            this.btnProductosNoVendidos.Click += new System.EventHandler(this.btnProductosNoVendidos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trimestre";
            // 
            // btnMayorFacturacion
            // 
            this.btnMayorFacturacion.Location = new System.Drawing.Point(331, 16);
            this.btnMayorFacturacion.Name = "btnMayorFacturacion";
            this.btnMayorFacturacion.Size = new System.Drawing.Size(122, 57);
            this.btnMayorFacturacion.TabIndex = 5;
            this.btnMayorFacturacion.Text = "Vendedores con mayor Facturación";
            this.btnMayorFacturacion.UseVisualStyleBackColor = true;
            this.btnMayorFacturacion.Click += new System.EventHandler(this.btnMayorFacturacion_Click);
            // 
            // btnMayorCalificacion
            // 
            this.btnMayorCalificacion.Location = new System.Drawing.Point(459, 16);
            this.btnMayorCalificacion.Name = "btnMayorCalificacion";
            this.btnMayorCalificacion.Size = new System.Drawing.Size(122, 57);
            this.btnMayorCalificacion.TabIndex = 6;
            this.btnMayorCalificacion.Text = "Vendedores con mayores calificaciones";
            this.btnMayorCalificacion.UseVisualStyleBackColor = true;
            this.btnMayorCalificacion.Click += new System.EventHandler(this.btnMayorCalificacion_Click);
            // 
            // btnPublicacionesSinCalificar
            // 
            this.btnPublicacionesSinCalificar.Location = new System.Drawing.Point(587, 16);
            this.btnPublicacionesSinCalificar.Name = "btnPublicacionesSinCalificar";
            this.btnPublicacionesSinCalificar.Size = new System.Drawing.Size(122, 57);
            this.btnPublicacionesSinCalificar.TabIndex = 7;
            this.btnPublicacionesSinCalificar.Text = "Clientes con mayor cant. de publicaciones sin calificar";
            this.btnPublicacionesSinCalificar.UseVisualStyleBackColor = true;
            this.btnPublicacionesSinCalificar.Click += new System.EventHandler(this.btnPublicacionesSinCalificar_Click);
            // 
            // dgvListadoEstadistico
            // 
            this.dgvListadoEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEstadistico.Location = new System.Drawing.Point(11, 97);
            this.dgvListadoEstadistico.Name = "dgvListadoEstadistico";
            this.dgvListadoEstadistico.Size = new System.Drawing.Size(698, 299);
            this.dgvListadoEstadistico.TabIndex = 8;
            // 
            // formListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 408);
            this.Controls.Add(this.dgvListadoEstadistico);
            this.Controls.Add(this.btnPublicacionesSinCalificar);
            this.Controls.Add(this.btnMayorCalificacion);
            this.Controls.Add(this.btnMayorFacturacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProductosNoVendidos);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.cmbAño);
            this.Name = "formListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.formListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEstadistico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Button btnProductosNoVendidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMayorFacturacion;
        private System.Windows.Forms.Button btnMayorCalificacion;
        private System.Windows.Forms.Button btnPublicacionesSinCalificar;
        private System.Windows.Forms.DataGridView dgvListadoEstadistico;
    }
}