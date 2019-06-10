USE [master]
GO
/****** Object:  Database [LibrarySystem]    Script Date: 27/05/2019 12:51:54 ******/
CREATE DATABASE [LibrarySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibrarySystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.FURKAN\MSSQL\DATA\LibrarySystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibrarySystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.FURKAN\MSSQL\DATA\LibrarySystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibrarySystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibrarySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibrarySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibrarySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibrarySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibrarySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibrarySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibrarySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECOVERY FULL 
GO
ALTER DATABASE [LibrarySystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibrarySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibrarySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibrarySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibrarySystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibrarySystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibrarySystem', N'ON'
GO
ALTER DATABASE [LibrarySystem] SET QUERY_STORE = OFF
GO
USE [LibrarySystem]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [LibrarySystem]
GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 27/05/2019 12:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[authorizationID] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[authorizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 27/05/2019 12:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[bookID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[writer] [nvarchar](50) NULL,
	[publisher] [nvarchar](50) NULL,
	[numberOfPages] [int] NULL,
	[statusID] [int] NULL,
	[categoryID] [int] NULL,
	[imageName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[bookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 27/05/2019 12:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 27/05/2019 12:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[loanID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[bookID] [int] NULL,
	[dateIssue] [date] NULL,
	[dateReturn] [date] NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[loanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserve]    Script Date: 27/05/2019 12:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserve](
	[reserveID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[bookID] [int] NULL,
 CONSTRAINT [PK_Reserve] PRIMARY KEY CLUSTERED 
(
	[reserveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 27/05/2019 12:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[statusID] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[statusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/05/2019 12:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[surname] [nvarchar](50) NULL,
	[phoneNumber] [nvarchar](11) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[authorizationID] [int] NULL,
	[imageName] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Authorization] ([authorizationID], [name]) VALUES (1, N'ADMİN')
INSERT [dbo].[Authorization] ([authorizationID], [name]) VALUES (2, N'ÜYE')
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (1, N'YENİDEN DOĞUŞ', N'ANONİM', N'GÜNEŞ YAYINEVİ', 129, 1, 1, N'default.jpg')
INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (2, N'DEĞİŞİM', N'JOSEPH MURPHY', N'WORLD WIDE', 123, 2, 2, N'default.jpg')
INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (3, N'İNEK', N'HAKAN SAHAN', N'KÖY ', 123, 3, 1, N'default.jpg')
INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (4, N'İSİMSİZLER', N'ANONİM', N'İSİMSİZİZ', 123, 1, 1, N'default.jpg')
INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (5, N'İŞTE BU ', N'HAMDİ KOÇ', N'KLASİK', 123, 1, 1, N'default.jpg')
INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (6, N'SON', N'SONAT YAR', N'SONSUZLUK', 123, 1, 2, N'8d0612d7-1bd6-43c6-8b49-050c701e87ca.png')
INSERT [dbo].[Book] ([bookID], [name], [writer], [publisher], [numberOfPages], [statusID], [categoryID], [imageName]) VALUES (7, N'DENEME', N'DENEME', N'DENEME', 123, 1, 1, N'default.jpg')
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([categoryID], [name]) VALUES (1, N'MACERA')
INSERT [dbo].[Category] ([categoryID], [name]) VALUES (2, N'AKSİYON')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Loan] ON 

INSERT [dbo].[Loan] ([loanID], [userID], [bookID], [dateIssue], [dateReturn]) VALUES (13, 7, 2, CAST(N'2018-10-10' AS Date), CAST(N'2019-05-11' AS Date))
INSERT [dbo].[Loan] ([loanID], [userID], [bookID], [dateIssue], [dateReturn]) VALUES (14, 3, 2, CAST(N'2019-05-11' AS Date), CAST(N'2019-10-10' AS Date))
INSERT [dbo].[Loan] ([loanID], [userID], [bookID], [dateIssue], [dateReturn]) VALUES (15, 2, 1, CAST(N'2019-05-11' AS Date), CAST(N'2019-05-12' AS Date))
INSERT [dbo].[Loan] ([loanID], [userID], [bookID], [dateIssue], [dateReturn]) VALUES (17, 7, 5, CAST(N'2019-05-13' AS Date), CAST(N'2019-05-13' AS Date))
INSERT [dbo].[Loan] ([loanID], [userID], [bookID], [dateIssue], [dateReturn]) VALUES (19, 2, 3, CAST(N'2019-05-13' AS Date), NULL)
INSERT [dbo].[Loan] ([loanID], [userID], [bookID], [dateIssue], [dateReturn]) VALUES (21, 3, 2, CAST(N'2019-05-16' AS Date), CAST(N'2019-05-17' AS Date))
SET IDENTITY_INSERT [dbo].[Loan] OFF
SET IDENTITY_INSERT [dbo].[Reserve] ON 

INSERT [dbo].[Reserve] ([reserveID], [userID], [bookID]) VALUES (67, 3, 2)
SET IDENTITY_INSERT [dbo].[Reserve] OFF
INSERT [dbo].[Status] ([statusID], [name]) VALUES (1, N'UYGUN')
INSERT [dbo].[Status] ([statusID], [name]) VALUES (2, N'REZERVE EDİLMİŞ')
INSERT [dbo].[Status] ([statusID], [name]) VALUES (3, N'ÖDÜNÇ VERİLMİŞ')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([userID], [name], [surname], [phoneNumber], [email], [password], [authorizationID], [imageName]) VALUES (1, N'FURKAN', N'AKTAŞ', N'55555555555', N'FURKAN@GMAİL.COM', N'12345', 1, N'default.jpg')
INSERT [dbo].[User] ([userID], [name], [surname], [phoneNumber], [email], [password], [authorizationID], [imageName]) VALUES (2, N'YASİN', N'AKPINAR', N'55555555555', N'YASİN@GMAİL.COM', N'12345', 1, N'default.jpg')
INSERT [dbo].[User] ([userID], [name], [surname], [phoneNumber], [email], [password], [authorizationID], [imageName]) VALUES (3, N'EREN', N'FİDAN', N'55555555555', N'EREN@GMAİL.COM', N'12345', 2, N'default.jpg')
INSERT [dbo].[User] ([userID], [name], [surname], [phoneNumber], [email], [password], [authorizationID], [imageName]) VALUES (7, N'YUSUF', N'ORUÇ', N'55555555555', N'YUSUF@GMAIL.COM', N'12345', 1, N'c269f5c4-ab38-4424-92a0-8b83a82384cc.png')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([categoryID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Status] FOREIGN KEY([statusID])
REFERENCES [dbo].[Status] ([statusID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Status]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Book] FOREIGN KEY([bookID])
REFERENCES [dbo].[Book] ([bookID])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Book]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_User]
GO
ALTER TABLE [dbo].[Reserve]  WITH CHECK ADD  CONSTRAINT [FK_Reserve_Book] FOREIGN KEY([bookID])
REFERENCES [dbo].[Book] ([bookID])
GO
ALTER TABLE [dbo].[Reserve] CHECK CONSTRAINT [FK_Reserve_Book]
GO
ALTER TABLE [dbo].[Reserve]  WITH CHECK ADD  CONSTRAINT [FK_Reserve_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO
ALTER TABLE [dbo].[Reserve] CHECK CONSTRAINT [FK_Reserve_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Authorization] FOREIGN KEY([authorizationID])
REFERENCES [dbo].[Authorization] ([authorizationID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Authorization]
GO
USE [master]
GO
ALTER DATABASE [LibrarySystem] SET  READ_WRITE 
GO
