﻿namespace FrbaCommerce.Abm_Cliente
{
    partial class FormABMCliente
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
            this.buttonModificarEliminar = new System.Windows.Forms.Button();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.TextOpcion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonModificarEliminar
            // 
            this.buttonModificarEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificarEliminar.Location = new System.Drawing.Point(162, 64);
            this.buttonModificarEliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonModificarEliminar.Name = "buttonModificarEliminar";
            this.buttonModificarEliminar.Size = new System.Drawing.Size(113, 36);
            this.buttonModificarEliminar.TabIndex = 9;
            this.buttonModificarEliminar.Text = "Modificar/Eliminar";
            this.buttonModificarEliminar.UseVisualStyleBackColor = true;
            this.buttonModificarEliminar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonAlta
            // 
            this.buttonAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlta.Location = new System.Drawing.Point(22, 64);
            this.buttonAlta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(113, 36);
            this.buttonAlta.TabIndex = 8;
            this.buttonAlta.Text = "Dar da Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // TextOpcion
            // 
            this.TextOpcion.AutoSize = true;
            this.TextOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextOpcion.Location = new System.Drawing.Point(19, 21);
            this.TextOpcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextOpcion.Name = "TextOpcion";
            this.TextOpcion.Size = new System.Drawing.Size(119, 13);
            this.TextOpcion.TabIndex = 7;
            this.TextOpcion.Text = "Seleccione una opcion:";
            // 
            // FormABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 128);
            this.Controls.Add(this.buttonModificarEliminar);
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.TextOpcion);
            this.Name = "FormABMCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FormABMCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModificarEliminar;
        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Label TextOpcion;
    }
}