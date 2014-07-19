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
            command.Parameters.AddWithValue("@p_Password", Login.FormLogin.getSha256(password));
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
            command.Parameters.AddWithValue("@p_Password", Login.FormLogin.getSha256(password));
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

        public static bool validarCamposCreacion(TextBox nombre, TextBox apellido, TextBox calle, TextBox nroCalle, TextBox pisoCalle, TextBox deptoCalle, TextBox diaN, TextBox mesN, TextBox anioN, TextBox telefono, ComboBox tipoDoc, TextBox nDoc, TextBox codP, TextBox localidad, TextBox mail, string username, string password)
        {
            //Validación todos los campos obligatorios están completos
            nombre.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            apellido.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            calle.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            nroCalle.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            diaN.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            mesN.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            anioN.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            tipoDoc.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            nDoc.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            codP.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            localidad.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);
            mail.Validating += new CancelEventHandler(Validaciones.validarCampoObligatorio_Validating);

            //Validaciones de tipos de datos correctos
            nombre.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            apellido.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            //calle.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            nroCalle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //pisoCalle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //deptoCalle.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            diaN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            mesN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            anioN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            tipoDoc.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            nDoc.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //textCodP.Validating += new CancelEventHandler(Validaciones.ValidarCampoNumerico_Validating);
            localidad.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            mail.Validating += new CancelEventHandler(Validaciones.validarCampoMail_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarUnicidadTelefono_Validating);
            Validaciones.validarFecha(diaN, mesN, anioN);

            //Validación documento ya se encuentra en la base de datos
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand comm = new SqlCommand(string.Format("SELECT COUNT(*) FROM LOS_OPTIMISTAS.Cliente WHERE Dni = @nDoc AND Id_Tipo_Documento = @tipoDoc"), conn);
            comm.Parameters.AddWithValue("@nDoc", nDoc.Text);
            comm.Parameters.AddWithValue("@tipoDoc", tipoDoc.Text);
            Int32 count = (Int32)comm.ExecuteScalar();
            conn.Close();
            if (count != 0)
            {
                MessageBox.Show("El documento ingresado ya existe, por favor valide los datos");
                return false;
            }
            else return true;
        }

        //**********************************************************
        //*  VALIDACION DE DATOS PARA LA MODIFICACION DE UN CLIENTE
        //**********************************************************

        public static bool validarCamposModificacion(TextBox nombre, TextBox apellido, TextBox calle, TextBox nroCalle, TextBox pisoCalle, TextBox deptoCalle, TextBox diaN, TextBox mesN, TextBox anioN, TextBox telefono, ComboBox tipoDoc, TextBox nDoc, TextBox codP, TextBox localidad, TextBox mail, TextBox password)
        {

            //Si no se completa ningún campo no se muestra cartel de modificación realizada correctamente
            if(nombre.Text == "" &  apellido.Text == "" & calle.Text == "" & nroCalle.Text == "" & pisoCalle.Text == "" & deptoCalle.Text == "" & diaN.Text == "" & mesN.Text == "" & anioN.Text == "" & telefono.Text == "" & tipoDoc.Text == "" & nDoc.Text == "" & codP.Text == "" & localidad.Text == "" & mail.Text == "" & password.Text == "")
            {
                MessageBox.Show("No se ha modificado ningún dato", "Modificación de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //Validaciones de tipos de datos correctos
            nombre.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            apellido.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            //calle.Validating += new CancelEventHandler(Validaciones.ValidarCampoSoloLetras_Validating);
            //nroCalle.Validating += new CancelEventHandler(Validaciones.ValidarCampoNumerico_Validating);
            //pisoCalle.Validating += new CancelEventHandler(Validaciones.ValidarCampoNumerico_Validating);
            //deptoCalle.Validating += new CancelEventHandler(Validaciones.ValidarCampoNumerico_Validating);
            diaN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            mesN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            anioN.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            telefono.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            tipoDoc.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            nDoc.Validating += new CancelEventHandler(Validaciones.validarCampoNumerico_Validating);
            //textCodP.Validating += new CancelEventHandler(Validaciones.ValidarCampoNumerico_Validating);
            localidad.Validating += new CancelEventHandler(Validaciones.validarCampoSoloLetras_Validating);
            mail.Validating += new CancelEventHandler(Validaciones.validarCampoMail_Validating);

            if (diaN.Text != "" || mesN.Text != "" || anioN.Text != "")
            {
                Validaciones.validarFecha(diaN, mesN, anioN);
            }

            if (password.Text != "")
            {
                password.Validating += new CancelEventHandler(Validaciones.validarPassword_Validating);
            }

            //Validacion teléfono ya se encuentra en la base de datos
            telefono.Validating += new CancelEventHandler(Validaciones.validarUnicidadTelefono_Validating);

            //Validacion numero y tipo de documento ya se encuentran en la base de datos
            SqlConnection conn = Procedimientos.abrirConexion();
            if (nDoc.Text != "" || tipoDoc.Text != "")
            {
                SqlCommand comm = new SqlCommand(string.Format("SELECT COUNT(*) FROM LOS_OPTIMISTAS.Cliente WHERE Dni = @nDoc AND Id_Tipo_Documento = @tipoDoc"), conn);
                comm.Parameters.AddWithValue("@nDoc", nDoc.Text);
                comm.Parameters.AddWithValue("@tipoDoc", tipoDoc.Text);
                Int32 count = (Int32)comm.ExecuteScalar();
                if (count != 0)
                {
                    MessageBox.Show("El documento ingresado ya existe, por favor valide los datos");
                    return false;
                }
            }
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
