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

CREATE TABLE [LOS_OPTIMISTAS].[Usuario](
	[Id_Usuario][varchar](20) NOT NULL,
	[Password][varchar](64) NOT NULL,
	[Cantidad_Login][Int] NOT NULL,
	[Ultima_Fecha][datetime] NULL

	CONSTRAINT UQ_Usuarios_Id_Usuario UNIQUE(Id_Usuario)
)

CREATE TABLE[LOS_OPTIMISTAS].[Usuario_temp](
	[Id_Usuario][varchar](20) NOT NULL,
	[Rol][Int] NOT NULL
)

--Devuelve dni
INSERT INTO LOS_OPTIMISTAS.Usuario_temp(Id_Usuario,Rol)
select Distinct(LTRIM(STR(CONVERT(INT,STR(Publ_Cli_Dni,20))))),2 from gd_esquema.Maestra WHERE Publ_Cli_Dni IS NOT NULL

--Devuelve numero razon social
INSERT INTO LOS_OPTIMISTAS.Usuario_temp(Id_Usuario,Rol)
select Distinct(LTRIM(STR(CONVERT(INT,SubString(Publ_Empresa_Cuit,4,8))))),3 from gd_esquema.Maestra WHERE Publ_Empresa_Cuit IS NOT NULL

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
	[Fecha_Baja][datetime] NULL

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

	CONSTRAINT [FK_Rol_Funcionalidad_Funcionalidad_Id_Funcionalidad] FOREIGN KEY(Id_Funcionalidad)
		REFERENCES [LOS_OPTIMISTAS].[Funcionalidad] (Id_Funcionalidad),
	CONSTRAINT [FK_Rol_Funcionalidad_Rol_Id_Rol] FOREIGN KEY(Id_Rol)
		REFERENCES [LOS_OPTIMISTAS].[Rol] (Id_Rol),
	CONSTRAINT UQ_Rol_Funcionalidad_Id_Rol_Id_Funcionalidad UNIQUE(Id_Rol,Id_Funcionalidad)
)

