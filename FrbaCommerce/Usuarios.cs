using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FrbaCommerce
{
    public class Usuarios
    {
        public string user_id;
        public string password;
        public string rol;
        public int cantidadFallasEnPass;
        //tendria que tener unos atributos para cada rol!!

        public Usuarios(string user, string pass, string rol)
        {
            this.user_id = user;
            this.password = pass;
            this.rol = rol;
        }
    }

    public class Administracion
    {

        public Boolean validarUsuario(Usuarios user)
        {
            //llamar a un stored y pasarle user y que me devuelva si esta o no.
            //en el true iria la invocacion al stored

            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand comando = new SqlCommand(string.Format("Select Id_usuario from LOS_OPTIMISTAS.Usuario where Id_usuario = {0}", user.user_id), conn);
            comando.BeginExecuteReader();
            if (true)
            {
                return true;
                //setear el atributo de los errores en contraseña de la clase usuario aca, cuando voy a validar al usuario!!
                //Si el usuario es valido seteo los errores en contraña.
            }
            return false;
        }

        public Boolean validarContraseña(Usuarios user)
        {
            //llamar a un stored y  pasarle pass y que me devuelva si esta bien o no.
            //en el true iria la invocacion al stored.
            //EN VEZ DE PONER TANTOS IF, PODRIA HACER QUE EL STORED DEVUELVA TRUE OR FALSE SI LA CONTRASEÑA ESTA BIEN O NO
            //Y DIRECTAMENTE RETORNO LO QUE ME DEVUELVA EL STORED.
            if (true)
            {
                return true;
            }
        }

        public void deshabilitarUsuario(Usuarios user)
        {
            //llamo a un stored y le paso el id de usuario a deshabilitar
        }

        public Boolean validarCantidadDeFallasMayorAdos(Usuarios user)
        {
            //Sacar la cantidad de fallas de la base y verificar que sea menor a tres.
            return true;
        }

        public Boolean statusUsuario(Usuarios user)
        {
            //Sacar el status de la base y ver si esta habilitado o no;
            return true;
        }
    }
}

