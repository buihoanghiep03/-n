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
    /// Interaction logic for QLDocGia.xaml
    /// </summary>
    public partial class QLDocGia : UserControl
    {
        public DatnContext context = new DatnContext();
        private QuanLyDocGium selectedDocGia;
        private List<QuanLyDocGium> danhSachDocGia;

        public QLDocGia()
        {
            InitializeComponent();

            int docGiaId = context.QuanLyDocGia.Select(e => e.Id).Distinct().Count();
            int HetHan = context.QuanLyDocGia.Count(e => e.TrangThaiDocGia == "Hết hạn");

            docGiaCount.Text = docGiaId.ToString();
            giaHancount.Text = HetHan.ToString();

            load();
        }

        public void load()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var quanLyDocGia = context.QuanLyDocGia.ToList();

            foreach (var docGia in quanLyDocGia)
            {
                if (docGia.NgayHetHanThe.HasValue)
                {
                    docGia.TrangThaiDocGia = docGia.NgayHetHanThe.Value >= today ? "Còn hạn" : "Hết hạn";
                }
                else
                {
                    docGia.TrangThaiDocGia = "Chưa xác định";
                }
            }

            datagrid.ItemsSource = quanLyDocGia.OrderBy(e => e.Id).ToList();
        }

        private void DKDocGiabtn_Click(object sender, RoutedEventArgs e)
        {
            var themDocGia = new ThemDocGia();

            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
                mainWindow.ShowWithOverlay(themDocGia);
            else
                themDocGia.ShowDialog();

            load();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string docGiaId = button.Tag.ToString();

                    var selectedDocGia = context.QuanLyDocGia.SingleOrDefault(s => s.Id == docGiaId);

                    if (selectedDocGia != null)
                    {
                        var suaDocGia = new SuaDocGia(selectedDocGia);

                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                            mainWindow.ShowWithOverlay(suaDocGia);
                        else
                            suaDocGia.ShowDialog();

                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy độc giả để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void inThebtn_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyDocGium selectedDocGia)
            {
                DateTime ngayHienTai = DateTime.Today;
                string ngayLamThe = selectedDocGia.NgayLamThe?.ToString("yyyy-MM-dd") ?? ngayHienTai.ToString("yyyy-MM-dd");
                string ngayHetHanThe = selectedDocGia.NgayHetHanThe?.ToString("yyyy-MM-dd") ?? ngayHienTai.AddYears(1).ToString("yyyy-MM-dd");

                var inTheDocGia = new InTheDocGia(
                    selectedDocGia.HoTen,
                    ngayLamThe,
                    ngayHetHanThe,
                    selectedDocGia.Id,
                    selectedDocGia.LoaiDocGia,
                    selectedDocGia.AnhDg
                );

                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                    mainWindow.ShowWithOverlay(inTheDocGia);
                else
                    inTheDocGia.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một độc giả trước khi in thẻ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            load();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyDocGium docGia)
            {
                selectedDocGia = docGia;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var theLoaiId = button.Tag.ToString();
                    var result = MessageBox.Show($"Are you sure you want to delete Employee ID: {theLoaiId}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var theLoaiSach = context.TheLoaiSaches.SingleOrDefault(tl => tl.Id == theLoaiId);
                        if (theLoaiSach != null)
                        {
                            context.TheLoaiSaches.Remove(theLoaiSach);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thể loại để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                datagrid.ItemsSource = danhSachDocGia; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.QuanLyDocGia
                        .Where(cv => (cv.Id != null && cv.Id.ToLower().Contains(keyword)) ||
                                     (cv.SoCccd != null && cv.SoCccd.ToLower().Contains(keyword)) ||
                                     (cv.HoTen != null && cv.HoTen.ToLower().Contains(keyword)) ||
                                     (cv.LoaiDocGia != null && cv.LoaiDocGia.ToLower().Contains(keyword)))
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
