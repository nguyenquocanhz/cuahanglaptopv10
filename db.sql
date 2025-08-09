USE [laptopStoreDB]
GO

/****** Object:  Table [dbo].[ChiTietHoaDon]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
    [MaHD] [int] NOT NULL,
    [MaSP] [int] NOT NULL,
    [SoLuong] [int] NULL,
    [DonGia] [decimal](18, 2) NULL,
    [ThanhTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaHD] ASC,
    [MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ChiTietPhieuBaoHanh]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuBaoHanh](
    [MaPBH] [int] NOT NULL,
    [MaTTBH] [int] NULL,
    [MaSP] [int] NOT NULL,
    [TrangThai] [nvarchar](50) NULL,
    [GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaPBH] ASC,
    [MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ChiTietPhieuNhap]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
    [MaPN] [int] NOT NULL,
    [MaSP] [int] NOT NULL,
    [SoLuongNhap] [int] NULL,
    [DonGiaNhap] [decimal](18, 2) NULL,
    [ThanhTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaPN] ASC,
    [MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[HoaDon]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
    [MaHD] [int] IDENTITY(1,1) NOT NULL,
    [ngayTao] [date] NULL,
    [tongTienTT] [decimal](18, 2) NULL,
    [ghiChu] [nvarchar](255) NULL,
    [MaKH] [int] NULL,
    [MaNV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
    [MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[KhachHang]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
    [MaKH] [int] IDENTITY(1,1) NOT NULL,
    [HotenKH] [nvarchar](100) NULL,
    [gioiTinh] [nvarchar](10) NULL,
    [soDienThoai] [varchar](15) NULL,
    [diaChiKH] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[khuyenMaiSP]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khuyenMaiSP](
    [MaKM] [int] IDENTITY(1,1) NOT NULL,
    [TenKM] [nvarchar](100) NULL,
    [GiaTriKM] [decimal](5, 2) NULL,
    [ngayBatDau] [date] NULL,
    [ngayKetThuc] [date] NULL,
    [trangThaiCT] [nvarchar](50) NULL,
    [ghiChu] [nvarchar](255) NULL,
    [MaKMHienThi]  AS ('KM'+right('000000'+CONVERT([varchar](10),[MaKM]),(6))) PERSISTED,
PRIMARY KEY CLUSTERED 
(
    [MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NhaCungCap]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
    [MaNCC] [int] IDENTITY(1,1) NOT NULL,
    [TenNCC] [nvarchar](100) NULL,
    [soDienThoaiNCC] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NhanVien]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
    [MaNV] [int] IDENTITY(1,1) NOT NULL,
    [hoTenNV] [nvarchar](100) NULL,
    [gioiTinh] [nvarchar](10) NULL,
    [ngaySinh] [date] NULL,
    [soDienThoai] [varchar](15) NULL,
    [password] [varchar](255) NULL,
    [quyenHan] [nvarchar](50) NULL,
    [chucDanh] [nvarchar](50) NULL,
    [DiaChiNV] [nvarchar](255) NULL,
    [cccd] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
UNIQUE NONCLUSTERED 
(
    [soDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PhieuBaoHanh]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuBaoHanh](
    [MaPBH] [int] NOT NULL,
    [MaKH] [int] NULL,
    [MaHD] [int] NULL,
    [NgayLap] [date] NULL,
    [ThoiGianBaoHanh] [int] NULL,
    [GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaPBH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PhieuNhapHang]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapHang](
    [MaPN] [int] IDENTITY(1,1) NOT NULL,
    [tongTienNhap] [decimal](18, 2) NULL,
    [ngayLapPhieu] [date] NULL,
    [MaNCC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
    [MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SanPham]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
    [MaSP] [int] IDENTITY(1,1) NOT NULL,
    [TenSP] [nvarchar](100) NULL,
    [thoiGianBaoHanh] [int] NULL,
    [soLuongSP] [int] NULL,
    [giaBan] [int] NULL,
    [MaNCC] [int] NULL,
    [moTaChiTiet] [nvarchar](max) NULL, -- Changed from text to nvarchar(max)
    [giaNhap] [int] NULL,
 CONSTRAINT [PK__SanPham__2725081CF1296A66] PRIMARY KEY CLUSTERED 
(
    [MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY] -- Removed TEXTIMAGE_ON [PRIMARY] as nvarchar(max) doesn't require it explicitly
GO

/****** Object:  Table [dbo].[SanPhamKhuyenMai]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamKhuyenMai](
    [MaKM] [int] NOT NULL,
    [MaSP] [int] NOT NULL,
    [MaNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [MaKM] ASC,
    [MaSP] ASC,
    [MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TrungTamBaoHanh]     Script Date: 19/04/2025 15:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrungTamBaoHanh](
    [MaTTBH] [int] IDENTITY(1,1) NOT NULL,
    [TenTTBH] [nvarchar](100) NULL,
    [DiaChiTTBH] [nvarchar](255) NULL,
    [soDienThoai] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
    [MaTTBH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] -- Removed OPTIMIZE_FOR_SEQUENTIAL_KEY
) ON [PRIMARY]
GO

-- FOREIGN KEY CONSTRAINTS (These look fine for compatibility)
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHoa__MaSP__2A164134] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHoa__MaSP__2A164134]
GO
ALTER TABLE [dbo].[ChiTietPhieuBaoHanh]  WITH CHECK ADD FOREIGN KEY([MaPBH])
REFERENCES [dbo].[PhieuBaoHanh] ([MaPBH])
GO
ALTER TABLE [dbo].[ChiTietPhieuBaoHanh]  WITH CHECK ADD FOREIGN KEY([MaTTBH])
REFERENCES [dbo].[TrungTamBaoHanh] ([MaTTBH])
GO
ALTER TABLE [dbo].[ChiTietPhieuBaoHanh]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPhi__MaSP__3D2915A8] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietPhieuBaoHanh] CHECK CONSTRAINT [FK__ChiTietPhi__MaSP__3D2915A8]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhapHang] ([MaPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPhi__MaSP__3587F3E0] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPhi__MaSP__3587F3E0]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuBaoHanh]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[PhieuBaoHanh]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[PhieuNhapHang]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK__SanPham__MaNCC__151B244E] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK__SanPham__MaNCC__151B244E]
GO
ALTER TABLE [dbo].[SanPhamKhuyenMai]  WITH CHECK ADD FOREIGN KEY([MaKM])
REFERENCES [dbo].[khuyenMaiSP] ([MaKM])
GO
ALTER TABLE [dbo].[SanPhamKhuyenMai]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[SanPhamKhuyenMai]  WITH CHECK ADD  CONSTRAINT [FK__SanPhamKhu__MaSP__1EA48E88] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[SanPhamKhuyenMai] CHECK CONSTRAINT [FK__SanPhamKhu__MaSP__1EA48E88]
GO