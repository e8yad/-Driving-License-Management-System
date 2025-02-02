USE [master]
GO
/****** Object:  Database [DVLD]    Script Date: 7/11/2024 2:00:30 AM ******/
CREATE DATABASE [DVLD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyDVLD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyDVLD.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyDVLD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyDVLD_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DVLD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DVLD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DVLD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DVLD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DVLD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DVLD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DVLD] SET ARITHABORT OFF 
GO
ALTER DATABASE [DVLD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DVLD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DVLD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DVLD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DVLD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DVLD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DVLD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DVLD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DVLD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DVLD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DVLD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DVLD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DVLD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DVLD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DVLD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DVLD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DVLD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DVLD] SET RECOVERY FULL 
GO
ALTER DATABASE [DVLD] SET  MULTI_USER 
GO
ALTER DATABASE [DVLD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DVLD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DVLD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DVLD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DVLD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DVLD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DVLD', N'ON'
GO
ALTER DATABASE [DVLD] SET QUERY_STORE = ON
GO
ALTER DATABASE [DVLD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DVLD]
GO
/****** Object:  UserDefinedFunction [dbo].[GetQUizGradeFromQuetions]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[GetQUizGradeFromQuetions](@QuizID int)
returns int
as
begin 
return (select SUM(Points) from Quetions where QuizID=@QuizID)
end
GO
/****** Object:  Table [dbo].[LocalDrivingLicenseClasses]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalDrivingLicenseClasses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[MinimumAge] [smallint] NOT NULL,
	[Validity] [smallint] NOT NULL,
	[Fees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_LocalDrivingLicenseClasses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[statuses]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_statuses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [bigint] IDENTITY(1,1) NOT NULL,
	[NationalID] [bigint] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[SecondName] [nvarchar](10) NOT NULL,
	[ThirdName] [nvarchar](10) NOT NULL,
	[LastName] [nvarchar](10) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Email] [varchar](25) NULL,
	[ImagePath] [varchar](80) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FullName] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC,
	[SecondName] ASC,
	[ThirdName] ASC,
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_NationalID] UNIQUE NONCLUSTERED 
(
	[NationalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalLicenseApplications]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalLicenseApplications](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [bigint] NOT NULL,
	[ClassID] [int] NOT NULL,
	[TestsPassed] [tinyint] NULL,
 CONSTRAINT [PK_LocalLicensesApplications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationTypes]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Fees] [smallmoney] NOT NULL,
 CONSTRAINT [PK__Applicat__3214EC275D97A66B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationID] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonID] [bigint] NOT NULL,
	[ApplicationTypeID] [int] NOT NULL,
	[CreationDate] [date] NOT NULL,
	[StatusID] [int] NOT NULL,
	[TotalFees] [smallmoney] NOT NULL,
	[PaymentID] [int] NULL,
	[UserID] [bigint] NOT NULL,
 CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ManageLocalDrivingLicenseApplications]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ManageLocalDrivingLicenseApplications]
AS
SELECT        dbo.LocalLicenseApplications.ID AS LDLApplicationID, dbo.Persons.NationalID, dbo.ApplicationTypes.Title, dbo.Applications.CreationDate, dbo.statuses.Name AS Status, dbo.Applications.TotalFees, 
                         dbo.LocalDrivingLicenseClasses.ClassName AS Class, dbo.Applications.UserID, dbo.LocalLicenseApplications.TestsPassed
FROM            dbo.Applications INNER JOIN
                         dbo.statuses ON dbo.Applications.StatusID = dbo.statuses.ID INNER JOIN
                         dbo.ApplicationTypes ON dbo.Applications.ApplicationTypeID = dbo.ApplicationTypes.ID INNER JOIN
                         dbo.Persons ON dbo.Applications.PersonID = dbo.Persons.PersonID INNER JOIN
                         dbo.LocalLicenseApplications ON dbo.LocalLicenseApplications.ApplicationID = dbo.Applications.ApplicationID INNER JOIN
                         dbo.LocalDrivingLicenseClasses ON dbo.LocalLicenseApplications.ClassID = dbo.LocalDrivingLicenseClasses.ID
GO
/****** Object:  View [dbo].[LocalDrvingLicenseCheck]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LocalDrvingLicenseCheck]
AS
SELECT        dbo.Applications.PersonID, dbo.Applications.StatusID, dbo.LocalLicenseApplications.ClassID, dbo.Applications.ApplicationTypeID
FROM            dbo.Applications INNER JOIN
                         dbo.LocalLicenseApplications ON dbo.LocalLicenseApplications.ApplicationID = dbo.Applications.ApplicationID
GO
/****** Object:  Table [dbo].[DetainedLicenses]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetainedLicenses](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LicenseNumber] [bigint] NOT NULL,
	[Fines] [smallmoney] NOT NULL,
	[DetainedDate] [date] NOT NULL,
	[DetainedReason] [nvarchar](3000) NULL,
	[ReleaseDate] [date] NULL,
	[IsDetained] [bit] NOT NULL,
	[ReleaseDetainedAppID] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalDrivingLicenses]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalDrivingLicenses](
	[LicenseNumber] [bigint] IDENTITY(1,1) NOT NULL,
	[LDLA] [bigint] NOT NULL,
	[IssueDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[Fees] [smallmoney] NOT NULL,
	[PaymentID] [bigint] NULL,
	[Notes] [nvarchar](3000) NULL,
	[StatusID] [int] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[ClassID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDetained] [bit] NOT NULL,
	[DriverID] [bigint] NOT NULL,
 CONSTRAINT [PK_LocalDrivingLicenses] PRIMARY KEY CLUSTERED 
(
	[LicenseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ManageDetainedLicenses]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ManageDetainedLicenses]
AS
SELECT   dbo.DetainedLicenses.ID, dbo.DetainedLicenses.LicenseNumber, dbo.DetainedLicenses.Fines, dbo.DetainedLicenses.DetainedDate, dbo.DetainedLicenses.DetainedReason, 
                         dbo.DetainedLicenses.ReleaseDate, dbo.DetainedLicenses.IsDetained, dbo.LocalDrivingLicenses.ClassID
FROM         dbo.DetainedLicenses INNER JOIN
                         dbo.LocalDrivingLicenses ON dbo.DetainedLicenses.LicenseNumber = dbo.LocalDrivingLicenses.LicenseNumber
GO
/****** Object:  Table [dbo].[choices]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[choices](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[QuetionID] [bigint] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[IsCorrectChoice] [bit] NOT NULL,
 CONSTRAINT [PK_choices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[DriverID] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonID] [bigint] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[DriverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamLogs]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamLogs](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PerosonID] [bigint] NOT NULL,
	[QuizID] [int] NOT NULL,
	[Grade] [tinyint] NOT NULL,
	[ExameDate&Time] [datetime] NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[TestID] [bigint] NOT NULL,
 CONSTRAINT [PK_ExamLogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InternationalDrivingLicenses]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternationalDrivingLicenses](
	[IntLicenseNumber] [bigint] IDENTITY(1,1) NOT NULL,
	[LocalLicenseNumber] [bigint] NOT NULL,
	[ApplicationID] [bigint] NOT NULL,
	[IssueDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_InternationalDrivingLicense] PRIMARY KEY CLUSTERED 
(
	[IntLicenseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseStatus]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatuesName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LicenseStatues] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quetions]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quetions](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](3000) NULL,
	[QuestionImage] [nvarchar](50) NULL,
	[QuizID] [int] NOT NULL,
	[Points] [tinyint] NOT NULL,
 CONSTRAINT [PK_Quetions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizes]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Grade] [smallint] NULL,
	[CreatedDate] [date] NOT NULL,
	[IsRand] [bit] NOT NULL,
 CONSTRAINT [PK_Quizes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[TestID] [bigint] IDENTITY(1,1) NOT NULL,
	[TestTypeID] [int] NOT NULL,
	[TestDate] [date] NOT NULL,
	[Result] [bit] NULL,
	[isLocked] [bit] NOT NULL,
	[LocalDrivingLicenseApplicationID] [bigint] NOT NULL,
	[Notes] [nvarchar](3350) NULL,
	[PaymentID] [bigint] NULL,
	[PersonID] [bigint] NULL,
	[UserID] [bigint] NOT NULL,
	[Fees] [smallmoney] NOT NULL,
	[RetakeTestApplicationID] [bigint] NULL,
 CONSTRAINT [PK_Testes] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Fees] [money] NOT NULL,
 CONSTRAINT [PK__TestType__3214EC2717EE40EC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](15) NOT NULL,
	[Password] [char](64) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Permissions] [int] NULL,
	[PersonID] [bigint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UserName_Unique] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetainedLicenses]    Script Date: 7/11/2024 2:00:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_DetainedLicenses] ON [dbo].[DetainedLicenses]
(
	[LicenseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NationalID]    Script Date: 7/11/2024 2:00:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_NationalID] ON [dbo].[Persons]
(
	[NationalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Testes]    Script Date: 7/11/2024 2:00:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_Testes] ON [dbo].[Tests]
(
	[LocalDrivingLicenseApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD  CONSTRAINT [DF_Applications_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[choices] ADD  CONSTRAINT [DF_choices_IsCorrectChoice]  DEFAULT ((0)) FOR [IsCorrectChoice]
GO
ALTER TABLE [dbo].[LocalLicenseApplications] ADD  CONSTRAINT [DF_LocalLicenseApplications_TestesBased]  DEFAULT ((0)) FOR [TestsPassed]
GO
ALTER TABLE [dbo].[Quizes] ADD  CONSTRAINT [DF_Quizes_IsRand]  DEFAULT ((1)) FOR [IsRand]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_ApplicationTypes] FOREIGN KEY([ApplicationTypeID])
REFERENCES [dbo].[ApplicationTypes] ([ID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_ApplicationTypes]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_Persons]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_statuses] FOREIGN KEY([StatusID])
REFERENCES [dbo].[statuses] ([ID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_statuses]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_Users]
GO
ALTER TABLE [dbo].[choices]  WITH CHECK ADD  CONSTRAINT [FK_choices_Quetions] FOREIGN KEY([QuetionID])
REFERENCES [dbo].[Quetions] ([ID])
GO
ALTER TABLE [dbo].[choices] CHECK CONSTRAINT [FK_choices_Quetions]
GO
ALTER TABLE [dbo].[DetainedLicenses]  WITH CHECK ADD  CONSTRAINT [FK_DetainedLicenses_Applications] FOREIGN KEY([ReleaseDetainedAppID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[DetainedLicenses] CHECK CONSTRAINT [FK_DetainedLicenses_Applications]
GO
ALTER TABLE [dbo].[DetainedLicenses]  WITH CHECK ADD  CONSTRAINT [FK_DetainedLicenses_LocalDrivingLicenses] FOREIGN KEY([LicenseNumber])
REFERENCES [dbo].[LocalDrivingLicenses] ([LicenseNumber])
GO
ALTER TABLE [dbo].[DetainedLicenses] CHECK CONSTRAINT [FK_DetainedLicenses_LocalDrivingLicenses]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [FK_Drivers_Persons]
GO
ALTER TABLE [dbo].[ExamLogs]  WITH CHECK ADD  CONSTRAINT [FK_ExamLogs_Persons] FOREIGN KEY([PerosonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[ExamLogs] CHECK CONSTRAINT [FK_ExamLogs_Persons]
GO
ALTER TABLE [dbo].[ExamLogs]  WITH CHECK ADD  CONSTRAINT [FK_ExamLogs_Quizes] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quizes] ([ID])
GO
ALTER TABLE [dbo].[ExamLogs] CHECK CONSTRAINT [FK_ExamLogs_Quizes]
GO
ALTER TABLE [dbo].[ExamLogs]  WITH CHECK ADD  CONSTRAINT [FK_ExamLogs_Tests] FOREIGN KEY([TestID])
REFERENCES [dbo].[Tests] ([TestID])
GO
ALTER TABLE [dbo].[ExamLogs] CHECK CONSTRAINT [FK_ExamLogs_Tests]
GO
ALTER TABLE [dbo].[InternationalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_InternationalDrivingLicenses_Applications] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[InternationalDrivingLicenses] CHECK CONSTRAINT [FK_InternationalDrivingLicenses_Applications]
GO
ALTER TABLE [dbo].[InternationalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_InternationalDrivingLicenses_LocalDrivingLicenses] FOREIGN KEY([LocalLicenseNumber])
REFERENCES [dbo].[LocalDrivingLicenses] ([LicenseNumber])
GO
ALTER TABLE [dbo].[InternationalDrivingLicenses] CHECK CONSTRAINT [FK_InternationalDrivingLicenses_LocalDrivingLicenses]
GO
ALTER TABLE [dbo].[LocalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenses_Drivers] FOREIGN KEY([DriverID])
REFERENCES [dbo].[Drivers] ([DriverID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenses] CHECK CONSTRAINT [FK_LocalDrivingLicenses_Drivers]
GO
ALTER TABLE [dbo].[LocalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenses_LicenseStatues] FOREIGN KEY([StatusID])
REFERENCES [dbo].[LicenseStatus] ([StatusID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenses] CHECK CONSTRAINT [FK_LocalDrivingLicenses_LicenseStatues]
GO
ALTER TABLE [dbo].[LocalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenses_LocalDrivingLicenseClasses] FOREIGN KEY([ClassID])
REFERENCES [dbo].[LocalDrivingLicenseClasses] ([ID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenses] CHECK CONSTRAINT [FK_LocalDrivingLicenses_LocalDrivingLicenseClasses]
GO
ALTER TABLE [dbo].[LocalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenses_LocalLicenseApplications] FOREIGN KEY([LDLA])
REFERENCES [dbo].[LocalLicenseApplications] ([ID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenses] CHECK CONSTRAINT [FK_LocalDrivingLicenses_LocalLicenseApplications]
GO
ALTER TABLE [dbo].[LocalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenses_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[LocalDrivingLicenses] CHECK CONSTRAINT [FK_LocalDrivingLicenses_Users]
GO
ALTER TABLE [dbo].[LocalLicenseApplications]  WITH CHECK ADD  CONSTRAINT [FK_LocalLicenseApplications_Applications] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[LocalLicenseApplications] CHECK CONSTRAINT [FK_LocalLicenseApplications_Applications]
GO
ALTER TABLE [dbo].[LocalLicenseApplications]  WITH CHECK ADD  CONSTRAINT [FK_LocalLicensesApplications_LocalDrivingLicenseClasses] FOREIGN KEY([ClassID])
REFERENCES [dbo].[LocalDrivingLicenseClasses] ([ID])
GO
ALTER TABLE [dbo].[LocalLicenseApplications] CHECK CONSTRAINT [FK_LocalLicensesApplications_LocalDrivingLicenseClasses]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Countries]
GO
ALTER TABLE [dbo].[Quetions]  WITH CHECK ADD  CONSTRAINT [FK_Quetions_Quizes] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quizes] ([ID])
GO
ALTER TABLE [dbo].[Quetions] CHECK CONSTRAINT [FK_Quetions_Quizes]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Testes_LocalLicenseApplications] FOREIGN KEY([LocalDrivingLicenseApplicationID])
REFERENCES [dbo].[LocalLicenseApplications] ([ID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Testes_LocalLicenseApplications]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Testes_TestTypes] FOREIGN KEY([TestTypeID])
REFERENCES [dbo].[TestTypes] ([ID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Testes_TestTypes]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Applications] FOREIGN KEY([RetakeTestApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_Applications]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_Persons]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UserPerson] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UserPerson]
GO
ALTER TABLE [dbo].[LocalDrivingLicenses]  WITH CHECK ADD  CONSTRAINT [CK_LocalDrivingLicenses] CHECK  (([ExpirationDate]>[IssueDate]))
GO
ALTER TABLE [dbo].[LocalDrivingLicenses] CHECK CONSTRAINT [CK_LocalDrivingLicenses]
GO
ALTER TABLE [dbo].[LocalLicenseApplications]  WITH CHECK ADD  CONSTRAINT [CK_LocalLicenseApplications] CHECK  (([TestsPassed]>=(0) AND [TestsPassed]<=(3)))
GO
ALTER TABLE [dbo].[LocalLicenseApplications] CHECK CONSTRAINT [CK_LocalLicenseApplications]
GO
/****** Object:  StoredProcedure [dbo].[AddExamLog]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddExamLog]
@PersonID Bigint,
@QuizID int,
@Grade TinyInt,
@ExameDate_Time Datetime,
@EndTime Datetime,
@TestID BigInt,
@newRecordId Bigint output
As
begin
	insert into ExamLogs(PerosonID,QuizID,Grade,[ExameDate&Time],EndTime,TestID)
	values(@PersonID,@QuizID,@Grade,@ExameDate_Time,@EndTime,@TestID);
	set @newRecordId=SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetChoicesByQuetionID]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_GetChoicesByQuetionID]
@QuetionID bigint
as 
begin
select choices.Description As DES,choices.IsCorrectChoice AS IsCorrect from choices
where choices.QuetionID=@QuetionID
order by NEWID();
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetExamlog]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetExamlog]
as
begin
select * from ExamLogs
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetQuizQutionsByQuizID]    Script Date: 7/11/2024 2:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_GetQuizQutionsByQuizID]
@QuizID int 
as 
begin
	declare @IsRand bit;
	select @IsRand=Quizes.IsRand  from Quizes where Quizes.ID=@QuizID ;
	if (@IsRand=1)
	begin
		select Quetions.ID,Quetions.Description,Quetions.QuestionImage,Quetions.Points
		from Quetions where Quetions.QuizID=@QuizID order by NEWID();
	end
	else
	begin
		select Quetions.ID,Quetions.Description,Quetions.QuestionImage,Quetions.Points
			from Quetions where Quetions.QuizID=@QuizID
	end
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Applications"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 183
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LocalLicenseApplications"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 119
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LocalDrvingLicenseCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LocalDrvingLicenseCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DetainedLicenses"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "LocalDrivingLicenses"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 136
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 9
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ManageDetainedLicenses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ManageDetainedLicenses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "statuses"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 102
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApplicationTypes"
            Begin Extent = 
               Top = 181
               Left = 302
               Bottom = 294
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Persons"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 324
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LocalLicenseApplications"
            Begin Extent = 
               Top = 151
               Left = 635
               Bottom = 308
               Right = 805
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Applications"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LocalDrivingLicenseClasses"
            Begin Extent = 
               Top = 6
               Left = 470
               Bottom = 211
               Right = 640
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ManageLocalDrivingLicenseApplications'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ManageLocalDrivingLicenseApplications'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ManageLocalDrivingLicenseApplications'
GO
USE [master]
GO
ALTER DATABASE [DVLD] SET  READ_WRITE 
GO
