-- Empleado
IF OBJECT_ID('administracion.ActualizarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ActualizarEmpleado
GO
IF OBJECT_ID('administracion.EliminarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.EliminarEmpleado
GO
IF OBJECT_ID('administracion.InsertarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.InsertarEmpleado
GO
IF OBJECT_ID('administracion.ListarEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ListarEmpleado
GO
IF OBJECT_ID('administracion.ObtenerEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ObtenerEmpleado
GO
CREATE PROCEDURE administracion.ActualizarEmpleado
(
	@idUsuario VARCHAR(50),
	@identificacion BIGINT,	
	@nombre VARCHAR(100),
	@primerApellido VARCHAR(100),
	@segundoApellido VARCHAR(100),
	@constrasena VARCHAR(300)
)
AS
BEGIN
	UPDATE administracion.Empleado 
	SET Identificacion = @identificacion,
		Nombre = @nombre,
		PrimerApellido = @primerApellido,
		SegundoApellido = @segundoApellido,
		Contrasena = @constrasena
	WHERE IdUsuario = @idUsuario
END
GO
CREATE PROCEDURE administracion.EliminarEmpleado
(
	@idUsuario VARCHAR(50)
)
AS
BEGIN
    DELETE
	FROM administracion.Empleado
    WHERE
		IdUsuario = @idUsuario
END
GO
CREATE PROCEDURE administracion.InsertarEmpleado
(	
	@idUsuario VARCHAR(50),
	@identificacion BIGINT,	
	@nombre VARCHAR(100),
	@primerApellido VARCHAR(100),
	@segundoApellido VARCHAR(100),
	@contrasena VARCHAR(300)
)
AS
BEGIN
	INSERT INTO administracion.Empleado
	(
		IdUsuario,
		Identificacion,
		Nombre,
		PrimerApellido,
		SegundoApellido,
		Contrasena
	)
	VALUES 
	(		
		@idUsuario,
		@identificacion,
		@nombre,
		@primerApellido,
		@segundoApellido,
		@contrasena
	)
END
GO
CREATE PROCEDURE administracion.ListarEmpleado
AS
BEGIN
	SELECT
		*
	FROM administracion.Empleado
END
GO
CREATE PROCEDURE administracion.ObtenerEmpleado
(
	@idUsuario VARCHAR(50)
)
AS
BEGIN
    SELECT
		*
	FROM administracion.Empleado
    WHERE
		IdUsuario = @idUsuario
END
GO
-- Cliente
IF OBJECT_ID('administracion.ActualizarCliente' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ActualizarCliente
GO
IF OBJECT_ID('administracion.EliminarCliente' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.EliminarCliente
GO
IF OBJECT_ID('administracion.InsertarCliente' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.InsertarCliente
GO
IF OBJECT_ID('administracion.ListarCliente' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ListarCliente
GO
IF OBJECT_ID('administracion.ObtenerCliente' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ObtenerCliente
GO
CREATE PROCEDURE administracion.ActualizarCliente
(
	@idCliente INT,
	@nit BIGINT,	
	@nombre VARCHAR(100),
	@descripcion VARCHAR(100)
)
AS
BEGIN
	UPDATE administracion.Cliente 
	SET Nit = @nit,
		Nombre = @nombre,
		Descripcion = @descripcion
	WHERE IdCliente = @idCliente
END
GO
CREATE PROCEDURE administracion.EliminarCliente
(
	@idCliente INT
)
AS
BEGIN
    DELETE
	FROM administracion.Cliente
    WHERE
		IdCliente = @idCliente
END
GO
CREATE PROCEDURE administracion.InsertarCliente
(	
	@idCliente INT,
	@nit BIGINT,	
	@nombre VARCHAR(100),
	@descripcion VARCHAR(100)
)
AS
BEGIN
	INSERT INTO administracion.Cliente
	(
		idCliente,
		Nit,
		Nombre,
		Descripcion
	)
	VALUES 
	(		
		@idCliente,
		@nit,
		@nombre,
		@descripcion
	)
END
GO
CREATE PROCEDURE administracion.ListarCliente
AS
BEGIN
	SELECT
		*
	FROM administracion.Cliente
END
GO
CREATE PROCEDURE administracion.ObtenerCliente
(
	@idCliente INT
)
AS
BEGIN
    SELECT
		*
	FROM administracion.Cliente
    WHERE
		IdCliente = @idCliente
END
GO
-- EmpleadoPerfil
IF OBJECT_ID('administracion.EliminarEmpleadoPerfilPorEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.EliminarEmpleadoPerfilPorEmpleado
GO
IF OBJECT_ID('administracion.InsertarEmpleadoPerfil' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.InsertarEmpleadoPerfil
GO
IF OBJECT_ID('administracion.ListarEmpleadoPerfilPorEmpleado' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ListarEmpleadoPerfilPorEmpleado
GO
CREATE PROCEDURE administracion.EliminarEmpleadoPerfilPorEmpleado
(
	@idUsuario VARCHAR(50)
)
AS
BEGIN
    DELETE
	FROM administracion.EmpleadoPerfil
    WHERE
		IdUsuario = @idUsuario
END
GO
CREATE PROCEDURE administracion.InsertarEmpleadoPerfil
(	
	@idUsuario VARCHAR(50),
	@idPerfil INT
)
AS
BEGIN
	INSERT INTO administracion.EmpleadoPerfil
	(
		IdUsuario,
		IdPerfil
	)
	VALUES 
	(		
		@idUsuario,
		@idPerfil
	)
END
GO
CREATE PROCEDURE administracion.ListarEmpleadoPerfilPorEmpleado
(
	@idUsuario VARCHAR(50)
)
AS
BEGIN
	SELECT
		*
	FROM administracion.EmpleadoPerfil
	WHERE IdUsuario = @idUsuario
END
GO
-- Perfil
IF OBJECT_ID('administracion.ListarPerfil' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ListarPerfil
GO
IF OBJECT_ID('administracion.ObtenerPerfil' , 'P') IS NOT NULL
	DROP PROCEDURE administracion.ObtenerPerfil
GO
CREATE PROCEDURE administracion.ListarPerfil
AS
BEGIN
	SELECT
		*
	FROM administracion.Perfil
END
GO
CREATE PROCEDURE administracion.ObtenerPerfil
(
	@idPerfil VARCHAR(50)
)
AS
BEGIN
    SELECT
		*
	FROM administracion.Perfil
    WHERE
		IdPerfil = @idPerfil
END
GO
-- Factura
IF OBJECT_ID('facturacion.ActualizarFactura' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.ActualizarFactura
GO
IF OBJECT_ID('facturacion.EliminarFactura' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.EliminarFactura
GO
IF OBJECT_ID('facturacion.InsertarFactura' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.InsertarFactura
GO
IF OBJECT_ID('facturacion.ListarFactura' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.ListarFactura
GO
IF OBJECT_ID('facturacion.ObtenerFactura' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.ObtenerFactura
GO
CREATE PROCEDURE facturacion.ActualizarFactura
(
	@idFactura INT,
	@idCliente INT,	
	@idUsuario VARCHAR(50)
)
AS
BEGIN
	UPDATE facturacion.Factura 
	SET IdCliente = @idCliente,
		IdUsuario = @idUsuario
	WHERE IdFactura = @idFactura
END
GO
CREATE PROCEDURE facturacion.EliminarFactura
(
	@idFactura INT
)
AS
BEGIN
    DELETE
	FROM facturacion.Factura
    WHERE
		IdFactura = @idFactura
END
GO
CREATE PROCEDURE facturacion.InsertarFactura
(	
	@idCliente INT,	
	@idUsuario VARCHAR(50)
)
AS
BEGIN
	INSERT INTO facturacion.Factura
	(
		IdCliente,
		IdUsuario,
		MomentoCreacion
	)
	VALUES 
	(		
		@idCliente,
		@idUsuario,
		GETDATE()
	)
END
GO
CREATE PROCEDURE facturacion.ListarFactura
AS
BEGIN
	SELECT
		*
	FROM facturacion.Factura
END
GO
CREATE PROCEDURE facturacion.ObtenerFactura
(
	@idFactura INT
)
AS
BEGIN
    SELECT
		*
	FROM facturacion.Factura
    WHERE
		IdFactura = @idFactura
END
GO
-- Producto
IF OBJECT_ID('logistica.ActualizarProducto' , 'P') IS NOT NULL
	DROP PROCEDURE logistica.ActualizarProducto
GO
IF OBJECT_ID('logistica.EliminarProducto' , 'P') IS NOT NULL
	DROP PROCEDURE logistica.EliminarProducto
GO
IF OBJECT_ID('logistica.InsertarProducto' , 'P') IS NOT NULL
	DROP PROCEDURE logistica.InsertarProducto
GO
IF OBJECT_ID('logistica.ListarProducto' , 'P') IS NOT NULL
	DROP PROCEDURE logistica.ListarProducto
GO
IF OBJECT_ID('logistica.ObtenerProducto' , 'P') IS NOT NULL
	DROP PROCEDURE logistica.ObtenerProducto
GO
CREATE PROCEDURE logistica.ActualizarProducto
(
	@idProducto INT,
	@nombre VARCHAR(100),	
	@descripcion VARCHAR(500),
	@precio REAL
)
AS
BEGIN
	UPDATE logistica.Producto 
	SET Nombre = @nombre,
		Descripcion = @descripcion,
		Precio = @precio
	WHERE IdProducto = @idProducto
END
GO
CREATE PROCEDURE logistica.EliminarProducto
(
	@idProducto INT
)
AS
BEGIN
    DELETE
	FROM logistica.Producto
    WHERE
		IdProducto = @idProducto
END
GO
CREATE PROCEDURE logistica.InsertarProducto
(	
	@nombre VARCHAR(100),	
	@descripcion VARCHAR(500),
	@precio REAL
)
AS
BEGIN
	INSERT INTO logistica.Producto
	(
		Nombre,
		Descripcion,
		Precio
	)
	VALUES 
	(		
		@nombre,
		@descripcion,
		@precio
	)
END
GO
CREATE PROCEDURE logistica.ListarProducto
AS
BEGIN
	SELECT
		*
	FROM logistica.Producto
END
GO
CREATE PROCEDURE logistica.ObtenerProducto
(
	@idProducto INT
)
AS
BEGIN
    SELECT
		*
	FROM logistica.Producto
    WHERE
		IdProducto = @idProducto
END
GO
-- FacturaProducto
IF OBJECT_ID('facturacion.ActualizarFacturaProducto' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.ActualizarFacturaProducto
GO
IF OBJECT_ID('facturacion.EliminarFacturaProductoPorFactura' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.EliminarFacturaProductoPorFactura
GO
IF OBJECT_ID('facturacion.InsertarFacturaProducto' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.InsertarFacturaProducto
GO
IF OBJECT_ID('facturacion.ListarFacturaProducto' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.ListarFacturaProducto
GO
IF OBJECT_ID('facturacion.ObtenerFacturaProducto' , 'P') IS NOT NULL
	DROP PROCEDURE facturacion.ObtenerFacturaProducto
GO
CREATE PROCEDURE facturacion.EliminarFacturaProductoPorFactura
(
	@idFactura INT
)
AS
BEGIN
    DELETE
	FROM facturacion.FacturaProducto
    WHERE
		@idFactura = @idFactura
END
GO
CREATE PROCEDURE facturacion.InsertarFacturaProducto
(	
	@idFactura INT,	
	@idProducto INT,
	@cantidad INT
)
AS
BEGIN
	INSERT INTO facturacion.FacturaProducto
	(
		IdFactura,
		IdProducto,
		Cantidad
	)
	VALUES 
	(		
		@idFactura,
		@idProducto,
		@cantidad
	)
END
GO
CREATE PROCEDURE facturacion.ListarFacturaProducto
AS
BEGIN
	SELECT
		*
	FROM facturacion.FacturaProducto
END
GO
CREATE PROCEDURE facturacion.ObtenerFacturaProducto
(
	@idProducto INT,
	@idFactura INT
)
AS
BEGIN
    SELECT
		*
	FROM facturacion.FacturaProducto
    WHERE
		IdProducto = @idProducto
	AND IdFactura = @idProducto
END
GO