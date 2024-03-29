USE [master]
GO
/****** Object:  Database [Assessment_DB]    Script Date: 05/02/2023 2:10:40 PM ******/
CREATE DATABASE [Assessment_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assessment_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Assessment_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assessment_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Assessment_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Assessment_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assessment_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assessment_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assessment_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assessment_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assessment_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assessment_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assessment_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assessment_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assessment_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assessment_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assessment_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assessment_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assessment_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assessment_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assessment_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assessment_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Assessment_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assessment_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assessment_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assessment_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assessment_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assessment_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assessment_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assessment_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assessment_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Assessment_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assessment_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assessment_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assessment_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assessment_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assessment_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Assessment_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [Assessment_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Assessment_DB]
GO
/****** Object:  Table [dbo].[Children]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Children](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[NoOfChildren] [int] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Age] [int] NOT NULL,
	[Photo] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Children] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[ParentID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailId] [varchar](100) NOT NULL,
	[Mobno] [varchar](20) NOT NULL,
	[EmiratesID] [varchar](max) NOT NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Children] ON 

INSERT [dbo].[Children] ([ID], [ParentID], [NoOfChildren], [FirstName], [LastName], [Gender], [Age], [Photo]) VALUES (2, 1, 2, N'kiki', N'err', N'Female', 6, N'dbdd5b8e-3e48-4438-b2b7-1f2119dee416_mm.jpg')
INSERT [dbo].[Children] ([ID], [ParentID], [NoOfChildren], [FirstName], [LastName], [Gender], [Age], [Photo]) VALUES (6, 1, 1, N'zuzu', N'zz', N'Male', 7, N'58c22c38-6357-4e08-8e98-2c3867103602_kk.jpg')
INSERT [dbo].[Children] ([ID], [ParentID], [NoOfChildren], [FirstName], [LastName], [Gender], [Age], [Photo]) VALUES (8, 6, 1, N'dashwin', N'sk', N'Male', 6, N'3180d0d9-299f-4996-9aa5-bd9fab29a738_mm.jpg')
INSERT [dbo].[Children] ([ID], [ParentID], [NoOfChildren], [FirstName], [LastName], [Gender], [Age], [Photo]) VALUES (9, 6, 2, N'lithika', N'sk', N'Female', 1, N'25e40397-bca5-4c71-b9ee-0348528e2aac_kk.jpg')
SET IDENTITY_INSERT [dbo].[Children] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([ParentID], [Username], [Password], [Gender], [FirstName], [LastName], [EmailId], [Mobno], [EmiratesID]) VALUES (1, N'priya', N'pd123', N'Female', N'Priyaddhar', N'Maaaaaa', N'priya@abc.co', N'123430909', N'12435rgdr233aa')
INSERT [dbo].[UserMaster] ([ParentID], [Username], [Password], [Gender], [FirstName], [LastName], [EmailId], [Mobno], [EmiratesID]) VALUES (3, N'test', N'test123', N'Female', N'test', N't', N'dfdsfddfgfg454546', N'123444444', N'fdgdfg2343')
INSERT [dbo].[UserMaster] ([ParentID], [Username], [Password], [Gender], [FirstName], [LastName], [EmailId], [Mobno], [EmiratesID]) VALUES (6, N'kalai', N'kalaiopp', N'Female', N'kalai', N'an', N'kk@ti.con', N'123555555', N'234566788')
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK_Children_UserMaster] FOREIGN KEY([ParentID])
REFERENCES [dbo].[UserMaster] ([ParentID])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK_Children_UserMaster]
GO
/****** Object:  StoredProcedure [dbo].[CreateChild]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[CreateChild]
@parentid int,
@noofchild  int,
@gender varchar(20),
@fname varchar(100),
@lname varchar(100),    
@age  int,
@photo varchar(max)=''
AS
BEGIN

	INSERT INTO  Children (ParentID,NoOfChildren,Gender,FirstName,LastName,Age,Photo)
				 VALUES (@parentid, @noofchild, @gender, @fname,@lname,@age,@photo)

END
GO
/****** Object:  StoredProcedure [dbo].[CreateUsers]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[CreateUsers]
@userName varchar(50),
@password   varchar(50),
@gender varchar(20),
@fname varchar(100),
@lname varchar(100),    
@emailid  varchar(50), 
@mobNo  varchar(20),
@emiratesId  varchar(50),
@id int output
AS
BEGIN
IF NOT EXISTS(SELECT TOP 1 1 FROM UserMaster where LOWER(Username)=LOWER(@userName))
BEGIN
	INSERT INTO  [UserMaster] (Username,Password,Gender,FirstName,LastName,EmailId,Mobno,EmiratesID)
				 VALUES (@userName, @password, @gender, @fname,@lname,@emailid,@mobNo,@emiratesId)
	SET @id=SCOPE_IDENTITY()
    RETURN  @id
END
ELSE
BEGIN 
SET @id=0
	RETURN @id

END
	
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteChild]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[DeleteChild]
@childid int
AS
BEGIN

IF EXISTS(SELECT TOP 1 1 FROM Children where ID=@childid)
BEGIN 
	DELETE FROM Children where ID=@childid
				
END


END
GO
/****** Object:  StoredProcedure [dbo].[EditChild]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[EditChild]
@childid int,
@parentid int,
@noofchild  int,
@gender varchar(20),
@fname varchar(100),
@lname varchar(100),    
@age  int,
@photo varchar(max)=''
AS
BEGIN

IF EXISTS(SELECT TOP 1 1 FROM Children where ID=@childid AND ParentID=@parentid)
BEGIN 
	Update Children set NoOfChildren=@noofchild,Gender=@gender,FirstName=@fname,LastName=@lname,Age=@age,Photo=@photo where ParentID=@parentid AND ID=@childid
				
END


END
GO
/****** Object:  StoredProcedure [dbo].[GetChildren]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[GetChildren]
@parentid int
AS
BEGIN

SELECT * from Children where ParentID=@parentid
	
END

GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[GetUser]
@userName varchar(50)
AS
BEGIN

SELECT ParentId,Username,Gender,FirstName,LastName,EmailId,Mobno,EmiratesID from UserMaster where Username=@userName
	
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[GetUserByID]
@id int
AS
BEGIN

SELECT ParentId,Username,Gender,FirstName,LastName,EmailId,Mobno,EmiratesID from UserMaster where ParentID=@id
	
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUsers]    Script Date: 05/02/2023 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[UpdateUsers]
@parentid int,
@userName varchar(50),
@fname varchar(100),
@lname varchar(100),    
@emailid  varchar(50), 
@mobNo  varchar(20),
@emiratesId  varchar(50),
@id int output
AS
BEGIN
IF EXISTS(SELECT TOP 1 1 FROM UserMaster where ParentID=@parentid)
BEGIN

UPDATE UserMaster SET FirstName=@fname,LastName=@lname,EmailId=@emailid,Mobno=@mobNo,EmiratesID=@emiratesId WHERE ParentID=@parentid
	SET @id=@parentid
    RETURN  @id
END
ELSE
BEGIN 
SET @id=0
	RETURN @id

END
	
END


GO
USE [master]
GO
ALTER DATABASE [Assessment_DB] SET  READ_WRITE 
GO
