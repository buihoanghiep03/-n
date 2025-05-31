using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class NhomLoaiSach
{
    public string Id { get; set; } = null!;

    public string? TenNhomSach { get; set; }

    public string? MaTat { get; set; }

    public int? SoLuongTheLoai { get; set; }

    public int? SoLuongSach { get; set; }
}
