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
    /// Interaction logic for SuaDuLieuSach.xaml
    /// </summary>
    public partial class SuaDuLieuSach : Window
    {
        public DatnContext context = new DatnContext();
        private ChiTietSach currentBook;
        public SuaDuLieuSach(ChiTietSach book)
        {
            InitializeComponent();

            // Lấy danh sách các năm xuất bản (ví dụ từ 1950 đến năm hiện tại)
            int currentYear = DateTime.Now.Year;
            var namXuatBan = Enumerable.Range(1950, currentYear - 1950 + 1)
                                       .Reverse() // Đảo ngược danh sách
                                       .ToList();
            namXuatBancb.ItemsSource = namXuatBan;

            // Lấy danh sách nhóm loại sách
            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            nhomSachcb.ItemsSource = nhomLoaiSaches;
            nhomSachcb.DisplayMemberPath = "TenNhomSach";

            // Gán sự kiện khi nhóm sách thay đổi
            nhomSachcb.SelectionChanged += nhomSachcb_SelectionChanged;

            // Gán sự kiện khi thể loại sách thay đổi
            TheLoaicb.SelectionChanged += TheLoaicb_SelectionChanged;

            UpdateTheLoaiComboBox();

            var quanLyNhaXuatBans = context.QuanLyNhaXuatBans.ToList();
            nhaXuatBancb.ItemsSource = quanLyNhaXuatBans;
            nhaXuatBancb.DisplayMemberPath = "TenNhaXuatBan";

            ngonNgucb.ItemsSource = new string[]{
                    "Tiếng Việt", "Tiếng Anh", "Tiếng Pháp", "Tiếng Đức", "Tiếng Tây Ban Nha",
                    "Tiếng Trung Quốc", "Tiếng Nhật Bản", "Tiếng Hàn Quốc", "Tiếng Thái Lan", "Tiếng Nga", "Ngôn ngữ khác"};

            trangThaicb.ItemsSource = new string[]{
                    "Mới", "Bình thường", "Cũ", "Hỏng nhẹ", "Hỏng nặng", "Mất"};

            var quanLyKeSaches = context.QuanLyKeSaches.ToList();
            keSachcb.ItemsSource = quanLyKeSaches;
            keSachcb.DisplayMemberPath = "TenKeSach";

            currentBook = book;
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
            }
        }

        private void TheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadBookData()
        {
            if (currentBook != null)
            {
                sachIDtxt.Text = currentBook.Id;
                tenSachtxt.Text = currentBook.TenSach;
                nhomSachcb.Text = currentBook.NhomTheLoai;
                TheLoaicb.Text = currentBook.TheLoai;
                tacGiatxt.Text = currentBook.TacGia;
                nhaXuatBancb.Text = currentBook.NhaXuatBan;
                namXuatBancb.Text = currentBook.NamXuatBan?.ToString() ?? "";
                ngonNgucb.Text = currentBook.NgonNgu;
                ngayNhapSachdp.Text = currentBook.NgayNhapSach?.ToString("yyyy-MM-dd") ?? "";
                ISBNtxt.Text = currentBook.Isbn;
                trangThaicb.Text = currentBook.TinhTrangSach;
                keSachcb.Text = currentBook.KeSach;

                // Kiểm tra xem ảnh có tồn tại không trước khi hiển thị
                if (!string.IsNullOrEmpty(currentBook.AnhBia) && File.Exists(currentBook.AnhBia))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(currentBook.AnhBia, UriKind.Absolute));
                    anhSachImage.Source = bitmap;
                }
                else
                {
                    anhSachImage.Source = null; // Ẩn ảnh nếu không tìm thấy
                }
            }
        }

        private void SuaSachbtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(sachIDtxt.Text) ||
                    string.IsNullOrWhiteSpace(tenSachtxt.Text) ||
                    string.IsNullOrWhiteSpace(nhomSachcb.Text) ||
                    string.IsNullOrWhiteSpace(TheLoaicb.Text) ||
                    string.IsNullOrWhiteSpace(tacGiatxt.Text) ||
                    string.IsNullOrWhiteSpace(namXuatBancb.Text) ||
                    string.IsNullOrWhiteSpace(nhaXuatBancb.Text) ||
                    string.IsNullOrWhiteSpace(ngayNhapSachdp.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(namXuatBancb.Text, out int namXuatBan))
                {
                    MessageBox.Show("Năm xuất bản không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (currentBook != null)
                {
                    // Cập nhật dữ liệu sách
                    currentBook.TenSach = tenSachtxt.Text;
                    currentBook.NhomTheLoai = nhomSachcb.Text;
                    currentBook.TheLoai = TheLoaicb.Text;
                    currentBook.TacGia = tacGiatxt.Text;
                    currentBook.NhaXuatBan = nhaXuatBancb.Text;
                    currentBook.NamXuatBan = namXuatBan;
                    currentBook.NgonNgu = ngonNgucb.Text;
                    currentBook.NgayNhapSach = DateOnly.Parse(ngayNhapSachdp.Text);
                    currentBook.Isbn = ISBNtxt.Text;
                    currentBook.TinhTrangSach = trangThaicb.Text;
                    currentBook.KeSach = keSachcb.Text;

                    // Cập nhật ảnh bìa nếu có thay đổi
                    if (anhSachImage.Source is BitmapImage bitmap)
                    {
                        currentBook.AnhBia = bitmap.UriSource?.LocalPath;
                    }

                    context.SaveChanges();

                    MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu sách để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
