using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace FrbaCommerce.Abm_Empresa
{
    class Empresa
    {
        //**********************************************************
        //*  GUARDAR DATOS DE EMPRESA EN BASE DE DATOS
        //**********************************************************

        public static void crearEmpresa(string razonSocial, string cuit, string nombreContacto, string telefono, string calle, string nroCalle, string piso, string depto, string codP, string localidad, string ciudad, string diaN, string mesN, string anioN, string mail, string username, string password)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoCrearEmpresa;
            command.Parameters.AddWithValue("@p_Razon_Social", razonSocial);
            command.Parameters.AddWithValue("@p_Cuit ", cuit);
            command.Parameters.AddWithValue("@p_Fecha_Creacion", Procedimientos.convertirFecha(diaN, mesN, anioN));
            command.Parameters.AddWithValue("@p_Domicilio", calle);
            command.Parameters.AddWithValue("@p_Telefono", telefono);
            command.Parameters.AddWithValue("@p_CP", codP);
            command.Parameters.AddWithValue("@p_Mail", mail);
            command.Parameters.AddWithValue("@p_Localidad", localidad);
            command.Parameters.AddWithValue("@p_Calle", nroCalle);
            command.Parameters.AddWithValue("@p_Piso", piso);
            command.Parameters.AddWithValue("@p_Depto", depto);
            command.Parameters.AddWithValue("@p_Id_Usuario", username);
            command.Parameters.AddWithValue("@p_Password", password);
            Procedimientos.ejecutarStoredProcedure(command, "Creación de Empresa", true);
        }

        //**********************************************************
        //*  MODIFICAR DATOS DE EMPRESA
        //**********************************************************

        public static void modificarEmpresa(string razonSocial, string cuit, string nombreContacto, string telefono, string calle, string nroCalle, string piso, string depto, string codP, string localidad, string ciudad, string diaN, string mesN, string anioN, string mail, string password)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoModificarEmpresa;
            command.Parameters.AddWithValue("@p_Razon_Social", razonSocial);
            command.Parameters.AddWithValue("@p_Cuit", cuit);
            command.Parameters.AddWithValue("@p_Nombre_Contacto", nombreContacto);
            command.Parameters.AddWithValue("@p_Telefono", telefono);
            command.Parameters.AddWithValue("@p_Domicilio", calle);
            command.Parameters.AddWithValue("@p_Calle", nroCalle);
            command.Parameters.AddWithValue("@p_Piso", piso);
            command.Parameters.AddWithValue("@p_Fecha_Creacion", Procedimientos.convertirFecha(diaN, mesN, anioN));
            command.Parameters.AddWithValue("@p_Depto", depto);
            command.Parameters.AddWithValue("@p_CP", codP);
            command.Parameters.AddWithValue("@p_Localidad", localidad);
            command.Parameters.AddWithValue("@p_Ciudad", ciudad);
            command.Parameters.AddWithValue("@p_Mail", mail);
            command.Parameters.AddWithValue("@p_Password", password);
            Procedimientos.ejecutarStoredProcedure(command, "Modificación de empresa", true);
        }

        //**********************************************************
        //*  ELIMINAR EMPRESA
        //**********************************************************

        public static void eliminarEmpresa(string idUsuario)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoBajaUsuario;
            command.Parameters.AddWithValue("@p_Id_Usuario", idUsuario);
            Procedimientos.ejecutarStoredProcedure(command, "Eliminación de empresa", true);
        }

        //**********************************************************
        //*  VALIDACION DE DATOS PARA EL REGISTRO DE NUEVA EMPRESA
        //**********************************************************
        
        public static bool validarCampos(string razonSocial, string cuit, string nombreContacto, string telefono, string calle, string nroCalle, string piso, string depto, string codP, string localidad, string ciudad, string diaN, string mesN, string anioN, string mail, string username, string password)
        {
            SqlConnection conn = Procedimientos.abrirConexion();

            //Validacion de datos completados
            if (razonSocial == "" || cuit == "" || nombreContacto == "" || telefono == "" || calle == "" || nroCalle == "" || piso == "" || depto == "" || codP == "" || localidad == "" || ciudad == "" || codP == "" || diaN == "" || mesN == "" || anioN == "" || mail == "")
            {
                MessageBox.Show("Debe completar todos los campos para poder continuar con el registro");
                return false;
            }

            //Validacion de tipos de datos numéricos correctos
            if (Validaciones.validarNumero(diaN) == false)
            {
                MessageBox.Show("Verifique el día en la fecha de Creacion");
                return false;
            }

            if (Validaciones.validarNumero(mesN) == false)
            {
                MessageBox.Show("Verifique el mes en la fecha de Creacion");
                return false;
            }

            if (Validaciones.validarNumero(anioN) == false)
            {
                MessageBox.Show("Verifique el año en la fecha de Creacion");
                return false;
            }

            if (Validaciones.validarNumero(piso) == false)
            {
                MessageBox.Show("Verifique el piso de su domicilio ingresado");
                return false;
            }

            if (Validaciones.validarNumero(cuit) == false)
            {
                MessageBox.Show("Verifique el CUIT ingresado");
                return false;
            }

            if (Validaciones.validarNumero(telefono) == false)
            {
                MessageBox.Show("Verifique el teléfono ingresado");
                return false;
            }

            //Validacion de tipos de datos cadena correctos
            if (Validaciones.validarString(nombreContacto) == false)
            {
                MessageBox.Show("Verifique el nombre ingresado");
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

            if (Validaciones.validarString(ciudad) == false)
            {
                MessageBox.Show("Verifique la ciudad ingresada");
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

            //Validacion cuit ya se encuentra en base de datos
            Boolean unicoCuit = Procedimientos.esUnico("LOS_OPTIMISTAS.Empresa", "Cuit", cuit);
            if (unicoCuit == false)
            {
                MessageBox.Show("El CUIT ingresado ya existe, por favor valide los datos");
                return false;
            }

            //Validacion razón social ya se encuentra en base de datos
            Boolean unicaRazonSocial = Procedimientos.esUnico("LOS_OPTIMISTAS.Empresa", "Razon_Social", razonSocial);
            if (unicaRazonSocial == false)
            {
                MessageBox.Show("La razón social ingresada ya existe, por favor valide los datos");
                return false;
            }

            //Validacion username ya se encuentra en base de datos
            //TODO Si el username es autogenerado (lo inscribe el administrador) deberá autogenerarse nuevamente

            if ( !Validaciones.validacionUsernameYaExiste(conn, username)) return false;

            conn.Close();
            return true;
        }

        //**********************************************************
        //*  CARGAR LA BUSQUEDA DE EMPRESA EN DATAGRIDVIEW
        //**********************************************************

        public static void buscar(string razonSocial, string cuit, string mail, DataGridView dgvEmpresa)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constantes.procedimientoMostrarEmpresas;

            if (razonSocial == string.Empty)
                command.Parameters.AddWithValue("@p_Razon_Social", null);
            else
                command.Parameters.AddWithValue("@p_Razon_Social", razonSocial);

            if (cuit == string.Empty)
                command.Parameters.AddWithValue("@p_Cuit", null);
            else
                command.Parameters.AddWithValue("@@p_Cuit", cuit);

            if (mail == string.Empty)
                command.Parameters.AddWithValue("@p_Email", null);
            else
                command.Parameters.AddWithValue("@p_Email", mail);

            Procedimientos.llenarDataGridView(command, dgvEmpresa, "DataGridView Empresa");
        }
    }
}
