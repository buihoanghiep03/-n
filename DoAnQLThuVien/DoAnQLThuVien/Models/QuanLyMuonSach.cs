using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyMuonSach
{
    public string Id { get; set; } = null!;

    public string? DocGiaId { get; set; }

    public string? TenDocGia { get; set; }

    public int? SoLuongMuon { get; set; }

    public DateOnly? NgayMuon { get; set; }

    public DateOnly? NgayHenTra { get; set; }

    public DateOnly? NgayGiaHanTra1 { get; set; }

    public DateOnly? NgayGiaHanTra2 { get; set; }

    public decimal? PhiGiaHan { get; set; }

    public DateOnly? NgayTraThucTe { get; set; }

    public string? TinhTrangMuonTra { get; set; }

    public string? GhiChu { get; set; }

    public string? IdsachMuon1 { get; set; }

    public string? TenSach1 { get; set; }

    public string? TinhTrangSach1 { get; set; }

    public string? TinhTrangKhiTra1 { get; set; }

    public string? IdsachMuon2 { get; set; }

    public string? TenSach2 { get; set; }

    public string? TinhTrangSach2 { get; set; }

    public string? TinhTrangKhiTra2 { get; set; }

    public string? IdsachMuon3 { get; set; }

    public string? TenSach3 { get; set; }

    public string? TinhTrangSach3 { get; set; }

    public string? TinhTrangKhiTra3 { get; set; }

    public string? TinhTrangBoiThuong { get; set; }

    public decimal? TienBoiThuong { get; set; }
}
