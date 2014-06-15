using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Abm_Cliente;
using System.Data.SqlClient;

namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormABMEmpresa formCabm = new FormABMEmpresa();
            formCabm.ShowDialog();
        }
    }
}
