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
@p_Piso varchar(20) = null,
@p_Depto varchar(50) = null,
@p_Localidad varchar(255) = null,
@p_CP varchar(50) = null,
@p_Fecha_Nacimiento datetime,
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
	
	INSERT INTO LOS_OPTIMISTAS.Usuario_Rol(Id_Rol,Id_Usuario,Habilitado)
	Values(2,@p_Id_Usuario,1)
	
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
@p_Piso varchar (20),
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
			IF (@p_Depto != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Depto] = @p_Depto WHERE Id_Usuario = @p_Id_Usuario
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
			Dom_Mail.Domicilio 'Domicilio'
			
			
			
			FROM LOS_OPTIMISTAS.Empresa Empr, LOS_OPTIMISTAS.Dom_Mail Dom_Mail, LOS_OPTIMISTAS.Usuario Usar
			
			WHERE
			((@p_Razon_Social IS NULL) OR ( Empr.Razon_social like @p_Razon_Social  + '%'))
			AND  ((@p_Cuit IS NULL) OR (Empr.Cuit = @p_Cuit ))
			AND  ((@p_Email IS NULL) OR ( Dom_Mail.Mail like @p_Email  + '%'))
			AND  (Empr.ID_Usuario = Dom_Mail.Id_Usuario)
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
@p_Fecha_Creacion datetime = null,
@p_Domicilio varchar(100) = null,
@p_Telefono varchar(40) = null,
@p_CP varchar(50) = null,
@p_Mail varchar(255) = null, 
@p_Localidad varchar (255) = null,
@p_Calle varchar(255) = null,
@p_Piso varchar(20) = null,
@p_Depto varchar(50) = null,
@p_Id_Usuario varchar (20),
@p_Password varchar (64),
@p_Nombre_Contacto varchar(255) = null 

 )
AS
BEGIN

	INSERT INTO LOS_OPTIMISTAS.Usuario(Id_Usuario,Password,Cantidad_Login,Ultima_Fecha,Habilitado)
	values(@p_Id_Usuario,@p_Password,'0',GETDATE(),1)
		
	INSERT INTO LOS_OPTIMISTAS.Empresa(ID_Usuario,Razon_social,Cuit,Fecha_Creacion, Nombre_Contacto)
	values(@p_Id_Usuario,@p_Razon_Social,@p_Cuit,@p_Fecha_Creacion, @p_Nombre_Contacto)
		
	INSERT INTO LOS_OPTIMISTAS.Dom_Mail(Id_Usuario,Domicilio,Depto,Cp,Calle,Localidad,Mail,Piso,Telefono)
	Values(@p_Id_Usuario,@p_Domicilio,@p_Depto,@p_CP,@p_Calle,@p_Localidad ,@p_Mail,@p_Piso,@p_Telefono)
	
	INSERT INTO LOS_OPTIMISTAS.Usuario_Rol(Id_Rol,Id_Usuario,Habilitado)
	Values(3,@p_Id_Usuario,1)
							
END
 
GO
 
 
 GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[ModificarEmpresa]
(
@p_Razon_Social varchar(255) = null ,
@p_Cuit varchar(50) = null,
@p_Fecha_Creacion datetime = null,
@p_Nombre_Contacto varchar(255) = null,
@p_Domicilio varchar(100) = null,
@p_Telefono varchar(40) = null,
@p_CP varchar(50) = null,
@p_Mail varchar(255) = null, 
@p_Localidad varchar (255) = null,
@p_Calle varchar(255) = null,
@p_Piso varchar(20) = null,
@p_Depto varchar(50) = null,
@p_Id_Usuario varchar (20),
@p_Password varchar (64)
)
AS
BEGIN

		BEGIN TRANSACTION
							
							
			IF (@p_Password != '') UPDATE LOS_OPTIMISTAS.Usuario SET [Password] = @p_Password WHERE Id_Usuario = @p_Id_Usuario
						
			IF (@p_Razon_Social != '') UPDATE LOS_OPTIMISTAS.Empresa SET [Razon_social] = @p_Razon_Social WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Cuit != '') UPDATE LOS_OPTIMISTAS.Empresa SET [Cuit] = @p_Cuit WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Nombre_Contacto != '') UPDATE LOS_OPTIMISTAS.Empresa SET [Nombre_Contacto] = @p_Nombre_Contacto WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Fecha_Creacion != '') UPDATE LOS_OPTIMISTAS.Empresa SET [Fecha_Creacion] = @p_Fecha_Creacion WHERE Id_Usuario = @p_Id_Usuario
						
			IF (@p_Domicilio != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Domicilio] = @p_Domicilio WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Depto != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Depto] = @p_Depto WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_CP != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Cp] = @p_CP WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Calle != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Calle] = @p_Calle WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Localidad != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Localidad] = @p_Localidad WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Mail != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Mail] = @p_Mail WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Piso != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Piso] = @p_Piso WHERE Id_Usuario = @p_Id_Usuario
			IF (@p_Telefono != '') UPDATE LOS_OPTIMISTAS.Dom_Mail SET [Telefono] = @p_Telefono WHERE Id_Usuario = @p_Id_Usuario
					
		COMMIT TRANSACTION
					
		
END
GO
 /* Store Procedure para ABM Rol*/ 
 /*VERIFICAR SI ANDA BIEN Cargando datos en las tablas*/
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[ListarRoles]
 
 AS
 BEGIN
	
	Select  Rol.Id_Rol,Rol.Descripcion,Rol.Habilitado
	  from LOS_OPTIMISTAS.Rol Rol
		
 END
 GO
 
 
 
 /* Procedimiento Alta Rol*/
GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[CrearRol]
 (
 @p_Descripcion_Rol varchar(20) = null
 )
 AS
 BEGIN
 
Declare @id_rol int
Declare @p_Rol_Habilitado int = 1
	
	select @id_rol = Id_Rol from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol
	
	IF @id_rol is not null
		BEGIN	 
		 UPDATE LOS_OPTIMISTAS.Rol  SET [Habilitado] = @p_Rol_Habilitado WHERE Id_Rol = @id_rol 
		END
	ELSE
		BEGIN
		 select TOP 1 @id_rol = Id_Rol from LOS_OPTIMISTAS.Rol 
		 order by Id_Rol DESC
		 
		 INSERT INTO LOS_OPTIMISTAS.Rol(Id_Rol,Descripcion,Habilitado)
		 values ((@id_rol + 1),@p_Descripcion_Rol,1)
		END
END
GO
 
 
 /* Procedimiento Baja Rol*/
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[BajaRol]
 (
  @p_Descripcion_Rol varchar(20) = null
 )
 AS
 BEGIN
 Declare @id_rol int
 select @id_rol = Id_Rol from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol
 
 UPDATE LOS_OPTIMISTAS.Rol  SET [Habilitado] = 0 WHERE Id_Rol = @id_rol 
 
 --Deshabilito todos de la tabla Usuario_Rol todos los usuarios que tengan ese ROL
 
UPDATE LOS_OPTIMISTAS.Usuario_Rol
SET [Habilitado] = 0
Where Id_Rol = @id_rol 
 
 
 
 END
 GO
 
 
 /* Procedimiento Baja Rol*/
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[HabilitarRol]
 (
  @p_Descripcion_Rol varchar(20) = null
 )
 AS
 BEGIN
 Declare @id_rol int
 select @id_rol = Id_Rol from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol
 
 UPDATE LOS_OPTIMISTAS.Rol  SET [Habilitado] = 1 WHERE Id_Rol = @id_rol 
 
 END
 GO
 
  /* Procedimiento Modificar Rol*/
  
  GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[ModificarNombreRol]
 (
  @p_Descripcion_Rol_Vieja varchar(20) = null,
  @p_Descripcion_Rol_Nueva varchar(20) = null
 )
 AS
 BEGIN
 
 UPDATE LOS_OPTIMISTAS.Rol  SET [Descripcion] = @p_Descripcion_Rol_Nueva WHERE  Descripcion = @p_Descripcion_Rol_Vieja 
 
 END
 GO

 CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_InhabilitarRol](
 	@p_Descripcion_Rol varchar(20) = null
 )
 AS
 BEGIN
 	Declare @p_Id_Rol int
 	IF EXISTS( select * from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol)
		BEGIN
			select @p_Id_Rol =  Id_Rol from LOS_OPTIMISTAS.Rol where Descripcion = @p_Descripcion_Rol
			UPDATE LOS_OPTIMISTAS.Rol SET Habilitado = 0 WHERE Id_Rol = @p_Id_Rol
			DELETE FROM LOS_OPTIMISTAS.Usuario_Rol WHERE Id_Rol = @p_Id_Rol
		END
 END
 GO
 
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_HabilitarRol](
	@p_Descripcion_Rol varchar(20) = null
)
AS
BEGIN
	Declare @p_Id_Rol int
	IF EXISTS( select * from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol)
		BEGIN
			select @p_Id_Rol =  Id_Rol from LOS_OPTIMISTAS.Rol where Descripcion = @p_Descripcion_Rol
			UPDATE LOS_OPTIMISTAS.Rol SET Habilitado = 1 WHERE Id_Rol = @p_Id_Rol
		END
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_EliminarFuncionalidades]
(
	@p_Descripcion_Rol varchar(20) = null
)
AS
BEGIN
	Declare @p_Id_Rol int
	IF EXISTS( select * from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol)
		BEGIN
			select @p_Id_Rol =  Id_Rol from LOS_OPTIMISTAS.Rol where Descripcion = @p_Descripcion_Rol
			DELETE FROM LOS_OPTIMISTAS.Rol_Funcionalidad WHERE Id_Rol = @p_Id_Rol
		END
END
 
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarFuncionalidesRol]
(
	@p_Descripcion_Rol varchar(20) = null
)
AS
BEGIN
	SELECT func.Descripcion FROM LOS_OPTIMISTAS.Rol rol INNER JOIN LOS_OPTIMISTAS.Rol_Funcionalidad rolFunc
		ON rol.Id_Rol = rolFunc.Id_Rol 
		INNER JOIN LOS_OPTIMISTAS.Funcionalidad func ON rolFunc.Id_Funcionalidad = func.Id_Funcionalidad
	WHERE UPPER(rol.Descripcion) = UPPER(@p_Descripcion_Rol) 
END
 
 GO 
 --SP para agregar funcionalidades a un ROL
 CREATE PROCEDURE [LOS_OPTIMISTAS].[AgregarFuncionalidad]
 
 (
 @p_Descripcion_Rol varchar(20) = null,
  @p_Descripcion_Funcionalidad varchar(40) = null
    )
 AS
 BEGIN
 Declare @p_Id_Rol int
 Declare @p_Id_Funcionalidad int
 
	IF EXISTS( select * from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol)
	--Si existe el ROL entonces...
			BEGIN
			select @p_Id_Rol =  Id_Rol from LOS_OPTIMISTAS.Rol where Descripcion = @p_Descripcion_Rol
			
						IF EXISTS( select * from LOS_OPTIMISTAS.Funcionalidad Where Descripcion = @p_Descripcion_Funcionalidad)
						--Si Existe la funcionalidad entonces .....
						BEGIN
						select  @p_Id_Funcionalidad = Id_Funcionalidad from LOS_OPTIMISTAS.Funcionalidad Where Descripcion = @p_Descripcion_Funcionalidad
						INSERT INTO LOS_OPTIMISTAS.Rol_Funcionalidad(Id_Rol,Id_Funcionalidad)
						values (@p_Id_Rol,@p_Id_Funcionalidad)
						END
						ELSE
						--Si no existe la funcionalidad
						PRINT ' No existe la funcionalidad'		
			
			END
	 ELSE
	 PRINT ' El Rol no existe, DEBE CREAR EL ROL ANTES de agregar funcionalidades'
	  
	END 
	
	



 
 --SP para agregar funcionalidades a un ROL
 GO
 CREATE PROCEDURE [LOS_OPTIMISTAS].[QuitarFuncionalidad]
 
 (
 @p_Descripcion_Rol varchar(20) = null,
  @p_Descripcion_Funcionalidad varchar(40) = null
    )
 AS
 BEGIN
 Declare @p_Id_Rol int
 Declare @p_Id_Funcionalidad int
 
	IF EXISTS( select * from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol)
	--Si existe el ROL entonces...
			BEGIN
			select @p_Id_Rol =  Id_Rol from LOS_OPTIMISTAS.Rol where Descripcion = @p_Descripcion_Rol
			
						IF EXISTS( select * from LOS_OPTIMISTAS.Funcionalidad Where Descripcion = @p_Descripcion_Funcionalidad)
						--Si Existe la funcionalidad entonces .....
						BEGIN
						select  @p_Id_Funcionalidad = Id_Funcionalidad from LOS_OPTIMISTAS.Funcionalidad Where Descripcion = @p_Descripcion_Funcionalidad
						
						DELETE LOS_OPTIMISTAS.Rol_Funcionalidad Where ((Id_Rol = @p_Id_Rol) AND (Id_Funcionalidad = @p_Id_Funcionalidad ))
					
						
						END
						ELSE
						--Si no existe la funcionalidad
						PRINT ' No existe la funcionalidad'		
			
			END
	 ELSE
	 PRINT ' El Rol no existe, DEBE CREAR EL ROL ANTES de agregar funcionalidades'
	  
	END 
	GO

--ABM REGISTRAR USUARIO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_registrarUsuarioRoles]
AS
BEGIN
	SELECT Descripcion,Id_Rol FROM LOS_OPTIMISTAS.Rol
		WHERE Descripcion IN ('empresa','cliente') AND Habilitado = 1
END
GO

--ABM VISIBILIDAD
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_CrearVisibilidad](
	@id_visibilidad numeric(18,0),
	@descripcion varchar(255),
	@precio numeric(18,2),
	@porcentaje numeric(18,2),
	@peso int = 0,
	@habilitado int
)
AS
BEGIN
	INSERT INTO LOS_OPTIMISTAS.Visibilidad (id_visibilidad,descripcion,precio,porcentaje,peso,habilitado)
	VALUES (@id_visibilidad,@descripcion,@precio, @porcentaje, @peso, @habilitado)
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarVisibilidades]
(
	@p_id_visibilidad numeric(18,0) = null,
	@p_descripcion varchar(255) = null,
	@p_peso int = null
)
AS
BEGIN
	SELECT DISTINCT
				
		visib.Id_Visibilidad 'Codigo',
		visib.Descripcion 'Descripcion',
		visib.Precio 'Precio',
		visib.Porcentaje 'Porcentaje',
		visib.Peso 'Peso',
		visib.Habilitado 'Habilitado'
		
		FROM LOS_OPTIMISTAS.Visibilidad visib
		
		WHERE
		((@p_id_visibilidad IS NULL) OR ( visib.Id_Visibilidad = @p_id_visibilidad))
		AND  ((@p_descripcion IS NULL) OR (visib.Descripcion like @p_descripcion + '%'))
		AND  ((@p_peso IS NULL) OR (visib.Peso = @p_peso))
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ChequearCodigoYDescripcionVisibilidad]
(
	@id_visibilidad numeric(18,0),
	@descripcion varchar(255)
)
AS
BEGIN
	Declare @existe int = 0
	SELECT * FROM LOS_OPTIMISTAS.Visibilidad
		WHERE Id_Visibilidad = @id_visibilidad
	 IF (@@ROWCOUNT > 0)
	 	SET @existe = @existe + 1

	SELECT * FROM LOS_OPTIMISTAS.Visibilidad
		WHERE LTRIM(Descripcion) = LTRIM(@descripcion)
	IF (@@ROWCOUNT > 0)
	 	SET @existe = @existe + 2

	RETURN @existe
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_CrearModificarVisibilidad]
(
	@id_visibilidad numeric(18,0),
	@descripcion varchar(255),
	@precio numeric(18,2),
	@porcentaje numeric(18,2),
	@peso int,
	@habilitado int
)
AS 
BEGIN
	IF EXISTS(SELECT 1 FROM LOS_OPTIMISTAS.Visibilidad WHERE Id_Visibilidad = @id_visibilidad)
	BEGIN		
		UPDATE LOS_OPTIMISTAS.Visibilidad SET 
		Descripcion=@descripcion,
		Precio=@precio,
		Porcentaje=@porcentaje,
		Peso=@peso,
		Habilitado=@habilitado
		WHERE Id_Visibilidad = @id_visibilidad
	END
		ELSE
		INSERT INTO LOS_OPTIMISTAS.Visibilidad (Id_Visibilidad,Descripcion,Precio,Porcentaje,Peso,Habilitado)
		VALUES(@id_visibilidad,@descripcion,@precio,@porcentaje,@peso,@habilitado)	
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_EliminarVisibilidad]
(
	@id_visibilidad numeric(18,0)
)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM LOS_OPTIMISTAS.Visibilidad WHERE Id_Visibilidad = @id_visibilidad)
	BEGIN		
		UPDATE LOS_OPTIMISTAS.Visibilidad SET 
			Habilitado=0
		WHERE Id_Visibilidad = @id_visibilidad
	END
		ELSE
		--Si no existe la funcionalidad
		PRINT ' No existe la visibilidad'
END
GO

--Procedimiento para listar funcionalidades dado el Id del Rol

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarMenuFuncionalidadesRol]
(
	@p_Id_Rol int
)

AS

BEGIN	
		
	SELECT fun.Descripcion, fun.Id_Funcionalidad FROM LOS_OPTIMISTAS.Funcionalidad fun
	INNER JOIN LOS_OPTIMISTAS.Rol_Funcionalidad funR ON fun.Id_Funcionalidad = funR.Id_Funcionalidad 
	WHERE @p_Id_Rol = funR.Id_Rol

END

--Procedimineto para listar preguntas que tiene pendiente por responder un Usuario, me pasan Id_Usuario y les devuelvo todo referido a las preguntas pendientes que tiene
--en cada publicacion
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[ListarPreguntas]

(
@Id_Usuario varchar(20)
)

AS
BEGIN

			SELECT 
			
			Publicacion_Preguntas.Fecha_Creacion,
			Publicacion_Preguntas.Fecha_Respuesta,
			Publicacion_Preguntas.Id_Pregunta,
			Publicacion_Preguntas.Id_Publicacion,
			Publicacion_Preguntas.Id_Usuario,
			Publicacion_Preguntas.Preg_Descripcion,
			Publicacion_Preguntas.Preg_Respuesta,
			Publicacion.Id_Publicacion

			FROM LOS_OPTIMISTAS.Publicacion_Preguntas , LOS_OPTIMISTAS.Publicacion 
			
			WHERE ( Publicacion.Id_Usuario = @Id_Usuario) AND 
			(Publicacion.Id_Publicacion = Publicacion_Preguntas.Id_Publicacion) AND
			(Publicacion_Preguntas.Preg_Respuesta IS NULL)
			
			
 END
 GO
 
 
 --Subo respuesta pasandome el Id_Pregunta(que se los pase en el procedimiento ListarPreguntas),el Id_usuario de quien responde y la descripcion de la respuesta
 GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[SubirRespuesta]

(
@Id_Pregunta [numeric](18,0),
@Id_Usuario varchar(20),
@Preg_Respuesta varchar(255)

)

AS
BEGIN

			UPDATE LOS_OPTIMISTAS.Publicacion_Preguntas 
			SET [Preg_Respuesta] = @Preg_Respuesta, [Fecha_Respuesta] = getdate()
			Where (Id_Pregunta = @Id_Pregunta) AND (Id_Usuario = @Id_Usuario)
			
 END
 GO
 
 
 
--Proc. Para listar las preguntas que realizo un usuario y si fueron respondidas o no
 GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[ListarRespuestas]

(
@Id_Usuario varchar(20)
)

AS
BEGIN

			SELECT 
			Publ_Preguntas.Preg_Descripcion,
			Publ_Preguntas.Preg_Respuesta,
			Publ.Id_Publicacion,
			Publ.Descripcion,
			Publ.Fecha_Inicio,
			Publ.Fecha_Vencimiento,
			Publ.Cant_por_Venta,
			Publ.Permite_Preguntas,
			Publ.Precio,
			Tipo_Publicacion.Descripcion,
			Visib.Peso,
			Visib.Descripcion,
			Visib.Porcentaje,
			Visib.Precio

			FROM LOS_OPTIMISTAS.Publicacion_Preguntas Publ_Preguntas , LOS_OPTIMISTAS.Publicacion  Publ, LOS_OPTIMISTAS.Tipo_Publicacion Tipo_Publicacion, LOS_OPTIMISTAS.Visibilidad Visib
			
			WHERE (Publ_Preguntas.Id_Usuario = @Id_Usuario) AND
			(Publ_Preguntas.Id_Publicacion = Publ.Id_Publicacion) AND
			(Publ.Id_Tipo_Publicacion = Tipo_Publicacion.Id_Tipo_Publicacion)AND
			(Publ.Id_Visibilidad = Visib.Id_Visibilidad) AND
			(Publ_Preguntas.Preg_Respuesta IS NOT NULL)	
			
 END
 GO

 CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_LoginUsuarioValido](
	@Usuario varchar(20)
)
AS
BEGIN
	Declare @Valido Int  = 0

	SELECT * FROM LOS_OPTIMISTAS.Usuario WHERE LTRIM(RTRIM(Id_Usuario)) = LTRIM(RTRIM(@Usuario))

	SET @Valido = @@ROWCOUNT

	RETURN @Valido
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_Login](
	@Usuario varchar(20),
	@Password varchar(64)
)
AS
BEGIN
	Declare @Intento Int

	SELECT * FROM LOS_OPTIMISTAS.Usuario WHERE Id_Usuario = @Usuario AND Password = @password AND Habilitado = 1

	IF (@@ROWCOUNT = 1)
	BEGIN
		SET @Intento = 0
		UPDATE LOS_OPTIMISTAS.Usuario SET Cantidad_Login = 0, Ultima_Fecha = GETDATE()
			WHERE Id_Usuario = @Usuario

		RETURN @Intento
	END
	ELSE
	BEGIN
		SELECT @Intento = Cantidad_Login FROM LOS_OPTIMISTAS.Usuario WHERE Id_Usuario = @Usuario

		SET @Intento = @Intento + 1
		UPDATE LOS_OPTIMISTAS.Usuario SET Cantidad_Login = @Intento
			WHERE Id_Usuario = @Usuario
		IF(@Intento >= 3)
			UPDATE LOS_OPTIMISTAS.Usuario SET Habilitado = 0

		RETURN @Intento
	END
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_UsuarioRol](
	@Id_Usuario varchar(20)
)
AS
BEGIN
	Declare @Habilitado Int = 1

	SELECT ur.Id_Rol, r.Descripcion,ur.Habilitado FROM Usuario_Rol ur INNER JOIN Rol r
		ON ur.Id_Rol = r.Id_Rol
		WHERE ur.Id_Usuario = @Id_Usuario
		AND ur.Habilitado = @Habilitado
		AND r.Habilitado = @Habilitado
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarRoles]
AS
BEGIN
	SELECT r.Descripcion, r.Habilitado FROM LOS_OPTIMISTAS.Rol r
END
GO
--AM Publicacion
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_GenerarPublicacion](
	@Id_Usuario varchar(20),
	@Id_Tipo_Publicacion int,
	@Id_Visibilidad numeric(18,0),
	@Precio numeric(18,2),
	@Id_Estado int,
	@Fecha_Inicio datetime,
	@Fecha_Vencimiento datetime,
	@Permite_Preguntas bit,
	@Cant_por_Venta numeric(18,0),
	@Descripcion varchar(255),
	@Cantidad numeric(18,0)
)
AS
BEGIN
	Declare @Id_Articulo numeric(18,0)
	Declare @Id_Publicacion numeric(18,0)
	
	Declare @Precio_Visibilidad numeric(18,2)
	Declare @Visibilidad varchar(255)
	Declare @Comision numeric(18,2)

	BEGIN TRANSACTION

		/*
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
		[Descripcion][varchar](255) NULL,

		[Id_Articulo][numeric](18,0)IDENTITY(1,1) NOT NULL,
		[Id_Usuario][varchar](20) NOT NULL,
		[Cantidad][numeric](18,0) NOT NULL,

		[Id_Registro][numeric](18,0)IDENTITY(1,1),
		[Id_Usuario][varchar](20) NOT NULL,
		[Id_Usuario_Comprador][varchar](20) DEFAULT NULL,
		[Id_Publicacion][numeric](18,0) NULL,
		[Comision][numeric](18,2) NOT NULL,
		[Visibilidad][varchar](255) NOT NULL,
		[Cantidad][int] NULL,
		[Precio_Publicacion][numeric](18,2) NULL,
		[Precio_Visibilidad][numeric](18,2) NULL,
		*/

		INSERT INTO LOS_OPTIMISTAS.Stock (Id_Usuario, Cantidad)
		VALUES (@Id_Usuario,@Cantidad)

		SET @Id_Articulo = @@IDENTITY

		INSERT INTO LOS_OPTIMISTAS.Publicacion (Id_Usuario,Id_Tipo_Publicacion,Id_Articulo,Id_Visibilidad,
			Precio,Fecha_Inicio,Fecha_Vencimiento,Permite_Preguntas,Cant_por_Venta,Descripcion)
		VALUES (@Id_Usuario,@Id_Tipo_Publicacion,@Id_Articulo,@Id_Visibilidad,@Precio,CONVERT(Date,@Fecha_Inicio),
			CONVERT(Date,@Fecha_Vencimiento),@Permite_Preguntas,@Cant_por_Venta,@Descripcion)

		SET @Id_Publicacion = @@IDENTITY

		INSERT INTO LOS_OPTIMISTAS.Estado_Publicacion (Id_Publicacion, Id_Estado)
			VALUES (@Id_Publicacion, @Id_Estado)

		SELECT @Precio_Visibilidad = Precio, @Visibilidad = Descripcion, @Comision = porcentaje FROM LOS_OPTIMISTAS.Visibilidad WHERE 
			Id_Visibilidad = @Id_Visibilidad 


		INSERT INTO LOS_OPTIMISTAS.Facturacion_Pendiente (Id_Usuario,Id_Publicacion,Precio_Visibilidad,Visibilidad, Comision)
		VALUES (@Id_Usuario, @Id_Publicacion,@Precio_Visibilidad,@Visibilidad, @Comision)

		COMMIT TRANSACTION
END

GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ObtenerIdPublicacionGratuita]
AS
BEGIN
	Declare @Id_Gratis int
	SELECT @Id_Gratis = Id_Visibilidad FROM LOS_OPTIMISTAS.Visibilidad
		WHERE UPPER(LTRIM(Descripcion)) = UPPER('Gratis')
	RETURN @Id_Gratis
END

GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ChequearPublicacionesGratuitas](
	@Id_Usuario varchar(20) = null
)
AS
BEGIN
	Declare @CantidadPublicacionesActivasGratuitas int = 0
	Declare @NoSuperaCondicion int = 0
	Declare @Id_Estado_Activa int

	SELECT @Id_Estado_Activa = Id_Estado FROM LOS_OPTIMISTAS.Id_Estado
		WHERE UPPER(LTRIM(Descripcion)) = UPPER(LTRIM('Activa'))

	SELECT * FROM LOS_OPTIMISTAS.Publicacion pub 
		INNER JOIN LOS_OPTIMISTAS.Estado_Publicacion pubEst
			ON pub.Id_Publicacion = pubEst.Id_Publicacion
		INNER JOIN LOS_OPTIMISTAS.Visibilidad visi
			ON pub.Id_Visibilidad = visi.Id_Visibilidad
		WHERE pubEst.Id_Estado = @Id_Estado_Activa
			AND UPPER(LTRIM(visi.Descripcion)) = UPPER('Gratis')
			AND DATEDIFF(DAY, pub.Fecha_Vencimiento, GETDATE()) < 0

	SET @CantidadPublicacionesActivasGratuitas = @@ROWCOUNT

	IF @CantidadPublicacionesActivasGratuitas > 2
		SET @NoSuperaCondicion = 1

	RETURN @NoSuperaCondicion
END	
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarPublicaciones]

(
	@p_IdUsuario varchar(20) = null,
	@p_Description varchar(255) = null,
	@p_Type int = null,
	@p_Status int = null,
	@p_Visibility int = null
)
AS
BEGIN

			SELECT DISTINCT
			
			pub.Id_Publicacion 'Codigo Publicacion',
			pub.Descripcion 'Descripcion',
			stock.Cantidad 'Stock Actual',
			est.Descripcion 'Estado',
			tiPub.Descripcion 'Tipo Publicacion',
			visi.Descripcion 'Visibilidad',
			pub.Fecha_Inicio 'Fecha Inicio',
			pub.Fecha_Vencimiento 'Fecha Vencimiento'
			
			FROM LOS_OPTIMISTAS.Publicacion pub
				INNER JOIN LOS_OPTIMISTAS.Estado_Publicacion estPub ON pub.Id_Publicacion = estPub.Id_Publicacion
				INNER JOIN LOS_OPTIMISTAS.Stock stock ON pub.Id_Articulo = stock.Id_Articulo
				INNER JOIN LOS_OPTIMISTAS.Estado est ON estPub.Id_Estado = est.Id_Estado
				INNER JOIN LOS_OPTIMISTAS.Tipo_Publicacion tiPub ON pub.Id_Tipo_Publicacion = tiPub.Id_Tipo_Publicacion
				INNER JOIN LOS_OPTIMISTAS.Visibilidad visi ON visi.Id_Visibilidad = pub.Id_Visibilidad
			WHERE
			pub.Id_Usuario = @p_IdUsuario
			AND ((@p_Description IS NULL) OR ( pub.Descripcion like '%' + @p_Description  + '%'))
			AND  ((@p_Type IS NULL) OR (tiPub.Id_Tipo_Publicacion = @p_Type ))
			AND  ((@p_Status IS NULL) OR (est.Id_Estado = @p_Status ))
			AND  ((@p_Visibility IS NULL) OR (visi.Id_Visibilidad = @p_Visibility))
 END
 GO

 CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ObtenerPublicacion]

(
	@p_Id_Usuario varchar(20) = null,
	@p_Id_Publicacion numeric(18,0) = null
)
AS
BEGIN

			SELECT DISTINCT
			
			pub.Id_Publicacion,
			pub.Descripcion,
			stock.Cantidad 'Stock',
			est.Id_Estado,
			est.Descripcion 'estadoDescripcion',
			tiPub.Id_Tipo_Publicacion,
			tiPub.Descripcion 'tipoDescripcion',
			visi.Id_Visibilidad,
			visi.Descripcion 'visibilidadDescripcion',
			pub.precio,
			pub.Permite_Preguntas,
			pub.Cant_por_Venta,
			pub.Fecha_Inicio,
			pub.Fecha_Vencimiento
			
			FROM LOS_OPTIMISTAS.Publicacion pub
				INNER JOIN LOS_OPTIMISTAS.Estado_Publicacion estPub ON pub.Id_Publicacion = estPub.Id_Publicacion
				INNER JOIN LOS_OPTIMISTAS.Stock stock ON pub.Id_Articulo = stock.Id_Articulo
				INNER JOIN LOS_OPTIMISTAS.Estado est ON estPub.Id_Estado = est.Id_Estado
				INNER JOIN LOS_OPTIMISTAS.Tipo_Publicacion tiPub ON pub.Id_Tipo_Publicacion = tiPub.Id_Tipo_Publicacion
				INNER JOIN LOS_OPTIMISTAS.Visibilidad visi ON visi.Id_Visibilidad = pub.Id_Visibilidad
			WHERE
			pub.Id_Usuario = @p_Id_Usuario
			AND @p_Id_Publicacion = pub.Id_Publicacion
 END
 GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_EditarPublicacion](
	@Id_Publicacion numeric(18,0),
	@Id_Usuario varchar(20),
	@Id_Tipo_Publicacion int,
	@Id_Visibilidad numeric(18,0),
	@Precio numeric(18,2),
	@Id_Estado int,
	@Fecha_Inicio datetime,
	@Fecha_Vencimiento datetime,
	@Permite_Preguntas bit,
	@Cant_por_Venta numeric(18,0),
	@Descripcion varchar(255),
	@Cantidad numeric(18,0),
	@Agregar_Stock int = 0 
)
AS
BEGIN
	Declare @Id_Articulo numeric(18,0)
	Declare @Estado_Descripcion varchar(30)
	Declare @Precio_Visibilidad numeric(18,2)
	Declare @Visibilidad varchar(255)
	Declare @Comision numeric(18,2)

	BEGIN TRANSACTION
		SELECT @Id_Articulo = Id_Articulo FROM LOS_OPTIMISTAS.Publicacion WHERE 
			Id_Publicacion = @Id_Publicacion AND Id_Usuario = @Id_Usuario

		SELECT @Estado_Descripcion = est.Descripcion FROM LOS_OPTIMISTAS.Estado_Publicacion estPub
			INNER JOIN LOS_OPTIMISTAS.Estado est ON estPub.Id_Estado = est.Id_Estado
			WHERE estPub.Id_Publicacion = @Id_Publicacion 

		IF (@Estado_Descripcion = 'ACTIVA')
		BEGIN
			UPDATE LOS_OPTIMISTAS.Stock SET Cantidad = Cantidad + @Agregar_Stock
				WHERE Id_Articulo = @Id_Articulo

			UPDATE LOS_OPTIMISTAS.Publicacion SET Descripcion = @Descripcion
				WHERE Id_Publicacion = @Id_Publicacion AND Id_Usuario = @Id_Usuario

			COMMIT TRANSACTION
			RETURN
		END
		ELSE
		BEGIN
			UPDATE LOS_OPTIMISTAS.Publicacion SET Id_Tipo_Publicacion = Id_Tipo_Publicacion,
				Id_Visibilidad = @Id_Visibilidad,
				Precio = @Precio,
				Permite_Preguntas = @Permite_Preguntas,
				Cant_por_Venta = @Cant_por_Venta,
				Descripcion = @Descripcion
				WHERE 
					Id_Publicacion = @Id_Publicacion AND Id_Usuario = @Id_Usuario

			UPDATE LOS_OPTIMISTAS.Estado_Publicacion SET Id_Estado = @Id_Estado
				WHERE Id_Publicacion = @Id_Publicacion

			SELECT @Precio_Visibilidad = Precio, @Visibilidad = Descripcion, @Comision = porcentaje FROM LOS_OPTIMISTAS.Visibilidad WHERE 
				Id_Visibilidad = @Id_Visibilidad 

			INSERT INTO LOS_OPTIMISTAS.Facturacion_Pendiente (Id_Usuario,Id_Publicacion,Precio_Visibilidad,Visibilidad, Comision)
			VALUES (@Id_Usuario, @Id_Publicacion,@Precio_Visibilidad,@Visibilidad, @Comision)

			COMMIT TRANSACTION
			RETURN
		END
END
GO

/*Stored Procedure para Listar Subastas Ganadas del Usuario*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarSubastasGanadas]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN
		SELECT hC.Id_Publicacion 'Publicacion'
		,hS.Fecha_Oferta 'Fecha de Oferta'
		,hS.Precio_Oferta 'Precio'
		
		FROM Historial_Subasta hS
		INNER JOIN Historial_Compra hC  ON hS.Id_Publicacion = hC.Id_Publicacion AND hS.Id_Usuario = hC.Id_Comprador
		WHERE hC.Id_Comprador = @p_Id_Usuario
		ORDER BY hS.Fecha_Oferta
				
 END
 GO

--MAL!!!!
/*Stored Procedure para Listar Subastas Perdidas del Usuario*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarSubastasPerdidas]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN
		DECLARE 
		@Ganado varchar(2),
		@historialS numeric(18,0),
		@historialC numeric(18,0)
		
		SELECT 
		hC.Id_Publicacion 'Publicacion'
		,hS.Precio_Oferta 'Oferta'
		,hS.Fecha_Oferta 'Fecha de oferta'
		,'Si' AS 'Subasta Ganada'
		FROM LOS_OPTIMISTAS.Historial_Compra hC
		JOIN LOS_OPTIMISTAS.Historial_Subasta hS
		ON hC.Id_Publicacion = hS.Id_Publicacion
		WHERE
		@p_Id_Usuario = Id_Usuario
		
		UNION
		
		SELECT 
		Id_Publicacion 'Publicacion'
		,Precio_Oferta 'Oferta'
		,Fecha_Oferta 'Fecha de oferta'
		,'No' AS 'Subasta Ganada'
		FROM LOS_OPTIMISTAS.Historial_Subasta hS
		WHERE
		@p_Id_Usuario = Id_Usuario
		
 END
 GO
 
  /*Stored Procedure para Listar las Calificaciones Otorgadas*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarCalificacionesOtorgadas]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN

		SELECT 
		hC.Id_Vendedor 'Usuario'
		,hC.Id_Publicacion 'Publicacion'
		,hC.Id_Articulo 'Articulo'
		,pubCal.Fecha_Calificacion 'Fecha de Calificacion'
		,pubCal.Calificacion
		,pubCal.Detalle
		FROM Publicacion_Calificaciones pubCal
		JOIN Historial_Compra hC ON pubCal.Id_Historial_Compra = hC.Id_Historial_Compra
		WHERE hC.Id_Comprador = @p_Id_Usuario
 END
 GO
 
/*Stored Procedure para Listar las Calificaciones Recibidas*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarCalificacionesRecibidas]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN

		SELECT 
		hC.Id_Comprador 'Usuario'
		,hC.Id_Publicacion 'Publicacion'
		,hC.Id_Articulo 'Articulo'
		,pubCal.Fecha_Calificacion 'Fecha de Calificacion'
		,pubCal.Calificacion
		,pubCal.Detalle
		FROM Publicacion_Calificaciones pubCal
		JOIN Historial_Compra hC ON pubCal.Id_Historial_Compra = hC.Id_Historial_Compra
		WHERE hC.Id_Vendedor = @p_Id_Usuario
 END
 GO
 
/*Stored Procedure para Listar las Compras del Usuario*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarCompras]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN

		SELECT 
		hC.Id_Publicacion 'Publicacion'
		,Pub.Descripcion
		,hC.Compra_Cantidad 'Cantidad'
		,hC.Compra_Fecha 'Fecha de Compra'
		FROM Historial_Compra hC
		JOIN Publicacion Pub
		ON hC.Id_Publicacion = Pub.Id_Publicacion

		WHERE
		@p_Id_Usuario = Id_Comprador
 END
 GO
 
/*Stored Procedure para Listar las Ventas del Usuario*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarVentas]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN

		SELECT 
		hC.Id_Publicacion 'Publicacion'
		,Pub.Descripcion
		,hC.Compra_Cantidad 'Cantidad'
		,hC.Compra_Fecha 'Fecha de Venta'
		FROM Historial_Compra hC
		JOIN Publicacion Pub
		ON hC.Id_Publicacion = Pub.Id_Publicacion

		WHERE
		@p_Id_Usuario = Id_Vendedor
 END
 GO

/*Stored Procedure para Listar las Facturas pendientes de pago*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarFacturasPendientes]

(
@p_Id_Usuario varchar(20) = null
)

AS
BEGIN

		SELECT Id_Publicacion 'Publicación'
		,Id_Usuario_Comprador 'Comprador'
		,((Comision * Cantidad) + Precio_Publicacion + Precio_Visibilidad) 'A pagar'
		FROM Facturacion_Pendiente
		WHERE Id_Usuario = @p_Id_Usuario
		ORDER BY Id_Publicacion	
 END
 GO

/*Stored Procedure para Facturar*/
 /*
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_Facturar]

(
@p_Id_Usuario varchar(20) = null,
@p_Cantidad int = null,
@p_Numero_Tarjeta numeric(16,0) = null,
@p_Cantidad_Cuotas int = null,
@p_Tipo_Pago int = null
)

AS
BEGIN

	CREATE TABLE[LOS_OPTIMISTAS].[Facturacion_Pendiente_temp](
	[Id_Registro][numeric](18,0),
	[Id_Usuario][varchar](20) NOT NULL,
	[Id_Usuario_Comprador][varchar](20) DEFAULT NULL,
	[Id_Publicacion][numeric](18,0) NULL,
	[Comision][numeric](18,2) NOT NULL,
	[Visibilidad][varchar](255) NOT NULL,
	[Cantidad][int] NULL,
	[Precio_Publicacion][numeric](18,2) NULL,
	[Precio_Visibilidad][numeric](18,2) NULL
	)
	
	DECLARE @p_Numero_Factura numeric (18,0)
	DECLARE @p_Id_Detalle_Tarjeta int
	
	INSERT INTO Facturacion_Pendiente_temp  
		(Id_Registro,Id_Usuario,Id_Usuario_Comprador,Id_Publicacion,Comision,Visibilidad,Cantidad,Precio_Publicacion,Precio_Visibilidad)
		(SELECT TOP (@p_Cantidad) * FROM Facturacion_Pendiente) ORDER BY Id_Registro
		
	DELETE FROM Facturacion_Pendiente WHERE Facturacion_Pendiente.Id_Registro IN (SELECT Id_Registro FROM Facturacion_Pendiente_temp)
	
	INSERT INTO LOS_OPTIMISTAS.Facturacion
		(Id_Usuario,Total_Factura,Total_Comisiones,Total_Visibilidad,Fecha)
	VALUES (@p_Id_Usuario,ISNULL((SELECT ((Comision * Cantidad) + Precio_Publicacion + Precio_Visibilidad) FROM Facturacion_Pendiente_temp),0),ISNULL((SELECT Comision FROM Facturacion_Pendiente_temp),0),ISNULL((SELECT Visibilidad FROM Facturacion_Pendiente_temp),0),GETDATE())
		
	IF (@p_Numero_Tarjeta IS NOT NULL)
	BEGIN
	
		INSERT INTO Detalle_Tarjeta 
			(Nro_Tarjeta,Cant_Cuota)
		VALUES (@p_Numero_Factura,@p_Cantidad_Cuotas)
		
		IF NOT EXISTS(SELECT Id_Factura = @p_Numero_Factura FROM Facturacion)
		INSERT INTO LOS_OPTIMISTAS.Forma_Pago
			(@p_Numero_Factura,Id_Detalle_Tarjeta,Id_Tipo_Pago) 
		VALUES (@p_Numero_Factura, 1,2)
	END
	
	DROP TABLE Facturacion_Pendiente_temp
 	
END
GO
*/

/*Stored Procedure para Listar Vendedores a Calificar*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_ListarVendedoresACalificar]
(
@p_Id_Comprador varchar(20) = null
)

AS 
BEGIN

	SELECT Id_Historial_Compra Compra, Id_Vendedor Vendedor, Id_Publicacion Publicacion, Compra_Fecha Fecha FROM Historial_Compra 
		WHERE Id_Comprador = @p_Id_Comprador AND Calificado = 0

END
GO

/*Stored Procedure para Calificar*/
GO
CREATE PROCEDURE [LOS_OPTIMISTAS].[proc_Calificar]
(
@p_Id_Historial_Compra numeric (18,0),
@p_Id_Vendedor varchar(20),
@p_Id_Comprador varchar(20),
@p_Fecha_Calificacion datetime,
@p_Detalle varchar(255),
@p_Calificacion numeric(18,0)
)

AS
BEGIN

	INSERT INTO LOS_OPTIMISTAS.Publicacion_Calificaciones 
		(Id_Historial_Compra,Fecha_Calificacion,Detalle,Calificacion) 
		VALUES (@p_Id_Historial_Compra,@p_Fecha_Calificacion,@p_Detalle,@p_Calificacion)
		
	UPDATE Historial_Compra SET Calificado = 1 WHERE Id_Historial_Compra = @p_Id_Historial_Compra
END
GO