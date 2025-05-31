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
using System.IO;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for SuaNhanSu.xaml
    /// </summary>
    public partial class SuaNhanSu : Window
    {
        public DatnContext context = new DatnContext();
        private QuanLyNhanSu nhanSuHienTai;

        public SuaNhanSu(QuanLyNhanSu quanLyNhanSu)
        {
            InitializeComponent();
            nhanSuHienTai = quanLyNhanSu;

            gioiTinhcb.ItemsSource = new List<string> { "Nam", "Nữ" };
            gioiTinhcb.SelectedIndex = 0;

            var quanLyCongViecs = context.QuanLyCongViecs.ToList();
            congVieccb.ItemsSource = quanLyCongViecs;
            congVieccb.DisplayMemberPath = "CongViec";

            // Gán sự kiện khi thay đổi công việc
            congVieccb.SelectionChanged += congVieccb_SelectionChanged;

            LoadComboBoxData(); // <--- Gọi hàm này để nạp dữ liệu cho ComboBox ngày/tháng/năm
            LoadData();
        }


        private void savebtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (nhanSuHienTai != null)
                {
                    nhanSuHienTai.TenNhanSu = tenNhanSutxt.Text;
                    nhanSuHienTai.Cccd = soCCCDtxt.Text;
                    nhanSuHienTai.DiaChi = noiOtxt.Text;
                    nhanSuHienTai.Email = emailtxt.Text;
                    nhanSuHienTai.Sdt = soDienThoaitxt.Text;
                    nhanSuHienTai.LoaiNhanSu = loaiNhanSutxt.Text;
                    nhanSuHienTai.LuongCoBan = decimal.TryParse(luongCoBantxt.Text, out decimal luong) ? luong : null;

                    if (gioiTinhcb.SelectedItem != null)
                    {
                        nhanSuHienTai.GioiTinh = gioiTinhcb.SelectedItem.ToString();
                    }

                    if (congVieccb.SelectedItem != null)
                    {
                        nhanSuHienTai.CongViec = ((QuanLyCongViec)congVieccb.SelectedItem).CongViec;
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

                    nhanSuHienTai.NgaySinh = ngaySinh;
                    nhanSuHienTai.NgayBatDau = ngaybatdau;

                    context.QuanLyNhanSus.Update(nhanSuHienTai);
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin nhân sự thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData()
        {
            if (nhanSuHienTai != null)
            {
                if (!string.IsNullOrEmpty(nhanSuHienTai.Id))
                {
                    var parts = nhanSuHienTai.Id.Split('-'); // Tách chuỗi theo dấu '-'
                    if (parts.Length == 2)
                    {
                        maTatCVtxt.Text = parts[0];  // Phần chữ (TT)
                        maNhanSutxt.Text = parts[1]; // Phần số (00001)
                    }
                    else
                    {
                        maTatCVtxt.Text = nhanSuHienTai.Id; // Trường hợp lỗi, gán toàn bộ
                        maNhanSutxt.Text = "";
                    }
                }
                tenNhanSutxt.Text = nhanSuHienTai.TenNhanSu;
                soCCCDtxt.Text = nhanSuHienTai.Cccd;
                noiOtxt.Text = nhanSuHienTai.DiaChi;
                emailtxt.Text = nhanSuHienTai.Email;
                soDienThoaitxt.Text = nhanSuHienTai.Sdt;
                congVieccb.Text = nhanSuHienTai.CongViec;
                loaiNhanSutxt.Text = nhanSuHienTai.LoaiNhanSu;
                luongCoBantxt.Text = nhanSuHienTai.LuongCoBan?.ToString() ?? string.Empty;

                if (nhanSuHienTai.NgaySinh.HasValue)
                {
                    namcb.SelectedItem = nhanSuHienTai.NgaySinh.Value.Year;
                    thangcb.SelectedItem = nhanSuHienTai.NgaySinh.Value.Month;
                    ngaycb.SelectedItem = nhanSuHienTai.NgaySinh.Value.Day;
                }

                if (nhanSuHienTai.NgayBatDau.HasValue)
                {
                    nambatdaucb.SelectedItem = nhanSuHienTai.NgayBatDau.Value.Year;
                    thangbatdaucb.SelectedItem = nhanSuHienTai.NgayBatDau.Value.Month;
                    ngaybatdaucb.SelectedItem = nhanSuHienTai.NgayBatDau.Value.Day;
                }

                // Kiểm tra xem ảnh có tồn tại không trước khi hiển thị
                if (!string.IsNullOrEmpty(nhanSuHienTai.AnhTt) && File.Exists(nhanSuHienTai.AnhTt))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(nhanSuHienTai.AnhTt, UriKind.Absolute));
                    imagiPicture.Source = bitmap;
                }
                else
                {
                    imagiPicture.Source = null; // Ẩn ảnh nếu không tìm thấy
                }
            }
        }

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

            int oldSelectedDay = ngaycb.SelectedItem != null ? (int)ngaycb.SelectedItem : 1; // Lưu ngày cũ

            ngaycb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngaycb.Items.Add(i);
            }

            // Đặt lại ngày cũ nếu hợp lệ, nếu không thì chọn ngày 1
            ngaycb.SelectedValue = ngaycb.Items.Contains(oldSelectedDay) ? oldSelectedDay : 1;
        }

        private void UpdateNgayBatDauComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (nambatdaucb.SelectedItem == null || thangbatdaucb.SelectedItem == null)
                return;

            int year = (int)nambatdaucb.SelectedItem;
            int month = (int)thangbatdaucb.SelectedItem;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int oldSelectedDay = ngaybatdaucb.SelectedItem != null ? (int)ngaybatdaucb.SelectedItem : 1;

            ngaybatdaucb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngaybatdaucb.Items.Add(i);
            }

            ngaybatdaucb.SelectedValue = ngaybatdaucb.Items.Contains(oldSelectedDay) ? oldSelectedDay : 1;
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


        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
