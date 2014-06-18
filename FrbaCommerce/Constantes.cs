using System;
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

        public const String procedimientoCrearCliente = "LOS_OPTIMISTAS.AltaCliente";
        public const String procedimientoMostrarClientes = "LOS_OPTIMISTAS.proc_ListarClientes";
        public const String procedimientoModificarCliente = "LOS_OPTIMISTAS.ModificarCliente";

        public const String procedimientoCrearEmpresa = "LOS_OPTIMISTAS.AltaEmpresa";
        public const String procedimientoMostrarEmpresas = "LOS_OPTIMISTAS.proc_ListarEmpresas";
        public const String procedimientoModificarEmpresa = "LOS_OPTIMISTAS.ModificarEmpresa";

        public const String procedimientoBajaUsuario = "LOS_OPTIMISTAS.BajaUsuario";


        //************************************
        //*  CONSTANTES VALIDACIONES
        //************************************

        public const int cantidadDeFallasIgualATres = 3;
        public const string RolCliente = "Cliente";
        public const string RolEmpresa = "Empresa";
    }
}
