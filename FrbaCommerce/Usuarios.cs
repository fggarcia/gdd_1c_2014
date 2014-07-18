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
        public int Id_Rol { get; set; }


        public Usuarios(string user, string pass)
        {
            this.user_id = user;
            this.password = pass;
        }
    }

    public class Administracion
    {

        public Boolean primerIngreso(Usuarios user)
		{
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand(Constantes.procedimientoPrimerIngreso, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_Id_Usuario", user.user_id);

            var returnParameter = command.Parameters.Add("@Fecha", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            Int32 primerInicio = Convert.ToInt32(returnParameter.Value);

            Procedimientos.cerrarConexion(conn);
            if (primerInicio == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        public Boolean validarUsuario(Usuarios user)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_LoginUsuarioValido";
            SqlCommand command = new SqlCommand(nombreStoredProcedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Usuario", user.user_id);

            var returnParameter = command.Parameters.Add("@Valido", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            Int32 valido = Convert.ToInt32(returnParameter.Value);

            Procedimientos.cerrarConexion(conn);
            if (valido == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Int32 loguear(Usuarios user)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_Login";
            SqlCommand command = new SqlCommand(nombreStoredProcedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Usuario", user.user_id);
            command.Parameters.AddWithValue("@Password", user.password);

            var returnParameter = command.Parameters.Add("@Intento", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            Int32 intento = Convert.ToInt32(returnParameter.Value);

            Procedimientos.cerrarConexion(conn);

            return intento;
        }

        public void deshabilitarUsuario(Usuarios user)
        {

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@p_Id_Usuario", user.user_id);
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

            if (statusUsuario != 1)
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
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_UsuarioRol";
            SqlCommand command = new SqlCommand(nombreStoredProcedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id_Usuario", user.user_id);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rol rolUsuario = new Rol();
                    rolUsuario.Id_Rol = Convert.ToInt32(reader["Id_Rol"].ToString());
                    rolUsuario.Descripcion = reader["Descripcion"].ToString();
                    rolUsuario.Habilitado = Convert.ToBoolean(reader["Habilitado"].ToString());

                    listaRol.Add(rolUsuario);
                }
            }
            Procedimientos.cerrarConexion(conn);

            return listaRol;
        }
    }
}

