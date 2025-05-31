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
using static Azure.Core.HttpHeader;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for NhomSach.xaml
    /// </summary>
    public partial class QLNhomTheLoai : UserControl
    {
        public DatnContext context = new DatnContext();
        private List<NhomLoaiSach> danhSachNhomLoaiSach;
        public QLNhomTheLoai()
        {
            InitializeComponent();

            load();
        }

        public void load()
        {
            var nhomLoaiSaches = context.NhomLoaiSaches.AsQueryable();
            datagrid.ItemsSource = nhomLoaiSaches.OrderBy(e => e.Id).ToList();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is NhomLoaiSach selectedNhom)
            {
                maNTLtxt.Text = selectedNhom.Id;
                tenNTLtxt.Text = selectedNhom.TenNhomSach;
                maTattxt.Text = selectedNhom.MaTat;
            }
        }

        private void thembtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maNTLtxt.Text) ||
                    string.IsNullOrWhiteSpace(maTattxt.Text) ||
                    string.IsNullOrWhiteSpace(tenNTLtxt.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var nhomLoaiSachs = new NhomLoaiSach
                {
                    Id = maNTLtxt.Text,
                    TenNhomSach = tenNTLtxt.Text,
                    MaTat = maTattxt.Text,
                    SoLuongTheLoai = 0,
                    SoLuongSach = 0

                };
                context.NhomLoaiSaches.Add(nhomLoaiSachs);
                context.SaveChanges();

                MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                maNTLtxt.Text = "";
                tenNTLtxt.Text = "";
                maTattxt.Text = "";

                load();
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void suabtn_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is NhomLoaiSach selectedNhom)
            {
                try
                {
                    var nhomLoaiSach = context.NhomLoaiSaches.SingleOrDefault(n => n.Id == selectedNhom.Id);
                    if (nhomLoaiSach != null)
                    {
                        // Cập nhật thông tin từ TextBox vào đối tượng
                        nhomLoaiSach.TenNhomSach = tenNTLtxt.Text;
                        nhomLoaiSach.MaTat = maTattxt.Text;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        context.SaveChanges();

                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        maNTLtxt.Text = "";
                        tenNTLtxt.Text = "";
                        maTattxt.Text = "";

                        load(); // Tải lại danh sách để cập nhật giao diện
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhóm thể loại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var nhomTheLoaiId = button.Tag?.ToString();
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm thể loại có ID: {nhomTheLoaiId}?",
                                             "Xác nhận xóa",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    return;
                }

                using (var context = new DatnContext())
                {
                    var nhomLoaiSach = context.NhomLoaiSaches.SingleOrDefault(tl => tl.Id == nhomTheLoaiId);
                    if (nhomLoaiSach != null)
                    {
                        context.NhomLoaiSaches.Remove(nhomLoaiSach);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thể loại để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                // Load lại danh sách sau khi xóa
                load();
            }
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = danhSachNhomLoaiSach; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.NhomLoaiSaches
                        .Where(cv => (cv.Id != null && cv.Id.ToLower().Contains(keyword)) ||
                                     (cv.TenNhomSach != null && cv.TenNhomSach.ToLower().Contains(keyword)) ||
                                     (cv.MaTat != null && cv.MaTat.ToLower().Contains(keyword)))
                        .ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }
    }
}
