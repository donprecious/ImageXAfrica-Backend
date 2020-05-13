USE [master]
GO
/****** Object:  Database [ImageAfricaDbApp]    Script Date: 4/27/2020 1:04:48 AM ******/
CREATE DATABASE [ImageAfricaDbApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ImageAfricaDbApp', FILENAME = N'C:\Users\Chigozie Joshua\ImageAfricaDbApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ImageAfricaDbApp_log', FILENAME = N'C:\Users\Chigozie Joshua\ImageAfricaDbApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ImageAfricaDbApp] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ImageAfricaDbApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ImageAfricaDbApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ImageAfricaDbApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ImageAfricaDbApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ImageAfricaDbApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ImageAfricaDbApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ImageAfricaDbApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ImageAfricaDbApp] SET  MULTI_USER 
GO
ALTER DATABASE [ImageAfricaDbApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ImageAfricaDbApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ImageAfricaDbApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ImageAfricaDbApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ImageAfricaDbApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ImageAfricaDbApp] SET QUERY_STORE = OFF
GO
USE [ImageAfricaDbApp]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ImageAfricaDbApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/27/2020 1:04:48 AM ******/
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
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ProfileImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/27/2020 1:04:48 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatorUserId] [nvarchar](max) NULL,
	[LastModificationTime] [datetime2](7) NULL,
	[LastModifierUserId] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletionTime] [datetime2](7) NULL,
	[DeleterUserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Challenges]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Challenges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[TipsAndConditions] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Prize] [varchar](max) NOT NULL,
	[FirstWinnerImageId] [int] NULL,
	[SecondWinnerImageId] [int] NULL,
	[OrganizerName] [nvarchar](max) NOT NULL,
	[OrganizerUrl] [nvarchar](max) NOT NULL,
	[CreatorUserId] [nvarchar](max) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierUserId] [nvarchar](max) NULL,
	[LastModificationTime] [datetime2](7) NULL,
	[IsDeleted] [bit] NULL,
	[DeleterUserId] [nvarchar](max) NULL,
	[DeletionTime] [datetime2](7) NULL,
 CONSTRAINT [PK_dbo.Challenges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentCollections]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentCollections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[CreatorUserId] [nvarchar](max) NULL,
	[ImageId] [int] NOT NULL,
	[LastModificationTime] [datetime2](7) NULL,
	[LastModifierUserId] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletionTime] [datetime2](7) NULL,
	[DeleterUserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContentCollections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageLikes]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageLikes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ImageId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_ImageLikes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[GeoLat] [float] NOT NULL,
	[GeoLog] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[CreatorUserId] [nvarchar](max) NULL,
	[LastModificationTime] [datetime2](7) NULL,
	[LastModifierUserId] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletionTime] [datetime2](7) NULL,
	[DeleterUserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageTags]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ImageId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[CreatorUserId] [nvarchar](max) NULL,
	[LastModificationTime] [datetime2](7) NULL,
	[LastModifierUserId] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletionTime] [datetime2](7) NULL,
	[DeleterUserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_ImageTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageViews]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageViews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_ImageViews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatorUserId] [nvarchar](max) NULL,
	[LastModificationTime] [datetime2](7) NULL,
	[LastModifierUserId] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletionTime] [datetime2](7) NULL,
	[DeleterUserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChallenges]    Script Date: 4/27/2020 1:04:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChallenges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChallengeId] [int] NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[JoinedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserChallenges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
ALTER TABLE [dbo].[ContentCollections]  WITH CHECK ADD  CONSTRAINT [FK_ContentCollections_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ContentCollections] CHECK CONSTRAINT [FK_ContentCollections_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ContentCollections]  WITH CHECK ADD  CONSTRAINT [FK_ContentCollections_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContentCollections] CHECK CONSTRAINT [FK_ContentCollections_Images_ImageId]
GO
ALTER TABLE [dbo].[ImageLikes]  WITH CHECK ADD  CONSTRAINT [FK_ImageLikes_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ImageLikes] CHECK CONSTRAINT [FK_ImageLikes_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ImageLikes]  WITH CHECK ADD  CONSTRAINT [FK_ImageLikes_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageLikes] CHECK CONSTRAINT [FK_ImageLikes_Images_ImageId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ImageTags]  WITH CHECK ADD  CONSTRAINT [FK_ImageTags_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageTags] CHECK CONSTRAINT [FK_ImageTags_Images_ImageId]
GO
ALTER TABLE [dbo].[ImageTags]  WITH CHECK ADD  CONSTRAINT [FK_ImageTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageTags] CHECK CONSTRAINT [FK_ImageTags_Tags_TagId]
GO
ALTER TABLE [dbo].[ImageViews]  WITH CHECK ADD  CONSTRAINT [FK_ImageViews_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageViews] CHECK CONSTRAINT [FK_ImageViews_Images_ImageId]
GO
USE [master]
GO
ALTER DATABASE [ImageAfricaDbApp] SET  READ_WRITE 
GO
