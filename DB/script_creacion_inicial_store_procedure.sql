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