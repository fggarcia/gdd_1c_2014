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

CREATE TABLE [LOS_OPTIMISTAS].[Usuario](
	[Id_Usuario][varchar](20) NOT NULL,
	[Password][varchar](64) NOT NULL,
	[Cantidad_Login][Int] NOT NULL,
	[Ultima_Fecha][smalldatetime] NULL
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
INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario,Password,Cantidad_Login,Ultima_Fecha)
select Usuario_temp.Id_Usuario,'5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01',0,NULL from LOS_OPTIMISTAS.Usuario_temp

--Contraseña del usuario admin igual a la del resto
INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario, Password, Cantidad_Login, Ultima_Fecha)
VALUES ('admin','5e4ac4f46b377c21b587cdaf94cc4e0d9bff2434dc00393dc4eef7b90f39ee01',0,getDate())

--TABLA ROL
CREATE TABLE [LOS_OPTIMISTAS].[Rol](
	[Id_Rol][Int] NOT NULL,
	[Descripcion][varchar](20) NOT NULL,
	[Fecha_Baja][datetime] NULL

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

--TABLA CLIENTE
CREATE TABLE [LOS_OPTIMISTAS].[Cliente](
	[Id_Usuario][varchar](20) NOT NULL,
	[Dni][varchar](20) NOT NULL,---El DNI y el Id_Usuario es lo mismo, los cargo igual, VER!!!! si hay que cambiar a numeric
	[Nombre][varchar](255),
	[Apellido][varchar](255),
	[Fecha_Nacimiento][smalldatetime]
	
		CONSTRAINT [FK_Cliente_Usuario_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
		
		CONSTRAINT UQ_Cliente_Dni UNIQUE(Dni),
		CONSTRAINT UQ_Cliente_Id_Usuario UNIQUE(Id_Usuario)
)

--CARGO LOS CLIENTES
INSERT INTO LOS_OPTIMISTAS.Cliente(Id_Usuario,Dni,Nombre,Apellido,Fecha_Nacimiento)
select Distinct(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),Publ_Cli_Nombre,Publ_Cli_Apeliido,Publ_Cli_Fecha_Nac from gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--TABLA EMPRESA
CREATE TABLE [LOS_OPTIMISTAS].[Empresa](
[ID_Usuario] [varchar](20) NOT NULL,
[Razon_social] [varchar](255) NOT NULL ,
[Cuit] [varchar](50) NOT NULL,
[Fecha_Creacion][smalldatetime]

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
[Localidad] [varchar](255) NULL

CONSTRAINT [FK_Dom_Mail_Empresa_Id_Usuario] FOREIGN KEY(Id_Usuario)
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario)
)

--CARGO TABLA Dom_Mail con los datos de Clientes

INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Telefono,Cp,Mail,Localidad)
select Distinct(LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni)),Cli_Dom_Calle,null,Cli_Cod_Postal,Cli_Mail,null from gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--CARGO TABLA Dom_Mail con los datos de las Empresas

INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Telefono,Cp,Mail,Localidad)select Distinct(LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit)),Publ_Empresa_Dom_Calle,null,Publ_Empresa_Cod_Postal,Publ_Empresa_Mail,null from gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL


--CREO TABLA Visibilidad 

CREATE TABLE [LOS_OPTIMISTAS].[Visibilidad](

[Id_Visibilidad][numeric](18,0) NOT NULL,
[Descripcion][varchar](255) NULL,
[Precio] [numeric](18,2),
[Porcentaje][numeric](18,2)

CONSTRAINT [UQ_Visibilidad_Id_Visibilidad] UNIQUE (Id_Visibilidad),

)

INSERT INTO LOS_OPTIMISTAS.Visibilidad(Id_Visibilidad,Descripcion,Precio,Porcentaje)
select Distinct (Publicacion_Visibilidad_Cod),Publicacion_Visibilidad_Desc,Publicacion_Visibilidad_Precio,Publicacion_Visibilidad_Porcentaje from gd_esquema.Maestra WHERE (Publicacion_Visibilidad_Cod IS NOT NULL )



--CREO TABLA PUBLICACION

CREATE TABLE [LOS_OPTIMISTAS].[Publicacion](

[Id_Publicacion][numeric] (18,0) NOT NULL,
[Id_Usuario][varchar](20) NOT NULL,
[Id_Tipo_Publicacion][varchar](255) NOT NULL,
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
		REFERENCES [LOS_OPTIMISTAS].[Usuario] (Id_Usuario),
		CONSTRAINT PK_Publicacion_Id_Publicacion UNIQUE(Id_Publicacion),
		
CONSTRAINT [FK_Publicacion_Id_Visibilidad] FOREIGN KEY(Id_Visibilidad)
		REFERENCES [LOS_OPTIMISTAS].[Visibilidad] (Id_Visibilidad),
		
)
--INSERTO EN PUBLICACION LOS CASOS EN QUE EL USUARIO ES EL QUE PUBLICA
INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Publicacion,Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,Id_Estado,Precio,Fecha_Inicio,Fecha_Vencimiento,Pemite_Preguntas,Cant_por_Venta,stock,Descripcion)
select Distinct (CONVERT(numeric(18,0),Publicacion_Cod)),LOS_OPTIMISTAS.obtenerDNI(Publ_Cli_Dni),Publicacion_Tipo,LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),Publicacion_Visibilidad_Cod,Publicacion_Estado,Publicacion_Precio,Publicacion_Fecha,Publicacion_Fecha_Venc,LOS_OPTIMISTAS.obtenerCondicionPreguntas(Publicacion_Estado),1,Publicacion_Stock,Publicacion_Rubro_Descripcion from gd_esquema.Maestra WHERE (Publicacion_Cod IS NOT NULL AND Publ_Cli_Dni IS NOT NULL AND Publ_Empresa_Cuit IS NULL) 
--SE PONE EL VALOR 1 COMO CANTIDAD DE VENTA POR PUBLICACION DEFAULT

--INSERTO EN PUBLICACION LOS CASOS EN QUE LA EMPRESA ES LA QUE PUBLICA
INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Publicacion,Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,Id_Estado,Precio,Fecha_Inicio,Fecha_Vencimiento,Pemite_Preguntas,Cant_por_Venta,stock,Descripcion)
select Distinct (CONVERT(numeric(18,0),Publicacion_Cod)),LOS_OPTIMISTAS.obtenerCuit(Publ_Empresa_Cuit),Publicacion_Tipo,LOS_OPTIMISTAS.obtenerCodigoArticulo(Publicacion_Descripcion),Publicacion_Visibilidad_Cod,Publicacion_Estado,Publicacion_Precio,Publicacion_Fecha,Publicacion_Fecha_Venc,LOS_OPTIMISTAS.obtenerCondicionPreguntas(Publicacion_Estado),1,Publicacion_Stock,Publicacion_Rubro_Descripcion from gd_esquema.Maestra WHERE (Publicacion_Cod IS NOT NULL AND Publ_Empresa_Cuit IS NOT NULL AND Publ_Cli_Dni IS NULL)



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


