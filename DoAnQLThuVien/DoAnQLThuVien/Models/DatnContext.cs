using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnQLThuVien.Models;

public partial class DatnContext : DbContext
{
    public DatnContext()
    {
    }

    public DatnContext(DbContextOptions<DatnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietSach> ChiTietSaches { get; set; }

    public virtual DbSet<NhomLoaiSach> NhomLoaiSaches { get; set; }

    public virtual DbSet<QuanLyChamCong> QuanLyChamCongs { get; set; }

    public virtual DbSet<QuanLyCongViec> QuanLyCongViecs { get; set; }

    public virtual DbSet<QuanLyDauSach> QuanLyDauSaches { get; set; }

    public virtual DbSet<QuanLyDocGium> QuanLyDocGia { get; set; }

    public virtual DbSet<QuanLyKeSach> QuanLyKeSaches { get; set; }

    public virtual DbSet<QuanLyMuonSach> QuanLyMuonSaches { get; set; }

    public virtual DbSet<QuanLyNhaXuatBan> QuanLyNhaXuatBans { get; set; }

    public virtual DbSet<QuanLyNhanSu> QuanLyNhanSus { get; set; }

    public virtual DbSet<QuanLyPhongDoc> QuanLyPhongDocs { get; set; }

    public virtual DbSet<SoSachTrenKe> SoSachTrenKes { get; set; }

    public virtual DbSet<TaiKhoanQuanLy> TaiKhoanQuanLies { get; set; }

    public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

    public virtual DbSet<TheoDoiDangNhap> TheoDoiDangNhaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= DESKTOP-1DC3TC4;Initial Catalog=DATN;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietSach>(entity =>
        {
            entity.HasKey(e => e.Stt).HasName("PK_DanhSachSach");

            entity.ToTable("ChiTietSach");

            entity.Property(e => e.GioiHanDocGia).HasMaxLength(50);
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.KeSach).HasMaxLength(50);
            entity.Property(e => e.NgonNgu).HasMaxLength(50);
            entity.Property(e => e.NhaXuatBan).HasMaxLength(50);
            entity.Property(e => e.NhomTheLoai).HasMaxLength(50);
            entity.Property(e => e.TacGia).HasMaxLength(50);
            entity.Property(e => e.TenSach).HasMaxLength(50);
            entity.Property(e => e.TheLoai).HasMaxLength(50);
            entity.Property(e => e.TinhTrangMuon).HasMaxLength(50);
            entity.Property(e => e.TinhTrangSach).HasMaxLength(50);
        });

        modelBuilder.Entity<NhomLoaiSach>(entity =>
        {
            entity.ToTable("NhomLoaiSach");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.MaTat).HasMaxLength(50);
            entity.Property(e => e.TenNhomSach).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyChamCong>(entity =>
        {
            entity.HasKey(e => e.No);

            entity.ToTable("QuanLyChamCong");

            entity.Property(e => e.NhanVienId).HasMaxLength(50);
            entity.Property(e => e.ThangChamCong).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyCongViec>(entity =>
        {
            entity.ToTable("QuanLyCongViec");

            entity.Property(e => e.CongViec).HasMaxLength(50);
            entity.Property(e => e.LoaiCongViec).HasMaxLength(50);
            entity.Property(e => e.LuongCoBan).HasColumnType("money");
            entity.Property(e => e.MaTat).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyDauSach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QuanLySach");

            entity.ToTable("QuanLyDauSach");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.GioiHanDocGia).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.NgonNgu).HasMaxLength(50);
            entity.Property(e => e.NhaXuatBan).HasMaxLength(50);
            entity.Property(e => e.NhomSach).HasMaxLength(50);
            entity.Property(e => e.TacGia).HasMaxLength(50);
            entity.Property(e => e.TenSach).HasMaxLength(100);
            entity.Property(e => e.TheLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyDocGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QuanLyHoiVien");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.AnhDg).HasColumnName("AnhDG");
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.LoaiDocGia).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.TrangThaiDocGia).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyKeSach>(entity =>
        {
            entity.ToTable("QuanLyKeSach");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.LoaiKeSach).HasMaxLength(100);
            entity.Property(e => e.NhomTheLoaiKe).HasMaxLength(100);
            entity.Property(e => e.TenKeSach).HasMaxLength(100);
            entity.Property(e => e.ViTriKe).HasMaxLength(100);
        });

        modelBuilder.Entity<QuanLyMuonSach>(entity =>
        {
            entity.ToTable("QuanLyMuonSach");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.DocGiaId)
                .HasMaxLength(50)
                .HasColumnName("DocGiaID");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.IdsachMuon1)
                .HasMaxLength(50)
                .HasColumnName("IDSachMuon1");
            entity.Property(e => e.IdsachMuon2)
                .HasMaxLength(50)
                .HasColumnName("IDSachMuon2");
            entity.Property(e => e.IdsachMuon3)
                .HasMaxLength(50)
                .HasColumnName("IDSachMuon3");
            entity.Property(e => e.PhiGiaHan).HasColumnType("money");
            entity.Property(e => e.TenDocGia).HasMaxLength(50);
            entity.Property(e => e.TienBoiThuong).HasColumnType("money");
            entity.Property(e => e.TinhTrangBoiThuong).HasMaxLength(50);
            entity.Property(e => e.TinhTrangKhiTra1).HasMaxLength(50);
            entity.Property(e => e.TinhTrangKhiTra2).HasMaxLength(50);
            entity.Property(e => e.TinhTrangKhiTra3).HasMaxLength(50);
            entity.Property(e => e.TinhTrangMuonTra).HasMaxLength(50);
            entity.Property(e => e.TinhTrangSach1).HasMaxLength(50);
            entity.Property(e => e.TinhTrangSach2).HasMaxLength(50);
            entity.Property(e => e.TinhTrangSach3).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyNhaXuatBan>(entity =>
        {
            entity.ToTable("QuanLyNhaXuatBan");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Gmail).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhaXuatBan).HasMaxLength(100);
        });

        modelBuilder.Entity<QuanLyNhanSu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QuanLyNhanVien");

            entity.ToTable("QuanLyNhanSu");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.AnhTt).HasColumnName("AnhTT");
            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .HasColumnName("CCCD");
            entity.Property(e => e.CongViec).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.LoaiNhanSu).HasMaxLength(50);
            entity.Property(e => e.LuongCoBan).HasColumnType("money");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhanSu).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyPhongDoc>(entity =>
        {
            entity.ToTable("QuanLyPhongDoc");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.GioiHanDocGia).HasMaxLength(50);
            entity.Property(e => e.LoaiPhongDoc).HasMaxLength(50);
            entity.Property(e => e.TenPhongDoc).HasMaxLength(100);
            entity.Property(e => e.ViTriPhongDoc).HasMaxLength(100);
        });

        modelBuilder.Entity<SoSachTrenKe>(entity =>
        {
            entity.HasKey(e => e.Stt);

            entity.ToTable("SoSachTrenKe");

            entity.Property(e => e.KeSachId).HasMaxLength(50);
            entity.Property(e => e.SachId).HasMaxLength(50);
        });

        modelBuilder.Entity<TaiKhoanQuanLy>(entity =>
        {
            entity.HasKey(e => e.Stt).HasName("PK_QuanLyTaiKhoan");

            entity.ToTable("TaiKhoanQuanLy");

            entity.Property(e => e.LoaiTk).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(500);
            entity.Property(e => e.NguoiDungId).HasMaxLength(50);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
        });

        modelBuilder.Entity<TheLoaiSach>(entity =>
        {
            entity.ToTable("TheLoaiSach");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.MaTat).HasMaxLength(50);
            entity.Property(e => e.NhomLoaiSach).HasMaxLength(50);
            entity.Property(e => e.TheLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<TheoDoiDangNhap>(entity =>
        {
            entity.HasKey(e => e.Stt);

            entity.ToTable("TheoDoiDangNhap");

            entity.Property(e => e.LoaiTk)
                .HasMaxLength(50)
                .HasColumnName("LoaiTK");
            entity.Property(e => e.ThoiDiemDangNhap).HasMaxLength(50);
            entity.Property(e => e.ThoiDiemDangXuat).HasMaxLength(50);
            entity.Property(e => e.TkdangNhap)
                .HasMaxLength(50)
                .HasColumnName("TKDangNhap");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
