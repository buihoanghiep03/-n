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
    /// Interaction logic for QLKeSach.xaml
    /// </summary>
    public partial class QLKeSach : UserControl
    {
        public DatnContext context = new DatnContext();

        private int pageSize = 20; // Giới hạn số hàng trên 1 trang
        private int currentPage = 1;
        private int totalPages = 1;
        private List<QuanLyKeSach> allKeSachs;

        public QLKeSach()
        {
            InitializeComponent();

            datagrid.SelectionChanged += datagrid_SelectionChanged;
            load();
        }

        public void load()
        {
            allKeSachs = context.QuanLyKeSaches.OrderBy(e => e.Id).ToList();
            totalPages = (int)Math.Ceiling((double)allKeSachs.Count / pageSize);
            currentPage = 1;

            // Cập nhật tổng số kệ sách
            tongSoKeSachlb.Content = $"Tổng số {allKeSachs.Count} kệ sách";

            // Hiển thị danh sách trang trong ComboBox
            trangcb.ItemsSource = Enumerable.Range(1, totalPages);
            trangcb.SelectedIndex = 0; // Chọn trang đầu tiên

            LoadPage(currentPage);
        }

        private void trangcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trangcb.SelectedItem != null)
            {
                int selectedPage = (int)trangcb.SelectedItem;
                LoadPage(selectedPage);
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyKeSach keSach)
            {
                int soLuongHienTai = keSach.SoLuongSachHienTai ?? 0;
                int soLuongToiDa = keSach.SoLuongSachToiDa ?? 1;

                // Tránh chia cho 0
                double phanTram = (soLuongToiDa > 0) ? (double)soLuongHienTai / soLuongToiDa * 100 : 0;

                // Kiểm tra giá trị
                Console.WriteLine($"[LOG] Số lượng hiện tại: {soLuongHienTai}, Số lượng tối đa: {soLuongToiDa}, Phần trăm: {phanTram}");

                // Nếu không có dữ liệu thì thoát
                if (soLuongToiDa == 0) return;

                // Cập nhật thanh tiến độ
                thanhTienDoGreen.Width = Math.Max(1, (phanTram / 100) * 462);
                thanhTienDoRed.Width = 462 - thanhTienDoGreen.Width;

                // Cập nhật giao diện
                thanhTienDoGreen.UpdateLayout();
                thanhTienDoRed.UpdateLayout();
                thanhTienDoGreen.InvalidateVisual();
                thanhTienDoRed.InvalidateVisual();

                // Cập nhật Label hiển thị số lượng
                tienDolb.Content = $"{soLuongHienTai} / {soLuongToiDa}";

                CapNhatThongTin();
            }
        }

        private void LoadPage(int page)
        {
            currentPage = page;

            var data = allKeSachs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            datagrid.ItemsSource = data;

            // Cập nhật Label số trang
            tranglb.Content = "Trang";
            tongTranglb.Content = $"trên tổng số {totalPages} trang";
        }

        private void CapNhatThongTin()
        {
            // Cập nhật label tổng số kệ sách
            tongSoKeSachlb.Content = $"Tổng {allKeSachs.Count} kệ sách";

            // Cập nhật ComboBox chọn trang
            trangcb.ItemsSource = Enumerable.Range(1, totalPages);
            trangcb.SelectedItem = currentPage;

            // Cập nhật label số trang
            tranglb.Content = $"Trang {currentPage} trên tổng số {totalPages} trang";
        }

        private void Sachbtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string keSachId = button.Tag?.ToString();
                if (!string.IsNullOrEmpty(keSachId))
                {
                    var sachTrenKe = new SachTrenKe(keSachId);

                    var mainWindow = Window.GetWindow(this) as MainWindow;
                    if (mainWindow != null)
                        mainWindow.ShowWithOverlay(sachTrenKe);
                    else
                        sachTrenKe.ShowDialog();

                    load();
                }
            }
            load();
        }

        private void ThemKeSachbtn_Click(object sender, RoutedEventArgs e)
        {
            var themKeSach = new ThemKeSach();

            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
                mainWindow.ShowWithOverlay(themKeSach);
            else
                themKeSach.ShowDialog();

            load();
        }

        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string KeSachId = button.Tag.ToString();

                    var selectedKeSach = context.QuanLyKeSaches.SingleOrDefault(s => s.Id == KeSachId);

                    if (selectedKeSach != null)
                    {
                        var suaKeSach = new SuaKeSach(selectedKeSach);

                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                            mainWindow.ShowWithOverlay(suaKeSach);
                        else
                            suaKeSach.ShowDialog();

                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kệ sách để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                load();
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
                    var result = MessageBox.Show($"Bạn có muốn xóa kệ sách mang ID: {SachID}?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

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

        // Hàm tìm kiếm sách theo từ khóa
        public void SearchBooks(string keyword)
        {
            keyword = keyword.ToLower().Trim(); // Chuẩn hóa từ khóa tìm kiếm
            var searchResult = context.QuanLyKeSaches
                .Where(e => e.Id.ToLower().Contains(keyword) || e.TenKeSach.ToLower().Contains(keyword) || e.LoaiKeSach.ToLower().Contains(keyword)
                || e.NhomTheLoaiKe.ToLower().Contains(keyword) || e.ViTriKe.ToLower().Contains(keyword))
                .OrderBy(e => e.Id)
                .ToList();

            allKeSachs = searchResult;
            LoadPage(1); // Hiển thị kết quả tìm kiếm từ trang đầu tiên
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
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
                load();
            }
        }
    }
}
