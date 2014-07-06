using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FrbaCommerce
{
    public class Rol
    {
        public int Id_Rol {get;set;}
        public String Descripcion { get; set; }
        public bool Habilitado { get; set; }
        //Ver si es necesario agregar la lista de funcionalidades del rol



    }
}
