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
    /// Interaction logic for QLTaiKhoan.xaml
    /// </summary>
    public partial class QLTaiKhoan : UserControl
    {
        public DatnContext context = new DatnContext();
        private List<TaiKhoanQuanLy> taiKhoanQuanLies;

        public QLTaiKhoan()
        {
            InitializeComponent();

            int admin = context.TaiKhoanQuanLies.Count(e => e.LoaiTk == "Admin");
            int user = context.TaiKhoanQuanLies.Count(e => e.LoaiTk == "User");

            adminCount.Text = admin.ToString();
            userCount.Text = user.ToString();

            QLload();
        }

        public void QLload()
        {
            var taiKhoanQuanLy = context.TaiKhoanQuanLies.AsQueryable();
            QLdatagrid.ItemsSource = taiKhoanQuanLy.OrderBy(e => e.Stt).ToList();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void QGDeleteImage_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var TKQLID = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn có muốn xóa tài khoản của: {TKQLID}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var TKQL = context.TaiKhoanQuanLies.SingleOrDefault(tl => tl.NguoiDungId == TKQLID);
                        if (TKQL != null)
                        {
                            context.TaiKhoanQuanLies.Remove(TKQL);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thể loại để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    QLload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void themQLbtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new DKTKQuanLy();
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
                mainWindow.ShowWithOverlay(form);
            else
                form.ShowDialog();

            QLload();
        }

        private void QLEditImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    int STT = int.Parse(button.Tag.ToString());

                    var selectedTaiKhoan = context.TaiKhoanQuanLies.SingleOrDefault(s => s.Stt == STT);

                    if (selectedTaiKhoan != null)
                    {
                        var form = new SuaTaiKhoan(selectedTaiKhoan);
                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                            mainWindow.ShowWithOverlay(form);
                        else
                            form.ShowDialog();

                        QLload();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
                QLdatagrid.ItemsSource = taiKhoanQuanLies; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.TaiKhoanQuanLies
                        .Where(cv => (cv.TaiKhoan != null && cv.TaiKhoan.ToLower().Contains(keyword)) ||
                                     (cv.LoaiTk != null && cv.LoaiTk.ToLower().Contains(keyword)) ||
                                     (cv.NguoiDungId != null && cv.NguoiDungId.ToLower().Contains(keyword)))
                        .ToList();

                    QLdatagrid.ItemsSource = filteredList;
                }
            }
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            QLload();
        }

        private void theoDoibtn_Click(object sender, RoutedEventArgs e)
        {
            TheoDoiTKDangNhap theoDoiTKDangNhap = new TheoDoiTKDangNhap();
            theoDoiTKDangNhap.ShowDialog();
        }
    }
}
