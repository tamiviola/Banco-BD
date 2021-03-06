USE [master]
GO
/****** Object:  Database [Banco]    Script Date: 27/10/2015 15:52:14 ******/
CREATE DATABASE [Banco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Banco', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Banco.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Banco_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Banco_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Banco] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Banco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Banco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Banco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Banco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Banco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Banco] SET ARITHABORT OFF 
GO
ALTER DATABASE [Banco] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Banco] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Banco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Banco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Banco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Banco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Banco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Banco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Banco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Banco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Banco] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Banco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Banco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Banco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Banco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Banco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Banco] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Banco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Banco] SET RECOVERY FULL 
GO
ALTER DATABASE [Banco] SET  MULTI_USER 
GO
ALTER DATABASE [Banco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Banco] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Banco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Banco] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Banco', N'ON'
GO
USE [Banco]
GO
/****** Object:  UserDefinedTableType [dbo].[ListaClientes]    Script Date: 27/10/2015 15:52:15 ******/
CREATE TYPE [dbo].[ListaClientes] AS TABLE(
	[Id] [int] NOT NULL
)
GO
/****** Object:  StoredProcedure [dbo].[s_ConsultarPorIdCuenta]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_ConsultarPorIdCuenta]
	@Id int
AS
BEGIN
	SELECT * FROM Cuentas WHERE Id = @Id

	SELECT c.Id, c.Nombre, c.Apellido, c.Direccion, t.Tipo, t.Numero
	FROM Clientes c, Telefonos t, Cuentas_Clientes cc
	WHERE c.Telefono_Id = t.Id AND cc.Cliente_Id = c.Id AND cc.Cuenta_Id = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[s_CrearCliente]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_CrearCliente]
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Direccion varchar(50),
	@Tipo varchar(50),
	@Numero varchar(50)

AS
BEGIN

INSERT INTO Telefonos (Tipo,Numero)
VALUES (@Tipo,@Numero)

DECLARE @Telefono_Id int
SET @Telefono_Id = (SELECT MAX (Id)FROM Telefonos)

INSERT INTO Clientes (Nombre,Apellido,Direccion,Telefono_Id)
VALUES (@Nombre,@Apellido,@Direccion,@Telefono_Id)

END

GO
/****** Object:  StoredProcedure [dbo].[s_CrearCuenta]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_CrearCuenta]
	@Tipo varchar(50),
	@Clientes As ListaClientes READONLY
AS
BEGIN

INSERT INTO Cuentas (Tipo,Saldo)
VALUES(@Tipo,0)

DECLARE @Cuenta_Id int
SET @Cuenta_Id = (SELECT MAX (Id) FROM Cuentas)

INSERT INTO Cuentas_Clientes (Cuenta_Id,Cliente_Id)
SELECT @Cuenta_Id, Id FROM @Clientes

END

GO
/****** Object:  StoredProcedure [dbo].[s_EditarCliente]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_EditarCliente]
	@Id int,
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Direccion varchar(50),
	@Tipo varchar(50),
	@Numero varchar(50)

AS
BEGIN

UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion WHERE ID = @Id

UPDATE Telefonos SET Tipo = @Tipo, Numero = @Numero WHERE Id = (SELECT Telefono_Id FROM Clientes WHERE Id = @Id)

END

GO
/****** Object:  StoredProcedure [dbo].[s_EditarCuenta]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_EditarCuenta]
	@Id int,
	@Tipo varchar(50),
	@Saldo float,
	@Clientes As ListaClientes READONLY
AS
BEGIN

UPDATE Cuentas SET Saldo = @Saldo, Tipo = @Tipo WHERE Id = @Id

DELETE FROM Cuentas_Clientes WHERE Cuenta_Id = @Id

INSERT INTO Cuentas_Clientes (Cuenta_Id,Cliente_Id)
SELECT @Id, Id FROM @Clientes

END

GO
/****** Object:  StoredProcedure [dbo].[s_EliminarCliente]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_EliminarCliente]
	@Id int

AS
BEGIN

DELETE FROM Clientes WHERE Id = @Id

DELETE FROM Telefonos WHERE Id = (SELECT Telefono_Id FROM Clientes WHERE Id = @Id)

END

GO
/****** Object:  StoredProcedure [dbo].[s_ListarCliente]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_ListarCliente]
AS
BEGIN
	SELECT c.Id,c.Nombre,c.Apellido,c.Direccion,t.Tipo,t.Numero 
	FROM Clientes c,Telefonos t
	WHERE c.Telefono_Id = t.Id

END

GO
/****** Object:  StoredProcedure [dbo].[s_ListarCuenta]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_ListarCuenta]
AS
BEGIN
	SELECT Id,Saldo,Tipo FROM Cuentas
END

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono_Id] [int] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Saldo] [float] NULL,
	[Tipo] [varchar](50) NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuentas_Clientes]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas_Clientes](
	[Cuenta_Id] [int] NOT NULL,
	[Cliente_Id] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Cuentas_Clientes] PRIMARY KEY CLUSTERED 
(
	[Cuenta_Id] ASC,
	[Cliente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefonos]    Script Date: 27/10/2015 15:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefonos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NULL,
	[Numero] [varchar](50) NULL,
 CONSTRAINT [PK_Telefonos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Banco] SET  READ_WRITE 
GO
