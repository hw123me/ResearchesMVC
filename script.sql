USE [master]
GO
/****** Object:  Database [ResearchesMVC]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE DATABASE [ResearchesMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ResearchesMVC', FILENAME = N'D:\Asp.Net Core\ResearchesMVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ResearchesMVC_log', FILENAME = N'D:\Asp.Net Core\ResearchesMVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ResearchesMVC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResearchesMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResearchesMVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ResearchesMVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ResearchesMVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ResearchesMVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ResearchesMVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [ResearchesMVC] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ResearchesMVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ResearchesMVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ResearchesMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ResearchesMVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ResearchesMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ResearchesMVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ResearchesMVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ResearchesMVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ResearchesMVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ResearchesMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ResearchesMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ResearchesMVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ResearchesMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ResearchesMVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ResearchesMVC] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ResearchesMVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ResearchesMVC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ResearchesMVC] SET  MULTI_USER 
GO
ALTER DATABASE [ResearchesMVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ResearchesMVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ResearchesMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ResearchesMVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ResearchesMVC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ResearchesMVC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ResearchesMVC] SET QUERY_STORE = OFF
GO
USE [ResearchesMVC]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/4/2022 11:20:39 م ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/4/2022 11:20:39 م ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/4/2022 11:20:39 م ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/4/2022 11:20:39 م ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/4/2022 11:20:39 م ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
	[Address] [nvarchar](max) NULL,
	[CardId] [int] NULL,
	[CityId] [int] NULL,
	[FullName] [nvarchar](500) NULL,
	[Gender] [int] NULL,
	[Jop] [nvarchar](max) NULL,
	[JopTitle] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[StateId] [int] NULL,
	[UserType] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nvarchar](max) NULL,
	[SignImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Uneviersity] [nvarchar](max) NOT NULL,
	[City_Univ] [nvarchar](max) NOT NULL,
	[College] [nvarchar](max) NOT NULL,
	[Section] [nvarchar](max) NOT NULL,
	[Specialize] [nvarchar](max) NOT NULL,
	[StudyTitle] [nvarchar](max) NOT NULL,
	[Goal] [int] NOT NULL,
	[ToolsPdfUrl] [nvarchar](max) NULL,
	[School_Type] [int] NOT NULL,
	[Term_Year] [nvarchar](max) NOT NULL,
	[Term] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Active] [bit] NULL,
	[Notes] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 5/4/2022 11:20:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220419205022_initialdatabase', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220419205610_addStateAndCity', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220419211002_AddApplicationUser', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220419221831_updatestate', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220420200818_addorder', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220420224120_addorder2', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220421050733_test', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422185857_addstatus', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422190327_addstatus2', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422191121_addstatus3', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422193412_UpdateOrders', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422194041_UpdateOrders2', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422204120_Addorder', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422204620_Addorder', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422205349_Addorder2', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220422210706_Addorder3', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220423192212_updateApplictionUser', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220426083506_abc', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504080656_addImage', N'6.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504172811_EditImage', N'6.0.4')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'149d0bea-a3ac-45e9-a277-28fb66b2d0ff', N'Admin', N'ADMIN', N'43cc2815-c04f-4804-9cd9-47f6b2120afa')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'88acc51c-9449-4abd-9939-02b4c2eb4c5e', N'User', N'USER', N'8523fcf8-c083-4205-b6fc-669090cfb14c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02cfe5bf-1bbc-493f-a1ec-865c3c2bf5e3', N'149d0bea-a3ac-45e9-a277-28fb66b2d0ff')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0e7e484b-b560-4353-b491-0f95571be8a3', N'88acc51c-9449-4abd-9939-02b4c2eb4c5e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'80034ba5-b14d-4097-b30f-1d05ae01bf1f', N'88acc51c-9449-4abd-9939-02b4c2eb4c5e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b188f100-af80-4b59-9d84-0c5d1bcc873a', N'88acc51c-9449-4abd-9939-02b4c2eb4c5e')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [CardId], [CityId], [FullName], [Gender], [Jop], [JopTitle], [Mobile], [StateId], [UserType]) VALUES (N'02cfe5bf-1bbc-493f-a1ec-865c3c2bf5e3', N'w.a.a2012@gmail.com', N'W.A.A2012@GMAIL.COM', N'w.a.a2012@gmail.com', N'W.A.A2012@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEF/sCDuqrgRlLdvfKIye2Tf1AidQjLmGos3oUrvADk0TJ9aTF/itn9yHHg1HYK75dw==', N'DRHAC6UQO72JXMND2LRT5WEX4MH4R2SM', N'5db8b4e8-9b86-4415-91bd-d0b5c537e6ec', NULL, 0, 0, NULL, 1, 0, N'الطائف', 1017757145, 1, N'علي محمد خالد', 0, N'وزارة التعليم', N'الحوية', N'0542158808', 1, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [CardId], [CityId], [FullName], [Gender], [Jop], [JopTitle], [Mobile], [StateId], [UserType]) VALUES (N'0e7e484b-b560-4353-b491-0f95571be8a3', N'blog@blog.com', N'BLOG@BLOG.COM', N'blog@blog.com', N'BLOG@BLOG.COM', 0, N'AQAAAAEAACcQAAAAEC32dOjh6dS/PfjpN9HY2TgP7WTAz56+rrT5se0P0azRORCkXhJD5hUI2jYxRhSI8w==', N'HKGATZUTFZKT2WQXBFW7UPMX3MV6JABL', N'095d4d69-c5b8-4ffc-94c6-972691430fc2', NULL, 0, 0, NULL, 1, 0, N'ثضصثض', 10166526, 4, N'هدى', 1, N'ضصثض', N'ضصث', N'0546363111', 2, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [CardId], [CityId], [FullName], [Gender], [Jop], [JopTitle], [Mobile], [StateId], [UserType]) VALUES (N'80034ba5-b14d-4097-b30f-1d05ae01bf1f', N'zzz@zz.com', N'ZZZ@ZZ.COM', N'zzz@zz.com', N'ZZZ@ZZ.COM', 0, N'AQAAAAEAACcQAAAAEH5jXUivsGrrEXqoBNWcLh/okWIDJFd5sQzV0Uw4SIDk7LDcXgZ5+xdQrVu744S2OQ==', N'BCHLBMOJQN7OWQKFEBDW4Q25BCBKY5QV', N'4d32f213-57c7-4521-a69a-cd0ad2440725', NULL, 0, 0, NULL, 1, 0, N'جدة', 1212334, 1, N'سلطان حسن', 0, N'تابتيسبتن', N'ىنبىنس', N'0543444', 1, N'Customer')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [CardId], [CityId], [FullName], [Gender], [Jop], [JopTitle], [Mobile], [StateId], [UserType]) VALUES (N'b188f100-af80-4b59-9d84-0c5d1bcc873a', N'blog2@blog.com', N'BLOG2@BLOG.COM', N'blog2@blog.com', N'BLOG2@BLOG.COM', 0, N'AQAAAAEAACcQAAAAEN9pevOEuRrLHTIXsbBykgojwVg+0OJrW3t7F93A5ld+ZP5Y2I32hzC1sycG8Nffag==', N'U4LPFISOYHF7YAQICHQ7N6SE3S237SW6', N'076a37b8-775d-4e29-ae34-98ad4f16d44d', NULL, 0, 0, NULL, 1, 0, N'fefe', 34232, 4, N'خالد الزهراني', 0, N'ferew', N'dfgretre', N'44444', 2, N'Customer')
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([CityId], [Name], [StateId]) VALUES (1, N'جدة', 1)
INSERT [dbo].[Cities] ([CityId], [Name], [StateId]) VALUES (2, N'بحرة', 1)
INSERT [dbo].[Cities] ([CityId], [Name], [StateId]) VALUES (3, N'مكة', 1)
INSERT [dbo].[Cities] ([CityId], [Name], [StateId]) VALUES (4, N'الرياض', 2)
INSERT [dbo].[Cities] ([CityId], [Name], [StateId]) VALUES (5, N'أبها', 4)
INSERT [dbo].[Cities] ([CityId], [Name], [StateId]) VALUES (6, N'الدمام', 3)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [AdminName], [SignImageUrl]) VALUES (1, N'محمد بن عامر النفيعي', N'sign.png')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [Uneviersity], [City_Univ], [College], [Section], [Specialize], [StudyTitle], [Goal], [ToolsPdfUrl], [School_Type], [Term_Year], [Term], [StatusId], [Active], [Notes], [CreatedOn]) VALUES (1, N'02cfe5bf-1bbc-493f-a1ec-865c3c2bf5e3', N'الملك عبدالعزيز', N'جدة', N'التربية', N'مناهج', N'طرق تدريس', N'متطلبات التنمية المهنية بالنسبة لأعضاء الهيئة التدريسية في التعليم الجامعي بضوء مجتمع المعرفة', 0, N'Identity Core 6.pdf', 0, N'1443', 0, 2, 1, NULL, CAST(N'2022-04-23T00:00:59.1170000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [UserId], [Uneviersity], [City_Univ], [College], [Section], [Specialize], [StudyTitle], [Goal], [ToolsPdfUrl], [School_Type], [Term_Year], [Term], [StatusId], [Active], [Notes], [CreatedOn]) VALUES (3, N'80034ba5-b14d-4097-b30f-1d05ae01bf1f', N'ام القرى', N'مكة', N'التربية', N'قسم المناهج', N'طرق تدريس', N'واقع المناهج المعاصرة', 0, N'Identity Core 6.pdf', 1, N'1443', 2, 1, 1, NULL, CAST(N'2022-04-24T22:44:11.0000000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [UserId], [Uneviersity], [City_Univ], [College], [Section], [Specialize], [StudyTitle], [Goal], [ToolsPdfUrl], [School_Type], [Term_Year], [Term], [StatusId], [Active], [Notes], [CreatedOn]) VALUES (4, N'b188f100-af80-4b59-9d84-0c5d1bcc873a', N'الملك عبدالعزيز', N'جدة', N'التربية', N'مناهج', N'طرق تدريس علوم', N'التفاعلات الكيميائية', 0, N'Chapter 13_ Newspaper App.pdf', 0, N'1443', 0, 5, 1, NULL, CAST(N'2022-04-26T00:15:05.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([StateId], [Name]) VALUES (1, N'مكة المكرمة')
INSERT [dbo].[States] ([StateId], [Name]) VALUES (2, N'الرياض')
INSERT [dbo].[States] ([StateId], [Name]) VALUES (3, N'الشرقية')
INSERT [dbo].[States] ([StateId], [Name]) VALUES (4, N'عسير')
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'تم إرسال الطلب')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'تم استلام الطلب')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (3, N'تم رفض الطلب')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (4, N'تم إعادة الطلب للباحث')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (5, N'تم اعتماد الطلب وارساله للباحث')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_CityId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CityId] ON [dbo].[AspNetUsers]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_StateId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_StateId] ON [dbo].[AspNetUsers]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cities_StateId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_Cities_StateId] ON [dbo].[Cities]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_StatusId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_Orders_StatusId] ON [dbo].[Orders]
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 5/4/2022 11:20:39 م ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Cities_CityId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_States_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_States_StateId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_States_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_States_StateId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Status_StatusId]
GO
USE [master]
GO
ALTER DATABASE [ResearchesMVC] SET  READ_WRITE 
GO
