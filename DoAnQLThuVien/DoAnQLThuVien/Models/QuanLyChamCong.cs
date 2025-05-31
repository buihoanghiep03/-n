using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyChamCong
{
    public int No { get; set; }

    public string? NhanVienId { get; set; }

    public int? TongNgayChamCong { get; set; }

    public string? ThangChamCong { get; set; }

    public int? SoNgayChamCongTrenThang { get; set; }

    public DateOnly? NgayChamCong { get; set; }

    public DateOnly? ChamLanDau { get; set; }

    public DateOnly? ChamLanCuoi { get; set; }
}
