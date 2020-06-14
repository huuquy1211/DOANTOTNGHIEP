USE [master]
GO
/****** Object:  Database [EnglishGame]    Script Date: 6/13/2020 10:04:48 PM ******/
CREATE DATABASE [EnglishGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnglishGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.ADMIN\MSSQL\DATA\EnglishGame.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EnglishGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.ADMIN\MSSQL\DATA\EnglishGame_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EnglishGame] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnglishGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnglishGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnglishGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnglishGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnglishGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnglishGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnglishGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EnglishGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnglishGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnglishGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnglishGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnglishGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnglishGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnglishGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnglishGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnglishGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EnglishGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnglishGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnglishGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnglishGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnglishGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnglishGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EnglishGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnglishGame] SET RECOVERY FULL 
GO
ALTER DATABASE [EnglishGame] SET  MULTI_USER 
GO
ALTER DATABASE [EnglishGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnglishGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnglishGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnglishGame] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EnglishGame] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EnglishGame', N'ON'
GO
USE [EnglishGame]
GO
/****** Object:  Table [dbo].[Painting]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Painting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varchar](128) NULL,
	[ImagePainted] [varchar](128) NULL,
	[Request] [varchar](128) NULL,
	[Color] [int] NULL,
 CONSTRAINT [PK_Painting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaintingOfUnit]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaintingOfUnit](
	[Id_Painting] [int] NOT NULL,
	[Id_Unit] [int] NOT NULL,
 CONSTRAINT [PK_PaintingOfUnit] PRIMARY KEY CLUSTERED 
(
	[Id_Painting] ASC,
	[Id_Unit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sentence]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sentence](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sound] [varchar](128) NULL,
	[Image] [varchar](128) NULL,
	[Text] [varchar](256) NULL,
 CONSTRAINT [PK_Sentence] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SentenceOfUnit]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SentenceOfUnit](
	[Id_Unit] [int] NOT NULL,
	[Id_Sentence] [int] NOT NULL,
 CONSTRAINT [PK_SentenceOfUnit] PRIMARY KEY CLUSTERED 
(
	[Id_Unit] ASC,
	[Id_Sentence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Word](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varchar](128) NULL,
	[Voice] [varchar](128) NULL,
 CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WordOfUnit]    Script Date: 6/13/2020 10:04:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordOfUnit](
	[Id_Unit] [int] NOT NULL,
	[Id_Word] [int] NOT NULL,
 CONSTRAINT [PK_WordOfUnit] PRIMARY KEY CLUSTERED 
(
	[Id_Unit] ASC,
	[Id_Word] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Sentence] ON 

INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (1, N'..\..\media\audio\storytime\act1\sound1.mp3', N'..\..\media\textures\storytime\act1\img1.png', N'School Days')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (2, N'..\..\media\audio\storytime\act1\sound2.mp3', N'..\..\media\textures\storytime\act1\img2.png', N'-What is this?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (3, N'..\..\media\audio\storytime\act1\sound3.mp3', N'..\..\media\textures\storytime\act1\img3.png', N'-It is a puppet.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (4, N'..\..\media\audio\storytime\act1\sound4.mp3', N'..\..\media\textures\storytime\act1\img4.png', N'-Oh! It''s a puppet.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (5, N'..\..\media\audio\storytime\act2\sound1.mp3', N'..\..\media\textures\storytime\act2\img1.png', N'What Is This?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (6, N'..\..\media\audio\storytime\act2\sound2.mp3', N'..\..\media\textures\storytime\act2\img2.png', N'-What is this?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (7, N'..\..\media\audio\storytime\act2\sound3.mp3', N'..\..\media\textures\storytime\act2\img2.png', N'-It is a square.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (8, N'..\..\media\audio\storytime\act2\sound4.mp3', N'..\..\media\textures\storytime\act2\img3.png', N'-They are Circles.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (9, N'..\..\media\audio\storytime\act2\sound5.mp3', N'..\..\media\textures\storytime\act2\img3.png', N'-They are Circles.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (10, N'..\..\media\audio\storytime\act2\sound6.mp3', N'..\..\media\textures\storytime\act2\img4.png', N'-It is a face!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (11, N'..\..\media\audio\storytime\act3\sound1.mp3', N'..\..\media\textures\storytime\act3\img1.png', N'My Family')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (12, N'..\..\media\audio\storytime\act3\sound2.mp3', N'..\..\media\textures\storytime\act3\img1.png', N'-This is my mother.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (13, N'..\..\media\audio\storytime\act3\sound3.mp3', N'..\..\media\textures\storytime\act3\img2.png', N'-This is my sister.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (14, N'..\..\media\audio\storytime\act3\sound4.mp3', N'..\..\media\textures\storytime\act3\img3.png', N'-Hello!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (15, N'..\..\media\audio\storytime\act3\sound5.mp3', N'..\..\media\textures\storytime\act3\img4.png', N'-This is my brother.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (16, N'..\..\media\audio\storytime\act3\sound6.mp3', N'..\..\media\textures\storytime\act3\img4.png', N'-What?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (17, N'..\..\media\audio\storytime\act3\sound7.mp3', N'..\..\media\textures\storytime\act3\img4.png', N'-Hi!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (18, N'..\..\media\audio\storytime\act4\sound1.mp3', N'..\..\media\textures\storytime\act4\img1.png', N'Dollhouse')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (19, N'..\..\media\audio\storytime\act4\sound2.mp3', N'..\..\media\textures\storytime\act4\img1.png', N'-I want dolls.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (20, N'..\..\media\audio\storytime\act4\sound3.mp3', N'..\..\media\textures\storytime\act4\img1.png', N'-Let find dolls.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (21, N'..\..\media\audio\storytime\act4\sound4.mp3', N'..\..\media\textures\storytime\act4\img2.png', N'-Look!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (22, N'..\..\media\audio\storytime\act4\sound5.mp3', N'..\..\media\textures\storytime\act4\img1.png', N'-Yay!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (23, N'..\..\media\audio\storytime\act4\sound6.mp3', N'..\..\media\textures\storytime\act4\img3.png', N'-This is the mother.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (24, N'..\..\media\audio\storytime\act4\sound7.mp3', N'..\..\media\textures\storytime\act4\img3.png', N'-I want a doll family!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (25, N'..\..\media\audio\storytime\act4\sound8.mp3', N'..\..\media\textures\storytime\act4\img4.png', N'-We have BIG baby dolls!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (26, N'..\..\media\audio\storytime\act5\sound1.mp3', N'..\..\media\textures\storytime\act5\img1.png', N'A Surprise')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (27, N'..\..\media\audio\storytime\act5\sound2.mp3', N'..\..\media\textures\storytime\act5\img1.png', N'-I have milk.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (28, N'..\..\media\audio\storytime\act5\sound3.mp3', N'..\..\media\textures\storytime\act5\img2.png', N'-I have carrots.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (29, N'..\..\media\audio\storytime\act5\sound4.mp3', N'..\..\media\textures\storytime\act5\img3.png', N'-What do you have?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (30, N'..\..\media\audio\storytime\act5\sound5.mp3', N'..\..\media\textures\storytime\act5\img4.png', N'-We have lunch and... a surprise!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (31, N'..\..\media\audio\storytime\act6\sound1.mp3', N'..\..\media\textures\storytime\act6\img1.png', N'Let''s Play')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (32, N'..\..\media\audio\storytime\act6\sound2.mp3', N'..\..\media\textures\storytime\act6\img1.png', N'-Let''s play.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (33, N'..\..\media\audio\storytime\act6\sound3.mp3', N'..\..\media\textures\storytime\act6\img2.png', N'-Yes! Yes!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (34, N'..\..\media\audio\storytime\act6\sound4.mp3', N'..\..\media\textures\storytime\act6\img2.png', N'-I want it!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (35, N'..\..\media\audio\storytime\act6\sound5.mp3', N'..\..\media\textures\storytime\act6\img2.png', N'-No! I want it!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (36, N'..\..\media\audio\storytime\act6\sound6.mp3', N'..\..\media\textures\storytime\act6\img3.png', N'-Look at you!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (37, N'..\..\media\audio\storytime\act6\sound7.mp3', N'..\..\media\textures\storytime\act6\img4.png', N'-I want a picture, please!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (38, N'..\..\media\audio\storytime\act7\sound1.mp3', N'..\..\media\textures\storytime\act7\img1.png', N'Where''s Lucy?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (39, N'..\..\media\audio\storytime\act7\sound2.mp3', N'..\..\media\textures\storytime\act7\img1.png', N'-Where''s Lucy?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (40, N'..\..\media\audio\storytime\act7\sound3.mp3', N'..\..\media\textures\storytime\act7\img2.png', N'-I don''t know.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (41, N'..\..\media\audio\storytime\act7\sound4.mp3', N'..\..\media\textures\storytime\act7\img2.png', N'-I see a crayon.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (42, N'..\..\media\audio\storytime\act7\sound5.mp3', N'..\..\media\textures\storytime\act7\img3.png', N'-I see a fish, but where''s Lucy?')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (43, N'..\..\media\audio\storytime\act7\sound6.mp3', N'..\..\media\textures\storytime\act7\img4.png', N'-I see Lucy. I see her new puppies, too!')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (44, N'..\..\media\audio\storytime\act8\sound1.mp3', N'..\..\media\textures\storytime\act8\img1.png', N'Hospital')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (45, N'..\..\media\audio\storytime\act8\sound2.mp3', N'..\..\media\textures\storytime\act8\img1.png', N'-I see one doctor.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (46, N'..\..\media\audio\storytime\act8\sound3.mp3', N'..\..\media\textures\storytime\act8\img2.png', N'-I see two nurses.')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (47, N'..\..\media\audio\storytime\act8\sound4.mp3', N'..\..\media\textures\storytime\act8\img3.png', N'-I see...')
INSERT [dbo].[Sentence] ([Id], [Sound], [Image], [Text]) VALUES (48, N'..\..\media\audio\storytime\act8\sound5.mp3', N'..\..\media\textures\storytime\act8\img4.png', N'-One, two, three balloons!')
SET IDENTITY_INSERT [dbo].[Sentence] OFF
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 1)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 2)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 3)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 4)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 5)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 6)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 7)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 8)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 9)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 10)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 11)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 12)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 13)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 14)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 15)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 16)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (3, 17)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 18)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 19)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 20)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 21)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 22)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 23)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 24)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (4, 25)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (5, 26)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (5, 27)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (5, 28)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (5, 29)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (5, 30)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 31)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 32)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 33)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 34)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 35)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 36)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (6, 37)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7, 38)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7, 39)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7, 40)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7, 41)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7, 42)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7, 43)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (8, 44)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (8, 45)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (8, 46)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (8, 47)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (8, 48)
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [Number]) VALUES (1, 1)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (2, 2)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (3, 3)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (4, 4)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (5, 5)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (6, 6)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (7, 7)
INSERT [dbo].[Unit] ([Id], [Number]) VALUES (8, 8)
SET IDENTITY_INSERT [dbo].[Unit] OFF
SET IDENTITY_INSERT [dbo].[Word] ON 

INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (1, N'..\..\media\textures\concentration\act1\img1.png', N'..\..\media\audio\concentration\act1\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (2, N'..\..\media\textures\concentration\act1\img2.png', N'..\..\media\audio\concentration\act1\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (3, N'..\..\media\textures\concentration\act1\img3.png', N'..\..\media\audio\concentration\act1\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (4, N'..\..\media\textures\concentration\act2\img1.png', N'..\..\media\audio\concentration\act2\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (5, N'..\..\media\textures\concentration\act2\img2.png', N'..\..\media\audio\concentration\act2\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (6, N'..\..\media\textures\concentration\act2\img3.png', N'..\..\media\audio\concentration\act2\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (7, N'..\..\media\textures\concentration\act3\img1.png', N'..\..\media\audio\concentration\act3\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (8, N'..\..\media\textures\concentration\act3\img2.png', N'..\..\media\audio\concentration\act3\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (9, N'..\..\media\textures\concentration\act3\img3.png', N'..\..\media\audio\concentration\act3\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (10, N'..\..\media\textures\concentration\act4\img1.png', N'..\..\media\audio\concentration\act4\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (11, N'..\..\media\textures\concentration\act4\img2.png', N'..\..\media\audio\concentration\act4\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (12, N'..\..\media\textures\concentration\act4\img3.png', N'..\..\media\audio\concentration\act4\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (13, N'..\..\media\textures\concentration\act5\img1.png', N'..\..\media\audio\concentration\act5\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (14, N'..\..\media\textures\concentration\act5\img2.png', N'..\..\media\audio\concentration\act5\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (15, N'..\..\media\textures\concentration\act5\img3.png', N'..\..\media\audio\concentration\act5\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (16, N'..\..\media\textures\concentration\act6\img1.png', N'..\..\media\audio\concentration\act6\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (17, N'..\..\media\textures\concentration\act6\img2.png', N'..\..\media\audio\concentration\act6\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (18, N'..\..\media\textures\concentration\act6\img3.png', N'..\..\media\audio\concentration\act6\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (19, N'..\..\media\textures\concentration\act7\img1.png', N'..\..\media\audio\concentration\act7\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (20, N'..\..\media\textures\concentration\act7\img2.png', N'..\..\media\audio\concentration\act7\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (21, N'..\..\media\textures\concentration\act7\img3.png', N'..\..\media\audio\concentration\act7\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (22, N'..\..\media\textures\concentration\act8\img1.png', N'..\..\media\audio\concentration\act8\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (23, N'..\..\media\textures\concentration\act8\img2.png', N'..\..\media\audio\concentration\act8\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (24, N'..\..\media\textures\concentration\act8\img3.png', N'..\..\media\audio\concentration\act8\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (25, N'..\..\media\textures\matching\act1\img1.png', N'..\..\media\audio\matching\act1\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (26, N'..\..\media\textures\matching\act1\img2.png', N'..\..\media\audio\matching\act1\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (27, N'..\..\media\textures\matching\act1\img3.png', N'..\..\media\audio\matching\act1\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (28, N'..\..\media\textures\matching\act2\img1.png', N'..\..\media\audio\matching\act2\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (29, N'..\..\media\textures\matching\act2\img2.png', N'..\..\media\audio\matching\act2\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (30, N'..\..\media\textures\matching\act2\img3.png', N'..\..\media\audio\matching\act2\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (31, N'..\..\media\textures\matching\act3\img1.png', N'..\..\media\audio\matching\act3\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (32, N'..\..\media\textures\matching\act3\img2.png', N'..\..\media\audio\matching\act3\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (33, N'..\..\media\textures\matching\act3\img3.png', N'..\..\media\audio\matching\act3\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (34, N'..\..\media\textures\matching\act4\img1.png', N'..\..\media\audio\matching\act4\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (35, N'..\..\media\textures\matching\act4\img2.png', N'..\..\media\audio\matching\act4\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (36, N'..\..\media\textures\matching\act4\img3.png', N'..\..\media\audio\matching\act4\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (37, N'..\..\media\textures\matching\act5\img1.png', N'..\..\media\audio\matching\act5\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (38, N'..\..\media\textures\matching\act5\img2.png', N'..\..\media\audio\matching\act5\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (39, N'..\..\media\textures\matching\act5\img3.png', N'..\..\media\audio\matching\act5\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (40, N'..\..\media\textures\matching\act6\img1.png', N'..\..\media\audio\matching\act6\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (41, N'..\..\media\textures\matching\act6\img2.png', N'..\..\media\audio\matching\act6\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (42, N'..\..\media\textures\matching\act6\img3.png', N'..\..\media\audio\matching\act6\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (43, N'..\..\media\textures\matching\act7\img1.png', N'..\..\media\audio\matching\act7\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (44, N'..\..\media\textures\matching\act7\img2.png', N'..\..\media\audio\matching\act7\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (45, N'..\..\media\textures\matching\act7\img3.png', N'..\..\media\audio\matching\act7\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (46, N'..\..\media\textures\matching\act8\img1.png', N'..\..\media\audio\matching\act8\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (47, N'..\..\media\textures\matching\act8\img2.png', N'..\..\media\audio\matching\act8\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (48, N'..\..\media\textures\matching\act8\img3.png', N'..\..\media\audio\matching\act8\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (49, N'..\..\media\textures\multiplechoice\act1\img1.png', N'..\..\media\audio\multiplechoice\act1\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (50, N'..\..\media\textures\multiplechoice\act1\img2.png', N'..\..\media\audio\multiplechoice\act1\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (51, N'..\..\media\textures\multiplechoice\act1\img3.png', N'..\..\media\audio\multiplechoice\act1\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (52, N'..\..\media\textures\multiplechoice\act2\img1.png', N'..\..\media\audio\multiplechoice\act2\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (53, N'..\..\media\textures\multiplechoice\act2\img2.png', N'..\..\media\audio\multiplechoice\act2\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (54, N'..\..\media\textures\multiplechoice\act2\img3.png', N'..\..\media\audio\multiplechoice\act2\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (55, N'..\..\media\textures\multiplechoice\act3\img1.png', N'..\..\media\audio\multiplechoice\act3\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (56, N'..\..\media\textures\multiplechoice\act3\img2.png', N'..\..\media\audio\multiplechoice\act3\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (57, N'..\..\media\textures\multiplechoice\act3\img3.png', N'..\..\media\audio\multiplechoice\act3\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (58, N'..\..\media\textures\multiplechoice\act4\img1.png', N'..\..\media\audio\multiplechoice\act4\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (59, N'..\..\media\textures\multiplechoice\act4\img2.png', N'..\..\media\audio\multiplechoice\act4\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (60, N'..\..\media\textures\multiplechoice\act4\img3.png', N'..\..\media\audio\multiplechoice\act4\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (61, N'..\..\media\textures\multiplechoice\act5\img1.png', N'..\..\media\audio\multiplechoice\act5\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (62, N'..\..\media\textures\multiplechoice\act5\img2.png', N'..\..\media\audio\multiplechoice\act5\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (63, N'..\..\media\textures\multiplechoice\act5\img3.png', N'..\..\media\audio\multiplechoice\act5\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (64, N'..\..\media\textures\multiplechoice\act6\img1.png', N'..\..\media\audio\multiplechoice\act6\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (65, N'..\..\media\textures\multiplechoice\act6\img2.png', N'..\..\media\audio\multiplechoice\act6\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (66, N'..\..\media\textures\multiplechoice\act6\img3.png', N'..\..\media\audio\multiplechoice\act6\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (67, N'..\..\media\textures\multiplechoice\act7\img1.png', N'..\..\media\audio\multiplechoice\act7\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (68, N'..\..\media\textures\multiplechoice\act7\img2.png', N'..\..\media\audio\multiplechoice\act7\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (69, N'..\..\media\textures\multiplechoice\act7\img3.png', N'..\..\media\audio\multiplechoice\act7\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (70, N'..\..\media\textures\multiplechoice\act8\img1.png', N'..\..\media\audio\multiplechoice\act8\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (71, N'..\..\media\textures\multiplechoice\act8\img2.png', N'..\..\media\audio\multiplechoice\act8\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (72, N'..\..\media\textures\multiplechoice\act8\img3.png', N'..\..\media\audio\multiplechoice\act8\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (73, N'..\..\media\textures\sequence\act1\img1.png', N'..\..\media\audio\sequence\act1\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (74, N'..\..\media\textures\sequence\act1\img2.png', N'..\..\media\audio\sequence\act1\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (75, N'..\..\media\textures\sequence\act1\img3.png', N'..\..\media\audio\sequence\act1\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (76, N'..\..\media\textures\sequence\act2\img1.png', N'..\..\media\audio\sequence\act2\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (77, N'..\..\media\textures\sequence\act2\img2.png', N'..\..\media\audio\sequence\act2\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (78, N'..\..\media\textures\sequence\act2\img3.png', N'..\..\media\audio\sequence\act2\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (79, N'..\..\media\textures\sequence\act3\img1.png', N'..\..\media\audio\sequence\act3\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (80, N'..\..\media\textures\sequence\act3\img2.png', N'..\..\media\audio\sequence\act3\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (81, N'..\..\media\textures\sequence\act3\img3.png', N'..\..\media\audio\sequence\act3\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (82, N'..\..\media\textures\sequence\act4\img1.png', N'..\..\media\audio\sequence\act4\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (83, N'..\..\media\textures\sequence\act4\img2.png', N'..\..\media\audio\sequence\act4\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (84, N'..\..\media\textures\sequence\act4\img3.png', N'..\..\media\audio\sequence\act4\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (85, N'..\..\media\textures\sequence\act5\img1.png', N'..\..\media\audio\sequence\act5\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (86, N'..\..\media\textures\sequence\act5\img2.png', N'..\..\media\audio\sequence\act5\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (87, N'..\..\media\textures\sequence\act5\img3.png', N'..\..\media\audio\sequence\act5\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (88, N'..\..\media\textures\sequence\act6\img1.png', N'..\..\media\audio\sequence\act6\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (89, N'..\..\media\textures\sequence\act6\img2.png', N'..\..\media\audio\sequence\act6\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (90, N'..\..\media\textures\sequence\act6\img3.png', N'..\..\media\audio\sequence\act6\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (91, N'..\..\media\textures\sequence\act7\img1.png', N'..\..\media\audio\sequence\act7\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (92, N'..\..\media\textures\sequence\act7\img2.png', N'..\..\media\audio\sequence\act7\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (93, N'..\..\media\textures\sequence\act7\img3.png', N'..\..\media\audio\sequence\act7\sound3.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (94, N'..\..\media\textures\sequence\act8\img1.png', N'..\..\media\audio\sequence\act8\sound1.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (95, N'..\..\media\textures\sequence\act8\img2.png', N'..\..\media\audio\sequence\act8\sound2.mp3')
INSERT [dbo].[Word] ([Id], [Image], [Voice]) VALUES (96, N'..\..\media\textures\sequence\act8\img3.png', N'..\..\media\audio\sequence\act8\sound3.mp3')
SET IDENTITY_INSERT [dbo].[Word] OFF
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (1, 1)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (1, 2)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (1, 3)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (2, 4)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (2, 5)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (2, 6)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (3, 7)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (3, 8)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (3, 9)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (4, 10)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (4, 11)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (4, 12)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (5, 13)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (5, 14)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (5, 15)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (6, 16)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (6, 17)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (6, 18)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (7, 19)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (7, 20)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (7, 21)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (8, 22)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (8, 23)
INSERT [dbo].[WordOfUnit] ([Id_Unit], [Id_Word]) VALUES (8, 24)


INSERT INTO Painting VALUES
('..\..\media\textures\painting\act1\img1.png','..\..\media\textures\painting\act1\coloredimg1.png','..\..\media\audio\painting\act1\sound1.mp3',1),
('..\..\media\textures\painting\act1\img2.png','..\..\media\textures\painting\act1\coloredimg2.png','..\..\media\audio\painting\act1\sound2.mp3',1),
('..\..\media\textures\painting\act1\img3.png','..\..\media\textures\painting\act1\coloredimg3.png','..\..\media\audio\painting\act1\sound3.mp3',1),

('..\..\media\textures\painting\act2\img1.png','..\..\media\textures\painting\act2\coloredimg1.png','..\..\media\audio\painting\act2\sound1.mp3',2),
('..\..\media\textures\painting\act2\img2.png','..\..\media\textures\painting\act2\coloredimg2.png','..\..\media\audio\painting\act2\sound2.mp3',1),
('..\..\media\textures\painting\act2\img3.png','..\..\media\textures\painting\act2\coloredimg3.png','..\..\media\audio\painting\act2\sound3.mp3',2),

('..\..\media\textures\painting\act3\img1.png','..\..\media\textures\painting\act3\coloredimg1.png','..\..\media\audio\painting\act3\sound1.mp3',2),
('..\..\media\textures\painting\act3\img2.png','..\..\media\textures\painting\act3\coloredimg2.png','..\..\media\audio\painting\act3\sound2.mp3',1),
('..\..\media\textures\painting\act3\img3.png','..\..\media\textures\painting\act3\coloredimg3.png','..\..\media\audio\painting\act3\sound3.mp3',3),

('..\..\media\textures\painting\act4\img1.png','..\..\media\textures\painting\act4\coloredimg1.png','..\..\media\audio\painting\act4\sound1.mp3',2),
('..\..\media\textures\painting\act4\img2.png','..\..\media\textures\painting\act4\coloredimg2.png','..\..\media\audio\painting\act4\sound2.mp3',4),
('..\..\media\textures\painting\act4\img3.png','..\..\media\textures\painting\act4\coloredimg3.png','..\..\media\audio\painting\act4\sound3.mp3',3),

('..\..\media\textures\painting\act5\img1.png','..\..\media\textures\painting\act5\coloredimg1.png','..\..\media\audio\painting\act5\sound1.mp3',6),
('..\..\media\textures\painting\act5\img2.png','..\..\media\textures\painting\act5\coloredimg2.png','..\..\media\audio\painting\act5\sound2.mp3',5),
('..\..\media\textures\painting\act5\img3.png','..\..\media\textures\painting\act5\coloredimg3.png','..\..\media\audio\painting\act5\sound3.mp3',1),

('..\..\media\textures\painting\act6\img1.png','..\..\media\textures\painting\act6\coloredimg1.png','..\..\media\audio\painting\act6\sound1.mp3',5),
('..\..\media\textures\painting\act6\img2.png','..\..\media\textures\painting\act6\coloredimg2.png','..\..\media\audio\painting\act6\sound2.mp3',8),
('..\..\media\textures\painting\act6\img3.png','..\..\media\textures\painting\act6\coloredimg3.png','..\..\media\audio\painting\act6\sound3.mp3',7),

('..\..\media\textures\painting\act7\img1.png','..\..\media\textures\painting\act7\coloredimg1.png','..\..\media\audio\painting\act7\sound1.mp3',4),
('..\..\media\textures\painting\act7\img2.png','..\..\media\textures\painting\act7\coloredimg2.png','..\..\media\audio\painting\act7\sound2.mp3',9),
('..\..\media\textures\painting\act7\img3.png','..\..\media\textures\painting\act7\coloredimg3.png','..\..\media\audio\painting\act7\sound3.mp3',5),

('..\..\media\textures\painting\act8\img1.png','..\..\media\textures\painting\act8\coloredimg1.png','..\..\media\audio\painting\act8\sound1.mp3',3),
('..\..\media\textures\painting\act8\img2.png','..\..\media\textures\painting\act8\coloredimg2.png','..\..\media\audio\painting\act8\sound2.mp3',5),
('..\..\media\textures\painting\act8\img3.png','..\..\media\textures\painting\act8\coloredimg3.png','..\..\media\audio\painting\act8\sound3.mp3',4)

INSERT INTO PaintingOfUnit(Id_Unit,Id_Painting) VALUES
(1,1),(1,2),(1,3),
(2,4),(2,5),(2,6),
(3,7),(3,8),(3,9),
(4,10),(4,11),(4,12),
(5,13),(5,14),(5,15),
(6,16),(6,17),(6,18),
(7,19),(7,20),(7,21),
(8,22),(8,23),(8,24)








ALTER TABLE [dbo].[PaintingOfUnit]  WITH CHECK ADD  CONSTRAINT [FK_PaintingOfUnit_Painting] FOREIGN KEY([Id_Painting])
REFERENCES [dbo].[Painting] ([Id])
GO
ALTER TABLE [dbo].[PaintingOfUnit] CHECK CONSTRAINT [FK_PaintingOfUnit_Painting]
GO
ALTER TABLE [dbo].[PaintingOfUnit]  WITH CHECK ADD  CONSTRAINT [FK_PaintingOfUnit_Unit] FOREIGN KEY([Id_Unit])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[PaintingOfUnit] CHECK CONSTRAINT [FK_PaintingOfUnit_Unit]
GO
ALTER TABLE [dbo].[SentenceOfUnit]  WITH CHECK ADD  CONSTRAINT [FK_SentenceOfUnit_Sentence] FOREIGN KEY([Id_Sentence])
REFERENCES [dbo].[Sentence] ([Id])
GO
ALTER TABLE [dbo].[SentenceOfUnit] CHECK CONSTRAINT [FK_SentenceOfUnit_Sentence]
GO
ALTER TABLE [dbo].[SentenceOfUnit]  WITH CHECK ADD  CONSTRAINT [FK_SentenceOfUnit_Unit] FOREIGN KEY([Id_Unit])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[SentenceOfUnit] CHECK CONSTRAINT [FK_SentenceOfUnit_Unit]
GO
ALTER TABLE [dbo].[WordOfUnit]  WITH CHECK ADD  CONSTRAINT [FK_WordOfUnit_Unit] FOREIGN KEY([Id_Unit])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[WordOfUnit] CHECK CONSTRAINT [FK_WordOfUnit_Unit]
GO
ALTER TABLE [dbo].[WordOfUnit]  WITH CHECK ADD  CONSTRAINT [FK_WordOfUnit_Word] FOREIGN KEY([Id_Word])
REFERENCES [dbo].[Word] ([Id])
GO
ALTER TABLE [dbo].[WordOfUnit] CHECK CONSTRAINT [FK_WordOfUnit_Word]
GO
USE [master]
GO
ALTER DATABASE [EnglishGame] SET  READ_WRITE 
GO
