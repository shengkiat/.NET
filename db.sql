USE [master]
GO
/****** Object:  Database [CLMSDB]    Script Date: 6/11/2016 12:21:21 PM ******/
CREATE DATABASE [CLMSDB] ON  PRIMARY 
( NAME = N'.NET', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\.NET.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'.NET_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\.NET_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CLMSDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CLMSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CLMSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CLMSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CLMSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CLMSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CLMSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CLMSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CLMSDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CLMSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CLMSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CLMSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CLMSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CLMSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CLMSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CLMSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CLMSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CLMSDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CLMSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CLMSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CLMSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CLMSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CLMSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CLMSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CLMSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CLMSDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CLMSDB] SET  MULTI_USER 
GO
ALTER DATABASE [CLMSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CLMSDB] SET DB_CHAINING OFF 
GO
USE [CLMSDB]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] NOT NULL,
	[BranchName] [nvarchar](50) NULL,
	[BranchAddress] [nvarchar](200) NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Copy]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copy](
	[AccessionNo] [int] NOT NULL,
	[CopyNo] [int] NULL,
	[ShelfLocation] [nvarchar](50) NULL,
	[Status] [nvarchar](10) NULL,
	[Notes] [ntext] NULL,
	[BranchID] [int] NULL,
	[MaterialID] [int] NULL,
 CONSTRAINT [PK_Copy] PRIMARY KEY CLUSTERED 
(
	[AccessionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loan]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[TransactionNo] [int] NOT NULL,
	[MemberID] [int] NULL,
	[AccessionNo] [int] NULL,
	[DateBorrowed] [datetime] NULL,
	[DateDue] [datetime] NULL,
	[DateReturned] [datetime] NULL,
	[Remarks] [ntext] NULL,
	[Status] [nvarchar](10) NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[TransactionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Material]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[MaterialID] [int] NOT NULL,
	[MaterialType] [nvarchar](1) NULL,
	[Title] [nvarchar](50) NULL,
	[Authors] [nvarchar](50) NULL,
	[Publisher] [nvarchar](50) NULL,
	[CopiesInShelf] [int] NULL,
	[ISBN] [nvarchar](50) NULL,
	[NoOfPages] [int] NULL,
	[DurationMinutes] [int] NULL,
	[IssueNo] [int] NULL,
	[IssueDate] [datetime] NULL,
	[Volume] [nvarchar](50) NULL,
	[Edition] [nvarchar](50) NULL,
	[LoanDuration] [int] NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] NOT NULL,
	[NRIC] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nchar](50) NULL,
	[ExpiryDate] [datetime] NULL,
	[MemberTypeID] [int] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberType]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberType](
	[MemberTypeID] [int] NOT NULL,
	[TotalLimit] [int] NULL,
	[AVLimit] [int] NULL,
 CONSTRAINT [PK_MemberType] PRIMARY KEY CLUSTERED 
(
	[MemberTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 6/11/2016 12:21:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] NOT NULL,
	[ReserveDate] [datetime] NULL,
	[MaterialID] [int] NULL,
	[CollectionBranch] [int] NULL,
	[Status] [nvarchar](10) NULL,
	[Remarks] [ntext] NULL,
	[BookingReference] [nvarchar](50) NULL,
	[MemberID] [int] NOT NULL,
	[AccessionNo] [int] NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK_Copy_Branch]
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([MaterialID])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK_Copy_Material]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Copy] FOREIGN KEY([AccessionNo])
REFERENCES [dbo].[Copy] ([AccessionNo])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Copy]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Member]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_MemberType] FOREIGN KEY([MemberTypeID])
REFERENCES [dbo].[MemberType] ([MemberTypeID])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_MemberType]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Branch] FOREIGN KEY([CollectionBranch])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Branch]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Copy] FOREIGN KEY([AccessionNo])
REFERENCES [dbo].[Copy] ([AccessionNo])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Copy]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Material] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Material] ([MaterialID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Material]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Member]
GO
USE [master]
GO
ALTER DATABASE [CLMSDB] SET  READ_WRITE 
GO
