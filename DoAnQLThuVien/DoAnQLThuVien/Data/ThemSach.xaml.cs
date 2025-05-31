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
    /// Interaction logic for ThemSach.xaml
    /// </summary>
    public partial class ThemSach : Window
    {
        public DatnContext context = new DatnContext();
        private QuanLyDauSach selectedBook;
        public ThemSach(QuanLyDauSach book)
        {
            InitializeComponent();
            selectedBook = book;
            LoadBookData();

            LoadComboBoxData();
        }

        private void ThemSachbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(namXuatBancb.Text, out int namXuatBan))
                {
                    MessageBox.Show("Vui lòng nhập đúng số cho năm xuất bản và số lượng sách!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(soLuongSachMoitxt.Text) &&
                    string.IsNullOrWhiteSpace(soLuongSachBinhThuongtxt.Text) &&
                    string.IsNullOrWhiteSpace(soLuongSachCutxt.Text) &&
                    string.IsNullOrWhiteSpace(soLuongSachHongNhetxt.Text) &&
                    string.IsNullOrWhiteSpace(soLuongSachHongNangtxt.Text))
                {
                    MessageBox.Show("Vui lòng điền số lượng sách trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var sachID = sachIDtxt.Text;

                int GetIntValue(TextBox textBox)
                {
                    return int.TryParse(textBox.Text, out int value) ? value : 0;
                }

                int SoluongSachNhap =
                    GetIntValue(soLuongSachMoitxt) +
                    GetIntValue(soLuongSachBinhThuongtxt) +
                    GetIntValue(soLuongSachCutxt) +
                    GetIntValue(soLuongSachHongNhetxt) +
                    GetIntValue(soLuongSachHongNangtxt);

                // Cập nhật số lượng sách trong nhóm thể loại và thể loại
                var nhomSach = context.NhomLoaiSaches.FirstOrDefault(n => n.TenNhomSach == nhomSachtxt.Text);
                if (nhomSach != null)
                {
                    nhomSach.SoLuongSach += SoluongSachNhap;
                }

                var theLoaiSach = context.TheLoaiSaches.FirstOrDefault(t => t.TheLoai == TheLoaitxt.Text);
                if (theLoaiSach != null)
                {
                    theLoaiSach.SoLuongSach += SoluongSachNhap;
                }

                // Lấy danh sách ID hiện có trong ChiTietSach có cùng sachID
                var danhSachID = context.ChiTietSaches
                    .Where(s => s.Id.StartsWith(sachID)) // Lọc ID phù hợp
                    .Select(s => s.Id) // Lấy toàn bộ ID
                    .AsEnumerable() // Chuyển sang xử lý trong bộ nhớ (RAM)
                    .Select(id => id.Length >= sachID.Length + 3 ? id.Substring(id.Length - 3) : "001") // Lấy 3 số cuối
                    .Where(id => int.TryParse(id, out _)) // Giữ ID là số hợp lệ
                    .Select(id => int.Parse(id)) // Chuyển thành số
                    .ToList();


                // Xác định số thứ tự lớn nhất hiện có (nếu không có ID nào, bắt đầu từ 001)
                int soThuTuHienTai = danhSachID.Any() ? danhSachID.Max() : 0;

                // Thêm chi tiết sách dựa trên số lượng nhập vào
                for (int i = 1; i <= SoluongSachNhap; i++)
                {
                    soThuTuHienTai++; // Tăng số thứ tự
                    string tinhTrangSach;
                    if (i <= int.Parse(soLuongSachMoitxt.Text))
                        tinhTrangSach = "Mới";
                    else if (i <= int.Parse(soLuongSachMoitxt.Text) + int.Parse(soLuongSachBinhThuongtxt.Text))
                        tinhTrangSach = "Bình thường";
                    else if (i <= int.Parse(soLuongSachMoitxt.Text) + int.Parse(soLuongSachBinhThuongtxt.Text) + int.Parse(soLuongSachCutxt.Text))
                        tinhTrangSach = "Cũ";
                    else if (i <= int.Parse(soLuongSachMoitxt.Text) + int.Parse(soLuongSachBinhThuongtxt.Text) + int.Parse(soLuongSachCutxt.Text) + int.Parse(soLuongSachHongNhetxt.Text))
                        tinhTrangSach = "Hư hỏng nhẹ";
                    else
                        tinhTrangSach = "Hư hỏng nặng";

                    // Kiểm tra tình trạng sách để đặt TinhTrangMuon
                    string tinhTrangMuon = (tinhTrangSach == "Mới" || tinhTrangSach == "Bình thường") ? "Khả dụng" : "Không khả dụng";

                    // Lấy giá trị năm, tháng, ngày từ ComboBox
                    int year = (int)namcb.SelectedItem;
                    int month = (int)thangcb.SelectedItem;
                    int day = (int)ngaycb.SelectedItem;

                    // Tạo đối tượng DateOnly từ năm, tháng, ngày
                    DateOnly ngaynhapsach = new DateOnly(year, month, day);

                    var chiTietSach = new ChiTietSach
                    {
                        Id = $"{sachIDtxt.Text}-{soThuTuHienTai:D3}", // Mã ID có dạng: SachID001, SachID002,...
                        TenSach = tenSachtxt.Text,
                        NhomTheLoai = nhomSachtxt.Text,
                        TheLoai = TheLoaitxt.Text,
                        TacGia = tacGiatxt.Text,
                        NhaXuatBan = nhaXuatBancb.Text,
                        NamXuatBan = namXuatBan,
                        Isbn = ISBNtxt.Text,
                        NgonNgu = ngonNgucb.Text,
                        NgayNhapSach = ngaynhapsach,
                        GioiHanDocGia = gioiHanNguoiDoctxt.Text,
                        TinhTrangSach = tinhTrangSach,
                        TinhTrangMuon = tinhTrangMuon,
                        KeSach = "Trong kho",
                        AnhBia = anhSachImage.Source is BitmapImage bitmap ? bitmap.UriSource?.LocalPath : null
                    };

                    context.ChiTietSaches.Add(chiTietSach);
                }

                context.SaveChanges();

                MessageBox.Show("Thêm dữ liệu đầu sách và dữ liệu từng quyển sách mới thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadBookData()
        {
            if (selectedBook != null)
            {
                sachIDtxt.Text = selectedBook.Id;
                tenSachtxt.Text = selectedBook.TenSach;
                nhomSachtxt.Text = selectedBook.NhomSach;
                TheLoaitxt.Text = selectedBook.TheLoai;
                tacGiatxt.Text = selectedBook.TacGia;
                nhaXuatBancb.Text = selectedBook.NhaXuatBan;
                namXuatBancb.Text = selectedBook.NamXuatBan.ToString();
                ISBNtxt.Text = selectedBook.Isbn;
                ngonNgucb.Text = selectedBook.NgonNgu;

                // Tách NgayNhapSach thành năm, tháng, ngày
                if (selectedBook.NgayNhapSach.HasValue)
                {
                    DateOnly ngayNhap = selectedBook.NgayNhapSach.Value;
                    namcb.Text = ngayNhap.Year.ToString();  
                    thangcb.Text = ngayNhap.Month.ToString();
                    ngaycb.Text = ngayNhap.Day.ToString();
                }
                else
                {
                    namcb.Text = "";
                    thangcb.Text = "";
                    ngaycb.Text = "";
                }
                gioiHanNguoiDoctxt.Text = selectedBook.GioiHanDocGia;
                soLuongSachMoitxt.Text = "0";
                soLuongSachBinhThuongtxt.Text = "0";
                soLuongSachCutxt.Text = "0";
                soLuongSachHongNhetxt.Text = "0";
                soLuongSachHongNangtxt.Text = "0";

                // Kiểm tra nếu ảnh bìa tồn tại thì hiển thị, nếu không thì bỏ qua
                if (!string.IsNullOrEmpty(selectedBook.AnhBia) && File.Exists(selectedBook.AnhBia))
                {
                    anhSachImage.Source = new BitmapImage(new Uri(selectedBook.AnhBia, UriKind.RelativeOrAbsolute));
                }
                else
                {
                    anhSachImage.Source = null; // Không hiển thị gì nếu ảnh không tồn tại
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
        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
