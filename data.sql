USE [master]
GO
/****** Object:  Database [bookmanagement]    Script Date: 09/03/2023 19:52:15 ******/
CREATE DATABASE [bookmanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bookmanagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HAO\MSSQL\DATA\bookmanagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bookmanagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.HAO\MSSQL\DATA\bookmanagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [bookmanagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bookmanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bookmanagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bookmanagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bookmanagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bookmanagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bookmanagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [bookmanagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bookmanagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bookmanagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bookmanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bookmanagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bookmanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bookmanagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bookmanagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bookmanagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bookmanagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bookmanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bookmanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bookmanagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bookmanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bookmanagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bookmanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bookmanagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bookmanagement] SET RECOVERY FULL 
GO
ALTER DATABASE [bookmanagement] SET  MULTI_USER 
GO
ALTER DATABASE [bookmanagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bookmanagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bookmanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bookmanagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bookmanagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bookmanagement', N'ON'
GO
ALTER DATABASE [bookmanagement] SET QUERY_STORE = OFF
GO
USE [bookmanagement]
GO
/****** Object:  Table [dbo].[books]    Script Date: 09/03/2023 19:52:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[author] [nvarchar](255) NULL,
	[decription] [nvarchar](255) NULL,
	[public_date] [int] NULL,
	[category] [nvarchar](255) NULL,
	[price] [float] NULL,
	[image_url] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_item]    Script Date: 09/03/2023 19:52:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idOrder] [int] NULL,
	[idBook] [int] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 09/03/2023 19:52:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[totalPrice] [float] NULL,
	[create_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 09/03/2023 19:52:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](255) NULL,
	[pass] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[role] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[books] ON 

INSERT [dbo].[books] ([id], [title], [author], [decription], [public_date], [category], [price], [image_url]) VALUES (5, N'ĐỜI THAY ĐỔI KHI CHÚNG TA THAY ĐỔI', N'Andrew Mathew', N'Cuộc đời của mỗi người sẽ luôn trải qua những giai đoạn thăng trầm, đôi lúc bạn sẽ buông bỏ tất cả vì mất niềm tin, ý chí. Nhưng bạn phải thật sáng suốt và tỉnh táo để nhận ra những bài học cuộc đời mang lại.', 2019, N'Văn học', 150000, N'https://cdn3.dhht.vn/wp-content/uploads/2022/09/2-top-15-nhung-cuon-sach-hay-nen-doc-it-nhat-1-lan-trong-doi.jpg')
INSERT [dbo].[books] ([id], [title], [author], [decription], [public_date], [category], [price], [image_url]) VALUES (7, N'ĐẮC NHÂN TÂM', N'Dale Carnegie', N'Đắc Nhân Tâm là một trong những cuốn sách hay nên đọc cho học sinh và cả người trưởng thành. Được tác giả Dale Carnegie ra mắt năm 1937, trải qua nhiều năm đây vẫn là cuốn sách đáng đọc bởi những giá trị mà nó mang lại.', 1937, N'Tâm lý học', 150000, N'https://cdn3.dhht.vn/wp-content/uploads/2022/09/3-top-15-nhung-cuon-sach-hay-nen-doc-it-nhat-1-lan-trong-doi.jpg')
INSERT [dbo].[books] ([id], [title], [author], [decription], [public_date], [category], [price], [image_url]) VALUES (8, N'CÁCH NGHĨ ĐỂ THÀNH CÔNG', N'Napoleon Hill', N'Đây là câu chuyện của con trai tác giả, đứa bé sinh ra không có đôi tai. Người bố khi ấy đã gieo cho cậu một niềm tin mãnh liệt. Tuổi đi học của cậu bé thay vì học trong trường khiếm thị thì ông bố đã mang con mình đến ngôi trường bình thường để học tập.', 2019, N'Sách làm giàu', 89000, N'https://cdn3.dhht.vn/wp-content/uploads/2022/09/4-top-15-nhung-cuon-sach-hay-nen-doc-it-nhat-1-lan-trong-doi.jpg')
INSERT [dbo].[books] ([id], [title], [author], [decription], [public_date], [category], [price], [image_url]) VALUES (9, N'HẠT GIỐNG TÂM HỒN', N'Nhiều tác giả', N'Bạn sẽ thấy mình trong những câu chuyện nhỏ, nhẹ nhàng và giản dị nhưng chứa đựng những triết lý sống sâu sắc. Từng chương sách là một khía cạnh, trải nghiệm mới về cuộc sống. Từ đó giúp bạn khai phá những câu hỏi về cuộc sống này.', 2002, N'Tâm lý', 250000, N'https://cdn3.dhht.vn/wp-content/uploads/2022/09/5-top-15-nhung-cuon-sach-hay-nen-doc-it-nhat-1-lan-trong-doi.jpg')
SET IDENTITY_INSERT [dbo].[books] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [email], [pass], [name], [role]) VALUES (1, N'admin@gmail.com', N'123', N'admin', 0)
INSERT [dbo].[users] ([id], [email], [pass], [name], [role]) VALUES (2, N'user@gmail.com', N'123', N'user', 1)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((1)) FOR [role]
GO
ALTER TABLE [dbo].[order_item]  WITH CHECK ADD  CONSTRAINT [pk_orderitem_book] FOREIGN KEY([idBook])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[order_item] CHECK CONSTRAINT [pk_orderitem_book]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [pk_order_user] FOREIGN KEY([idUser])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [pk_order_user]
GO
USE [master]
GO
ALTER DATABASE [bookmanagement] SET  READ_WRITE 
GO
