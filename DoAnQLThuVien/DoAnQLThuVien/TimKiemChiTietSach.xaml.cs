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
using System.IO;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for TimKiemChiTietSach.xaml
    /// </summary>
    public partial class TimKiemChiTietSach : Window
    {
        public DatnContext context = new DatnContext();
        private ChiTietSach currentBook;
        public TimKiemChiTietSach(ChiTietSach chiTietSach)
        {
            InitializeComponent();
            currentBook = chiTietSach;

            LoadBookData();
        }

        private void LoadBookData()
        {
            if (currentBook != null)
            {
                sachIDtxt.Text = currentBook.Id;
                tenSachtxt.Text = currentBook.TenSach;
                nhomSachcb.Text = currentBook.NhomTheLoai;
                TheLoaicb.Text = currentBook.TheLoai;
                tacGiatxt.Text = currentBook.TacGia;
                nhaXuatBancb.Text = currentBook.NhaXuatBan;
                namXuatBancb.Text = currentBook.NamXuatBan?.ToString() ?? "";
                ngonNgucb.Text = currentBook.NgonNgu;
                ngayNhapSachdp.Text = currentBook.NgayNhapSach?.ToString("yyyy-MM-dd") ?? "";
                ISBNtxt.Text = currentBook.Isbn;
                trangThaicb.Text = currentBook.TinhTrangSach;
                keSachcb.Text = currentBook.KeSach;

                // Kiểm tra xem ảnh có tồn tại không trước khi hiển thị
                if (!string.IsNullOrEmpty(currentBook.AnhBia) && File.Exists(currentBook.AnhBia))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(currentBook.AnhBia, UriKind.Absolute));
                    anhSachImage.Source = bitmap;
                }
                else
                {
                    anhSachImage.Source = null; // Ẩn ảnh nếu không tìm thấy
                }
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
