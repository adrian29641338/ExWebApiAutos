USE [master]
GO
/****** Object:  Database [ExamenAutos]    Script Date: 24/01/2019 10:03:55 ******/
CREATE DATABASE [ExamenAutos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExamenAutos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ExamenAutos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExamenAutos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ExamenAutos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ExamenAutos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExamenAutos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExamenAutos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExamenAutos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExamenAutos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExamenAutos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExamenAutos] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExamenAutos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExamenAutos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExamenAutos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExamenAutos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExamenAutos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExamenAutos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExamenAutos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExamenAutos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExamenAutos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExamenAutos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExamenAutos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExamenAutos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExamenAutos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExamenAutos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExamenAutos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExamenAutos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExamenAutos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExamenAutos] SET RECOVERY FULL 
GO
ALTER DATABASE [ExamenAutos] SET  MULTI_USER 
GO
ALTER DATABASE [ExamenAutos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExamenAutos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExamenAutos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExamenAutos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExamenAutos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ExamenAutos', N'ON'
GO
ALTER DATABASE [ExamenAutos] SET QUERY_STORE = OFF
GO
USE [ExamenAutos]
GO
/****** Object:  Table [dbo].[T_Auto]    Script Date: 24/01/2019 10:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Auto](
	[auto_id] [uniqueidentifier] NOT NULL,
	[auto_color] [varchar](20) NOT NULL,
	[auto_aniofabri] [int] NOT NULL,
	[auto_nroplaca] [varchar](10) NOT NULL,
	[auto_nroasientos] [int] NOT NULL,
	[auto_mecanico] [char](2) NOT NULL,
	[auto_full] [char](2) NOT NULL,
	[auto_marca] [varchar](15) NOT NULL,
 CONSTRAINT [PK_T_Auto] PRIMARY KEY CLUSTERED 
(
	[auto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ExamenAutos] SET  READ_WRITE 
GO
