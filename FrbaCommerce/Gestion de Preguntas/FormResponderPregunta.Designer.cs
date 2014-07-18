namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class FormResponderPregunta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPregunta = new System.Windows.Forms.Label();
            this.textPregunta = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textRespuesta = new System.Windows.Forms.TextBox();
            this.labelRespuesta = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textPregunta);
            this.panel1.Controls.Add(this.labelPregunta);
            this.panel1.Location = new System.Drawing.Point(40, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 152);
            this.panel1.TabIndex = 1;
            // 
            // labelPregunta
            // 
            this.labelPregunta.AutoSize = true;
            this.labelPregunta.Location = new System.Drawing.Point(14, 12);
            this.labelPregunta.Name = "labelPregunta";
            this.labelPregunta.Size = new System.Drawing.Size(53, 13);
            this.labelPregunta.TabIndex = 1;
            this.labelPregunta.Text = "Pregunta:";
            // 
            // textPregunta
            // 
            this.textPregunta.Location = new System.Drawing.Point(17, 38);
            this.textPregunta.Multiline = true;
            this.textPregunta.Name = "textPregunta";
            this.textPregunta.ReadOnly = true;
            this.textPregunta.Size = new System.Drawing.Size(381, 85);
            this.textPregunta.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textRespuesta);
            this.panel2.Controls.Add(this.labelRespuesta);
            this.panel2.Location = new System.Drawing.Point(40, 229);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 152);
            this.panel2.TabIndex = 3;
            // 
            // textRespuesta
            // 
            this.textRespuesta.Location = new System.Drawing.Point(17, 38);
            this.textRespuesta.MaxLength = 255;
            this.textRespuesta.Multiline = true;
            this.textRespuesta.Name = "textRespuesta";
            this.textRespuesta.Size = new System.Drawing.Size(381, 85);
            this.textRespuesta.TabIndex = 2;
            // 
            // labelRespuesta
            // 
            this.labelRespuesta.AutoSize = true;
            this.labelRespuesta.Location = new System.Drawing.Point(14, 12);
            this.labelRespuesta.Name = "labelRespuesta";
            this.labelRespuesta.Size = new System.Drawing.Size(61, 13);
            this.labelRespuesta.TabIndex = 1;
            this.labelRespuesta.Text = "Respuesta:";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(364, 402);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(91, 32);
            this.buttonAceptar.TabIndex = 4;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Caracteres Max. 255";
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(40, 402);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(91, 32);
            this.buttonVolver.TabIndex = 5;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // FormResponderPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 454);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormResponderPregunta";
            this.Text = "FormResponderPregunta";
            this.Load += new System.EventHandler(this.FormResponderPregunta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textPregunta;
        private System.Windows.Forms.Label labelPregunta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textRespuesta;
        private System.Windows.Forms.Label labelRespuesta;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonVolver;

    }
}