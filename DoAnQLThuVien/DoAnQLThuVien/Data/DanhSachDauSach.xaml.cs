using DoAnQLThuVien.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for DanhSachSach.xaml
    /// </summary>
    public partial class DanhSachDauSach : UserControl
    {
        public DatnContext context = new DatnContext();

        public DanhSachDauSach()
        {
            InitializeComponent();

            tongDauSach.Text = "0";
            tongSach.Text = "0";

            var TongDauSach = context.QuanLyDauSaches.Count();
            var TongSoSach = context.QuanLyDauSaches.Sum(e => (int?)e.TongSoSach) ?? 0;
            tongSach.Text = TongSoSach.ToString();
            tongDauSach.Text = TongDauSach.ToString();

            tongSoDauSachlb.Content = $"Tổng số {TongDauSach} đầu sách";

            load();
        }
        public void load()
        {
            allBooks = context.QuanLyDauSaches.OrderBy(e => e.Id).ToList(); // Lưu toàn bộ dữ liệu
            LoadPagination(); // Cập nhật số trang
            LoadPage(1); // Hiển thị trang đầu tiên
        }

        private List<QuanLyDauSach> allBooks;
        private int totalPages;
        private int currentPage = 1;
        private int pageSize = 20; // Số sách mỗi trang

        private void LoadPage(int page)
        {
            currentPage = page;

            if (allBooks == null || allBooks.Count == 0)
            {
                datagrid.ItemsSource = null;
                tranglb.Content = "Trang 0";
                tongTranglb.Content = "trên tổng số 0 trang";
                return;
            }

            var data = allBooks
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            datagrid.ItemsSource = data;

            // Cập nhật số trang hiển thị
            tranglb.Content = $"Trang {currentPage}";
            tongTranglb.Content = $"trên tổng số {totalPages} trang";
        }

        private void LoadPagination()
        {
            if (allBooks == null || allBooks.Count == 0)
            {
                totalPages = 0;
                trangcb.Items.Clear();
                return;
            }

            totalPages = (int)Math.Ceiling((double)allBooks.Count / pageSize);
            trangcb.Items.Clear();

            for (int i = 1; i <= totalPages; i++)
            {
                trangcb.Items.Add(i);
            }

            trangcb.SelectedIndex = 0; // Mặc định chọn trang đầu tiên
        }

        private void trangcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trangcb.SelectedItem != null)
            {
                LoadPage((int)trangcb.SelectedItem);
            }
        }

        private void ThemDauSachbtn_Click(object sender, RoutedEventArgs e)
        {
            var themSachWindow = new ThemDauSach();

            // Từ chính DanhSachDauSach, lấy ra MainWindow
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.ShowWithOverlay(themSachWindow);
            }
            else
            {
                themSachWindow.ShowDialog(); // fallback nếu không tìm thấy MainWindow
            }
            load();
        }

        private void ThemSachbtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = datagrid.SelectedItem as QuanLyDauSach;
            if (selectedBook != null)
            {
                // Tạo cửa sổ thêm sách
                ThemSach themSach = new ThemSach(selectedBook);

                // Gọi MainWindow và dùng ShowWithOverlay
                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.ShowWithOverlay(themSach);
                }
                else
                {
                    themSach.ShowDialog(); // fallback nếu không tìm thấy MainWindow
                }

                load(); // Reload lại dữ liệu sau khi thêm
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đầu sách trước khi thêm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string sachId = button.Tag.ToString();

                    // Tìm sách trong database theo Id
                    var selectedBook = context.QuanLyDauSaches.SingleOrDefault(s => s.Id == sachId);

                    if (selectedBook != null)
                    {
                        // Mở cửa sổ sửa đầu sách và truyền dữ liệu vào
                        SuaDauSach editBookWindow = new SuaDauSach(selectedBook);

                        // Lấy MainWindow và gọi ShowWithOverlay
                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                        {
                            mainWindow.ShowWithOverlay(editBookWindow);
                        }
                        else
                        {
                            editBookWindow.ShowDialog(); // fallback nếu không tìm thấy MainWindow
                        }

                        // Reload sau khi chỉnh sửa
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var SachID = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn có muốn xóa sách mang ID: {SachID}?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var quanLySach = context.QuanLyDauSaches.SingleOrDefault(tl => tl.Id == SachID);
                        if (quanLySach != null)
                        {
                            context.QuanLyDauSaches.Remove(quanLySach);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sách để xóa.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                SearchBooks(keyword);
            }
            else
            {
                load(); // Nếu ô tìm kiếm trống, tải lại toàn bộ sách
            }
        }

        // Hàm tìm kiếm sách theo từ khóa
        public void SearchBooks(string keyword)
        {
            keyword = keyword.ToLower().Trim(); // Chuẩn hóa từ khóa tìm kiếm
            var searchResult = context.QuanLyDauSaches
                .Where(e => e.TenSach.ToLower().Contains(keyword) || e.TacGia.ToLower().Contains(keyword) || e.Id.ToLower().Contains(keyword))
                .OrderBy(e => e.Id)
                .ToList();

            allBooks = searchResult;
            LoadPagination();
            LoadPage(1); // Hiển thị kết quả tìm kiếm từ trang đầu tiên
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }
    }
}
