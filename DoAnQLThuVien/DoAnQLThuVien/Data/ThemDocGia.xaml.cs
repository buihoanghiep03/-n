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
using Microsoft.Win32;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for ThemDocGia.xaml
    /// </summary>
    public partial class ThemDocGia : Window
    {
        public DatnContext context = new DatnContext();
        public ThemDocGia()
        {
            InitializeComponent();

            LoadComboBoxData();
            ngayDKdp.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Đặt ngày hiện tại
            maDGtxt.Text = GenerateNewId();

            loaiDocGia.ItemsSource = new string[]{ "Phổ thông", "Thiếu niên" ,"Trẻ em", "Nghiên cứu viên" ,"Đặc biệt " };
            loaiDocGia.SelectedIndex = 0; // Chọn giá trị đầu tiên mặc định
        }

        private void LoadComboBoxData()
        {
            // Thêm danh sách năm (1900 - hiện tại)
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= 1900; i--)
            {
                namcb.Items.Add(i);
            }

            // Thêm danh sách tháng (1 - 12)
            for (int i = 1; i <= 12; i++)
            {
                thangcb.Items.Add(i);
            }

            // Mặc định chọn năm, tháng hiện tại
            namcb.SelectedItem = currentYear;
            thangcb.SelectedItem = DateTime.Now.Month;

            // Gọi hàm cập nhật ngày khi thay đổi năm hoặc tháng
            namcb.SelectionChanged += UpdateNgayComboBox;
            thangcb.SelectionChanged += UpdateNgayComboBox;
            UpdateNgayComboBox(null, null);
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

        private string GenerateNewId()
        {
            var lastDocGia = context.QuanLyDocGia
                                    .OrderByDescending(d => d.Id)
                                    .FirstOrDefault();

            if (lastDocGia == null)
            {
                return "DG0000001"; // Trường hợp không có dữ liệu
            }

            // Lấy số thứ tự từ mã DG0000001 -> 0000001
            string numberPart = lastDocGia.Id.Substring(2);
            if (int.TryParse(numberPart, out int number))
            {
                return $"DG{(number + 1):D7}"; // Tăng lên 1 và giữ định dạng 7 chữ số
            }

            return "DG0000001"; // Tránh lỗi nếu dữ liệu không đúng chuẩn
        }


        private void dangkybtn_Click(object sender, RoutedEventArgs e)
        {
            QuanLyDocGium quanLyDocGia = null;
            try
            {

                if (string.IsNullOrWhiteSpace(maDGtxt.Text) ||
                    string.IsNullOrWhiteSpace(tenDGtxt.Text) ||
                    string.IsNullOrWhiteSpace(namcb.Text) ||
                    string.IsNullOrWhiteSpace(thangcb.Text) ||
                    string.IsNullOrWhiteSpace(ngaycb.Text) ||
                    string.IsNullOrWhiteSpace(CCCDtxt.Text) ||
                    string.IsNullOrWhiteSpace(SDTtxt.Text) ||
                    string.IsNullOrWhiteSpace(diaChitxt.Text) ||
                    string.IsNullOrWhiteSpace(ngayDKdp.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Kiểm tra CCCD chỉ được chứa số (không chứa chữ hoặc ký tự đặc biệt)
                if (!CCCDtxt.Text.All(char.IsDigit))
                {
                    MessageBox.Show("CCCD chỉ được chứa số!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Kiểm tra số điện thoại cũng chỉ chứa số
                if (!SDTtxt.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa số!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Lấy giá trị năm, tháng, ngày từ ComboBox
                int year = (int)namcb.SelectedItem;
                int month = (int)thangcb.SelectedItem;
                int day = (int)ngaycb.SelectedItem;

                // Tạo đối tượng DateOnly từ năm, tháng, ngày
                DateOnly ngaySinh = new DateOnly(year, month, day);

                quanLyDocGia = new QuanLyDocGium
                {
                    Id = maDGtxt.Text,
                    HoTen = tenDGtxt.Text,
                    NgaySinh = ngaySinh,
                    LoaiDocGia = loaiDocGia.Text,
                    SoCccd = CCCDtxt.Text,
                    Sdt = SDTtxt.Text,
                    DiaChi = diaChitxt.Text,
                    NgayDangKy = DateOnly.Parse(ngayDKdp.Text),
                    AnhDg = anhDocGiaImage.Source is BitmapImage bitmap ? bitmap.UriSource?.LocalPath : null
                };
                context.QuanLyDocGia.Add(quanLyDocGia);
                context.SaveChanges();
                MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Close();

            
            
            // Mở cửa sổ InTheDocGia và truyền dữ liệu
            InTheDocGia inTheDocGia = new InTheDocGia(
                quanLyDocGia.HoTen,
                DateTime.Now.ToString("yyyy-MM-dd"),
                DateTime.Now.AddYears(1).ToString("yyyy-MM-dd"),
                quanLyDocGia.Id,
                quanLyDocGia.LoaiDocGia,
                quanLyDocGia.AnhDg
            );
            inTheDocGia.ShowDialog();
        }

        private void Browerbtn_Click(object sender, RoutedEventArgs e)
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
                    anhDocGiaImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
