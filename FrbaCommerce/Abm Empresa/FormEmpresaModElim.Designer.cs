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
            this.textCuit = new System.Windows.Forms.TextBox();
            this.textMail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelCuit = new System.Windows.Forms.Label();
            this.textRazonSocial = new System.Windows.Forms.TextBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.dgvEmpresa = new System.Windows.Forms.DataGridView();
            this.groupBoxTituloBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).BeginInit();
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
            this.buttonBuscar.Location = new System.Drawing.Point(706, 202);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(106, 27);
            this.buttonBuscar.TabIndex = 23;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // groupBoxTituloBusqueda
            // 
            this.groupBoxTituloBusqueda.Controls.Add(this.labelRazonSocial);
            this.groupBoxTituloBusqueda.Controls.Add(this.textCuit);
            this.groupBoxTituloBusqueda.Controls.Add(this.textMail);
            this.groupBoxTituloBusqueda.Controls.Add(this.labelEmail);
            this.groupBoxTituloBusqueda.Controls.Add(this.labelCuit);
            this.groupBoxTituloBusqueda.Controls.Add(this.textRazonSocial);
            this.groupBoxTituloBusqueda.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBoxTituloBusqueda.Location = new System.Drawing.Point(28, 19);
            this.groupBoxTituloBusqueda.Name = "groupBoxTituloBusqueda";
            this.groupBoxTituloBusqueda.Size = new System.Drawing.Size(784, 156);
            this.groupBoxTituloBusqueda.TabIndex = 17;
            this.groupBoxTituloBusqueda.TabStop = false;
            this.groupBoxTituloBusqueda.Text = "Filtrar búsqueda";
            // 
            // textCuit
            // 
            this.textCuit.Location = new System.Drawing.Point(578, 41);
            this.textCuit.Name = "textCuit";
            this.textCuit.Size = new System.Drawing.Size(180, 20);
            this.textCuit.TabIndex = 6;
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(119, 94);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(180, 20);
            this.textMail.TabIndex = 8;
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
            this.labelCuit.Location = new System.Drawing.Point(519, 44);
            this.labelCuit.Name = "labelCuit";
            this.labelCuit.Size = new System.Drawing.Size(35, 13);
            this.labelCuit.TabIndex = 1;
            this.labelCuit.Text = "CUIT:";
            // 
            // textRazonSocial
            // 
            this.textRazonSocial.Location = new System.Drawing.Point(119, 41);
            this.textRazonSocial.Name = "textRazonSocial";
            this.textRazonSocial.Size = new System.Drawing.Size(180, 20);
            this.textRazonSocial.TabIndex = 5;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(28, 202);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(106, 27);
            this.buttonLimpiar.TabIndex = 22;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(365, 482);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(106, 37);
            this.buttonEliminar.TabIndex = 19;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(28, 482);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(106, 37);
            this.buttonVolver.TabIndex = 21;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(707, 482);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(105, 37);
            this.buttonModificar.TabIndex = 20;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // dgvEmpresa
            // 
            this.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresa.Location = new System.Drawing.Point(28, 244);
            this.dgvEmpresa.Name = "dgvEmpresa";
            this.dgvEmpresa.Size = new System.Drawing.Size(784, 204);
            this.dgvEmpresa.TabIndex = 18;
            this.dgvEmpresa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresa_CellClick);
            this.dgvEmpresa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresa_CellContentClick);
            // 
            // FormEmpresaModElim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 538);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.groupBoxTituloBusqueda);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.dgvEmpresa);
            this.Name = "FormEmpresaModElim";
            this.Text = "Búsqueda de Empresa";
            this.groupBoxTituloBusqueda.ResumeLayout(false);
            this.groupBoxTituloBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRazonSocial;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.GroupBox groupBoxTituloBusqueda;
        private System.Windows.Forms.TextBox textCuit;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelCuit;
        private System.Windows.Forms.TextBox textRazonSocial;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.DataGridView dgvEmpresa;
    }
}