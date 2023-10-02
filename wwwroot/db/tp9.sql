USE [master]
GO
/****** Object:  Database [TP9]    Script Date: 2/10/2023 10:42:11 ******/
CREATE DATABASE [TP9]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP9', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TP9.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP9_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TP9_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP9] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP9].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP9] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP9] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP9] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP9] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP9] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP9] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP9] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP9] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP9] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP9] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP9] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP9] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP9] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP9] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP9] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP9] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP9] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP9] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP9] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP9] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP9] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP9] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP9] SET RECOVERY FULL 
GO
ALTER DATABASE [TP9] SET  MULTI_USER 
GO
ALTER DATABASE [TP9] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP9] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP9] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP9] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP9] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP9', N'ON'
GO
ALTER DATABASE [TP9] SET QUERY_STORE = OFF
GO
USE [TP9]
GO
/****** Object:  User [alumno]    Script Date: 2/10/2023 10:42:11 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/10/2023 10:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[contraseña] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[sexo] [char](1) NULL,
	[fotoPerfil] [varchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idusuario], [username], [contraseña], [email], [fechaNacimiento], [fechaRegistro], [sexo], [fotoPerfil]) VALUES (3, N'dante', N'reifut', N'dante@dante.com', CAST(N'2023-10-01' AS Date), CAST(N'2023-10-02' AS Date), N'h', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 2/10/2023 10:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Login]
@nombreUsuario varchar(100), @contraseña varchar(100)
as
begin
declare 
@idUsuario int, @contraseñacorrecta varchar(100)
select @idUsuario=idusuario,@contraseñacorrecta=contraseña from Usuario where username=@nombreUsuario

if (@contraseña=@contraseñacorrecta)
begin
return 1

end
else
begin
return 0
end

end;

GO
/****** Object:  StoredProcedure [dbo].[registrarse]    Script Date: 2/10/2023 10:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[registrarse]
@username nchar(100), @contraseña nchar(100), @email nchar(100), @fechaNacimiento date, @sexo char(1), @foto nchar(3000)
as
begin

if not exists (select * from Usuario where username=@username)
begin
insert into Usuario values (@username,@contraseña,@email,@fechaNacimiento,getdate(),@sexo,@foto)
end
else

begin
print 'El usuario ya esta usado'
end

end;
GO
USE [master]
GO
ALTER DATABASE [TP9] SET  READ_WRITE 
GO
