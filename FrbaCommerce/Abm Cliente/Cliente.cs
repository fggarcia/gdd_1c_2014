using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    class Cliente
    {
        //**********************************************************
        //*  GUARDAR DATOS DE CLIENTE EN BASE DE DATOS
        //**********************************************************

        //TODO ver como se va a llamar la tabla de Clientes y sus datos
        //TODO ver como se va a llamar la tabla Dom_Mail y sus datos
        //TODO ver formato de Dni, Telefono, Codigo_Postal,  Int32??
        //TODO ver como guardar el domicilio
        public static int crearCliente(string nombre, string apellido, string calle, string depto, string piso, string diaN, string mesN, string anioN, string telefono, string tipoDoc, string nDoc, string codP, string localidad, string mail, string username, string password)
        {
            int resultado = 1;
            DateTime fechaNac = new DateTime(Convert.ToInt32(anioN), Convert.ToInt32(mesN), Convert.ToInt32(diaN));
            SqlConnection conn = BaseDeDatos.abrirConexion();
            SqlCommand comandoUsuario = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Usuario (Id_Usuario, Password, Cantidad_Login) values ('{0}', '{1}', '{2}')", username, password, 0), conn);
            SqlCommand comandoCliente = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Cliente (Tipo_Documento, Dni, Id_Usuario, Nombre, Apellido, Fecha_Nacimiento) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", tipoDoc, Convert.ToInt32(nDoc), username, nombre, apellido, fechaNac), conn);
            SqlCommand comandoDomMail = new SqlCommand(string.Format("Insert into LOS_OPTIMISTAS.Dom_Mail (Id_Usuario, Domicilio, Telefono, Codigo_Postal, Mail, Localidad) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", username, calle + piso + depto, Convert.ToInt32(telefono), Convert.ToInt32(codP), mail, localidad), conn);
            comandoUsuario.ExecuteNonQuery();
            comandoCliente.ExecuteNonQuery();
            comandoDomMail.ExecuteNonQuery();
            conn.Close();
            return resultado;
        }

        //**********************************************************
        //*  VALIDACION DE DATOS PARA EL REGISTRO DE NUEVO CLIENTE
        //**********************************************************

        public static bool validarCampos(string nombre, string apellido, string calle, string diaN, string mesN, string anioN, string telefono, string tipoDoc, string nDoc, string codP, string localidad, string mail, string username, string password){
            
            //Validacion de datos completados
            if (nombre == "" || apellido == "" ||calle == "" ||diaN == "" ||mesN == "" ||anioN == "" ||telefono == "" ||nDoc == "" ||codP == "" ||localidad == "" ||mail == "")
            {
                MessageBox.Show("Debe completar todos los campos para poder continuar con el registro");
                return false;
            }

            //Validacion de formato de mail correcto
            if (mail != "")
            {
                Regex objValidMail = new Regex(@"(@)(\w)+(\.)([\w])+$");
                if (!objValidMail.IsMatch(mail))
                {
                    MessageBox.Show("El formato del mail es incorrecto");
                    return false;
                }
            }

            //Validacion formato de fecha de nacimiento correcto

            if (Convert.ToInt32(diaN) < 1 || Convert.ToInt32(diaN) > 31)
            {
                MessageBox.Show("Los siguientes campos de la Fecha de Nacimiento son erroneos: Día");
                return false;
            }
            if (Convert.ToInt32(mesN) < 1 || Convert.ToInt32(mesN) > 12)
            {
                MessageBox.Show("Los siguientes campos de la Fecha de Nacimiento son erroneos: Mes");
                return false;
            }
            if (Convert.ToInt32(anioN) < 1900 || Convert.ToInt32(anioN) > 2014)
            {
                MessageBox.Show("Los siguientes campos de la Fecha de Nacimiento son erroneos: Año");
                return false;
            }

            DateTime fechaNac = new DateTime(Convert.ToInt32(anioN), Convert.ToInt32(mesN), Convert.ToInt32(diaN));
            if (fechaNac > Variables.FechaHoraSistema)
            {
                MessageBox.Show("La Fecha de Nacimiento debe ser menor a la fecha actual.");
                return false;
            }

            //Validacion telefono ya se encuentra en base de datos
            //TODO Chequear bien como se va a llamar la tabla que contiene el numero de telefono, ahora suponemos que se llama Dom_Mail
            //TODO telefono = Int32??
            SqlConnection conn = BaseDeDatos.abrirConexion();
            SqlCommand comandoTelefono = new SqlCommand(string.Format("Select Telefono from LOS_OPTIMISTAS.Dom_Mail where Telefono = {0}", Convert.ToInt32(telefono)), conn);
            SqlDataReader readerTelefono = comandoTelefono.ExecuteReader();
            if (readerTelefono.Read())
            {
                MessageBox.Show("El número de teléfono ingresado ya existe, por favor valide los datos");
                return false;
            }

            //Validacion numero y tipo de documento ya se encuentran en la base de datos
            //TODO Chequear bien como se van a llamar Tipo_Documento y Dni (se supone tabla Cliente)
            //TODO Dni = Int32??
            SqlCommand comandoDoc = new SqlCommand(string.Format("Select Tipo_Documento, Dni from LOS_OPTIMISTAS.Cliente where Tipo_Documento = {0} and Dni = {1}", tipoDoc, Convert.ToInt32(nDoc)), conn);
            SqlDataReader readerDoc = comandoDoc.ExecuteReader();
            if (readerDoc.Read())
            {
                MessageBox.Show("El número de documento ingresado ya existe, por favor valide los datos");
                return false;
            }

            //Validacion username ya se encuentra en base de datos
            //TODO Si el username es autogenerado (lo inscribe el administrador) deberá autogenerarse nuevamente
            SqlCommand comandoUsername = new SqlCommand(string.Format("Select Id_Usuario from LOS_OPTIMISTAS.Usuario where Id_Usuario = {0}", username), conn);
            SqlDataReader readerUsername = comandoUsername.ExecuteReader();
            if (readerUsername.Read())
            {
                MessageBox.Show("El nombre de usuario ingresado ya existe, por favor ingrese otro nombre de usuario");
                return false;
            }

            conn.Close();
            return true;
        }
    }
}
