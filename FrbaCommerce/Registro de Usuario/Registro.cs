using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FrbaCommerce.Registro_de_Usuario
{
    class Registro
    {
    //Registrar usuario
    //TODO Falta Agregar Ultima_Fecha y Seleccion de Rol
    public static int crearCliente(string pCliente, string pContrasenia)
        {
            int resultado = 1;
            string pFecha = DateTime.Today.ToString();
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand comando = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Usuario (Id_Usuario, Password, Cantidad_Login) values ('{0}', '{1}', '{2}')", pCliente, pContrasenia, 0), conn);
            comando.ExecuteNonQuery();
            Procedimientos.cerrarConexion(conn);
            return resultado;
        }

    public static int crearEmpresa(string pCliente, string pContrasenia)
    {
        int resultado = 1;
        string pFecha = DateTime.Today.ToString();
        SqlConnection conn = Procedimientos.abrirConexion();
        SqlCommand comando = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Usuario (Id_Usuario, Password, Cantidad_Login) values ('{0}', '{1}', '{2}')", pCliente, pContrasenia, 0), conn);
        comando.ExecuteNonQuery();
        Procedimientos.cerrarConexion(conn);
        return resultado;
    }

    public static string obtenerDescripcionRol(int idRol)
    {
        SqlConnection conn = Procedimientos.abrirConexion();
        SqlCommand command = new SqlCommand(string.Format("select Descripcion from LOS_OPTIMISTAS.Rol where Id_Rol = {0}", idRol), conn);
        string descripcion = (string)command.ExecuteScalar();
        Procedimientos.cerrarConexion(conn);
        return descripcion;
    }
    }
}