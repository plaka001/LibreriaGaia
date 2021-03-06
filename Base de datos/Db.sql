CREATE DATABASE [Libreria]
GO
USE [Libreria]
GO
/****** Object:  Schema [Libreria]    Script Date: 6/05/2021 1:24:59 p. m. ******/
CREATE SCHEMA [Libreria]
GO
/****** Object:  Table [Libreria].[Autores]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Libreria].[Autores](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Pais] [int] NULL,
	[Departamento] [int] NULL,
	[Ciudad] [int] NULL,
	[Sexo] [int] NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Libreria].[Ciudades]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Libreria].[Ciudades](
	[IdCiudad] [int] IDENTITY(1,1) NOT NULL,
	[Ciudad] [varchar](50) NULL,
	[IdDepartamento] [int] NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Libreria].[Departamentos]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Libreria].[Departamentos](
	[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[Departamento] [varchar](50) NULL,
	[IdPais] [int] NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Libreria].[Libros]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Libreria].[Libros](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaEscritura] [date] NULL,
	[Costo] [decimal](19, 3) NULL,
	[IdAutor] [int] NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Libreria].[Paises]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Libreria].[Paises](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](50) NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Libreria].[Sexo]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Libreria].[Sexo](
	[IdSexo] [int] IDENTITY(1,1) NOT NULL,
	[Sexo] [varchar](50) NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [date] NULL,
	[FechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
GO
SET IDENTITY_INSERT [Libreria].[Ciudades] ON 

INSERT [Libreria].[Ciudades] ([IdCiudad], [Ciudad], [IdDepartamento], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (1, N'Medellin', 1, 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Ciudades] ([IdCiudad], [Ciudad], [IdDepartamento], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (2, N'Bogota', 2, 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Ciudades] ([IdCiudad], [Ciudad], [IdDepartamento], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (3, N'León', 3, 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Ciudades] ([IdCiudad], [Ciudad], [IdDepartamento], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (4, N'Ciudad de Mexico', 4, 1, CAST(N'2021-04-29' AS Date), NULL)
SET IDENTITY_INSERT [Libreria].[Ciudades] OFF
GO
SET IDENTITY_INSERT [Libreria].[Departamentos] ON 

INSERT [Libreria].[Departamentos] ([IdDepartamento], [Departamento], [IdPais], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (1, N'Antioquia', 1, 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Departamentos] ([IdDepartamento], [Departamento], [IdPais], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (2, N'Cundinamarca', 1, 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Departamentos] ([IdDepartamento], [Departamento], [IdPais], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (3, N'Guanajuato', 2, 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Departamentos] ([IdDepartamento], [Departamento], [IdPais], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (4, N'Oaxaca', 2, 1, CAST(N'2021-04-29' AS Date), NULL)
SET IDENTITY_INSERT [Libreria].[Departamentos] OFF
GO
SET IDENTITY_INSERT [Libreria].[Paises] ON 

INSERT [Libreria].[Paises] ([IdPais], [Pais], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (1, N'Colombia', 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Paises] ([IdPais], [Pais], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (2, N'Mexico', 1, CAST(N'2021-04-29' AS Date), NULL)
SET IDENTITY_INSERT [Libreria].[Paises] OFF
GO
SET IDENTITY_INSERT [Libreria].[Sexo] ON 

INSERT [Libreria].[Sexo] ([IdSexo], [Sexo], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (1, N'Masculino', 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Sexo] ([IdSexo], [Sexo], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (2, N'Femenino', 1, CAST(N'2021-04-29' AS Date), NULL)
INSERT [Libreria].[Sexo] ([IdSexo], [Sexo], [Activo], [FechaRegistro], [FechaModificacion]) VALUES (3, N'No responde', 1, CAST(N'2021-04-29' AS Date), NULL)
SET IDENTITY_INSERT [Libreria].[Sexo] OFF
GO
ALTER TABLE [Libreria].[Autores]  WITH CHECK ADD FOREIGN KEY([Ciudad])
REFERENCES [Libreria].[Ciudades] ([IdCiudad])
GO
ALTER TABLE [Libreria].[Autores]  WITH CHECK ADD FOREIGN KEY([Departamento])
REFERENCES [Libreria].[Departamentos] ([IdDepartamento])
GO
ALTER TABLE [Libreria].[Autores]  WITH CHECK ADD FOREIGN KEY([Pais])
REFERENCES [Libreria].[Paises] ([IdPais])
GO
ALTER TABLE [Libreria].[Autores]  WITH CHECK ADD FOREIGN KEY([Sexo])
REFERENCES [Libreria].[Sexo] ([IdSexo])
GO
ALTER TABLE [Libreria].[Ciudades]  WITH CHECK ADD FOREIGN KEY([IdCiudad])
REFERENCES [Libreria].[Departamentos] ([IdDepartamento])
GO
ALTER TABLE [Libreria].[Departamentos]  WITH CHECK ADD FOREIGN KEY([IdPais])
REFERENCES [Libreria].[Paises] ([IdPais])
GO
ALTER TABLE [Libreria].[Libros]  WITH CHECK ADD FOREIGN KEY([IdAutor])
REFERENCES [Libreria].[Autores] ([IdAutor])
GO
/****** Object:  StoredProcedure [Libreria].[ActualizarAutores]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<John Marlon Cano>
-- Description:	<Actualiza los autores>
-- =============================================
CREATE PROCEDURE [Libreria].[ActualizarAutores]
@Nombre varchar(50),
@Apellido varchar(50),
@Edad int,
@Pais int,
@Departamento int,
@Ciudad int,
@Sexo int,
@IdAutor int output

AS
BEGIN

UPDATE [Libreria].[Autores]
   SET [Nombre] = @Nombre
      ,[Pais] = @Pais
	  ,[Apellido] = @Apellido
      ,[Edad] = @Edad
	  ,[Departamento] = @Departamento
      ,[Ciudad] = @Ciudad
      ,[Sexo] = @Sexo
      ,[FechaModificacion] = GETDATE()
 WHERE [IdAutor] = @IdAutor

END
GO
/****** Object:  StoredProcedure [Libreria].[ActualizarLibros]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<John Marlon Cano>
-- Description:	<Actualiza los libros>
-- =============================================
CREATE PROCEDURE [Libreria].[ActualizarLibros]
@Nombre varchar(50),
@FechaEscritura datetime,
@Costo decimal(19,3),
@IdAutor int,
@IdLibro int output

AS
BEGIN

UPDATE [Libreria].[Libros]
   SET [Nombre] =@Nombre
      ,[FechaEscritura] = CAST (@FechaEscritura as DATE)
      ,[Costo] = @Costo
      ,[IdAutor] = @IdAutor
      ,[FechaModificacion] = GETDATE()
 WHERE [IdLibro] = @IdLibro

END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarAutores]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<John Marlon Cano>
-- Description:	<Consulta los autores>
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarAutores]

AS
BEGIN

SELECT Au.IdAutor, Au.Nombre,Au.Apellido,Au.Edad, Na.Pais as Pais,De.Departamento,Ciu.Ciudad,Se.Sexo,COUNT(Li.IdAutor) AS CantidadLibros FROM Libreria.Autores AS Au 
	INNER JOIN Libreria.Paises AS Na	ON Au.Pais = Na.IdPais
	INNER JOIN Libreria.Departamentos AS De on Au.Departamento = De.IdDepartamento
	INNER JOIN Libreria.Ciudades	 AS Ciu ON Au.Ciudad       = Ciu.IdCiudad
	INNER JOIN Libreria.Sexo		 AS Se  ON Au.Sexo         = Se.IdSexo
	LEFT JOIN Libreria.Libros		 AS Li  ON Au.IdAutor      = Li.IdAutor
		GROUP BY Au.IdAutor,Au.Nombre,Au.Apellido,Au.Edad,Na.Pais,De.Departamento,Ciu.Ciudad,Se.Sexo,Li.IdAutor


END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarAutoresById]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<John Marlon Cano>
-- Description:	<Consulta los autores>
--exec [Libreria].[ConsultarAutoresById] 7
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarAutoresById]
@IdAutor int
AS
BEGIN

SELECT Au.IdAutor, Au.Nombre,Au.Apellido,Au.Edad FROM Libreria.Autores AS Au 
	
		WHERE Au.IdAutor = @IdAutor
		GROUP BY Au.IdAutor,Au.Nombre,Au.Apellido,Au.Edad


END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarCiudades]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<John Marlon Cano>
-- Description:	<Consulta las ciudades>
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarCiudades]
@IdDepartamento int
AS
BEGIN

SELECT IdCiudad,Ciudad FROM Libreria.Ciudades WHERE Activo = 1 and IdDepartamento = @IdDepartamento

END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarDepartamentos]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarDepartamentos]
@Idpais int
AS
BEGIN

SELECT IdDepartamento,Departamento FROM Libreria.Departamentos WHERE Activo = 1 and IdPais = @Idpais

END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarLibros]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarLibros]

AS
BEGIN

SELECT Li.IdLibro,Li.Nombre,Li.FechaEscritura, Li.Costo,Au.Nombre AS NombreAutor FROM Libreria.Libros as Li
	INNER JOIN Libreria.Autores AS Au ON li.IdAutor = Au.IdAutor


END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarLibrosById]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<John Marlon Cano>
-- Description:	<Consulta los autores>
--exec [Libreria].[ConsultarLibrosById] 2
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarLibrosById]
@IdLibro int
AS
BEGIN

SELECT IdLibro,Nombre,FechaEscritura,Costo  FROM Libreria.Libros AS Au 
	
		WHERE Au.IdLibro = @IdLibro


END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarPaises]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarPaises]

AS
BEGIN

SELECT IdPais,Pais FROM Libreria.Paises WHERE Activo = 1

END
GO
/****** Object:  StoredProcedure [Libreria].[ConsultarSexos]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[ConsultarSexos]

AS
BEGIN

SELECT IdSexo,Sexo FROM Libreria.Sexo WHERE Activo = 1 

END
GO
/****** Object:  StoredProcedure [Libreria].[EliminarAutor]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
--exec [Libreria].[EliminarAutor] 4
-- =============================================
CREATE PROCEDURE [Libreria].[EliminarAutor]
@IdAutor int output 

AS
BEGIN
DECLARE @CantidadLibros int
SET @CantidadLibros = (SELECT COUNT(IdAutor) FROM Libreria.Libros WHERE IdAutor = @IdAutor GROUP BY IdAutor)

IF (@CantidadLibros > 0)
	BEGIN
		SET @IdAutor = 0
		SELECT @IdAutor as IdAutor
	END
	ELSE
	BEGIN 
		DELETE FROM Libreria.Autores WHERE IdAutor = @IdAutor 
		SELECT @IdAutor as IdAutor
	END
END
GO
/****** Object:  StoredProcedure [Libreria].[EliminarLibro]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[EliminarLibro]
@IdLibro int output 

AS
BEGIN

DELETE FROM Libreria.Libros WHERE IdLibro = @IdLibro
     
END
GO
/****** Object:  StoredProcedure [Libreria].[InsertarAutores]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[InsertarAutores]
@Nombre varchar(50),
@Apellido varchar(50),
@Edad int,
@Pais int,
@Departamento int,
@Ciudad int,
@Sexo int,
@IdAutor int output
AS
BEGIN

INSERT INTO [Libreria].[Autores]
           ([Nombre]
		   ,[Apellido]
		   ,[Edad]
           ,[Pais]
		   ,[Departamento]
           ,[Ciudad]
           ,[Sexo]
		   ,[FechaRegistro]
			)
     VALUES
			(
				@Nombre,
				@Apellido,
				@Edad,
				@Pais,
				@Departamento,
				@Ciudad,
				@Sexo,
				GETDATE()
			)

	SET @IdAutor = @@IDENTITY
          
END
GO
/****** Object:  StoredProcedure [Libreria].[InsertarLibros]    Script Date: 6/05/2021 1:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Libreria].[InsertarLibros]
@Nombre varchar(50),
@FechaEscritura datetime,
@Costo decimal(19,3),
@IdAutor int,
@IdLibro int output
AS
BEGIN

INSERT INTO [Libreria].[Libros]
           ([Nombre]
           ,[FechaEscritura]
           ,[Costo]
           ,[IdAutor]
           ,[FechaRegistro])
     VALUES
           (@Nombre
           ,CAST(@FechaEscritura AS date)
           ,@Costo
           ,@IdAutor
           ,GETDATE())

	SET @IdLibro = @@IDENTITY
          
END
GO
