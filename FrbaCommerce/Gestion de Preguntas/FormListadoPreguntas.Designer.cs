namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class FormListadoPreguntas
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvRealizadas = new System.Windows.Forms.DataGridView();
            this.dgvResponder = new System.Windows.Forms.DataGridView();
            this.buttonResponder = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealizadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 500);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvRealizadas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Realizadas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonResponder);
            this.tabPage2.Controls.Add(this.dgvResponder);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "A Responder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvRealizadas
            // 
            this.dgvRealizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealizadas.Location = new System.Drawing.Point(39, 54);
            this.dgvRealizadas.Name = "dgvRealizadas";
            this.dgvRealizadas.Size = new System.Drawing.Size(647, 315);
            this.dgvRealizadas.TabIndex = 0;
            // 
            // dgvResponder
            // 
            this.dgvResponder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponder.Location = new System.Drawing.Point(39, 54);
            this.dgvResponder.Name = "dgvResponder";
            this.dgvResponder.Size = new System.Drawing.Size(647, 315);
            this.dgvResponder.TabIndex = 0;
            // 
            // buttonResponder
            // 
            this.buttonResponder.Location = new System.Drawing.Point(590, 404);
            this.buttonResponder.Name = "buttonResponder";
            this.buttonResponder.Size = new System.Drawing.Size(96, 36);
            this.buttonResponder.TabIndex = 1;
            this.buttonResponder.Text = "Responder";
            this.buttonResponder.UseVisualStyleBackColor = true;
            // 
            // FormListadoPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 495);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormListadoPreguntas";
            this.Text = "Gestión de Preguntas";
            this.Load += new System.EventHandler(this.FormListadoPreguntas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealizadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvRealizadas;
        private System.Windows.Forms.DataGridView dgvResponder;
        private System.Windows.Forms.Button buttonResponder;
    }
}