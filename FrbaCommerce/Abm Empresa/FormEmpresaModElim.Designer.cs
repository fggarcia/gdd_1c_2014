namespace FrbaCommerce.Abm_Empresa
{
    partial class FormEmpresaModElim
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
            this.labelRazonSocial = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.groupBoxTituloBusqueda = new System.Windows.Forms.GroupBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelCuit = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.ColumnRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxTituloBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRazonSocial
            // 
            this.labelRazonSocial.AutoSize = true;
            this.labelRazonSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelRazonSocial.Location = new System.Drawing.Point(15, 44);
            this.labelRazonSocial.Name = "labelRazonSocial";
            this.labelRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.labelRazonSocial.TabIndex = 0;
            this.labelRazonSocial.Text = "Razón Social:";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(506, 202);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(106, 27);
            this.buttonBuscar.TabIndex = 23;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            // 
            // groupBoxTituloBusqueda
            // 
            this.groupBoxTituloBusqueda.Controls.Add(this.labelRazonSocial);
            this.groupBoxTituloBusqueda.Controls.Add(this.textBoxApellido);
            this.groupBoxTituloBusqueda.Controls.Add(this.textBoxEmail);
            this.groupBoxTituloBusqueda.Controls.Add(this.labelEmail);
            this.groupBoxTituloBusqueda.Controls.Add(this.labelCuit);
            this.groupBoxTituloBusqueda.Controls.Add(this.textBoxNombre);
            this.groupBoxTituloBusqueda.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBoxTituloBusqueda.Location = new System.Drawing.Point(28, 19);
            this.groupBoxTituloBusqueda.Name = "groupBoxTituloBusqueda";
            this.groupBoxTituloBusqueda.Size = new System.Drawing.Size(584, 156);
            this.groupBoxTituloBusqueda.TabIndex = 17;
            this.groupBoxTituloBusqueda.TabStop = false;
            this.groupBoxTituloBusqueda.Text = "Filtrar búsqueda";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(384, 41);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(180, 20);
            this.textBoxApellido.TabIndex = 6;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(119, 94);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(180, 20);
            this.textBoxEmail.TabIndex = 8;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelEmail.Location = new System.Drawing.Point(15, 94);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email:";
            // 
            // labelCuit
            // 
            this.labelCuit.AutoSize = true;
            this.labelCuit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCuit.Location = new System.Drawing.Point(325, 44);
            this.labelCuit.Name = "labelCuit";
            this.labelCuit.Size = new System.Drawing.Size(35, 13);
            this.labelCuit.TabIndex = 1;
            this.labelCuit.Text = "CUIT:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(119, 41);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(180, 20);
            this.textBoxNombre.TabIndex = 5;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(28, 202);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(106, 27);
            this.buttonLimpiar.TabIndex = 22;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(262, 482);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(106, 37);
            this.buttonEliminar.TabIndex = 19;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(28, 482);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(106, 37);
            this.buttonVolver.TabIndex = 21;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(507, 482);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(105, 37);
            this.buttonModificar.TabIndex = 20;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            // 
            // dgvCliente
            // 
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnRazonSocial,
            this.ColumnCuit,
            this.ColumnEmail});
            this.dgvCliente.Location = new System.Drawing.Point(28, 244);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.Size = new System.Drawing.Size(584, 204);
            this.dgvCliente.TabIndex = 18;
            // 
            // ColumnRazonSocial
            // 
            this.ColumnRazonSocial.HeaderText = "Razón Social";
            this.ColumnRazonSocial.Name = "ColumnRazonSocial";
            this.ColumnRazonSocial.Width = 180;
            // 
            // ColumnCuit
            // 
            this.ColumnCuit.HeaderText = "CUIT";
            this.ColumnCuit.Name = "ColumnCuit";
            this.ColumnCuit.Width = 180;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.Width = 180;
            // 
            // FormEmpresaModElim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 538);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.groupBoxTituloBusqueda);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.dgvCliente);
            this.Name = "FormEmpresaModElim";
            this.Text = "Búsqueda de Empresa";
            this.groupBoxTituloBusqueda.ResumeLayout(false);
            this.groupBoxTituloBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRazonSocial;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.GroupBox groupBoxTituloBusqueda;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelCuit;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
    }
}