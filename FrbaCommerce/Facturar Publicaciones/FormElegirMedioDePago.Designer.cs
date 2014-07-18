namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FormElegirMedioDePago
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
            this.comboBoxMedioPago = new System.Windows.Forms.ComboBox();
            this.labelMedioPago = new System.Windows.Forms.Label();
            this.labelNroTarjeta = new System.Windows.Forms.Label();
            this.labelCantCuotas = new System.Windows.Forms.Label();
            this.textNroTarjeta = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonPagar = new System.Windows.Forms.Button();
            this.comboCuotas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxMedioPago
            // 
            this.comboBoxMedioPago.FormattingEnabled = true;
            this.comboBoxMedioPago.Location = new System.Drawing.Point(183, 37);
            this.comboBoxMedioPago.Name = "comboBoxMedioPago";
            this.comboBoxMedioPago.Size = new System.Drawing.Size(172, 21);
            this.comboBoxMedioPago.TabIndex = 0;
            // 
            // labelMedioPago
            // 
            this.labelMedioPago.AutoSize = true;
            this.labelMedioPago.Location = new System.Drawing.Point(41, 40);
            this.labelMedioPago.Name = "labelMedioPago";
            this.labelMedioPago.Size = new System.Drawing.Size(82, 13);
            this.labelMedioPago.TabIndex = 1;
            this.labelMedioPago.Text = "Medio de Pago:";
            // 
            // labelNroTarjeta
            // 
            this.labelNroTarjeta.AutoSize = true;
            this.labelNroTarjeta.Location = new System.Drawing.Point(41, 116);
            this.labelNroTarjeta.Name = "labelNroTarjeta";
            this.labelNroTarjeta.Size = new System.Drawing.Size(98, 13);
            this.labelNroTarjeta.TabIndex = 2;
            this.labelNroTarjeta.Text = "Número de Tarjeta:";
            // 
            // labelCantCuotas
            // 
            this.labelCantCuotas.AutoSize = true;
            this.labelCantCuotas.Location = new System.Drawing.Point(41, 192);
            this.labelCantCuotas.Name = "labelCantCuotas";
            this.labelCantCuotas.Size = new System.Drawing.Size(103, 13);
            this.labelCantCuotas.TabIndex = 3;
            this.labelCantCuotas.Text = "Cantidad de Cuotas:";
            // 
            // textNroTarjeta
            // 
            this.textNroTarjeta.Location = new System.Drawing.Point(183, 113);
            this.textNroTarjeta.Name = "textNroTarjeta";
            this.textNroTarjeta.Size = new System.Drawing.Size(172, 20);
            this.textNroTarjeta.TabIndex = 4;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(44, 293);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(79, 30);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonPagar
            // 
            this.buttonPagar.Location = new System.Drawing.Point(273, 293);
            this.buttonPagar.Name = "buttonPagar";
            this.buttonPagar.Size = new System.Drawing.Size(82, 30);
            this.buttonPagar.TabIndex = 7;
            this.buttonPagar.Text = "Pagar";
            this.buttonPagar.UseVisualStyleBackColor = true;
            this.buttonPagar.Click += new System.EventHandler(this.buttonPagar_Click);
            // 
            // comboCuotas
            // 
            this.comboCuotas.FormattingEnabled = true;
            this.comboCuotas.Location = new System.Drawing.Point(183, 189);
            this.comboCuotas.Name = "comboCuotas";
            this.comboCuotas.Size = new System.Drawing.Size(90, 21);
            this.comboCuotas.TabIndex = 8;
            // 
            // FormElegirMedioDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 358);
            this.Controls.Add(this.comboCuotas);
            this.Controls.Add(this.buttonPagar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.textNroTarjeta);
            this.Controls.Add(this.labelCantCuotas);
            this.Controls.Add(this.labelNroTarjeta);
            this.Controls.Add(this.labelMedioPago);
            this.Controls.Add(this.comboBoxMedioPago);
            this.Name = "FormElegirMedioDePago";
            this.Text = "Pagar";
            this.Load += new System.EventHandler(this.FormElegirMedioDePago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMedioPago;
        private System.Windows.Forms.Label labelMedioPago;
        private System.Windows.Forms.Label labelNroTarjeta;
        private System.Windows.Forms.Label labelCantCuotas;
        private System.Windows.Forms.TextBox textNroTarjeta;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonPagar;
        private System.Windows.Forms.ComboBox comboCuotas;
    }
}