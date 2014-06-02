using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using FrbaCommerce.Properties;
using System.Data;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public class Procedimientos
    {

        //**********************************************************
        //*                 ABRIR Y CERRAR CONEXIÓN
        //**********************************************************

        //Obtener String de la conexion del archivo config
        public static string obtenerString()
        {
            return Settings.Default.connectionString;
        }

        //Abrir conexion
        public static SqlConnection abrirConexion()
        {
            SqlConnection conn = new SqlConnection(obtenerString());
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return conn;
        }

        //Cerrar conexion
        public static void cerrarConexion(SqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //**********************************************************
        //*         PROCEDIMIENTO PARA LLENAR COMBOBOX
        //**********************************************************
        
        public static void LlenarComboBox(ComboBox comboBox, String dataSource, String valueMember, String displayMember, String whereMember, String orderMember)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(String.Format("SELECT {0} 'Value',{1} AS 'Display' FROM {2} {3} {4}", valueMember, displayMember, dataSource, String.IsNullOrEmpty(whereMember) ? "" : "WHERE " + whereMember, String.IsNullOrEmpty(orderMember) ? "" : "ORDER BY " + orderMember), conn);
            dataAdapter.Fill(dataSet, dataSource);
            DataRow row = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            comboBox.DataSource = dataSet.Tables[0].DefaultView;
            comboBox.ValueMember = "Value";
            comboBox.DisplayMember = "Display";
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Text = "(Seleccione una Opcion)";
         }
        

        //*************************************************************************
        //*    PROCEDIMIENTO PARA VALIDAR SI UN REGISTRO YA SE ENCUENTRA EN LA BD
        //****************************************************************************
        
        public static Boolean esUnico(String nombreTabla, String nombreCampo, String nombreTextBox)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand comm = new SqlCommand(string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}'", nombreTabla, nombreCampo, nombreTextBox), conn);
            comm.Parameters.AddWithValue("@nombreTextBox", nombreTextBox);
            Int32 count = (Int32)comm.ExecuteScalar();
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //*************************************************
        //*    PROCEDIMIENTO PARA LLENAR UN DATAGRIDVIEW
        //*************************************************
        
        public static void llenarDataGridView(SqlCommand command, DataGridView dataGridView, String operacion)
        {
            SqlConnection conn = abrirConexion();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;
            
            // Seteo las propiedades del DGV
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;

            // Pongo todas las columnas en Read Only salvo las de checkbox porque si no, no se pueden checkear
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (!column.Name.Equals("checkbox") && !column.Name.Equals("chk"))
                    column.ReadOnly = true;
            }
            cerrarConexion(conn);
          }

       //*******************************************************
        //*    PROCEDIMIENTO PARA EJECUTAR UN STORED PROCEDURE
        //******************************************************

        public static int ejecutarStoredProcedure(SqlCommand command, String operacion, Boolean muestraMensaje)
        {
            int filasAfectadas = -1;
            int identity = -1;
            SqlConnection conn = abrirConexion();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            filasAfectadas = command.ExecuteNonQuery();

            if (filasAfectadas > 0)
            {
                // Recupero el ID con el que se genero
                string sqlIdentity = "SELECT @@IDENTITY";
                using (SqlCommand cmdIdentity = new SqlCommand(sqlIdentity, conn))
                {
                    if (cmdIdentity.ExecuteScalar() is DBNull)
                    { }
                    else
                        identity = Convert.ToInt32(cmdIdentity.ExecuteScalar());
                }
            }
            if (muestraMensaje.Equals(true))
                MessageBox.Show(operacion + " realizada satisfactoriamente", operacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            cerrarConexion(conn);
            return identity;
        }

        //*************************************************************************
        //*    PROCEDIMIENTO PARA OBTENER UN DATO A PARTIR DEL ID_USUARIO
        //****************************************************************************

        public static string obtenerDato(String nombreTabla, String datoAobtener, String idUsuario)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            SqlCommand command = new SqlCommand(string.Format("SELECT '{0}' FROM '{1}' WHERE Id_Usuario = '{2}'", datoAobtener, nombreTabla, idUsuario), conn);
            return command.CommandText;
        }

        public static void limpiarTextBoxes(Control parent)
        {
            TextBox t;
            foreach (Control c in parent.Controls)
            {
                t = c as TextBox;
                if (t != null)
                {
                    t.Clear();
                }
                if (c.Controls.Count > 0)
                {
                    limpiarTextBoxes(c);
                }
            }
        }

        public static void limpiarComboBoxes(Control parent)
        {
            ComboBox t;
            foreach (Control c in parent.Controls)
            {
                t = c as ComboBox;
                if (t != null)
                {
                    t.SelectedIndex = -1;
                }
                if (c.Controls.Count > 0)
                {
                    limpiarComboBoxes(c);
                }
            }
        }

        public static string convertirFecha(string dia, string mes, string anio)
        {
            DateTime fecha = new DateTime(Convert.ToInt32(dia), Convert.ToInt32(mes), Convert.ToInt32(anio), 00, 00, 00);
            return fecha.ToString("yyyy-MM-dd HH:mm:ss");
        }

     }
}
