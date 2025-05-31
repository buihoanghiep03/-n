using DoAnQLThuVien.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NPOI.SS.Formula.Atp;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for ThemSach.xaml
    /// </summary>
    public partial class ThemDauSach : Window
    {
        public DatnContext context = new DatnContext();
        public ThemDauSach()
        {
            InitializeComponent();

            ngayNhapSachdp.SelectedDate = DateTime.Now;

            // Lấy danh sách nhóm loại sách
            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            nhomSachcb.ItemsSource = nhomLoaiSaches;
            nhomSachcb.DisplayMemberPath = "TenNhomSach";
            nhomSachcb.SelectedIndex = 0;

            // Lấy danh sách nhóm loại sách
            var quanLyNhaXuatBans = context.QuanLyNhaXuatBans.ToList();
            nhaXuatBancb.ItemsSource = quanLyNhaXuatBans;
            nhaXuatBancb.DisplayMemberPath = "TenNhaXuatBan";
            nhaXuatBancb.SelectedIndex = 0;

            // Lấy danh sách các năm xuất bản (ví dụ từ 1950 đến năm hiện tại)
            int currentYear = DateTime.Now.Year;
            var namXuatBan = Enumerable.Range(1950, currentYear - 1950 + 1)
                                       .Reverse() // Đảo ngược danh sách
                                       .ToList();
            namXuatBancb.ItemsSource = namXuatBan;
            namXuatBancb.SelectedIndex = 0;

            // Gán sự kiện khi nhóm sách thay đổi
            nhomSachcb.SelectionChanged += nhomSachcb_SelectionChanged;

            // Gán sự kiện khi thể loại sách thay đổi
            TheLoaicb.SelectionChanged += TheLoaicb_SelectionChanged;

            UpdateTheLoaiComboBox();
            GenerateNextBookId();

            // Gán danh sách ngôn ngữ cho ComboBox
            ngonNgucb.ItemsSource = new string[]{
                "Tiếng Việt", "Tiếng Anh", "Tiếng Pháp", "Tiếng Đức", "Tiếng Tây Ban Nha",
                "Tiếng Trung Quốc", "Tiếng Nhật Bản", "Tiếng Hàn Quốc", "Tiếng Thái Lan", "Tiếng Nga", "Ngôn ngữ khác"};
            ngonNgucb.SelectedIndex = 0; // Chọn giá trị đầu tiên mặc định

            gioiHanNguoiDoccb.ItemsSource = new string[] { "Không giới hạn", "Thiếu niên" ,"Người trưởng thành", "Nhà nghiên cứu", "Đối tượng đặc biệt" };
            gioiHanNguoiDoccb.SelectedIndex = 0;
        }

        private void ThemSachbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(namXuatBancb.Text, out int namXuatBan))
                {
                    MessageBox.Show("Vui lòng nhập đúng số cho năm xuất bản và số lượng sách!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (TheLoaicb.SelectedItem is not TheLoaiSach selectedTheLoai ||
                    nhomSachcb.SelectedItem is not NhomLoaiSach selectedNhom)
                {
                    MessageBox.Show("Vui lòng chọn nhóm thể loại và thể loại sách!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenSachtxt.Text) ||
                    string.IsNullOrWhiteSpace(tacGiatxt.Text) ||
                    string.IsNullOrWhiteSpace(nhaXuatBancb.Text) ||
                    string.IsNullOrWhiteSpace(ISBNtxt.Text) ||
                    string.IsNullOrWhiteSpace(ngayNhapSachdp.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int GetIntValue(TextBox textBox)
                {
                    return int.TryParse(textBox.Text, out int value) ? value : 0;
                }

                int soLuongSachMoi = GetIntValue(soLuongSachMoitxt);
                int soLuongSachBinhThuong = GetIntValue(soLuongSachBinhThuongtxt);
                int soLuongSachCu = GetIntValue(soLuongSachCutxt);
                int soLuongSachHongNhe = GetIntValue(soLuongSachHongNhetxt);
                int soLuongSachHongNang = GetIntValue(soLuongSachHongNangtxt);

                int tongSoSach = soLuongSachMoi + soLuongSachBinhThuong + soLuongSachCu + soLuongSachHongNhe + soLuongSachHongNang;

                if (tongSoSach == 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng sách hợp lệ!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var sachID = $"{sachNTLIDtxt.Text}-{sachTLIDtxt.Text}-{sachIDtxt.Text}";

                var sachMoi = new QuanLyDauSach
                {
                    Id = sachID,
                    TenSach = tenSachtxt.Text,
                    NhomSach = selectedNhom.TenNhomSach,
                    TheLoai = selectedTheLoai.TheLoai,
                    TacGia = tacGiatxt.Text,
                    NhaXuatBan = nhaXuatBancb.Text,
                    NamXuatBan = namXuatBan,
                    NgonNgu = ngonNgucb.Text,
                    Isbn = ISBNtxt.Text,
                    NgayNhapSach = DateOnly.Parse(ngayNhapSachdp.Text),
                    GioiHanDocGia = gioiHanNguoiDoccb.Text,
                    TongSoSach = tongSoSach,
                    SoLuongTrongThuVien = tongSoSach,
                    SoLuongMuon = 0,
                    SoLuongMat = 0,
                    AnhBia = anhSachImage.Source is BitmapImage bitmap ? bitmap.UriSource?.LocalPath : null
                };

                context.QuanLyDauSaches.Add(sachMoi);

                // Cập nhật số lượng sách trong nhóm thể loại và thể loại
                var nhomSach = context.NhomLoaiSaches.FirstOrDefault(n => n.TenNhomSach == selectedNhom.TenNhomSach);
                if (nhomSach != null)
                {
                    nhomSach.SoLuongSach += tongSoSach;
                }

                var theLoaiSach = context.TheLoaiSaches.FirstOrDefault(t => t.TheLoai == selectedTheLoai.TheLoai);
                if (theLoaiSach != null)
                {
                    theLoaiSach.SoLuongSach += tongSoSach;
                }

                // Thêm sách vào ChiTietSach
                int soThuTu = 1;
                for (int i = 0; i < tongSoSach; i++)
                {
                    string tinhTrangSach;
                    if (i < soLuongSachMoi)
                        tinhTrangSach = "Mới";
                    else if (i < soLuongSachMoi + soLuongSachBinhThuong)
                        tinhTrangSach = "Bình thường";
                    else if (i < soLuongSachMoi + soLuongSachBinhThuong + soLuongSachCu)
                        tinhTrangSach = "Cũ";
                    else if (i < soLuongSachMoi + soLuongSachBinhThuong + soLuongSachCu + soLuongSachHongNhe)
                        tinhTrangSach = "Hư hỏng nhẹ";
                    else
                        tinhTrangSach = "Hư hỏng nặng";

                    string tinhTrangMuon = (tinhTrangSach == "Mới" || tinhTrangSach == "Bình thường") ? "Khả dụng" : "Không khả dụng";

                    var chiTietSach = new ChiTietSach
                    {
                        Id = $"{sachID}-{soThuTu:D3}",
                        TenSach = tenSachtxt.Text,
                        NhomTheLoai = selectedNhom.TenNhomSach,
                        TheLoai = selectedTheLoai.TheLoai,
                        TacGia = tacGiatxt.Text,
                        NhaXuatBan = nhaXuatBancb.Text,
                        NamXuatBan = namXuatBan,
                        Isbn = ISBNtxt.Text,
                        NgonNgu = ngonNgucb.Text,
                        NgayNhapSach = DateOnly.Parse(ngayNhapSachdp.Text),
                        GioiHanDocGia = gioiHanNguoiDoccb.Text,
                        TinhTrangSach = tinhTrangSach,
                        TinhTrangMuon = tinhTrangMuon,
                        KeSach = "Trong kho",
                        AnhBia = anhSachImage.Source is BitmapImage imageBitmap ? imageBitmap.UriSource?.LocalPath : null
                    };

                    context.ChiTietSaches.Add(chiTietSach);
                    soThuTu++;
                }

                context.SaveChanges();
                MessageBox.Show("Thêm dữ liệu đầu sách và chi tiết sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateNextBookId()
        {
            using (var context = new DatnContext()) // Thay bằng DbContext của bạn
            {
                string prefix = $"{sachNTLIDtxt.Text}-{sachTLIDtxt.Text}-"; // Tiền tố ID từ các phần đã nhập
                var existingIds = context.QuanLyDauSaches
                    .Where(q => q.Id.StartsWith(prefix))
                    .Select(q => q.Id)
                    .ToList();

                if (existingIds.Count == 0)
                {
                    sachIDtxt.Text = "0000001"; // Nếu chưa có sách nào, bắt đầu từ 0000001
                    return;
                }

                // Lấy số lớn nhất từ danh sách ID
                int maxNumber = existingIds
                    .Select(id => ExtractNumber(id))
                    .DefaultIfEmpty(0)
                    .Max();

                // Tăng số đầu sách
                int nextNumber = maxNumber + 1;

                // Xác định số chữ số cần có: tối thiểu 7 số, nếu lớn hơn thì giữ nguyên độ dài
                int minDigits = Math.Max(7, nextNumber.ToString().Length);

                // Định dạng số thành chuỗi với số chữ số phù hợp
                sachIDtxt.Text = nextNumber.ToString($"D{minDigits}");
            }
        }

        // Hàm lấy số cuối cùng sau dấu "-"
        private int ExtractNumber(string id)
        {
            string[] parts = id.Split('-');
            if (parts.Length > 0 && int.TryParse(parts.Last(), out int number))
            {
                return number;
            }
            return 0;
        }

        private void UpdateTheLoaiComboBox()
        {

            if (nhomSachcb.SelectedItem is NhomLoaiSach selectedNhom)
            {
                // Cập nhật TheLoaicb theo nhóm loại sách
                var theLoaiSaches = context.TheLoaiSaches
                    .Where(t => t.NhomLoaiSach == selectedNhom.TenNhomSach)
                    .ToList();

                TheLoaicb.ItemsSource = theLoaiSaches;
                TheLoaicb.DisplayMemberPath = "TheLoai";

                // Chọn mục đầu tiên nếu có dữ liệu
                TheLoaicb.SelectedIndex = theLoaiSaches.Count > 0 ? 0 : -1;

                // Hiển thị mã tắt của nhóm thể loại trong sachNTLIDtxt.Text
                sachNTLIDtxt.Text = selectedNhom.MaTat;
            }
        }

        private void nhomSachcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTheLoaiComboBox();
        }

        private void TheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TheLoaicb.SelectedItem is TheLoaiSach selectedTheLoai)
            {
                // Hiển thị mã tắt của thể loại trong sachTLIDtxt.Text
                sachTLIDtxt.Text = selectedTheLoai.MaTat;
            }
        }


        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void browsebtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif",
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(dialog.FileName, UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    anhSachImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
