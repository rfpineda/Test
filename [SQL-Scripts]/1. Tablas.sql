USE [ABC]
GO

/****** Object:  Table [administracion].[Cliente]    Script Date: 01/09/2019 19:03:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [administracion].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nit] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](300) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ABC]
GO

/****** Object:  Table [administracion].[Empleado]    Script Date: 01/09/2019 19:03:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [administracion].[Empleado](
	[IdUsuario] [varchar](50) NOT NULL,
	[Identificacion] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[PrimerApellido] [varchar](100) NOT NULL,
	[SegundoApellido] [varchar](100) NULL,
	[Contrasena] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ABC]
GO

/****** Object:  Table [administracion].[Perfil]    Script Date: 01/09/2019 19:03:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [administracion].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ABC]
GO

/****** Object:  Table [administracion].[EmpleadoPerfil]    Script Date: 01/09/2019 19:04:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [administracion].[EmpleadoPerfil](
	[IdUsuario] [varchar](50) NOT NULL,
	[IdPerfil] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [administracion].[EmpleadoPerfil]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoPerfil_Empleado1] FOREIGN KEY([IdUsuario])
REFERENCES [administracion].[Empleado] ([IdUsuario])
GO

ALTER TABLE [administracion].[EmpleadoPerfil] CHECK CONSTRAINT [FK_EmpleadoPerfil_Empleado1]
GO

ALTER TABLE [administracion].[EmpleadoPerfil]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoPerfil_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [administracion].[Perfil] ([IdPerfil])
GO

ALTER TABLE [administracion].[EmpleadoPerfil] CHECK CONSTRAINT [FK_EmpleadoPerfil_Perfil]
GO


USE [ABC]
GO

/****** Object:  Table [facturacion].[Factura]    Script Date: 01/09/2019 19:04:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [facturacion].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdUsuario] [varchar](50) NOT NULL,
	[MomentoCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [facturacion].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [administracion].[Cliente] ([IdCliente])
GO

ALTER TABLE [facturacion].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO

ALTER TABLE [facturacion].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empleado1] FOREIGN KEY([IdUsuario])
REFERENCES [administracion].[Empleado] ([IdUsuario])
GO

ALTER TABLE [facturacion].[Factura] CHECK CONSTRAINT [FK_Factura_Empleado1]
GO


USE [ABC]
GO

/****** Object:  Table [logistica].[Producto]    Script Date: 01/09/2019 19:05:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [logistica].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](500) NULL,
	[Precio] [real] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





USE [ABC]
GO

/****** Object:  Table [facturacion].[FacturaProducto]    Script Date: 01/09/2019 19:05:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [facturacion].[FacturaProducto](
	[IdFactura] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [facturacion].[FacturaProducto]  WITH CHECK ADD  CONSTRAINT [FK_FacturaProducto_Factura] FOREIGN KEY([IdFactura])
REFERENCES [facturacion].[Factura] ([IdFactura])
GO

ALTER TABLE [facturacion].[FacturaProducto] CHECK CONSTRAINT [FK_FacturaProducto_Factura]
GO

ALTER TABLE [facturacion].[FacturaProducto]  WITH CHECK ADD  CONSTRAINT [FK_FacturaProducto_Producto] FOREIGN KEY([IdProducto])
REFERENCES [logistica].[Producto] ([IdProducto])
GO

ALTER TABLE [facturacion].[FacturaProducto] CHECK CONSTRAINT [FK_FacturaProducto_Producto]
GO


