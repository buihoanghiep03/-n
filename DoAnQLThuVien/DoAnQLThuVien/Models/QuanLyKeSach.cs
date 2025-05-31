using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyKeSach
{
    public string Id { get; set; } = null!;

    public string? TenKeSach { get; set; }

    public string? LoaiKeSach { get; set; }

    public string? NhomTheLoaiKe { get; set; }

    public string? ViTriKe { get; set; }

    public int? SoLuongSachToiDa { get; set; }

    public int? SoLuongSachHienTai { get; set; }
}
