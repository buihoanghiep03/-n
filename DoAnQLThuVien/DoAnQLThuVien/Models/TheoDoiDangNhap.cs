using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class TheoDoiDangNhap
{
    public int Stt { get; set; }

    public string? TkdangNhap { get; set; }

    public string? LoaiTk { get; set; }

    public DateOnly? NgayDangNhap { get; set; }

    public string? ThoiDiemDangNhap { get; set; }

    public string? ThoiDiemDangXuat { get; set; }
}
