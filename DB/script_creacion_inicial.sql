/****** Object:  Schema [LOS_OPTIMISTAS]    Script Date: 10/05/2014 23:39:06 ******/

/****************************************************************/
--						CREAR ESQUEMA
/****************************************************************/

CREATE SCHEMA [LOS_OPTIMISTAS] AUTHORIZATION [gd]
GO

/****************************************************************/
--				CREAR TABLAS E INSERTAR DATOS
/****************************************************************/

--contraseña default para todos (gdd)
--5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01

CREATE FUNCTION LOS_OPTIMISTAS.obtenerDNI(@dni numeric(18,0))
RETURNS varchar(20)
BEGIN
	RETURN LTRIM(STR(CONVERT(INT,STR(@dni,20))))
END
GO

CREATE FUNCTION LOS_OPTIMISTAS.obtenerCuit(@cuit varchar(50))
RETURNS varchar(20)
BEGIN
	RETURN LTRIM(STR(CONVERT(INT,SubString(@cuit,4,8))))
END
GO

CREATE FUNCTION LOS_OPTIMISTAS.obtenerCodigoArticulo(@descripcion varchar(255))
returns NUMERIC(18,0)
BEGIN
	RETURN CONVERT(NUMERIC(18,0),RTRIM(SubString(@descripcion,24,20)))
END
GO

CREATE FUNCTION LOS_OPTIMISTAS.obtenerCondicionPreguntas(@estado varchar(255))
returns bit
BEGIN
	declare @publicada varchar(10)
	SET @publicada = 'Publicada'
	if LTRIM(@estado) = LTRIM(@publicada)
		RETURN 1
	else 
		RETURN 0
	RETURN 0
END
GO

CREATE FUNCTION LOS_OPTIMISTAS.obtenerIdTipoPublicacion(@tipo_publicacion varchar(255))
RETURNS INT
BEGIN
	DECLARE @Id_Tipo_Publicacion INT
	SELECT @Id_Tipo_Publicacion = Id_Tipo_Publicacion FROM LOS_OPTIMISTAS.Tipo_Publicacion 
		WHERE UPPER(Descripcion) = UPPER(@tipo_publicacion)
	RETURN @Id_Tipo_Publicacion
END
GO

CREATE TABLE [LOS_OPTIMISTAS].[Usuario](
	[Id_Usuario][varchar](20) NOT NULL,
	[Password][varchar](64) NOT NULL,
	[Cantidad_Login][Int] NOT NULL,
	[Ultima_Fecha][datetime] NULL,
	[Habilitado][bit] NULL
	
	CONSTRAINT UQ_Usuarios_Id_Usuario UNIQUE(Id_Usuario)
)

CREATE TABLE[LOS_OPTIMISTAS].[Usuario_temp](
	[Id_Usuario][varchar](20) NOT NULL,
	[Rol][Int] NOT NULL
)

--Devuelve dni
INSERT INTO LOS_OPTIMISTAS.Usuario_temp(Id_Usuario,Rol)
SELECT DISTINCT(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),2 FROM gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--Devuelve numero razon social
INSERT INTO LOS_OPTIMISTAS.Usuario_temp(Id_Usuario,Rol)
SELECT DISTINCT(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),3 FROM gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL

--Meto toda la lista de la temporal en Usuario
INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario,Password,Cantidad_Login,Ultima_Fecha,Habilitado)
SELECT Usuario_temp.Id_Usuario,'5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01',0,NULL,1 FROM LOS_OPTIMISTAS.Usuario_temp

--Contraseña del usuario admin igual a la del resto
INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario, Password, Cantidad_Login, Ultima_Fecha,Habilitado)
VALUES ('admin','5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01',0,getDate(),1)

--TABLA ROL
CREATE TABLE [LOS_OPTIMISTAS].[Rol](
	[Id_Rol][Int] NOT NULL,
	[Descripcion][varchar](20) NOT NULL,
	[Habilitado][bit] NULL

	CONSTRAINT UQ_Rol_Id_Rol UNIQUE(Id_Rol)
)

--CARGO LOS ROLES INICIALES
INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Habilitado) VALUES(1,'administrador',1)
INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Habilitado) VALUES(2,'cliente',1)
INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Habilitado) VALUES(3,'empresa',1)

--TABLA USUARIO_ROL
CREATE TABLE [LOS_OPTIMISTAS].[Usuario_Rol](
	[Id_Usuario][varchar](20) NOT NULL,
	[Id_Rol][Int] NOT NULL,
	[Habilitado][bit] NULL

	CONSTRAINT UQ_Usuario_Rol_Id_Usuario UNIQUE(Id_Usuario),
	CONSTRAINT [FK_Usuario_Rol_Usuario_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
	CONSTRAINT [FK_Usuario_Rol_Rol_Id_Rol] FOREIGN KEY(Id_Rol)
		REFERENCES [LOS_OPTIMISTAS].[Rol] (Id_Rol)
)

--INGRESO LOS USUARIOS CARGADOS EN LA TABLA PERSONAL CON ROLES SEGUN CORRESPONDA
INSERT INTO LOS_OPTIMISTAS.Usuario_Rol(Id_Usuario,Id_Rol,Habilitado)
SELECT Usuario_temp.Id_Usuario, Usuario_temp.Rol,1 FROM LOS_OPTIMISTAS.Usuario_temp

--AGREGO AL USUARIO ADMIN A LA TABLA DE ROLES
INSERT INTO LOS_OPTIMISTAS.Usuario_Rol(Id_Usuario,Id_Rol,Habilitado) VALUES ('admin',1,1)

--DESTRUYO TABLA TEMPORAL
DROP TABLE LOS_OPTIMISTAS.Usuario_temp

--TABLA FUNCIONALIDAD
CREATE TABLE [LOS_OPTIMISTAS].[Funcionalidad](
	[Id_Funcionalidad][Int] NOT NULL,
	[Descripcion][varchar](40) NOT NULL

	CONSTRAINT UQ_Funcionalidad_Id_Funcionalidad UNIQUE(Id_Funcionalidad)	
)

INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(1,'Login y Seguridad')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(2,'ABM de Rol')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(3,'Registro de Usuario')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(4,'ABM Cliente')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(5,'ABM Empresa')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(6,'ABM Rubro')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(7,'ABM visibilidad de publicacion')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(8,'Generar publicacion')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(9,'Editar publicacion')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(10,'Gestion de preguntas')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(11,'Comprar/Ofertar')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(12,'Historial del cliente')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(13,'Calificar al vendedor')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(14,'Facturar Publicaciones')
INSERT INTO LOS_OPTIMISTAS.Funcionalidad(Id_Funcionalidad,Descripcion) VALUES(15,'Listado Estadistico')


--TABLA ROL_FUNCIONALIDAD
CREATE TABLE [LOS_OPTIMISTAS].[Rol_Funcionalidad](
	[Id_Rol][Int] NOT NULL,
	[Id_Funcionalidad][Int] NOT NULL

	CONSTRAINT [PK_Rol_Funcionalidad] PRIMARY KEY (
		[Id_Rol] ASC,
		[Id_Funcionalidad] ASC
	)
	CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad_Id_Funcionalidad] FOREIGN KEY(Id_Funcionalidad)
		REFERENCES [LOS_OPTIMISTAS].[Funcionalidad] (Id_Funcionalidad),
	CONSTRAINT [FK_Rol_Funcionalidad_Rol_Id_Rol] FOREIGN KEY(Id_Rol)
		REFERENCES [LOS_OPTIMISTAS].[Rol] (Id_Rol),
	CONSTRAINT UQ_Rol_Funcionalidad_Id_Rol_Id_Funcionalidad UNIQUE(Id_Rol,Id_Funcionalidad)
)

--CREO TABLA Tipo_Documento

CREATE TABLE  [LOS_OPTIMISTAS].[Tipo_Documento](
	[Id_Tipo_Documento][varchar](6) NOT NULL,
	[Descripcion][varchar](255) 

	CONSTRAINT UQ_Tipo_Documento_Id_Tipo_Documento UNIQUE(Id_Tipo_Documento)
)

--Inserto un valor en la tabla Tipo_Documento que es "DNI"
INSERT INTO LOS_OPTIMISTAS.Tipo_Documento(Id_Tipo_Documento,Descripcion)
VALUES ('DNI','Documento Nacional de Identidad')

--TABLA CLIENTE
CREATE TABLE [LOS_OPTIMISTAS].[Cliente](
	[Id_Usuario][varchar](20) NOT NULL,
	[Id_Tipo_Documento][varchar](6) NOT NULL,
	[Dni][varchar](20) NOT NULL,---El DNI y el Id_Usuario es lo mismo, los cargo igual, VER!!!! si hay que cambiar a numeric
	[Nombre][varchar](255),
	[Apellido][varchar](255),
	[Fecha_Nacimiento][datetime]
	
	CONSTRAINT [FK_Cliente_Usuario_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
		
	CONSTRAINT [FK_Cliente_Id_Tipo_Documento] FOREIGN KEY(Id_Tipo_Documento)
		REFERENCES [LOS_OPTIMISTAS].[Tipo_Documento](Id_Tipo_Documento),
		
	CONSTRAINT UQ_Cliente_Dni UNIQUE(Dni),
		CONSTRAINT UQ_Cliente_Id_Usuario UNIQUE(Id_Usuario)
)

--CARGO LOS CLIENTES
INSERT INTO LOS_OPTIMISTAS.Cliente(Id_Usuario,Id_Tipo_Documento,Dni,Nombre,Apellido,Fecha_Nacimiento)
SELECT DISTINCT(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),'DNI',LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),
	Publ_Cli_Nombre,Publ_Cli_Apeliido,Publ_Cli_Fecha_Nac FROM gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--TABLA EMPRESA
CREATE TABLE [LOS_OPTIMISTAS].[Empresa](
	[ID_Usuario] [varchar](20) NOT NULL,
	[Razon_social] [varchar](255) NOT NULL ,
	[Cuit] [varchar](50) NOT NULL,
	[Fecha_Creacion][datetime],
	[Nombre_Contacto][varchar](255) NULL, 

	CONSTRAINT [FK_Empresa_Cliente_Id_Usuario] FOREIGN KEY(Id_Usuario)
			REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
	CONSTRAINT UQ_Empresa_Razon_social UNIQUE(Razon_social),
	CONSTRAINT UQ_Empresa_Cuit UNIQUE(Cuit)
)
--CARGO LAS EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Empresa(ID_Usuario,Razon_social,Cuit,Fecha_Creacion)
SELECT DISTINCT(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),Publ_Empresa_Razon_Social,Publ_Empresa_Cuit,Publ_Empresa_Fecha_Creacion 
	FROM gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL

--CREO TABLA DOM_MAIL
CREATE TABLE [LOS_OPTIMISTAS].[Dom_Mail](
	[Id_Usuario][varchar](20) NOT NULL ,
	[Domicilio][varchar](100)  NULL,
	[Telefono][varchar](40)  NULL,
	[Cp] [varchar](50)  NULL,
	[Mail] [varchar](255) NULL, 
	[Localidad] [varchar](255) NULL,
	[Calle][varchar](255) NULL,
	[Piso][varchar](20) NULL,
	[Depto][varchar](50) NULL

	CONSTRAINT [FK_Dom_Mail_Empresa_Id_Usuario] FOREIGN KEY(Id_Usuario)
			REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario)
)

--CARGO TABLA Dom_Mail con los datos de Clientes

INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Telefono,Cp,Mail,Localidad,Calle,Piso,Depto)
SELECT DISTINCT(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),Publ_Cli_Dom_Calle,null,Publ_Cli_Cod_Postal,Publ_Cli_Mail,null,
	Publ_Cli_Nro_Calle,Publ_Cli_Piso,Publ_Cli_Depto FROM gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--CARGO TABLA Dom_Mail con los datos de las Empresas

INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Telefono,Cp,Mail,Localidad,Calle,Piso,Depto)
SELECT DISTINCT(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),Publ_Empresa_Dom_Calle,null,Publ_Empresa_Cod_Postal,Publ_Empresa_Mail,
	null,Publ_Empresa_Dom_Calle,Publ_Empresa_Piso,Publ_Empresa_Depto FROM gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL


--CREO TABLA Visibilidad
CREATE TABLE [LOS_OPTIMISTAS].[Visibilidad](
	[Id_Visibilidad][numeric](18,0) NOT NULL,
	[Descripcion][varchar](255) NOT NULL,
	[Precio][numeric](18,2) NOT NULL,
	[Porcentaje][numeric](18,2) NOT NULL,
	[Peso][Int] NOT NULL,
	[Habilitado][Bit] DEFAULT 1

	CONSTRAINT [PK_Visibilidad_Id_Visibilidad] PRIMARY KEY(Id_Visibilidad),
	CONSTRAINT [UQ_Visibilidad_Id_Visibilidad] UNIQUE (Id_Visibilidad)
)

--INSERTO 0 EN EL PESO PARA ACONTINUACION MODIFICARLO
INSERT INTO LOS_OPTIMISTAS.Visibilidad(Id_Visibilidad, Descripcion, Precio, Porcentaje, Peso)
SELECT DISTINCT(Publicacion_Visibilidad_Cod), Publicacion_Visibilidad_Desc,
	Publicacion_Visibilidad_Precio,Publicacion_Visibilidad_Porcentaje,0
	FROM gd_esquema.Maestra WHERE Publicacion_Visibilidad_Cod IS NOT NULL
	ORDER BY Publicacion_Visibilidad_Cod ASC

UPDATE LOS_OPTIMISTAS.Visibilidad SET Peso = 1 WHERE UPPER(Descripcion) = UPPER('Platino')
UPDATE LOS_OPTIMISTAS.Visibilidad SET Peso = 2 WHERE UPPER(Descripcion) = UPPER('Oro')
UPDATE LOS_OPTIMISTAS.Visibilidad SET Peso = 3 WHERE UPPER(Descripcion) = UPPER('Plata')
UPDATE LOS_OPTIMISTAS.Visibilidad SET Peso = 4 WHERE UPPER(Descripcion) = UPPER('Bronce')
UPDATE LOS_OPTIMISTAS.Visibilidad SET Peso = 5 WHERE UPPER(Descripcion) = UPPER('Gratis')

--CREO TABLA Tipo_Publicacion
CREATE TABLE [LOS_OPTIMISTAS].[Tipo_Publicacion](
	[Id_Tipo_Publicacion][Int]IDENTITY(1,1) NOT NULL,
	[Descripcion][varchar](255) NOT NULL,

	CONSTRAINT [UQ_Tipo_Publicacion_Descripcion] UNIQUE(Descripcion),
	CONSTRAINT [PK_Tipo_Publicacion_Id_Tipo_Publicacion] PRIMARY KEY (Id_Tipo_Publicacion)
)

INSERT INTO LOS_OPTIMISTAS.Tipo_Publicacion(Descripcion)
SELECT DISTINCT(UPPER(Publicacion_Tipo)) FROM gd_esquema.maestra

--CREO TABLA estado
CREATE TABLE [LOS_OPTIMISTAS].[Estado](
	[Id_Estado][Int] IDENTITY(1,1) NOT NULL,
	[Descripcion][varchar](30) NOT NULL,

	CONSTRAINT [UQ_Estado_descripcion] UNIQUE (Descripcion),
	CONSTRAINT [PK_Estado_Id_Estado] PRIMARY KEY(Id_Estado)
)

INSERT INTO LOS_OPTIMISTAS.Estado(Descripcion)
SELECT DISTINCT UPPER(Publicacion_Estado) FROM gd_esquema.Maestra WHERE Publicacion_Estado IS NOT NULL

INSERT INTO LOS_OPTIMISTAS.Estado(Descripcion) VALUES (UPPER('Borrador'))
INSERT INTO LOS_OPTIMISTAS.Estado(Descripcion) VALUES (UPPER('Activa'))
INSERT INTO LOS_OPTIMISTAS.Estado(Descripcion) VALUES (UPPER('Pausada'))
INSERT INTO LOS_OPTIMISTAS.Estado(Descripcion) VALUES (UPPER('Finalizada'))

--CREO TABLA estado_publicacion
CREATE TABLE [LOS_OPTIMISTAS].[Estado_Publicacion](
	[Id_Publicacion][numeric](18,0) NOT NULL,
	[Id_Estado][Int] NOT NULL,

	CONSTRAINT [FK_Estado_Publicacion_Id_Estado] FOREIGN KEY(Id_Estado)
		REFERENCES [LOS_OPTIMISTAS].[Estado](Id_Estado),
	CONSTRAINT [UQ_Estado_Publicacion_Id_Publicacion] UNIQUE (Id_Publicacion)	
)

--verifique en la tabla y no habia iguales
INSERT INTO LOS_OPTIMISTAS.Estado_Publicacion(Id_Publicacion, Id_Estado)
SELECT DISTINCT(Publicacion_Cod), Id_Estado FROM gd_esquema.Maestra maestra 
	INNER JOIN LOS_OPTIMISTAS.Estado Estado ON (UPPER(maestra.Publicacion_Estado) = UPPER(Estado.Descripcion))

--CREO TABLA PUBLICACION
CREATE TABLE [LOS_OPTIMISTAS].[Publicacion](
	[Id_Publicacion][numeric] (18,0)IDENTITY(1,1) NOT NULL,
	[Id_Usuario][varchar](20) NOT NULL,
	[Id_Tipo_Publicacion][int] NOT NULL,
	[Id_Articulo][numeric](18,0) NOT NULL,             
	[Id_Visibilidad][numeric](18,0)NOT NULL,
	[Id_Estado][varchar](255)NOT NULL,
	[Precio][numeric](18,2) NULL,
	[Fecha_Inicio][datetime] NULL,
	[Fecha_Vencimiento][datetime] NULL,
	[Pemite_Preguntas][Bit] NULL,
	[Cant_por_Venta][numeric] (18,0) NULL,
	[Descripcion][varchar](255) NULL

	CONSTRAINT [FK_Publicacion_Id_Usuario] FOREIGN KEY(Id_Usuario)
			REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),

	CONSTRAINT [PK_Publicacion_Id_Publicacion] PRIMARY KEY(Id_Publicacion),
			
	CONSTRAINT [FK_Publicacion_Id_Visibilidad] FOREIGN KEY(Id_Visibilidad)
			REFERENCES [LOS_OPTIMISTAS].[Visibilidad](Id_Visibilidad),

	CONSTRAINT [FK_Publicacion_Id_Tipo_Publicacion] FOREIGN KEY(Id_Tipo_Publicacion)
			REFERENCES [LOS_OPTIMISTAS].[Tipo_Publicacion](Id_Tipo_Publicacion)		
)

SET IDENTITY_INSERT [LOS_OPTIMISTAS].Publicacion ON
GO

--INSERTO EN PUBLICACION LOS CASOS EN QUE EL USUARIO ES EL QUE PUBLICA
--SE PONE EL VALOR 1 COMO CANTIDAD DE VENTA POR PUBLICACION DEFAULT
INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Publicacion,Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,
	Id_Estado,Precio,Fecha_Inicio,Fecha_Vencimiento,Pemite_Preguntas,Cant_por_Venta,Descripcion)
SELECT DISTINCT(CONVERT(numeric(18,0),Publicacion_Cod)),LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),
	LOS_OPTIMISTAS.obtenerIdTipoPublicacion(Publicacion_Tipo),LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),
	Publicacion_Visibilidad_Cod,Publicacion_Estado,Publicacion_Precio,Publicacion_Fecha,Publicacion_Fecha_Venc,
	LOS_OPTIMISTAS.obtenerCondicionPreguntas(Publicacion_Estado),1,Publicacion_Descripcion 
	FROM gd_esquema.Maestra WHERE (Publicacion_Cod IS NOT NULL AND Publ_Cli_Dni IS NOT NULL AND Publ_Empresa_Cuit IS NULL) 


--INSERTO EN PUBLICACION LOS CASOS EN QUE LA EMPRESA ES LA QUE PUBLICA
INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Publicacion,Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,
	Id_Estado,Precio,Fecha_Inicio,Fecha_Vencimiento,Pemite_Preguntas,Cant_por_Venta,Descripcion)
SELECT DISTINCT(CONVERT(numeric(18,0),Publicacion_Cod)),LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit),
	LOS_OPTIMISTAS.obtenerIdTipoPublicacion(Publicacion_Tipo),LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),
	Publicacion_Visibilidad_Cod,Publicacion_Estado,Publicacion_Precio,Publicacion_Fecha,Publicacion_Fecha_Venc,
	LOS_OPTIMISTAS.obtenerCondicionPreguntas(Publicacion_Estado),1,Publicacion_Descripcion 
	FROM gd_esquema.Maestra WHERE (Publicacion_Cod IS NOT NULL AND Publ_Empresa_Cuit IS NOT NULL AND Publ_Cli_Dni IS NULL)

--AGREGO RESTRICCION EN ESTADO_PUBLICACION
ALTER TABLE [LOS_OPTIMISTAS].[Estado_Publicacion] ADD CONSTRAINT [FK_Estado_Publicacion_Id_Publicacion] 
	FOREIGN KEY (Id_Publicacion) REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion)

SET IDENTITY_INSERT [LOS_OPTIMISTAS].Publicacion OFF
GO

--CREO TABLA Stock
CREATE TABLE [LOS_OPTIMISTAS].[Stock](
	[Id_Articulo][numeric](18,0)IDENTITY(1,1) NOT NULL,
	[Id_Usuario][varchar](20) NOT NULL,
	[Cantidad][numeric](18,0) NOT NULL,

	CONSTRAINT [FK_Stock_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
	CONSTRAINT [PK_Stock_Id_Articulo] PRIMARY KEY(Id_Articulo)
)

GO
SET IDENTITY_INSERT [LOS_OPTIMISTAS].Stock ON
GO

--STOCK DE COMPRAS INMEDIATAS DE CLIENTES
INSERT INTO LOS_OPTIMISTAS.Stock(Id_Articulo, Id_Usuario, Cantidad)
SELECT LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),
	LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),MAX(Publicacion_Stock) - SUM(Compra_Cantidad)
	FROM gd_esquema.Maestra
	WHERE Publ_Cli_Dni IS NOT NULL AND 
	Publ_Empresa_Cuit IS NULL AND
	Compra_Cantidad IS NOT NULL AND 
	Publicacion_Tipo = 'Compra Inmediata' AND
	Calificacion_Cant_Estrellas IS NULL
	GROUP BY Publicacion_Descripcion, Publ_Cli_Dni

--STOCK DE COMPRAS INMEDIATAS DE EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Stock(Id_Articulo, Id_Usuario, Cantidad)
SELECT LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),
	LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit),MAX(Publicacion_Stock) - SUM(Compra_Cantidad)
	FROM gd_esquema.Maestra WHERE 
	Publ_Cli_Dni IS NULL AND 
	Publ_Empresa_Cuit IS NOT NULL AND
	Compra_Cantidad IS NOT NULL AND 
	Publicacion_Tipo = 'Compra Inmediata' AND
	Calificacion_Cant_Estrellas IS NULL
	GROUP BY Publicacion_Descripcion, Publ_Empresa_Cuit

--AL COMPROBAR QUE NO ARITUCULOS QUE SE PUBLIQUEN COMO COMPRA INMEDIATA Y SUBASTA A LA VEZ A TRAVES
--SELECT Distinct(C.Publicacion_Cod) FROM gd_esquema.Maestra C INNER JOIN gd_esquema.Maestra D
--ON
--LOS_OPTIMISTAS.obtenerCodigoArticulo(C.Publicacion_Descripcion) = 
--	LOS_OPTIMISTAS.obtenerCodigoArticulo(D.Publicacion_Descripcion) AND
--C.Publicacion_Tipo = 'Compra Inmediata' AND
--D.Publicacion_Tipo = 'Subasta'

--STOCK DE SUBASTAS CLIENTES
INSERT INTO LOS_OPTIMISTAS.Stock(Id_Articulo, Id_Usuario, Cantidad)
SELECT LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),
	LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),MAX(Publicacion_Stock) - SUM(Compra_Cantidad)
	FROM gd_esquema.Maestra WHERE 
	Publ_Cli_Dni IS NOT NULL AND 
	Publ_Empresa_Cuit IS NULL AND
	Compra_Cantidad IS NOT NULL AND 
	Publicacion_Tipo = 'Subasta' AND
	Calificacion_Cant_Estrellas IS NULL
	GROUP BY Publicacion_Descripcion, Publ_Cli_Dni

--STOCK DE SUBASTAS EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Stock(Id_Articulo, Id_Usuario, Cantidad)
SELECT LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),
	LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit),MAX(Publicacion_Stock) - SUM(Compra_Cantidad)
	FROM gd_esquema.Maestra WHERE 
	Publ_Cli_Dni IS NULL AND 
	Publ_Empresa_Cuit IS NOT NULL AND
	Compra_Cantidad IS NOT NULL AND 
	Publicacion_Tipo = 'Subasta' AND
	Calificacion_Cant_Estrellas IS NULL
	GROUP BY Publicacion_Descripcion, Publ_Empresa_Cuit

GO
SET IDENTITY_INSERT [LOS_OPTIMISTAS].Stock OFF
GO

--CREO TABLA HISTORIAL DE COMPRAS
CREATE TABLE [LOS_OPTIMISTAS].[Historial_Compra](
[Id_Historial_Compra][numeric](18,0) IDENTITY(1,1) NOT NULL,
[Id_Vendedor][varchar](20) NOT NULL,
[Id_Comprador][varchar](20) NOT NULL,
[Id_Publicacion][numeric](18,0) NOT NULL,
[Id_Articulo][numeric](18,0) NOT NULL,
[Compra_Cantidad][numeric](18,0) NOT NULL,
[Compra_Fecha][smalldatetime] NOT NULL,
[Calificado][Int] NOT NULL DEFAULT 0

CONSTRAINT [FK_Historial_Compra_Id_Vendedor] FOREIGN KEY(Id_Vendedor)
REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
CONSTRAINT [FK_Historial_Compra_Id_Comprador] FOREIGN KEY(Id_Comprador)
REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
CONSTRAINT [FK_Historial_Compra_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion),
CONSTRAINT [FK_Historial_Compra_Id_Articulo] FOREIGN KEY(Id_Articulo)
REFERENCES [LOS_OPTIMISTAS].[Stock](Id_Articulo),
CONSTRAINT [PK_Historial_Compra_Id_Historial_Compra] PRIMARY KEY(Id_Historial_Compra)
)

--HISTORIAL COMPRAS POR CLIENTES A CLIENTES
INSERT INTO LOS_OPTIMISTAS.Historial_Compra(Id_Vendedor, Id_Comprador, Id_Publicacion, Id_Articulo, Compra_Cantidad, Compra_Fecha,Calificado)
SELECT LOS_OPTIMISTAS.obtenerDNI(m1.Publ_Cli_Dni), LOS_OPTIMISTAS.obtenerDNI(m1.Cli_Dni), m1.Publicacion_Cod, 
	LOS_OPTIMISTAS.obtenerCodigoArticulo(m1.Publicacion_Descripcion), m1.Compra_Cantidad, m1.Compra_Fecha,
	(SELECT TOP 1 1 FROM gd_esquema.Maestra m2 WHERE m2.Calificacion_codigo IS NOT NULL 
		AND m2.Calificacion_Cant_Estrellas IS NOT NULL
		AND m2.Cli_Dni IS NOT NULL AND LOS_OPTIMISTAS.obtenerDNI(m2.Publ_Cli_Dni) = m1.Publ_Cli_Dni AND 
		LOS_OPTIMISTAS.obtenerDNI(m1.Cli_Dni) = LOS_OPTIMISTAS.obtenerDNI(m2.Cli_Dni) AND m1.Publicacion_Cod = m2.Publicacion_Cod)
	FROM gd_esquema.Maestra m1
	WHERE m1.Cli_Dni IS NOT NULL AND m1.Publ_Cli_Dni IS NOT NULL
	AND m1.Compra_Cantidad IS NOT NULL AND m1.Compra_Fecha IS NOT NULL
	AND m1.Calificacion_Cant_Estrellas IS NULL

--HISTORIAL COMPRAS POR CLIENTES A EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Historial_Compra(Id_Vendedor, Id_Comprador, Id_Publicacion, Id_Articulo,Compra_Cantidad, Compra_Fecha,Calificado)
SELECT LOS_OPTIMISTAS.obtenerCuit(m1.Publ_Empresa_Cuit), LOS_OPTIMISTAS.obtenerDNI(m1.Cli_Dni), 
	m1.Publicacion_Cod, LOS_OPTIMISTAS.obtenerCodigoArticulo(m1.Publicacion_Descripcion), m1.Compra_Cantidad, m1.Compra_Fecha,
	(SELECT TOP 1 1 FROM gd_esquema.Maestra m2 WHERE m2.Calificacion_codigo IS NOT NULL 
		AND m2.Calificacion_Cant_Estrellas IS NOT NULL
		AND m2.Cli_Dni IS NOT NULL AND LOS_OPTIMISTAS.obtenerCuit(m2.Publ_Empresa_Cuit) = LOS_OPTIMISTAS.obtenerCuit(m1.Publ_Empresa_Cuit) 
		AND LOS_OPTIMISTAS.obtenerDNI(m2.Cli_Dni) = LOS_OPTIMISTAS.obtenerDNI(m1.Cli_Dni) AND m2.Publicacion_Cod = m1.Publicacion_Cod)
	FROM gd_esquema.Maestra m1 WHERE m1.Cli_Dni IS NOT NULL AND m1.Publ_Empresa_Cuit IS NOT NULL
	AND m1.Compra_Cantidad IS NOT NULL AND m1.Compra_Fecha IS NOT NULL
	AND m1.Calificacion_Cant_Estrellas IS NULL

CREATE TABLE [LOS_OPTIMISTAS].[Publicacion_Calificaciones](
	[Id_Historial_Compra][numeric](18,0) NOT NULL,
	[Id_Calificacion][numeric](18,0)NOT NULL,
	[Fecha_Calificacion][datetime] NULL,
	[Detalle][varchar] (255) NULL,
	[Calificacion][Numeric](18,0)  NULL

	CONSTRAINT [FK_Publicacion_Calificaciones_Id_Calificacion] PRIMARY KEY (Id_Calificacion),	
	CONSTRAINT [FK_Publicacion_Calificaciones_Id_Publicacion] FOREIGN KEY(Id_Historial_Compra)
			REFERENCES [LOS_OPTIMISTAS].[Historial_Compra](Id_Historial_Compra)
)

--Inserto en publicacion_Calificaciones COnsideramos
--poner la fecha de compra como la de calificacion en todos los casos de migracion
INSERT INTO LOS_OPTIMISTAS.Publicacion_Calificaciones (Id_Calificacion, Fecha_Calificacion, Detalle, Calificacion, Id_Historial_Compra)
SELECT 	Calificacion_Codigo,Compra_Fecha,
		Calificacion_Descripcion,Calificacion_Cant_Estrellas,
		(SELECT TOP 1 Id_Historial_Compra
			FROM LOS_OPTIMISTAS.Historial_Compra 
			WHERE Id_Comprador = LOS_OPTIMISTAS.obtenerDNI(Cli_Dni)
			AND Id_Publicacion = Publicacion_Cod
			AND Compra_Fecha = Compra_Fecha) FROM gd_esquema.Maestra
		WHERE Calificacion_codigo IS NOT NULL 
		AND Calificacion_Cant_Estrellas IS NOT NULL
		AND Publ_Cli_Dni IS NOT NULL
		AND Cli_Dni IS NOT NULL

INSERT INTO LOS_OPTIMISTAS.Publicacion_Calificaciones (Id_Calificacion, Fecha_Calificacion, Detalle, Calificacion, Id_Historial_Compra)
SELECT 	Calificacion_Codigo,Compra_Fecha,
		Calificacion_Descripcion,Calificacion_Cant_Estrellas,
		(SELECT TOP 1 Id_Historial_Compra
			FROM LOS_OPTIMISTAS.Historial_Compra 
			WHERE Id_Comprador = LOS_OPTIMISTAS.obtenerDNI(Cli_Dni)
			AND Id_Publicacion = Publicacion_Cod
			AND Compra_Fecha = Compra_Fecha) FROM gd_esquema.Maestra
		WHERE Calificacion_codigo IS NOT NULL 
		AND Calificacion_Cant_Estrellas IS NOT NULL
		AND Publ_Empresa_Cuit IS NOT NULL
		AND Cli_Dni IS NOT NULL

--CREO TABLA Publicacion_Pregunta (No la cargo porque no existen preguntas)
CREATE TABLE [LOS_OPTIMISTAS].[Publicacion_Preguntas](
	[Id_Pregunta][int]IDENTITY(1,1) NOT NULL,
	[Id_Publicacion][numeric] (18,0) NOT NULL,
	[Id_Usuario][varchar](20) NOT NULL,
	[Fecha_Creacion][datetime],
	[Preg_Descripcion][varchar](255) NULL,
	[Preg_Respuesta][varchar](255) NULL,
	[Fecha_Respuesta][datetime]

	CONSTRAINT [FK_Publicacion_Preguntas_Id_Pregunta] PRIMARY KEY (Id_Pregunta),

	CONSTRAINT [FK_Publicacion_Preguntas_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
			REFERENCES [LOS_OPTIMISTAS].[Publicacion] (Id_Publicacion),

	CONSTRAINT [FK_Publicacion_Preguntas_Id_Usuario] FOREIGN KEY(Id_Usuario)
			REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario)
)

--CREO TABLA Historial_Subasta
CREATE TABLE [LOS_OPTIMISTAS].[Historial_Subasta](
	[Id_Publicacion][numeric] (18,0) NOT NULL,
	[Id_Usuario][varchar](20) NOT NULL,
	[Precio_Oferta][numeric](18,2) NULL, --En el enunciado dice que tiene que ser ENTERO!!!!!
	[Fecha_Oferta][datetime],


	CONSTRAINT [FK_Historial_Subasta_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
			REFERENCES [LOS_OPTIMISTAS].[Publicacion] (Id_Publicacion),

	CONSTRAINT [FK_Historial_Subasta_Id_Usuario] FOREIGN KEY(Id_Usuario)
			REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario)
)

--Inserto en Historial_Publicacion Y TAMBIEN PASO VALORES DONDE EXSITE UNA OFERTA(esta el dni) PERO QUE NO TIENE PRECIO ni FECHA
INSERT INTO LOS_OPTIMISTAS.Historial_Subasta(Id_Publicacion,Id_Usuario,Precio_Oferta,Fecha_Oferta)
SELECT Publicacion_Cod, LOS_OPTIMISTAS.obtenerDNI(Cli_Dni),Oferta_Monto,Oferta_Fecha 
	FROM gd_esquema.Maestra WHERE (Publicacion_Tipo = 'Subasta' and Cli_Dni IS NOT NULL 
	AND Calificacion_Codigo IS NULL AND Compra_Cantidad IS NULL)

--CREO TABLA Rubro
CREATE TABLE [LOS_OPTIMISTAS].[Rubro](
	[Id_Rubro][Int] NOT NULL,
	[Descripcion][varchar](60) NOT NULL,
	[Fecha_Baja][datetime] NULL,

	CONSTRAINT [PK_Rubro_Id_Rubro] PRIMARY KEY(Id_Rubro)
)

--CREO TABLA Rubro_Publicacion
CREATE TABLE [LOS_OPTIMISTAS].[Rubro_Publicacion](
	[Id_Publicacion][numeric](18,0) NOT NULL,
	[Id_Rubro][Int] NOT NULL,

	CONSTRAINT [FK_Rubro_Publicacion_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
		REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion),

	CONSTRAINT [FK_Rubro_Publicacion_Id_Rubro] FOREIGN KEY(Id_Rubro)
		REFERENCES [LOS_OPTIMISTAS].[Rubro](Id_Rubro)
)

--CREO RESTRICCION EN PUBLICACION
ALTER TABLE [LOS_OPTIMISTAS].[Publicacion] ADD CONSTRAINT [FK_Publicacion_Id_Articulo] FOREIGN KEY (Id_Articulo)
	REFERENCES [LOS_OPTIMISTAS].[Stock](Id_Articulo)

--CREO TABLA FACTURACION DETALLE
CREATE TABLE [LOS_OPTIMISTAS].[Facturacion_Detalle](
	[Id_Factura][numeric](18,0) NOT NULL,
	[Id_Publicacion][numeric](18,0) NOT NULL,	
	[Monto_Compra][numeric](18,2) NOT NULL DEFAULT 0.0,
	[Porcentaje_Comision][numeric](18,2) NOT NULL DEFAULT 0.0,
	[Comision][numeric](18,2) NOT NULL DEFAULT 0.0,
	[Cantidad_Venta][Int] NOT NULL DEFAULT 1,
	[Monto_Visibilidad][numeric](18,2) NOT NULL DEFAULT 0.0,
	[Id_Visibilidad][numeric](18,0) NOT NULL,
)
--Cargo factura detalle con subastas
INSERT INTO LOS_OPTIMISTAS.Facturacion_Detalle(Id_Factura, Id_Publicacion,Monto_Compra,Porcentaje_Comision,Comision,
	Cantidad_Venta,Id_Visibilidad)
SELECT Factura_Nro, Publicacion_Cod, 
	CONVERT(numeric(18,2),((1 * Item_Factura_Monto) / Publicacion_Visibilidad_Porcentaje)/Item_Factura_Cantidad) AS monto_compra,
	Publicacion_Visibilidad_Porcentaje, 
	CONVERT(numeric(18,2),Item_Factura_Monto/Item_Factura_Cantidad) AS comision, 
	Item_Factura_Cantidad, Publicacion_Visibilidad_Cod
	FROM gd_esquema.Maestra WHERE Factura_Nro IS NOT NULL
	AND Publicacion_Tipo = 'Subasta'
	AND Publicacion_Visibilidad_Precio != Item_Factura_Monto / Item_Factura_Cantidad

--Cargo facturacion detalle cobro visibilidad subastas
INSERT INTO LOS_OPTIMISTAS.Facturacion_Detalle(Id_Factura, Id_Publicacion,Monto_Visibilidad,Cantidad_Venta,Id_Visibilidad)
SELECT Factura_Nro, Publicacion_Cod, Publicacion_Visibilidad_Precio,
	Item_Factura_Cantidad,Publicacion_Visibilidad_Cod
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL
	AND Publicacion_Tipo = 'Subasta'
	AND Publicacion_Visibilidad_Precio = Item_Factura_Monto / Item_Factura_Cantidad

--Cargo factura detalle con compra inmediata
INSERT INTO LOS_OPTIMISTAS.Facturacion_Detalle(Id_Factura, Id_Publicacion,Monto_Compra,Porcentaje_Comision,
	Comision,Cantidad_Venta,Id_Visibilidad)
SELECT Factura_Nro, Publicacion_Cod, Publicacion_Precio,Publicacion_Visibilidad_Porcentaje,
	CONVERT(numeric(18,2),Publicacion_Precio * Publicacion_Visibilidad_Porcentaje), Item_Factura_Cantidad, 
	Publicacion_Visibilidad_Cod
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL
	AND Publicacion_Tipo = 'Compra Inmediata'
	AND Publicacion_Visibilidad_Precio != Item_Factura_Monto / Item_Factura_Cantidad

--Cargo facturacion detalle cobro visibilidad compra inmediata
INSERT INTO LOS_OPTIMISTAS.Facturacion_Detalle(Id_Factura, Id_Publicacion,Monto_Visibilidad,Cantidad_Venta,Id_Visibilidad)
SELECT Factura_Nro, Publicacion_Cod, Publicacion_Visibilidad_Precio,
	Item_Factura_Cantidad,Publicacion_Visibilidad_Cod
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL
	AND Publicacion_Tipo = 'Compra Inmediata'
	AND Publicacion_Visibilidad_Precio = Item_Factura_Monto / Item_Factura_Cantidad

--CREO TABLA FACTURACION
CREATE TABLE [LOS_OPTIMISTAS].[Facturacion](
	[Id_Factura][numeric](18,0) NOT NULL,
	[Id_Usuario][varchar](20) NOT NULL,
	[Total_Factura][numeric](18,2) NOT NULL,
	[Total_Comisiones][numeric](18,2) NULL,
	[Total_Visibilidad][numeric](18,2) NULL,
	[Fecha][datetime] NOT NULL,

	CONSTRAINT [PK_Facturacion_Id_Factura] PRIMARY KEY(Id_Factura),
	CONSTRAINT [FK_Facturacion_Id_Usuario] FOREIGN KEY(Id_Usuario)
	REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario)
)

--INSERTO LAS FACTURAS DE CLIENTES
INSERT INTO LOS_OPTIMISTAS.Facturacion(Id_Factura, Id_Usuario, Total_Comisiones, Total_Visibilidad,Total_Factura, Fecha)
SELECT FD.Id_Factura, LOS_OPTIMISTAS.obtenerDNI(E.Publ_Cli_Dni),CONVERT(numeric(18,2),
	SUM(FD.Comision * FD.Cantidad_Venta)) AS Total_Comisiones, 
	CONVERT(numeric(18,2),SUM(FD.Monto_Visibilidad * FD.Cantidad_Venta)) AS Total_Visibilidad,
	CONVERT(numeric(18,2),SUM(FD.Comision * FD.Cantidad_Venta)) + CONVERT(numeric(18,2),
	SUM(FD.Monto_Visibilidad * FD.Cantidad_Venta)) AS Total_Factura, E.Factura_Fecha
	FROM LOS_OPTIMISTAS.Facturacion_Detalle FD INNER JOIN (SELECT Factura_Nro, Publ_Cli_Dni, Factura_Fecha FROM gd_esquema.Maestra
	WHERE Publ_Cli_Dni IS NOT NULL AND Factura_Nro IS NOT NULL
	GROUP BY Factura_Nro, Publ_Cli_Dni, Factura_Fecha) E
	ON FD.Id_Factura = E.Factura_Nro
	GROUP BY FD.Id_Factura, E.Publ_Cli_Dni, E.Factura_Fecha

--INSERTO LAS FACTURAS DE EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Facturacion(Id_Factura, Id_Usuario, Total_Comisiones, Total_Visibilidad,Total_Factura, Fecha)
SELECT FD.Id_Factura,LOS_OPTIMISTAS.obtenerCuit(E.Publ_Empresa_Cuit), 
	CONVERT(numeric(18,2),SUM(FD.Comision * FD.Cantidad_Venta)) AS Total_Comisiones, 
	CONVERT(numeric(18,2),SUM(FD.Monto_Visibilidad * FD.Cantidad_Venta)) AS Total_Visibilidad,
	CONVERT(numeric(18,2),SUM(FD.Comision * FD.Cantidad_Venta)) + CONVERT(numeric(18,2),
	SUM(FD.Monto_Visibilidad * FD.Cantidad_Venta)) AS Total_Factura, E.Factura_Fecha
	FROM LOS_OPTIMISTAS.Facturacion_Detalle FD INNER JOIN (SELECT Factura_Nro, Publ_Empresa_Cuit, Factura_Fecha FROM gd_esquema.Maestra
	WHERE Publ_Empresa_Cuit IS NOT NULL AND Factura_Nro IS NOT NULL
	GROUP BY Factura_Nro, Publ_Empresa_Cuit, Factura_Fecha) E
	ON FD.Id_Factura = E.Factura_Nro
	GROUP BY FD.Id_Factura, E.Publ_Empresa_Cuit, E.Factura_Fecha

--DESPUES DE MIGRAR LAS TABLAS DE FACTURACION AGREGO LAS CONSTRAINT CORRESPONDIENTES
ALTER TABLE [LOS_OPTIMISTAS].[Facturacion_Detalle] ADD  CONSTRAINT [FK_Facturacion_Detalle_Id_Factura] FOREIGN KEY(Id_Factura)
REFERENCES [LOS_OPTIMISTAS].[Facturacion] (Id_Factura)

ALTER TABLE [LOS_OPTIMISTAS].[Facturacion_Detalle] ADD  CONSTRAINT [FK_Facturacion_Detalle_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
REFERENCES [LOS_OPTIMISTAS].[Publicacion] (Id_Publicacion)

ALTER TABLE [LOS_OPTIMISTAS].[Facturacion_Detalle] ADD  CONSTRAINT [FK_Facturacion_Detalle_Descripcion_Visibilidad] FOREIGN KEY(Id_Visibilidad)
REFERENCES [LOS_OPTIMISTAS].[Visibilidad] (Id_Visibilidad)

--CREO TABLA FACTURACION PENDIENTE
CREATE TABLE [LOS_OPTIMISTAS].[Facturacion_Pendiente](
	[Id_Registro][numeric](18,0)IDENTITY(1,1),
	[Id_Usuario][varchar](20) NOT NULL,
	[Id_Usuario_Comprador][varchar](20) DEFAULT NULL,
	[Id_Publicacion][numeric](18,0) NULL,
	[Comision][numeric](18,2) NOT NULL,
	[Visibilidad][varchar](255) NOT NULL,
	[Cantidad][int] NULL,
	[Precio_Publicacion][numeric](18,2) NULL,
	[Precio_Visibilidad][numeric](18,2) NULL,

	CONSTRAINT [PK_Facturacion_Pendiente_Id_Registro] PRIMARY KEY (Id_Registro),
	CONSTRAINT [FK_Facturacion_Pendiente_Id_Usuario] FOREIGN KEY(Id_Usuario)
	REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
	CONSTRAINT [FK_Facturacion_Pendiente_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
	REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion)
)
-- SE VERIFICO QUE AL EJECUTAR
--SELECT TOP 1 * FROM gd_esquema.Maestra M
--WHERE (SELECT TOP 1 1 FROM LOS_OPTIMISTAS.Facturacion_Detalle FD WHERE FD.Id_Publicacion = M.Publicacion_Cod) != 1
--SIGNIFICA QUE NO HAY PENDIENTE DE FACTURACION

--CREO TABLA TIPO DE PAGO
CREATE TABLE [LOS_OPTIMISTAS].[Tipo_Pago](
	[Id_Tipo_Pago][int]IDENTITY(1,1),
	[Descripcion][varchar](255),

	CONSTRAINT [PK_Tipo_Pago_Id_Tipo_Pago] PRIMARY KEY(Id_Tipo_Pago),
	CONSTRAINT [UQ_Tipo_Pago_Descripcion] UNIQUE(Descripcion)
)

INSERT INTO LOS_OPTIMISTAS.Tipo_Pago(Descripcion)
SELECT DISTINCT(Forma_Pago_Desc) FROM gd_esquema.Maestra WHERE Forma_Pago_Desc IS NOT NULL

INSERT INTO LOS_OPTIMISTAS.Tipo_Pago(Descripcion) VALUES('Tarjeta Credito')

--CREO TABLA DETALLE TARJETA
CREATE TABLE [LOS_OPTIMISTAS].[Detalle_Tarjeta](
	[Id_Detalle_Tarjeta][Int]IDENTITY(1,1) NOT NULL,
	[Nro_Tarjeta][numeric](16,0) NOT NULL,
	[Cant_Cuota][Int] NOT NULL,

	CONSTRAINT [PK_Detalle_Tarjeta_Id_Detalle_Tarjeta] PRIMARY KEY(Id_Detalle_Tarjeta)
)

--CREO TABLA FORMA PAGO
CREATE TABLE [LOS_OPTIMISTAS].[Forma_Pago](
	[Id_Factura][numeric](18,0) NOT NULL,
	[Id_Detalle_Tarjeta][Int] NULL,
	[Id_Tipo_Pago][Int] NOT NULL,

	CONSTRAINT [FK_Forma_Pago_Id_Factura] FOREIGN KEY(Id_Factura)
	REFERENCES [LOS_OPTIMISTAS].[Facturacion](Id_Factura),
	CONSTRAINT [FK_Forma_Pago_Id_Detalle_Tarjeta] FOREIGN KEY(Id_Detalle_Tarjeta)
	REFERENCES [LOS_OPTIMISTAS].[Detalle_Tarjeta](Id_Detalle_Tarjeta),
	CONSTRAINT [FK_Forma_Pago_Id_Tipo_Pago] FOREIGN KEY(Id_Tipo_Pago)
	REFERENCES [LOS_OPTIMISTAS].[Tipo_Pago](Id_Tipo_Pago)
)
INSERT INTO LOS_OPTIMISTAS.Forma_Pago(Id_Factura,Id_Tipo_Pago)
SELECT Id_Factura, Id_Tipo_Pago FROM LOS_OPTIMISTAS.Facturacion F INNER JOIN
	(SELECT Factura_Nro, Forma_Pago_Desc FROM gd_esquema.Maestra
	GROUP BY Factura_Nro, Forma_Pago_Desc) M ON F.Id_Factura = M.Factura_Nro 
	INNER JOIN LOS_OPTIMISTAS.Tipo_Pago TP ON UPPER(M.Forma_Pago_Desc) = UPPER(TP.Descripcion)

--Agrego Funcionalidades al Administrador (FALTA!!)

INSERT INTO [GD1C2014].[LOS_OPTIMISTAS].[Rol_Funcionalidad] ([Id_Rol],[Id_Funcionalidad]) VALUES (1,1)

INSERT INTO [GD1C2014].[LOS_OPTIMISTAS].[Rol_Funcionalidad] ([Id_Rol],[Id_Funcionalidad]) VALUES (1,2)

INSERT INTO [GD1C2014].[LOS_OPTIMISTAS].[Rol_Funcionalidad] ([Id_Rol],[Id_Funcionalidad]) VALUES (1,3)

INSERT INTO [GD1C2014].[LOS_OPTIMISTAS].[Rol_Funcionalidad] ([Id_Rol],[Id_Funcionalidad]) VALUES (1,4)

INSERT INTO [GD1C2014].[LOS_OPTIMISTAS].[Rol_Funcionalidad] ([Id_Rol],[Id_Funcionalidad]) VALUES (1,5)