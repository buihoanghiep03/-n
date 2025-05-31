using DoAnQLThuVien.Data;
using DoAnQLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DoAnQLThuVien
{
    public partial class TimKiemWindow : Window
    {
        private int _currentPage = 1;
        private const int PageSize = 20; // Số sách mỗi trang
        private List<ChiTietSach> _filteredBooks; // Danh sách sách đã lọc

        public TimKiemWindow()
        {
            InitializeComponent();
            // Lấy danh sách nhóm loại sách
            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            timNhomTheLoaicb.ItemsSource = nhomLoaiSaches;
            timNhomTheLoaicb.DisplayMemberPath = "TenNhomSach";

            // Lấy danh sách nhóm loại sách
            var quanLyNhaXuatBans = context.QuanLyNhaXuatBans.ToList();
            timNhaXuatBancb.ItemsSource = quanLyNhaXuatBans;
            timNhaXuatBancb.DisplayMemberPath = "TenNhaXuatBan";

            // Lấy danh sách các năm xuất bản (ví dụ từ 1950 đến năm hiện tại)
            int currentYear = DateTime.Now.Year;
            var namXuatBan = Enumerable.Range(1950, currentYear - 1950 + 1)
                                       .Reverse() // Đảo ngược danh sách
                                       .ToList();
            timNamXuatBancb.ItemsSource = namXuatBan;

            // Gán danh sách ngôn ngữ cho ComboBox
            ngonNgucb.ItemsSource = new string[]{
                "Tiếng Việt", "Tiếng Anh", "Tiếng Pháp", "Tiếng Đức", "Tiếng Tây Ban Nha",
                "Tiếng Trung Quốc", "Tiếng Nhật Bản", "Tiếng Hàn Quốc", "Tiếng Thái Lan", "Tiếng Nga", "Ngôn ngữ khác"};

            timTrangThaiSachcb.ItemsSource = new string[]{
                "Mới", "Bình thường", "Cũ", "Hỏng nhẹ", "Hỏng nặng"};

            // Gán sự kiện khi nhóm sách thay đổi
            timNhomTheLoaicb.SelectionChanged += timNhomTheLoaicb_SelectionChanged;

            // Gán sự kiện khi thể loại sách thay đổi
            timTheLoaicb.SelectionChanged += timTheLoaicb_SelectionChanged;

            UpdateTheLoaiComboBox();



            // Tải dữ liệu ban đầu
            load();
        }

        private void UpdateTheLoaiComboBox()
        {
            if (timNhomTheLoaicb.SelectedItem is NhomLoaiSach selectedNhom)
            {
                // Cập nhật TheLoaicb theo nhóm loại sách
                var theLoaiSaches = context.TheLoaiSaches
                    .Where(t => t.NhomLoaiSach == selectedNhom.TenNhomSach)
                    .ToList();

                timTheLoaicb.ItemsSource = theLoaiSaches;
                timTheLoaicb.DisplayMemberPath = "TheLoai";
            }
        }

        public DatnContext context = new DatnContext();

        public void load()
        {
            var chiTietSaches = context.ChiTietSaches.AsQueryable();
            _filteredBooks = chiTietSaches.OrderBy(e => e.Id).ToList();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            // Lấy dữ liệu cho trang hiện tại
            var pagedBooks = _filteredBooks.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList();
            datagrid.ItemsSource = pagedBooks;

            // Cập nhật số trang hiện tại
            lblCurrentPage.Content = _currentPage.ToString();
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateDataGrid();
            }
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < (_filteredBooks.Count + PageSize - 1) / PageSize)
            {
                _currentPage++;
                UpdateDataGrid();
            }
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý khi chọn một hàng trong DataGrid
        }

        private void tritietbtn_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý khi nhấn nút chi tiết
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            timKiemtxt.Clear();
            timNamXuatBancb.Text = "";
            timNhaXuatBancb.Text = "";
            timNhomTheLoaicb.Text = "";
            timTacGiatxt.Clear();
            timTheLoaicb.Text = "";
            timTrangThaiSachcb.Text = "";
            ngonNgucb.Text = "";

            load();
        }

        private void timTrangThaiSachcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý khi tình trạng sách thay đổi
        }

        private void timNamXuatBancb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý khi năm xuất bản thay đổi
        }

        private void timTheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý khi thể loại sách thay đổi
        }

        private void timNhomTheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTheLoaiComboBox();
        }

        private void locSachbtn_Click(object sender, RoutedEventArgs e)
        {
            var filteredBooks = context.ChiTietSaches.AsQueryable();

            // Lọc theo tên sách
            if (!string.IsNullOrWhiteSpace(timKiemtxt.Text))
            {
                filteredBooks = filteredBooks.Where(s => s.TenSach.Contains(timKiemtxt.Text));
            }

            // Lọc theo tác giả
            if (!string.IsNullOrWhiteSpace(timTacGiatxt.Text))
            {
                filteredBooks = filteredBooks.Where(s => s.TacGia.Contains(timTacGiatxt.Text));
            }

            // Lọc theo nhà xuất bản
            if (timNhaXuatBancb.SelectedItem is QuanLyNhaXuatBan selectedNxb)
            {
                filteredBooks = filteredBooks.Where(s => s.NhaXuatBan == selectedNxb.TenNhaXuatBan);
            }

            // Lọc theo nhóm thể loại sách
            if (timNhomTheLoaicb.SelectedItem is NhomLoaiSach selectedNhom)
            {
                filteredBooks = filteredBooks.Where(s => s.NhomTheLoai == selectedNhom.TenNhomSach);
            }

            // Lọc theo thể loại sách
            if (timTheLoaicb.SelectedItem is TheLoaiSach selectedTheLoai)
            {
                filteredBooks = filteredBooks.Where(s => s.TheLoai == selectedTheLoai.TheLoai);
            }

            // Lọc theo năm xuất bản
            if (timNamXuatBancb.SelectedItem is int selectedYear)
            {
                filteredBooks = filteredBooks.Where(s => s.NamXuatBan == selectedYear);
            }

            // Lọc theo ngôn ngữ
            if (ngonNgucb.SelectedItem is string selectedLanguage)
            {
                filteredBooks = filteredBooks.Where(s => s.NgonNgu == selectedLanguage);
            }

            // Lọc theo tình trạng sách
            if (timTrangThaiSachcb.SelectedItem is string selectedStatus)
            {
                filteredBooks = filteredBooks.Where(s => s.TinhTrangSach == selectedStatus);
            }

            // Gán dữ liệu đã lọc vào danh sách và cập nhật DataGrid
            _filteredBooks = filteredBooks.OrderBy(s => s.Id).ToList();
            _currentPage = 1; // Reset về trang đầu tiên
            UpdateDataGrid();
        }

        private void ngonNgucb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý khi ngôn ngữ thay đổi
        }

        private void chiTietbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string sachId = button.Tag.ToString();

                    // Tìm sách trong database theo Id
                    var selectedBook = context.ChiTietSaches.SingleOrDefault(s => s.Id == sachId);

                    if (selectedBook != null)
                    {
                        // Mở cửa sổ sửa đầu sách và truyền dữ liệu sách vào
                        TimKiemChiTietSach timKiemChiTietSach = new TimKiemChiTietSach(selectedBook);
                        timKiemChiTietSach.ShowDialog();

                        // Reload dữ liệu sau khi chỉnh sửa
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}