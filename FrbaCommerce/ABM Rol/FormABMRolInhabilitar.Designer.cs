namespace FrbaCommerce.ABM_Rol
{
    partial class FormABMRolInhabilitar
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
            this.buttonInhabilitar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSeleccionRol
            // 
            this.labelSeleccionRol.AutoSize = true;
            this.labelSeleccionRol.Location = new System.Drawing.Point(23, 23);
            this.labelSeleccionRol.Name = "labelSeleccionRol";
            this.labelSeleccionRol.Size = new System.Drawing.Size(193, 13);
            this.labelSeleccionRol.TabIndex = 11;
            this.labelSeleccionRol.Text = "Seleccione el Rol que desea inhabilitar:";
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(26, 424);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(85, 35);
            this.buttonVolver.TabIndex = 10;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonInhabilitar
            // 
            this.buttonInhabilitar.Location = new System.Drawing.Point(342, 424);
            this.buttonInhabilitar.Name = "buttonInhabilitar";
            this.buttonInhabilitar.Size = new System.Drawing.Size(85, 35);
            this.buttonInhabilitar.TabIndex = 9;
            this.buttonInhabilitar.Text = "Inhabilitar";
            this.buttonInhabilitar.UseVisualStyleBackColor = true;
            this.buttonInhabilitar.Click += new System.EventHandler(this.buttonInhabilitar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(401, 345);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(178, 424);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 35);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormABMRolInhabilitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 483);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.labelSeleccionRol);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonInhabilitar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormABMRolInhabilitar";
            this.Text = "FormABMRolInhabilitar";
            this.Load += new System.EventHandler(this.FormABMRolInhabilitar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeleccionRol;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonInhabilitar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminar;
    }
}