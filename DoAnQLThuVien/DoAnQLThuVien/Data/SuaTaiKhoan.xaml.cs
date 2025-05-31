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
using static Azure.Core.HttpHeader;
using System.Security.Cryptography;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for SuaTaiKhoan.xaml
    /// </summary>
    public partial class SuaTaiKhoan : Window
    {
        public DatnContext context = new DatnContext();
        private TaiKhoanQuanLy taiKhoanHienTai;
        public SuaTaiKhoan(TaiKhoanQuanLy taiKhoan)
        {
            InitializeComponent();
            taiKhoanHienTai = taiKhoan;

            LoadData();

        }

        private void LoadData()
        {
            if (taiKhoanHienTai != null)
            {
                taiKhoantxt.Text = taiKhoanHienTai.TaiKhoan;
                loaiTaiKhoantxt.Text = taiKhoanHienTai.LoaiTk;
                nguoiDungIdtxt.Text = taiKhoanHienTai.NguoiDungId;
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void suabtn_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra tài khoản hợp lệ
            if (string.IsNullOrWhiteSpace(taiKhoantxt.Text) ||
                string.IsNullOrWhiteSpace(matKhautxt.Password) ||
                string.IsNullOrWhiteSpace(xacNhanMatKhautxt.Password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra mật khẩu xác nhận
            if (matKhautxt.Password != xacNhanMatKhautxt.Password)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Tìm tài khoản trong database
                var taiKhoanSua = context.TaiKhoanQuanLies.FirstOrDefault(t => t.NguoiDungId == taiKhoanHienTai.NguoiDungId);
                if (taiKhoanSua != null)
                {
                    // Cập nhật tài khoản
                    taiKhoanSua.TaiKhoan = taiKhoantxt.Text;

                    // Kiểm tra nếu mật khẩu có thay đổi thì mã hóa lại
                    if (taiKhoanHienTai.MatKhau != matKhautxt.Password)
                    {
                        taiKhoanSua.MatKhau = ComputeSha256Hash(matKhautxt.Password);
                    }

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tài khoản: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
