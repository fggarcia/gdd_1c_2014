namespace FrbaCommerce.ABM_Rol
{
    partial class FormABMRolModificar
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
            this.labelSeleccionRol = new System.Windows.Forms.Label();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSeleccionRol
            // 
            this.labelSeleccionRol.AutoSize = true;
            this.labelSeleccionRol.Location = new System.Drawing.Point(23, 23);
            this.labelSeleccionRol.Name = "labelSeleccionRol";
            this.labelSeleccionRol.Size = new System.Drawing.Size(191, 13);
            this.labelSeleccionRol.TabIndex = 12;
            this.labelSeleccionRol.Text = "Seleccione el Rol que desea modificar:";
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(26, 424);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(85, 35);
            this.buttonVolver.TabIndex = 11;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(342, 424);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(85, 35);
            this.buttonModificar.TabIndex = 10;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(26, 52);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(401, 345);
            this.dgvRoles.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(181, 424);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 35);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormABMRolModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 483);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.labelSeleccionRol);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.dgvRoles);
            this.Name = "FormABMRolModificar";
            this.Text = "Modificar Rol";
            this.Load += new System.EventHandler(this.FormABMRolModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeleccionRol;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnEliminar;

    }
}