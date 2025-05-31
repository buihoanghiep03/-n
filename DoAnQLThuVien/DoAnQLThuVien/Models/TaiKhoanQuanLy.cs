using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class TaiKhoanQuanLy
{
    public int Stt { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public DateOnly? NgayTao { get; set; }

    public string? NguoiDungId { get; set; }

    public string? LoaiTk { get; set; }
}
