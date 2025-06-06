CREATE DATABASE DATN;
USE DATN;
GO
/****** Object:  Table [dbo].[ChiTietSach]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSach](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[Id] [nvarchar](50) NULL,
	[TenSach] [nvarchar](50) NULL,
	[NhomTheLoai] [nvarchar](50) NULL,
	[TheLoai] [nvarchar](50) NULL,
	[TacGia] [nvarchar](50) NULL,
	[NhaXuatBan] [nvarchar](50) NULL,
	[NamXuatBan] [int] NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[ISBN] [nvarchar](50) NULL,
	[NgayNhapSach] [date] NULL,
	[GioiHanDocGia] [nvarchar](50) NULL,
	[TinhTrangSach] [nvarchar](50) NULL,
	[TinhTrangMuon] [nvarchar](50) NULL,
	[KeSach] [nvarchar](50) NULL,
	[AnhBia] [nvarchar](max) NULL,
 CONSTRAINT [PK_DanhSachSach] PRIMARY KEY CLUSTERED 
(
	[Stt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomLoaiSach]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomLoaiSach](
	[Id] [nvarchar](50) NOT NULL,
	[TenNhomSach] [nvarchar](50) NULL,
	[MaTat] [nvarchar](50) NULL,
	[SoLuongTheLoai] [int] NULL,
	[SoLuongSach] [int] NULL,
 CONSTRAINT [PK_NhomLoaiSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyChamCong]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyChamCong](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienId] [nvarchar](50) NULL,
	[TongNgayChamCong] [int] NULL,
	[ThangChamCong] [nvarchar](50) NULL,
	[SoNgayChamCongTrenThang] [int] NULL,
	[NgayChamCong] [date] NULL,
	[ChamLanDau] [date] NULL,
	[ChamLanCuoi] [date] NULL,
 CONSTRAINT [PK_QuanLyChamCong] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyCongViec]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyCongViec](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiCongViec] [nvarchar](50) NULL,
	[CongViec] [nvarchar](50) NULL,
	[MaTat] [nvarchar](50) NULL,
	[LuongCoBan] [money] NULL,
	[SoLuongNguoiLam] [int] NULL,
 CONSTRAINT [PK_QuanLyCongViec] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyDauSach]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyDauSach](
	[Id] [nvarchar](50) NOT NULL,
	[TenSach] [nvarchar](100) NULL,
	[NhomSach] [nvarchar](50) NULL,
	[TheLoai] [nvarchar](50) NULL,
	[TacGia] [nvarchar](50) NULL,
	[NhaXuatBan] [nvarchar](50) NULL,
	[NamXuatBan] [int] NULL,
	[ISBN] [nvarchar](50) NULL,
	[NgonNgu] [nvarchar](50) NULL,
	[NgayNhapSach] [date] NULL,
	[GioiHanDocGia] [nvarchar](50) NULL,
	[TongSoSach] [int] NULL,
	[SoLuongTrongThuVien] [int] NULL,
	[SoLuongMuon] [int] NULL,
	[SoLuongMat] [int] NULL,
	[AnhBia] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuanLySach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyDocGia]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyDocGia](
	[Id] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[SoCCCD] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[LoaiDocGia] [nvarchar](50) NULL,
	[NgayDangKy] [date] NULL,
	[NgayLamThe] [date] NULL,
	[NgayHetHanThe] [date] NULL,
	[TrangThaiDocGia] [nvarchar](50) NULL,
	[AnhDG] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuanLyHoiVien] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyKeSach]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyKeSach](
	[Id] [nvarchar](50) NOT NULL,
	[TenKeSach] [nvarchar](100) NULL,
	[LoaiKeSach] [nvarchar](100) NULL,
	[NhomTheLoaiKe] [nvarchar](100) NULL,
	[ViTriKe] [nvarchar](100) NULL,
	[SoLuongSachToiDa] [int] NULL,
	[SoLuongSachHienTai] [int] NULL,
 CONSTRAINT [PK_QuanLyKeSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyMuonSach]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyMuonSach](
	[Id] [nvarchar](50) NOT NULL,
	[DocGiaID] [nvarchar](50) NULL,
	[TenDocGia] [nvarchar](50) NULL,
	[SoLuongMuon] [int] NULL,
	[NgayMuon] [date] NULL,
	[NgayHenTra] [date] NULL,
	[NgayGiaHanTra1] [date] NULL,
	[NgayGiaHanTra2] [date] NULL,
	[PhiGiaHan] [money] NULL,
	[NgayTraThucTe] [date] NULL,
	[TinhTrangMuonTra] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](500) NULL,
	[IDSachMuon1] [nvarchar](50) NULL,
	[TenSach1] [nvarchar](max) NULL,
	[TinhTrangSach1] [nvarchar](50) NULL,
	[TinhTrangKhiTra1] [nvarchar](50) NULL,
	[IDSachMuon2] [nvarchar](50) NULL,
	[TenSach2] [nvarchar](max) NULL,
	[TinhTrangSach2] [nvarchar](50) NULL,
	[TinhTrangKhiTra2] [nvarchar](50) NULL,
	[IDSachMuon3] [nvarchar](50) NULL,
	[TenSach3] [nvarchar](max) NULL,
	[TinhTrangSach3] [nvarchar](50) NULL,
	[TinhTrangKhiTra3] [nvarchar](50) NULL,
	[TinhTrangBoiThuong] [nvarchar](50) NULL,
	[TienBoiThuong] [money] NULL,
 CONSTRAINT [PK_QuanLyMuonSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyNhanSu]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyNhanSu](
	[Id] [nvarchar](50) NOT NULL,
	[TenNhanSu] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[CCCD] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NgayBatDau] [date] NULL,
	[LoaiNhanSu] [nvarchar](50) NULL,
	[CongViec] [nvarchar](50) NULL,
	[LuongCoBan] [money] NULL,
	[AnhTT] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuanLyNhanVien] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyNhaXuatBan]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyNhaXuatBan](
	[Id] [nvarchar](50) NOT NULL,
	[TenNhaXuatBan] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](50) NULL,
	[Gmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuanLyNhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyPhongDoc]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyPhongDoc](
	[Id] [nvarchar](50) NULL,
	[TenPhongDoc] [nvarchar](100) NULL,
	[LoaiPhongDoc] [nvarchar](50) NULL,
	[GioiHanDocGia] [nvarchar](50) NULL,
	[ViTriPhongDoc] [nvarchar](100) NULL,
	[SoLuongKeSach] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoSachTrenKe]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoSachTrenKe](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[KeSachId] [nvarchar](50) NULL,
	[SachId] [nvarchar](50) NULL,
 CONSTRAINT [PK_SoSachTrenKe] PRIMARY KEY CLUSTERED 
(
	[Stt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoanQuanLy]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanQuanLy](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](500) NULL,
	[NgayTao] [date] NULL,
	[NguoiDungId] [nvarchar](50) NULL,
	[LoaiTk] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuanLyTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Stt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoaiSach]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoaiSach](
	[Id] [nvarchar](50) NOT NULL,
	[NhomLoaiSach] [nvarchar](50) NULL,
	[TheLoai] [nvarchar](50) NULL,
	[MaTat] [nvarchar](50) NULL,
	[SoLuongSach] [int] NULL,
 CONSTRAINT [PK_TheLoaiSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheoDoiDangNhap]    Script Date: 4/4/2025 4:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheoDoiDangNhap](
	[Stt] [int] IDENTITY(1,1) NOT NULL,
	[TKDangNhap] [nvarchar](50) NULL,
	[LoaiTK] [nvarchar](50) NULL,
	[NgayDangNhap] [date] NULL,
	[ThoiDiemDangNhap] [nvarchar](50) NULL,
	[ThoiDiemDangXuat] [nvarchar](50) NULL,
 CONSTRAINT [PK_TheoDoiDangNhap] PRIMARY KEY CLUSTERED 
(
	[Stt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietSach] ON 

INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (6, N'GD-TH-00001-001', N'test2x', N'Sách Giáo dục', N'Sách toán học', N'tester', N'Kim đồng', 2025, N'Tiếng Việt', N'123456789', CAST(N'2025-03-03' AS Date), N'Không giới hạn', N'Mới', N'Khả dụng', N'Trong kho', N'C:\Users\Admin\Downloads\2021080915352364784.png')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (7, N'GD-TH-00001-002', N'test2x', N'Sách Giáo dục', N'Sách toán học', N'tester', N'Kim đồng', 2025, N'Tiếng Việt', N'123456789', CAST(N'2025-03-03' AS Date), N'Không giới hạn', N'Mới', N'Khả dụng', N'Trong kho', N'C:\Users\Admin\Downloads\2021080915352364784.png')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (8, N'GD-TH-00001-003', N'test2x', N'Sách Giáo dục', N'Sách toán học', N'tester', N'Kim đồng', 2025, N'Tiếng Việt', N'123456789', CAST(N'2025-03-03' AS Date), N'Không giới hạn', N'Mới', N'Khả dụng', N'Trong kho', N'C:\Users\Admin\Downloads\2021080915352364784.png')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (9, N'GD-TH-00001-004', N'test2x', N'Sách Giáo dục', N'Sách toán học', N'tester', N'Kim đồng', 2025, N'Tiếng Việt', N'123456789', CAST(N'2025-03-03' AS Date), N'Không giới hạn', N'Bình thường', N'Khả dụng', N'Kệ A1', N'C:\Users\Admin\Downloads\2021080915352364784.png')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (10, N'GD-TH-00001-005', N'test2x', N'Sách Giáo dục', N'Sách toán học', N'tester', N'Kim đồng', 2025, N'Tiếng Việt', N'123456789', CAST(N'2025-03-03' AS Date), N'Không giới hạn', N'Bình thường', N'Khả dụng', N'Kệ A1', N'C:\Users\Admin\Downloads\2021080915352364784.png')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (11, N'TT-TTCN-00001-001', N'toán 5', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'r324', N'Kim đồng', 2019, N'Tiếng Việt', N'23523532', CAST(N'2025-03-14' AS Date), N'Không giới hạn', N'Bình thường', N'Khả dụng', N'Kệ A1', N'C:\Users\lamri\Downloads\5r5xd3.jpg')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (12, N'TT-TTCN-00001-002', N'toán 5', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'r324', N'Kim đồng', 2019, N'Tiếng Việt', N'23523532', CAST(N'2025-03-14' AS Date), N'Không giới hạn', N'Bình thường', N'Khả dụng', N'Kệ A1', N'C:\Users\lamri\Downloads\5r5xd3.jpg')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (13, N'TT-TTCN-00001-003', N'toán 5', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'r324', N'Kim đồng', 2019, N'Tiếng Việt', N'23523532', CAST(N'2025-03-14' AS Date), N'Không giới hạn', N'Cũ', N'Không khả dụng', N'Trong kho', N'C:\Users\lamri\Downloads\5r5xd3.jpg')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (14, N'TT-TTCN-00001-004', N'toán 5', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'r324', N'Kim đồng', 2019, N'Tiếng Việt', N'23523532', CAST(N'2025-03-14' AS Date), N'Không giới hạn', N'Cũ', N'Không khả dụng', N'Trong kho', N'C:\Users\lamri\Downloads\5r5xd3.jpg')
INSERT [dbo].[ChiTietSach] ([Stt], [Id], [TenSach], [NhomTheLoai], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [NgonNgu], [ISBN], [NgayNhapSach], [GioiHanDocGia], [TinhTrangSach], [TinhTrangMuon], [KeSach], [AnhBia]) VALUES (15, N'TT-TTCN-00001-005', N'toán 5', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'r324', N'Kim đồng', 2019, N'Tiếng Việt', N'23523532', CAST(N'2025-03-14' AS Date), N'Không giới hạn', N'Cũ', N'Không khả dụng', N'Trong kho', N'C:\Users\lamri\Downloads\5r5xd3.jpg')
SET IDENTITY_INSERT [dbo].[ChiTietSach] OFF
GO
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N001', N'Sách Giáo dục', N'GD', 7, 5)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N002', N'Sách Tâm lý - Chữa lành', N'TC', 6, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N003', N'Sách Y học - Sức khỏe', N'YS', 5, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N004', N'Sách Tôn giáo', N'TG', 5, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N005', N'Sách Tiểu sử - Tự truyện', N'TT', 5, 5)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N006', N'Sách Lịch sử - Địa lý', N'LD', 5, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N007', N'Sách Nghệ thuật và Sáng tạo', N'NS', 5, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N008', N'Sách Triết học - Chính trị', N'TC', 3, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N009', N'Sách Truyện - Tiểu thuyết', N'TTT', 6, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N010', N'Sách Khoa học - Công nghệ và Nông nghiệp', N'KC', 4, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N011', N'Sách Kinh doanh - Khởi nghiệp', N'KK', 4, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N012', N'Sách Thể thao - Giải trí', N'TTG', 2, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N013', N'Sách Văn hóa - Du lịch', N'VD', 2, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N014', N'Sách Dạy nghề', N'DN', 2, 0)
INSERT [dbo].[NhomLoaiSach] ([Id], [TenNhomSach], [MaTat], [SoLuongTheLoai], [SoLuongSach]) VALUES (N'N015', N'Sách Thiếu nhi', N'TN', 2, 0)
GO
SET IDENTITY_INSERT [dbo].[QuanLyCongViec] ON 

INSERT [dbo].[QuanLyCongViec] ([Id], [LoaiCongViec], [CongViec], [MaTat], [LuongCoBan], [SoLuongNguoiLam]) VALUES (1, NULL, N'Thủ thư', N'TT', 10000000.0000, 0)
INSERT [dbo].[QuanLyCongViec] ([Id], [LoaiCongViec], [CongViec], [MaTat], [LuongCoBan], [SoLuongNguoiLam]) VALUES (2, NULL, N'Lao công', N'LC', 80000000.0000, 0)
INSERT [dbo].[QuanLyCongViec] ([Id], [LoaiCongViec], [CongViec], [MaTat], [LuongCoBan], [SoLuongNguoiLam]) VALUES (3, NULL, N'Bảo vệ', N'BV', 60000000.0000, 0)
SET IDENTITY_INSERT [dbo].[QuanLyCongViec] OFF
GO
INSERT [dbo].[QuanLyDauSach] ([Id], [TenSach], [NhomSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [ISBN], [NgonNgu], [NgayNhapSach], [GioiHanDocGia], [TongSoSach], [SoLuongTrongThuVien], [SoLuongMuon], [SoLuongMat], [AnhBia]) VALUES (N'GD-TH-00001', N'test2x', N'Sách Giáo dục', N'Sách toán học', N'tester', N'Kim đồng', 2025, N'123456789', N'Tiếng Việt', CAST(N'2025-03-03' AS Date), N'Không giới hạn', 5, 5, 0, 0, N'C:\Users\Admin\Downloads\2021080915352364784.png')
INSERT [dbo].[QuanLyDauSach] ([Id], [TenSach], [NhomSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan], [ISBN], [NgonNgu], [NgayNhapSach], [GioiHanDocGia], [TongSoSach], [SoLuongTrongThuVien], [SoLuongMuon], [SoLuongMat], [AnhBia]) VALUES (N'TT-TTCN-00001', N'toán 5', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'r324', N'Kim đồng', 2019, N'23523532', N'Tiếng Việt', CAST(N'2025-03-14' AS Date), N'Không giới hạn', 5, 5, 0, 0, N'C:\Users\lamri\Downloads\5r5xd3.jpg')
GO
INSERT [dbo].[QuanLyDocGia] ([Id], [HoTen], [NgaySinh], [SoCCCD], [SDT], [DiaChi], [LoaiDocGia], [NgayDangKy], [NgayLamThe], [NgayHetHanThe], [TrangThaiDocGia], [AnhDG]) VALUES (N'DG0000001', N'Tester', CAST(N'2000-01-01' AS Date), N'123456789', N'5889897498', N'vdvđvvs', N'Phổ thông', CAST(N'2025-03-04' AS Date), CAST(N'2025-03-04' AS Date), CAST(N'2026-03-04' AS Date), N'Còn hạn', N'C:\Users\lamri\Downloads\5r5xd3.jpg')
INSERT [dbo].[QuanLyDocGia] ([Id], [HoTen], [NgaySinh], [SoCCCD], [SDT], [DiaChi], [LoaiDocGia], [NgayDangKy], [NgayLamThe], [NgayHetHanThe], [TrangThaiDocGia], [AnhDG]) VALUES (N'DG0000002', N'Người làm app', CAST(N'2002-10-11' AS Date), N'8668866886', N'0352232274', N'Bắc Ninh', N'Đặc biệt ', CAST(N'2025-03-19' AS Date), CAST(N'2025-03-27' AS Date), CAST(N'2026-03-19' AS Date), N'Còn hạn', N'C:\Users\Admin\Downloads\8840770fb75a02a1d3cdb7f40998f607_6136976844461586863.png')
GO
INSERT [dbo].[QuanLyKeSach] ([Id], [TenKeSach], [LoaiKeSach], [NhomTheLoaiKe], [ViTriKe], [SoLuongSachToiDa], [SoLuongSachHienTai]) VALUES (N'KS-0001', N'Kệ A1', N'To', N'Sách Giáo dục', N'Khu A', 100, 3)
INSERT [dbo].[QuanLyKeSach] ([Id], [TenKeSach], [LoaiKeSach], [NhomTheLoaiKe], [ViTriKe], [SoLuongSachToiDa], [SoLuongSachHienTai]) VALUES (N'KS-002', N'Kệ B1', N'To', N'Sách Y học - Sức khỏe', N'Khu B', 100, 0)
GO
INSERT [dbo].[QuanLyMuonSach] ([Id], [DocGiaID], [TenDocGia], [SoLuongMuon], [NgayMuon], [NgayHenTra], [NgayGiaHanTra1], [NgayGiaHanTra2], [PhiGiaHan], [NgayTraThucTe], [TinhTrangMuonTra], [GhiChu], [IDSachMuon1], [TenSach1], [TinhTrangSach1], [TinhTrangKhiTra1], [IDSachMuon2], [TenSach2], [TinhTrangSach2], [TinhTrangKhiTra2], [IDSachMuon3], [TenSach3], [TinhTrangSach3], [TinhTrangKhiTra3], [TinhTrangBoiThuong], [TienBoiThuong]) VALUES (N'PM-00001', N'DG-00001', N'Adu', 3, CAST(N'2025-03-04' AS Date), CAST(N'2025-04-01' AS Date), CAST(N'2025-03-30' AS Date), CAST(N'2025-04-01' AS Date), 30000.0000, NULL, N'Đã trả', N'abcdefg', N'GD-TH-00001-001', N'test', N'Mới', N'Mới', N'GD-TH-00001-002', N'test', N'Mới', N'Bình thường', N'GD-TH-00001-003', N'test', N'Mới', N'Mới', N'Không cần bồi thường', 0.0000)
INSERT [dbo].[QuanLyMuonSach] ([Id], [DocGiaID], [TenDocGia], [SoLuongMuon], [NgayMuon], [NgayHenTra], [NgayGiaHanTra1], [NgayGiaHanTra2], [PhiGiaHan], [NgayTraThucTe], [TinhTrangMuonTra], [GhiChu], [IDSachMuon1], [TenSach1], [TinhTrangSach1], [TinhTrangKhiTra1], [IDSachMuon2], [TenSach2], [TinhTrangSach2], [TinhTrangKhiTra2], [IDSachMuon3], [TenSach3], [TinhTrangSach3], [TinhTrangKhiTra3], [TinhTrangBoiThuong], [TienBoiThuong]) VALUES (N'PM-2025-000001', N'DG0000001', N'Tester', 3, CAST(N'2025-03-01' AS Date), CAST(N'2025-03-15' AS Date), NULL, NULL, NULL, NULL, N'Quá hạn', N'Không có ghi chú', N'GD-TH-00001-003', N'test2x', N'Mới', NULL, N'TT-TTCN-00001-003', N'toán 5', N'Cũ', NULL, N'GD-TH-00001-004', N'test2x', N'Bình thường', NULL, NULL, NULL)
GO
INSERT [dbo].[QuanLyNhanSu] ([Id], [TenNhanSu], [GioiTinh], [NgaySinh], [CCCD], [Email], [SDT], [DiaChi], [NgayBatDau], [LoaiNhanSu], [CongViec], [LuongCoBan], [AnhTT]) VALUES (N'TT-00001', N'Thủ thư số 1', N'Nữ', CAST(N'2000-02-02' AS Date), N'2222222222', N'thuthu@gmail.com', N'0220022002', N'Bắc Ninh', CAST(N'2025-03-01' AS Date), N'Nhân viên quản lý', N'Thủ thư', 10000000.0000, N'C:\Users\Admin\Downloads\8840770fb75a02a1d3cdb7f40998f607_6136976844461586863.png')
GO
INSERT [dbo].[QuanLyNhaXuatBan] ([Id], [TenNhaXuatBan], [DiaChi], [SDT], [Gmail]) VALUES (N'NXB1', N'Kim đồng', N'Kim đồng', N'123456789', N'gmail.com')
GO
SET IDENTITY_INSERT [dbo].[SoSachTrenKe] ON 

INSERT [dbo].[SoSachTrenKe] ([Stt], [KeSachId], [SachId]) VALUES (6, N'KS-0001', N'GD-TH-00001-003')
INSERT [dbo].[SoSachTrenKe] ([Stt], [KeSachId], [SachId]) VALUES (10, N'KS-0001', N'TT-TTCN-00001-002')
INSERT [dbo].[SoSachTrenKe] ([Stt], [KeSachId], [SachId]) VALUES (11, N'KS-0001', N'GD-TH-00001-003')
SET IDENTITY_INSERT [dbo].[SoSachTrenKe] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoanQuanLy] ON 

INSERT [dbo].[TaiKhoanQuanLy] ([Stt], [TaiKhoan], [MatKhau], [NgayTao], [NguoiDungId], [LoaiTk]) VALUES (1, N'admin', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', CAST(N'2025-03-19' AS Date), N'admin123', N'Admin')
INSERT [dbo].[TaiKhoanQuanLy] ([Stt], [TaiKhoan], [MatKhau], [NgayTao], [NguoiDungId], [LoaiTk]) VALUES (2, N'test', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', CAST(N'2025-03-21' AS Date), N'TT-00001', N'User')
SET IDENTITY_INSERT [dbo].[TaiKhoanQuanLy] OFF
GO
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL001', N'Sách Giáo dục', N'Sách toán học', N'TH', 5)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL002', N'Sách giáo dục', N'Sách tham khảo ', N'TK', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL003', N'Sách giáo dục', N'Sách kỹ năng sống', N'KNS', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL004', N'Sách giáo dục', N'Sách ngoại ngữ ', N'NN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL005', N'Sách giáo dục', N'Sách khoa học phổ thông', N'KHPT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL006', N'Sách giáo dục', N'Sách giáo dục mầm non', N'GDMN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL007', N'Sách giáo dục', N'Sách đạo đức và phát triển nhân cách', N'DDPT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL008', N'Sách Tâm lý - Chữa lành', N'Sách tâm lý học', N'TLH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL009', N'Sách Tâm lý - Chữa lành', N'Sách chữa lành và cảm xúc', N'CLCX', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL010', N'Sách Tâm lý - Chữa lành', N'Sách về mối quan hệ', N'MQH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL011', N'Sách Tâm lý - Chữa lành', N'Sách cảm hứng sống', N'CHS', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL012', N'Sách Tâm lý - Chữa lành', N'Sách tâm lý xã hội', N'TLXH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL013', N'Sách Tâm lý - Chữa lành', N'Sách tình yêu - hôn nhân', N'TYHN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL014', N'Sách Y học - Sức khỏe', N'Sách y học phổ thông
', N'YHPT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL015', N'Sách Y học - Sức khỏe', N'Sách dinh dưỡng và sức khỏe', N'DDSK', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL016', N'Sách Y học - Sức khỏe', N'Sách chăm sóc sức khỏe tinh thần', N'SKTT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL017', N'Sách Y học - Sức khỏe', N'Sách y học cổ truyền', N'YHCT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL018', N'Sách Y học - Sức khỏe', N'Sách hướng dẫn sơ cứu và chữa bệnh', N'SCCB', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL019', N'Sách Tôn giáo', N'Sách kinh điển tôn giáo', N'KDTG', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL020', N'Sách Tôn giáo', N'Sách triết lý tôn giáo', N'TLTG', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL021', N'Sách Tôn giáo', N'Sách giáo dục tâm linh', N'GDTL', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL022', N'Sách Tôn giáo', N'Sách thiền, cầu nguyện', N'TCN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL023', N'Sách Tôn giáo', N'Sách phong tục tín ngưỡng', N'PTTN  ', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL024', N'Sách Tiểu sử - Tự truyện', N'Tự truyện cá nhân', N'TTCN', 5)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL025', N'Sách Tiểu sử - Tự truyện', N'Sách tiểu sử và hồi ký', N'TSHK', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL026', N'Sách Tiểu sử - Tự truyện', N'Tiểu sử nghệ sĩ', N'TSNS', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL027', N'Sách Tiểu sử - Tự truyện', N'Tiểu sử nhà khoa học', N'TSKH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL028', N'Sách Tiểu sử - Tự truyện', N'Tiểu sử chính trị gia', N'TSCT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL029', N'Sách Lịch sử - Địa lý', N'Sách lịch sử quốc gia và thế giới
', N'QGTG', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL030', N'Sách Lịch sử - Địa lý', N'Sách địa lý văn hóa và du ký, khám phá', N'VHDK', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL031', N'Sách Lịch sử - Địa lý
', N'Sách khảo cổ học ', N'KCH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL032', N'Sách Lịch sử - Địa lý
', N'Sách lịch sử chiến tranh', N'LSCT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL033', N'Sách Lịch sử - Địa lý
', N'Sách bản đồ và tư liệu địa lý', N'BDTL', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL034', N'Sách Nghệ thuật và Sáng tạo', N'Sách mỹ thuật và hội họa', N'MTHH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL035', N'Sách Nghệ thuật và Sáng tạo', N'Sách âm nhạc và nghệ thuật biểu diễn', N'ANNT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL036', N'Sách Nghệ thuật và Sáng tạo', N'Sách quảng cáo và sáng tạo truyền thông', N'QCST', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL037', N'Sách Nghệ thuật và Sáng tạo', N'Sách thiết kế thời trang
', N'TKTT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL038', N'Sách Nghệ thuật và Sáng tạo', N'Sách nhiếp ảnh', N'NA', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL039', N'Sách Triết học - Chính trị', N'Sách triết học cổ điển và hiện đại', N'CDHD', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL040', N'Sách Triết học - Chính trị', N'Sách chính trị và luật pháp', N'CTLP', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL041', N'Sách Triết học - Chính trị', N'Sách triết lý đạo đức và nhân sinh', N'DDNS', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL043', N'Sách Truyện - Tiểu thuyết', N'Sách truyện hài hước', N'THH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL044', N'Sách Truyện - Tiểu thuyết', N'Sách tiểu thuyết giả tưởng', N'TTGT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL045', N'Sách Truyện - Tiểu thuyết', N'Sách tiểu thuyết tình cảm', N'TTTC', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL046', N'Sách Truyện - Tiểu thuyết', N'Sách tiểu thuyết lịch sử', N'TTLS', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL047', N'Sách Truyện - Tiểu thuyết', N'Sách tiểu thuyết hư cấu hiện thực', N'HCVT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL048', N'Sách Truyện - Tiểu thuyết', N'Sách tiểu thuyết kinh dị', N'TTKD', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL049', N'Sách Khoa học - Công nghệ và Nông Nghiệp', N'Sách khoa học tự nhiên ', N'KHTN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL050', N'Sách Khoa học - Công nghệ và Nông Nghiệp', N'Sách công nghệ thông tin
', N'CNTT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL051', N'Sách Khoa học - Công nghệ và Nông Nghiệp', N'Sách kỹ thuật', N'KT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL052', N'Sách Khoa học - Công nghệ và Nông Nghiệp', N'Sách khoa học ứng dụng', N'KHUD', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL053', N'Sách Kinh doanh - Khởi nghiệp', N'Sách quản trị doanh nghiệp', N'QTDN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL054', N'Sách Kinh doanh - Khởi nghiệp', N'Sách marketing và bán hàng', N'MBH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL055', N'Sách Kinh doanh - Khởi nghiệp', N'Sách tài chính cá nhân', N'TCCN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL056', N'Sách Kinh doanh - Khởi nghiệp', N'Sách khởi nghiệp và đổi mới sáng tạo
', N'KNDM', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL057', N'Sách Thể thao - Giải trí', N'Sách về các môn thể thao', N'MTT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL058', N'Sách Thể thao - Giải trí', N'Sách giải trí tổng hợp
', N'GTTH', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL059', N'Sách Văn hóa - Du lịch', N'Sách hướng dẫn du lịch', N'HDDL', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL060', N'Sách Văn hóa - Du lịch', N'Sách văn hóa các vùng miền', N'VHVM', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL061', N'Sách Dạy nghề', N'Sách nghề thủ công ', N'NTC', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL062', N'Sách Dạy nghề', N'Sách kỹ thuật công nghiệp', N'KTCN', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL063', N'Sách Thiếu nhi', N'Sách truyện cổ tích', N'TCT', 0)
INSERT [dbo].[TheLoaiSach] ([Id], [NhomLoaiSach], [TheLoai], [MaTat], [SoLuongSach]) VALUES (N'TL064', N'Sách Thiếu nhi', N'Sách truyện tranh', N'TT', 0)
GO
SET IDENTITY_INSERT [dbo].[TheoDoiDangNhap] ON 

INSERT [dbo].[TheoDoiDangNhap] ([Stt], [TKDangNhap], [LoaiTK], [NgayDangNhap], [ThoiDiemDangNhap], [ThoiDiemDangXuat]) VALUES (1, N'admin', N'Admin', CAST(N'2025-04-04' AS Date), N'14:53:59', N'14:54:40')
SET IDENTITY_INSERT [dbo].[TheoDoiDangNhap] OFF
GO
