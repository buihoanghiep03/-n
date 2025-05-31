using DoAnQLThuVien.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for SuaSach.xaml
    /// </summary>
    public partial class SuaDauSach : Window
    {
        public DatnContext context = new DatnContext();
        private QuanLyDauSach currentNameBook;
        private ChiTietSach currentBook;
        public SuaDauSach(QuanLyDauSach book)
        {
            InitializeComponent();

            // Lấy danh sách nhóm loại sách
            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            nhomSachcb.ItemsSource = nhomLoaiSaches;
            nhomSachcb.DisplayMemberPath = "TenNhomSach";

            // Lấy danh sách nhóm loại sách
            var quanLyNhaXuatBans = context.QuanLyNhaXuatBans.ToList();
            nhaXuatBancb.ItemsSource = quanLyNhaXuatBans;
            nhaXuatBancb.DisplayMemberPath = "TenNhaXuatBan";

            // Lấy danh sách các năm xuất bản (ví dụ từ 1950 đến năm hiện tại)
            int currentYear = DateTime.Now.Year;
            var namXuatBan = Enumerable.Range(1950, currentYear - 1950 + 1)
                                       .Reverse() // Đảo ngược danh sách
                                       .ToList();
            namXuatBancb.ItemsSource = namXuatBan;

            // Gán sự kiện khi nhóm sách thay đổi
            nhomSachcb.SelectionChanged += nhomSachcb_SelectionChanged;

            // Gán sự kiện khi thể loại sách thay đổi
            TheLoaicb.SelectionChanged += TheLoaicb_SelectionChanged;

            UpdateTheLoaiComboBox();

            // Gán danh sách ngôn ngữ cho ComboBox
            ngonNgucb.ItemsSource = new string[]{
                "Tiếng Việt", "Tiếng Anh", "Tiếng Pháp", "Tiếng Đức", "Tiếng Tây Ban Nha",
                "Tiếng Trung Quốc", "Tiếng Nhật Bản", "Tiếng Hàn Quốc", "Tiếng Thái Lan", "Tiếng Nga", "Ngôn ngữ khác"};

            gioiHanNguoiDoccb.ItemsSource = new string[] { "Không giới hạn", "Người trưởng thành", "Nhà nghiên cứu", "Đối tượng đặc biệt" };

            currentNameBook = book;
            LoadBookData();
        }
        private void nhomSachcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTheLoaiComboBox();
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

        private void TheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TheLoaicb.SelectedItem is TheLoaiSach selectedTheLoai)
            {
                // Hiển thị mã tắt của thể loại trong sachTLIDtxt.Text
                sachTLIDtxt.Text = selectedTheLoai.MaTat;
            }
        }

        private void LoadBookData()
        {
            if (currentNameBook != null)
            {
                int moi = 0;
                int bthuong = 0;
                int cu = 0;
                int nhe = 0; 
                int nang = 0;

                // Tìm tất cả sách có Id chứa mã đầu sách của currentNameBook
                var booksWithSameId = context.ChiTietSaches
                    .Where(b => b.Id.StartsWith(currentNameBook.Id))
                    .ToList();

                foreach (var book in booksWithSameId)
                {
                    // Tính số lượng sách theo tình trạng
                    switch (book.TinhTrangSach)
                    {
                        case "Mới":
                            moi++;
                            break;
                        case "Bình thường":
                            bthuong++;
                            break;
                        case "Cũ":
                            cu++;
                            break;
                        case "Nhẹ":
                            nhe++;
                            break;
                        case "Nặng":
                            nang++;
                            break;
                    }
                }

                // Tách Id đầu sách (ví dụ: "GD-TH-00001")
                string[] idParts = currentNameBook.Id.Split('-');

                if (idParts.Length == 3)
                {
                    sachNTLIDtxt.Text = idParts[0]; // "GD"
                    sachTLIDtxt.Text = idParts[1];  // "TH"
                    sachIDtxt.Text = idParts[2];     // "00001"
                }

                sachNTLIDtxt.Text = currentNameBook.NhomSach;
                sachTLIDtxt.Text = currentNameBook.TheLoai; 
                tenSachtxt.Text = currentNameBook.TenSach;
                nhomSachcb.Text = currentNameBook.NhomSach;
                TheLoaicb.Text = currentNameBook.TheLoai;
                tacGiatxt.Text = currentNameBook.TacGia;
                nhaXuatBancb.Text = currentNameBook.NhaXuatBan;
                namXuatBancb.SelectedItem = currentNameBook.NamXuatBan;
                ISBNtxt.Text = currentNameBook.Isbn;
                ngonNgucb.Text = currentNameBook.NgonNgu;
                ngayNhapSachdp.Text = currentNameBook.NgayNhapSach?.ToString("yyyy-MM-dd") ?? "";
                gioiHanNguoiDoccb.Text = currentNameBook.GioiHanDocGia;
                soLuongSachMoitxt.Text = moi.ToString();
                soLuongSachBinhThuongtxt.Text = bthuong.ToString();
                soLuongSachCutxt.Text = cu.ToString();
                soLuongSachHongNhetxt.Text = nhe.ToString();
                soLuongSachHongNangtxt.Text = nang.ToString();

                // Kiểm tra xem ảnh có tồn tại không trước khi hiển thị
                if (!string.IsNullOrEmpty(currentNameBook.AnhBia) && File.Exists(currentNameBook.AnhBia))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(currentNameBook.AnhBia, UriKind.Absolute));
                    anhSachImage.Source = bitmap;
                }
                else
                {
                    anhSachImage.Source = null; // Ẩn ảnh nếu không tìm thấy
                }
            }
        }

        private void SuaDauSachbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(namXuatBancb.Text, out int namXuatBan))
                {
                    MessageBox.Show("Vui lòng nhập đúng số cho năm xuất bản và số lượng sách!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (TheLoaicb.SelectedItem is not TheLoaiSach selectedTheLoai)
                {
                    MessageBox.Show("Vui lòng chọn thể loại sách!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(sachIDtxt.Text) || string.IsNullOrWhiteSpace(tenSachtxt.Text) ||
                    string.IsNullOrWhiteSpace(nhomSachcb.Text) || string.IsNullOrWhiteSpace(TheLoaicb.Text) ||
                    string.IsNullOrWhiteSpace(tacGiatxt.Text) || string.IsNullOrWhiteSpace(nhaXuatBancb.Text) ||
                    string.IsNullOrWhiteSpace(ngayNhapSachdp.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string sachID = currentNameBook.Id; // Lấy ID sách hiện tại
                var oldSach = context.QuanLyDauSaches.FirstOrDefault(s => s.Id == sachID);
                if (oldSach == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu sách cần sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Cập nhật thông tin sách
                oldSach.TenSach = tenSachtxt.Text;
                oldSach.NhomSach = nhomSachcb.Text;
                oldSach.TheLoai = TheLoaicb.Text;
                oldSach.TacGia = tacGiatxt.Text;
                oldSach.NhaXuatBan = nhaXuatBancb.Text;
                oldSach.NamXuatBan = namXuatBan;
                oldSach.NgonNgu = ngonNgucb.Text;
                oldSach.Isbn = ISBNtxt.Text;
                oldSach.NgayNhapSach = DateOnly.Parse(ngayNhapSachdp.Text);
                oldSach.GioiHanDocGia = gioiHanNguoiDoccb.Text;
                oldSach.AnhBia = anhSachImage.Source is BitmapImage bitmap ? bitmap.UriSource?.LocalPath : null;

                // Cập nhật thông tin các quyển sách trong ChiTietSach
                var sachChiTietList = context.ChiTietSaches.Where(s => s.Id.StartsWith(sachID)).ToList();
                foreach (var chiTietSach in sachChiTietList)
                {
                    chiTietSach.TenSach = tenSachtxt.Text;
                    chiTietSach.NhomTheLoai = nhomSachcb.Text;
                    chiTietSach.TheLoai = TheLoaicb.Text;
                    chiTietSach.TacGia = tacGiatxt.Text;
                    chiTietSach.NhaXuatBan = nhaXuatBancb.Text;
                    chiTietSach.NamXuatBan = namXuatBan;
                    chiTietSach.Isbn = ISBNtxt.Text;
                    chiTietSach.NgonNgu = ngonNgucb.Text;
                    chiTietSach.NgayNhapSach = DateOnly.Parse(ngayNhapSachdp.Text);
                    chiTietSach.GioiHanDocGia = gioiHanNguoiDoccb.Text;
                    chiTietSach.AnhBia = oldSach.AnhBia;
                }

                context.SaveChanges();
                MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadBookData();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
