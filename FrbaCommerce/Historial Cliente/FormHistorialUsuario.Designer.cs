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
            this.labelVentas = new System.Windows.Forms.Label();
            this.labelCompras = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.tabOfertas = new System.Windows.Forms.TabPage();
            this.labelNoGanadas = new System.Windows.Forms.Label();
            this.labelGanadas = new System.Windows.Forms.Label();
            this.dgvSubNoGanadas = new System.Windows.Forms.DataGridView();
            this.dgvSubGanadas = new System.Windows.Forms.DataGridView();
            this.tabCalificaciones = new System.Windows.Forms.TabPage();
            this.labelCalificacionesRecibidas = new System.Windows.Forms.Label();
            this.labelCalificacionesOtorgadas = new System.Windows.Forms.Label();
            this.dgvCalRecibidas = new System.Windows.Forms.DataGridView();
            this.dgvCalOtorgadas = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.TabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.tabOfertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubNoGanadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGanadas)).BeginInit();
            this.tabCalificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalRecibidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalOtorgadas)).BeginInit();
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
            // labelVentas
            // 
            this.labelVentas.AutoSize = true;
            this.labelVentas.Location = new System.Drawing.Point(25, 207);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(93, 13);
            this.labelVentas.TabIndex = 3;
            this.labelVentas.Text = "Ventas realizadas:";
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
            // dgvVentas
            // 
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(25, 232);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(658, 147);
            this.dgvVentas.TabIndex = 1;
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
            this.tabOfertas.Controls.Add(this.labelNoGanadas);
            this.tabOfertas.Controls.Add(this.labelGanadas);
            this.tabOfertas.Controls.Add(this.dgvSubNoGanadas);
            this.tabOfertas.Controls.Add(this.dgvSubGanadas);
            this.tabOfertas.Location = new System.Drawing.Point(4, 22);
            this.tabOfertas.Name = "tabOfertas";
            this.tabOfertas.Padding = new System.Windows.Forms.Padding(3);
            this.tabOfertas.Size = new System.Drawing.Size(710, 412);
            this.tabOfertas.TabIndex = 1;
            this.tabOfertas.Text = "Ofertas";
            this.tabOfertas.UseVisualStyleBackColor = true;
            // 
            // labelNoGanadas
            // 
            this.labelNoGanadas.AutoSize = true;
            this.labelNoGanadas.Location = new System.Drawing.Point(26, 211);
            this.labelNoGanadas.Name = "labelNoGanadas";
            this.labelNoGanadas.Size = new System.Drawing.Size(115, 13);
            this.labelNoGanadas.TabIndex = 7;
            this.labelNoGanadas.Text = "Subastas no Ganadas:";
            // 
            // labelGanadas
            // 
            this.labelGanadas.AutoSize = true;
            this.labelGanadas.Location = new System.Drawing.Point(26, 30);
            this.labelGanadas.Name = "labelGanadas";
            this.labelGanadas.Size = new System.Drawing.Size(100, 13);
            this.labelGanadas.TabIndex = 6;
            this.labelGanadas.Text = "Subastas Ganadas:";
            // 
            // dgvSubNoGanadas
            // 
            this.dgvSubNoGanadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubNoGanadas.Location = new System.Drawing.Point(26, 236);
            this.dgvSubNoGanadas.Name = "dgvSubNoGanadas";
            this.dgvSubNoGanadas.Size = new System.Drawing.Size(658, 147);
            this.dgvSubNoGanadas.TabIndex = 5;
            // 
            // dgvSubGanadas
            // 
            this.dgvSubGanadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubGanadas.Location = new System.Drawing.Point(26, 49);
            this.dgvSubGanadas.Name = "dgvSubGanadas";
            this.dgvSubGanadas.Size = new System.Drawing.Size(658, 147);
            this.dgvSubGanadas.TabIndex = 4;
            // 
            // tabCalificaciones
            // 
            this.tabCalificaciones.Controls.Add(this.labelCalificacionesRecibidas);
            this.tabCalificaciones.Controls.Add(this.labelCalificacionesOtorgadas);
            this.tabCalificaciones.Controls.Add(this.dgvCalRecibidas);
            this.tabCalificaciones.Controls.Add(this.dgvCalOtorgadas);
            this.tabCalificaciones.Location = new System.Drawing.Point(4, 22);
            this.tabCalificaciones.Name = "tabCalificaciones";
            this.tabCalificaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalificaciones.Size = new System.Drawing.Size(710, 412);
            this.tabCalificaciones.TabIndex = 2;
            this.tabCalificaciones.Text = "Calificaciones";
            this.tabCalificaciones.UseVisualStyleBackColor = true;
            // 
            // labelCalificacionesRecibidas
            // 
            this.labelCalificacionesRecibidas.AutoSize = true;
            this.labelCalificacionesRecibidas.Location = new System.Drawing.Point(26, 211);
            this.labelCalificacionesRecibidas.Name = "labelCalificacionesRecibidas";
            this.labelCalificacionesRecibidas.Size = new System.Drawing.Size(125, 13);
            this.labelCalificacionesRecibidas.TabIndex = 11;
            this.labelCalificacionesRecibidas.Text = "Calificaciones Recibidas:";
            // 
            // labelCalificacionesOtorgadas
            // 
            this.labelCalificacionesOtorgadas.AutoSize = true;
            this.labelCalificacionesOtorgadas.Location = new System.Drawing.Point(26, 30);
            this.labelCalificacionesOtorgadas.Name = "labelCalificacionesOtorgadas";
            this.labelCalificacionesOtorgadas.Size = new System.Drawing.Size(127, 13);
            this.labelCalificacionesOtorgadas.TabIndex = 10;
            this.labelCalificacionesOtorgadas.Text = "Calificaciones Otorgadas:";
            // 
            // dgvCalRecibidas
            // 
            this.dgvCalRecibidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalRecibidas.Location = new System.Drawing.Point(26, 236);
            this.dgvCalRecibidas.Name = "dgvCalRecibidas";
            this.dgvCalRecibidas.Size = new System.Drawing.Size(658, 147);
            this.dgvCalRecibidas.TabIndex = 9;
            // 
            // dgvCalOtorgadas
            // 
            this.dgvCalOtorgadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalOtorgadas.Location = new System.Drawing.Point(26, 49);
            this.dgvCalOtorgadas.Name = "dgvCalOtorgadas";
            this.dgvCalOtorgadas.Size = new System.Drawing.Size(658, 147);
            this.dgvCalOtorgadas.TabIndex = 8;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.tabOfertas.ResumeLayout(false);
            this.tabOfertas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubNoGanadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGanadas)).EndInit();
            this.tabCalificaciones.ResumeLayout(false);
            this.tabCalificaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalRecibidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalOtorgadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabCompras;
        private System.Windows.Forms.TabPage tabOfertas;
        private System.Windows.Forms.TabPage tabCalificaciones;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label labelVentas;
        private System.Windows.Forms.Label labelCompras;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label labelNoGanadas;
        private System.Windows.Forms.Label labelGanadas;
        private System.Windows.Forms.DataGridView dgvSubNoGanadas;
        private System.Windows.Forms.DataGridView dgvSubGanadas;
        private System.Windows.Forms.Label labelCalificacionesRecibidas;
        private System.Windows.Forms.Label labelCalificacionesOtorgadas;
        private System.Windows.Forms.DataGridView dgvCalRecibidas;
        private System.Windows.Forms.DataGridView dgvCalOtorgadas;






    }
}