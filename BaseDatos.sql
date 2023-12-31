USE [master]
GO
/****** Object:  Database [BancsSQL]    Script Date: 04/07/2023 03:32:29 p. m. ******/
CREATE DATABASE [BancsSQL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancsSQL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BancsSQL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancsSQL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BancsSQL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BancsSQL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancsSQL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BancsSQL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BancsSQL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BancsSQL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BancsSQL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BancsSQL] SET ARITHABORT OFF 
GO
ALTER DATABASE [BancsSQL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BancsSQL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BancsSQL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BancsSQL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BancsSQL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BancsSQL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BancsSQL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BancsSQL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BancsSQL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BancsSQL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BancsSQL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BancsSQL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BancsSQL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BancsSQL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BancsSQL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BancsSQL] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BancsSQL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BancsSQL] SET RECOVERY FULL 
GO
ALTER DATABASE [BancsSQL] SET  MULTI_USER 
GO
ALTER DATABASE [BancsSQL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BancsSQL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BancsSQL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BancsSQL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BancsSQL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BancsSQL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BancsSQL', N'ON'
GO
ALTER DATABASE [BancsSQL] SET QUERY_STORE = OFF
GO
USE [BancsSQL]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/07/2023 03:32:29 p. m. ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 04/07/2023 03:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [uniqueidentifier] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[AccountNumber] [nvarchar](max) NOT NULL,
	[AccountType] [nvarchar](max) NOT NULL,
	[InitialBalance] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 04/07/2023 03:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[Age] [nvarchar](max) NOT NULL,
	[IdentificationCard] [nvarchar](max) NOT NULL,
	[Adress] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 04/07/2023 03:32:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[InitialBalance] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[TransactionType] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Balance] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BancsSQL] SET  READ_WRITE 
GO
