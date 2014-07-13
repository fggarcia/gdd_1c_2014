using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;

namespace FrbaCommerce
{
    class Validaciones
    {
        static Dictionary<Control, ErrorProvider> dictionaryErrorProviders = new Dictionary<Control, ErrorProvider>();

        static public Boolean validar(Control cntr, Form parentForm)
        {
            Boolean isValid = true;

            foreach (Control c in cntr.Controls)
            {
                if (c is TabControl)
                    validar((TabControl)c, parentForm);
                else if (c is TabPage)
                    validar((TabPage)c, parentForm);
                else if (c is Panel)
                    validar((Panel)c, parentForm);
                else if (c is GroupBox)
                    validar((GroupBox)c, parentForm);

                c.Focus();
           
                if (!parentForm.Validate())
                    isValid = false;
            }
            return isValid;
        }

        static public void setearValidacion(Control cntr, Boolean valido)
        {
            foreach (Control c in cntr.Controls)
            {
                if (c is TabControl)
                    setearValidacion((TabControl)c, valido);
                else if (c is TabPage)
                    setearValidacion((TabPage)c, valido);
                else if (c is Panel)
                    setearValidacion((Panel)c, valido);
                else if (c is GroupBox)
                    setearValidacion((GroupBox)c, valido);

                c.CausesValidation = valido;
            }
        }

        public static ErrorProvider obtenerErrorProvider(Control control)
        {

            ErrorProvider nameErrorProvider;

            if (dictionaryErrorProviders.ContainsKey(control))
            {
                nameErrorProvider = dictionaryErrorProviders[control];
            }
            else
            {
                nameErrorProvider = new ErrorProvider();
                dictionaryErrorProviders.Add(control, nameErrorProvider);
                nameErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            }
            return nameErrorProvider;
        }

        //**********************************************************
        //*  VALIDACION DE DATOS OBLIGATORIOS COMPLETADOS
        //**********************************************************

        public static void validarCampoObligatorio_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                if (tb.Text.Equals(string.Empty))
                    isValid = false;
                else
                    isValid = true;
            }

            else if (sender is ComboBox)
            {
                ComboBox cb = (ComboBox)sender;

                if (cb.Text.Equals(string.Empty))
                    isValid = false;
                else
                    isValid = true;
            }

            else if (sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;

                if (dgv.Rows.Count.Equals(0))
                {
                    isValid = false;
                }
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "Es un campo obligatorio, por favor completar");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("Es un campo obligatorio, por favor completar")))
                    nameErrorProvider.SetError(control, "");
            }

        }

        public static void setearErrorProvider(Control control, CancelEventArgs e, ErrorProvider nameErrorProvider, String mensajeError, Boolean isValid)
        {
            if (isValid == false)
            {
                nameErrorProvider.SetError(control, mensajeError);
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals((mensajeError)))
                    nameErrorProvider.SetError(control, "");
            }
        }

        //**********************************************************
        //*  VALIDACION DE DATOS DE TIPO NUMÉRICOS
        //**********************************************************

        public static void validarCampoNumerico_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                if (!tb.Text.Equals(String.Empty))
                {

                    Int64 aux;
                    if (Int64.TryParse(tb.Text, out aux) || tb.Text.Equals(string.Empty))
                        isValid = true;
                    else
                        isValid = false;
                }
            }

            String mensajeError = "Solo se admiten valores numericos, sin signos especiales como '.' ',' o '-' por favor completar correctamente";

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, mensajeError);
                e.Cancel = true;
            }

            else
            {
                if (nameErrorProvider.GetError(control).Equals((mensajeError)))
                    nameErrorProvider.SetError(control, "");
            }
        }

        public static void validarCampoNumericoFlotante_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                if (!tb.Text.Equals(String.Empty))
                {

                    Double aux;
                    if (Double.TryParse(tb.Text, out aux) || tb.Text.Equals(string.Empty))
                        isValid = true;
                    else
                        isValid = false;
                }
            }

            String mensajeError = "Solo se admiten valores numericos, sin signos especiales como '.' ',' o '-' por favor completar correctamente";

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, mensajeError);
                e.Cancel = true;
            }

            else
            {
                if (nameErrorProvider.GetError(control).Equals((mensajeError)))
                    nameErrorProvider.SetError(control, "");
            }
        }

        //**********************************************************
        //*  VALIDACION DE FORMATO DE MAIL CORRECTO
        //**********************************************************

        public static void validarCampoMail_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                if (!tb.Text.Equals(String.Empty))
                {

                    Regex objValidMail = new Regex(@"(@)(\w)+(\.)([\w])+$");

                    if (objValidMail.IsMatch(tb.Text))
                        isValid = true;
                    else
                        isValid = false;
                }
            }

            String mensajeError = "No es un formato de mail valido, por favor completar correctamente";

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, mensajeError);
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals((mensajeError)))
                    nameErrorProvider.SetError(control, "");
            }
        }

        //**********************************************************
        //*  VALIDACION DE DATOS DE TIPO CADENA DE CARACTERES
        //**********************************************************

        public static void validarCampoSoloLetras_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                if (!tb.Text.Equals(String.Empty))
                {
                    Regex objValidLetters = new Regex(@"[^a-zA-Záéíóú\s]");

                    if (!objValidLetters.IsMatch(tb.Text))
                        isValid = true;
                    else
                        isValid = false;
                }
            }

            String mensajeError = "El campo solo debe contener letras, no puede contener numeros ni caracteres especiales, por favor completar correctamente";

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, mensajeError);
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals((mensajeError)))
                    nameErrorProvider.SetError(control, "");
            }
        }

        //**********************************************************
        //*  VALIDACION DE DATOS ÚNICOS
        //**********************************************************

        public static void validarUnicidadTelefono_Validating(object sender, CancelEventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn = Procedimientos.abrirConexion();

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                isValid = Procedimientos.esUnico("LOS_OPTIMISTAS.Dom_Mail", "Telefono", tb.Text);
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "El teléfono ingresado ya existe");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("El teléfono ingresado ya existe")))
                    nameErrorProvider.SetError(control, "");
            }

            Procedimientos.cerrarConexion(conn);
        }

        public static void validarUnicidadUsername_Validating(object sender, CancelEventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn = Procedimientos.abrirConexion();

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                isValid = Procedimientos.esUnico("LOS_OPTIMISTAS.Usuario", "Id_Usuario", tb.Text);
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "El nombre de usuario ingresado ya existe");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("El nombre de usuario ingresado ya existe")))
                    nameErrorProvider.SetError(control, "");
            }

            Procedimientos.cerrarConexion(conn);
        }

        public static void validarUnicidadRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn = Procedimientos.abrirConexion();

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                isValid = Procedimientos.esUnico("LOS_OPTIMISTAS.Empresa", "Razon_Social", tb.Text);
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "La razón social ingresada ya existe");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("La razón social ingresada ya existe")))
                    nameErrorProvider.SetError(control, "");
            }

            Procedimientos.cerrarConexion(conn);
        }

        public static void validarUnicidadCuit_Validating(object sender, CancelEventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn = Procedimientos.abrirConexion();

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            if (sender is TextBox)
            {

                TextBox tb = (TextBox)sender;

                isValid = Procedimientos.esUnico("LOS_OPTIMISTAS.Empresa", "Cuit", tb.Text);
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "El CUIT ingresado ya existe");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("El CUIT ingresado ya existe")))
                    nameErrorProvider.SetError(control, "");
            }

            Procedimientos.cerrarConexion(conn);
        }

        //**********************************************************
        //*  VALIDACION DE DATOS INGRESADOS
        //**********************************************************

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

        public static void validarDia_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;
            
            TextBox tb = (TextBox)sender;

            if (tb.Text == "")
            {
                nameErrorProvider.SetError(control, "Debe completar la fecha completa para poder continuar");
                e.Cancel = true;
            }

            else
            {
                if (nameErrorProvider.GetError(control).Equals(("Debe completar la fecha completa para poder continuar")))
                    nameErrorProvider.SetError(control, "");
                isValid = (Convert.ToInt32(tb.Text) >= 1 & Convert.ToInt32(tb.Text) <= 31);
            }
           
            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "El día debe ser un número del 1 al 31");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("El día debe ser un número del 1 al 31")))
                    nameErrorProvider.SetError(control, "");
            }

        }

        public static void validarMes_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            TextBox tb = (TextBox)sender;

            if (tb.Text == "")
            {
                nameErrorProvider.SetError(control, "Debe completar la fecha completa para poder continuar");
                e.Cancel = true;
            }

            else
            {
                if (nameErrorProvider.GetError(control).Equals(("Debe completar la fecha completa para poder continuar")))
                    nameErrorProvider.SetError(control, "");
                isValid = (Convert.ToInt32(tb.Text) >= 1 & Convert.ToInt32(tb.Text) <= 12);
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "El mes debe ser un número del 1 al 12");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("El mes debe ser un número del 1 al 12")))
                    nameErrorProvider.SetError(control, "");
            }

        }

        public static void validarAnio_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            TextBox tb = (TextBox)sender;

            if (tb.Text == "")
            {
                nameErrorProvider.SetError(control, "Debe completar la fecha completa para poder continuar");
                e.Cancel = true;
            }

            else
            {
                if (nameErrorProvider.GetError(control).Equals(("Debe completar la fecha completa para poder continuar")))
                nameErrorProvider.SetError(control, "");
                isValid = (Convert.ToInt32(tb.Text) >= 1900 & Convert.ToInt32(tb.Text) <= 2014);
            }

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "El año debe ser un número del 1900 al 2014");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("El año debe ser un número del 1900 al 2014")))
                    nameErrorProvider.SetError(control, "");
            }

        }

        public static void validarFecha(TextBox dia, TextBox mes, TextBox anio)
        {
            dia.Validating += new CancelEventHandler(Validaciones.validarDia_Validating);
            mes.Validating += new CancelEventHandler(Validaciones.validarMes_Validating);
            anio.Validating += new CancelEventHandler(Validaciones.validarAnio_Validating);
        }
        //Validacion formato de fecha correcto
        
        public static bool validarFechaC(string dia, string mes, string anio, string fecha)
        {
            if (Convert.ToInt32(dia) < 1 || Convert.ToInt32(dia) > 31)
            {
                MessageBox.Show(string.Format ("Verifique el día en la fecha de {0}", fecha));
                return false;
            }

            if (Convert.ToInt32(mes) < 1 || Convert.ToInt32(mes) > 12)
            {
                MessageBox.Show(string.Format("Verifique el mes en la fecha de {0}", fecha));
                return false;
            }

            if (Convert.ToInt32(anio) < 1900 || Convert.ToInt32(anio) > 2014)
            {
                MessageBox.Show(string.Format("Verifique el año en la fecha de {0}", fecha));
                
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

        public static void validarPassword_Validating(object sender, CancelEventArgs e)
        {

            Control control = (Control)sender;

            ErrorProvider nameErrorProvider = obtenerErrorProvider(control);

            Boolean isValid = true;

            TextBox tb = (TextBox)sender;

            isValid = (tb.Text.Length >= 6 & tb.Text.Length <= 10);

            if (isValid == false)
            {
                nameErrorProvider.SetError(control, "La contraseña debe ser de 6 a 10 caracteres");
                e.Cancel = true;
            }
            else
            {
                if (nameErrorProvider.GetError(control).Equals(("La contraseña debe ser de 6 a 10 caracteres")))
                    nameErrorProvider.SetError(control, "");
            }

        }

        public static bool validarPassword(string password)
        {
            if (password.Length < 6) return false;
            else return true;
        }

        //Validacion username ya existe en base de datos
        public static bool validacionUsernameYaExiste(SqlConnection conn, string username, bool mensaje)
        {
            SqlCommand comandoUsername = new SqlCommand(string.Format("SELECT COUNT(*) FROM LOS_OPTIMISTAS.Usuario WHERE Id_Usuario = @username"), conn);
            comandoUsername.Parameters.AddWithValue("@username", username);
            Int32 counts = (Int32)comandoUsername.ExecuteScalar();
            if (counts != 0)
            {
                if (mensaje)
                {
                    MessageBox.Show("El usuario ingresado ya existe, por favor valide los datos");
                }
                return true;
            }
            else return false;
        }
    }
}
