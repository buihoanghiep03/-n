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

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for ThemKeSach.xaml
    /// </summary>
    public partial class ThemKeSach : Window
    {
        public DatnContext context = new DatnContext();

        public ThemKeSach()
        {
            InitializeComponent();

            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            TheLoaiKecb.ItemsSource = nhomLoaiSaches;
            TheLoaiKecb.DisplayMemberPath = "TenNhomSach";
            TheLoaiKecb.SelectedIndex = 0;

            var phongDocs = context.QuanLyPhongDocs.ToList();
            ViTriKecb.ItemsSource = phongDocs;
            ViTriKecb.DisplayMemberPath = "TenPhongDoc";
            ViTriKecb.SelectedIndex = 0;

            maKeSachtxt.Text = GenerateNextKeSachId();
        }

        private void thembtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DatnContext()) // Đảm bảo bạn có DbContext phù hợp
                {

                    // Kiểm tra dữ liệu hợp lệ
                    if (string.IsNullOrEmpty(tenKeSachtxt.Text) ||
                        string.IsNullOrEmpty(loaiKetxt.Text) ||
                        string.IsNullOrEmpty(ViTriKecb.Text) ||
                        string.IsNullOrEmpty(soLuongToiDatxt.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Tạo một đối tượng mới
                    var quanLyKeSach = new QuanLyKeSach
                    {
                        Id = maKeSachtxt.Text,
                        TenKeSach = tenKeSachtxt.Text,
                        LoaiKeSach = loaiKetxt.Text,
                        NhomTheLoaiKe = TheLoaiKecb.Text,
                        ViTriKe = ViTriKecb.Text,
                        SoLuongSachToiDa = int.Parse(soLuongToiDatxt.Text),
                        SoLuongSachHienTai = 0
                    };

                    // Thêm vào database
                    context.QuanLyKeSaches.Add(quanLyKeSach);
                    context.SaveChanges();

                    // Hiển thị thông báo thành công
                    MessageBox.Show($"Thêm kệ sách {tenKeSachtxt.Text} thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Đóng cửa sổ sau khi thêm thành công
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm kệ sách: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Tạo mã kệ sách tự động theo format KS-0001, KS-0002...
        private string GenerateNextKeSachId()
        {
            using (var context = new DatnContext())
            {
                // Lấy danh sách ID có dạng "KS-xxxx"
                var existingIds = context.QuanLyKeSaches
                    .Where(k => k.Id.StartsWith("KS-"))
                    .Select(k => k.Id)
                    .ToList();

                if (existingIds.Count == 0)
                {
                    return "KS-0001"; // Nếu chưa có kệ nào, bắt đầu từ 0001
                }

                // Lấy số lớn nhất từ danh sách ID
                int maxNumber = existingIds
                    .Select(id => ExtractNumber(id))
                    .DefaultIfEmpty(0)
                    .Max();

                // Tăng số lên
                int nextNumber = maxNumber + 1;

                // Định dạng thành chuỗi "KS-xxxx"
                return $"KS-{nextNumber:D4}";
            }
        }

        // Hàm lấy số phía sau "KS-"
        private int ExtractNumber(string id)
        {
            if (id.StartsWith("KS-"))
            {
                string numberPart = id.Substring(3); // Lấy phần sau "KS-"
                if (int.TryParse(numberPart, out int number))
                {
                    return number;
                }
            }
            return 0;
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
