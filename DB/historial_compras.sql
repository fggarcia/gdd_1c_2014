--CREO TABLA HISTORIAL DE COMPRAS
CREATE TABLE [LOS_OPTIMISTAS].[Historial_Compra](
[Id_Vendedor][varchar](20) NOT NULL,
[Id_Comprador][varchar](20) NOT NULL,
[Id_Publicacion][numeric](18,0) NOT NULL,
[Id_Articulo][numeric](18,0) NOT NULL,
[Compra_Cantidad][numeric](18,0) NOT NULL,
[Compra_Fecha][smalldatetime] NOT NULL,

CONSTRAINT [FK_Historial_Compra_Id_Vendedor] FOREIGN KEY(Id_Vendedor)
REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
CONSTRAINT [FK_Historial_Compra_Id_Comprador] FOREIGN KEY(Id_Comprador)
REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
CONSTRAINT [FK_Historial_Compra_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion),
CONSTRAINT [FK_Historial_Compra_Id_Articulo] FOREIGN KEY(Id_Articulo)
REFERENCES [LOS_OPTIMISTAS].[Stock](Id_Articulo)
)
--COMPRAS POR CLIENTES A CLIENTES
INSERT INTO LOS_OPTIMISTAS.Historial_Compra(Id_Vendedor, Id_Comprador, Id_Publicacion, Id_Articulo, Compra_Cantidad, Compra_Fecha)
SELECT LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni), LOS_OPTIMISTAS.obtenerDNI(Cli_Dni), Publicacion_Cod, 
	LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion), Compra_Cantidad, Compra_Fecha
	FROM gd_esquema.Maestra 
	WHERE Cli_Dni IS NOT NULL AND Publ_Cli_Dni IS NOT NULL
	AND Compra_Cantidad IS NOT NULL AND Compra_Fecha IS NOT NULL
	AND Calificacion_Cant_Estrellas IS NULL

--COMPRAS POR CLIENTES A EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Historial_Compra(Id_Vendedor, Id_Comprador, Id_Publicacion, Id_Articulo,Compra_Cantidad, Compra_Fecha)
SELECT LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit), LOS_OPTIMISTAS.obtenerDNI(Cli_Dni), 
	Publicacion_Cod, LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion), Compra_Cantidad, Compra_Fecha
	FROM gd_esquema.Maestra WHERE Cli_Dni IS NOT NULL AND Publ_Empresa_Cuit IS NOT NULL
	AND Compra_Cantidad IS NOT NULL AND Compra_Fecha IS NOT NULL
	AND Calificacion_Cant_Estrellas IS NULL
