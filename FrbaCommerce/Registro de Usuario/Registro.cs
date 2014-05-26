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
    public static int crearCliente(string pCliente, string pContrasenia, int pCantidad)
        {
            int resultado = 1;
            string pFecha = DateTime.Today.ToString();
            SqlConnection conn = BaseDeDatos.abrirConexion();
            SqlCommand comando = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Usuario (Id_Usuario, Password, Cantidad_Login) values ('{0}', '{1}', '{2}')", pCliente, pContrasenia, pCantidad), conn);
            comando.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }

    public static int crearEmpresa(string pCliente, string pContrasenia, int pCantidad)
    {
        int resultado = 1;
        string pFecha = DateTime.Today.ToString();
        SqlConnection conn = BaseDeDatos.abrirConexion();
        SqlCommand comando = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Usuario (Id_Usuario, Password, Cantidad_Login) values ('{0}', '{1}', '{2}')", pCliente, pContrasenia, pCantidad), conn);
        comando.ExecuteNonQuery();
        conn.Close();
        return resultado;
    }
    }
}