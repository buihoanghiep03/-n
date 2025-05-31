using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyNhanSu
{
    public string Id { get; set; } = null!;

    public string? TenNhanSu { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Cccd { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public string? LoaiNhanSu { get; set; }

    public string? CongViec { get; set; }

    public decimal? LuongCoBan { get; set; }

    public string? AnhTt { get; set; }
}
