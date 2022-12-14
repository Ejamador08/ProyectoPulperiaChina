USE [Respaldo_PulperiaChina]
GO
/****** Object:  Table [dbo].[CatMarca]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatMarca](
	[IDMarca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Marca] [nvarchar](100) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_tblMarca] PRIMARY KEY CLUSTERED 
(
	[IDMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CatMarca] ON
INSERT [dbo].[CatMarca] ([IDMarca], [Nombre_Marca], [Estado]) VALUES (1, N'Mabe', 1)
INSERT [dbo].[CatMarca] ([IDMarca], [Nombre_Marca], [Estado]) VALUES (2, N'Sony', 1)
INSERT [dbo].[CatMarca] ([IDMarca], [Nombre_Marca], [Estado]) VALUES (3, N'Lg', 1)
INSERT [dbo].[CatMarca] ([IDMarca], [Nombre_Marca], [Estado]) VALUES (4, N'Oster', 1)
SET IDENTITY_INSERT [dbo].[CatMarca] OFF
/****** Object:  Table [dbo].[CatEmpleado]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatEmpleado](
	[IDEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NULL,
	[Apellido1] [nvarchar](30) NULL,
	[Apellido2] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](50) NULL,
	[E-Mail] [nvarchar](70) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Estado] [bit] NULL,
	[ImgEmpleado] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblUsuario] PRIMARY KEY CLUSTERED 
(
	[IDEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatDepartamento]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatDepartamento](
	[ID_Departamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Depto] [nvarchar](30) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_tblDepartamento] PRIMARY KEY CLUSTERED 
(
	[ID_Departamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CatDepartamento] ON
INSERT [dbo].[CatDepartamento] ([ID_Departamento], [Nombre_Depto], [Estado]) VALUES (1, N'Carazo', NULL)
SET IDENTITY_INSERT [dbo].[CatDepartamento] OFF
/****** Object:  Table [dbo].[CatCategoria]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatCategoria](
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Categoria] [nvarchar](80) NOT NULL,
	[Descripcion_Categoria] [nvarchar](300) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_tblCategoria] PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CatCategoria] ON
INSERT [dbo].[CatCategoria] ([ID_Categoria], [Nombre_Categoria], [Descripcion_Categoria], [Estado]) VALUES (1, N'Linea Blanca', N'Esta comprende varios articulos de la cocina.', NULL)
INSERT [dbo].[CatCategoria] ([ID_Categoria], [Nombre_Categoria], [Descripcion_Categoria], [Estado]) VALUES (2, N'Muebles', N'aqui estan ubicados todo tipo de muebles para el hogar.', NULL)
INSERT [dbo].[CatCategoria] ([ID_Categoria], [Nombre_Categoria], [Descripcion_Categoria], [Estado]) VALUES (3, N'Materiales de Contruccion', N'estos son los principales materiales que demandan.', NULL)
SET IDENTITY_INSERT [dbo].[CatCategoria] OFF
/****** Object:  Table [dbo].[CatBodega]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatBodega](
	[ID_Bodega] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Bodega] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_CatBodega] PRIMARY KEY CLUSTERED 
(
	[ID_Bodega] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[ID_Informacion] [int] NULL,
	[Nombre] [nvarchar](100) NULL,
	[Propietari@] [nvarchar](100) NULL,
	[Admonistrad@r] [nvarchar](100) NULL,
	[Ubicacion] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Municipio] [nvarchar](100) NULL,
	[Departamento] [nvarchar](100) NULL,
	[Telefono] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Logo] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatUsuario]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatUsuario](
	[ID_Usuario] [int] NOT NULL,
	[Nombre_User] [nvarchar](100) NULL,
	[Apellido1_User] [nvarchar](100) NULL,
	[Apellido2_User] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[Tipo_Usuario] [nvarchar](100) NULL,
	[ImgUser] [nvarchar](100) NULL,
 CONSTRAINT [PK_CatUsuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatProveedor]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatProveedor](
	[ID_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Proveedor] [nvarchar](100) NULL,
	[Telefono] [varchar](100) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Estado] [bit] NULL,
	[RutaLogo] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblProveedor] PRIMARY KEY CLUSTERED 
(
	[ID_Proveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CatProveedor] ON
INSERT [dbo].[CatProveedor] ([ID_Proveedor], [Nombre_Proveedor], [Telefono], [Direccion], [Email], [Estado], [RutaLogo]) VALUES (1, N'La Principal S.A', N'88776655', N'Del reloj Diriamba 2c. abajo', NULL, NULL, NULL)
INSERT [dbo].[CatProveedor] ([ID_Proveedor], [Nombre_Proveedor], [Telefono], [Direccion], [Email], [Estado], [RutaLogo]) VALUES (2, N'El Superior', N'25329009', N'Jinotepe, Carazo', NULL, NULL, NULL)
INSERT [dbo].[CatProveedor] ([ID_Proveedor], [Nombre_Proveedor], [Telefono], [Direccion], [Email], [Estado], [RutaLogo]) VALUES (3, N'El Rey', N'23456789', N'Managua, Av. Bolivar', NULL, NULL, NULL)
INSERT [dbo].[CatProveedor] ([ID_Proveedor], [Nombre_Proveedor], [Telefono], [Direccion], [Email], [Estado], [RutaLogo]) VALUES (4, N'Distribución 2000', N'81234567', N'de los juzgado jinotepe 2c. oeste', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CatProveedor] OFF
/****** Object:  Table [dbo].[tblCaja]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCaja](
	[Fecha_Apertura] [date] NULL,
	[Hora_Apertura] [time](7) NULL,
	[Monto_Apertura] [float] NULL,
	[Fecha_Cierre] [date] NULL,
	[Hora_Cierre] [time](7) NULL,
	[Monto_Cierre] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPedidos]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPedidos](
	[ID_Compra] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Compra] [datetime] NULL,
	[Fecha_Recepcion] [datetime] NULL,
	[Sub-Total] [real] NULL,
	[IVA] [real] NULL,
	[Descuento] [real] NULL,
	[Total] [real] NULL,
	[Pendiente_Aprobacion] [nvarchar](60) NULL,
	[ID_Proveedor] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_tblCompra] PRIMARY KEY CLUSTERED 
(
	[ID_Compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatMunicipio]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatMunicipio](
	[ID_Municipio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Municipio] [nvarchar](30) NULL,
	[ID_Departamento] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_tblMunicipio] PRIMARY KEY CLUSTERED 
(
	[ID_Municipio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CatMunicipio] ON
INSERT [dbo].[CatMunicipio] ([ID_Municipio], [Nombre_Municipio], [ID_Departamento], [Estado]) VALUES (1, N'Dolores', 1, NULL)
SET IDENTITY_INSERT [dbo].[CatMunicipio] OFF
/****** Object:  Table [dbo].[CatArticulo]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatArticulo](
	[ID_Articulo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Articulo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[ID_Categoria] [int] NOT NULL,
	[ID_Proveedor] [int] NOT NULL,
	[ID_Marca] [int] NULL,
	[Estado] [bit] NULL,
	[RutaImagen] [varchar](300) NULL,
 CONSTRAINT [PK_tblArticulo] PRIMARY KEY CLUSTERED 
(
	[ID_Articulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CatArticulo] ON
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (1, N'Refrigeradora', NULL, 1, 2, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (2, N'Arena_Negra', NULL, 3, 3, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (3, N'Sofa_Principal', NULL, 2, 1, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (4, N'Cocina', NULL, 1, 2, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (5, N'Cemento', NULL, 3, 3, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (6, N'Comedor', NULL, 2, 1, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (7, N'Licuadora', NULL, 1, 2, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (8, N'Zinc', NULL, 3, 3, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (9, N'Estante', NULL, 2, 1, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (10, N'MicroOnda', NULL, 1, 2, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (11, N'Bloque', NULL, 3, 3, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (12, N'Silla_Mecedora', NULL, 2, 1, NULL, 1, NULL)
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (13, N'Arenilla', NULL, 3, 3, NULL, 1, N'Imagenes/Articulos.png')
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (14, N'Hierro', NULL, 3, 3, NULL, 1, N'Imagenes/Articulos.png')
INSERT [dbo].[CatArticulo] ([ID_Articulo], [Nombre_Articulo], [Descripcion], [ID_Categoria], [ID_Proveedor], [ID_Marca], [Estado], [RutaImagen]) VALUES (15, N'assss', NULL, 1, 1, NULL, 1, N'Imagenes/ImagenesArticulos/775a5504-1463-462e-a0b9-f1bac7c3224f.jpg')
SET IDENTITY_INSERT [dbo].[CatArticulo] OFF
/****** Object:  Table [dbo].[CatCliente]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatCliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Cliente] [nvarchar](60) NOT NULL,
	[Apellido1_Cliente] [nvarchar](60) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[N° de Cedula] [nvarchar](30) NULL,
	[Telefono_Celular] [varchar](20) NULL,
	[Estado] [bit] NULL,
	[ID_Municipio] [int] NULL,
	[Email] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](40) NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CatCliente] ON
INSERT [dbo].[CatCliente] ([ID_Cliente], [Nombre_Cliente], [Apellido1_Cliente], [Direccion], [N° de Cedula], [Telefono_Celular], [Estado], [ID_Municipio], [Email], [UserName]) VALUES (1, N'Eliezer', N'Amador', N'del parque de Dolores 2 c. abajo 75vrs. norte', N'000-000000-000E', N'81211633', 1, 1, N'15000', N'Jah')
SET IDENTITY_INSERT [dbo].[CatCliente] OFF
/****** Object:  Table [dbo].[tblArticulo_Bodega]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArticulo_Bodega](
	[ID_Articulo] [int] NOT NULL,
	[ID_Bodega] [int] NOT NULL,
	[Precio_Compra] [real] NOT NULL,
	[Precion_Venta] [real] NOT NULL,
	[ID_Marca] [int] NOT NULL,
	[Existencia] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVentaCredito]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVentaCredito](
	[ID_Venta] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cliente] [int] NULL,
	[ID_Articulo] [int] NOT NULL,
	[Feche_Venta] [date] NOT NULL,
	[Plazos] [real] NOT NULL,
	[Prima] [real] NULL,
	[Interes] [real] NOT NULL,
	[Descuento] [real] NULL,
 CONSTRAINT [PK_tblVentaCredito] PRIMARY KEY CLUSTERED 
(
	[ID_Venta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVenta]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVenta](
	[ID_Venta] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Vta] [datetime] NULL,
	[ID_Cliente] [int] NULL,
	[ID_Usuario] [int] NOT NULL,
	[NombreCliente] [nvarchar](100) NULL,
	[SubTotal] [real] NOT NULL,
	[IVA] [real] NOT NULL,
	[Descuento] [real] NULL,
	[Total] [real] NOT NULL,
	[Anulada] [nvarchar](30) NULL,
 CONSTRAINT [PK_tblVenta] PRIMARY KEY CLUSTERED 
(
	[ID_Venta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDetalleVentaCredito]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDetalleVentaCredito](
	[ID_VentaCredito] [int] NULL,
	[ID_Producto] [int] NULL,
	[Cantidad] [nchar](10) NULL,
	[Precio] [nchar](10) NULL,
	[IVA] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDetalleVenta]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDetalleVenta](
	[ID_Articulo] [int] NULL,
	[ID_Venta] [int] NULL,
	[SubTotal] [real] NULL,
	[Estado] [nvarchar](100) NULL,
	[Descuento] [real] NULL,
	[Precio] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAbono_Cliente]    Script Date: 10/30/2016 17:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAbono_Cliente](
	[ID_VentaCredito] [int] NOT NULL,
	[Fecha_Abono] [datetime] NOT NULL,
	[Monto_Abono] [real] NOT NULL,
	[Mora] [real] NULL,
 CONSTRAINT [PK_tblAbono] PRIMARY KEY CLUSTERED 
(
	[ID_VentaCredito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_CatArticulo_CatCategoria]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[CatArticulo]  WITH CHECK ADD  CONSTRAINT [FK_CatArticulo_CatCategoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[CatCategoria] ([ID_Categoria])
GO
ALTER TABLE [dbo].[CatArticulo] CHECK CONSTRAINT [FK_CatArticulo_CatCategoria]
GO
/****** Object:  ForeignKey [FK_CatArticulo_CatMarca]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[CatArticulo]  WITH CHECK ADD  CONSTRAINT [FK_CatArticulo_CatMarca] FOREIGN KEY([ID_Marca])
REFERENCES [dbo].[CatMarca] ([IDMarca])
GO
ALTER TABLE [dbo].[CatArticulo] CHECK CONSTRAINT [FK_CatArticulo_CatMarca]
GO
/****** Object:  ForeignKey [FK_CatArticulo_CatProveedor]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[CatArticulo]  WITH CHECK ADD  CONSTRAINT [FK_CatArticulo_CatProveedor] FOREIGN KEY([ID_Proveedor])
REFERENCES [dbo].[CatProveedor] ([ID_Proveedor])
GO
ALTER TABLE [dbo].[CatArticulo] CHECK CONSTRAINT [FK_CatArticulo_CatProveedor]
GO
/****** Object:  ForeignKey [FK_tblCliente_tblMunicipio]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[CatCliente]  WITH CHECK ADD  CONSTRAINT [FK_tblCliente_tblMunicipio] FOREIGN KEY([ID_Municipio])
REFERENCES [dbo].[CatMunicipio] ([ID_Municipio])
GO
ALTER TABLE [dbo].[CatCliente] CHECK CONSTRAINT [FK_tblCliente_tblMunicipio]
GO
/****** Object:  ForeignKey [FK_tblMunicipio_tblDepartamento]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[CatMunicipio]  WITH CHECK ADD  CONSTRAINT [FK_tblMunicipio_tblDepartamento] FOREIGN KEY([ID_Departamento])
REFERENCES [dbo].[CatDepartamento] ([ID_Departamento])
GO
ALTER TABLE [dbo].[CatMunicipio] CHECK CONSTRAINT [FK_tblMunicipio_tblDepartamento]
GO
/****** Object:  ForeignKey [FK_tblAbono_tblVentaCredito]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblAbono_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_tblAbono_tblVentaCredito] FOREIGN KEY([ID_VentaCredito])
REFERENCES [dbo].[tblVentaCredito] ([ID_Venta])
GO
ALTER TABLE [dbo].[tblAbono_Cliente] CHECK CONSTRAINT [FK_tblAbono_tblVentaCredito]
GO
/****** Object:  ForeignKey [FK_tblAbono_tblVentaCredito1]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblAbono_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_tblAbono_tblVentaCredito1] FOREIGN KEY([ID_VentaCredito])
REFERENCES [dbo].[tblVentaCredito] ([ID_Venta])
GO
ALTER TABLE [dbo].[tblAbono_Cliente] CHECK CONSTRAINT [FK_tblAbono_tblVentaCredito1]
GO
/****** Object:  ForeignKey [FK_tblArticulo_Bodega_CatArticulo]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblArticulo_Bodega]  WITH CHECK ADD  CONSTRAINT [FK_tblArticulo_Bodega_CatArticulo] FOREIGN KEY([ID_Articulo])
REFERENCES [dbo].[CatArticulo] ([ID_Articulo])
GO
ALTER TABLE [dbo].[tblArticulo_Bodega] CHECK CONSTRAINT [FK_tblArticulo_Bodega_CatArticulo]
GO
/****** Object:  ForeignKey [FK_tblArticulo_Bodega_CatBodega]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblArticulo_Bodega]  WITH CHECK ADD  CONSTRAINT [FK_tblArticulo_Bodega_CatBodega] FOREIGN KEY([ID_Bodega])
REFERENCES [dbo].[CatBodega] ([ID_Bodega])
GO
ALTER TABLE [dbo].[tblArticulo_Bodega] CHECK CONSTRAINT [FK_tblArticulo_Bodega_CatBodega]
GO
/****** Object:  ForeignKey [FK_tblDetalleVenta_tblArticulo]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblDetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_tblDetalleVenta_tblArticulo] FOREIGN KEY([ID_Articulo])
REFERENCES [dbo].[CatArticulo] ([ID_Articulo])
GO
ALTER TABLE [dbo].[tblDetalleVenta] CHECK CONSTRAINT [FK_tblDetalleVenta_tblArticulo]
GO
/****** Object:  ForeignKey [FK_tblDetalleVenta_tblVenta]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblDetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_tblDetalleVenta_tblVenta] FOREIGN KEY([ID_Venta])
REFERENCES [dbo].[tblVenta] ([ID_Venta])
GO
ALTER TABLE [dbo].[tblDetalleVenta] CHECK CONSTRAINT [FK_tblDetalleVenta_tblVenta]
GO
/****** Object:  ForeignKey [FK_tblDetalleVentaCredito_tblVentaCredito]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblDetalleVentaCredito]  WITH CHECK ADD  CONSTRAINT [FK_tblDetalleVentaCredito_tblVentaCredito] FOREIGN KEY([ID_VentaCredito])
REFERENCES [dbo].[tblVentaCredito] ([ID_Venta])
GO
ALTER TABLE [dbo].[tblDetalleVentaCredito] CHECK CONSTRAINT [FK_tblDetalleVentaCredito_tblVentaCredito]
GO
/****** Object:  ForeignKey [FK_tblCompra_tblProveedor]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblPedidos]  WITH CHECK ADD  CONSTRAINT [FK_tblCompra_tblProveedor] FOREIGN KEY([ID_Proveedor])
REFERENCES [dbo].[CatProveedor] ([ID_Proveedor])
GO
ALTER TABLE [dbo].[tblPedidos] CHECK CONSTRAINT [FK_tblCompra_tblProveedor]
GO
/****** Object:  ForeignKey [FK_tblVenta_tblCliente]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblVenta]  WITH CHECK ADD  CONSTRAINT [FK_tblVenta_tblCliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[CatCliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[tblVenta] CHECK CONSTRAINT [FK_tblVenta_tblCliente]
GO
/****** Object:  ForeignKey [FK_tblVenta_tblUsuario]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblVenta]  WITH CHECK ADD  CONSTRAINT [FK_tblVenta_tblUsuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[CatEmpleado] ([IDEmpleado])
GO
ALTER TABLE [dbo].[tblVenta] CHECK CONSTRAINT [FK_tblVenta_tblUsuario]
GO
/****** Object:  ForeignKey [FK_tblVentaCredito_tblCliente]    Script Date: 10/30/2016 17:41:59 ******/
ALTER TABLE [dbo].[tblVentaCredito]  WITH CHECK ADD  CONSTRAINT [FK_tblVentaCredito_tblCliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[CatCliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[tblVentaCredito] CHECK CONSTRAINT [FK_tblVentaCredito_tblCliente]
GO
