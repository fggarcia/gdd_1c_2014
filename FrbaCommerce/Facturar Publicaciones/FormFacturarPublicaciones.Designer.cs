namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FormFacturarPublicaciones
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelPublicacionesPend = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelSeleccionCant = new System.Windows.Forms.Label();
            this.buttonPagar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(505, 233);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelPublicacionesPend
            // 
            this.labelPublicacionesPend.AutoSize = true;
            this.labelPublicacionesPend.Location = new System.Drawing.Point(26, 21);
            this.labelPublicacionesPend.Name = "labelPublicacionesPend";
            this.labelPublicacionesPend.Size = new System.Drawing.Size(173, 13);
            this.labelPublicacionesPend.TabIndex = 1;
            this.labelPublicacionesPend.Text = "Publicaciones pendientes de pago:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 312);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 2;
            // 
            // labelSeleccionCant
            // 
            this.labelSeleccionCant.AutoSize = true;
            this.labelSeleccionCant.Location = new System.Drawing.Point(26, 315);
            this.labelSeleccionCant.Name = "labelSeleccionCant";
            this.labelSeleccionCant.Size = new System.Drawing.Size(157, 13);
            this.labelSeleccionCant.TabIndex = 3;
            this.labelSeleccionCant.Text = "Seleccione la cantidad a pagar:";
            // 
            // buttonPagar
            // 
            this.buttonPagar.Location = new System.Drawing.Point(282, 310);
            this.buttonPagar.Name = "buttonPagar";
            this.buttonPagar.Size = new System.Drawing.Size(75, 23);
            this.buttonPagar.TabIndex = 4;
            this.buttonPagar.Text = "Pagar";
            this.buttonPagar.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(459, 310);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // FormFacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 360);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonPagar);
            this.Controls.Add(this.labelSeleccionCant);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelPublicacionesPend);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormFacturarPublicaciones";
            this.Text = "Facturar Publicaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelPublicacionesPend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelSeleccionCant;
        private System.Windows.Forms.Button buttonPagar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}