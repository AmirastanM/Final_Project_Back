USE [master]
GO
/****** Object:  Database [StoneSafetyDb]    Script Date: 9/23/2024 1:00:42 AM ******/
CREATE DATABASE [StoneSafetyDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoneSafetyDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StoneSafetyDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoneSafetyDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StoneSafetyDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StoneSafetyDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoneSafetyDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoneSafetyDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StoneSafetyDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoneSafetyDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoneSafetyDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StoneSafetyDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoneSafetyDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [StoneSafetyDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoneSafetyDb] SET  MULTI_USER 
GO
ALTER DATABASE [StoneSafetyDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoneSafetyDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoneSafetyDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoneSafetyDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoneSafetyDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoneSafetyDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StoneSafetyDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [StoneSafetyDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StoneSafetyDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/23/2024 1:00:43 AM ******/
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
/****** Object:  Table [dbo].[Abouts]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Abouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banners]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SurName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Subject] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
	[Phone] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsMain] [bit] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ImageData] [varbinary](max) NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[SubSubCategoryId] [int] NULL,
	[SubcategoryId] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
	[ProductCode] [nvarchar](max) NOT NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategories]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SubCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubSubCategories]    Script Date: 9/23/2024 1:00:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubSubCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[SoftDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SubSubCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240806162609_initial', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240808100657_addProductCodeToProductTable', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240810120347_addContactModelProperty', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240812182813_addPropAboutTable', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240814092446_addedPropToCategoryTable', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240815120617_addedRatingPropertyToProductTable', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240823054844_AddSoftDeleteToProductImages', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240825062314_addedBannerTable', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240825062616_addedBannerTables', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240825081426_updateBannerTable', N'6.0.32')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240826142453_AddImageDataToProductImage', N'6.0.32')
GO
SET IDENTITY_INSERT [dbo].[Abouts] ON 

INSERT [dbo].[Abouts] ([Id], [Title], [Description], [CreatedDate], [UpdatedDate], [SoftDeleted], [Image]) VALUES (1, N'Bizim şirkət müxtəlif iş geyimlərinin(uniformalarının) topdan satışı ilə məşğuldur:', N'Bizdə geniş çeşidli məhsullar vardır ki, istənilən tədbir, təşkilat və müəssəni funksianallaşdıra bilər.

Bizim müştərilərimiz arasında həm hüquqi həm də fiziki şəxslər mövcuddur. Hər bir müştəriyə onun tələb və istəklərinə uyğun olaraq endirimlər təklif etməyə hazırıq. Müsabiqəli, daimi alıcı və mövsum endirimləri mövcuddur.', CAST(N'2024-08-14T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-01T00:14:40.5760555' AS DateTime2), 0, N'a3e9c4d4-42bf-46c2-8716-32f79d75d1ba-2382b096-bb03-4c65-a693-abff0e527667-about_bg.jpg')
SET IDENTITY_INSERT [dbo].[Abouts] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a0514a00-52fa-472c-b751-48bb009469e7', N'Member', N'MEMBER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'af231f08-e250-41a9-ad09-fd5fca6afb47', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c0b83a1e-309e-409b-afa2-c9e6b33c5cd9', N'SuperAdmin', N'SUPERADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4153c2b0-0f57-4a02-b9fb-8b0226c63073', N'a0514a00-52fa-472c-b751-48bb009469e7')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'87ad3737-faf5-4762-bf5f-4c12bc60978f', N'a0514a00-52fa-472c-b751-48bb009469e7')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec8633cf-4549-452e-b3a0-156e94e7615c', N'a0514a00-52fa-472c-b751-48bb009469e7')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a9acccb5-655f-4e89-b611-2927dd12386c', N'af231f08-e250-41a9-ad09-fd5fca6afb47')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a9acccb5-655f-4e89-b611-2927dd12386c', N'c0b83a1e-309e-409b-afa2-c9e6b33c5cd9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4153c2b0-0f57-4a02-b9fb-8b0226c63073', N'Andrei Ivanenko', N'Ivanenko', N'IVANENKO', N'baydiyaste@gufum.com', N'BAYDIYASTE@GUFUM.COM', 0, N'AQAAAAEAACcQAAAAEFadhnluwwJX3VU2x6lGCPof3XUI5dkYkXEPI9psPGW+yYb3J76pZc1ILlIWYLDAzg==', N'3RCWP5HUAMA3FBEKPSYN5MERNESWVYX5', N'22be6e1f-df00-48ac-93d6-6ea913ce0277', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'87ad3737-faf5-4762-bf5f-4c12bc60978f', N'Mixail Andropov', N'Mixail', N'MIXAIL', N'andropovmixail@gmail.com', N'ANDROPOVMIXAIL@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJ7TfHmfh4fAqW6/p7tprLCOuh6O6fPy5QMjwHVH4HNk4zCSfsIA5k0wH6i9f94lKg==', N'NUQETVQ44V3G6HGX6ORPDVHGLG3PRKHE', N'0f76b063-4ed9-4f9f-818d-dfe8f351db76', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a9acccb5-655f-4e89-b611-2927dd12386c', N'Amirastan Mereyev', N'Test123', N'TEST123', N'amirastan.mereyev@gmail.com', N'AMIRASTAN.MEREYEV@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEo0bO1FvcyHq1fLhc0CdV41I+2jnZMYriuwR15/etchK9mcIQteea7U9KD2n7T0HQ==', N'ZQNGKAWGAPFTY53E72MK4TPPZXW4I66E', N'fad3c2bf-400e-46a8-9343-42adc841d7fe', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ec8633cf-4549-452e-b3a0-156e94e7615c', N'Mixail Andropov', N'Mixail777', N'MIXAIL777', N'murzohaspu@gufum.com', N'MURZOHASPU@GUFUM.COM', 1, N'AQAAAAEAACcQAAAAEJbGpl0t6fqTb3PvuhhVBaPq2sn6aOKoPiAlZ8Rv2jt0p53d5Yoe/LBskfadwAMfDA==', N'IZOHSCJMKQBTUPY5GQHZX5727QL55NNB', N'ead8a3ee-b002-4ae5-a24a-b2aa3ff76995', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Banners] ON 

INSERT [dbo].[Banners] ([Id], [Image], [CreatedDate], [UpdatedDate], [SoftDeleted], [Description], [Title]) VALUES (1, N'b318d232-ef34-42fd-9f6d-95ad3605f1a3-63_Human-Machine_Interface_Design._Two_people_on_a_project-min.jpeg', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), CAST(N'2024-09-01T00:14:21.6499046' AS DateTime2), 0, N'TƏHLÜKƏSİZLİK MALLARI & XÜSUSİ İŞ GEYİMLƏR', N'HƏR ŞEY DƏYİŞİR, DƏYİŞMƏYƏN TƏK DƏYƏR GÜVƏNDİR!')
SET IDENTITY_INSERT [dbo].[Banners] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [CreatedDate], [UpdatedDate], [SoftDeleted], [Image]) VALUES (1, N'TƏHLÜKƏSİZLİK AVADANLIQLARI', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), NULL, 0, N'5979c198-b5e7-4bbd-b942-b05e883bcc13-safety-harness.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [CreatedDate], [UpdatedDate], [SoftDeleted], [Image]) VALUES (2, N'Qoruyucu vasitələr', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), NULL, 0, N'c047c45b-87a1-4db1-82a9-cb7d01f6b4a6-bsqr.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [CreatedDate], [UpdatedDate], [SoftDeleted], [Image]) VALUES (3, N'İŞ GEYİMLƏRİ', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), NULL, 0, N'b216bac7-c02c-48da-b236-0c3342797754-istockphoto-1224034104-612x612.jpg')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Name], [SurName], [Email], [Subject], [Message], [CreatedDate], [UpdatedDate], [SoftDeleted], [Phone]) VALUES (1, N'amirastan', N'mereyev', N'amirastan.mereyev@gmail.com', N'test', N'test email', CAST(N'2024-08-29T10:06:01.0010577' AS DateTime2), NULL, 0, N'0513031171')
INSERT [dbo].[Contacts] ([Id], [Name], [SurName], [Email], [Subject], [Message], [CreatedDate], [UpdatedDate], [SoftDeleted], [Phone]) VALUES (2, N'asdasdsddsa', N'asdsadasd', N'andropovmixail@gmail.com', N'test', N'saddasdasd', CAST(N'2024-08-31T17:04:48.0185571' AS DateTime2), NULL, 0, N'0513031171')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (54, N'b5056d9e-3eb0-4623-a8a5-2dd76a839380-Screenshot 2023-08-15 110304.png', 1, 12, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (55, N'8a863cde-08c3-4c0c-8aea-eb79a559e506-Screenshot 2023-08-15 105117.png', 1, 13, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (56, N'6bc46aa2-ee42-457b-8883-f9653ad8a2b1-Screenshot 2023-08-15 104933.png', 1, 14, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (57, N'5d74a52f-1123-4ddc-8c9e-22d91ce699db-Screenshot 2023-10-23 204446.png', 1, 15, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (58, N'd4857f42-bfee-44da-8b49-8e676a2018b0-Screenshot 2023-10-23 204446.png', 1, 16, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (59, N'4fc56266-e8eb-4697-9966-785801e03ee1-Screenshot 2023-08-15 104517.png', 1, 17, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (60, N'2d98e6a1-891a-4f4b-92f9-1ec3bb8a8745-Screenshot 2023-11-06 143659.jpg', 1, 18, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (61, N'6639f056-95fd-4d47-a915-c95fb2c6aa69-Screenshot 2023-08-15 105851.png', 1, 19, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (62, N'bd7418ff-9b9d-47c6-ab9a-8b03829db050-Screenshot 2023-08-15 105718.png', 1, 20, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (63, N'9e9d8f49-62d1-42aa-b7a5-0da60ca68933-S918caf3d2dc8422aa7ce18d54b35d7aer.jpg_480x480.jpeg', 1, 21, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (64, N'b93bed31-112b-48b2-bfe0-cd124b4bf147-Screenshot 2023-10-02 104943.png', 1, 22, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (65, N'3c7dd9b1-52bb-48bd-88e8-697251c6cb0f-Screenshot 2023-08-18 131320.png', 1, 23, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (66, N'6a2f48ad-a77a-44ec-91bc-c30424b7c8ae-Screenshot 2023-08-18 131357.png', 1, 24, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (67, N'8f66cb13-ab33-483b-9a8f-bb3547a40b83-Screenshot 2023-08-18 131453.png', 1, 25, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (68, N'5c052a88-e98a-4b39-b38d-93cfbaa0af97-Screenshot 2023-08-18 131426.png', 1, 26, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (69, N'c2e85178-c0de-460d-a947-f81a142f293d-Screenshot 2023-09-26 123708.png', 1, 27, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (70, N'172a7340-0906-4628-bff2-05ae1b6b9f8f-Screenshot 2023-09-26 124135.png', 1, 28, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (71, N'7a7152e3-b95d-477d-b9fd-febd1ef43f39-Screenshot 2023-09-26 124057.png', 1, 29, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (72, N'eeb67845-2ae9-4dab-8f68-1d11a948feb2-Screenshot 2023-09-26 124526.png', 1, 30, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (73, N'42520786-42da-4018-8c20-431e88a2bd39-Screenshot 2023-09-26 105835.png', 1, 31, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (74, N'1a928234-ee78-408c-a9fb-f31b206609f8-Screenshot 2023-09-26 123431.png', 1, 32, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (75, N'de716179-2d52-4555-807c-61c025c2dfb5-Screenshot 2023-09-26 123507.png', 1, 33, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (76, N'25623742-158c-4557-982e-72287bfe48c7-Screenshot 2023-09-26 123557.png', 1, 34, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (77, N'a7616f1a-4f61-4073-92be-dfefb4f4ef3d-Screenshot 2023-09-26 123745.png', 1, 35, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (78, N'516333d6-69b7-419c-819b-747ce22c0e4c-Screenshot 2023-09-26 123828.png', 1, 36, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (79, N'29e7385a-242e-4756-975d-1fa2c838044c-Screenshot 2023-09-26 123857.png', 1, 37, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (80, N'3bc4f2a1-bb5a-42e8-abc3-ec2c7ffe2765-Screenshot 2023-09-26 123930.png', 1, 38, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (81, N'1e5dc90a-3257-43c3-a9d4-5f79e9fb8610-Screenshot 2023-09-26 124005.png', 1, 39, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (82, N'42d3abc9-118e-43e1-a0fe-489df71b2164-Screenshot 2023-09-26 124201.png', 1, 40, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (83, N'ff5a7ab9-d2d1-4b06-9ba4-01c32e431dee-Screenshot 2023-09-26 124259.png', 1, 41, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (84, N'0b379152-82f2-4d5a-bc7c-3923de6ef796-Screenshot 2023-09-26 124331.png', 1, 42, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (85, N'dcf67578-0e55-4d7f-a706-8de7384f147c-Screenshot 2023-09-26 124412.png', 1, 43, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (86, N'6d5ff4fd-bf5e-4f7d-aaac-451a024f6dfa-Screenshot 2023-09-26 124439.png', 1, 44, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (87, N'0d989495-4e91-4ea1-8afe-15d2b468f8e4-Screenshot 2023-09-26 124639.png', 1, 45, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (88, N'286593d7-97da-401c-ac56-8c95a1c42297-Screenshot 2023-09-26 124722.png', 1, 46, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (89, N'fbeefbdc-29ed-4d54-b48e-1101ca3087f8-Screenshot 2023-09-26 124919.png', 1, 47, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (90, N'1fa0fa4f-9951-4ca5-a95e-cbd81296f2f4-Screenshot 2023-09-26 124945.png', 1, 48, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (91, N'095d21f8-2d7e-4eac-b7fd-102e5e387542-Screenshot 2023-08-18 132146.png', 1, 49, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (92, N'b5117d1b-c0ad-41bc-a934-1731365c9520-Screenshot 2023-09-02 100827.png', 1, 50, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (93, N'06c65aea-a121-4034-b1a5-86596e35d4ef-Screenshot 2023-09-02 100827.png', 1, 51, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (94, N'218258cb-b554-4340-975b-b765b601811e-Screenshot 2023-08-18 132233.png', 1, 52, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (95, N'ddec53c5-32d1-49b4-a867-e2bfdffa10c3-Screenshot 2023-10-02 102913.png', 1, 53, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (96, N'c4169048-e761-44fe-b410-7e25db75c914-Screenshot 2023-10-02 103127.png', 1, 54, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (97, N'5f858c04-5e51-4158-8914-9f1879272f42-Screenshot 2023-10-02 171203.png', 1, 55, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (98, N'fba35426-eadb-42f2-96e6-57cb93c377ef-Screenshot 2023-09-02 102306.png', 1, 56, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (99, N'4c259839-83b7-4f7c-a468-c49463e51b58-Screenshot 2023-09-02 102559.png', 1, 57, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (100, N'fed2b102-7bb0-4ed5-be5a-067c5e7828e1-Screenshot 2023-09-02 102744.png', 1, 58, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (101, N'd3391423-a5f1-419b-82f2-a5c45f9ec90b-Screenshot 2023-10-02 172748.png', 1, 59, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (102, N'ba132c6a-b5a6-4b7e-92a4-44437e12faa5-Screenshot 2023-08-15 112807.png', 1, 60, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (103, N'006fdcee-078d-434e-870f-43b1bb941c2f-Screenshot 2023-08-15 113104.png', 1, 61, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (104, N'84dd46c4-1377-4146-b56d-71fe9dbac970-Screenshot 2023-08-15 113434.png', 1, 62, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (105, N'0da7a05d-5df2-430d-a92b-fa33500af1bc-Screenshot 2023-08-15 113543.png', 1, 63, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (106, N'c745d550-c45e-4ec8-bd26-54b5add3cf2c-Screenshot 2023-08-15 114726.png', 1, 64, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (107, N'55ba9929-090b-4f4a-a157-cf60afa2b7b4-Screenshot 2023-08-15 115347.png', 1, 65, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (108, N'2dac4742-2620-4acc-914b-950be563cf80-Screenshot 2023-08-15 114129.png', 1, 66, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (109, N'781cac4c-9d6b-4ad9-8e76-c3578db8ac26-Screenshot 2023-08-15 114232.png', 1, 67, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (110, N'1b4c8fcf-0625-44f5-ad2f-e062be3a9da0-Screenshot 2023-08-15 114316.png', 1, 68, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (111, N'b0fb5e21-dfef-45b3-a818-854495b276ab-Screenshot 2023-08-15 114454.png', 1, 69, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (112, N'6443b0f3-3699-4ed9-8cdd-19f6329e541b-Screenshot 2023-08-15 114550.png', 1, 70, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (113, N'28fcd178-aa72-4409-a2cf-50bb505a9be8-Screenshot 2023-08-15 114647.png', 1, 71, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (114, N'6613cd29-7bd1-4c45-adf1-af0d097175db-Screenshot 2023-08-15 115155.png', 1, 72, NULL)
INSERT [dbo].[ProductImages] ([Id], [Name], [IsMain], [ProductId], [ImageData]) VALUES (115, N'4e01a8e6-b633-4768-966d-9ddf600c44c8-Screenshot 2023-08-15 115310.png', 1, 73, NULL)
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (12, N'YDS ', N'- İkili altlıq PU/TPU
- Qorunma səviyyəsi S3
- Burnu dəmirli
- Altı deşilməz
- Antistatik
- Yağa(sürüşməyə) davamlı', CAST(35.00 AS Decimal(18, 2)), 9, 17, CAST(N'2024-09-01T01:31:46.6417694' AS DateTime2), NULL, 0, N'SSA0004', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (13, N'ZapadBaltObuv Sandal', N'- İkili altlıq PU/PU
- Qorunma səviyyəsi S2
- Burnu dəmirli
- Altı deşilməz
- Antistatik
- Yağa(sürüşməyə) davamlı
 ', CAST(33.00 AS Decimal(18, 2)), 9, 17, CAST(N'2024-09-01T01:36:47.2973511' AS DateTime2), NULL, 0, N'SSA001', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (14, N'ZapadBaltObuv Bot', N'- İkili altlıq PU/TPU 
- Qorunma səviyyəsi S3 
- Burnu dəmirli 
- Altı deşilməz 
- Antistatik 
- Yağa(sürüşməyə) davamlı', CAST(33.00 AS Decimal(18, 2)), 9, 17, CAST(N'2024-09-01T01:39:12.7076799' AS DateTime2), NULL, 0, N'SSA002', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (15, N'BMES Bot S3', N'- İkili altlıq PU/TPU
- Qorunma səviyyəsi S3
- Burnu dəmirli
- Altı deşilməz
- Antistatik
- Yağa(sürüşməyə) davamlı', CAST(35.00 AS Decimal(18, 2)), 10, 17, CAST(N'2024-09-01T01:50:17.8094013' AS DateTime2), NULL, 0, N'SSA003', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (16, N'BMES Bot S2', N'- Tək altlıq PU
- Qorunma səviyyəsi S2
- Burnu dəmirli
- Antistatik
- Yağa(sürüşməyə) davamlı', CAST(28.00 AS Decimal(18, 2)), 10, 17, CAST(N'2024-09-01T01:53:08.7799901' AS DateTime2), NULL, 0, N'SSA005', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (17, N'BMES Qaynaqçı Bot S3', N'- İkili altlıq PU/TPU
- Qorunma səviyyəsi S3
- Burnu dəmirli
- Altı deşilməz
- Antistatik
- Yağa(sürüşməyə) davamlı', CAST(38.00 AS Decimal(18, 2)), 10, 17, CAST(N'2024-09-01T01:55:47.9131814' AS DateTime2), NULL, 0, N'SSA006', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (18, N'Dəri Bot Uzunbogaz S3', N'- İkili altlıq PU/TPU
- Qorunma səviyyəsi S3
- Burnu dəmirli
- Altı deşilməz
- Antistatik
- Yağa(sürüşməyə) davamlı', CAST(45.00 AS Decimal(18, 2)), 10, 17, CAST(N'2024-09-01T01:57:58.2195902' AS DateTime2), NULL, 0, N'SSA007', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (19, N'Rezin Çəkmə', N'- İkili altlıq PVC
- Qorunma səviyyəsi S2
- Antistatik
- Yağa(sürüşməyə) davamlı', CAST(10.00 AS Decimal(18, 2)), 11, 17, CAST(N'2024-09-01T02:01:09.6014482' AS DateTime2), NULL, 0, N'SSA008', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (20, N'PVC Çəkmə', N'- İkili altlıq PVC 
- Qorunma səviyyəsi S2 
- Antistatik 
- Yağa(sürüşməyə) davamlı', CAST(16.00 AS Decimal(18, 2)), 11, 17, CAST(N'2024-09-01T02:02:28.7597345' AS DateTime2), NULL, 0, N'SSA009', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (21, N'Aşpaz', N'- Ön hissəsi düyməli
- 95% pambıq 5% likra
- Xüsusi modeller işlənilməsi imkanı
- Şalvarda ölçü tənzimləyən bel rezini, iki yan ciblər', CAST(40.00 AS Decimal(18, 2)), 12, 18, CAST(N'2024-09-01T02:09:29.4074680' AS DateTime2), NULL, 0, N'SSU001', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (22, N'Önlük', N'- 65% pambıq 35% poliester 
- Alpaka 
- Dəriəvəzedici 
- Brezent', CAST(12.00 AS Decimal(18, 2)), 13, 18, CAST(N'2024-09-01T02:11:25.1211790' AS DateTime2), NULL, 0, N'SSU002', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (23, N'Gödəkçə Muhəndis', N'Astar: 200 qkm poliester astara sırınmış isidici təbəqə

Rənglər: Limon (açıq yaşıl), tünd göy, qırmızı, açıq mavi (elektro), yaşıl, qara, boz

Ölçü: 46 - 60', CAST(35.00 AS Decimal(18, 2)), 14, 18, CAST(N'2024-09-01T16:29:48.9707070' AS DateTime2), NULL, 0, N'SSU003 ', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (24, N'İşçi gödəkçəsi Reflektorlu', N'Material: Sukeçirməz poliester

Astar: 200 qkm poliester astara sırınmış isidici təbəqə

Rənglər: Limon (açıq yaşıl), tünd göy, qırmızı, açıq mavi (elektro), yaşıl, qara

Ölçü: 46 - 60 ', CAST(40.00 AS Decimal(18, 2)), 14, 18, CAST(N'2024-09-01T16:31:31.2469379' AS DateTime2), NULL, 0, N'SSU004', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (25, N'Gödəkçə Mörtel', N'Astar: 200 qkm poliester astara sırınmış isidici təbəqə

Rənglər: Limon (açıq yaşıl), tünd göy, qırmızı, açıq mavi (elektro), yaşıl, qara, boz

Ölçü: 46 - 60 ', CAST(33.00 AS Decimal(18, 2)), 14, 18, CAST(N'2024-09-01T16:32:54.8871209' AS DateTime2), NULL, 0, N'SSU005', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (26, N'Gödəkçəsi Sadə', N'Astar: 200 qkm poliester astara sırınmış isidici təbəqə

Rənglər: Tünd göy, qırmızı, açıq mavi (elektro), yaşıl, qara

Ölçü: 46 - 60 ', CAST(28.00 AS Decimal(18, 2)), 14, 18, CAST(N'2024-09-01T16:33:55.3142547' AS DateTime2), NULL, 0, N'SSU006', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (27, N'İşçi Dəsti Boz ', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(30.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T16:41:53.5724752' AS DateTime2), NULL, 0, N'SSU007', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (28, N'İşçi Dəsti tünd göy ', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(30.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T16:43:00.2924127' AS DateTime2), NULL, 0, N'SSU008', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (29, N'İşçi Dəsti elektro', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(30.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:16:26.7351153' AS DateTime2), NULL, 0, N'SSU009', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (30, N'İşçi Dəsti qırmızı', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(30.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:17:27.7437869' AS DateTime2), NULL, 0, N'SSU010', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (31, N'İşçi Dəsti boz-qırmızı', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:19:46.0443952' AS DateTime2), NULL, 0, N'SSU011', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (32, N'İşçi Dəsti boz-göy (voltaj)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:20:48.6484053' AS DateTime2), NULL, 0, N'SSU012', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (33, N'İşçi Dəsti boz-narıncı (master)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(45.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:21:55.2496853' AS DateTime2), NULL, 0, N'SSU013', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (34, N'İşçi Dəsti boz-yaşıl', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:23:14.1505776' AS DateTime2), NULL, 0, N'SSU014', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (35, N'İşçi Dəsti boz-narıncı (expert)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(38.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:24:57.2266641' AS DateTime2), NULL, 0, N'SSU015', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (36, N'İşçi Dəsti boz-narıncı ', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:25:43.6954594' AS DateTime2), NULL, 0, N'SSU016', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (37, N'İşçi Dəsti boz-yaşıl (expert)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(38.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:27:50.4274730' AS DateTime2), NULL, 0, N'SSU017', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (38, N'İşçi Dəsti boz-qara (expert)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(38.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:28:27.0752539' AS DateTime2), NULL, 0, N'SSU018', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (39, N'İşçi Dəsti elektro-boz', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:29:35.4812966' AS DateTime2), NULL, 0, N'SSU019', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (40, N'İşçi Dəsti elektro-qırmızı', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:30:02.7520812' AS DateTime2), NULL, 0, N'SSU020', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (41, N'İşçi Dəsti boz (mühəndis)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(45.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:30:56.8751591' AS DateTime2), NULL, 0, N'SSU021', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (42, N'İşçi Dəsti göy-qırmızı', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(35.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:31:34.7070403' AS DateTime2), NULL, 0, N'SSU022', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (43, N'İşçi Dəsti bej (exclusive)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(60.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:32:36.3668078' AS DateTime2), NULL, 0, N'SSU023', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (44, N'İşçi Dəsti qara-qırmızı (expert)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(38.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:33:50.4323336' AS DateTime2), NULL, 0, N'SSU024', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (45, N'İşçi Dəsti qara-yaşıl (expert)', N'Material: 65/35 poliester pambıq 195 qkm

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(38.00 AS Decimal(18, 2)), 15, 18, CAST(N'2024-09-01T21:34:32.8805021' AS DateTime2), NULL, 0, N'SSU025', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (46, N'Xadimə dəsti (bardo)', N'Material: Alpaka – Polyester 65 % Viskos 35 % 

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz

Ölçü: 46 - 60 ', CAST(30.00 AS Decimal(18, 2)), 19, 18, CAST(N'2024-09-01T21:39:29.1045862' AS DateTime2), NULL, 0, N'SSU026', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (47, N'Xadimə dəsti (göy)', N'Alpaka – Polyester 65 % Viskos 35 % 

Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz 

Ölçü: 46 - 60', CAST(30.00 AS Decimal(18, 2)), 19, 18, CAST(N'2024-09-01T21:42:45.3656114' AS DateTime2), NULL, 0, N'SSU027', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (48, N'Xadimə dəsti (yaşıl)', N'Material: Alpaka – Polyester 65 % Viskos 35 % 
Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz 
Ölçü: 46 - 60', CAST(30.00 AS Decimal(18, 2)), 19, 18, CAST(N'2024-09-01T21:43:45.6767833' AS DateTime2), NULL, 0, N'SSU028', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (49, N'Astarlı jilet (su keçirməz)', N'Material: Sukeçirməz poliester

Astar: 160 qkm poliester astara sırınmış isidici təbəqə

Rənglər: Tünd göy, qırmızı, açıq mavi (elektro), yaşıl, qara

Ölçü: 46 - 60 ', CAST(22.00 AS Decimal(18, 2)), 16, 18, CAST(N'2024-09-01T21:47:30.8537674' AS DateTime2), NULL, 0, N'SSU029', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (50, N'İşçi Jilet 60 gr', N'Material: 100% toxunma poliester 60 gr,

Sadə, 

Rənglər: Yaşıl, Narıncı', CAST(3.00 AS Decimal(18, 2)), 16, 18, CAST(N'2024-09-01T21:51:44.4333019' AS DateTime2), NULL, 0, N'SSU030', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (51, N'İşçi Jilet 120 gr', N'Material: 100% toxunma poliester 120 gr, 
Cibli,
Rənglər: Yaşıl, Narıncı, Mavi, Qırmızı', CAST(8.00 AS Decimal(18, 2)), 16, 18, CAST(N'2024-09-01T21:53:04.3976112' AS DateTime2), NULL, 0, N'SSU031', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (52, N'Xilasedici Jilet ', N'Üzgüçülər və üzə bilməyənlər üçün qorunma məqsədi üçün nəzərdə tutulub', CAST(45.00 AS Decimal(18, 2)), 16, 18, CAST(N'2024-09-01T21:56:33.8445815' AS DateTime2), NULL, 0, N'SSU032', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (53, N'İşçi köynəyi Polo Yaka', N'Xüsusiyyətləri: rahat, dəbli və praktik polo köynəyi; daxilində trikotaj yaxa, manjetlər və sinə hissəsində üç düymə', CAST(14.00 AS Decimal(18, 2)), 17, 18, CAST(N'2024-09-01T21:59:55.8410002' AS DateTime2), NULL, 0, N'SSU033', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (54, N'İşçi köynəyi Yumuru boğaz', N'Material: 100% pambıq, bir qatlı trikotaj, sıxlıq 155 q/m2', CAST(10.00 AS Decimal(18, 2)), 17, 18, CAST(N'2024-09-01T22:01:20.7305692' AS DateTime2), NULL, 0, N'SSU034', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (55, N'İşçi Şalvar', N'Material : 65 % pambıq 35 % polyester
', CAST(18.00 AS Decimal(18, 2)), 18, 18, CAST(N'2024-09-01T22:04:15.0733759' AS DateTime2), NULL, 0, N'SSU035', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (56, N'İşçi Komninezonu ', N'Material: 65/35 poliester pambıq 195 qkm 
Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz 
Ölçü: 46 - 60', CAST(33.00 AS Decimal(18, 2)), 20, 18, CAST(N'2024-09-01T22:15:25.3746330' AS DateTime2), NULL, 0, N'SSU036', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (57, N'İşçi Yarım Komninezonu ', N'Material: 65/35 poliester pambıq 195 qkm 
Rənglər: tünd göy, qırmızı, açıq mavi (elektro), yaşıl, boz 
Ölçü: 46 - 60', CAST(20.00 AS Decimal(18, 2)), 20, 18, CAST(N'2024-09-01T22:16:05.3908153' AS DateTime2), NULL, 0, N'SSU037', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (58, N'Birdəfəlik kombinezon ', N'Antistatik, toza davamlı, silikonsuz, qorunmaq və uyğunlaşmaq üçün yapışqanlı (tikişsiz) elastik kəmər, havada olan kimyəvi maddələrə davamlı, kimyəvi sıçrayışlara davamlı, 3 hissəli başlıq', CAST(7.00 AS Decimal(18, 2)), 20, 18, CAST(N'2024-09-01T22:22:59.5065326' AS DateTime2), NULL, 0, N'SSU038', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (59, N'Yağmurluq', N'PVC materialdan, su keçirməyin ', CAST(14.00 AS Decimal(18, 2)), 21, 18, CAST(N'2024-09-01T22:25:07.6932668' AS DateTime2), NULL, 0, N'SSU039', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (60, N'Dəbilqə', N'Dəbilqəyə bərkidilmiş qoruyucu üz sipərləri və dəbilqəyə bərkidilmiş səs-küy əleyhinə qulaq tıxacları ilə birgə taxmaq üçün dəbilqə korpusunda yuvalar.
Çənə kəməri və möhürlərlə tamamlayın.
Temperatur diapazonu: -30 ° C + 50 ° C.
Baş bandı əlavəsi: 6 nöqtəli.
Korpus materialı: polipropilen.', CAST(6.00 AS Decimal(18, 2)), 22, 19, CAST(N'2024-09-01T22:35:42.5640222' AS DateTime2), NULL, 0, N'SSB001', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (61, N'Dəbilqə (kasketka)', N'Dəbilqəyə bərkidilmiş qoruyucu üz sipərləri və dəbilqəyə bərkidilmiş səs-küy əleyhinə qulaq tıxacları ilə birgə taxmaq üçün dəbilqə korpusunda yuvalar.
Çənə kəməri və möhürlərlə tamamlayın.
Temperatur diapazonu: -30 ° C + 50 ° C.
Baş bandı əlavəsi: 6 nöqtəli.
Korpus materialı: polipropilen.', CAST(12.00 AS Decimal(18, 2)), 22, 19, CAST(N'2024-09-01T22:36:19.4048315' AS DateTime2), NULL, 0, N'SSB002', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (62, N'Səs gücləndirici', N'Yaddaş panel,
Enerji daşları ilə işləyir', CAST(150.00 AS Decimal(18, 2)), NULL, 28, CAST(N'2024-09-01T22:43:05.0026482' AS DateTime2), NULL, 0, N'SS+001', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (63, N'Yük sıxan kəmər', N'Tonajina görə xüsusiyyətləri dəyişir', CAST(35.00 AS Decimal(18, 2)), NULL, 28, CAST(N'2024-09-01T22:44:17.2639723' AS DateTime2), NULL, 0, N'SS+002', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (64, N'İşçi əlcəyi sadə', N'mapterial: 4 ipli polyester
krasak: bir qat', CAST(0.35 AS Decimal(18, 2)), 24, 20, CAST(N'2024-09-01T22:46:26.6755814' AS DateTime2), NULL, 0, N'SSE001', 3)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (65, N'İşçi əlcəyi zebra', N'mapterial: 5 ipli polyester 
iç boyalanma: bir yarım qat ', CAST(0.50 AS Decimal(18, 2)), 24, 20, CAST(N'2024-09-01T22:48:15.0416513' AS DateTime2), NULL, 0, N'SSE002', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (66, N'İşçi əlcəyi №300', N'mapterial: 6 ipli polyester 
iç boyalanma: bir yarım qat
barmaq hissesi güclendirilib', CAST(0.70 AS Decimal(18, 2)), 24, 20, CAST(N'2024-09-01T22:49:32.5924007' AS DateTime2), NULL, 0, N'SSE003', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (67, N'Beybi KN65', N'Neft əlcəyi', CAST(3.00 AS Decimal(18, 2)), 27, 20, CAST(N'2024-09-01T22:50:52.9506082' AS DateTime2), NULL, 0, N'SSE004', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (68, N'Beybi KN350', N'mapterial: 100% pambıq
 krasak: bir qat', CAST(1.80 AS Decimal(18, 2)), 24, 20, CAST(N'2024-09-01T22:52:59.8343087' AS DateTime2), NULL, 0, N'SSE005', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (69, N'Beybi NTL-33', N'Turşuya davamli', CAST(3.00 AS Decimal(18, 2)), 27, 20, CAST(N'2024-09-01T22:54:49.0426469' AS DateTime2), NULL, 0, N'SSE006', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (70, N'Beybi PL9', N'Material: 6 ipli polyester,
İç boyalanma 2 qat', CAST(2.00 AS Decimal(18, 2)), 24, 20, CAST(N'2024-09-01T22:56:21.6566729' AS DateTime2), NULL, 0, N'SSE007', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (71, N'Beybi PN5', N'Mapterial: 5 ipli polyester 
İç boyalanma: bir yarım qat', CAST(1.00 AS Decimal(18, 2)), 24, 20, CAST(N'2024-09-01T22:57:13.6480420' AS DateTime2), NULL, 0, N'SSE008', 4)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (72, N'Qaynaqçı əlcəyi', N'Təmiz dəri, tikiş yeri dəri ilə gücləndirilib', CAST(8.00 AS Decimal(18, 2)), 25, 20, CAST(N'2024-09-01T22:58:23.3806740' AS DateTime2), NULL, 0, N'SSE009', 5)
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price], [SubSubCategoryId], [SubcategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted], [ProductCode], [Rating]) VALUES (73, N'Montajçı əlcəyi', N'İç hissə dəri, üst hissə parça', CAST(4.00 AS Decimal(18, 2)), 26, 20, CAST(N'2024-09-01T22:59:09.6963650' AS DateTime2), NULL, 0, N'SSE010', 5)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (1, N'Location', N'EUROHOME T.M, birinci sıra (dəmir yolu sırası), Mağaza 13-3', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (2, N'Phone', N'+994 51 303 11 71', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (4, N'Phone1', N'+994 77 573 12 76', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (5, N'Email', N'stonesafetysupply@gmail.com', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (7, N'IG1', N'Siqnal (Jilet və s.)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (8, N'IG2', N'Kostyum (Şalvar/Pencək)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (9, N'IG3', N'Kombinizon', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (10, N'IG4', N'Yarım Kombinizon', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (11, N'IG5', N'Gödəkçə', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (12, N'IG6', N'Su Keçirməyən (Plaş, Gödəkçə)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (13, N'IG7', N'Yanmayan (Kombinizonlar və s.)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (14, N'IG8', N'Personal (Aşbaz, Xadiməçi, Xalat və s.)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (15, N'IG9', N'Ayaqqabı', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (16, N'FQV1', N'Əl qoruyucu vasitələri (iş əlcəkləri)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (19, N'FQV2', N'Göz qoruyucu vasitələri (qoruyucu eynəklər)', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (20, N'FQV3', N'Nəfəs qoruyucu vasitələri', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (21, N'FQV4', N'Eşitmə qoruyucu vasitələri', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (22, N'FQV5', N'Yüksəklikdən düşmə qoruyucu vasitələri', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (24, N'XİA1', N'Yay iş ayaqqabısı', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (25, N'XİA2', N'Qış iş ayaqqabısı', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (26, N'XİA3', N'PVC iş ayaqqabısı', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (27, N'CompanyName', N'Stone Safety', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (28, N'OurService1', N'korporativ geyimlər', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (29, N'OurService2', N'iş geyimləri', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (30, N'OurService3', N'iş ayaqqabıları', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (31, N'OurService4', N'iş ayaqqabıları', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (32, N'OurService5', N'fərdi qoruyucu vasitələr', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (33, N'OurService6', N'təhlükəsizlik avadanlıqları', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (34, N'IGTitel', N'İş Geyimləri', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (35, N'IGDesc', N'İş Geyimləri, işçilərin geyim vasitəsi ilə təhlükəsizliyini təmin etmək üçündür. İG –nin əsas növləri bunlardır:', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (36, N'FQVTitel', N'Fərdi Qoruyucu Vasitələr', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (37, N'FQVDesc', N'Fərdi qoruyucu vasitələr işçilərin təhlükəsizliyini təmin etmək üçündür. FQV –nin əsas növləri bunlardır:', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (38, N'XİATitel', N'İş Ayaqqablıları', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (40, N'XİADesc', N'Xüsusi iş ayaqqabılarının alt və ya uc hissələrində qoruyucu "dəmir" olur. XİA -nın əsas növləri bunlardır:', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (44, N'LOGO', N'SS_Logo_CROP.png', CAST(N'2024-12-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (45, N'InstagramLink', N'https://www.instagram.com/stone_safety/', CAST(N'2024-01-08T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (46, N'clothesssew', N'clothesssew.svg', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (47, N'flex', N'flex.svg', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[Settings] ([Id], [Key], [Value], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (48, N'logosew', N'logosew.svg', CAST(N'2024-08-25T00:00:00.0000000' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 

INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (17, N'Ayaqqabılar', 3, CAST(N'2024-09-01T00:24:40.4983983' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (18, N'Uniforma', 3, CAST(N'2024-09-01T00:24:53.2360541' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (19, N'Qoruyucu Baş Geyimləri', 2, CAST(N'2024-09-01T00:25:16.1340265' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (20, N'Əlcəklər', 2, CAST(N'2024-09-01T00:26:00.6735415' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (21, N'Gözlərin və Üzün Mühafizəsi', 2, CAST(N'2024-09-01T00:26:14.8721790' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (22, N'Qaynaqçı üçün Qoruyucu Vasitələr', 2, CAST(N'2024-09-01T00:26:32.5726928' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (23, N'Səsdən Qoruyucu Vasitələr', 2, CAST(N'2024-09-01T00:27:02.4569734' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (24, N'İlk Yardım və Dərinin Mühafizəsi', 1, CAST(N'2024-09-01T00:27:22.5004134' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (25, N'Hündürlükdən Yıxılmağa Qarşı Qoruyucu Vasitələr', 1, CAST(N'2024-09-01T00:27:41.8251437' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (26, N'Təhlükəsizlik Nişanları', 1, CAST(N'2024-09-01T00:28:18.0921352' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (27, N'Yol Təhlükəsizliyinin Təminatı', 1, CAST(N'2024-09-01T00:28:36.5619237' AS DateTime2), NULL, 0)
INSERT [dbo].[SubCategories] ([Id], [Name], [CategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (28, N'Digər Təhlükəsizlik Malları', 1, CAST(N'2024-09-01T00:28:46.9378973' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[SubSubCategories] ON 

INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (9, N'Yay Ayaqqabıları', 17, CAST(N'2024-09-01T00:29:40.1118936' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (10, N'Qış Ayaqqabıları', 17, CAST(N'2024-09-01T00:29:56.9171877' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (11, N'PVC Ayaqqabıları', 17, CAST(N'2024-09-01T00:30:10.1862855' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (12, N'Aşbaz', 18, CAST(N'2024-09-01T01:10:06.8099600' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (13, N'Döşlüklər', 18, CAST(N'2024-09-01T01:10:19.7772112' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (14, N'Gödəkçələr', 18, CAST(N'2024-09-01T01:10:30.7597496' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (15, N'Geyim Dəst', 18, CAST(N'2024-09-01T01:10:51.7575395' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (16, N'Jiletlər', 18, CAST(N'2024-09-01T01:11:01.8202546' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (17, N'Köynəklər', 18, CAST(N'2024-09-01T01:11:10.1671950' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (18, N'İşçi Şalvarları', 18, CAST(N'2024-09-01T01:11:20.7713260' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (19, N'Xalatlar', 18, CAST(N'2024-09-01T01:11:29.2441727' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (20, N'Kombinezonlar', 18, CAST(N'2024-09-01T01:11:40.9880677' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (21, N'Yağmurluqlar', 18, CAST(N'2024-09-01T01:11:49.9092873' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (22, N'Dəbilqələr', 19, CAST(N'2024-09-01T01:12:11.3772696' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (23, N'Digər', 19, CAST(N'2024-09-01T01:12:28.2512556' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (24, N'Işçi əlcəkləri', 20, CAST(N'2024-09-01T01:13:09.7667846' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (25, N'Qaynaqçı ələcəkləri', 20, CAST(N'2024-09-01T01:14:52.6937486' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (26, N'Montajçı əlcəkləri', 20, CAST(N'2024-09-01T01:15:03.9005166' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (27, N'Digər əlcəklər', 20, CAST(N'2024-09-01T01:15:15.5291864' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (28, N'Eynəklər', 21, CAST(N'2024-09-01T01:15:42.6355882' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (29, N'Sipərliklər', 21, CAST(N'2024-09-01T01:15:51.1252946' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (30, N'Digər', 21, CAST(N'2024-09-01T01:16:05.6729711' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (31, N'Tibbi Yardım Çantaları', 24, CAST(N'2024-09-01T01:16:33.3147089' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (32, N'Kəmərlər', 25, CAST(N'2024-09-01T01:17:09.9371159' AS DateTime2), NULL, 0)
INSERT [dbo].[SubSubCategories] ([Id], [Name], [SubCategoryId], [CreatedDate], [UpdatedDate], [SoftDeleted]) VALUES (33, N'Qarmaqlar', 25, CAST(N'2024-09-01T01:17:19.3369793' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[SubSubCategories] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductId] ON [dbo].[ProductImages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SubcategoryId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SubcategoryId] ON [dbo].[Products]
(
	[SubcategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SubSubCategoryId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SubSubCategoryId] ON [dbo].[Products]
(
	[SubSubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubCategories_CategoryId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_SubCategories_CategoryId] ON [dbo].[SubCategories]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubSubCategories_SubCategoryId]    Script Date: 9/23/2024 1:00:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_SubSubCategories_SubCategoryId] ON [dbo].[SubSubCategories]
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Banners] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Banners] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [ProductCode]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Rating]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SubCategories_SubcategoryId] FOREIGN KEY([SubcategoryId])
REFERENCES [dbo].[SubCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_SubCategories_SubcategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SubSubCategories_SubSubCategoryId] FOREIGN KEY([SubSubCategoryId])
REFERENCES [dbo].[SubSubCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_SubSubCategories_SubSubCategoryId]
GO
ALTER TABLE [dbo].[SubCategories]  WITH CHECK ADD  CONSTRAINT [FK_SubCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubCategories] CHECK CONSTRAINT [FK_SubCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[SubSubCategories]  WITH CHECK ADD  CONSTRAINT [FK_SubSubCategories_SubCategories_SubCategoryId] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategories] ([Id])
GO
ALTER TABLE [dbo].[SubSubCategories] CHECK CONSTRAINT [FK_SubSubCategories_SubCategories_SubCategoryId]
GO
USE [master]
GO
ALTER DATABASE [StoneSafetyDb] SET  READ_WRITE 
GO
