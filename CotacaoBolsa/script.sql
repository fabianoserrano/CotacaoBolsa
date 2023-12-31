USE [master]
GO

CREATE DATABASE [cotacaoBolsa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cotacaoBolsa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\cotacaoBolsa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cotacaoBolsa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\cotacaoBolsa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [cotacaoBolsa] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cotacaoBolsa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cotacaoBolsa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET ARITHABORT OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [cotacaoBolsa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cotacaoBolsa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cotacaoBolsa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [cotacaoBolsa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cotacaoBolsa] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [cotacaoBolsa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cotacaoBolsa] SET  MULTI_USER 
GO
ALTER DATABASE [cotacaoBolsa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cotacaoBolsa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cotacaoBolsa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cotacaoBolsa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cotacaoBolsa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cotacaoBolsa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [cotacaoBolsa] SET QUERY_STORE = ON
GO
ALTER DATABASE [cotacaoBolsa] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [cotacaoBolsa]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataCotacao] [datetime] NOT NULL,
	[CodigoAtivo] [nvarchar](6) NOT NULL,
	[ValorFechamento] [decimal](18, 4) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataModificacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Cotacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Cotacao_DataCotacao] ON [dbo].[Cotacao]
(
	[DataCotacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [cotacaoBolsa] SET  READ_WRITE 
GO
