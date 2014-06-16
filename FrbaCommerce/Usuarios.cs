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
        public int cantidadFallasEnPass;
        //tendria que tener unos atributos para cada rol!!

        public Usuarios(string user, string pass)
        {
            this.user_id = user;
            this.password = pass;
        }
    }

    public class Administracion
    {

        public Boolean validarUsuario(Usuarios user)
        {

            if (!Procedimientos.esUnico("LOS_OPTIMISTAS.Usuario", "Id_Usuario", user.user_id))
            {
                SqlConnection conn = Procedimientos.abrirConexion();
                SqlCommand command = new SqlCommand("select Cantidad_Login from LOS_OPTIMISTAS.Usuario where Id_usuario = @user", conn);
                command.Parameters.AddWithValue("@user", user);
                user.cantidadFallasEnPass = (Int32)command.ExecuteScalar();
                Procedimientos.cerrarConexion(conn);

                return true;
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
            
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@p_Id_Usuario",user.user_id);
            Procedimientos.ejecutarStoredProcedure(command, "BajaUsuario", false);
        }

        public Boolean validarCantidadDeFallasMayorAdos(Usuarios user)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand("select Cantidad_Login from LOS_OPTIMISTAS.Usuario where Id_usuario = @user", conn);
            command.Parameters.AddWithValue("@user", user);
            Int32 cantidadDeFallas = (Int32)command.ExecuteScalar();
            Procedimientos.cerrarConexion(conn);

            if (cantidadDeFallas > 2)
            {
                return true;
            }

            return false;
            
        }

        public Boolean usuarioHabilitado(Usuarios user)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand("select Habilitado from LOS_OPTIMISTAS.Usuario where Id_usuario = @user", conn);
            command.Parameters.AddWithValue("@user", user);
            Int32 statusUsuario = (Int32)command.ExecuteScalar();
            Procedimientos.cerrarConexion(conn);

            if(statusUsuario != 1)
            {
                return false;
            }  
            else
            {
                return true;
            }
        }

        public void actualizarCantidadDeFallas(Usuarios user)
        {
            user.cantidadFallasEnPass++;
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand(string.Format("update LOS_OPTIMISTAS.Usuario set Cantidad_Login = {0} where Id_Usuario = {1}", user.cantidadFallasEnPass, user.user_id), conn);
            int numeroDeFilasAfectadas = command.ExecuteNonQuery();
            Procedimientos.cerrarConexion(conn);
        }

        public void limpiarIntentosFallidos(Usuarios user)
        {
            user.cantidadFallasEnPass = 0;
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand(string.Format("update LOS_OPTIMISTAS.Usuario set Cantidad_Login = 0 where Id_Usuario = {0}", user.user_id), conn);
            int numeroDeFilasAfectadas = command.ExecuteNonQuery();
            Procedimientos.cerrarConexion(conn);
        }

        public List<Rol> obtenerRolesDe(Usuarios user)
        {
            List<Rol> listaRol = new List<Rol>();
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand(string.Format("select UR.Id_Rol, R.Descripcion from LOS_OPTIMISTAS.Usuario_Rol UR join LOS_OPTIMISTAS.Rol R on UR.Id_Rol = R.Id_Rol where UR.Id_usuario = {0} and UR.Habilitado <> 0", user.user_id), conn);
            SqlDataReader lectura = command.ExecuteReader();
            while (lectura.Read())
            {
                Rol rolUsuario = new Rol();
                rolUsuario.Id_Rol = lectura.GetInt32(0);
                rolUsuario.Descripcion = lectura.GetString(1);

                listaRol.Add(rolUsuario);
            }
            Procedimientos.cerrarConexion(conn);
            return listaRol;

        }



    }
}

