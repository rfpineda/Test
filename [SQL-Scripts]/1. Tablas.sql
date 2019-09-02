-- Usuario
IF OBJECT_ID('dbo.ActualizarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ActualizarEmpleado
GO
IF OBJECT_ID('dbo.EliminarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.EliminarEmpleado
GO
IF OBJECT_ID('dbo.InsertarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.InsertarEmpleado
GO
IF OBJECT_ID('dbo.ListarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ListarEmpleado
GO
IF OBJECT_ID('dbo.ObtenerEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ObtenerEmpleado
GO
CREATE PROCEDURE dbo.ActualizarEmpleado
(
	@idUsuario VARCHAR(50),
	@identificacion BIGINT,	
	@nombre VARCHAR(50),
	@primerApellido VARCHAR(50),
	@segundoApellido VARCHAR(50),
	@correoElectronico VARCHAR(100),
	@constrasena VARCHAR(2000), 
	@esActivo BIT	
)
AS
BEGIN
	UPDATE dbo.Usuario 
	SET Identificacion = @identificacion,
		Nombre = @nombre,
		PrimerApellido = @primerApellido,
		SegundoApellido = @segundoApellido,
		CorreoElectronico = @correoElectronico,
		EsActivo = @esActivo,
		CambioContrasena = 0,
		IntentosAutenticacion = 0,
		MomentoUltimaActualizacion = GETDATE()
	WHERE IdUsuario = @idUsuario
END
GO

CREATE PROCEDURE dbo.EliminarUsuario
(
	@idUsuario VARCHAR(50)
)
AS
BEGIN
    DELETE
	FROM dbo.Empleado
    WHERE
		IdUsuario = @idUsuario
END
GO

CREATE PROCEDURE dbo.InsertarUsuario
(	
	@idUsuario VARCHAR(50),
	@identificacion BIGINT,	
	@nombre VARCHAR(50),
	@primerApellido VARCHAR(50),
	@segundoApellido VARCHAR(50),
	@correoElectronico VARCHAR(100)
)
AS
BEGIN
	INSERT INTO dbo.Usuario
	(
		IdUsuario,
		Nombre,
		PrimerApellido,
		SegundoApellido,
		CorreoElectronico,
		Contrasena,
		EsActivo,
		CambioContrasena,
		IntentosAutenticacion,
		MomentoCreacion,
		MomentoUltimaActualizacion
	)
	VALUES 
	(		
		@idUsuario,
		@nombre,
		@primerApellido,
		@segundoApellido,
		@correoElectronico,
		'',
		1,
		1,
		0,
		GETDATE(),
		GETDATE()		
	)
END
GO

CREATE PROCEDURE dbo.ListarUsuario
AS
BEGIN
	SELECT
		*
	FROM dbo.Usuario
END
GO

CREATE PROCEDURE dbo.ObtenerUsuario
(
	@idUsuario VARCHAR(50)
)
AS
BEGIN
    SELECT
		*
	FROM dbo.Usuario
    WHERE
		IdUsuario = @idUsuario
END
GO

-- LinkerBoxProtocolo

IF OBJECT_ID('dbo.ListarLinkerBoxProtocolo' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ListarLinkerBoxProtocolo
GO
IF OBJECT_ID('dbo.ObtenerLinkerBoxProtocolo' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ObtenerLinkerBoxProtocolo
GO

CREATE PROCEDURE dbo.ListarLinkerBoxProtocolo
AS
BEGIN
	SELECT
		*
	FROM dbo.LinkerBoxProtocolo
END
GO

CREATE PROCEDURE dbo.ObtenerLinkerBoxProtocolo
(
	@idLinkerBoxProtocolo INT
)
AS
BEGIN
    SELECT
		*
	FROM dbo.LinkerBoxProtocolo
    WHERE
		IdLinkerBoxProtocolo = @idLinkerBoxProtocolo
END
GO
