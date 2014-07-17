namespace FrbaCommerce.Calificar_Vendedor
{
    partial class FormSeleccionACalificar
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
            this.labelSeleccion = new System.Windows.Forms.Label();
            this.dgvACalificar = new System.Windows.Forms.DataGridView();
            this.buttonContinuar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvACalificar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSeleccion
            // 
            this.labelSeleccion.AutoSize = true;
            this.labelSeleccion.Location = new System.Drawing.Point(28, 29);
            this.labelSeleccion.Name = "labelSeleccion";
            this.labelSeleccion.Size = new System.Drawing.Size(170, 13);
            this.labelSeleccion.TabIndex = 0;
            this.labelSeleccion.Text = "Seleccione el vendedor a calificar:";
            // 
            // dgvACalificar
            // 
            this.dgvACalificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvACalificar.Location = new System.Drawing.Point(31, 71);
            this.dgvACalificar.Name = "dgvACalificar";
            this.dgvACalificar.Size = new System.Drawing.Size(563, 281);
            this.dgvACalificar.TabIndex = 1;
            this.dgvACalificar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvACalificar_CellClick);
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.Location = new System.Drawing.Point(506, 384);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(88, 29);
            this.buttonContinuar.TabIndex = 2;
            this.buttonContinuar.Text = "Continuar";
            this.buttonContinuar.UseVisualStyleBackColor = true;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // FormSeleccionACalificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 437);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.dgvACalificar);
            this.Controls.Add(this.labelSeleccion);
            this.Name = "FormSeleccionACalificar";
            this.Text = "Calificar";
            this.Load += new System.EventHandler(this.FormSeleccionACalificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvACalificar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeleccion;
        private System.Windows.Forms.DataGridView dgvACalificar;
        private System.Windows.Forms.Button buttonContinuar;
    }
}