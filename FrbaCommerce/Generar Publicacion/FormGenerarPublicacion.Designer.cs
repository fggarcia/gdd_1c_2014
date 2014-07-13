namespace FrbaCommerce.Generar_Publicacion
{
    partial class FormGenerarPublicacion
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
            this.btnBidding = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.TextOpcion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBidding
            // 
            this.btnBidding.Location = new System.Drawing.Point(22, 64);
            this.btnBidding.Name = "btnBidding";
            this.btnBidding.Size = new System.Drawing.Size(113, 36);
            this.btnBidding.TabIndex = 0;
            this.btnBidding.Text = "Subasta";
            this.btnBidding.UseVisualStyleBackColor = true;
            this.btnBidding.Click += new System.EventHandler(this.btnBidding_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(162, 64);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(113, 36);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Compra Inmediata";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(198, 136);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(77, 31);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // TextOpcion
            // 
            this.TextOpcion.AutoSize = true;
            this.TextOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextOpcion.Location = new System.Drawing.Point(19, 21);
            this.TextOpcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextOpcion.Name = "TextOpcion";
            this.TextOpcion.Size = new System.Drawing.Size(119, 13);
            this.TextOpcion.TabIndex = 13;
            this.TextOpcion.Text = "Seleccione una opcion:";
            // 
            // FormGenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 190);
            this.Controls.Add(this.TextOpcion);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnBidding);
            this.Name = "FormGenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.FormGenerarPublicacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBidding;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label TextOpcion;
    }
}