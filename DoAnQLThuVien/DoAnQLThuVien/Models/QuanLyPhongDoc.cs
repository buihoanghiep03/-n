using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyPhongDoc
{
    public string Id { get; set; } = null!;

    public string? TenPhongDoc { get; set; }

    public string? LoaiPhongDoc { get; set; }

    public string? GioiHanDocGia { get; set; }

    public string? ViTriPhongDoc { get; set; }

    public int? SoLuongKeSach { get; set; }
}
