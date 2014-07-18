namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FormFacturarPublicaciones
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
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.labelPublicacionesPend = new System.Windows.Forms.Label();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.labelSeleccionCant = new System.Windows.Forms.Label();
            this.buttonContinuar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(29, 50);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.Size = new System.Drawing.Size(505, 233);
            this.dgvPublicaciones.TabIndex = 0;
            // 
            // labelPublicacionesPend
            // 
            this.labelPublicacionesPend.AutoSize = true;
            this.labelPublicacionesPend.Location = new System.Drawing.Point(26, 21);
            this.labelPublicacionesPend.Name = "labelPublicacionesPend";
            this.labelPublicacionesPend.Size = new System.Drawing.Size(173, 13);
            this.labelPublicacionesPend.TabIndex = 1;
            this.labelPublicacionesPend.Text = "Publicaciones pendientes de pago:";
            // 
            // textCantidad
            // 
            this.textCantidad.Location = new System.Drawing.Point(367, 313);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(69, 20);
            this.textCantidad.TabIndex = 2;
            this.textCantidad.Text = "0";
            // 
            // labelSeleccionCant
            // 
            this.labelSeleccionCant.AutoSize = true;
            this.labelSeleccionCant.Location = new System.Drawing.Point(204, 316);
            this.labelSeleccionCant.Name = "labelSeleccionCant";
            this.labelSeleccionCant.Size = new System.Drawing.Size(157, 13);
            this.labelSeleccionCant.TabIndex = 3;
            this.labelSeleccionCant.Text = "Seleccione la cantidad a pagar:";
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.Location = new System.Drawing.Point(459, 311);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(75, 23);
            this.buttonContinuar.TabIndex = 4;
            this.buttonContinuar.Text = "Continuar";
            this.buttonContinuar.UseVisualStyleBackColor = true;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // FormFacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 360);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.labelSeleccionCant);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.labelPublicacionesPend);
            this.Controls.Add(this.dgvPublicaciones);
            this.Name = "FormFacturarPublicaciones";
            this.Text = "Facturar Publicaciones";
            this.Load += new System.EventHandler(this.FormFacturarPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.Label labelPublicacionesPend;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.Label labelSeleccionCant;
        private System.Windows.Forms.Button buttonContinuar;
    }
}