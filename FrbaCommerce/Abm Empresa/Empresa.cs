using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace FrbaCommerce.Abm_Empresa
{
    class Empresa
    {
        //**********************************************************
        //*  GUARDAR DATOS DE EMPRESA EN BASE DE DATOS
        //**********************************************************

        //TODO modificar en cuanto se tenga la ciudad en la base de datos
        public static void crearEmpresa(string razonSocial, string cuit, string nombreContacto, string telefono, string calle, string nroCalle, string piso, string depto, string codP, string localidad, string ciudad, string diaN, string mesN, string anioN, string mail, string username, string password)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoCrearEmpresa;
            command.Parameters.AddWithValue("@p_Razon_Social", razonSocial);
            command.Parameters.AddWithValue("@p_Cuit ", cuit);
            command.Parameters.AddWithValue("@p_Nombre_Contacto", nombreContacto);
            command.Parameters.AddWithValue("@p_Fecha_Creacion", Procedimientos.convertirFecha(diaN, mesN, anioN));
            command.Parameters.AddWithValue("@p_Domicilio", calle);
            command.Parameters.AddWithValue("@p_Telefono", telefono);
            command.Parameters.AddWithValue("@p_CP", codP);
            command.Parameters.AddWithValue("@p_Mail", mail);
            command.Parameters.AddWithValue("@p_Localidad", localidad);
            //command.Parameters.AddWithValue("@p_Ciudad", ciudad);
            command.Parameters.AddWithValue("@p_Calle", nroCalle);
            command.Parameters.AddWithValue("@p_Piso", piso);
            command.Parameters.AddWithValue("@p_Depto", depto);
            command.Parameters.AddWithValue("@p_Id_Usuario", username);
            command.Parameters.AddWithValue("@p_Password", Login.FormLogin.getSha256(password));
            Procedimientos.ejecutarStoredProcedure(command, "Creación de Empresa", true);
        }

        //**********************************************************
        //*  MODIFICAR DATOS DE EMPRESA
        //**********************************************************

        //TODO modificar en cuanto se tenga la ciudad en la base de datos
        public static void modificar(string razonSocial, string cuit, string nombreContacto, string telefono, string calle, string nroCalle, string piso, string depto, string codP, string localidad, string ciudad, string diaN, string mesN, string anioN, string mail, string password, string username)
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
            if (diaN != "" & mesN != "" & anioN != "")
            {
                command.Parameters.AddWithValue("@p_Fecha_Creacion", Procedimientos.convertirFecha(diaN, mesN, anioN));
            }
            command.Parameters.AddWithValue("@p_Depto", depto);
            command.Parameters.AddWithValue("@p_CP", codP);
            command.Parameters.AddWithValue("@p_Localidad", localidad);
            //command.Parameters.AddWithValue("@p_Ciudad", ciudad);
            command.Parameters.AddWithValue("@p_Mail", mail);
            command.Parameters.AddWithValue("@p_Password", Login.FormLogin.getSha256(password));
            command.Parameters.AddWithValue("@p_Id_Usuario", username);
            Procedimientos.ejecutarStoredProcedure(command, "Modificación de empresa", true);
        }

        //**********************************************************
        //*  ELIMINAR EMPRESA
        //**********************************************************

        public static void eliminar(string idUsuario)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Constantes.procedimientoBajaUsuario;
            command.Parameters.AddWithValue("@p_Id_Usuario", idUsuario);
            Procedimientos.ejecutarStoredProcedure(command, "Eliminación de empresa", true);
        }

        //**********************************************************
        //*  VALIDACION DE DATOS PARA EL REGISTRO DE NUEVA EMPRESA
        //**********************************************************

        //TODO ver tema de username y password
        public static void validarCamposCreacion(TextBox razonSocial, TextBox cuit, TextBox nombreContacto, TextBox telefono, TextBox calle, TextBox nroCalle, TextBox piso, TextBox depto, TextBox codP, TextBox localidad, TextBox ciudad, TextBox diaN, TextBox mesN, TextBox anioN, TextBox mail, string username, string password)
        {
            
            //Validación todos los campos obligatorios están completos
            razonSocial.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            cuit.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            nombreContacto.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            calle.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            nroCalle.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            //piso.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            //depto.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            codP.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            localidad.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            ciudad.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            diaN.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            mesN.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            anioN.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            mail.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);

            //Validaciones de tipos de datos correctos
            cuit.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //calle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            nroCalle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //piso.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //codP.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            localidad.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            ciudad.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            diaN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            mesN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            anioN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            mail.Validating += new CancelEventHandler(Validaciones.validarCampoMail_Validating);
            Validaciones.validarFecha(diaN, mesN, anioN);
            telefono.Validating += new CancelEventHandler(Validaciones.validarUnicidadTelefono_Validating);
            razonSocial.Validating += new CancelEventHandler(Validaciones.validarUnicidadRazonSocial_Validating);
            cuit.Validating += new CancelEventHandler(Validaciones.validarUnicidadCuit_Validating);
          
            //Validacion username ya se encuentra en base de datos
            //TODO Si el username es autogenerado (lo inscribe el administrador) deberá autogenerarse nuevamente

           // if (!Validaciones.validacionUsernameYaExiste(conn, username)) return false;
        }


        //**********************************************************
        //*  VALIDACION DE DATOS PARA LA MODIFICACION DE UNA EMPRESA
        //**********************************************************

        public static bool validarCamposModificacion(TextBox razonSocial, TextBox cuit, TextBox nombreContacto, TextBox telefono, TextBox calle, TextBox nroCalle, TextBox piso, TextBox depto, TextBox codP, TextBox localidad, TextBox ciudad, TextBox diaN, TextBox mesN, TextBox anioN, TextBox mail, TextBox password)
        {

            if (razonSocial.Text == "" & cuit.Text == "" & nombreContacto.Text == "" & telefono.Text == "" & calle.Text == "" & nroCalle.Text == "" & piso.Text == "" & depto.Text == "" & codP.Text == "" & localidad.Text == "" & ciudad.Text == "" & diaN.Text == "" & mesN.Text == "" & anioN.Text == "" & mail.Text == "" & password.Text == "")
            {
                MessageBox.Show("No se ha modificado ningún dato", "Modificación de Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //Validaciones de tipos de datos correctos
            cuit.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //calle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            nroCalle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //piso.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //codP.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            localidad.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            ciudad.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            diaN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            mesN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            anioN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            mail.Validating += new CancelEventHandler(Validaciones.validarCampoMail_Validating);

            //Validaciones de unicidad (teléfono, razón social, cuit)
            telefono.Validating += new CancelEventHandler(Validaciones.validarUnicidadTelefono_Validating);
            razonSocial.Validating += new CancelEventHandler(Validaciones.validarUnicidadRazonSocial_Validating);
            cuit.Validating += new CancelEventHandler(Validaciones.validarUnicidadCuit_Validating);

            if (diaN.Text != "" || mesN.Text != "" || anioN.Text != "")
            {
                Validaciones.validarFecha(diaN, mesN, anioN);
            }

            if (password.Text != "")
            {
                password.Validating += new CancelEventHandler(Validaciones.validarPassword_Validating);
            }
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
                command.Parameters.AddWithValue("@p_Cuit", cuit);

            if (mail == string.Empty)
                command.Parameters.AddWithValue("@p_Email", null);
            else
                command.Parameters.AddWithValue("@p_Email", mail);

            Procedimientos.llenarDataGridView(command, dgvEmpresa, "DataGridView Empresa");
        }
    }
}
