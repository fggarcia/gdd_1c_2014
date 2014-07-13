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
		Select  Rol.Id_Rol,Rol.Descripcion,Rol.Habilitado,Rol_Func.Id_Funcionalidad,Func.Descripcion
		from LOS_OPTIMISTAS.Rol Rol, LOS_OPTIMISTAS.Rol_Funcionalidad Rol_Func,LOS_OPTIMISTAS.Funcionalidad Func
		Where
		(Rol.Id_Rol = Rol_Func.Id_Rol) And (Rol_Func.Id_Funcionalidad= Func.Id_Funcionalidad) 
		
		
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
	IF EXISTS( select * from LOS_OPTIMISTAS.Rol Where Descripcion = @p_Descripcion_Rol)
	 
	  PRINT 'El rol ya existe'
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

--ABM VISIBILIDAD
CREATE PROCEDURE [LOS_OPTIMISTAS].[ListarVisibilidades]
AS
BEGIN
	SELECT * FROM LOS_OPTIMISTAS.Visibilidad
	ORDER BY Descripcion ASC
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[ModificarVisibilidad]
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
		--Si no existe la funcionalidad
		PRINT ' No existe la visibilidad'		
END
GO

CREATE PROCEDURE [LOS_OPTIMISTAS].[EliminarVisibilidad]
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

--ABM Publicacion
CREATE PROCEDURE [LOS_OPTIMISTAS].[CrearPublicacion](
	@Id_Usuario varchar(20),
	@Tipo_Publicacion int,
	@Id_Visibilidad numeric(18,0),
	@Descripcion_Articulo varchar(255),
	@Precio numeric(18,0),
	@Permite_Preguntas bit,
	@Cant_por_Venta numeric(18,0)
)
AS
BEGIN 
	Declare @Id_Articulo numeric(18,0),
	Declare @Id_Publicacion numeric(18,0),
	Declare @Precio_Publicacion_Pendiente numeric(18,2),
	Declare @Cantidad_Visibilidad_Cobrar int,
	Declare @Visibilidad varchar(255),
	Declare @Comision numeric(18,2)

	SET @Precio_Publicacion_Pendiente = 0.0
	SET @Comision = 0.0
	SET @Cantidad_Visibilidad_Cobrar = 1
	BEGIN TRANSACTION
		BEGIN TRY
			
			INSERT INTO LOS_OPTIMISTAS.Stock(@Id_Usuario, @Stock)
			SET @Id_Articulo = SELECT @@IDENTITY
			INSERT INTO LOS_OPTIMISTAS.Publicacion(Id_Articulo,Id_Visibilidad,Id_Estado,Precio,Fecha_Inicio,
				Fecha_Vencimiento,Permite_Preguntas,Cant_por_Venta,Stock,Descripcion)
				VALUES (@Id_Articulo,@Id_Visibilidad,@Precio,DATEADD(day,0,DATEDIFF(day,0,GETDATE())),
					DATEADD(month,1,DATEDIFF(day,0,GETDATE())),@Permite_Preguntas,@Cant_por_Venta)
			SET @Id_Publicacion = @@IDENTITY
			SELECT @Visibilidad = UPPER(Descripcion) ,@Precio_Publicacion_Pendiente  = Precio FROM
				LOS_OPTIMISTAS.Visibilidad WHERE Id_Visibilidad = @Id_Visibilidad
			INSERT INTO LOS_OPTIMISTAS.Facturacion_Pendiente (Id_Usuario, Id_Publicacion,Comision,Visibilidad,
				Cantidad,Precio_Publicacion, Precio_Visibilidad)
				VALUES (@Id_Usuario,@Id_Publicacion,@Comision,@Visibilidad,@Cantidad_Visibilidad_Cobrar,
					@Precio_Publicacion_Pendiente,@Precio_Visibilidad)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END TRANSACTION
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
			Publ.Pemite_Preguntas,
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
 