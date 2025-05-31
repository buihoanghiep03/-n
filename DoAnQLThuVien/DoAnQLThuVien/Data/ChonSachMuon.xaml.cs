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
    /// Interaction logic for ChonSachMuon.xaml
    /// </summary>
    public partial class ChonSachMuon : Window
    {
        public DatnContext context = new DatnContext();
        private List<ChiTietSach> danhSachSach;
        private dkmuon dkMuonWindow;
        private Dictionary<string, bool> selectedBooks = new Dictionary<string, bool>();
        private string loaiDocGia;
        private int soLuongMuon;

        public ChonSachMuon(dkmuon window, string loaiDocGia, int SoLuongMuon)
        {
            InitializeComponent();

            this.loaiDocGia = loaiDocGia;
            this.soLuongMuon = SoLuongMuon;

            // Lấy danh sách nhóm loại sách
            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            nhomTheLoaicb.ItemsSource = nhomLoaiSaches;
            nhomTheLoaicb.DisplayMemberPath = "TenNhomSach";

            // Gán sự kiện khi nhóm sách thay đổi
            nhomTheLoaicb.SelectionChanged += nhomTheLoaicb_SelectionChanged;

            UpdateTheLoaiComboBox();

            dkMuonWindow = window;
            load();
        }

        private void chonbtn_Click(object sender, RoutedEventArgs e)
        {
            // Lọc sách đã chọn từ danh sách ban đầu dựa trên Dictionary
            var sachDuocChon = danhSachSach.Where(s => selectedBooks.TryGetValue(s.Id, out bool isSelected) && isSelected).ToList();

            if (!sachDuocChon.Any())
            {
                MessageBox.Show("Vui lòng chọn ít nhất một quyển sách!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra nếu số lượng sách chọn vượt quá giới hạn
            if (sachDuocChon.Count > soLuongMuon)
            {
                MessageBox.Show($"Bạn chỉ được mượn tối đa {soLuongMuon} quyển sách. Vui lòng chọn lại!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var sach in sachDuocChon)
            {
                if (!KiemTraSachPhuHopVoiDocGia(sach))
                {
                    MessageBox.Show($"Sách '{sach.TenSach}' không phù hợp với loại độc giả '{loaiDocGia}'.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    continue;
                }
                dkMuonWindow.AddBookToDataGrid(sach); // Truyền sách về dkMuonWindow
            }

            this.Close(); // Đóng cửa sổ sau khi chọn xong
        }

        private bool KiemTraSachPhuHopVoiDocGia(ChiTietSach sach)
        {
            // Kiểm tra nếu không có thông tin loại độc giả hoặc nhóm thể loại của sách
            if (string.IsNullOrEmpty(loaiDocGia) || string.IsNullOrEmpty(sach.GioiHanDocGia))
                return false;

            // Điều kiện kiểm tra dựa trên loại độc giả
            switch (loaiDocGia)
            {
                case "Trẻ em":
                    // Trẻ em chỉ được mượn sách thuộc nhóm "Thiếu nhi"
                    return sach.GioiHanDocGia == "Thiếu nhi";

                case "Thiếu niên":
                    // Thiếu niên không được mượn sách dành cho "Người trưởng thành", "Nhà nghiên cứu" hoặc "Đối tượng đặc biệt"
                    return sach.GioiHanDocGia != "Người trưởng thành" && sach.GioiHanDocGia != "Nhà nghiên cứu" && sach.GioiHanDocGia != "Đối tượng đặc biệt";

                case "Nghiên cứu viên":
                    // Nghiên cứu viên có thể mượn tất cả sách trừ "Đối tượng đặc biệt"
                    return sach.GioiHanDocGia != "Đối tượng đặc biệt";

                case "Đặc biệt":
                    // Đối tượng đặc biệt không được mượn sách "Cấm mượn"
                    return sach.GioiHanDocGia != "Cấm mượn";
            }

            return true; // Mặc định cho phép nếu không thuộc điều kiện nào
        }

        public void load()
        {
            var chiTietSaches = context.ChiTietSaches.AsQueryable();
            danhSachSach = context.ChiTietSaches.OrderBy(e => e.Id).ToList();
            datagrid.ItemsSource = danhSachSach;
        }

        private void nhomTheLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTheLoaiComboBox();
        }

        private void theLoaicb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterDataGrid();
        }

        private void FilterDataGrid()
        {
            if (nhomTheLoaicb.SelectedItem is NhomLoaiSach selectedNhom)
            {
                if (theLoaicb.SelectedItem is TheLoaiSach selectedTheLoai)
                {
                    // Lọc theo nhóm thể loại và thể loại nếu cả hai được chọn
                    danhSachSach = context.ChiTietSaches
                        .Where(s => s.NhomTheLoai == selectedNhom.TenNhomSach && s.TheLoai == selectedTheLoai.TheLoai)
                        .OrderBy(s => s.Id)
                        .ToList();
                }
                else
                {
                    // Nếu chưa chọn thể loại, chỉ lọc theo nhóm thể loại
                    danhSachSach = context.ChiTietSaches
                        .Where(s => s.NhomTheLoai == selectedNhom.TenNhomSach)
                        .OrderBy(s => s.Id)
                        .ToList();
                }

                datagrid.ItemsSource = danhSachSach;
            }
        }

        private void UpdateTheLoaiComboBox()
        {
            if (nhomTheLoaicb.SelectedItem is NhomLoaiSach selectedNhom)
            {
                // Lọc danh sách thể loại theo nhóm loại sách đã chọn
                var theLoaiSaches = context.TheLoaiSaches
                    .Where(t => t.NhomLoaiSach == selectedNhom.TenNhomSach)
                    .ToList();

                theLoaicb.ItemsSource = theLoaiSaches;
                theLoaicb.DisplayMemberPath = "TheLoai";
                theLoaicb.SelectedIndex = -1; // Không chọn phần tử mặc định

                // Đăng ký sự kiện thay đổi thể loại
                theLoaicb.SelectionChanged += theLoaicb_SelectionChanged;

                // Nếu không có thể loại nào, xóa danh sách sách
                if (!theLoaiSaches.Any())
                {
                    datagrid.ItemsSource = null;
                }
            }
        }

        private void timKiemMabtn_Click(object sender, RoutedEventArgs e)
        {
            string tuKhoaTimKiem = timKiemMatxt.Text.Trim(); // Lấy giá trị nhập vào

            if (!string.IsNullOrEmpty(tuKhoaTimKiem))
            {
                var ketQuaTimKiem = danhSachSach
                    .Where(s => (s.Id != null && s.Id.ToLower().Contains(tuKhoaTimKiem.ToLower())) ||  // Tìm theo mã sách
                                (s.TenSach != null && s.TenSach.ToLower().Contains(tuKhoaTimKiem.ToLower())) ||
                                (s.TacGia != null && s.TacGia.ToLower().Contains(tuKhoaTimKiem.ToLower()))) // Tìm theo tên sách
                    .ToList();

                datagrid.ItemsSource = ketQuaTimKiem;
            }
            else
            {
                datagrid.ItemsSource = danhSachSach; // Nếu ô tìm kiếm trống, hiển thị toàn bộ danh sách
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                if (!selectedBooks.ContainsKey(bookId))
                {
                    selectedBooks.Add(bookId, true);
                } // Đánh dấu sách đã chọn
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                if (selectedBooks.ContainsKey(bookId))
                {
                    selectedBooks[bookId] = false;
                }// Bỏ chọn sách
            }
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
