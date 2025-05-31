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
    /// Interaction logic for QLTheLoaiSach.xaml
    /// </summary>
    public partial class QLDuLieu : UserControl
    {
        private string loaiTaiKhoan;
        public QLDuLieu(string loaiTaiKhoan)
        {
            InitializeComponent();
            this.loaiTaiKhoan = loaiTaiKhoan;

            // Ẩn chức năng nếu là User
            if (loaiTaiKhoan == "User")
            {
                congViecbtn.Visibility = Visibility.Collapsed;
            }

            QLNhomTheLoai nhomLoaiSach = new QLNhomTheLoai();
            content.Content = nhomLoaiSach;
        }

        private void nhomTheLoaibtn_Click(object sender, RoutedEventArgs e)
        {
            QLNhomTheLoai nhomLoaiSach = new QLNhomTheLoai();
            content.Content = nhomLoaiSach;
        }

        private void theLoaiSachbtn_Click(object sender, RoutedEventArgs e)
        {
            QLTheLoai theLoaiSach = new QLTheLoai();
            content.Content = theLoaiSach;
        }

        private void congViecbtn_Click(object sender, RoutedEventArgs e)
        {
            QLCongViec congViec = new QLCongViec();
            content.Content = congViec;
        }

        private void nhaXuatBanbtn_Click(object sender, RoutedEventArgs e)
        {
            QLNhaXuatBan nhaXuatBan = new QLNhaXuatBan();
            content.Content = nhaXuatBan;
        }

        private void phongDocbtn_Click(object sender, RoutedEventArgs e)
        {
            QLPhongDoc qLPhongDoc = new QLPhongDoc();
            content.Content = qLPhongDoc;
        }

    }
}
