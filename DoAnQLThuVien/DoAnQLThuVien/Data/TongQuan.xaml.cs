using System.Windows;
using System.Windows.Controls;

namespace DoAnQLThuVien.Data
{
    public partial class TongQuan : UserControl
    {
        private string loaiTaiKhoan;
        
        public TongQuan(string loaiTaiKhoan)
        {
            InitializeComponent();
            this.loaiTaiKhoan = loaiTaiKhoan;
        }

        private void nhomLoaiSachbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.content.Content = new QLDuLieu(loaiTaiKhoan);
            }
        }

        private void dauSachbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.content.Content = new DanhSachDauSach();
            }
        }

        private void docGiabtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.content.Content = new QLDocGia();
            }
        }

        private void muonTrabtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.content.Content = new QLMuon();
            }
        }
    }
}