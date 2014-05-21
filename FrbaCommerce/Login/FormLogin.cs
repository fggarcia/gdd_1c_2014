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
            //INVESTIGAR EN QUE PARTE HACER LA CONEXIÓN A LA BASE DE DATOS.
            //CREAR METODOS QUE ABRAN LA CONEXION Y LA CIERREN.

            //Me falta la parte de seleccionar el rol del usuario. Una vez validado el login, tendria que poder
            //seleccionar entre los distintos roles. Si selecciono uno que no esta definido para ese usuario tendria 
            //que sacar un error.
           
  
            /*Cuando haga click sobre el boton, tendria que conectarme a la base de datos
              y buscar si existe ese id de usuario. Si no existe tengo que devolver un error.
              si no me puedo conectar a la base, lo ideal tambien seria devolver un error.
              Tengo que validar que la contraseña este bien. Si esta todo bien, ingreso. Si la ingresa mal, 
              aumento contador de errores en pass en la base. Si el contador llega a tres. Deshabilito al usuario.
              E informo un mensaje por pantalla diciendo que se contacte con el administrador porque se bloqueo.
              Si realizo un login bien, despues de haber errado, limpio el contador.*/

            //Averiguar si puedo hacer que si no ingresa ningun dato en los textbos, cuando apreta el boton login salta
            //un mensaje diciendo que los campos son requeridos.

            //Ver este tema, como hago para conectar a una base de datos especifica.
            SqlConnection conexion = new SqlConnection();


            Usuarios usuario = new Usuarios(textBox1.Text, textBox2.Text);
            if (usuario.user_id == "" || usuario.password == "")
            {
                MessageBox.Show("Los campos usuario y contraseña son obligatorios","Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    

            Administracion administracion = new Administracion();
            if (administracion.validarUsuario(usuario.user_id))
            {
                
                if (administracion.validarContraseña(usuario.user_id,usuario.password))
                {
                    if(administracion.validarCantidadDeFallasMayorAdos(usuario.user_id))
                    {
                        MessageBox.Show("Su usuario se encuentra bloqueado, por favor contacte al administrador", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        //Salio todo bien. Se accede al sistema.
                        //Se accede a la seleccion del rol.

                    }
                else
                {
                    usuario.cantidadFallasEnPass++;
                    if (usuario.cantidadFallasEnPass < 3)
                    {
                        MessageBox.Show("Contraseña incorrecta", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        administracion.deshabilitarUsuario(textBox1.Text);
                        MessageBox.Show("Tu login esta deshabilitado. Por favor contactarse con el administrador", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

             }

            }
        }
        
        
        
        //Ver si estas clases puede ser definidas en otro lado. Como por ejemplo un package.
        public class Usuarios
        {
            public string user_id;
            public string password;
            public int cantidadFallasEnPass;
            //tendria que tener unos atributos para cada rol!!

            public Usuarios(string user, string pass)
            {
                this.user_id = user;
                this.password = pass;
                this.cantidadFallasEnPass = 0;
            }




        }

        public class Administracion
        {

            public Boolean validarUsuario(string user)
            {
                //llamar a un stored y pasarle user y pass y que me devuelva si esta o no.
                //en el true iria la invocacion al stored
                if (true)
                {
                    return true;
                }
            }

            public Boolean validarContraseña(string user, string pass)
            {
               
                //revisar aca la cantidad de fallas que este usuario tiene, ir a la base y mirar!
                if (true)
                {
                //llamar a un stored y  pasarle pass y que me devuelva si esta bien o no.
                //en el true iria la invocacion al stored.
                    if (true)
                    {
                        return true;
                    }
                 }
                 MessageBox.Show("Tu login esta deshabilitado. Por favor contactarse con el administrador", "Frba Commerce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            public void deshabilitarUsuario(string user)
            {
                //llamo a un stored y le paso el id de usuario a deshabilitar
            }

            public Boolean validarCantidadDeFallasMayorAdos(string user)
            {
                //Sacar la cantidad de fallas de la base y verificar que sea menor a tres.
                return true; 
            }

            


        }
    }


