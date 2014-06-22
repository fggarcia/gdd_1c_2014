namespace FrbaCommerce.ABM_Rol
{
    partial class FormABMRolBaja
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
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.labelSeleccionRol = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(341, 428);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(85, 35);
            this.buttonEliminar.TabIndex = 4;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(25, 428);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(85, 35);
            this.buttonVolver.TabIndex = 6;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // labelSeleccionRol
            // 
            this.labelSeleccionRol.AutoSize = true;
            this.labelSeleccionRol.Location = new System.Drawing.Point(22, 27);
            this.labelSeleccionRol.Name = "labelSeleccionRol";
            this.labelSeleccionRol.Size = new System.Drawing.Size(184, 13);
            this.labelSeleccionRol.TabIndex = 7;
            this.labelSeleccionRol.Text = "Seleccione el Rol que desea eliminar:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(401, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // FormABMRolBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 483);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelSeleccionRol);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonEliminar);
            this.Name = "FormABMRolBaja";
            this.Text = "Baja de Rol";
            this.Load += new System.EventHandler(this.FormABMRolBaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Label labelSeleccionRol;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}