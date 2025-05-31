using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyNhaXuatBan
{
    public string Id { get; set; } = null!;

    public string? TenNhaXuatBan { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Gmail { get; set; }
}
