using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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

        public const String procedimientoMostrarVisibilidad = "LOS_OPTIMISTAS.proc_ListarVisibilidades";
        public const String procedimientoModificarVisibilidad = "LOS_OPTIMISTAS.proc_CrearModificarVisibilidad";
        public const String procedimientoEliminarVisibilidad = "LOS_OPTIMISTAS.proc_EliminarVisibilidad";
        public const String procedimientoCrearVisibilidad = "LOS_OPTIMISTAS.proc_CrearModificarVisibilidad";

        public const String procedimientoGenerarPublicacion = "LOS_OPTIMISTAS.proc_GenerarPublicacion";
        
        public const String procedimientoBajaUsuario = "LOS_OPTIMISTAS.BajaUsuario";

        public const String listarMenuFuncionalidades = "LOS_OPTIMISTAS.proc_ListarMenuFuncionalidadesRol";

        public const String listarRoles = "LOS_OPTIMISTAS.ListarRoles";
        public const String bajaRol = "LOS_OPTIMISTAS.BajaRol";

        public const String procedimientoListadoSubastas = "LOS_OPTIMISTAS.proc_ListarSubastas";
        public const String procedimientoListadoCompras = "LOS_OPTIMISTAS.proc_ListarCompras";
        public const String procedimientoListadoVentas = "LOS_OPTIMISTAS.proc_ListarVentas";
        public const String procedimientoListadoCalificaciones = "LOS_OPTIMISTAS.proc_ListarCalificaciones";


        //************************************
        //*  CONSTANTES VALIDACIONES
        //************************************

        public const int cantidadDeFallasIgualATres = 3;
        public const string RolCliente = "Cliente";
        public const string RolEmpresa = "Empresa";

        //************************************
        //*  CONSTANTES FORMS
        //************************************

        public static Size aumentoTamanio = new Size(0, 30);

        //************************************
        //*  CONSTANTES FUNCIONALIDADES ROLES
        //************************************

        public struct funcionalidad
        {
            public String carpeta;
            public String form;
        }
        //TODO ver como se van a llamar los Forms que faltan
        public static funcionalidad obtenerFuncionalidad(String idFuncionalidad)
        {
            funcionalidad func = new funcionalidad();

            switch (idFuncionalidad)
            {
                case "Login y Seguridad":
                    func.carpeta = "Login";
                    func.form = "FormLogin";
                    break;
                case "ABM de Rol":
                    func.carpeta = "ABM_Rol";
                    func.form = "FormABMRol";
                    break;
                case "Registro de Usuario":
                    func.carpeta = "Registro_de_Usuario";
                    func.form = "FormRegistro";
                    break;
                case "ABM Cliente":
                    func.carpeta = "Abm_Cliente";
                    func.form = "FormABMCliente";
                    break;
                case "ABM Empresa":
                    func.carpeta = "Abm_Empresa";
                    func.form = "FormABMEmpresa";
                    break;
                case "ABM Rubro":
                    func.carpeta = "Abm_Rubro";
                    func.form = "Form";
                    break;
                case "ABM visibilidad de publicacion":
                    func.carpeta = "Abm_Visibilidad";
                    func.form = "FormABMVisibilidad";
                    break;
                case "Generar publicacion":
                    func.carpeta = "Generar_Publicacion";
                    func.form = "FormGenerarPublicacion";
                    break;
                case "Editar Publicacion":
                    func.carpeta = "Editar_Publicacion";
                    func.form = "Form";
                    break;
                case "Gestion de Preguntas":
                    func.carpeta = "Gestion_de_Preguntas";
                    func.form = "Form";
                    break;
                case "Comprar/Ofertar":
                    func.carpeta = "Comprar-Ofertar";
                    func.form = "Form";
                    break;
                case "Historial del cliente":
                    func.carpeta = "Historial_Cliente";
                    func.form = "FormHistorialUsuario";
                    break;
                case "Calificar al vendedor":
                    func.carpeta = "Calificar_Vendedor";
                    func.form = "Form";
                    break;
                case "Facturar Publicaciones":
                    func.carpeta = "Facturar_Publicaciones";
                    func.form = "Form";
                    break;
                case "Listado Estadistico":
                    func.carpeta = "Listado_Estadistico";
                    func.form = "Form";
                    break;

            }
            return func;
        }
    }
}
