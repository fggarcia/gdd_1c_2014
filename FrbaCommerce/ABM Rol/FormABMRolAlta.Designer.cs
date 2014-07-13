namespace FrbaCommerce.ABM_Rol
{
    partial class FormABMRolAlta
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
            this.nombreRol = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelFuncionalidad = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonAgregarFunc = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstFuncionalidades = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nombreRol
            // 
            this.nombreRol.Location = new System.Drawing.Point(147, 12);
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.Size = new System.Drawing.Size(274, 20);
            this.nombreRol.TabIndex = 0;
            this.nombreRol.TextChanged += new System.EventHandler(this.nombreRol_TextChanged);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(12, 15);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre:";
            this.labelNombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelFuncionalidad
            // 
            this.labelFuncionalidad.AutoSize = true;
            this.labelFuncionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFuncionalidad.Location = new System.Drawing.Point(12, 44);
            this.labelFuncionalidad.Name = "labelFuncionalidad";
            this.labelFuncionalidad.Size = new System.Drawing.Size(76, 13);
            this.labelFuncionalidad.TabIndex = 2;
            this.labelFuncionalidad.Text = "Funcionalidad:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(373, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // buttonAgregarFunc
            // 
            this.buttonAgregarFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarFunc.Location = new System.Drawing.Point(301, 195);
            this.buttonAgregarFunc.Name = "buttonAgregarFunc";
            this.buttonAgregarFunc.Size = new System.Drawing.Size(100, 45);
            this.buttonAgregarFunc.TabIndex = 5;
            this.buttonAgregarFunc.Text = "Agregar Funcionalidad";
            this.buttonAgregarFunc.UseVisualStyleBackColor = true;
            this.buttonAgregarFunc.Click += new System.EventHandler(this.buttonAgregarFunc_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVolver.Location = new System.Drawing.Point(39, 195);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(91, 45);
            this.buttonVolver.TabIndex = 6;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Funcionalidades Incluidas:";
            // 
            // lstFuncionalidades
            // 
            this.lstFuncionalidades.FormattingEnabled = true;
            this.lstFuncionalidades.Location = new System.Drawing.Point(147, 79);
            this.lstFuncionalidades.Name = "lstFuncionalidades";
            this.lstFuncionalidades.Size = new System.Drawing.Size(373, 95);
            this.lstFuncionalidades.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(163, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "Quitar Funcionalidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(433, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 45);
            this.button2.TabIndex = 10;
            this.button2.Text = "Confirmar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(447, 14);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 11;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // FormABMRolAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 258);
            this.Controls.Add(this.chkHabilitado);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstFuncionalidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonAgregarFunc);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelFuncionalidad);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.nombreRol);
            this.Name = "FormABMRolAlta";
            this.Text = "Alta/Modificacion de Rol";
            this.Load += new System.EventHandler(this.FormABMRolAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombreRol;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelFuncionalidad;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonAgregarFunc;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstFuncionalidades;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkHabilitado;
    }
}