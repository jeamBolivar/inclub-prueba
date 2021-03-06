USE [master]
GO
/****** Object:  Database [ShopDB]    Script Date: 20/05/2022 11:47:48 ******/
CREATE DATABASE [ShopDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopDB', N'ON'
GO
ALTER DATABASE [ShopDB] SET QUERY_STORE = OFF
GO
USE [ShopDB]
GO
/****** Object:  Table [dbo].[order_product]    Script Date: 20/05/2022 11:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_order_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 20/05/2022 11:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[total] [decimal](9, 2) NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 20/05/2022 11:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[price] [decimal](9, 2) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 20/05/2022 11:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](max) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[order_product] ON 

INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (1, 1, 1, 1)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (2, 1, 2, 1)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (3, 1, 1, 3)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (4, 2, 1, 2)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (5, 2, 1, 2)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (6, 2, 2, 1)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (7, 2, 2, 3)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (8, 3, 1, 1)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (9, 3, 2, 1)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (10, 3, 3, 1)
INSERT [dbo].[order_product] ([id], [order_id], [product_id], [quantity]) VALUES (11, 3, 4, 1)
SET IDENTITY_INSERT [dbo].[order_product] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([id], [user_id], [total]) VALUES (1, 1, CAST(452.00 AS Decimal(9, 2)))
INSERT [dbo].[orders] ([id], [user_id], [total]) VALUES (2, 1, CAST(604.00 AS Decimal(9, 2)))
INSERT [dbo].[orders] ([id], [user_id], [total]) VALUES (3, 2, CAST(271.00 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id], [description], [price]) VALUES (1, N'licuadora', CAST(100.20 AS Decimal(9, 2)))
INSERT [dbo].[products] ([id], [description], [price]) VALUES (2, N'air frier', CAST(50.70 AS Decimal(9, 2)))
INSERT [dbo].[products] ([id], [description], [price]) VALUES (3, N'lavadora', CAST(100.50 AS Decimal(9, 2)))
INSERT [dbo].[products] ([id], [description], [price]) VALUES (4, N'secadora', CAST(20.00 AS Decimal(9, 2)))
INSERT [dbo].[products] ([id], [description], [price]) VALUES (5, N'batidora', CAST(60.50 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [password]) VALUES (1, N'jeambolivar', N'1000.Lc4/qbcZv0JS2RhxWzoa3w==.UhF4H+UsiXAKCKf+xq/LpeKFZCsfbRaeeA8oFJTpoBA=')
INSERT [dbo].[users] ([id], [username], [password]) VALUES (2, N'admin', N'1000.odrmc2JQYb79Dxi9GgRCMA==.FNlkKMZP21ZTeOMoFD1q5uyMWswKgbl5/G/xJOZQ6Vs=')
INSERT [dbo].[users] ([id], [username], [password]) VALUES (3, N'diegobolivar', N'1000.0gX+Ksw5wTCFtwRvRulOlg==.k5BAT9qdP1sgBBXmvsyYIIqLfQq9XDrf0voGVEt0+L8=')
INSERT [dbo].[users] ([id], [username], [password]) VALUES (4, N'fiobolivar', N'1000.L4PKt/YQecjguwpuZZj74g==.01VUrdVbsZpc79pWoUpyKakb1tJF/zaKlFX32AW0s3E=')
INSERT [dbo].[users] ([id], [username], [password]) VALUES (6, N'ferbolivar', N'1000.XEgowQ0/McBU81gQRAzqcg==.07zM5Wzm5phW5/1nwa4I/Z6c85aoszrF0ZwwafXTIPo=')
INSERT [dbo].[users] ([id], [username], [password]) VALUES (7, N'admin2', N'1000.Pc6D90M2AEG45YOjlZRkTw==.fsymopr1AEn9RS8EAGYtJXsn/aDl1W4D//JCn8GK4F0=')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[order_product]  WITH CHECK ADD  CONSTRAINT [FK_order_product_order_1] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([id])
GO
ALTER TABLE [dbo].[order_product] CHECK CONSTRAINT [FK_order_product_order_1]
GO
ALTER TABLE [dbo].[order_product]  WITH CHECK ADD  CONSTRAINT [FK_order_product_product_1] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([id])
GO
ALTER TABLE [dbo].[order_product] CHECK CONSTRAINT [FK_order_product_product_1]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_order_user_1] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_order_user_1]
GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 20/05/2022 11:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrders]
	@userId int
AS
BEGIN
	SELECT *
	FROM orders o
	LEFT JOIN order_product op ON o.id = op.order_id
	WHERE o.user_id = @userId;
END
GO
USE [master]
GO
ALTER DATABASE [ShopDB] SET  READ_WRITE 
GO
