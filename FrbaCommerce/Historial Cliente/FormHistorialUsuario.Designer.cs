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
            this.tabOfertas = new System.Windows.Forms.TabPage();
            this.tabCalificaciones = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl.SuspendLayout();
            this.TabCompras.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabCompras);
            this.tabControl.Controls.Add(this.tabOfertas);
            this.tabControl.Controls.Add(this.tabCalificaciones);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(739, 512);
            this.tabControl.TabIndex = 0;
            // 
            // TabCompras
            // 
            this.TabCompras.Controls.Add(this.tableLayoutPanel1);
            this.TabCompras.Location = new System.Drawing.Point(4, 22);
            this.TabCompras.Name = "TabCompras";
            this.TabCompras.Padding = new System.Windows.Forms.Padding(3);
            this.TabCompras.Size = new System.Drawing.Size(731, 486);
            this.TabCompras.TabIndex = 0;
            this.TabCompras.Text = "Compras";
            this.TabCompras.UseVisualStyleBackColor = true;
            // 
            // tabOfertas
            // 
            this.tabOfertas.Location = new System.Drawing.Point(4, 22);
            this.tabOfertas.Name = "tabOfertas";
            this.tabOfertas.Padding = new System.Windows.Forms.Padding(3);
            this.tabOfertas.Size = new System.Drawing.Size(731, 486);
            this.tabOfertas.TabIndex = 1;
            this.tabOfertas.Text = "Ofertas";
            this.tabOfertas.UseVisualStyleBackColor = true;
            // 
            // tabCalificaciones
            // 
            this.tabCalificaciones.Location = new System.Drawing.Point(4, 22);
            this.tabCalificaciones.Name = "tabCalificaciones";
            this.tabCalificaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalificaciones.Size = new System.Drawing.Size(731, 486);
            this.tabCalificaciones.TabIndex = 2;
            this.tabCalificaciones.Text = "Calificaciones";
            this.tabCalificaciones.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(266, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FormHistorialUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 511);
            this.Controls.Add(this.tabControl);
            this.Name = "FormHistorialUsuario";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.FormHistorialUsuario_Load);
            this.tabControl.ResumeLayout(false);
            this.TabCompras.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabCompras;
        private System.Windows.Forms.TabPage tabOfertas;
        private System.Windows.Forms.TabPage tabCalificaciones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;






    }
}