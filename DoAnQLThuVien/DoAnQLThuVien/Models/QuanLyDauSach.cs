using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyDauSach
{
    public string Id { get; set; } = null!;

    public string? TenSach { get; set; }

    public string? NhomSach { get; set; }

    public string? TheLoai { get; set; }

    public string? TacGia { get; set; }

    public string? NhaXuatBan { get; set; }

    public int? NamXuatBan { get; set; }

    public string? Isbn { get; set; }

    public string? NgonNgu { get; set; }

    public DateOnly? NgayNhapSach { get; set; }

    public string? GioiHanDocGia { get; set; }

    public int? TongSoSach { get; set; }

    public int? SoLuongTrongThuVien { get; set; }

    public int? SoLuongMuon { get; set; }

    public int? SoLuongMat { get; set; }

    public string? AnhBia { get; set; }
}
