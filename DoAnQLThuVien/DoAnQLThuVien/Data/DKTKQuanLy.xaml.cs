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
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for DKTKQuanLy.xaml
    /// </summary>
    public partial class DKTKQuanLy : Window
    {
        public DatnContext context = new DatnContext();
        public DKTKQuanLy()
        {
            InitializeComponent();

            loaiTaiKhoancb.ItemsSource = new List<string> { "Admin", "User" };
            loaiTaiKhoancb.SelectedIndex = 0;

            var quanLyNhanSus = context.QuanLyNhanSus.ToList();
            maThuThucb.ItemsSource = quanLyNhanSus;
            maThuThucb.DisplayMemberPath = "Id";
            maThuThucb.SelectedIndex = 0;

            updateMaThuThu();
        }

        private void thembtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(taiKhoantxt.Text) ||
                    string.IsNullOrWhiteSpace(matKhautxt.Password) ||
                    string.IsNullOrWhiteSpace(xacNhanMatKhautxt.Password) ||
                    string.IsNullOrWhiteSpace(loaiTaiKhoancb.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; // Dừng lại nếu có ô trống
                }

                if (context.TaiKhoanQuanLies.Any(user => user.TaiKhoan == taiKhoantxt.Text))
                {
                    MessageBox.Show("Tài khoản đã tồn tại! Hãy sử dụng tài khoản khác", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (matKhautxt.Password != xacNhanMatKhautxt.Password)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Kiểm tra loại nhân sự thay vì công việc
                var nhanVienQuanLy = context.QuanLyNhanSus
                    .FirstOrDefault(e => e.Id == maThuThucb.Text && e.LoaiNhanSu == "Nhân viên quản lý");

                if (nhanVienQuanLy == null && !string.IsNullOrWhiteSpace(maThuThucb.Text))
                {
                    MessageBox.Show("Nhân viên quản lý Id không hợp lệ hoặc nhân sự này không phải là nhân viên quản lý.",
                        "Thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var matKhau = matKhautxt.Password;
                var maHoaMatKhau = ComputeSha256Hash(matKhau);

                // Tạo đối tượng tài khoản mới
                var taiKhoanQuanLy = new TaiKhoanQuanLy
                {
                    TaiKhoan = taiKhoantxt.Text,
                    MatKhau = maHoaMatKhau,
                    LoaiTk = loaiTaiKhoancb.Text,
                    NguoiDungId = !string.IsNullOrWhiteSpace(maThuThucb.Text) ? maThuThucb.Text : adminIdtxt.Text,
                    NgayTao = DateOnly.FromDateTime(DateTime.Now)
                };

                // Thêm vào cơ sở dữ liệu
                context.TaiKhoanQuanLies.Add(taiKhoanQuanLy);
                context.SaveChanges();

                // Thông báo thành công
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                // Đóng cửa sổ sau khi thêm thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm tài khoản: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void loaiTaiKhoancb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMaThuThu();
        }

        private void updateMaThuThu()
        {
            if (loaiTaiKhoancb.SelectedItem != null)
            {
                string selectedValue = loaiTaiKhoancb.SelectedItem.ToString();

                // Bật/tắt combobox maThuThucb dựa vào giá trị được chọn
                maThuThucb.IsEnabled = selectedValue == "User";

                if (maThuThucb.IsEnabled)
                {
                    var quanLyNhanSus = context.QuanLyNhanSus.ToList();
                    maThuThucb.ItemsSource = quanLyNhanSus;
                    maThuThucb.DisplayMemberPath = "Id";
                    maThuThucb.SelectedIndex = 0;
                }
                else
                {
                    maThuThucb.ItemsSource = null;
                }

                // Nếu chọn "User", vô hiệu hóa adminIdtxt
                adminIdtxt.IsEnabled = !(selectedValue == "User");
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Check if input is null or empty
            if (string.IsNullOrEmpty(rawData))
            {
                return string.Empty; // Return an empty string for null or empty input
            }

            // Create a SHA256 instance   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void HienMatKhau_Checked(object sender, RoutedEventArgs e)
        {
            matKhauTextBox.Text = matKhautxt.Password;
            matKhauTextBox.Visibility = Visibility.Visible;
            matKhautxt.Visibility = Visibility.Hidden;
        }

        private void HienMatKhau_Unchecked(object sender, RoutedEventArgs e)
        {
            matKhautxt.Password = matKhauTextBox.Text;
            matKhautxt.Visibility = Visibility.Visible;
            matKhauTextBox.Visibility = Visibility.Hidden;
        }
    }
}
