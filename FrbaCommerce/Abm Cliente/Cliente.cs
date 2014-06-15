using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace FrbaCommerce.Abm_Cliente
{
    class Cliente
    {

        //**********************************************************
        //*  GUARDAR DATOS DE CLIENTE EN BASE DE DATOS
        //**********************************************************

        public static void crear(string nombre, string apellido, string calle, string nroCalle, string pisoCalle, string deptoCalle, string diaN, string mesN, string anioN, string telefono, string tipoDoc, string nDoc, string codP, string localidad, string mail, string username, string password)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoCrearCliente;
            command.Parameters.AddWithValue("@p_Nombre", nombre);
            command.Parameters.AddWithValue("@p_Apellido", apellido);
            command.Parameters.AddWithValue("@p_Tipo_Documento", tipoDoc);
            command.Parameters.AddWithValue("@p_Numero_Documento", nDoc);
            command.Parameters.AddWithValue("@p_Mail", mail);
            command.Parameters.AddWithValue("@p_Telefono", telefono);
            command.Parameters.AddWithValue("@p_Domicilio_Calle", calle);
            command.Parameters.AddWithValue("@p_Nro_Calle", nroCalle);
            command.Parameters.AddWithValue("@p_Piso", pisoCalle);
            command.Parameters.AddWithValue("@p_Depto", deptoCalle);
            command.Parameters.AddWithValue("@p_Localidad", localidad);
            command.Parameters.AddWithValue("@p_CP", codP);
            command.Parameters.AddWithValue("@p_Fecha_Nacimiento", Procedimientos.convertirFecha(diaN, mesN, anioN));
            command.Parameters.AddWithValue("@p_Id_Usuario", username);
            command.Parameters.AddWithValue("@p_Password", password);
            //command.Parameters.AddWithValue("@p_Ultima_Fecha", diaYhora);
            Procedimientos.ejecutarStoredProcedure(command, "Creación de cliente", true);
        }

        //**********************************************************
        //*  MODIFICAR DATOS DE CLIENTE
        //**********************************************************

        public static void modificar(string nombre, string apellido, string domicilio, string nroCalle, string pisoCalle, string deptoCalle, string diaN, string mesN, string anioN, string telefono, string tipoDoc, string nDoc, string codP, string localidad, string mail, string password, string usuario)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoModificarCliente;
            command.Parameters.AddWithValue("@p_Nombre", nombre);
            command.Parameters.AddWithValue("@p_Apellido", apellido);
            command.Parameters.AddWithValue("@p_Tipo_Documento", tipoDoc);
            command.Parameters.AddWithValue("@p_Numero_Documento", nDoc);
            command.Parameters.AddWithValue("@p_Mail", mail);
            command.Parameters.AddWithValue("@p_Telefono", telefono);
            command.Parameters.AddWithValue("@p_Domicilio_Calle", domicilio);
            command.Parameters.AddWithValue("@p_Nro_Calle", nroCalle);
            command.Parameters.AddWithValue("@p_Piso", pisoCalle);
            command.Parameters.AddWithValue("@p_Depto", deptoCalle);
            command.Parameters.AddWithValue("@p_Cp", codP);
            command.Parameters.AddWithValue("@p_Localidad", localidad);
            command.Parameters.AddWithValue("@p_Password", password);
            command.Parameters.AddWithValue("@p_Id_Usuario", usuario);

            if (diaN != "" & mesN != "" & anioN != "")
            {
                command.Parameters.AddWithValue("@p_Fecha_Nacimiento", Procedimientos.convertirFecha(diaN, mesN, anioN));
            }
            else command.Parameters.AddWithValue("@p_Fecha_Nacimiento", "");
    
            Procedimientos.ejecutarStoredProcedure(command, "Modificación de cliente", true);
        }

        //**********************************************************
        //*  ELIMINAR CLIENTE
        //**********************************************************

        public static void eliminar(string idUsuario)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoBajaUsuario;
            command.Parameters.AddWithValue("@p_Id_Usuario", idUsuario);
            Procedimientos.ejecutarStoredProcedure(command, "Eliminación de cliente", true);
        }

        //**********************************************************
        //*  VALIDACION DE DATOS PARA EL REGISTRO DE NUEVO CLIENTE
        //**********************************************************

        public static bool validarCampos(string nombre, string apellido, string calle, string nroCalle, string pisoCalle, string deptoCalle, string diaN, string mesN, string anioN, string telefono, string tipoDoc, string nDoc, string codP, string localidad, string mail, string username, string password)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            
            //Validacion de datos completados
            if (nombre == "" || apellido == "" || calle == "" || nroCalle == "" || diaN == "" || mesN == "" || anioN == "" || telefono == "" || nDoc == "" || codP == "" || localidad == "" || mail == "")
            {
                MessageBox.Show("Debe completar todos los campos para poder continuar con el registro");
                return false;
            }

            //Validacion de tipos de datos numéricos correctos
            if (Validaciones.validarNumero(diaN) == false)
            {
                MessageBox.Show("Verifique el día en la fecha de Nacimiento");
                return false;
            }

            if (Validaciones.validarNumero(mesN) == false)
            {
                MessageBox.Show("Verifique el mes en la fecha de Nacimiento");
                return false;
            }

            if (Validaciones.validarNumero(anioN) == false)
            {
                MessageBox.Show("Verifique el año en la fecha de Nacimiento");
                return false;
            }

            if (Validaciones.validarNumero(pisoCalle) == false)
            {
                MessageBox.Show("Verifique el piso de su domicilio ingresado");
                return false;
            }

            if (Validaciones.validarNumero(nDoc) == false)
            {
                MessageBox.Show("Verifique el número de documento ingresado");
                return false;
            }

            if (Validaciones.validarNumero(telefono) == false)
            {
                MessageBox.Show("Verifique el teléfono ingresado");
                return false;
            }

            //Validacion de tipos de datos cadena correctos
            if (Validaciones.validarString(nombre) == false)
            {
                MessageBox.Show("Verifique el nombre ingresado");
                return false;
            }

            if (Validaciones.validarString(apellido) == false)
            {
                MessageBox.Show("Verifique el apellido ingresado");
                return false;
            }

            if (Validaciones.validarString(localidad) == false)
            {
                MessageBox.Show("Verifique la localidad ingresada");
                return false;
            }

            //Validacion de formato de mail correcto
            if (Validaciones.validarMail(mail) == false)
            {
                MessageBox.Show("Por favor verifique el mail ingresado");
                return false;
            }

            //Validacion formato de fecha de nacimiento correcto
            if (Validaciones.validarFechaNacimiento(diaN, mesN, anioN) == false)
            {
                MessageBox.Show("Por favor verifique la fecha de nacimiento ingresada");
                return false;
            }

            //Validacion longitud de Username y Password
            if (Validaciones.validarUsername(username) == false)
            {
                MessageBox.Show("El nombre de usuario debe contener al menos 5 caracteres");
                return false;
            }

            if (Validaciones.validarPassword(password) == false)
            {
                MessageBox.Show("La contraseña debe contener al menos 6 caracteres");
                return false;
            }

            //Validacion telefono ya se encuentra en base de datos
            Boolean unicoTelefono = Procedimientos.esUnico("LOS_OPTIMISTAS.Dom_Mail", "Telefono", telefono);
            if (unicoTelefono == false)
            {
                MessageBox.Show("El número de teléfono ingresado ya existe, por favor valide los datos");
                return false;
            }

            //Validacion numero y tipo de documento ya se encuentran en la base de datos
            SqlCommand comm = new SqlCommand(string.Format("SELECT COUNT(*) FROM LOS_OPTIMISTAS.Cliente WHERE Dni = @nDoc AND Id_Tipo_Documento = @tipoDoc"), conn);
            comm.Parameters.AddWithValue("@nDoc", nDoc);
            comm.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            Int32 count = (Int32)comm.ExecuteScalar();
            if (count != 0)
            {
                MessageBox.Show("El documento ingresado ya existe, por favor valide los datos");
                return false;
            }

            //Validacion username ya se encuentra en base de datos
            //TODO Si el username es autogenerado (lo inscribe el administrador) deberá autogenerarse nuevamente

            if (!Validaciones.validacionUsernameYaExiste(conn, username)) return false;

            conn.Close();
            return true;
        }

        //**********************************************************
        //*  CARGAR LA BUSQUEDA DE CLIENTE EN DATAGRIDVIEW
        //**********************************************************

        public static void buscar(string nombre, string apellido, string tipoDoc, string numDoc, string email, DataGridView dgvCliente)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.procedimientoMostrarClientes;

            if (nombre == string.Empty)
                command.Parameters.AddWithValue("@p_Nombre", null);
            else
                command.Parameters.AddWithValue("@p_Nombre", nombre);

            if (apellido == string.Empty)
                command.Parameters.AddWithValue("@p_Apellido", null);
            else
                command.Parameters.AddWithValue("@p_Apellido", apellido);

            if (tipoDoc == string.Empty)
                command.Parameters.AddWithValue("@p_Tipo_Documento", null);
            else
                command.Parameters.AddWithValue("@p_Tipo_Documento", tipoDoc);

            if (numDoc == string.Empty)
                command.Parameters.AddWithValue("@p_Numero_Documento", null);
            else
                command.Parameters.AddWithValue("@p_Numero_Documento", numDoc);

            if (email == string.Empty)
                command.Parameters.AddWithValue("@p_Mail", null);
            else
                command.Parameters.AddWithValue("@p_Mail", email);

            Procedimientos.llenarDataGridView(command, dgvCliente, "DataGridView Cliente");
        }
    }
}
