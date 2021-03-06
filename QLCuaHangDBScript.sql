USE [QLCuaHangDB]
GO
/****** Object:  Table [dbo].[BK_CTHoaDon]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BK_CTHoaDon](
	[id_HoaDon] [int] NOT NULL,
	[id_NuocGK] [int] NOT NULL,
	[soluongmua] [int] NOT NULL,
	[dongiaban] [int] NULL,
	[thanhtien] [int] NULL,
 CONSTRAINT [PK_dbo.BK_CTHoaDon] PRIMARY KEY CLUSTERED 
(
	[id_HoaDon] ASC,
	[id_NuocGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BK_HoaDon]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BK_HoaDon](
	[id_HoaDon] [int] NOT NULL,
	[NgayXuatHD] [date] NOT NULL,
	[id_KhachHang] [int] NULL,
	[soHD] [nvarchar](5) NULL,
	[TongTien] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[id_HoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietDonDatHang]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonDatHang](
	[id_DonDatHang] [int] NOT NULL,
	[id_NuocGK] [int] NOT NULL,
	[SoLuongDat] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_DonDatHang] ASC,
	[id_NuocGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[id_HoaDon] [int] NOT NULL,
	[id_NuocGK] [int] NOT NULL,
	[soluongmua] [int] NOT NULL,
	[dongiaban] [int] NULL,
	[thanhtien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_HoaDon] ASC,
	[id_NuocGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuGiaoHang]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuGiaoHang](
	[id_PhieuGiao] [int] NOT NULL,
	[id_NuocGK] [int] NOT NULL,
	[SoLuongGiao] [int] NOT NULL,
	[DonGiaGiao] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_PhieuGiao] ASC,
	[id_NuocGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuHen]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuHen](
	[id_NuocGK] [int] NOT NULL,
	[id_PhieuHen] [int] NOT NULL,
	[soluongHang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_PhieuHen] ASC,
	[id_NuocGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonDatHang]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatHang](
	[id_DonDatHang] [int] IDENTITY(1,1) NOT NULL,
	[NgayDatHang] [date] NOT NULL,
	[NhaCungUng] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_DonDatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[id_HoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayXuatHD] [date] NOT NULL,
	[id_KhachHang] [int] NULL,
	[soHD] [varchar](5) NULL,
	[TongTien] [int] NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_HoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id_KhachHang] [int] IDENTITY(1,1) NOT NULL,
	[tenKhachHang] [nvarchar](100) NOT NULL,
	[TenDN] [varchar](15) NOT NULL,
	[Matkhau] [varchar](32) NOT NULL,
	[diachi] [nvarchar](100) NOT NULL,
	[Ngaysinh] [smalldatetime] NULL,
	[Email] [varchar](50) NULL,
	[Gioitinh] [bit] NULL,
	[SoDienThoai] [varchar](20) NOT NULL,
	[SoTienConNo] [int] NOT NULL,
	[Duyet] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_KhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiNGK]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNGK](
	[id_LoaiNGK] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNGK] [nvarchar](100) NOT NULL,
	[NhaCungUng] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_LoaiNGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungUng]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungUng](
	[id_NhaCungUng] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaCungUng] [nvarchar](200) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_NhaCungUng] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NuocGK]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NuocGK](
	[id_NuocGK] [int] IDENTITY(1,1) NOT NULL,
	[tenNGK] [nvarchar](50) NOT NULL,
	[dongia] [int] NOT NULL,
	[nhanhieuNGK] [int] NULL,
	[soluongton] [int] NOT NULL,
	[hinhanh] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_NuocGK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuGiaoHang]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuGiaoHang](
	[id_PhieuGiao] [int] IDENTITY(1,1) NOT NULL,
	[id_DonDatHang] [int] NOT NULL,
	[NgayGiaoHang] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_PhieuGiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuHen]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuHen](
	[id_PhieuHen] [int] IDENTITY(1,1) NOT NULL,
	[ngaylapphieu] [date] NOT NULL,
	[ngayhen] [date] NOT NULL,
	[id_KhachHang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_PhieuHen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuTraNo]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTraNo](
	[id_PhieuTraNo] [int] IDENTITY(1,1) NOT NULL,
	[NgayTra] [date] NOT NULL,
	[SoTienTra] [int] NOT NULL,
	[id_HoaDon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_PhieuTraNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](32) NOT NULL,
	[PhanQuyen] [bit] NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](12) NULL,
	[Duyet] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietDonDatHang] ([id_DonDatHang], [id_NuocGK], [SoLuongDat]) VALUES (7, 15, 27)
INSERT [dbo].[ChiTietDonDatHang] ([id_DonDatHang], [id_NuocGK], [SoLuongDat]) VALUES (7, 16, 19)
INSERT [dbo].[ChiTietPhieuGiaoHang] ([id_PhieuGiao], [id_NuocGK], [SoLuongGiao], [DonGiaGiao]) VALUES (5, 15, 1, 4950)
INSERT [dbo].[ChiTietPhieuGiaoHang] ([id_PhieuGiao], [id_NuocGK], [SoLuongGiao], [DonGiaGiao]) VALUES (5, 16, 1, 5400)
INSERT [dbo].[ChiTietPhieuGiaoHang] ([id_PhieuGiao], [id_NuocGK], [SoLuongGiao], [DonGiaGiao]) VALUES (6, 15, 2, 4950)
INSERT [dbo].[ChiTietPhieuGiaoHang] ([id_PhieuGiao], [id_NuocGK], [SoLuongGiao], [DonGiaGiao]) VALUES (6, 16, 2, 5400)
SET IDENTITY_INSERT [dbo].[DonDatHang] ON 

INSERT [dbo].[DonDatHang] ([id_DonDatHang], [NgayDatHang], [NhaCungUng]) VALUES (7, CAST(N'2018-05-28' AS Date), 2)
SET IDENTITY_INSERT [dbo].[DonDatHang] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([id_KhachHang], [tenKhachHang], [TenDN], [Matkhau], [diachi], [Ngaysinh], [Email], [Gioitinh], [SoDienThoai], [SoTienConNo], [Duyet]) VALUES (1, N'Trần Đức Khang', N'monterk1', N'dcfec921c9f4c28daea525b5ee34123a', N'Lý Tự Trọng', NULL, N'khangtdk0612@gmail.com', 1, N'12345678910', 27000, 1)
INSERT [dbo].[KhachHang] ([id_KhachHang], [tenKhachHang], [TenDN], [Matkhau], [diachi], [Ngaysinh], [Email], [Gioitinh], [SoDienThoai], [SoTienConNo], [Duyet]) VALUES (5, N'Nguyễn Văn A', N'nguyenvana', N'e10adc3949ba59abbe56e057f20f883e', N'TPCHM', CAST(N'2018-05-07 00:00:00' AS SmallDateTime), N'vana@gmail.com', 1, N'0987654321', 0, 0)
INSERT [dbo].[KhachHang] ([id_KhachHang], [tenKhachHang], [TenDN], [Matkhau], [diachi], [Ngaysinh], [Email], [Gioitinh], [SoDienThoai], [SoTienConNo], [Duyet]) VALUES (7, N'aaa', N'aaa', N'e10adc3949ba59abbe56e057f20f883e', N'sadas', CAST(N'2018-05-01 00:00:00' AS SmallDateTime), N'asdasd', 1, N'12456890', 0, 1)
INSERT [dbo].[KhachHang] ([id_KhachHang], [tenKhachHang], [TenDN], [Matkhau], [diachi], [Ngaysinh], [Email], [Gioitinh], [SoDienThoai], [SoTienConNo], [Duyet]) VALUES (10, N'Tran Duc Khang', N'abc', N'900150983cd24fb0d6963f7d28e17f72', N'40C Ly Tu Trong', CAST(N'2018-05-02 00:00:00' AS SmallDateTime), N'khangtdk0612@gmail.com', 1, N'12345679', 0, 0)
INSERT [dbo].[KhachHang] ([id_KhachHang], [tenKhachHang], [TenDN], [Matkhau], [diachi], [Ngaysinh], [Email], [Gioitinh], [SoDienThoai], [SoTienConNo], [Duyet]) VALUES (11, N'Admin', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'123', NULL, NULL, 1, N'213123123', 0, 1)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiNGK] ON 

INSERT [dbo].[LoaiNGK] ([id_LoaiNGK], [TenLoaiNGK], [NhaCungUng]) VALUES (1, N'Nước có ga', 1)
INSERT [dbo].[LoaiNGK] ([id_LoaiNGK], [TenLoaiNGK], [NhaCungUng]) VALUES (2, N'Nước suối', 2)
INSERT [dbo].[LoaiNGK] ([id_LoaiNGK], [TenLoaiNGK], [NhaCungUng]) VALUES (3, N'Nước tăng lực', 4)
INSERT [dbo].[LoaiNGK] ([id_LoaiNGK], [TenLoaiNGK], [NhaCungUng]) VALUES (4, N'Nước trái cây', 3)
SET IDENTITY_INSERT [dbo].[LoaiNGK] OFF
SET IDENTITY_INSERT [dbo].[NhaCungUng] ON 

INSERT [dbo].[NhaCungUng] ([id_NhaCungUng], [TenNhaCungUng], [DiaChi], [SDT]) VALUES (1, N'ABC', N'123', N'0123456789')
INSERT [dbo].[NhaCungUng] ([id_NhaCungUng], [TenNhaCungUng], [DiaChi], [SDT]) VALUES (2, N'BCD', N'456', N'9876543210')
INSERT [dbo].[NhaCungUng] ([id_NhaCungUng], [TenNhaCungUng], [DiaChi], [SDT]) VALUES (3, N'EFG', N'987', N'1254798630')
INSERT [dbo].[NhaCungUng] ([id_NhaCungUng], [TenNhaCungUng], [DiaChi], [SDT]) VALUES (4, N'AAA', N'TPHCM', N'666777888')
SET IDENTITY_INSERT [dbo].[NhaCungUng] OFF
SET IDENTITY_INSERT [dbo].[NuocGK] ON 

INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (1, N'Coca lon', 10000, 1, -1, N'coca-350ml.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (2, N'Coca chai', 12000, 1, -6, N'coca-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (3, N'Pepsi chai', 13000, 1, 0, N'pepsi-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (4, N'Pepsi lon', 11000, 1, 30, N'pepsi-lon.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (5, N'Sprite chai', 11000, 1, 20, N'sprite-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (6, N'Sprite lon', 10000, 1, 20, N'sprite-lon.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (7, N'Sting đỏ (lon)', 9000, 1, 30, N'sting-do-lon.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (8, N'Sting đỏ (chai)', 11000, 1, 20, N'sting-do-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (9, N'Sting vàng (lon)', 9000, 1, 20, N'sting-vang-lon.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (10, N'Sting vàng (chai)', 11000, 1, 19, N'sting-vang-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (11, N'Fanta cam (lon)', 12000, 1, 19, N'fanta-lon.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (12, N'Fanta cam (chai)', 13000, 1, 19, N'fanta-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (13, N'Aquafina', 5500, 2, 19, N'aquafina-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (14, N'Lavie', 6000, 2, 30, N'Lavie-chai.png')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (15, N'Nước suối Vĩnh Hảo', 5500, 2, 3, N'vinhhao-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (16, N'Nước suối Ion-Life', 6000, 2, -1, N'ionlife-chai.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (19, N'Four Season', 8000, 4, 22, N'four_seasons_mixed_fruit_drink_can.jpg')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (20, N'RedBull', 15000, 3, 27, N'redbull.png')
INSERT [dbo].[NuocGK] ([id_NuocGK], [tenNGK], [dongia], [nhanhieuNGK], [soluongton], [hinhanh]) VALUES (21, N'Monster', 32000, 3, 27, N'monster.png')
SET IDENTITY_INSERT [dbo].[NuocGK] OFF
SET IDENTITY_INSERT [dbo].[PhieuGiaoHang] ON 

INSERT [dbo].[PhieuGiaoHang] ([id_PhieuGiao], [id_DonDatHang], [NgayGiaoHang]) VALUES (5, 7, CAST(N'2018-05-28' AS Date))
INSERT [dbo].[PhieuGiaoHang] ([id_PhieuGiao], [id_DonDatHang], [NgayGiaoHang]) VALUES (6, 7, CAST(N'2018-05-28' AS Date))
SET IDENTITY_INSERT [dbo].[PhieuGiaoHang] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([id], [TenDangNhap], [MatKhau], [PhanQuyen], [DiaChi], [SDT], [Duyet]) VALUES (4, N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1, N'HANOI', N'0987654321', 1)
INSERT [dbo].[TaiKhoan] ([id], [TenDangNhap], [MatKhau], [PhanQuyen], [DiaChi], [SDT], [Duyet]) VALUES (5, N'user1', N'24c9e15e52afc47c225b757e7bee1f9d', 0, N'TPHCM', N'0213654879', 1)
INSERT [dbo].[TaiKhoan] ([id], [TenDangNhap], [MatKhau], [PhanQuyen], [DiaChi], [SDT], [Duyet]) VALUES (6, N'user2', N'7e58d63b60197ceb55a1c487989a3720', 0, N'DANANG', N'123456789', 0)
INSERT [dbo].[TaiKhoan] ([id], [TenDangNhap], [MatKhau], [PhanQuyen], [DiaChi], [SDT], [Duyet]) VALUES (7, N'user3', N'92877af70a45fd6a2ed7fe81e1236b78', 0, N'DALAT', N'0756438291', 0)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD FOREIGN KEY([id_DonDatHang])
REFERENCES [dbo].[DonDatHang] ([id_DonDatHang])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD FOREIGN KEY([id_NuocGK])
REFERENCES [dbo].[NuocGK] ([id_NuocGK])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([id_HoaDon])
REFERENCES [dbo].[HoaDon] ([id_HoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([id_NuocGK])
REFERENCES [dbo].[NuocGK] ([id_NuocGK])
GO
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuGiaoHang_NuocGK] FOREIGN KEY([id_PhieuGiao])
REFERENCES [dbo].[PhieuGiaoHang] ([id_PhieuGiao])
GO
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang] CHECK CONSTRAINT [FK_ChiTietPhieuGiaoHang_NuocGK]
GO
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuGiaoHang_NuocGK1] FOREIGN KEY([id_NuocGK])
REFERENCES [dbo].[NuocGK] ([id_NuocGK])
GO
ALTER TABLE [dbo].[ChiTietPhieuGiaoHang] CHECK CONSTRAINT [FK_ChiTietPhieuGiaoHang_NuocGK1]
GO
ALTER TABLE [dbo].[ChiTietPhieuHen]  WITH CHECK ADD FOREIGN KEY([id_NuocGK])
REFERENCES [dbo].[NuocGK] ([id_NuocGK])
GO
ALTER TABLE [dbo].[ChiTietPhieuHen]  WITH CHECK ADD FOREIGN KEY([id_PhieuHen])
REFERENCES [dbo].[PhieuHen] ([id_PhieuHen])
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD FOREIGN KEY([NhaCungUng])
REFERENCES [dbo].[NhaCungUng] ([id_NhaCungUng])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([id_KhachHang])
REFERENCES [dbo].[KhachHang] ([id_KhachHang])
GO
ALTER TABLE [dbo].[LoaiNGK]  WITH CHECK ADD FOREIGN KEY([NhaCungUng])
REFERENCES [dbo].[NhaCungUng] ([id_NhaCungUng])
GO
ALTER TABLE [dbo].[NuocGK]  WITH CHECK ADD FOREIGN KEY([nhanhieuNGK])
REFERENCES [dbo].[LoaiNGK] ([id_LoaiNGK])
GO
ALTER TABLE [dbo].[PhieuGiaoHang]  WITH CHECK ADD  CONSTRAINT [FK_PhieuGiaoHang_DonDatHang] FOREIGN KEY([id_DonDatHang])
REFERENCES [dbo].[DonDatHang] ([id_DonDatHang])
GO
ALTER TABLE [dbo].[PhieuGiaoHang] CHECK CONSTRAINT [FK_PhieuGiaoHang_DonDatHang]
GO
ALTER TABLE [dbo].[PhieuHen]  WITH CHECK ADD FOREIGN KEY([id_KhachHang])
REFERENCES [dbo].[KhachHang] ([id_KhachHang])
GO
ALTER TABLE [dbo].[PhieuTraNo]  WITH CHECK ADD FOREIGN KEY([id_HoaDon])
REFERENCES [dbo].[HoaDon] ([id_HoaDon])
GO
/****** Object:  StoredProcedure [dbo].[BackupHoaDon]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BackupHoaDon]
as
begin
set nocount off;
	insert into BK_HoaDon select * from HoaDon
	insert into BK_CTHoaDon select * from ChiTietHoaDon

	delete from ChiTietHoaDon
	delete from HoaDon
end

GO
/****** Object:  Trigger [dbo].[TG_UpdateSoLuongSP]    Script Date: 6/1/2018 8:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TG_UpdateSoLuongSP]
on [dbo].[ChiTietHoaDon]
for insert,update
as
begin
	declare @ID_HoaDon int
	declare @ID_NuocGK int
	declare @SoLuongMua int
	declare @DonGiaBan int
	declare @ThanhTien int
	declare @SoLuongTon int

	select @ID_HoaDon = Inserted.id_HoaDon, @ID_NuocGK = Inserted.id_NuocGK, @SoLuongMua = Inserted.soluongmua from Inserted
	select @SoLuongTon = soluongton, @DonGiaBan = dongia from NuocGK where id_NuocGK = @ID_NuocGK

	set @SoLuongTon = @SoLuongTon - @SoLuongMua
	update NuocGK set soluongton = @SoLuongTon where id_NuocGK = @ID_NuocGK

end
GO
