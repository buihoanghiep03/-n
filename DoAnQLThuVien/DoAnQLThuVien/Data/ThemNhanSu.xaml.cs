using DoAnQLThuVien.Models;
using Microsoft.Win32;
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
    /// Interaction logic for ThemNhanSu.xaml
    /// </summary>
    public partial class ThemNhanSu : Window
    {
        public ThemNhanSu()
        {
            InitializeComponent();

            gioiTinhcb.ItemsSource = new List<string> { "Nam", "Nữ" };
            gioiTinhcb.SelectedIndex = 0;

            var quanLyCongViecs = context.QuanLyCongViecs.ToList();
            congVieccb.ItemsSource = quanLyCongViecs;
            congVieccb.DisplayMemberPath = "CongViec";
            congVieccb.SelectedIndex = 0;

            // Gán sự kiện khi thay đổi công việc
            congVieccb.SelectionChanged += congVieccb_SelectionChanged;

            GenerateNextBookId();

            LoadComboBoxData();

        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maNhanSutxt.Text) ||
                    string.IsNullOrWhiteSpace(maTatCVtxt.Text) ||
                    string.IsNullOrWhiteSpace(tenNhanSutxt.Text) ||
                    string.IsNullOrWhiteSpace(gioiTinhcb.Text) ||
                    string.IsNullOrWhiteSpace(namcb.Text) ||
                    string.IsNullOrWhiteSpace(thangcb.Text) ||
                    string.IsNullOrWhiteSpace(ngaycb.Text) ||
                    string.IsNullOrWhiteSpace(soCCCDtxt.Text) ||
                    string.IsNullOrWhiteSpace(emailtxt.Text) ||
                    string.IsNullOrWhiteSpace(soDienThoaitxt.Text) ||
                    string.IsNullOrWhiteSpace(noiOtxt.Text) ||
                    string.IsNullOrWhiteSpace(luongCoBantxt.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; // Dừng lại nếu có ô trống
                }

                if (!decimal.TryParse(luongCoBantxt.Text, out var luongCoBan))
                {
                    MessageBox.Show("Lương cơ bản không hợp lệ. Vui lòng nhập đúng định dạng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Lấy giá trị năm, tháng, ngày từ ComboBox
                int year = (int)namcb.SelectedItem;
                int month = (int)thangcb.SelectedItem;
                int day = (int)ngaycb.SelectedItem;

                // Lấy giá trị năm, tháng, ngày từ ComboBox
                int yearbatdau = (int)nambatdaucb.SelectedItem;
                int monthbatdau = (int)thangbatdaucb.SelectedItem;
                int daybatdau = (int)ngaybatdaucb.SelectedItem;

                // Tạo đối tượng DateOnly từ năm, tháng, ngày
                DateOnly ngaySinh = new DateOnly(year, month, day);

                // Tạo đối tượng DateOnly từ năm, tháng, ngày
                DateOnly ngaybatdau = new DateOnly(yearbatdau, monthbatdau, daybatdau);

                var nhanSuId = $"{maTatCVtxt.Text}-{maNhanSutxt.Text}";

                // Tạo đối tượng sách mới
                var nhanSuMoi = new QuanLyNhanSu
                {
                    Id = nhanSuId,
                    TenNhanSu = tenNhanSutxt.Text,
                    GioiTinh = gioiTinhcb.Text,
                    NgaySinh = ngaySinh,
                    Cccd = soCCCDtxt.Text,
                    Email = emailtxt.Text,
                    Sdt = soDienThoaitxt.Text,
                    DiaChi = noiOtxt.Text,
                    NgayBatDau = ngaybatdau,
                    CongViec = congVieccb.Text,
                    LoaiNhanSu = loaiNhanSutxt.Text,
                    LuongCoBan = luongCoBan,
                    AnhTt = imagiPicture.Source is BitmapImage bitmap ? bitmap.UriSource?.LocalPath : null
                };

                // Thêm vào cơ sở dữ liệu
                context.QuanLyNhanSus.Add(nhanSuMoi);
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

        private void GenerateNextBookId()
        {
            using (var context = new DatnContext()) // Thay bằng DbContext của bạn
            {
                string prefix = $"{maTatCVtxt.Text}-"; // Tiền tố ID từ các phần đã nhập
                var existingIds = context.QuanLyDauSaches
                    .Where(q => q.Id.StartsWith(prefix))
                    .Select(q => q.Id)
                    .ToList();

                if (existingIds.Count == 0)
                {
                    maNhanSutxt.Text = "0001"; // Nếu chưa có sách nào, bắt đầu từ 0001
                    return;
                }

                // Lấy số lớn nhất từ danh sách ID
                int maxNumber = existingIds
                    .Select(id => ExtractNumber(id))
                    .DefaultIfEmpty(0)
                    .Max();

                // Tăng số đầu sách
                int nextNumber = maxNumber + 1;

                // Xác định số chữ số cần có: tối thiểu 7 số, nếu lớn hơn thì giữ nguyên độ dài
                int minDigits = Math.Max(7, nextNumber.ToString().Length);

                // Định dạng số thành chuỗi với số chữ số phù hợp
                maNhanSutxt.Text = nextNumber.ToString($"D{minDigits}");
            }
        }

        // Hàm lấy số cuối cùng sau dấu "-"
        private int ExtractNumber(string id)
        {
            string[] parts = id.Split('-');
            if (parts.Length > 0 && int.TryParse(parts.Last(), out int number))
            {
                return number;
            }
            return 0;
        }

        private void congVieccb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (congVieccb.SelectedItem is QuanLyCongViec selectedJob)
            {
                maTatCVtxt.Text = selectedJob.MaTat;
                luongCoBantxt.Text = selectedJob.LuongCoBan?.ToString() ?? "0";

                // Kiểm tra loại công việc và cập nhật loaiNhanSutxt
                if (selectedJob.LoaiCongViec == "Bình thường")
                {
                    loaiNhanSutxt.Text = "Nhân viên bình thường";
                }
                else if (selectedJob.LoaiCongViec == "Quản lý")
                {
                    loaiNhanSutxt.Text = "Nhân viên quản lý";
                }
                else
                {
                    loaiNhanSutxt.Text = ""; // Nếu có loại khác, có thể để trống hoặc xử lý tùy theo yêu cầu
                }
            }
        }

        private void browsebtn_Clck(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.png, *.gif)|*.jpg;*.png;*.gif",
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(dialog.FileName, UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    imagiPicture.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public DatnContext context = new DatnContext();


        private void LoadComboBoxData()
        {
            // Thêm danh sách năm (1900 - hiện tại)
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= 1900; i--)
            {
                namcb.Items.Add(i);
                nambatdaucb.Items.Add(i);
            }

            // Thêm danh sách tháng (1 - 12)
            for (int i = 1; i <= 12; i++)
            {
                thangcb.Items.Add(i);
                thangbatdaucb.Items.Add(i);
            }

            // Mặc định chọn năm, tháng hiện tại
            namcb.SelectedItem = currentYear;
            thangcb.SelectedItem = DateTime.Now.Month;
            nambatdaucb.SelectedItem = currentYear;
            thangbatdaucb.SelectedItem = DateTime.Now.Month;

            // Gọi hàm cập nhật ngày khi thay đổi năm hoặc tháng
            namcb.SelectionChanged += UpdateNgayComboBox;
            thangcb.SelectionChanged += UpdateNgayComboBox;
            nambatdaucb.SelectionChanged += UpdateNgayBatDauComboBox;
            thangbatdaucb.SelectionChanged += UpdateNgayBatDauComboBox;

            UpdateNgayComboBox(null, null);
            UpdateNgayBatDauComboBox(null, null);
        }

        private void UpdateNgayComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (namcb.SelectedItem == null || thangcb.SelectedItem == null)
                return;

            int year = (int)namcb.SelectedItem;
            int month = (int)thangcb.SelectedItem;

            int daysInMonth = DateTime.DaysInMonth(year, month);

            ngaycb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngaycb.Items.Add(i);
            }

            // Chọn ngày mặc định là 1 hoặc giữ nguyên nếu có giá trị hợp lệ
            ngaycb.SelectedIndex = Math.Min(ngaycb.Items.Count - 1, 0);
        }

        private void UpdateNgayBatDauComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (nambatdaucb.SelectedItem == null || thangbatdaucb.SelectedItem == null)
                return;

            int year = (int)nambatdaucb.SelectedItem;
            int month = (int)thangbatdaucb.SelectedItem;

            int daysInMonth = DateTime.DaysInMonth(year, month);

            ngaybatdaucb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngaybatdaucb.Items.Add(i);
            }

            // Chọn ngày mặc định là 1 hoặc giữ nguyên nếu có giá trị hợp lệ
            ngaybatdaucb.SelectedIndex = Math.Min(ngaybatdaucb.Items.Count - 1, 0);
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
