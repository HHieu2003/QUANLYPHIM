CREATE DATABASE QuanLyPhim;
USE QuanLyPhim;

-- 1. Người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung NVARCHAR(10) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(10) CHECK (VaiTro IN ('admin', 'nhanvien', 'khach')) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);

-- 2. Phòng chiếu
CREATE TABLE PhongChieu (
    MaPhong NVARCHAR(10) PRIMARY KEY,
    TenPhong NVARCHAR(100) NOT NULL,
    SoLuongGhe INT NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'hoatdong' CHECK (TrangThai IN ('hoatdong', 'baotri'))
);

-- 3. Thể loại phim
CREATE TABLE TheLoaiPhim (
    MaTheLoai NVARCHAR(10) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL UNIQUE
);

-- 4. Phim
CREATE TABLE Phim (
    MaPhim NVARCHAR(10) PRIMARY KEY,
    TenPhim NVARCHAR(200) NOT NULL,
    MaTheLoai NVARCHAR(10) NULL,
    ThoiLuong INT NOT NULL,
    MoTa NVARCHAR(500),
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoaiPhim(MaTheLoai) ON DELETE SET NULL
);

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

-- 6. Loại vé
CREATE TABLE LoaiVe (
    MaLoaiVe NVARCHAR(10) PRIMARY KEY,
    TenLoaiVe NVARCHAR(100),
    PhuThu DECIMAL(10,2) DEFAULT 0
);

-- 7. Khách hàng
CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);

-- 8. Vé
CREATE TABLE Ve (
    MaVe UNIQUEIDENTIFIER PRIMARY KEY,
    MaLichChieu NVARCHAR(10) NULL,
    MaLoaiVe NVARCHAR(10) NULL,
    MaKhachHang NVARCHAR(10) NULL,
    SoGhe NVARCHAR(10) NOT NULL,
    NgayDat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaLichChieu) REFERENCES LichChieu(MaLichChieu) ON DELETE SET NULL,
    FOREIGN KEY (MaLoaiVe) REFERENCES LoaiVe(MaLoaiVe) ON DELETE SET NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE SET NULL
);

-- 9. Đơn hàng (Hóa đơn)
CREATE TABLE DonHang (
    MaDonHang NVARCHAR(50) PRIMARY KEY,
    MaKhachHang NVARCHAR(10) NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(12,2),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE SET NULL
);

-- 10. Món ăn
CREATE TABLE DoAn (
    MaDoAn NVARCHAR(10) PRIMARY KEY,
    TenDoAn NVARCHAR(100),
    Gia DECIMAL(10,2),
    MoTa NVARCHAR(255)
);

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

-- 12. Báo cáo
CREATE TABLE BaoCao (
    MaBaoCao NVARCHAR(10) PRIMARY KEY,
    TieuDe NVARCHAR(200),
    NoiDung NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NguoiTao NVARCHAR(10) NULL,
    FOREIGN KEY (NguoiTao) REFERENCES NguoiDung(MaNguoiDung) ON DELETE SET NULL
);
CREATE TABLE GiaoDich (
    MaGiaoDich NVARCHAR(50) PRIMARY KEY,
    MaXacNhan NVARCHAR(10) NOT NULL UNIQUE,
    MaKhachHang NVARCHAR(10) NOT NULL,
    MaDonHang NVARCHAR(10) NULL, -- Có thể null nếu không mua đồ ăn
    NgayGiaoDich DATETIME NOT NULL,
    TongTien DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);
ALTER TABLE GiaoDich
ADD TrangThai NVARCHAR(20) DEFAULT 'ChuaXuLy' CHECK (TrangThai IN ('ChuaXuLy', 'DaXuLy'));

ALTER TABLE Ve
ADD MaGiaoDich NVARCHAR(50) NULL;

ALTER TABLE Ve
ADD CONSTRAINT FK_Ve_MaGiaoDich FOREIGN KEY (MaGiaoDich) REFERENCES GiaoDich(MaGiaoDich);
STT | Form Tên | Quản lý đối tượng | Gọi từ BUS
1 | frmNguoiDung | Người dùng | NguoiDungBUS
2 | frmPhongChieu | Phòng chiếu | PhongChieuBUS
3 | frmTheLoaiPhim | Thể loại phim | TheLoaiPhimBUS
4 | frmPhim | Phim | PhimBUS
5 | frmLichChieu | Lịch chiếu | LichChieuBUS
6 | frmLoaiVe | Loại vé | LoaiVeBUS
7 | frmKhachHang | Khách hàng | KhachHangBUS
8 | frmVe | Vé (bán vé) | VeBUS
9 | frmDonHang | Hóa đơn mua đồ ăn | DonHangBUS
10 | frmChiTietDoAn | Chi tiết đơn đồ ăn | ChiTietDoAnBUS
11 | frmDoAn | Món ăn | DoAnBUS
12 | frmBaoCao | Báo cáo | BaoCaoBUS

✅ 4. Form Tiện ích khác (nếu cần)
frmDangKy: Tạo tài khoản mới

frmXemPhim: Dành cho khách xem danh sách phim

frmDatVe: Chọn lịch chiếu, ghế, vé → tạo Ve

frmHoaDonCaNhan: Xem vé đã đặt hoặc đơn hàng

frmThongTinCaNhan: Thay đổi thông tin người dùng





-- 1. Người dùng
INSERT INTO NguoiDung VALUES
('ND01', 'admin01', 'matkhau123', 'admin', GETDATE()),
('ND02', 'nhanvien01', 'nvpass01', 'nhanvien', GETDATE()),
('ND03', 'khach01', 'khachpass', 'khach', GETDATE()),
('ND04', 'khach02', 'khach02pass', 'khach', GETDATE()),
('ND05', 'nhanvien02', 'nvpass02', 'nhanvien', GETDATE());

-- 2. Phòng chiếu
INSERT INTO PhongChieu VALUES
('P01', 'Phòng 1', 100, 'hoatdong'),
('P02', 'Phòng 2', 80, 'hoatdong'),
('P03', 'Phòng 3', 50, 'baotri'),
('P04', 'Phòng 4', 120, 'hoatdong'),
('P05', 'Phòng 5', 70, 'hoatdong');

-- 3. Thể loại phim
INSERT INTO TheLoaiPhim VALUES
('TL01', 'Hành động'),
('TL02', 'Hài'),
('TL03', 'Kinh dị'),
('TL04', 'Tình cảm'),
('TL05', 'Viễn tưởng');

-- 4. Phim
INSERT INTO Phim VALUES
('PH01', 'Avengers: Endgame', 'TL01', 180, N'Phim siêu anh hùng của Marvel.'),
('PH02', 'Jumanji', 'TL02', 120, N'Trò chơi kỳ lạ và hài hước.'),
('PH03', 'Annabelle', 'TL03', 95, N'Búp bê ma ám đáng sợ.'),
('PH04', 'The Notebook', 'TL04', 123, N'Tình yêu và ký ức.'),
('PH05', 'Interstellar', 'TL05', 169, N'Hành trình vượt không gian.');

-- 5. Lịch chiếu
INSERT INTO LichChieu VALUES
('LC01', 'PH01', 'P01', '2025-04-21 18:00', 90000),
('LC02', 'PH02', 'P02', '2025-04-21 20:00', 75000),
('LC03', 'PH03', 'P03', '2025-04-22 21:30', 80000),
('LC04', 'PH04', 'P04', '2025-04-22 19:00', 85000),
('LC05', 'PH05', 'P05', '2025-04-23 17:00', 95000);

-- 6. Loại vé
INSERT INTO LoaiVe VALUES
('LV01', 'Vé thường', 0),
('LV02', 'Vé VIP', 20000),
('LV03', 'Vé trẻ em', -10000),
('LV04', 'Vé sinh viên', -5000),
('LV05', 'Vé đôi', 15000);

-- 7. Khách hàng
INSERT INTO KhachHang VALUES
('KH01', N'Nguyễn Văn A', '0901234567', 'a@gmail.com'),
('KH02', N'Lê Thị B', '0902345678', 'b@gmail.com'),
('KH03', N'Trần Văn C', '0903456789', 'c@gmail.com'),
('KH04', N'Phạm Thị D', '0904567890', 'd@gmail.com'),
('KH05', N'Hoàng Văn E', '0905678901', 'e@gmail.com');

-- 8. Vé
INSERT INTO Ve VALUES
(NEWID(), 'LC01', 'LV01', 'KH01', 'A1', GETDATE()),
(NEWID(), 'LC02', 'LV02', 'KH02', 'B2', GETDATE()),
(NEWID(), 'LC03', 'LV03', 'KH03', 'C3', GETDATE()),
(NEWID(), 'LC04', 'LV01', 'KH04', 'D4', GETDATE()),
(NEWID(), 'LC05', 'LV05', 'KH05', 'E5', GETDATE());


-- 9. Đơn hàng
INSERT INTO DonHang VALUES
('DH01', 'KH01', GETDATE(), 150000),
('DH02', 'KH02', GETDATE(), 100000),
('DH03', 'KH03', GETDATE(), 120000),
('DH04', 'KH04', GETDATE(), 90000),
('DH05', 'KH05', GETDATE(), 180000);

-- 10. Món ăn
INSERT INTO DoAn VALUES
('DA01', N'Bắp rang bơ', 30000, N'Ngon và giòn'),
('DA02', N'Coca-Cola', 20000, N'Nước giải khát'),
('DA03', N'Pepsi', 18000, N'Có ga mát lạnh'),
('DA04', N'Nước suối', 10000, N'Không đường'),
('DA05', N'Snack', 15000, N'Ăn nhẹ');

-- 11. Chi tiết đơn hàng đồ ăn
INSERT INTO ChiTietDoAn VALUES
('CT01', 'DH01', 'DA01', 2, 30000, NULL),
('CT02', 'DH02', 'DA02', 1, 20000, NULL),
('CT03', 'DH03', 'DA03', 3, 18000, NULL),
('CT04', 'DH04', 'DA04', 2, 10000, NULL),
('CT05', 'DH05', 'DA05', 5, 15000, NULL);

-- 12. Báo cáo
INSERT INTO BaoCao VALUES
('BC01', N'Thống kê vé bán', N'Báo cáo số lượng vé bán theo ngày', GETDATE(), 'ND01'),
('BC02', N'Doanh thu tuần', N'Doanh thu theo từng tuần', GETDATE(), 'ND02'),
('BC03', N'Thống kê khách hàng', N'Danh sách khách hàng đặt vé', GETDATE(), 'ND01'),
('BC04', N'Thống kê món ăn', N'Số lượng món ăn bán ra', GETDATE(), 'ND03'),
('BC05', N'Tổng hợp báo cáo', N'Tổng hợp các báo cáo chi tiết', GETDATE(), 'ND01');

