﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using FrbaCommerce.Properties;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace FrbaCommerce
{
    public class OpcionMenu
    {
        public int IdFuncionalidad { get; set; }
        public string DescripcionFuncionalidad { get; set; }
    }

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
        //*    PROCEDIMIENTO PARA LLENAR COMBOBOX CUOTAS
        //**********************************************************

        public static void LlenarComboBoxCuotas(ComboBox comboBox)
        {
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(1, "1");
            diccionario.Add(2, "3");
            diccionario.Add(3, "6");
            diccionario.Add(4, "12");
            diccionario.Add(5, "18");
            diccionario.Add(6, "24");
            comboBox.DataSource = new BindingSource(diccionario, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
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

        //**********************************************************
        //*         PROCEDIMIENTO PARA LLENAR COMBOBOX FROM STORE
        //**********************************************************

        public static void LlenarComboBoxDesdeProcedure(ComboBox comboBox, String dataSource, String valueMember, String displayMember, String whereMember, String orderMember)
        {
            SqlConnection conn = Procedimientos.abrirConexion();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("EXEC "+dataSource,conn);
            dataAdapter.Fill(dataSet, dataSource);
            DataRow row = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            comboBox.DataSource = dataSet.Tables[0].DefaultView;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
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
        //*    PROCEDIMIENTO PARA LLENAR UN DATATABLE
        //*************************************************

        public static void llenarDataTable(SqlCommand command, CommandType commandType, DataTable dataTable)
        {
            SqlConnection conn = abrirConexion();
            command.Connection = conn;
            command.CommandType = commandType;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(dataTable);
                    
            cerrarConexion(conn);
        }


        //**************************************************************
        //*    PROCEDIMIENTO PARA LLENAR UN DATAGRIDVIEW CON CHECKBOX
        //**************************************************************

        public static void EjecutarProcedimientoDataGridView(SqlCommand command, DataGridView dataGridView, String operacion)
        {
            SqlConnection conn = new SqlConnection ();
            conn = abrirConexion();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                string nombreCampo = string.Empty;
                Boolean tieneCheckButton = false;
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dataGridView.Columns.Add(chk);
                chk.HeaderText = "Seleccion";
                chk.Name = "chk";
                if (tieneCheckButton.Equals(true))
                {
                    DataGridViewCheckBoxColumn checBox = new DataGridViewCheckBoxColumn();
                    checBox.HeaderText = "Elegir";
                    checBox.Name = "chk";
                    dataGridView.Columns.Add(checBox);
                }
            }
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (!column.Name.Equals("checkbox") && !column.Name.Equals("chk"))
                    column.ReadOnly = true;
            }
            cerrarConexion(conn);
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

        //**************************************************
        //*    PROCEDIMIENTO PARA EJECUTAR FUNCION ESCALAR
        //**************************************************

        public static object ejecutarFuncionScalar(SqlCommand command)
        {

            object resultado = null;
            try
                {
                    SqlConnection conn = abrirConexion();
                    command.Connection = conn;
                    resultado = command.ExecuteScalar();
                }
                catch (SqlException sqlEx)
                {
                    String mensajeError = sqlEx.Message;
                    MessageBox.Show(mensajeError, "Ejecucion de Funcion sin Return", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    String mensajeError = ex.Message;
                    MessageBox.Show(mensajeError, "Ejecucion de Funcion sin Return", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return resultado;
            }
        

        //*************************************************
        //*    PROCEDIMIENTO PARA LLENAR UN DATAGRIDVIEW
        //*************************************************

        public static DataTable llenarDataGridViewDevuelveDT(SqlCommand command, DataGridView dataGridView, String operacion)
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
            return dataTable;
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

        public static void limpiarCheckBoxes(Control parent)
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

        public static void limpiarDataGridViews(DataGridView dgv)
        {
            if (dgv.CurrentCell != null)
            {
                DataTable dt = (DataTable)dgv.DataSource;
                dt.Clear();
            }
        }

        public static DateTime convertirFecha(string dia, string mes, string anio)
        {
            DateTime fecha = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia), 00, 00, 00, 000);
            return fecha;
        }

        //**********************************************************
        //*  GENERACION DE USERNAME Y PASSWORD AUTOMATICOS
        //**********************************************************

        public static string generarUsername()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }

        public static string generarPassword()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        //**********************************************************
        //*  OBTENCIÓN DE LAS OPCIONES DE MENÚ CON ID_ROL
        //**********************************************************

        public static void obtenerOpcionesMenu(SortedList<int, OpcionMenu> opcionesMenu, int id_Rol)
        {

            SqlConnection conn = abrirConexion();
            String nombreStoredProcedure = "LOS_OPTIMISTAS.proc_ListarMenuFuncionalidadesRol";
            SqlCommand command = new SqlCommand(nombreStoredProcedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_Id_Rol", id_Rol);

            SqlDataReader reader = command.ExecuteReader();
            int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   // MessageBox.Show("ES: " + (int)reader["Id_Funcionalidad"]);
                    OpcionMenu opcionesDeMenu = new OpcionMenu();
                    opcionesDeMenu.DescripcionFuncionalidad = reader["Descripcion"].ToString();
                    opcionesDeMenu.IdFuncionalidad = Convert.ToInt32(reader["Id_Funcionalidad"]);
                    opcionesMenu.Add(i, opcionesDeMenu);
                    i++;
                }
            }
            cerrarConexion(conn);

        }
    }
}