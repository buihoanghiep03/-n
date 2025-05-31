using DoAnQLThuVien.Models;
using System;
using System.IO;
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
    /// Interaction logic for SuaDocGia.xaml
    /// </summary>
    public partial class SuaDocGia : Window
    {
        public DatnContext context = new DatnContext();
        private QuanLyDocGium docGiaHienTai;
        public SuaDocGia(QuanLyDocGium docGia)
        {
            InitializeComponent();
            docGiaHienTai = docGia; // Gán giá trị cho biến

            loaiDocGia.ItemsSource = new string[] { "Phổ thông", "Thiếu niên", "Trẻ em", "Nghiên cứu viên", "Đặc biệt " };

            LoadComboBoxData();
            LoadData();
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

        private void suabtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (docGiaHienTai != null)
                {
                    // Lấy giá trị mới từ UI
                    string hoTenMoi = tenDGtxt.Text;
                    string soCccdMoi = CCCDtxt.Text;
                    string loaiDocGiaMoi = loaiDocGia.Text;
                    string sdtMoi = SDTtxt.Text;
                    string diaChiMoi = diaChitxt.Text;

                    DateOnly? ngaySinhMoi = null;
                    if (namcb.SelectedItem != null && thangcb.SelectedItem != null && ngaycb.SelectedItem != null)
                    {
                        int year = (int)namcb.SelectedItem;
                        int month = (int)thangcb.SelectedItem;
                        int day = (int)ngaycb.SelectedItem;
                        ngaySinhMoi = new DateOnly(year, month, day);
                    }

                    // Kiểm tra nếu không có thay đổi thì không lưu
                    if (hoTenMoi == docGiaHienTai.HoTen &&
                        soCccdMoi == docGiaHienTai.SoCccd &&
                        loaiDocGiaMoi == docGiaHienTai.LoaiDocGia &&
                        sdtMoi == docGiaHienTai.Sdt &&
                        diaChiMoi == docGiaHienTai.DiaChi &&
                        ngaySinhMoi == docGiaHienTai.NgaySinh)
                    {
                        MessageBox.Show("Không có thay đổi nào để cập nhật.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    // Cập nhật dữ liệu khi có thay đổi
                    docGiaHienTai.HoTen = hoTenMoi;
                    docGiaHienTai.SoCccd = soCccdMoi;
                    docGiaHienTai.LoaiDocGia = loaiDocGiaMoi;
                    docGiaHienTai.Sdt = sdtMoi;
                    docGiaHienTai.DiaChi = diaChiMoi;
                    docGiaHienTai.NgaySinh = ngaySinhMoi;

                    // Lưu vào CSDL
                    context.QuanLyDocGia.Update(docGiaHienTai);
                    context.SaveChanges();

                    MessageBox.Show("Cập nhật thông tin độc giả thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // Đóng cửa sổ sau khi sửa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData()
        {
            if (docGiaHienTai != null)
            {
                maDGtxt.Text = docGiaHienTai.Id;
                tenDGtxt.Text = docGiaHienTai.HoTen;
                CCCDtxt.Text = docGiaHienTai.SoCccd;
                loaiDocGia.Text = docGiaHienTai.LoaiDocGia;
                SDTtxt.Text = docGiaHienTai.Sdt;
                diaChitxt.Text = docGiaHienTai.DiaChi;
                ngayDKtxt.Text = docGiaHienTai.NgayDangKy?.ToString("yyyy-MM-dd") ?? "";
                if (docGiaHienTai.NgaySinh.HasValue)
                {
                    namcb.SelectedItem = docGiaHienTai.NgaySinh.Value.Year;
                    thangcb.SelectedItem = docGiaHienTai.NgaySinh.Value.Month;
                    ngaycb.SelectedItem = docGiaHienTai.NgaySinh.Value.Day;
                }

                // Kiểm tra xem ảnh có tồn tại không trước khi hiển thị
                if (!string.IsNullOrEmpty(docGiaHienTai.AnhDg) && File.Exists(docGiaHienTai.AnhDg))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(docGiaHienTai.AnhDg, UriKind.Absolute));
                    anhDocGiaImage.Source = bitmap;
                }
                else
                {
                    anhDocGiaImage.Source = null; // Ẩn ảnh nếu không tìm thấy
                }
            }
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
