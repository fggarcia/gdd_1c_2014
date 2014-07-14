namespace FrbaCommerce.Historial_Cliente
{
    partial class FormHistorialUsuario
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabCompras = new System.Windows.Forms.TabPage();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.tabOfertas = new System.Windows.Forms.TabPage();
            this.dgvOfertas = new System.Windows.Forms.DataGridView();
            this.tabCalificaciones = new System.Windows.Forms.TabPage();
            this.dgvCalificaciones = new System.Windows.Forms.DataGridView();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.labelCompras = new System.Windows.Forms.Label();
            this.labelVentas = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.TabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.tabOfertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).BeginInit();
            this.tabCalificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabCompras);
            this.tabControl.Controls.Add(this.tabOfertas);
            this.tabControl.Controls.Add(this.tabCalificaciones);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(718, 438);
            this.tabControl.TabIndex = 0;
            // 
            // TabCompras
            // 
            this.TabCompras.Controls.Add(this.labelVentas);
            this.TabCompras.Controls.Add(this.labelCompras);
            this.TabCompras.Controls.Add(this.dgvVentas);
            this.TabCompras.Controls.Add(this.dgvCompras);
            this.TabCompras.Location = new System.Drawing.Point(4, 22);
            this.TabCompras.Name = "TabCompras";
            this.TabCompras.Padding = new System.Windows.Forms.Padding(3);
            this.TabCompras.Size = new System.Drawing.Size(710, 412);
            this.TabCompras.TabIndex = 0;
            this.TabCompras.Text = "Compras/Ventas";
            this.TabCompras.UseVisualStyleBackColor = true;
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Location = new System.Drawing.Point(25, 45);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.Size = new System.Drawing.Size(658, 147);
            this.dgvCompras.TabIndex = 0;
            this.dgvCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabOfertas
            // 
            this.tabOfertas.Controls.Add(this.dgvOfertas);
            this.tabOfertas.Location = new System.Drawing.Point(4, 22);
            this.tabOfertas.Name = "tabOfertas";
            this.tabOfertas.Padding = new System.Windows.Forms.Padding(3);
            this.tabOfertas.Size = new System.Drawing.Size(710, 412);
            this.tabOfertas.TabIndex = 1;
            this.tabOfertas.Text = "Ofertas";
            this.tabOfertas.UseVisualStyleBackColor = true;
            // 
            // dgvOfertas
            // 
            this.dgvOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfertas.Location = new System.Drawing.Point(27, 25);
            this.dgvOfertas.Name = "dgvOfertas";
            this.dgvOfertas.Size = new System.Drawing.Size(658, 357);
            this.dgvOfertas.TabIndex = 1;
            // 
            // tabCalificaciones
            // 
            this.tabCalificaciones.Controls.Add(this.dgvCalificaciones);
            this.tabCalificaciones.Location = new System.Drawing.Point(4, 22);
            this.tabCalificaciones.Name = "tabCalificaciones";
            this.tabCalificaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalificaciones.Size = new System.Drawing.Size(710, 412);
            this.tabCalificaciones.TabIndex = 2;
            this.tabCalificaciones.Text = "Calificaciones";
            this.tabCalificaciones.UseVisualStyleBackColor = true;
            // 
            // dgvCalificaciones
            // 
            this.dgvCalificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalificaciones.Location = new System.Drawing.Point(27, 25);
            this.dgvCalificaciones.Name = "dgvCalificaciones";
            this.dgvCalificaciones.Size = new System.Drawing.Size(658, 357);
            this.dgvCalificaciones.TabIndex = 1;
            // 
            // dgvVentas
            // 
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(25, 232);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(658, 147);
            this.dgvVentas.TabIndex = 1;
            // 
            // labelCompras
            // 
            this.labelCompras.AutoSize = true;
            this.labelCompras.Location = new System.Drawing.Point(25, 26);
            this.labelCompras.Name = "labelCompras";
            this.labelCompras.Size = new System.Drawing.Size(101, 13);
            this.labelCompras.TabIndex = 2;
            this.labelCompras.Text = "Compras realizadas:";
            // 
            // labelVentas
            // 
            this.labelVentas.AutoSize = true;
            this.labelVentas.Location = new System.Drawing.Point(25, 207);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(93, 13);
            this.labelVentas.TabIndex = 3;
            this.labelVentas.Text = "Ventas realizadas:";
            // 
            // FormHistorialUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 461);
            this.Controls.Add(this.tabControl);
            this.Name = "FormHistorialUsuario";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.FormHistorialUsuario_Load);
            this.tabControl.ResumeLayout(false);
            this.TabCompras.ResumeLayout(false);
            this.TabCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.tabOfertas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).EndInit();
            this.tabCalificaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabCompras;
        private System.Windows.Forms.TabPage tabOfertas;
        private System.Windows.Forms.TabPage tabCalificaciones;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridView dgvOfertas;
        private System.Windows.Forms.DataGridView dgvCalificaciones;
        private System.Windows.Forms.Label labelVentas;
        private System.Windows.Forms.Label labelCompras;
        private System.Windows.Forms.DataGridView dgvVentas;






    }
}