USE [EnglishGame]
GO
/****** Object:  Table [dbo].[Sentence]    Script Date: 5/24/2020 1:43:56 PM ******/
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
/****** Object:  Table [dbo].[SentenceOfUnit]    Script Date: 5/24/2020 1:43:56 PM ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 5/24/2020 1:43:56 PM ******/
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
/****** Object:  Table [dbo].[Word]    Script Date: 5/24/2020 1:43:56 PM ******/
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
/****** Object:  Table [dbo].[WordOfUnit]    Script Date: 5/24/2020 1:43:56 PM ******/
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


--1-4
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act1\img1.png','..\..\media\audio\storytime\act1\sound1.mp3','School Days')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act1\img2.png','..\..\media\audio\storytime\act1\sound2.mp3','-What is this?')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act1\img3.png','..\..\media\audio\storytime\act1\sound3.mp3','-It is a puppet.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act1\img4.png','..\..\media\audio\storytime\act1\sound4.mp3','-Oh! It''s a puppet.')
--5-8
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act2\img1.png','..\..\media\audio\storytime\act2\sound1.mp3','What Is This?@-What is this?@-It is a square.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act2\img2.png','..\..\media\audio\storytime\act2\sound2.mp3','-They are Circles.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act2\img3.png','..\..\media\audio\storytime\act2\sound3.mp3','-They are Circles.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act2\img4.png','..\..\media\audio\storytime\act2\sound4.mp3','-It is a face!')
--9-12
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act3\img1.png','..\..\media\audio\storytime\act3\sound1.mp3','My Family@-This is my mother.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act3\img2.png','..\..\media\audio\storytime\act3\sound2.mp3','-This is my sister.@-Hello!')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act3\img3.png','..\..\media\audio\storytime\act3\sound3.mp3','-This is my brother.@-What?')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act3\img4.png','..\..\media\audio\storytime\act3\sound4.mp3','-Hi!')
--13-16
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act4\img1.png','..\..\media\audio\storytime\act4\sound1.mp3','Dollhouse@-I want dolls.@-Let find dolls.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act4\img2.png','..\..\media\audio\storytime\act4\sound2.mp3','-Look!@-Yay!')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act4\img3.png','..\..\media\audio\storytime\act4\sound3.mp3','-This is the mother.@-I want a doll family!')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act4\img4.png','..\..\media\audio\storytime\act4\sound4.mp3','-We have BIG baby dolls!')
--17-20
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act5\img1.png','..\..\media\audio\storytime\act5\sound1.mp3','A Surprise@-I have milk.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act5\img2.png','..\..\media\audio\storytime\act5\sound2.mp3','-I have carrots.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act5\img3.png','..\..\media\audio\storytime\act5\sound3.mp3','-What do you have?')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act5\img4.png','..\..\media\audio\storytime\act5\sound4.mp3','-We have lunch and... a surprise!')
--21-24
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act6\img1.png','..\..\media\audio\storytime\act6\sound1.mp3','Let''s Play@-Let''s play.@-Yes! Yes!')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act6\img2.png','..\..\media\audio\storytime\act6\sound2.mp3','-I want it!@-No! I want it!')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act6\img3.png','..\..\media\audio\storytime\act6\sound3.mp3','-Look at you!')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act6\img4.png','..\..\media\audio\storytime\act6\sound4.mp3','-I want a picture, please!')
--25-27
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act7\img1.png','..\..\media\audio\storytime\act7\sound1.mp3','Where''s Lucy?@-Where''s Lucy?@-I don''t know.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act7\img2.png','..\..\media\audio\storytime\act7\sound2.mp3','-I see a crayon.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act7\img3.png','..\..\media\audio\storytime\act7\sound3.mp3','-I see a fish, but where''s Lucy?')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act7\img4.png','..\..\media\audio\storytime\act7\sound4.mp3','-I see Lucy. I see her new puppies, too!')
--28-32
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act8\img1.png','..\..\media\audio\storytime\act8\sound1.mp3','Hospital@-I see one doctor.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act8\img2.png','..\..\media\audio\storytime\act8\sound2.mp3','-I see two nurses.')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act8\img3.png','..\..\media\audio\storytime\act8\sound3.mp3','-I see...')
INSERT [dbo].[Sentence] ([Image],[Sound],[Text]) VALUES ('..\..\media\textures\storytime\act8\img4.png','..\..\media\audio\storytime\act8\sound4.mp3','-One, two, three balloons!')


INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 1)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 2)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 3)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (1, 4)


INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 5)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 6)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 7)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (2, 8)

INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 3, 9)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 3, 10)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 3, 11)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 3,12 )

INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 4, 13)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 4, 14)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 4, 15)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 4, 16)

INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 5,17 )
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 5,18 )
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 5,19)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 5, 20)

INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 6,21 )
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 6, 22)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 6, 23)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 6, 24)

INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (7 , 25)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 7,26)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 7, 27)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 7, 28)

INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 8, 29)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES (8 , 30)
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 8,31 )
INSERT [dbo].[SentenceOfUnit] ([Id_Unit], [Id_Sentence]) VALUES ( 8,32 )






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
