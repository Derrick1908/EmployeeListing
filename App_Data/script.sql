USE [master]
GO
/****** Object:  Database [EmployeeDB]    Script Date: 28-09-2021 22:24:28 ******/
CREATE DATABASE [EmployeeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeDB] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeDB] SET QUERY_STORE = OFF
GO
USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[DEPARTMENT]    Script Date: 28-09-2021 22:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPARTMENT](
	[DEPARTMENTID] [int] IDENTITY(1,1) NOT NULL,
	[DEPARTMENTNAME] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DEPARTMENTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOBS]    Script Date: 28-09-2021 22:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOBS](
	[JOBID] [int] IDENTITY(1,1) NOT NULL,
	[JOBTITLE] [varchar](250) NOT NULL,
	[JOBDESCRIPTION] [varchar](max) NOT NULL,
	[LOCATIONID] [int] NOT NULL,
	[DEPARTMENTID] [int] NOT NULL,
	[CLOSINGDATE] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JOBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOCATION]    Script Date: 28-09-2021 22:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOCATION](
	[LOCATIONID] [int] IDENTITY(1,1) NOT NULL,
	[LOCATIONNAME] [varchar](250) NOT NULL,
	[LOCATIONCITY] [varchar](250) NOT NULL,
	[LOCATIONSTATE] [varchar](250) NOT NULL,
	[LOCATIONCOUNTRY] [varchar](250) NOT NULL,
	[LOCATIONZIP] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LOCATIONID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DEPARTMENT] ON 

INSERT [dbo].[DEPARTMENT] ([DEPARTMENTID], [DEPARTMENTNAME]) VALUES (5, N'Accounts')
INSERT [dbo].[DEPARTMENT] ([DEPARTMENTID], [DEPARTMENTNAME]) VALUES (3, N'HR')
INSERT [dbo].[DEPARTMENT] ([DEPARTMENTID], [DEPARTMENTNAME]) VALUES (2, N'Implementation')
INSERT [dbo].[DEPARTMENT] ([DEPARTMENTID], [DEPARTMENTNAME]) VALUES (4, N'Quality Assurance')
INSERT [dbo].[DEPARTMENT] ([DEPARTMENTID], [DEPARTMENTNAME]) VALUES (1, N'Software Development')
SET IDENTITY_INSERT [dbo].[DEPARTMENT] OFF
GO
SET IDENTITY_INSERT [dbo].[JOBS] ON 

INSERT [dbo].[JOBS] ([JOBID], [JOBTITLE], [JOBDESCRIPTION], [LOCATIONID], [DEPARTMENTID], [CLOSINGDATE]) VALUES (1, N'Software Developer', N'DEBUGGING EXISTING SYSTEMS & DESIGNING NEW CODE', 1, 1, CAST(N'2021-08-30T06:43:31.000' AS DateTime))
INSERT [dbo].[JOBS] ([JOBID], [JOBTITLE], [JOBDESCRIPTION], [LOCATIONID], [DEPARTMENTID], [CLOSINGDATE]) VALUES (2, N'Software Tester', N'TESTING REGRESSION AS WELL AS QA DEFFECTS. FOLLOWING INDUSTRY STANDARDS WHILE MAINTAINING QUALITY', 3, 4, CAST(N'2021-10-31T20:43:31.877' AS DateTime))
SET IDENTITY_INSERT [dbo].[JOBS] OFF
GO
SET IDENTITY_INSERT [dbo].[LOCATION] ON 

INSERT [dbo].[LOCATION] ([LOCATIONID], [LOCATIONNAME], [LOCATIONCITY], [LOCATIONSTATE], [LOCATIONCOUNTRY], [LOCATIONZIP]) VALUES (1, N'US Head Office', N'Baltimore', N'MD', N'United States', 21202)
INSERT [dbo].[LOCATION] ([LOCATIONID], [LOCATIONNAME], [LOCATIONCITY], [LOCATIONSTATE], [LOCATIONCOUNTRY], [LOCATIONZIP]) VALUES (2, N'India Head Office', N'Bangalore', N'Karnataka', N'India', 530068)
INSERT [dbo].[LOCATION] ([LOCATIONID], [LOCATIONNAME], [LOCATIONCITY], [LOCATIONSTATE], [LOCATIONCOUNTRY], [LOCATIONZIP]) VALUES (3, N'Regional Head Office', N'Panjim', N'Goa', N'India', 403001)
INSERT [dbo].[LOCATION] ([LOCATIONID], [LOCATIONNAME], [LOCATIONCITY], [LOCATIONSTATE], [LOCATIONCOUNTRY], [LOCATIONZIP]) VALUES (4, N'AUS Head Office', N'Adelaide', N'SA', N'Australia', 5001)
SET IDENTITY_INSERT [dbo].[LOCATION] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__DEPARTME__36A571F8C75A7456]    Script Date: 28-09-2021 22:24:29 ******/
ALTER TABLE [dbo].[DEPARTMENT] ADD UNIQUE NONCLUSTERED 
(
	[DEPARTMENTNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JOBS]  WITH CHECK ADD FOREIGN KEY([DEPARTMENTID])
REFERENCES [dbo].[DEPARTMENT] ([DEPARTMENTID])
GO
ALTER TABLE [dbo].[JOBS]  WITH CHECK ADD FOREIGN KEY([LOCATIONID])
REFERENCES [dbo].[LOCATION] ([LOCATIONID])
GO
USE [master]
GO
ALTER DATABASE [EmployeeDB] SET  READ_WRITE 
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 29-09-2021 10:04:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[USERID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](20) NOT NULL,
	[USERPASSWORD] [varchar](50) NOT NULL,
	[USERROLE] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 
GO
INSERT [dbo].[USERS] ([USERID], [USERNAME], [USERPASSWORD], [USERROLE]) VALUES (1, N'DERRICK', N'123456', N'SuperAdmin')
GO
INSERT [dbo].[USERS] ([USERID], [USERNAME], [USERPASSWORD], [USERROLE]) VALUES (2, N'BRYAN', N'abc123', N'User')
GO
INSERT [dbo].[USERS] ([USERID], [USERNAME], [USERPASSWORD], [USERROLE]) VALUES (3, N'MARK', N'123abc123', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO