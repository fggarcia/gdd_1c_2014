using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Registro_de_Usuario;
using System.Security.Cryptography; //Para usa SHA256
using System.Data.SqlClient;

namespace FrbaCommerce.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //ENCRIPTACION SHA256 A PARTIR DE UN STRING

        public static string getSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void buttonRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            this.Hide();
            formRegistro.ShowDialog();
            this.Close();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(textBox1.Text, textBox2.Text);
            if (usuario.user_id == "" || usuario.password == "")
            {
                MessageBox.Show("Los campos usuario y contraseña son obligatorios", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Administracion administracion = new Administracion();
            if (administracion.validarUsuario(usuario))
            {
                Int32 cantidadLogin = administracion.loguear(usuario);

                if (cantidadLogin == 0)
                {
                    FormSeleccionRol formSeleccionRol = new FormSeleccionRol(usuario);
                    this.Hide();
                    formSeleccionRol.ShowDialog();
                    this.Close();
                }
                else if (cantidadLogin > 0 && cantidadLogin < 3)
                {
                    MessageBox.Show("Contraseña incorrecta", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show("Su usuario se encuentra bloqueado, por favor contacte al administrador", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = new AutoScaleMode();
        }
        }
              
}



