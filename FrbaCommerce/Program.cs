﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrbaCommerce.Abm_Empresa;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce;
using System.Data.SqlClient;
using FrbaCommerce.Login;

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
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }
    }
}
