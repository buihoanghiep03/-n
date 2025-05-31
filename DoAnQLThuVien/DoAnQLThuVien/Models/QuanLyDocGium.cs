using System;
using System.Collections.Generic;

namespace DoAnQLThuVien.Models;

public partial class QuanLyDocGium
{
    public string Id { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? SoCccd { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? LoaiDocGia { get; set; }

    public DateOnly? NgayDangKy { get; set; }

    public DateOnly? NgayLamThe { get; set; }

    public DateOnly? NgayHetHanThe { get; set; }

    public string? TrangThaiDocGia { get; set; }

    public string? AnhDg { get; set; }
}
