ALTER TABLE dbo.khuyenMaiSP
ADD CONSTRAINT CK_khuyenMaiSP_LoaiKM_GiaTriKM
CHECK (
    (LoaiKM = 'phantram' AND GiaTriKM BETWEEN 0 AND 100)
    OR
    (LoaiKM = 'trigia' AND GiaTriKM BETWEEN 0 AND 10000000)
);
ALTER TABLE dbo.khuyenMaiSP
ADD LoaiKM NVARCHAR(20);  -- 'phantram' hoặc 'trigia'
-- Khuyến mãi 20%
INSERT INTO dbo.khuyenMaiSP (TenKM, GiaTriKM, ngayBatDau, ngayKetThuc, trangThaiCT, ghiChu, giftcode, LoaiKM)
VALUES (N'Khuyến mãi hè', 20, '2025-05-01', '2025-05-31', N'Đang áp dụng', N'Áp dụng toàn quốc', 'HE2025', 'phantram');

-- Khuyến mãi giảm 500,000 VNĐ
INSERT INTO dbo.khuyenMaiSP (TenKM, GiaTriKM, ngayBatDau, ngayKetThuc, trangThaiCT, ghiChu, giftcode, LoaiKM)
VALUES (N'Khuyến mãi tiền mặt', 500000, '2025-05-01', '2025-05-31', N'Đang áp dụng', N'Áp dụng đơn hàng > 5tr', 'TIENMAT2025', 'trigia');
ALTER TABLE khuyenMaiSP
ALTER COLUMN GiaTriKM BIGINT;


select * from khuyenMaiSP;

-- Bước 1: Xóa constraint
ALTER TABLE khuyenMaiSP DROP CONSTRAINT CK_khuyenMaiSP_LoaiKM_GiaTriKM;

-- Bước 2: Đổi kiểu dữ liệu
ALTER TABLE khuyenMaiSP ALTER COLUMN GiaTriKM DECIMAL(18, 2);

-- Bước 3 (tuỳ chọn): Tạo lại constraint nếu cần
-- Ví dụ nếu constraint cũ là kiểm tra Giá trị từ 0 đến 100
ALTER TABLE khuyenMaiSP ADD CONSTRAINT CK_khuyenMaiSP_LoaiKM_GiaTriKM
CHECK (
    (LoaiKM = 'phantram' AND GiaTriKM BETWEEN 0 AND 100) OR
    (LoaiKM = 'trigia' AND GiaTriKM BETWEEN 0 AND 100000000000)
);
