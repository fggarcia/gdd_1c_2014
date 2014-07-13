using System.Data.SqlClient;
using System.Data;
using FrbaCommerce;
using System.Windows.Forms;
public class Visibilidad
{
    public int id {get;set;}
    public string description { get; set; }
    public double price { get; set; }
    public double percentage { get; set; }
    public int weight { get; set; }
    public int enable { get; set; }

    public Visibilidad()
    {
    }

    public Visibilidad(int id, string description, double price, double percentage, int weight, int enable)
    {
        this.id = id;
        this.description = description;
        this.price = price;
        this.percentage = percentage;
        this.weight = weight;
        this.enable = enable;
    }

    public static void buscar(string id, string description, string weight, DataGridView dgvCliente)
    {
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constantes.procedimientoMostrarVisibilidad;

        if (id == string.Empty)
            command.Parameters.AddWithValue("@p_id_visibilidad", null);
        else
            command.Parameters.AddWithValue("@p_id_visibilidad", id);

        if (description == string.Empty)
            command.Parameters.AddWithValue("@p_descripcion", null);
        else
            command.Parameters.AddWithValue("@p_descripcion", description);

        if (weight == string.Empty)
            command.Parameters.AddWithValue("@p_peso", null);
        else
            command.Parameters.AddWithValue("@p_peso", weight);

        Procedimientos.llenarDataGridView(command, dgvCliente, "DataGridView Visibilidad");
    }

    public static void deshabilitarVisibilidad(string id)
    {
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constantes.procedimientoEliminarVisibilidad;

        command.Parameters.AddWithValue("@id_visibilidad", id);

        Procedimientos.ejecutarStoredProcedure(command, "eliminar visibilidad", true);
    }
}