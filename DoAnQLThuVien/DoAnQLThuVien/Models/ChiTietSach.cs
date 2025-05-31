using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class ChiTietSach
{
    public int Stt { get; set; }

    public string? Id { get; set; }

    public string? TenSach { get; set; }

    public string? NhomTheLoai { get; set; }

    public string? TheLoai { get; set; }

    public string? TacGia { get; set; }

    public string? NhaXuatBan { get; set; }

    public int? NamXuatBan { get; set; }

    public string? NgonNgu { get; set; }

    public string? Isbn { get; set; }

    public DateOnly? NgayNhapSach { get; set; }

    public string? GioiHanDocGia { get; set; }

    public string? TinhTrangSach { get; set; }

    public string? TinhTrangMuon { get; set; }

    public string? KeSach { get; set; }

    public string? AnhBia { get; set; }
}
