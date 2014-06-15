using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce
{
    class Validaciones
    {
        //Validacion de tipo de datos correctos
        public static bool validarNumero(string unNumero)
        {
            if (Regex.IsMatch(unNumero, @"^\d+$")) return true;
            else return false;
        }

        public static bool validarString(string unString)
        {
            if (Regex.IsMatch(unString, @"[\p{L}\s]")) return true;
            else return false;
        }

        //Validacion de formato de mail correcto
        public static bool validarMail(string unMail)
        {
            if (!(Regex.IsMatch(unMail, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$"))) 
            {
                MessageBox.Show("El formato del mail es incorrecto, por favor verifique los datos");
                return false;
            }
            else return true;
        }

        //Validacion formato de fecha de nacimiento correcto

        public static bool validarFechaNacimiento(string dia, string mes, string anio)
        {
            if (Convert.ToInt32(dia) < 1 || Convert.ToInt32(dia) > 31)
            {
                MessageBox.Show("Los siguientes campos de la Fecha de Nacimiento son erroneos: Día");
                return false;
            }

            if (Convert.ToInt32(mes) < 1 || Convert.ToInt32(mes) > 12)
            {
                MessageBox.Show("Los siguientes campos de la Fecha de Nacimiento son erroneos: Mes");
                return false;
            }

            if (Convert.ToInt32(anio) < 1900 || Convert.ToInt32(anio) > 2014)
            {
                MessageBox.Show("Los siguientes campos de la Fecha de Nacimiento son erroneos: Año");
                return false;
            }

            DateTime fechaNac = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
            if (fechaNac > Variables.FechaHoraSistema)
            {
                MessageBox.Show("La Fecha de Nacimiento debe ser menor a la fecha actual.");
                return false;
            }
            else return true;
        }

        //Validacion longitud de Username y Password
        public static bool validarUsername(string username)
        {
            if (username.Length < 5) return false;
            else return true;
        }
        public static bool validarPassword(string password)
        {
            if (password.Length < 6) return false;
            else return true;
        }

        //Validacion username ya existe en base de datos
        public static bool validacionUsernameYaExiste(SqlConnection conn, string username)
        {
            SqlCommand comandoUsername = new SqlCommand(string.Format("SELECT COUNT(*) FROM LOS_OPTIMISTAS.Usuario WHERE Id_Usuario = @username"), conn);
            comandoUsername.Parameters.AddWithValue("@username", username);
            Int32 counts = (Int32)comandoUsername.ExecuteScalar();
            if (counts != 0)
            {
                MessageBox.Show("El usuario ingresado ya existe, por favor valide los datos");
                return false;
            }
            else return true;
        }
    }
}
