using DoAnQLThuVien;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public DatnContext context = new DatnContext();
        public login()
        {
            InitializeComponent();
        }

        private async void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernametxt.Text.Trim();
            string password = passwordbox.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tìm tài khoản trong database
            var account = context.TaiKhoanQuanLies.FirstOrDefault(a => a.TaiKhoan == username);

            if (account != null)
            {
                // Mã hóa mật khẩu nhập vào để so sánh
                string hashedInputPassword = ComputeSha256Hash(password);

                if (account.MatKhau == hashedInputPassword)
                {
                    var theoDoiDangNhap = new TheoDoiDangNhap
                    {
                        TkdangNhap = username,
                        LoaiTk = account.LoaiTk,
                        NgayDangNhap = DateOnly.FromDateTime(DateTime.Now),
                        ThoiDiemDangNhap = DateTime.Now.ToString("HH:mm:ss")
                    };

                    context.TheoDoiDangNhaps.Add(theoDoiDangNhap);
                    context.SaveChanges(); // Lưu ngay để có thể lấy lại ID hoặc đối tượng này

                    // **Mở màn hình Loading**
                    Loading loadingScreen = new Loading();
                    loadingScreen.Show();

                    // **Chạy thanh tiến trình (loading)**
                    await loadingScreen.StartLoading();

                    // **Mở cửa sổ chính**
                    MainWindow main = new MainWindow(account.LoaiTk, account.NguoiDungId, theoDoiDangNhap);
                    main.Show();

                    // Đóng cửa sổ đăng nhập
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void quenMKbtn_Click(object sender, RoutedEventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.Show();
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

        private void timeKiembtn_Click(object sender, RoutedEventArgs e)
        {
            TimKiemWindow timKiemWindow = new TimKiemWindow();
            timKiemWindow.Show();
            this.Close();
        }
    }
}
