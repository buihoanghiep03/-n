using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class TheLoaiSach
{
    public string Id { get; set; } = null!;

    public string? NhomLoaiSach { get; set; }

    public string? TheLoai { get; set; }

    public string? MaTat { get; set; }

    public int? SoLuongSach { get; set; }
}
