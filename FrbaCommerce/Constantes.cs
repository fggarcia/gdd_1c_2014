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
        public const String procedimientoChequearTresPublicacionesGratuitas = "LOS_OPTIMISTAS.proc_ChequearPublicacionesGratuitas";
        public const String procedimientoMostrarPublicaciones = "LOS_OPTIMISTAS.proc_listarPublicaciones";

        public const String procedimientoMostrarPublicacionesComprarOfertar = "LOS_OPTIMISTAS.proc_ListarPublicacionesComprarOfertar";

        public const String procedimientoBajaUsuario = "LOS_OPTIMISTAS.BajaUsuario";

        public const String listarMenuFuncionalidades = "LOS_OPTIMISTAS.proc_ListarMenuFuncionalidadesRol";

        public const String listarRoles = "LOS_OPTIMISTAS.ListarRoles";
        public const String bajaRol = "LOS_OPTIMISTAS.BajaRol";

        public const String procedimientoListadoSubastasGanadas = "LOS_OPTIMISTAS.proc_ListarSubastasGanadas";
        public const String procedimientoListadoSubastasNoGanadas = "LOS_OPTIMISTAS.proc_ListarSubastasPerdidas";
        public const String procedimientoListadoCompras = "LOS_OPTIMISTAS.proc_ListarCompras";
        public const String procedimientoListadoVentas = "LOS_OPTIMISTAS.proc_ListarVentas";
        public const String procedimientoListadoCalificacionesOtorgadas = "LOS_OPTIMISTAS.proc_ListarCalificacionesOtorgadas";
        public const String procedimientoListadoCalificacionesRecibidas = "LOS_OPTIMISTAS.proc_ListarCalificacionesRecibidas";

        public const String procedimientoListadoFacturasPendientes = "LOS_OPTIMISTAS.proc_ListarFacturasPendientes";
        public const String procedimientoSeleccionarPagos = "LOS_OPTIMISTAS.proc_ListarFacturasPendientes";

        public const String procedimientoListarVendedoresCalificar = "LOS_OPTIMISTAS.proc_ListarVendedoresACalificar";

        public const String procedimientoCalificar = "LOS_OPTIMISTAS.proc_Calificar";

        public const String procedimientoPerformSubasta = "LOS_OPTIMISTAS.proc_aceptarSubasta";
        public const String procedimientoObtenerPrecioSubasta = "LOS_OPTIMISTAS.proc_obtenerPrecioSubasta";
        public const String procedimientoPerformCompra = "LOS_OPTIMISTAS.proc_aceptarCompra";
        
        public const String procedimientoMayorFacturacionTOP5 = "LOS_OPTIMISTAS.proc_ListadoEstadisticoMayorFacturacionTOP5";
        public const String procedimientoMayorFacturacionMensual = "LOS_OPTIMISTAS.proc_ListadoEstadisticoMayorFacturacionMensual";
        public const String procedimientoProductosNoVendidosTOP5 = "LOS_OPTIMISTAS.proc_ListadoEstadisticoProductosNoVendidosTOP5";
        public const String procedimientoProductosNoVendidosMensual = "LOS_OPTIMISTAS.proc_ListadoEstadisticoProductosNoVendidosMensual";
        public const String procedimientoMayorCalificacionTOP5 = "LOS_OPTIMISTAS.proc_ListadoEstadisticoMayorCalificacionTOP5";
        public const String procedimientoMayorCalificacionMensual = "LOS_OPTIMISTAS.proc_ListadoEstadisticoMayorCalificacionMensual";
        public const String procedimientoPublicacionesSinCalificarTOP5 = "LOS_OPTIMISTAS.proc_ListadoEstadisticoPublicacionesSinCalificarTOP5";
        public const String procedimientoPublicacionesSinCalificarMensual = "LOS_OPTIMISTAS.proc_ListadoEstadisticoPublicacionesSinCalificarMensual";

        public const String procedimientoListarPreguntas = "LOS_OPTIMISTAS.ListarPreguntas";
        public const String procedimientoListarRespuestas = "LOS_OPTIMISTAS.ListarRespuestas";

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
                case "Editar publicacion":
                    func.carpeta = "Editar_Publicacion";
                    func.form = "FormEditarPublicacion";
                    break;
                case "Gestion de preguntas":
                    func.carpeta = "Gestion_de_Preguntas";
                    func.form = "FormListadoPreguntas";
                    break;
                case "Comprar/Ofertar":
                    func.carpeta = "Comprar_Ofertar";
                    func.form = "FormComprarOfertar";
                    break;
                case "Historial del cliente":
                    func.carpeta = "Historial_Cliente";
                    func.form = "FormHistorialUsuario";
                    break;
                case "Calificar al vendedor":
                    func.carpeta = "Calificar_Vendedor";
                    func.form = "FormSeleccionACalificar";
                    break;
                case "Facturar Publicaciones":
                    func.carpeta = "Facturar_Publicaciones";
                    func.form = "FormFacturarPublicaciones";
                    break;
                case "Listado Estadistico":
                    func.carpeta = "Listado_Estadistico";
                    func.form = "FormListadoEstadistico";
                    break;

            }
            return func;
        }
    }
}
