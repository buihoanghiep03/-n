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
using DoAnQLThuVien.Models;

namespace DoAnQLThuVien
{
    /// <summary>
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class DoiMatKhau : Window
    {
        public DatnContext context = new DatnContext();
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void doiMatKhaubtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maTTtxt.Text) ||
                string.IsNullOrWhiteSpace(moipb.Password) ||
                string.IsNullOrWhiteSpace(xacNhanpb.Password))
            {
                doiMatKhaubtn.IsEnabled = false;
            }

            var nguoiDungId = context.TaiKhoanQuanLies.FirstOrDefault(t => t.NguoiDungId == maTTtxt.Text);
            if (nguoiDungId == null)
            {
                MessageBox.Show("Mã người dùng không tồn tại! Vui lòng nhập lại.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                maTTtxt.Focus(); // Đưa con trỏ về ô nhập
                return;
            }

            if (moipb.Password !=  xacNhanpb.Password)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var matKhauMoi = moipb.Password;
            var maHoaMatKhau = ComputeSha256Hash(matKhauMoi);

            try
            {
                // Tạo đối tượng sách mới
            var doiMatKhau = new TaiKhoanQuanLy
            {
                MatKhau = maHoaMatKhau
            };

            // Thêm vào cơ sở dữ liệu
            context.TaiKhoanQuanLies.Add(doiMatKhau);
            context.SaveChanges();

            // Thông báo thành công
            MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Đóng cửa sổ sau khi thêm thành công
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            login login = new login();
            login.ShowDialog();
            this.Close();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
