namespace FrbaCommerce.Abm_Empresa
{
    partial class FormABMEmpresa
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
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonModificarEliminar = new System.Windows.Forms.Button();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.TextOpcion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonVolver
            // 
            this.buttonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVolver.Location = new System.Drawing.Point(198, 136);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(77, 31);
            this.buttonVolver.TabIndex = 15;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonModificarEliminar
            // 
            this.buttonModificarEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificarEliminar.Location = new System.Drawing.Point(162, 64);
            this.buttonModificarEliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonModificarEliminar.Name = "buttonModificarEliminar";
            this.buttonModificarEliminar.Size = new System.Drawing.Size(113, 36);
            this.buttonModificarEliminar.TabIndex = 14;
            this.buttonModificarEliminar.Text = "Modificar/Eliminar";
            this.buttonModificarEliminar.UseVisualStyleBackColor = true;
            this.buttonModificarEliminar.Click += new System.EventHandler(this.buttonModificarEliminar_Click);
            // 
            // buttonAlta
            // 
            this.buttonAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlta.Location = new System.Drawing.Point(22, 64);
            this.buttonAlta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(113, 36);
            this.buttonAlta.TabIndex = 13;
            this.buttonAlta.Text = "Dar da Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // TextOpcion
            // 
            this.TextOpcion.AutoSize = true;
            this.TextOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextOpcion.Location = new System.Drawing.Point(19, 21);
            this.TextOpcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextOpcion.Name = "TextOpcion";
            this.TextOpcion.Size = new System.Drawing.Size(119, 13);
            this.TextOpcion.TabIndex = 12;
            this.TextOpcion.Text = "Seleccione una opcion:";
            // 
            // FormABMEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 190);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonModificarEliminar);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.TextOpcion);
            this.Name = "FormABMEmpresa";
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.FormABMEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonModificarEliminar;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Label TextOpcion;

    }
}