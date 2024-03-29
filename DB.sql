USE [master]
GO
/****** Object:  Database [Student]    Script Date: 16.01.2023 13:32:26 ******/
CREATE DATABASE [Student]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Student', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Student.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Student_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Student_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Student] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Student].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Student] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Student] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Student] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Student] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Student] SET ARITHABORT OFF 
GO
ALTER DATABASE [Student] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Student] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Student] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Student] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Student] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Student] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Student] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Student] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Student] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Student] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Student] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Student] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Student] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Student] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Student] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Student] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Student] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Student] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Student] SET  MULTI_USER 
GO
ALTER DATABASE [Student] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Student] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Student] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Student] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Student] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Student] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Student] SET QUERY_STORE = OFF
GO
USE [Student]
GO
/****** Object:  Table [dbo].[Finals]    Script Date: 16.01.2023 13:32:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Finals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [nvarchar](5) NOT NULL,
	[FullName] [nvarchar](60) NOT NULL,
	[Gender] [nvarchar](7) NOT NULL,
	[MaritalStatus] [nvarchar](50) NULL,
	[Exam1] [int] NULL,
	[Exam2] [int] NULL,
	[Exam3] [int] NULL,
	[Exam4] [int] NULL,
	[Exam5] [int] NULL,
 CONSTRAINT [PK_Finals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 16.01.2023 13:32:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16.01.2023 13:32:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserSurname] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[UserPatronymic] [nvarchar](20) NOT NULL,
	[UserLogin] [nvarchar](20) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Finals] ON 

INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (1, N'ВТ-11', N'Иванов Иван Иванович', N'Мужской', N'Замужем/женат', 2, 3, 3, 4, 3)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (2, N'ВТ-13', N'Александр Сергеевич Пушкин', N'Мужской', N'Замужем/женат', 5, 5, 4, 3, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (3, N'ВТ-13', N'Фамилия Имя Отчество', N'Женский', N'Не замужем/холост', 5, 5, 5, 5, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (4, N'ВТ-12', N'Ульянова Каролина Николаевна', N'Женский', N'Не замужем/холост', 5, 5, 5, 5, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (5, N'ВТ-13', N'Семенова Александра Марковна', N'Женский', N'Замужем/женат', 4, 4, 3, 5, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (6, N'ВТ-12', N'Карпов Александр Егорович', N'Мужской', N'Замужем/женат', 3, 4, 4, 3, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (7, N'ВТ-11', N'Копылов Дмитрий Фёдорович', N'Женский', N'Не замужем/холост', 4, 3, 4, 4, 4)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (8, N'ВТ-11', N'Толкачева Амина Всеволодовна', N'Женский', N'Замужем/женат', 5, 5, 4, 5, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (9, N'ВТ-11', N'Федоров Максим Александрович', N'Мужской', N'Не замужем/холост', 4, NULL, 4, 5, NULL)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (10, N'ВТ-12', N'Архипов Александр Маркович', N'Мужской', N'Не замужем/холост', 4, 4, 3, NULL, NULL)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (11, N'ВТ-11', N'Копылова Светлана Львовна', N'Женский', N'Не замужем/холост', 5, 5, 5, 4, 4)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (12, N'ВТ-11', N'Андреева Светлана Арсентьевна', N'Женский', N'Замужем/женат', 3, 4, 4, NULL, NULL)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (13, N'ВТ-12', N'Рожкова Светлана Львовна', N'Женский', N'Не замужем/холост', 4, 4, 4, 4, 4)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (14, N'ВТ-13', N'Сомов Александр Максимович', N'Мужской', N'Не замужем/холост', 3, 3, 3, 3, 3)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (15, N'ВТ-11', N'Лапшин Леон Евгеньевич', N'Мужской', N'Не замужем/холост', 4, 4, 5, 4, 5)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (16, N'ВТ-12', N'Михеев Марк Дмитриевич', N'Мужской', N'Не замужем/холост', 3, 4, 4, 5, 4)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (17, N'ВТ-13', N'Попова Вера Дамировна', N'Женский', N'Не замужем/холост', 4, 4, 4, 5, 4)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (18, N'ВТ-13', N'Орлова Екатерина Арсентьевна', N'Женский', N'Не замужем/холост', 4, 5, 4, 5, 2)
INSERT [dbo].[Finals] ([Id], [GroupId], [FullName], [Gender], [MaritalStatus], [Exam1], [Exam2], [Exam3], [Exam4], [Exam5]) VALUES (19, N'ВТ-11', N'Никонова Виктория Матвеевна', N'Женский', N'Не замужем/холост', 5, 5, 5, 2, 5)
SET IDENTITY_INSERT [dbo].[Finals] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Клиент')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (1, N'Иванов', N'Иван', N'Иванович', N'IvanIvanovich', N'1234', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([UserRole])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Student] SET  READ_WRITE 
GO
