using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyCongViec
{
    public int Id { get; set; }

    public string? LoaiCongViec { get; set; }

    public string? CongViec { get; set; }

    public string? MaTat { get; set; }

    public decimal? LuongCoBan { get; set; }

    public int? SoLuongNguoiLam { get; set; }
}
