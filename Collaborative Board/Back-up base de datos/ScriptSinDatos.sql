USE [master]
GO
/****** Object:  Database [BoardDatabase]    Script Date: 22/06/2017 21:12:19 ******/
CREATE DATABASE [BoardDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BoardDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BoardDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BoardDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BoardDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BoardDatabase] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoardDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoardDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BoardDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BoardDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BoardDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BoardDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [BoardDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BoardDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BoardDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BoardDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BoardDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BoardDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BoardDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BoardDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BoardDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BoardDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BoardDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BoardDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BoardDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BoardDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BoardDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BoardDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BoardDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BoardDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BoardDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [BoardDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BoardDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BoardDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BoardDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BoardDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BoardDatabase] SET QUERY_STORE = OFF
GO
USE [BoardDatabase]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BoardDatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatorEmail] [nvarchar](max) NULL,
	[ResolutionDate] [datetime] NOT NULL,
	[ResolverEmail] [nvarchar](max) NULL,
	[AssociatedElement_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Connections]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ConectionDirection] [int] NOT NULL,
	[Destination_Id] [int] NULL,
	[Origin_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Connections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ElementWhiteboards]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElementWhiteboards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RelativeX] [int] NOT NULL,
	[RelativeY] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[ImageToSave] [varbinary](max) NULL,
	[TextContent] [nvarchar](max) NULL,
	[FontToSave] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Container_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ElementWhiteboards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberScorings]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberScorings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MembersTotalScore] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[MembersTeamId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MemberScorings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScoringManagers]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScoringManagers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateWhiteboardScore] [int] NOT NULL,
	[DeleteWhiteboardScore] [int] NOT NULL,
	[AddElementScore] [int] NOT NULL,
	[AddCommentScore] [int] NOT NULL,
	[SetCommentAsSolvedScore] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ScoringManagers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[MaximumMembers] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeamUsers]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamUsers](
	[Team_Id] [int] NOT NULL,
	[User_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TeamUsers] PRIMARY KEY CLUSTERED 
(
	[Team_Id] ASC,
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Birthdate] [datetime] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[HasAdministrationPrivileges] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Whiteboards]    Script Date: 22/06/2017 21:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Whiteboards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModification] [datetime] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[OwnerTeam_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Whiteboards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_AssociatedElement_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_AssociatedElement_Id] ON [dbo].[Comments]
(
	[AssociatedElement_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Destination_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_Destination_Id] ON [dbo].[Connections]
(
	[Destination_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Origin_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_Origin_Id] ON [dbo].[Connections]
(
	[Origin_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Container_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_Container_Id] ON [dbo].[ElementWhiteboards]
(
	[Container_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Team_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_Team_Id] ON [dbo].[TeamUsers]
(
	[Team_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[TeamUsers]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OwnerTeam_Id]    Script Date: 22/06/2017 21:12:19 ******/
CREATE NONCLUSTERED INDEX [IX_OwnerTeam_Id] ON [dbo].[Whiteboards]
(
	[OwnerTeam_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comments_dbo.ElementWhiteboards_AssociatedElement_Id] FOREIGN KEY([AssociatedElement_Id])
REFERENCES [dbo].[ElementWhiteboards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_dbo.Comments_dbo.ElementWhiteboards_AssociatedElement_Id]
GO
ALTER TABLE [dbo].[Connections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Connections_dbo.ElementWhiteboards_Destination_Id] FOREIGN KEY([Destination_Id])
REFERENCES [dbo].[ElementWhiteboards] ([Id])
GO
ALTER TABLE [dbo].[Connections] CHECK CONSTRAINT [FK_dbo.Connections_dbo.ElementWhiteboards_Destination_Id]
GO
ALTER TABLE [dbo].[Connections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Connections_dbo.ElementWhiteboards_Origin_Id] FOREIGN KEY([Origin_Id])
REFERENCES [dbo].[ElementWhiteboards] ([Id])
GO
ALTER TABLE [dbo].[Connections] CHECK CONSTRAINT [FK_dbo.Connections_dbo.ElementWhiteboards_Origin_Id]
GO
ALTER TABLE [dbo].[ElementWhiteboards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ElementWhiteboards_dbo.Whiteboards_Container_Id] FOREIGN KEY([Container_Id])
REFERENCES [dbo].[Whiteboards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ElementWhiteboards] CHECK CONSTRAINT [FK_dbo.ElementWhiteboards_dbo.Whiteboards_Container_Id]
GO
ALTER TABLE [dbo].[TeamUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeamUsers_dbo.Teams_Team_Id] FOREIGN KEY([Team_Id])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamUsers] CHECK CONSTRAINT [FK_dbo.TeamUsers_dbo.Teams_Team_Id]
GO
ALTER TABLE [dbo].[TeamUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeamUsers_dbo.Users_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamUsers] CHECK CONSTRAINT [FK_dbo.TeamUsers_dbo.Users_User_Id]
GO
ALTER TABLE [dbo].[Whiteboards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Whiteboards_dbo.Teams_OwnerTeam_Id] FOREIGN KEY([OwnerTeam_Id])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Whiteboards] CHECK CONSTRAINT [FK_dbo.Whiteboards_dbo.Teams_OwnerTeam_Id]
GO
USE [master]
GO
ALTER DATABASE [BoardDatabase] SET  READ_WRITE 
GO
