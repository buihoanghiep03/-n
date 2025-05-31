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
    /// Interaction logic for SachTrenKe.xaml
    /// </summary>
    public partial class SachTrenKe : Window
    {
        private readonly DatnContext context = new DatnContext();
        private List<ChiTietSach> booksOnShelf = new List<ChiTietSach>();
        private readonly Dictionary<string, bool> selectedBooks = new Dictionary<string, bool>();
        private readonly string keSachId;

        public SachTrenKe(string keSachId)
        {
            InitializeComponent();
            this.keSachId = keSachId;
            keSachIdtxt.Text = keSachId;

            InitializeComboBoxes();
            LoadBooksOnShelf();
        }

        private void InitializeComboBoxes()
        {
            // Load book categories
            nhomTheLoaicb.ItemsSource = context.NhomLoaiSaches.ToList();
            nhomTheLoaicb.DisplayMemberPath = "TenNhomSach";
            nhomTheLoaicb.SelectedIndex = -1;
        }

        private void LoadBooksOnShelf()
        {
            booksOnShelf = context.SoSachTrenKes
                .Where(s => s.KeSachId == keSachId)
                .Join(context.ChiTietSaches,
                    stk => stk.SachId,
                    cts => cts.Id,
                    (stk, cts) => cts)
                .OrderBy(b => b.Id)
                .ToList();

            datagrid.ItemsSource = booksOnShelf;
        }

        private void FilterBooks()
        {
            IQueryable<ChiTietSach> query = context.ChiTietSaches
                .Where(s => booksOnShelf.Select(b => b.Id).Contains(s.Id));

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
            var results = booksOnShelf
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

        private void catSachbtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedBooks.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sách!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                int removedCount = 0;
                foreach (var bookId in selectedBooks.Keys.Where(k => selectedBooks[k]))
                {
                    var bookOnShelf = context.SoSachTrenKes
                        .FirstOrDefault(s => s.SachId == bookId && s.KeSachId == keSachId);

                    if (bookOnShelf != null)
                    {
                        context.SoSachTrenKes.Remove(bookOnShelf);

                        var book = context.ChiTietSaches.FirstOrDefault(b => b.Id == bookId);
                        if (book != null) book.KeSach = "Trong kho";

                        removedCount++;
                    }
                }

                if (removedCount > 0)
                {
                    context.SaveChanges();
                    MessageBox.Show($"Đã xóa {removedCount} sách khỏi kệ!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadBooksOnShelf();
                    selectedBooks.Clear();
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
                selectedBooks[bookId] = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                selectedBooks.Remove(bookId);
            }
        }

        private void themSachbtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ThemSachTrenKe(keSachId);
            window.ShowDialog();
            LoadBooksOnShelf();
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
            LoadBooksOnShelf(); 
        }
    }
}
