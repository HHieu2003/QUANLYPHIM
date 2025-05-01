CREATE DATABASE QuanLyPhim;
go
USE QuanLyPhim;
go
-- 1. Người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung NVARCHAR(10) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(10) CHECK (VaiTro IN ('admin', 'nhanvien', 'khach')) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);
go
-- 2. Phòng chiếu
CREATE TABLE PhongChieu (
    MaPhong NVARCHAR(10) PRIMARY KEY,
    TenPhong NVARCHAR(100) NOT NULL,
    SoLuongGhe INT NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'hoatdong' CHECK (TrangThai IN ('hoatdong', 'baotri'))
);
go
-- 3. Thể loại phim
CREATE TABLE TheLoaiPhim (
    MaTheLoai NVARCHAR(10) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL UNIQUE
);
go

-- 4. Phim
CREATE TABLE Phim (
    MaPhim NVARCHAR(10) PRIMARY KEY,
    TenPhim NVARCHAR(200) NOT NULL,
    MaTheLoai NVARCHAR(10) NULL,
    ThoiLuong INT NOT NULL,
    MoTa NVARCHAR(500),
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoaiPhim(MaTheLoai) ON DELETE SET NULL
);
go
-- 5. Lịch chiếu
CREATE TABLE LichChieu (
    MaLichChieu NVARCHAR(10) PRIMARY KEY,
    MaPhim NVARCHAR(10) NULL,
    MaPhong NVARCHAR(10) NULL,
    GioBatDau DATETIME NOT NULL,
    GiaVe DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (MaPhim) REFERENCES Phim(MaPhim) ON DELETE SET NULL,
    FOREIGN KEY (MaPhong) REFERENCES PhongChieu(MaPhong) ON DELETE SET NULL
);
go
-- 6. Loại vé
CREATE TABLE LoaiVe (
    MaLoaiVe NVARCHAR(10) PRIMARY KEY,
    TenLoaiVe NVARCHAR(100),
    PhuThu DECIMAL(10,2) DEFAULT 0
);
go
-- 7. Khách hàng
CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);
go

-- 9. Đơn hàng (Hóa đơn)
CREATE TABLE DonHang (
    MaDonHang NVARCHAR(50) PRIMARY KEY,
    MaKhachHang NVARCHAR(10) NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(12,2),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE SET NULL
);
go
-- 13. Giao dịch
CREATE TABLE GiaoDich (
    MaGiaoDich NVARCHAR(50) PRIMARY KEY,
    MaXacNhan NVARCHAR(10) NOT NULL UNIQUE,
    MaKhachHang NVARCHAR(10),
    MaDonHang NVARCHAR(50) NULL,
    NgayGiaoDich DATETIME ,
    TongTien DECIMAL(18, 2) ,
    TrangThai NVARCHAR(20) DEFAULT 'ChuaXuLy' CHECK (TrangThai IN ('ChuaXuLy', 'DaXuLy')),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE SET NULL,
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang) ON DELETE SET NULL
);


-- 8. Vé
CREATE TABLE Ve (
    MaVe UNIQUEIDENTIFIER PRIMARY KEY,
    MaLichChieu NVARCHAR(10) NULL,
    MaLoaiVe NVARCHAR(10) NULL,
    MaKhachHang NVARCHAR(10) NULL,
    SoGhe NVARCHAR(10) NOT NULL,
    NgayDat DATETIME DEFAULT GETDATE(),
    MaGiaoDich NVARCHAR(50) NULL,
    FOREIGN KEY (MaLichChieu) REFERENCES LichChieu(MaLichChieu) ON DELETE SET NULL,
    FOREIGN KEY (MaLoaiVe) REFERENCES LoaiVe(MaLoaiVe) ON DELETE SET NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE SET NULL,
	  FOREIGN KEY (MaGiaoDich) REFERENCES GiaoDich(MaGiaoDich) ON DELETE SET NULL
);
go




go
-- 10. Món ăn
CREATE TABLE DoAn (
    MaDoAn NVARCHAR(10) PRIMARY KEY,
    TenDoAn NVARCHAR(100),
    Gia DECIMAL(10,2),
    MoTa NVARCHAR(255)
);
go
-- 11. Chi tiết đơn hàng đồ ăn
CREATE TABLE ChiTietDoAn (
    MaChiTiet NVARCHAR(50) PRIMARY KEY,
    MaDonHang NVARCHAR(50) NULL,
    MaDoAn NVARCHAR(10) NULL,
    SoLuong INT NOT NULL,
    Gia DECIMAL(10,2) NOT NULL,
    ThanhTien DECIMAL(12,2),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang) ON DELETE SET NULL,
    FOREIGN KEY (MaDoAn) REFERENCES DoAn(MaDoAn) ON DELETE SET NULL
);

-- Trigger cập nhật Thành Tiền
GO
CREATE TRIGGER trg_CapNhat_ThanhTien
ON ChiTietDoAn
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE c
    SET c.ThanhTien = c.SoLuong * c.Gia
    FROM ChiTietDoAn c
    JOIN inserted i ON c.MaChiTiet = i.MaChiTiet;
END;
go
-- 12. Báo cáo
CREATE TABLE BaoCao (
    MaBaoCao NVARCHAR(10) PRIMARY KEY,
    TieuDe NVARCHAR(200),
    NoiDung NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NguoiTao NVARCHAR(10) NULL,
    FOREIGN KEY (NguoiTao) REFERENCES NguoiDung(MaNguoiDung) ON DELETE SET NULL
);


INSERT INTO NguoiDung VALUES
('KH01', 'admin', '1', 'admin', GETDATE()),
('KH02', 'nhanvien1', '123456', 'nhanvien', GETDATE()),
('KH03', 'khach1', 'abcxyz', 'khach', GETDATE()),
('KH04', 'khach2', 'pass123', 'khach', GETDATE()),
('KH05', 'nhanvien2', 'nhanvien456', 'nhanvien', GETDATE());

INSERT INTO KhachHang VALUES
('KH01', 'admin1', '0909123456', 'a@gmail.com'),
('KH02', 'Trần Thị B', '0911223344', 'b@gmail.com'),
('KH03', 'Lê Văn C', '0933445566', 'c@gmail.com'),
('KH04', 'Phạm Thị D', '0977889900', 'd@gmail.com'),
('KH05', 'Hoàng Văn E', '0922334455', 'e@gmail.com');

INSERT INTO PhongChieu VALUES
('PC01', 'Phòng 1', 100, 'hoatdong'),
('PC02', 'Phòng 2', 80, 'hoatdong'),
('PC03', 'Phòng 3', 120, 'baotri'),
('PC04', 'Phòng VIP', 50, 'hoatdong'),
('PC05', 'Phòng Mini', 40, 'hoatdong');
INSERT INTO TheLoaiPhim VALUES
('TL01', 'Hành động'),
('TL02', 'Hài'),
('TL03', 'Tình cảm'),
('TL04', 'Kinh dị'),
('TL05', 'Hoạt hình');
INSERT INTO Phim VALUES
('P001', 'Avengers: Endgame', 'TL01', 180, 'Siêu anh hùng cứu thế giới'),
('P002', 'Minions', 'TL05', 95, 'Những chú minion đáng yêu'),
('P003', 'The Conjuring', 'TL04', 110, 'Phim kinh dị nổi tiếng'),
('P004', 'Titanic', 'TL03', 195, 'Chuyện tình bất hủ trên tàu Titanic'),
('P005', 'Mr. Bean Holiday', 'TL02', 85, 'Hài hước và giải trí');
INSERT INTO LichChieu VALUES
('LC01', 'P001', 'PC01', '2025-04-27 18:00', 90000),
('LC02', 'P002', 'PC02', '2025-04-27 14:00', 75000),
('LC03', 'P003', 'PC03', '2025-04-27 22:00', 85000),
('LC04', 'P004', 'PC04', '2025-04-28 19:00', 95000),
('LC05', 'P005', 'PC05', '2025-04-28 10:00', 60000);
INSERT INTO LoaiVe VALUES
('LV01', 'Thường', 0),
('LV02', 'VIP', 30000),
('LV03', 'Sinh viên', -10000),
('LV04', 'Cuối tuần', 20000),
('LV05', 'Ưu đãi đặc biệt', -20000);
INSERT INTO Ve (MaVe, MaLichChieu, MaLoaiVe, MaKhachHang, SoGhe, NgayDat) VALUES
(NEWID(), 'LC01', 'LV01', 'KH01', 'A1', GETDATE()),
(NEWID(), 'LC02', 'LV02', 'KH02', 'B5', GETDATE()),
(NEWID(), 'LC03', 'LV03', 'KH03', 'C7', GETDATE()),
(NEWID(), 'LC04', 'LV01', 'KH04', 'D3', GETDATE()),
(NEWID(), 'LC05', 'LV04', 'KH05', 'E6', GETDATE());
INSERT INTO DonHang VALUES
('DH001', 'KH01', GETDATE(), 120000),
('DH002', 'KH02', GETDATE(), 100000),
('DH003', 'KH03', GETDATE(), 90000),
('DH004', 'KH04', GETDATE(), 110000),
('DH005', 'KH05', GETDATE(), 130000);
INSERT INTO DoAn VALUES
('DA01', 'Bắp rang bơ', 40000, 'Bắp rang vị caramel'),
('DA02', 'Pepsi', 25000, 'Nước giải khát'),
('DA03', 'Combo 1 (Bắp + Nước)', 60000, 'Combo tiết kiệm'),
('DA04', 'Khoai tây chiên', 30000, 'Giòn rụm thơm ngon'),
('DA05', 'Nước suối', 15000, 'Chai 500ml');
INSERT INTO ChiTietDoAn VALUES
('CTDA01', 'DH001', 'DA01', 2, 40000, NULL),
('CTDA02', 'DH002', 'DA02', 1, 25000, NULL),
('CTDA03', 'DH003', 'DA03', 1, 60000, NULL),
('CTDA04', 'DH004', 'DA04', 3, 30000, NULL),
('CTDA05', 'DH005', 'DA05', 2, 15000, NULL);
INSERT INTO BaoCao VALUES
('BC01', 'Báo cáo doanh thu tháng 4', 'Chi tiết doanh thu theo từng ngày', GETDATE(), 'KH01'),
('BC02', 'Báo cáo lỗi hệ thống', 'Lỗi không đặt được vé', GETDATE(), 'KH02'),
('BC03', 'Đề xuất nâng cấp phòng chiếu', 'Cần nâng cấp âm thanh phòng 3', GETDATE(), 'KH03'),
('BC04', 'Phản hồi khách hàng', 'Khách hàng phàn nàn về ghế ngồi', GETDATE(), 'KH04'),
('BC05', 'Báo cáo tồn kho đồ ăn', 'Kiểm kê kho ngày 25/4', GETDATE(), 'KH05');
