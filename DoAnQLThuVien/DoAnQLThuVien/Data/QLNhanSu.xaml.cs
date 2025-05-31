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
    /// Interaction logic for QLThuThu.xaml
    /// </summary>
    public partial class QLNhanSu : UserControl
    {
        public QLNhanSu()
        {
            InitializeComponent();

            int quanLy = context.QuanLyNhanSus.Count(e => e.LoaiNhanSu == "Nhân viên quản lý");
            int binhThuong = context.QuanLyNhanSus.Count(e => e.LoaiNhanSu == "Nhân viên bình thường");

            quanLyCount.Text = quanLy.ToString();
            binhThuongCount.Text = binhThuong.ToString();

            load();
        }

        public DatnContext context = new DatnContext();
        private List<QuanLyNhanSu> danhSachNhanSu;

        public void load()
        {
            var quanLyThuThus = context.QuanLyNhanSus.AsQueryable();
            datagrid.ItemsSource = quanLyThuThus.OrderBy(e => e.Id).ToList();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void thembtn_Click(object sender, RoutedEventArgs e)
        {
            var themNhanSu = new ThemNhanSu();

            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
                mainWindow.ShowWithOverlay(themNhanSu);
            else
                themNhanSu.ShowDialog();

            load();
        }

        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string nhanSuId = button.Tag.ToString();

                    var selectedNhanSu = context.QuanLyNhanSus.SingleOrDefault(s => s.Id == nhanSuId);

                    if (selectedNhanSu != null)
                    {
                        var suaNhanSu = new SuaNhanSu(selectedNhanSu);

                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                            mainWindow.ShowWithOverlay(suaNhanSu);
                        else
                            suaNhanSu.ShowDialog();

                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân sự để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    var nhanSuID = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn có muốn xóa nhân sự mang ID: {nhanSuID}?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var quanLyNhanSu = context.QuanLyNhanSus.SingleOrDefault(tl => tl.Id == nhanSuID);
                        if (quanLyNhanSu != null)
                        {
                            context.QuanLyNhanSus.Remove(quanLyNhanSu);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân sự để xóa.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = danhSachNhanSu; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.QuanLyNhanSus
                        .Where(cv => (cv.Id != null && cv.Id.ToLower().Contains(keyword)) ||
                                     (cv.TenNhanSu != null && cv.TenNhanSu.ToLower().Contains(keyword)) ||
                                     (cv.GioiTinh != null && cv.GioiTinh.ToLower().Contains(keyword)) ||
                                     (cv.CongViec != null && cv.CongViec.ToLower().Contains(keyword)) ||
                                     (cv.Cccd != null && cv.Cccd.ToLower().Contains(keyword)) ||
                                     (cv.LoaiNhanSu != null && cv.LoaiNhanSu.ToLower().Contains(keyword)))
                        .ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }
    }
}
