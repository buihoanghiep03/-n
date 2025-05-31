using DoAnQLThuVien.Data;
using DoAnQLThuVien.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnQLThuVien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string loaiTaiKhoan;
        private string nguoiDungId;
        private TheoDoiDangNhap theoDoi;
        public MainWindow(string loaiTaiKhoan, string nguoiDungId, TheoDoiDangNhap theoDoiDangNhap)
        {
            InitializeComponent();
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.nguoiDungId = nguoiDungId;
            this.theoDoi = theoDoiDangNhap;

            // Load thông tin user
            LoadUserInfo();

            // Ẩn các chức năng nếu là User
            if (loaiTaiKhoan == "User")
            {
                QLTaiKhoanbtn.Visibility = Visibility.Collapsed;
                QLNhanSubtn.Visibility = Visibility.Collapsed;
                ThongKebtn.Visibility = Visibility.Collapsed;
            }

            // Mặc định hiển thị giao diện tổng quan
            content.Content = new TongQuan(loaiTaiKhoan);
        }

        private void LoadUserInfo()
        {
            try
            {
                using (var db = new DatnContext())
                {
                    if (loaiTaiKhoan == "Admin")
                    {
                        txtUsername.Text = "ADMIN";
                        txtRole.Text = "Quản trị hệ thống";
                    }
                    else if (loaiTaiKhoan == "User")
                    {
                        var taiKhoan = db.TaiKhoanQuanLies.FirstOrDefault(t => t.NguoiDungId == nguoiDungId);
                        if (taiKhoan != null)
                        {
                            var nhanSu = db.QuanLyNhanSus.FirstOrDefault(n => n.Id == taiKhoan.NguoiDungId);
                            if (nhanSu != null)
                            {
                                txtUsername.Text = nhanSu.TenNhanSu;
                                txtRole.Text = nhanSu.CongViec; // Hoặc bất kỳ trường nào thể hiện công việc
                        
                                // Cập nhật ảnh đại diện
                                if (!string.IsNullOrEmpty(nhanSu.AnhTt))
                                {
                                    userImage.Source = new BitmapImage(new Uri(nhanSu.AnhTt, UriKind.RelativeOrAbsolute));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message);
            }
        }

        public void ShowWithOverlay(Window dialog)
        {
            Overlay.Visibility = Visibility.Visible;
            dialog.Owner = this;
            dialog.ShowDialog();
            Overlay.Visibility = Visibility.Collapsed;
        }

        private string LayAnhNhanSu()
        {
            // Truy vấn database để lấy ảnh nhân sự dựa trên nguoiDungId
            string anhNhanSu = "";
            try
            {
                using (var db = new DatnContext()) // Thay YourDbContext bằng DbContext thực tế
                {
                    var taiKhoan = db.TaiKhoanQuanLies.FirstOrDefault(t => t.NguoiDungId == nguoiDungId);
                    if (taiKhoan != null)
                    {
                        var nhanSu = db.QuanLyNhanSus.FirstOrDefault(n => n.Id == taiKhoan.NguoiDungId);
                        if (nhanSu != null)
                        {
                            anhNhanSu = nhanSu.AnhTt; // Giả sử cột ảnh là AnhTt
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh nhân sự: " + ex.Message);
            }

            return anhNhanSu;
        }


        private void minimizebtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            TongQuan home = new TongQuan(loaiTaiKhoan);
            content.Content = home;
        }

        private void QLSachbtn_Click(object sender, RoutedEventArgs e)
        {
            QLSach qualysach = new QLSach();
            content.Content = qualysach;
        }

        private void MuonTrabtn_Click(object sender, RoutedEventArgs e)
        {
            QLMuon qLMuon = new QLMuon();
            content.Content = qLMuon;
        }

        private void QLKeSachbtn_Click(object sender, RoutedEventArgs e)
        {
            QLKeSach qLKeSachbtn = new QLKeSach();
            content.Content = qLKeSachbtn;
        }

        private void QLDocGiabtn_Click(object sender, RoutedEventArgs e)
        {
            QLDocGia qLDocGia = new QLDocGia();
            content.Content = qLDocGia;
        }

        private void QLNhanSubtn_Click(object sender, RoutedEventArgs e)
        {
            QLNhanSu qLNhanSu = new QLNhanSu();
            content.Content = qLNhanSu;
        }

        private void QLTK_Click(object sender, RoutedEventArgs e)
        {
            QLTaiKhoan qLTaiKhoan = new QLTaiKhoan();
            content.Content = qLTaiKhoan;
        }

        private void ThongKebtn_Click(object sender, RoutedEventArgs e)
        {
            ThongKe thongKe = new ThongKe();
            content.Content = thongKe;
        }

        private void QLDuLieubtn_Click(object sender, RoutedEventArgs e)
        {
            QLDuLieu qLDuLieu = new QLDuLieu(loaiTaiKhoan);
            content.Content = qLDuLieu;
        }

        private void QLTaiKhoanbtn_Click(object sender, RoutedEventArgs e)
        {
            QLTaiKhoan qLTaiKhoan = new QLTaiKhoan();
            content.Content = qLTaiKhoan;
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            if (theoDoi != null)
            {
                using (var context = new DatnContext())
                {
                    var record = context.TheoDoiDangNhaps.Find(theoDoi.Stt);
                    if (record != null)
                    {
                        record.ThoiDiemDangXuat = DateTime.Now.ToString("HH:mm:ss");
                        context.SaveChanges();
                    }
                }
            }

            Application.Current.Shutdown();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (theoDoi != null)
            {
                using (var context = new DatnContext())
                {
                    var record = context.TheoDoiDangNhaps.Find(theoDoi.Stt);
                    if (record != null)
                    {
                        record.ThoiDiemDangXuat = DateTime.Now.ToString("HH:mm:ss");
                        context.SaveChanges();
                    }
                }
            }

            login login = new login();
            login.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

    }
}