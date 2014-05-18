using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using FrbaCommerce.Properties;

namespace FrbaCommerce
{
    public class BaseDeDatos
    {
        //Obtener String de la conexion del archivo config
        public static string obtenerString()
        {
            return Settings.Default.connectionString;
        }
        //Abrir conexion
        public static SqlConnection abrirConexion(){
            SqlConnection conn = new SqlConnection(obtenerString());
            try{
                conn.Open();
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
            return conn;
        }
        //Cerrar conexion
        public static void cerrarConexion(SqlConnection conn)
        {
            try{
                conn.Close();
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
        }
    }
}
