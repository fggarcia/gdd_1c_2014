namespace FrbaCommerce.Comprar_Ofertar
{
    partial class FormComprarOfertar
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
            this.labelPaginaActual = new System.Windows.Forms.Label();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.buttonUltimaPagina = new System.Windows.Forms.Button();
            this.buttonSiguiente = new System.Windows.Forms.Button();
            this.buttonAnterior = new System.Windows.Forms.Button();
            this.buttonPrimera = new System.Windows.Forms.Button();
            this.buttonComprarOfertar = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRubros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubros)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPaginaActual
            // 
            this.labelPaginaActual.AutoSize = true;
            this.labelPaginaActual.Location = new System.Drawing.Point(231, 324);
            this.labelPaginaActual.Name = "labelPaginaActual";
            this.labelPaginaActual.Size = new System.Drawing.Size(0, 13);
            this.labelPaginaActual.TabIndex = 15;
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(233, 157);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.Size = new System.Drawing.Size(569, 150);
            this.dgvPublicaciones.TabIndex = 13;
            // 
            // buttonUltimaPagina
            // 
            this.buttonUltimaPagina.Location = new System.Drawing.Point(705, 349);
            this.buttonUltimaPagina.Name = "buttonUltimaPagina";
            this.buttonUltimaPagina.Size = new System.Drawing.Size(97, 30);
            this.buttonUltimaPagina.TabIndex = 12;
            this.buttonUltimaPagina.Text = "Ultima Página";
            this.buttonUltimaPagina.UseVisualStyleBackColor = true;
            this.buttonUltimaPagina.Click += new System.EventHandler(this.buttonUltimo_Click);
            // 
            // buttonSiguiente
            // 
            this.buttonSiguiente.Location = new System.Drawing.Point(548, 349);
            this.buttonSiguiente.Name = "buttonSiguiente";
            this.buttonSiguiente.Size = new System.Drawing.Size(92, 30);
            this.buttonSiguiente.TabIndex = 11;
            this.buttonSiguiente.Text = "Siguiente";
            this.buttonSiguiente.UseVisualStyleBackColor = true;
            this.buttonSiguiente.Click += new System.EventHandler(this.buttonSiguiente_Click);
            // 
            // buttonAnterior
            // 
            this.buttonAnterior.Location = new System.Drawing.Point(394, 349);
            this.buttonAnterior.Name = "buttonAnterior";
            this.buttonAnterior.Size = new System.Drawing.Size(92, 30);
            this.buttonAnterior.TabIndex = 10;
            this.buttonAnterior.Text = "Anterior";
            this.buttonAnterior.UseVisualStyleBackColor = true;
            this.buttonAnterior.Click += new System.EventHandler(this.buttonAnterior_Click);
            // 
            // buttonPrimera
            // 
            this.buttonPrimera.Location = new System.Drawing.Point(233, 349);
            this.buttonPrimera.Name = "buttonPrimera";
            this.buttonPrimera.Size = new System.Drawing.Size(92, 30);
            this.buttonPrimera.TabIndex = 9;
            this.buttonPrimera.Text = "Primera Página";
            this.buttonPrimera.UseVisualStyleBackColor = true;
            this.buttonPrimera.Click += new System.EventHandler(this.buttonPrimera_Click);
            // 
            // buttonComprarOfertar
            // 
            this.buttonComprarOfertar.Location = new System.Drawing.Point(705, 424);
            this.buttonComprarOfertar.Name = "buttonComprarOfertar";
            this.buttonComprarOfertar.Size = new System.Drawing.Size(97, 38);
            this.buttonComprarOfertar.TabIndex = 16;
            this.buttonComprarOfertar.Text = "Comprar/Ofertar";
            this.buttonComprarOfertar.UseVisualStyleBackColor = true;
            this.buttonComprarOfertar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(665, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(233, 115);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(151, 23);
            this.btnClean.TabIndex = 21;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Filtrar por Rubro:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(305, 57);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(181, 20);
            this.txtDescription.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripcion:";
            // 
            // dgvRubros
            // 
            this.dgvRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubros.Location = new System.Drawing.Point(22, 60);
            this.dgvRubros.Name = "dgvRubros";
            this.dgvRubros.Size = new System.Drawing.Size(167, 402);
            this.dgvRubros.TabIndex = 23;
            // 
            // FormComprarOfertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.dgvRubros);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonComprarOfertar);
            this.Controls.Add(this.labelPaginaActual);
            this.Controls.Add(this.dgvPublicaciones);
            this.Controls.Add(this.buttonUltimaPagina);
            this.Controls.Add(this.buttonSiguiente);
            this.Controls.Add(this.buttonAnterior);
            this.Controls.Add(this.buttonPrimera);
            this.Name = "FormComprarOfertar";
            this.Text = "Comprar/Ofertar";
            this.Load += new System.EventHandler(this.FormComprarOfertar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPaginaActual;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.Button buttonUltimaPagina;
        private System.Windows.Forms.Button buttonSiguiente;
        private System.Windows.Forms.Button buttonAnterior;
        private System.Windows.Forms.Button buttonPrimera;
        private System.Windows.Forms.Button buttonComprarOfertar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRubros;
    }
}