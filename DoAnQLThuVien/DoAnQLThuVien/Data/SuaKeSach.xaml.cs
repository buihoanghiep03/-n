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

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for SuaKeSach.xaml
    /// </summary>
    public partial class SuaKeSach : Window
    {
        public DatnContext context = new DatnContext();
        private QuanLyKeSach keSachHienTai;
        public SuaKeSach(QuanLyKeSach quanLyKeSach)
        {
            InitializeComponent();
            keSachHienTai = quanLyKeSach;

            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            TheLoaiKecb.ItemsSource = nhomLoaiSaches;
            TheLoaiKecb.DisplayMemberPath = "TenNhomSach";

            var phongDocs = context.QuanLyPhongDocs.ToList();
            ViTriKecb.ItemsSource = phongDocs;
            ViTriKecb.DisplayMemberPath = "TenPhongDoc";

            LoadData();
        }

        private void LoadData()
        {
            if (keSachHienTai != null)
            {
                maKeSachtxt.Text = keSachHienTai.Id;
                tenKeSachtxt.Text = keSachHienTai.TenKeSach;
                loaiKetxt.Text = keSachHienTai.LoaiKeSach;
                TheLoaiKecb.Text = keSachHienTai.NhomTheLoaiKe;
                ViTriKecb.Text = keSachHienTai.ViTriKe;
                soLuongToiDatxt.Text = keSachHienTai.SoLuongSachToiDa?.ToString() ?? "";
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void luubtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (keSachHienTai != null)
                {
                    // Lấy đối tượng cần cập nhật từ CSDL
                    var keSach = context.QuanLyKeSaches.FirstOrDefault(k => k.Id == keSachHienTai.Id);
                    if (keSach == null)
                    {
                        MessageBox.Show("Không tìm thấy kệ sách để cập nhật!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Cập nhật thông tin kệ sách
                    keSach.TenKeSach = tenKeSachtxt.Text;
                    keSach.LoaiKeSach = loaiKetxt.Text;
                    keSach.NhomTheLoaiKe = TheLoaiKecb.Text;
                    keSach.ViTriKe = ViTriKecb.Text;

                    // Chuyển đổi số lượng tối đa từ string -> int
                    if (int.TryParse(soLuongToiDatxt.Text, out int soLuongToiDa))
                    {
                        keSach.SoLuongSachToiDa = soLuongToiDa;
                    }
                    else
                    {
                        MessageBox.Show("Số lượng tối đa không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Lưu thay đổi vào CSDL
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật kệ sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close(); // Đóng cửa sổ sau khi lưu thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật kệ sách: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
