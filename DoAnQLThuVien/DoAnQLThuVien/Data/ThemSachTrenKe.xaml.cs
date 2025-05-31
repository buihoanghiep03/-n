using DoAnQLThuVien.Models;
using Microsoft.EntityFrameworkCore;
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

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for ThemSachTrenKe.xaml
    /// </summary>
    public partial class ThemSachTrenKe : Window
    {
        private readonly DatnContext context = new DatnContext();
        private List<ChiTietSach> availableBooks = new List<ChiTietSach>();
        private readonly List<string> selectedBooks = new List<string>();
        private readonly string keSachId;

        public ThemSachTrenKe(string keSachId)
        {
            InitializeComponent();
            this.keSachId = keSachId;

            InitializeComboBoxes();
            LoadAvailableBooks();
        }

        private void InitializeComboBoxes()
        {
            nhomTheLoaicb.ItemsSource = context.NhomLoaiSaches.ToList();
            nhomTheLoaicb.DisplayMemberPath = "TenNhomSach";
            nhomTheLoaicb.SelectedIndex = -1;
        }

        private void LoadAvailableBooks()
        {
            // Get books not already on this shelf
            var booksOnShelf = context.SoSachTrenKes
                .Where(s => s.KeSachId == keSachId)
                .Select(s => s.SachId)
                .ToList();

            availableBooks = context.ChiTietSaches
                .Where(s => !booksOnShelf.Contains(s.Id) &&
                           s.TinhTrangMuon == "Khả dụng" &&
                           s.TinhTrangSach != "Nhẹ" &&
                           s.TinhTrangSach != "Nặng")
                .OrderBy(s => s.Id)
                .ToList();

            datagrid.ItemsSource = availableBooks;
        }

        private void FilterBooks()
        {
            IQueryable<ChiTietSach> query = context.ChiTietSaches
                .Where(s => availableBooks.Select(b => b.Id).Contains(s.Id));

            if (nhomTheLoaicb.SelectedItem is NhomLoaiSach selectedCategory)
            {
                query = query.Where(s => s.NhomTheLoai == selectedCategory.TenNhomSach);

                if (theLoaicb.SelectedItem is TheLoaiSach selectedType)
                {
                    query = query.Where(s => s.TheLoai == selectedType.TheLoai);
                }
            }

            datagrid.ItemsSource = query.ToList();
        }

        private void nhomTheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nhomTheLoaicb.SelectedItem is NhomLoaiSach selectedCategory)
            {
                theLoaicb.ItemsSource = context.TheLoaiSaches
                    .Where(t => t.NhomLoaiSach == selectedCategory.TenNhomSach)
                    .ToList();
                theLoaicb.DisplayMemberPath = "TheLoai";
                theLoaicb.SelectedIndex = -1;
            }
            FilterBooks();
        }

        private void theLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterBooks();
        }

        private void SearchBooks(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                FilterBooks();
                return;
            }

            keyword = keyword.ToLower();
            var results = availableBooks
                .Where(s => (s.Id != null && s.Id.ToLower().Contains(keyword)) ||
                           (s.TenSach != null && s.TenSach.ToLower().Contains(keyword)) ||
                           (s.TacGia != null && s.TacGia.ToLower().Contains(keyword)))
                .ToList();

            datagrid.ItemsSource = results;
        }

        private void timKiemMabtn_Click(object sender, RoutedEventArgs e)
        {
            SearchBooks(timKiemMatxt.Text.Trim());
        }

        private void themSachbtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sách!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var keSach = context.QuanLyKeSaches.Find(keSachId);
                if (keSach == null)
                {
                    MessageBox.Show("Kệ sách không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int addedCount = 0;

                // Duyệt qua selectedBooks mà không cần dùng Keys
                foreach (var bookId in selectedBooks)
                {
                    var book = context.ChiTietSaches.FirstOrDefault(b => b.Id == bookId); // Tìm sách theo Id (string)
                    if (book == null) continue;

                    // Kiểm tra nếu sách đã có trên kệ này
                    if (context.SoSachTrenKes.Any(s => s.SachId == bookId && s.KeSachId == keSachId))
                    {
                        continue;
                    }

                    // Thêm vào kệ
                    context.SoSachTrenKes.Add(new SoSachTrenKe
                    {
                        KeSachId = keSachId,
                        SachId = bookId
                    });

                    // Cập nhật vị trí sách
                    book.KeSach = keSach.TenKeSach;
                    addedCount++;
                }

                if (addedCount > 0)
                {
                    context.SaveChanges();
                    MessageBox.Show($"Đã thêm {addedCount} sách vào kệ!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Không có sách nào được thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                if (!selectedBooks.Contains(bookId))
                {
                    selectedBooks.Add(bookId);
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                selectedBooks.Remove(bookId);
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            timKiemMatxt.Text = "";
            nhomTheLoaicb.Text = "";
            theLoaicb.Text = "";
            LoadAvailableBooks();
        }
    }
}
