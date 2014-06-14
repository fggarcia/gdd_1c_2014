﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    class Constantes
    {
        //************************************
        //*  CONSTANTES STORED PROCEDURES
        //************************************

        //TODO Ver como se van a llamar los procedimientos
        public const String procedimientoMostrarClientes = "LOS_OPTIMISTAS.proc_ListarClientes";
        public const String procedimientoCrearCliente = "LOS_OPTIMISTAS.AltaCliente";
        public const String procedimientoModificarCliente = "LOS_OPTIMISTAS.ModificarCliente";
        public const String procedimientoEliminarCliente = "LOS_OPTIMISTAS.proc_Baja_Cliente";
        public const String procedimientoAltaEmpresa = "LOS_OPTIMISTAS.AltaEmpresa";
        public const String procedimientoListarEmpresas = "LOS_OPTIMISTAS.proc_ListarEmpresas";
    }
}