USE [master]
GO
/****** Object:  Database [SonGaming]    Script Date: 12/05/2018 6:39:50 PM ******/
CREATE DATABASE [SonGaming]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SonGaming', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SonGaming.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SonGaming_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SonGaming_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SonGaming].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SonGaming] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SonGaming] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SonGaming] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SonGaming] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SonGaming] SET ARITHABORT OFF 
GO
ALTER DATABASE [SonGaming] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SonGaming] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SonGaming] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SonGaming] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SonGaming] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SonGaming] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SonGaming] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SonGaming] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SonGaming] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SonGaming] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SonGaming] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SonGaming] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SonGaming] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SonGaming] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SonGaming] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SonGaming] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SonGaming] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SonGaming] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SonGaming] SET  MULTI_USER 
GO
ALTER DATABASE [SonGaming] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SonGaming] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SonGaming] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SonGaming] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SonGaming] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SonGaming]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[username] [nvarchar](250) NOT NULL,
	[password] [nvarchar](250) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[mahoadon] [int] NOT NULL,
	[masanpham] [int] NOT NULL,
	[soluong] [int] NULL,
	[dongia] [float] NULL,
 CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC,
	[masanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[mahoadon] [int] IDENTITY(1,1) NOT NULL,
	[makh] [int] NULL,
	[ngaydat] [datetime] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[makh] [int] IDENTITY(1,1) NOT NULL,
	[tenkhachhang] [nvarchar](250) NULL,
	[taikhoan] [nvarchar](250) NULL,
	[matkhau] [nvarchar](250) NULL,
	[sodienthoai] [nvarchar](250) NULL,
	[diachi] [nvarchar](250) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISANPHAM](
	[maloai] [int] NOT NULL,
	[tenloai] [nvarchar](250) NULL,
 CONSTRAINT [PK_LOAISANPHAM] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHASANXUAT]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHASANXUAT](
	[mansx] [int] NOT NULL,
	[tennsx] [nvarchar](250) NULL,
 CONSTRAINT [PK_NHASANXUAT] PRIMARY KEY CLUSTERED 
(
	[mansx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 12/05/2018 6:39:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[masanpham] [int] IDENTITY(1,1) NOT NULL,
	[mansx] [int] NULL,
	[maloai] [int] NULL,
	[tensanpham] [nvarchar](250) NULL,
	[giaban] [int] NULL,
	[ngaycapnhat] [datetime] NULL,
	[hinhsanpham] [nvarchar](250) NULL,
	[thongtin] [ntext] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[masanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ADMIN] ([username], [password]) VALUES (N'mrjackvnn', N'0972612950')
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([mahoadon], [makh], [ngaydat]) VALUES (0, 0, CAST(N'2018-04-15T23:49:11.917' AS DateTime))
INSERT [dbo].[HOADON] ([mahoadon], [makh], [ngaydat]) VALUES (1, 0, CAST(N'2018-04-16T00:43:05.167' AS DateTime))
INSERT [dbo].[HOADON] ([mahoadon], [makh], [ngaydat]) VALUES (2, 0, CAST(N'2018-04-16T20:50:34.840' AS DateTime))
INSERT [dbo].[HOADON] ([mahoadon], [makh], [ngaydat]) VALUES (3, 0, CAST(N'2018-04-26T10:52:45.950' AS DateTime))
INSERT [dbo].[HOADON] ([mahoadon], [makh], [ngaydat]) VALUES (1003, 0, CAST(N'2018-05-09T03:23:45.640' AS DateTime))
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([makh], [tenkhachhang], [taikhoan], [matkhau], [sodienthoai], [diachi]) VALUES (0, N'Hồ Sĩ An Sơn', N'mrjackvnn', N'0972612950', N'0972612950', N'102 Ham Nghi')
INSERT [dbo].[KHACHHANG] ([makh], [tenkhachhang], [taikhoan], [matkhau], [sodienthoai], [diachi]) VALUES (2, N'asdasdasd', N'asdasdasd', N'213123123', N'123123123', N'asdasddq2')
INSERT [dbo].[KHACHHANG] ([makh], [tenkhachhang], [taikhoan], [matkhau], [sodienthoai], [diachi]) VALUES (3, N'as123', N'123asd', N'123asd', N'123asd', N'123asd')
INSERT [dbo].[KHACHHANG] ([makh], [tenkhachhang], [taikhoan], [matkhau], [sodienthoai], [diachi]) VALUES (4, N'Hồ Sĩ An Sơn', N'sonsihodh', N'0972612950', N'0972612950', N'102 Ham Nghi')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai]) VALUES (1, N'Chuột')
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai]) VALUES (2, N'Bàn Phím')
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai]) VALUES (3, N'Tai Nghe')
INSERT [dbo].[NHASANXUAT] ([mansx], [tennsx]) VALUES (1, N'Logitech')
INSERT [dbo].[NHASANXUAT] ([mansx], [tennsx]) VALUES (2, N'Razer')
INSERT [dbo].[NHASANXUAT] ([mansx], [tennsx]) VALUES (3, N'Steel Series')
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (1, 1, 2, N'Chuột máy tính Logitech G102 Prodigy Gaming (Đen)', 470000, CAST(N'2018-05-10T00:00:00.000' AS DateTime), N'ChuotLogitechG102.jpg', N'Đã quá nổi với những em chuột dòng gaming build như xe tăng và giá tiền vô cùng ban căng, nay Logitech lại đánh mạnh vào phân khúc phổ thông để xù lông với thị trường. Không phải là ai khác chính là em chuột “thần đồng” Logitech G102 đúng như cái tên có một không hai của hắn.Với giá thành khởi điểm 600.000 VND và ở thời điểm hiện tại là 470.000 VND, rất khó để tìm được một em chuột chơi game đúng nghĩa với mắt đọc khoẻ, nút bấm bền bỉ, feet dày trơn mượt... nhưng tất cả những gì tốt nhất lại có ở Logitech G102 Prodigy gaming mouse.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (2, 1, 1, N'Chuột máy tính Logitech G502', 1650000, CAST(N'2018-04-11T00:00:00.000' AS DateTime), N'ChuotLogitechG502.png', N'Có thể khá là hoang mang khi cố gắng giải mã bộ chuột của Logitech vì số lượng quá nhiều, nhưng có một điều rõ ràng rằng G502 Proteus Spectrum là chuột chơi game có dây hàng đầu cho những người thuận tay phải và nhiều tính năng hơn hầu hết các thiết bị khác. Đây là một sự thay thế cho G502 Proteus Core, với từ Core được thay bằng Spectrum do phiên bản này được trang bị ánh sáng RGB tự nhiên. G502 cũng có tính năng cảm biến chính xác nhất của Logitech, 11 nút lập trình, và bạn cũng có thể tùy chỉnh trọng lượng.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (3, 1, 1, N'Chuột máy tính Logitech Gaming G903 (Đen)', 3700000, CAST(N'2018-04-11T00:00:00.000' AS DateTime), N'ChuotLogitechG903.jpg', N'Trong những thời khắc căng thẳng, sự khác biệt giữa thắng và thua có thể nằm ở độ trễ. Với giải thưởng lên tới hàng triệu đô la, những nhà chuyên nghiệp về thể thao điện tử có thể tin tưởng vào chuột G903. Có tốc độ báo cáo 1 mili giây và kết nối không dây 2.4 GHz tối ưu, G903 mang lại độ nhạy đáng kinh ngạc khi nhắm mục tiêu nhanh ở cấp độ thi đấu.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (4, 1, 2, N'Bàn phím cơ Logitech G Pro', 2190000, CAST(N'2018-04-11T00:00:00.000' AS DateTime), N'BanPhimLogitechGpro.jpg', N'Thị trường thiết bị gaming gear nửa đầu năm 2017 cực kỳ sôi động khi các sản phẩm mới liên tục xuất hiện như Razer với bàn phím chơi game Razer Blackwidow Chroma v2 hay Steelseries là dòng tai nghe chơi game Arctis. Vì thế, để không để mình lạc hậu cũng như mất hút trong mắt cộng động game thủ và các fan hâm mộ, Logitech đã nhanh chóng cho ra mắt bộ đôi chuột và bàn phím G Pro với nhiều nâng cấp khả quan.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (5, 1, 2, N'Bàn phím Logitech Gaming G213 (Đen)', 1020000, CAST(N'2018-04-11T00:00:00.000' AS DateTime), N'BanPhimLogitechG213.png', N'Bàn phím Logitech G213 Prodigy RGB là một loại bàn phím giả cơ mới nhất vừa được ra mắt trong tháng 9 vừa qua. Logitech G213 Prodigy RGB với thiết kế full size với các phím bấm khá giống với switch Brown của Cherry. Không chỉ vậy chiếc bàn phím chơi game mới này còn có khả năng chống nước cực kỳ hiệu quả. Ngoài ra bàn phím Logitech G213 còn được trang bị hệ thống đèn led RGB có khả năng tùy biến sắc màu đến 16.8 triệu màu.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (6, 1, 3, N'Tai nghe Logitech G231', 1250000, CAST(N'2018-04-11T00:00:00.000' AS DateTime), N'TaiNgheLogitechG231.jpg', N'G231 là chiếc tai nghe chơi game mới toanh trong series gaming gear Prodigy của hãng Logitech, được tạo ra để tấn công thị trường thiết bị tầm trung. Không phải ai cũng có cơ hội sở hữu những thiết bị high end của làng gaming gear, thay vào đó họ muốn bỏ tiền để cân bằng giữa thương hiệu, trải nghiệm sử dụng và chất lượng sản phẩm. Dòng sản phẩm Prodigy của Logitech là một trong số đó.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (7, 1, 3, N'Tai nghe Logitech G233 Prodigy Wired Gaming (Đen)
', 1920000, CAST(N'2018-04-12T00:00:00.000' AS DateTime), N'TaiNgheLogitechG233.png', N'Các game thủ đều muốn có hiệu suất âm thanh chất lượng cao, đắm chìm và bùng nổ trong khi chơi. Và vì lý do chính đáng là các game hiện đại đều mang đến thiết kế và hiệu ứng âm thanh đáng ngạc nhiên. Nhưng, còn bên ngoài trò chơi thì sao? G233 là dòng tai nghe chơi game mới. Bạn có tất cả các tính năng và công nghệ tiên tiến mình muốn để chơi game - đó là thiết kế đặc biệt thoải mái và có trọng lượng nhẹ bất ngờ phù hợp với những phần khác trong cuộc sống của bạn.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (8, 2, 1, N'Chuột máy tính Razer Lancehead Ambidextrous
', 3599000, CAST(N'2018-04-13T00:00:00.000' AS DateTime), N'ChuotRazerLancehead.jpg', N'Là một sản phẩm được đầu tư khá kĩ lưỡng của nhà Razer, chuột chơi game Razer Lancehead TE Ambidextrous (Razer Lancehead Tournament Edition Ambidextrous) tiếp tục là một sản phẩm làm mưa gió trong cộng đồng game, đặc biệt là đối với game thủ chuyên nghiệp. Sức hấp dẫn to lớn này từ Razer Lancehead Tournament Edition Ambidextrous đã chứng minh rằng dòng sản phẩm chuột chơi game của nhà Razer chưa bao giờ yếu thế trên thị trường và luôn thu hút được sự quan tâm của đông đảo người yêu game.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (9, 2, 1, N'Chuột máy tính Razer Mamba', 3500000, CAST(N'2018-04-14T00:00:00.000' AS DateTime), N'ChuotRazerMamba.jpg', N'Nếu được so sánh với xe hơi, Mamba chắc hẳn phải là một chiếc Lamborghini: chuyên môn hóa, quá đẳng cấp và hoàn toàn không phù hợp với hầu hết mọi người. Giá của nó là 150USD.Đây có vẻ như là một mức giá quá đắt đối với một số người. Ngay cả khi đó là dòng chuột chơi game không dây chức năng kép với các tính năng độc đáo, đây vẫn là một sự lãng phí không thể phủ nhận thậm chí đối với cả những game thủ giàu có nhất.
Điều đáng ngạc nhiên là Mamba đã linh hoạt biện minh tài tình cho mức giá quá cao này. Thiết kế chắc chắn, tuổi thọ pin dài (theo tiêu chuẩn rất khắt khe của chuột chơi game không dây), và kha khá tiện ích mới như Click Force tùy chỉnh và hệ thống đèn LED Razer Chroma. Rất nhiều ưu điểm bên cạnh số ít nhược điểm đối với phiên bản Mamba năm 2015 này.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (10, 2, 2, N'Bàn phím Razer BlackWidow X Chroma RGB
', 3890000, CAST(N'2018-04-15T00:00:00.000' AS DateTime), N'BanPhimRazerXRGB.png', N'Được thiết kế đặc biệt cho chơi game, Razer Mechanical Switches hoạt động ở khoảng cách tối ưu, cho bạn tốc độ và khả năng phản ứng nhanh hơn bao giờ hết. Thiết bị chuyển mạch cơ của Razer đã được đánh giá là tiêu chuẩn mới cho tất cả bàn phím chơi game cơ khí kể từ khi được giới thiệu.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (11, 2, 2, N'Bàn phím cơ Razer BlackWidow X Chroma ', 3520000, CAST(N'2018-04-16T00:00:00.000' AS DateTime), N'BanPhimRazerBlackWindow.jpg', N'Razer BlackWidow X Chroma Mercury là phiên bản màu trắng của chiếc bàn phím Razer BlackWidow X Chroma, với thiết kế và những tính năng cũ, Razer ra mắt thêm phiên bản Mercury để người dùng có thêm lựa chọn tùy theo sở thích.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (12, 2, 3, N'Tai nghe Razer Electra V2 - Analog', 1500000, CAST(N'2018-04-17T00:00:00.000' AS DateTime), N'TaiNgheRazerElectra.jpg', N'Hãng sản xuất gaming gear (thiết bị chơi game) nổi tiếng - Razer, vừa mang đến cho người dùng, đặc biệt là cộng đồng game thủ một phiên bản kế nhiệm của mẫu tai nghe Electra. Ngoài khả năng giả lập âm thanh vòm 7.1, điểm thú vị khác của chiếc tai nghe này là nó có một mức giá bán ra dễ thở hơn nhiều so với những sản phẩm cùng loại.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (13, 2, 3, N'Tai nghe Razer Kraken 7.1 V2', 2590000, CAST(N'2018-04-17T00:00:00.000' AS DateTime), N'TaiNgheRazerEKraken7.1.jpg', N'Razer Kraken 7.1 V2 Mercury là phiên bản màu trắng của chiếc tai nghe Razer Kraken 7.1 V2, với thiết kế và những tính năng giống với phiên bản trước, Razer đã ra mắt thêm phiên bản Mercury, cho người dùng thêm sự lựa chọn về màu sắc tùy theo sở thích. ')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (14, 3, 1, N'Chuột máy tính SteelSeries Rival 310 (Đen)', 1235000, CAST(N'2018-04-12T00:00:00.000' AS DateTime), N'ChuotSteelSeriesRival310.jpg', N'Sensei 310 là 1 đặc trưng cho dòng chuột chuyên game, nó có trọng lượng nhẹ đáng kinh ngạc chỉ ở mức 92,1 gram. Mọi bộ phận cấu tạo nên Rival 310 đều được gia công cực kì cẩn thận và tỉ mỉ, đem lại bộ bền tuyệt vời.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (15, 3, 1, N'Chuột máy tính SteelSeries Sensei 310 (Đen)', 1390000, CAST(N'2018-04-13T00:00:00.000' AS DateTime), N'ChuotSteelSeriesSensei.jpg', N'Mọi góc cạnh trong thiết kế của Sensei 310 đều đáp ứng được sự thoải mái cần thiết của người dùng trong mọi điều kiện sử dụng. Cho dù bạn có ưa thích kiểu cầm Claw hay Finger-Tip, Sensei 310 đều đem lại cho bạn sự thoải mái cao độ khi sử dụng trong thời gian dài.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (16, 3, 2, N'Bàn phím SteelSeries Apex 100', 1200000, CAST(N'2018-04-10T00:00:00.000' AS DateTime), N'BanPhimSteelSeriesApex.jpg', N'Bàn phím SteelSeries Apex 100 là mẫu bàn phím giả cơ mới nhất mà Steelseries vừa cho ra mắt vào đầu tháng 10 năm 2016 vừa qua. Steelseries Apex 100 có kiểu dáng khá đơn giản khá giống với phiên bản phím cơ Steelseries Apex M500 trước đó. Chiếc bàn phím chơi game mới này được trang bị phím nhấn tuổi thọ lên đến 20 triệu lượt và tốc độ phản hồi cực nhanh không hề thua kém các bàn phím cơ trên thị trường hiện nay. Ngoài ra “em nó” còn có led nền màu xanh dương vô cùng ấn tượng.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (17, 3, 2, N'Bàn phím SteelSeries Apex 150', 1499000, CAST(N'2018-04-09T00:00:00.000' AS DateTime), N'BanPhimSteelSeriesApex150.jpg', N'àn phím SteelSeries Apex 150 là mẫu bàn phím giả cơ có thể cung cấp mọi thứ bạn cần cho việc chơi game. Các nút nhấn Quick Tensors do chính tay SteelSeries thiết kế, đèn nền RGB 5 vùng, và tích hợp thông báo trên Discord sẽ làm cho chiếc bàn phím này trở thành một lựa chọn đáng cân nhắc trong phân khúc phổ thông.')
INSERT [dbo].[SANPHAM] ([masanpham], [mansx], [maloai], [tensanpham], [giaban], [ngaycapnhat], [hinhsanpham], [thongtin]) VALUES (18, 3, 3, N'Tai nghe Steelseries Arctis 7', 3999000, CAST(N'2018-04-08T00:00:00.000' AS DateTime), N'TaiNgheSteelSeriesArctis.jpg', N'Với thiết kế " Closer Ear " theo hình bầu dục giúp người đeo có cảm giác thoải mái hơn , dòng " ARCTIS 7 " tuy là Wireless nhưng trọng lượng không quá nặng, hỗ trợ đầy đủ với Micro thu chống ồn tốt nhất và âm thanh giả lập 7.1 Surround')
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_HOADON] FOREIGN KEY([mahoadon])
REFERENCES [dbo].[HOADON] ([mahoadon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_HOADON]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_SANPHAM] FOREIGN KEY([masanpham])
REFERENCES [dbo].[SANPHAM] ([masanpham])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_SANPHAM]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG] FOREIGN KEY([makh])
REFERENCES [dbo].[KHACHHANG] ([makh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISANPHAM] FOREIGN KEY([maloai])
REFERENCES [dbo].[LOAISANPHAM] ([maloai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_NHASANXUAT] FOREIGN KEY([mansx])
REFERENCES [dbo].[NHASANXUAT] ([mansx])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_NHASANXUAT]
GO
USE [master]
GO
ALTER DATABASE [SonGaming] SET  READ_WRITE 
GO
