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
    /// Interaction logic for CongViec.xaml
    /// </summary>
    public partial class QLCongViec : UserControl
    {
        public DatnContext context = new DatnContext();
        private List<QuanLyCongViec> danhSachCongViec;
        public QLCongViec()
        {
            InitializeComponent();

            // Gán danh sách ngôn ngữ cho ComboBox
            loaiCongVieccb.ItemsSource = new string[]{
                "Quản lý", "Bình thường"};
            loaiCongVieccb.SelectedIndex = 0;
            load();
        }

        public void load()
        {
            var quanLyCongViecs = context.QuanLyCongViecs.AsQueryable();
            datagrid.ItemsSource = quanLyCongViecs.OrderBy(e => e.Id).ToList();
        }

        private void thembtn_click(object sender, RoutedEventArgs e)
        {
            using (var context = new DatnContext()) // Đảm bảo bạn có DbContext thích hợp
            {
                // Lấy dữ liệu từ các TextBox
                string loaiCongViec = loaiCongVieccb.Text.Trim();
                string congViec = congViectxt.Text.Trim();
                string luongCoBanStr = luongCoBantxt.Text.Trim();

                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrEmpty(congViec))
                {
                    MessageBox.Show("Vui lòng nhập tên công việc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(luongCoBanStr, out decimal luongCoBan) || luongCoBan < 0)
                {
                    MessageBox.Show("Lương cơ bản phải là số hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Tạo một đối tượng mới
                var newJob = new QuanLyCongViec
                {
                    LoaiCongViec = loaiCongViec,
                    CongViec = congViec,
                    LuongCoBan = luongCoBan,
                    SoLuongNguoiLam = 0
                };

                // Thêm vào database
                context.QuanLyCongViecs.Add(newJob);
                context.SaveChanges();

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm công việc thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                congViectxt.Text = "";
                luongCoBantxt.Text = "";

                load();
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyCongViec selectedJob)
            {
                congViectxt.Text = selectedJob.CongViec;
                luongCoBantxt.Text = selectedJob.LuongCoBan.ToString();
            }
        }

        private void suabtn_click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyCongViec selectedJob)
            {
                try
                {
                    var job = context.QuanLyCongViecs.SingleOrDefault(j => j.Id == selectedJob.Id);
                    if (job != null)
                    {
                        job.CongViec = congViectxt.Text;
                        if (!decimal.TryParse(luongCoBantxt.Text, out decimal luongCoBan) || luongCoBan < 0)
                        {
                            MessageBox.Show("Lương cơ bản phải là số hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        job.LuongCoBan = luongCoBan;

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật công việc thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        congViectxt.Text = "";
                        luongCoBantxt.Text = "";

                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy công việc để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = danhSachCongViec; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.QuanLyCongViecs
                        .Where(cv => (cv.CongViec != null && cv.CongViec.ToLower().Contains(keyword)) ||
                                     (cv.LoaiCongViec != null && cv.LoaiCongViec.ToLower().Contains(keyword)) ||
                                     (cv.MaTat != null && cv.MaTat.ToLower().Contains(keyword)))
                        .ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }

        private void DeleteImage_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datagrid.SelectedItem is QuanLyCongViec selectedJob)
                {
                    var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc này không: {selectedJob.CongViec}?",
                                                 "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        var jobToDelete = context.QuanLyCongViecs.SingleOrDefault(j => j.Id == selectedJob.Id);
                        if (jobToDelete != null)
                        {
                            context.QuanLyCongViecs.Remove(jobToDelete);
                            context.SaveChanges();
                            MessageBox.Show("Xóa công việc thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy công việc để xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một công việc để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
