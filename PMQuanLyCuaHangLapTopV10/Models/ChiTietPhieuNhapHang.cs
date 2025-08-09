public class ChiTietPhieuNhapHang
{
    public string MaPNH { get; set; }
    public string MaSP { get; set; }
    public int SoLuongNhap { get; set; }
    public decimal DonGiaNhap { get; set; }
    public decimal ThanhTien { get; set; }

    public ChiTietPhieuNhapHang(string maPNH, string maSP, int soLuongNhap, decimal donGiaNhap, decimal thanhTien)
    {
        MaPNH = maPNH;
        MaSP = maSP;
        SoLuongNhap = soLuongNhap;
        DonGiaNhap = donGiaNhap;
        ThanhTien = thanhTien;
    }

    public override string ToString()
    {
        return $"Mã phiếu nhập hàng: {MaPNH}, Mã sản phẩm: {MaSP}, Số lượng nhập: {SoLuongNhap}, Đơn giá nhập: {DonGiaNhap}, Thành tiền: {ThanhTien}";
    }
}
