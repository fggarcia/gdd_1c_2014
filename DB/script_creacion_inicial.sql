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
	SELECT @Id_Tipo_Publicacion = Id_Tipo_Publicacion FROM LOS_OPTIMISTAS.Tipo_Publicacion WHERE UPPER(Descripcion) = UPPER(@tipo_publicacion)
	RETURN @Id_Tipo_Publicacion
END
GO

CREATE TABLE [LOS_OPTIMISTAS].[Usuario](
	[Id_Usuario][varchar](20) NOT NULL,
	[Password][varchar](64) NOT NULL,
	[Cantidad_Login][Int] NOT NULL,
	[Ultima_Fecha][smalldatetime] NULL,
	[Habilitado][bit] NULL
	
	CONSTRAINT UQ_Usuarios_Id_Usuario UNIQUE(Id_Usuario)
)

CREATE TABLE[LOS_OPTIMISTAS].[Usuario_temp](
	[Id_Usuario][varchar](20) NOT NULL,
	[Rol][Int] NOT NULL
)

--Devuelve dni
INSERT INTO LOS_OPTIMISTAS.Usuario_temp(Id_Usuario,Rol)
select Distinct(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),2 from gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--Devuelve numero razon social
INSERT INTO LOS_OPTIMISTAS.Usuario_temp(Id_Usuario,Rol)
select Distinct(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),3 from gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL

--Meto toda la lista de la temporal en Usuario
INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario,Password,Cantidad_Login,Ultima_Fecha,Habilitado)
select Usuario_temp.Id_Usuario,'5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01',0,NULL,1 from LOS_OPTIMISTAS.Usuario_temp

--Contraseña del usuario admin igual a la del resto
INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario, Password, Cantidad_Login, Ultima_Fecha,Habilitado)
VALUES ('admin','5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01',0,getDate(),1)

--TABLA ROL
CREATE TABLE [LOS_OPTIMISTAS].[Rol](
	[Id_Rol][Int] NOT NULL,
	[Descripcion][varchar](20) NOT NULL,
	[Fecha_Baja][smalldatetime] NULL

	CONSTRAINT UQ_Rol_Id_Rol UNIQUE(Id_Rol)
)

--CARGO LOS ROLES INICIALES
INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Fecha_Baja) VALUES(1,'administrador',NULL)
INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Fecha_Baja) VALUES(2,'cliente',NULL)
INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Fecha_Baja) VALUES(3,'empresa',NULL)

--TABLA USUARIO_ROL
CREATE TABLE [LOS_OPTIMISTAS].[Usuario_Rol](
	[Id_Usuario][varchar](20) NOT NULL,
	[Id_Rol][Int] NOT NULL,
	[Fecha_Baja][smalldatetime] NULL

	CONSTRAINT UQ_Usuario_Rol_Id_Usuario UNIQUE(Id_Usuario),
	CONSTRAINT [FK_Usuario_Rol_Usuario_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
	CONSTRAINT [FK_Usuario_Rol_Rol_Id_Rol] FOREIGN KEY(Id_Rol)
		REFERENCES [LOS_OPTIMISTAS].[Rol] (Id_Rol)
)

--INGRESO LOS USUARIOS CARGADOS EN LA TABLA PERSONAL CON ROLES SEGUN CORRESPONDA
INSERT INTO LOS_OPTIMISTAS.Usuario_Rol(Id_Usuario,Id_Rol,Fecha_Baja)
SELECT Usuario_temp.Id_Usuario, Usuario_temp.Rol,NULL FROM LOS_OPTIMISTAS.Usuario_temp

--AGREGO AL USUARIO ADMIN A LA TABLA DE ROLES
INSERT INTO LOS_OPTIMISTAS.Usuario_Rol(Id_Usuario,Id_Rol,Fecha_Baja) VALUES ('admin',1,NULL)

--DESTRUYO TABLA TEMPORAL
DROP TABLE LOS_OPTIMISTAS.Usuario_temp

--TABLA FUNCIONALIDAD
CREATE TABLE [LOS_OPTIMISTAS].[Funcionalidad](
	[Id_Funcionalidad][Int] NOT NULL,
	[Descripcion][varchar](40) NOT NULL

	CONSTRAINT UQ_Funcionalidad_Id_Funcionalidad UNIQUE(Id_Funcionalidad)	
)

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
	[Fecha_Nacimiento][smalldatetime]
	
		CONSTRAINT [FK_Cliente_Usuario_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
		
		CONSTRAINT [FK_Cliente_Id_Tipo_Documento] FOREIGN KEY(Id_Tipo_Documento)
		REFERENCES [LOS_OPTIMISTAS].[Tipo_Documento](Id_Tipo_Documento),
		
		CONSTRAINT UQ_Cliente_Dni UNIQUE(Dni),
		CONSTRAINT UQ_Cliente_Id_Usuario UNIQUE(Id_Usuario)
)

--CARGO LOS CLIENTES
INSERT INTO LOS_OPTIMISTAS.Cliente(Id_Usuario,Id_Tipo_Documento,Dni,Nombre,Apellido,Fecha_Nacimiento)
select Distinct(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),'DNI',LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),Publ_Cli_Nombre,Publ_Cli_Apeliido,Publ_Cli_Fecha_Nac from gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL





--TABLA EMPRESA
CREATE TABLE [LOS_OPTIMISTAS].[Empresa](
[ID_Usuario] [varchar](20) NOT NULL,
[Razon_social] [varchar](255) NOT NULL ,
[Cuit] [varchar](50) NOT NULL,
[Fecha_Creacion][smalldatetime],
[Nombre_Contacto][varchar](255) NULL, 

CONSTRAINT [FK_Empresa_Cliente_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
		CONSTRAINT UQ_Empresa_Razon_social UNIQUE(Razon_social),
		CONSTRAINT UQ_Empresa_Cuit UNIQUE(Cuit)
		
)
--CARGO LAS EMPRESAS
INSERT INTO LOS_OPTIMISTAS.Empresa(ID_Usuario,Razon_social,Cuit,Fecha_Creacion)
select Distinct(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),Publ_Empresa_Razon_Social,Publ_Empresa_Cuit,Publ_Empresa_Fecha_Creacion from gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL

--CREO TABLA DOM_MAIL
CREATE TABLE [LOS_OPTIMISTAS].[Dom_Mail](

[Id_Usuario][varchar](20) NOT NULL ,
[Domicilio][varchar](100)  NULL,
[Telefono][varchar](40)  NULL,
[Cp] [varchar](50)  NULL,
[Mail] [varchar](255) NULL, 
[Localidad] [varchar](255) NULL,
[Calle][varchar](255) NULL,
[Piso][numeric](18,0) NULL,
[Depto][varchar](50) NULL

CONSTRAINT [FK_Dom_Mail_Empresa_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario)
)

--CARGO TABLA Dom_Mail con los datos de Clientes

INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Telefono,Cp,Mail,Localidad,Calle,Piso,Depto)
select Distinct(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),Publ_Cli_Dom_Calle,null,Publ_Cli_Cod_Postal,Publ_Cli_Mail,null,Publ_Cli_Nro_Calle,Publ_Cli_Piso,Publ_Cli_Depto from gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--CARGO TABLA Dom_Mail con los datos de las Empresas

INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Telefono,Cp,Mail,Localidad,Calle,Piso,Depto)
select Distinct(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),Publ_Empresa_Dom_Calle,null,Publ_Empresa_Cod_Postal,Publ_Empresa_Mail,null,Publ_Empresa_Dom_Calle,Publ_Empresa_Piso,Publ_Empresa_Depto from gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL


--CREO TABLA Visibilidad
CREATE TABLE [LOS_OPTIMISTAS].[Visibilidad](
[Id_Visibilidad][numeric](18,0) NOT NULL,
[Descripcion][varchar](255) NOT NULL,
[Precio][numeric](18,2) NOT NULL,
[Porcentaje][numeric](18,2) NOT NULL,
[Peso][Int] NOT NULL,

CONSTRAINT [PK_Visibilidad_Id_Visibilidad] PRIMARY KEY(Id_Visibilidad),
CONSTRAINT [UQ_Visibilidad_Id_Visibilidad] UNIQUE (Id_Visibilidad)
)

--INSERTO 0 EN EL PESO PARA ACONTINUACION MODIFICARLO
INSERT INTO LOS_OPTIMISTAS.Visibilidad(Id_Visibilidad, Descripcion, Precio, Porcentaje, Peso)
SELECT DISTINCT(Publicacion_Visibilidad_Cod), Publicacion_Visibilidad_Desc,
	Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Precio,0
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

--CREO TABLA PUBLICACION

CREATE TABLE [LOS_OPTIMISTAS].[Publicacion](

[Id_Publicacion][numeric] (18,0) NOT NULL,
[Id_Usuario][varchar](20) NOT NULL,
[Id_Tipo_Publicacion][int] NOT NULL,
[Id_Articulo][numeric](18,0) NOT NULL,             
[Id_Visibilidad][numeric](18,0)NOT NULL,
[Id_Estado][varchar](255)NOT NULL,
[Precio][numeric](18,2) NULL,
[Fecha_Inicio][smalldatetime] NULL,
[Fecha_Vencimiento][smalldatetime] NULL,
[Pemite_Preguntas][Bit] NULL,
[Cant_por_Venta][numeric] (18,0) NULL,
[stock][numeric](18,0) NOT NULL,
[Descripcion][varchar](255) NULL


CONSTRAINT [FK_Publicacion_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),

CONSTRAINT [PK_Publicacion_Id_Publicacion] UNIQUE(Id_Publicacion),
		
CONSTRAINT [FK_Publicacion_Id_Visibilidad] FOREIGN KEY(Id_Visibilidad)
		REFERENCES [LOS_OPTIMISTAS].[Visibilidad](Id_Visibilidad),

CONSTRAINT [FK_Publicacion_Id_Tipo_Publicacion] FOREIGN KEY(Id_Tipo_Publicacion)
		REFERENCES [LOS_OPTIMISTAS].[Tipo_Publicacion](Id_Tipo_Publicacion)
		
)
--INSERTO EN PUBLICACION LOS CASOS EN QUE EL USUARIO ES EL QUE PUBLICA
INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Publicacion,Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,Id_Estado,Precio,Fecha_Inicio,Fecha_Vencimiento,Pemite_Preguntas,Cant_por_Venta,stock,Descripcion)
select Distinct (CONVERT(numeric(18,0),Publicacion_Cod)),LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),LOS_OPTIMISTAS.obtenerIdTipoPublicacion(Publicacion_Tipo),LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),Publicacion_Visibilidad_Cod,Publicacion_Estado,Publicacion_Precio,Publicacion_Fecha,Publicacion_Fecha_Venc,LOS_OPTIMISTAS.obtenerCondicionPreguntas(Publicacion_Estado),1,Publicacion_Stock,Publicacion_Rubro_Descripcion from gd_esquema.Maestra WHERE (Publicacion_Cod IS NOT NULL AND Publ_Cli_Dni IS NOT NULL AND Publ_Empresa_Cuit IS NULL) 
--SE PONE EL VALOR 1 COMO CANTIDAD DE VENTA POR PUBLICACION DEFAULT

--INSERTO EN PUBLICACION LOS CASOS EN QUE LA EMPRESA ES LA QUE PUBLICA
INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Publicacion,Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,Id_Estado,Precio,Fecha_Inicio,Fecha_Vencimiento,Pemite_Preguntas,Cant_por_Venta,stock,Descripcion)
select Distinct (CONVERT(numeric(18,0),Publicacion_Cod)),LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit),LOS_OPTIMISTAS.obtenerIdTipoPublicacion(Publicacion_Tipo),LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),Publicacion_Visibilidad_Cod,Publicacion_Estado,Publicacion_Precio,Publicacion_Fecha,Publicacion_Fecha_Venc,LOS_OPTIMISTAS.obtenerCondicionPreguntas(Publicacion_Estado),1,Publicacion_Stock,Publicacion_Rubro_Descripcion from gd_esquema.Maestra WHERE (Publicacion_Cod IS NOT NULL AND Publ_Empresa_Cuit IS NOT NULL AND Publ_Cli_Dni IS NULL)



CREATE TABLE [LOS_OPTIMISTAS].[Publicacion_Calificaciones](
[Id_Publicacion][numeric] (18,0) NOT NULL,
[Id_Calificacion][numeric](18,0)NOT NULL,
[Id_Usuario_Calificador][varchar](20) NOT NULL,
[Fecha_Calificacion][smalldatetime] NULL,
[Detalle][varchar] (255) NULL,
[Calificacion][Numeric](18,0)  NULL

CONSTRAINT [FK_Publicacion_Calificaciones_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
		REFERENCES [LOS_OPTIMISTAS].[Publicacion] (Id_Publicacion),

CONSTRAINT [FK_Publicacion_Calificaciones_Id_Calificacion] PRIMARY KEY (Id_Calificacion),	

CONSTRAINT [FK_Publicacion_Calificaciones_Id_Usuario_Calificador] FOREIGN KEY(Id_Usuario_Calificador)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
		
	
)

--Inserto en publicacion_Calificaciones COnsideramos poner la fecha de compra como la de calificacion en todos los casos de migracion
INSERT INTO LOS_OPTIMISTAS.Publicacion_Calificaciones(Id_Calificacion,Id_Publicacion,Id_Usuario_Calificador,Fecha_Calificacion,Detalle,Calificacion)
select Distinct (CONVERT(numeric(18,0),Calificacion_Codigo)),Publicacion_Cod,Cli_Dni,Compra_Fecha,Calificacion_Descripcion,Calificacion_Cant_Estrellas from gd_esquema.Maestra WHERE (Calificacion_codigo IS NOT NULL )


--CREO TABLA Publicacion_Pregunta (No la cargo porque no existen preguntas)
CREATE TABLE [LOS_OPTIMISTAS].[Publicacion_Preguntas](

[Id_Pregunta][int]IDENTITY(1,1) NOT NULL,
[Id_Publicacion][numeric] (18,0) NOT NULL,
[Id_Usuario][varchar](20) NOT NULL,
[Fecha_Creacion][smalldatetime],
[Preg_Descripcion][varchar](255) NULL,
[Preg_Respuesta][varchar](255) NULL,
[Fecha_Respuesta][smalldatetime]

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
[Fecha_Oferta][smalldatetime],


CONSTRAINT [FK_Historial_Subasta_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
		REFERENCES [LOS_OPTIMISTAS].[Publicacion] (Id_Publicacion),

CONSTRAINT [FK_Historial_Subasta_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario)

)

--Inserto en Historial_Publicacion Y TAMBIEN PASO VALORES DONDE EXSITE UNA OFERTA(esta el dni) PERO QUE NO TIENE PRECIO ni FECHA

INSERT INTO LOS_OPTIMISTAS.Historial_Subasta(Id_Publicacion,Id_Usuario,Precio_Oferta,Fecha_Oferta)
select Publicacion_Cod, Cli_Dni,Oferta_Monto,Oferta_Fecha from gd_esquema.Maestra WHERE (Publicacion_Tipo = 'Subasta' and Cli_Dni IS NOT NULL )

--CREO TABLA Rubro
CREATE TABLE [LOS_OPTIMISTAS].[Rubro](

[Id_Rubro][Int] NOT NULL,
[Descripcion][varchar](60) NOT NULL,
[Fecha_Baja][smalldatetime] NULL,

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

--CREO TABLA estado
CREATE TABLE [LOS_OPTIMISTAS].[Estado](
[Id_Estado][INT] IDENTITY(1,1) NOT NULL,
[Descripcion][varchar](30) NOT NULL,

CONSTRAINT [UQ_Estado_descripcion] UNIQUE (Descripcion),
CONSTRAINT [PK_Estado_Id_Estado] PRIMARY KEY(Id_Estado)
)

INSERT INTO LOS_OPTIMISTAS.Estado(Descripcion)
SELECT DISTINCT UPPER(Publicacion_Estado) FROM gd_esquema.Maestra WHERE Publicacion_Estado IS NOT NULL

--CREO TABLA estado_publicacion
CREATE TABLE [LOS_OPTIMISTAS].[Estado_Publicacion](

[Id_Publicacion][numeric](18,0) NOT NULL,
[Id_Estado][Int] NOT NULL,

CONSTRAINT [FK_Estado_Publicacion_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
	REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion),
CONSTRAINT [FK_Estado_Publicacion_Id_Estado] FOREIGN KEY(Id_Estado)
	REFERENCES [LOS_OPTIMISTAS].[Estado](Id_Estado),
CONSTRAINT [UQ_Estado_Publicacion_Id_Publicacion] UNIQUE (Id_Publicacion)	
)

--verifique en la tabla y no habia iguales
INSERT INTO LOS_OPTIMISTAS.Estado_Publicacion(Id_Publicacion, Id_Estado)
SELECT DISTINCT(Publicacion_Cod), Id_Estado FROM gd_esquema.Maestra maestra INNER JOIN LOS_OPTIMISTAS.Estado Estado ON (UPPER(maestra.Publicacion_Estado) = UPPER(Estado.Descripcion))



--CREO TABLA stock
CREATE TABLE [LOS_OPTIMISTAS].[Stock](

[Id_Articulo][numeric](18,0) NOT NULL,
[Id_Usuario][varchar](20) NOT NULL,
[Cantidad][numeric](18,0) NOT NULL,

CONSTRAINT [FK_Stock_Id_Usuario] FOREIGN KEY(Id_Usuario)
	REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
CONSTRAINT [PK_Stock_Id_Articulo] PRIMARY KEY(Id_Articulo)
)

CREATE TABLE [LOS_OPTIMISTAS].[Stock_Temp](

[Id_Articulo][numeric](18,0) NOT NULL,
[Id_Usuario][varchar](20) NOT NULL
)

--por default el stock de cada articulo es 100
INSERT INTO LOS_OPTIMISTAS.Stock_Temp(Id_Articulo, Id_Usuario)
select LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni) FROM gd_esquema.Maestra WHERE (Publicacion_Descripcion IS NOT NULL AND Publ_Cli_Dni IS NOT NULL AND Publ_Empresa_Cuit IS NULL) 

INSERT INTO LOS_OPTIMISTAS.Stock_Temp(Id_Articulo, Id_Usuario)
select LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit) from gd_esquema.Maestra WHERE (Publicacion_Descripcion IS NOT NULL AND Publ_Empresa_Cuit IS NOT NULL AND Publ_Cli_Dni IS NULL)

INSERT INTO LOS_OPTIMISTAS.Stock(Id_Articulo, Id_Usuario, Cantidad)
SELECT DISTINCT(Id_Articulo),Id_Usuario, 100 FROM LOS_OPTIMISTAS.Stock_Temp

DROP TABLE LOS_OPTIMISTAS.Stock_Temp 

--CREO TABLA FACTURACION
CREATE TABLE [LOS_OPTIMISTAS].[Facturacion](
[Id_Factura][numeric](18,0) NOT NULL,
[Id_Usuario][varchar](20) NOT NULL,
[Total_Factura][numeric](18,2) NOT NULL,
[Total_Comisiones][numeric](18,2) NULL,
[Total_Visibilidad][numeric](18,2) NULL,
[Fecha][smalldatetime] NOT NULL,

CONSTRAINT [PK_Facturacion_Id_Factura] PRIMARY KEY(Id_Factura),
CONSTRAINT [FK_Facturacion_Id_Usuario] FOREIGN KEY(Id_Usuario)
REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario)
)

--CREO TABLA FACTURACION PENDIENTE
CREATE TABLE [LOS_OPTIMISTAS].[Facturacion_Pendiente](
[Id_Usuario][varchar](20) NOT NULL,
[Id_Usuario_Comprador][varchar](20) NOT NULL,
[Id_Publicacion][numeric](18,0) NULL,
[Comision][numeric](18,2) NOT NULL,
[Visibilidad][varchar](255) NOT NULL,
[Cantidad][int] NULL,
[Precio_Publicacion][numeric](18,2) NULL,
[Precio_Visibilidad][numeric](18,2) NULL,

CONSTRAINT [FK_Facturacion_Pendiente_Id_Usuario] FOREIGN KEY(Id_Usuario)
REFERENCES [LOS_OPTIMISTAS].[Usuario](Id_Usuario),
CONSTRAINT [FK_Facturacion_Pendiente_Id_Publicacion] FOREIGN KEY(Id_Publicacion)
REFERENCES [LOS_OPTIMISTAS].[Publicacion](Id_Publicacion)
)

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



/*Store Procedure para ABM Clientes*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarClientes]

(
@p_Nombre varchar(255) = null,
@p_Apellido varchar(255)= null,
@p_Tipo_Documento varchar(6)=null,
@p_Numero_Documento varchar (20) = null,
@p_Mail varchar(255) = null
)

AS
BEGIN

			SELECT DISTINCT
			Clie.Id_Usuario 'Id Usuario',
			Clie.Nombre 'Nombre',
			Clie.Apellido 'Apellido',
			Clie.Id_Tipo_Documento 'Tipo Documento',
			Clie.Dni 'Numero Documento',
			Clie.Fecha_Nacimiento 'Fecha Nac',
			Dom_Mail.Mail 'Email'
 
			FROM LOS_OPTIMISTAS.Cliente Clie, LOS_OPTIMISTAS.Dom_Mail Dom_Mail, LOS_OPTIMISTAS.Usuario Usuar
			
			WHERE
			((@p_Nombre IS NULL) OR ( clie.Nombre like @p_Nombre + '%'))
			AND  ((@p_Apellido IS NULL) OR (clie.Apellido like @p_Apellido + '%'))
			AND  ((@p_Tipo_Documento IS NULL) OR ( clie.Id_Tipo_Documento = @p_Tipo_Documento))
			AND  ((@p_Numero_Documento IS NULL) OR (clie.Dni = @p_Numero_Documento))
			AND  ((@p_Mail IS NULL) OR (Dom_Mail.Mail = @p_Mail))
			AND (clie.Id_Usuario = Dom_Mail.Id_Usuario)
			AND (Usuar.Id_Usuario = clie.Id_Usuario)
			AND (Usuar.Habilitado = 1)
 END
 GO
 
 
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[AltaCliente]
(
@p_Nombre varchar(255) = null,
@p_Apellido varchar(255)= null,
@p_Tipo_Documento varchar(6)= null,
@p_Numero_Documento varchar (20) = null,
@p_Mail varchar(255) = null,
@p_Telefono varchar(40)= null,
@p_Domicilio_Calle varchar(255)= null,
@p_Nro_Calle varchar (100) = null,
@p_Piso numeric(18,0) = 0 ,
@p_Depto varchar(50) = null,
@p_Localidad varchar(255) = null,
@p_CP varchar(50) = null,
@p_Fecha_Nacimiento smalldatetime,
@p_Id_Usuario varchar(20),
@p_Password varchar(64)

 )
AS
BEGIN
	
	INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario,Password,Cantidad_Login,Ultima_Fecha,Habilitado)
	Values(@p_Id_Usuario,@p_Password,'0',GETDATE(),1)
							
	INSERT INTO LOS_OPTIMISTAS.Cliente(Id_Usuario,Id_Tipo_Documento,Dni,Nombre,Apellido,Fecha_Nacimiento)
	Values(@p_Id_Usuario,@p_Tipo_Documento,@p_Numero_Documento,@p_Nombre,@p_Apellido,@p_Fecha_Nacimiento)
	
	INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Depto,Cp,Calle,Localidad,Mail,Piso,Telefono)
	Values(@p_Id_Usuario,@p_Domicilio_Calle,@p_Depto,@p_CP,@p_Nro_Calle,@p_Localidad ,@p_Mail,@p_Piso,@p_Telefono)
	
END




GO
/*Sirve tanto para CLIENTES como para EMPRESAS*/
CREATE PROCEDURE [LOS_OPTIMISTAS].[BajaUsuario]
(
@p_Id_Usuario varchar (20)= null
)
AS
BEGIN
		IF EXISTS( select * from LOS_OPTIMISTAS.Usuario Where( Id_Usuario = @p_Id_Usuario)) 
		UPDATE LOS_OPTIMISTAS.Usuario set Habilitado = 0 Where ( Id_Usuario = @p_Id_Usuario)
		ELSE
		PRINT ' No se encontro el Usuario'
END
GO

GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[ModificarCliente]
(
@p_Nombre varchar(255) = null,
@p_Apellido varchar(255)= null,
@p_Tipo_Documento varchar(6)= null,
@p_Numero_Documento varchar (20) = null,
@p_Mail varchar(255) = null,
@p_Telefono varchar(40)= null,
@p_Domicilio_Calle varchar(255)= null,
@p_Nro_Calle varchar (100) = null,
@p_Piso numeric(18,0) = 0 ,
@p_Depto varchar(50) = null,
@p_Localidad varchar(255) = null,
@p_CP varchar(50) = null,
@p_Fecha_Nacimiento smalldatetime,
@p_Id_Usuario varchar(20),
@p_Password varchar(64)
)
AS
BEGIN

		BEGIN TRANSACTION
							
				
			IF (@p_Password != '') UPDATE LOS_OPTIMISTAS.Usuario SET [Password] = @p_Password WHERE Id_Usuario = @p_Id_Usuario
						
			IF (@p_Numero_Documento != '') UPDATE LOS_OPTIMISTAS.Cliente SET [Dni] = @p_Numero_Documento WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Nombre != '') UPDATE LOS_OPTIMISTAS.Cliente SET [Nombre] = @p_Nombre WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Apellido != '') UPDATE LOS_OPTIMISTAS.Cliente SET [Apellido] = @p_Apellido WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Fecha_Nacimiento != '') UPDATE LOS_OPTIMISTAS.Cliente SET [Fecha_Nacimiento] = @p_Fecha_Nacimiento WHERE Id_Usuario = @p_Id_Usuario
			
			IF (@p_Tipo_Documento != '') UPDATE LOS_OPTIMISTAS.Cliente SET [Id_Tipo_Documento] = @p_Tipo_Documento WHERE Id_Usuario = @p_Id_Usuario	
			
			IF (@p_Localidad != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Localidad] = @p_Localidad WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Mail != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Mail] = @p_Mail WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Piso != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Piso] = @p_Piso WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Telefono != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Telefono] = @p_Telefono WHERE Id_Usuario = @p_Id_Usuario
			
			IF (@p_Domicilio_Calle != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Domicilio] = @p_Domicilio_Calle WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Depto != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Depto] = @p_Domicilio_Calle WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_CP != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Cp] = @p_CP WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Nro_Calle != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Calle] = @p_Domicilio_Calle WHERE Id_Usuario = @p_Id_Usuario
								
										
					
		COMMIT TRANSACTION
					
		
END
GO








/* Store Procedure para ABM Empresa*/ 
GO 
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarEmpresas]

(
@p_Razon_Social varchar(255) = null,
@p_Cuit varchar(50)= null,
@p_Email varchar(255)=null
)

AS
BEGIN

			SELECT DISTINCT
			
			Empr.Id_Usuario 'Id Usuario',
			Empr.Razon_social 'Razon Social',
			Empr.Cuit 'CUIT',
			Empr.Fecha_Creacion'Fecha Creacion',
			Dom_Mail.Mail 'Mail',
			Dom_Mail.Cp 'Codigo Postal',
			Dom_Mail.Domicilio 'Domicilio',
			Dom_Mail.Localidad 'Localidad',
			Dom_Mail.Telefono 'Telefono'
			
			
			FROM LOS_OPTIMISTAS.Empresa Empr, LOS_OPTIMISTAS.Dom_Mail Dom_Mail, LOS_OPTIMISTAS.Usuario Usar
			
			WHERE
			((@p_Razon_Social IS NULL) OR ( Empr.Razon_social=@p_Razon_Social ))
			AND  ((@p_Cuit IS NULL) OR (Empr.Cuit= @p_Cuit ))
			AND  ((@p_Email IS NULL) OR ( Dom_Mail.Mail =@p_Email))
			AND  (Empr.ID_Usuario= Dom_Mail.Id_Usuario)
			AND (Usar.Id_Usuario = Empr.ID_Usuario)
			AND (Usar.Habilitado = 1)
			
 END
 GO


 
 
 
 --En AltaEmpresa no se agrega un ROL a ese usuario, ya que no es un requerimiento, Si en ALTA USUARIO se debe agregar un ROL
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[AltaEmpresa]
 (

@p_Razon_Social varchar(255) = null ,
@p_Cuit varchar(50) = null,
@p_Fecha_Creacion smalldatetime = null,
@p_Domicilio varchar(100) = null,
@p_Telefono varchar(40) = null,
@p_CP varchar(50) = null,
@p_Mail varchar(255) = null, 
@p_Localidad varchar (255) = null,
@p_Calle varchar(255) = null,
@p_Piso numeric (18,0) = null,
@p_Depto varchar(50) = null,
@p_Id_Usuario varchar (20),
@p_Password varchar (64)
 )
AS
BEGIN

	INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario,Password,Cantidad_Login,Ultima_Fecha,Habilitado)
	values(@p_Id_Usuario,@p_Password,'0',GETDATE(),1)
		
	INSERT INTO LOS_OPTIMISTAS.Empresa(ID_Usuario,Razon_social,Cuit,Fecha_Creacion)
	values(@p_Id_Usuario,@p_Razon_Social,@p_Cuit,@p_Fecha_Creacion)
		
	INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Depto,Cp,Calle,Localidad,Mail,Piso,Telefono)
	Values(@p_Id_Usuario,@p_Domicilio,@p_Depto,@p_CP,@p_Calle,@p_Localidad ,@p_Mail,@p_Piso,@p_Telefono)
							
END
 
GO
 
 
 GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[ModificarEmpresa]
(
@p_Razon_Social varchar(255) = null ,
@p_Cuit varchar(50) = null,
@p_Fecha_Creacion smalldatetime = null,
@p_Nombre_Contacto varchar(255) = null,
@p_Domicilio varchar(100) = null,
@p_Telefono varchar(40) = null,
@p_CP varchar(50) = null,
@p_Mail varchar(255) = null, 
@p_Localidad varchar (255) = null,
@p_Calle varchar(255) = null,
@p_Piso numeric (18,0) = null,
@p_Depto varchar(50) = null,
@p_Id_Usuario varchar (20),
@p_Password varchar (64)
)
AS
BEGIN

		BEGIN TRANSACTION
							
							
							UPDATE LOS_OPTIMISTAS.Usuario
							SET 
							Password = @p_Password
																			
							WHERE Id_Usuario = @p_Id_Usuario
							
								
							
							UPDATE LOS_OPTIMISTAS.Empresa
							SET 
							[Razon_social] = @p_Razon_Social ,
							[Cuit] = @p_Cuit,
							[Fecha_Creacion] = @p_Fecha_Creacion,
							[Nombre_Contacto] = @p_Nombre_Contacto
							
							WHERE ID_Usuario =  @p_Id_Usuario
							
																		
										
							UPDATE LOS_OPTIMISTAS.Dom_Mail
							SET 
							[Domicilio] = @p_Domicilio,
							[Depto] = @p_Depto,
							[Cp] = @p_CP,
							[Calle] = @p_Calle,
							[Localidad] = @p_Localidad,	
							[Mail] = @p_Mail,		
							[Piso] = @p_Piso,		
							[Telefono] =@p_Telefono			
							
							WHERE Id_Usuario = @p_Id_Usuario
										
										
							
					
		COMMIT TRANSACTION
					
		
END
GO
 /* Store Procedure para ABM Rol*/ 
 /*VERIFICAR SI ANDA BIEN Cargando datos en las tablas*/
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[ListarRoles]
 
 AS
 BEGIN
		Select  Rol.Id_Rol,Rol.Descripcion,Rol.Fecha_Baja,Rol_Func.Id_Funcionalidad,Func.Descripcion
		from LOS_OPTIMISTAS.Rol Rol, LOS_OPTIMISTAS.Rol_Funcionalidad Rol_Func,LOS_OPTIMISTAS.Funcionalidad Func
		Where
		(Rol.Id_Rol = Rol.Id_Rol)
		And (Rol_Func.Id_Funcionalidad = Func.Descripcion)
 END
 GO
 

 
 
 
