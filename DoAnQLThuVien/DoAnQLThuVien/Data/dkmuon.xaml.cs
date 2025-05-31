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
    /// Interaction logic for dkmuon.xaml
    /// </summary>
    public partial class dkmuon : Window
    {
        public DatnContext context = new DatnContext();
        private List<ChiTietSach> danhSachMuon;
        public dkmuon()
        {
            InitializeComponent();
            LoadComboBoxData();

            danhSachMuon = new List<ChiTietSach>(); // Khởi tạo danh sách
            datagrid.ItemsSource = danhSachMuon;

            soSachMuoncb.ItemsSource = new string[] { "1", "2", "3" };
            soSachMuoncb.SelectedIndex = 0; // Chọn giá trị đầu tiên mặc định

            // Lấy danh sách ID độc giả từ QuanLyDocGia
            maDocGiatcb.ItemsSource = context.QuanLyDocGia.Select(dg => dg.Id).ToList();

            // Tự động tạo và hiển thị mã phiếu mượn
            maPhieuMuontxt.Text = TaoMaPhieuMuon();
        }

        private void maDocGiatcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (maDocGiatcb.SelectedItem != null)
            {
                string selectedId = maDocGiatcb.SelectedItem.ToString();
                var docGia = context.QuanLyDocGia.FirstOrDefault(dg => dg.Id == selectedId);

                if (docGia != null)
                {
                    TenNguoiMuontxt.Text = docGia.HoTen; // Tự động điền tên độc giả
                    string loaiDocGiaHienTai = docGia.LoaiDocGia; // Giả sử có trường LoaiDocGia trong QuanLyDocGia
                    loaiDocGiatxt.Text = docGia.LoaiDocGia;
                }
            }
        }

        public void AddBookToDataGrid(ChiTietSach sach)
        {
            if (danhSachMuon == null)
            {
                danhSachMuon = new List<ChiTietSach>(); // Đảm bảo danh sách được khởi tạo
            }

            if (!danhSachMuon.Any(s => s.Id == sach.Id))
            {
                danhSachMuon.Add(sach);
                datagrid.ItemsSource = null; // Reset dữ liệu để cập nhật
                datagrid.ItemsSource = danhSachMuon;
            }
        }

        private void chonSachMuonbtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(soSachMuoncb.SelectedItem.ToString(), out int soSachMuonToiDa))
            {
                if (danhSachMuon.Count >= soSachMuonToiDa)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Đã chọn số lượng sách tối đa, bạn có muốn xóa danh sách đã chọn và chọn lại không?",
                        "Xác nhận",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    if (result == MessageBoxResult.Yes)
                    {
                        danhSachMuon.Clear();
                        datagrid.ItemsSource = null; // Reset dữ liệu
                        datagrid.ItemsSource = danhSachMuon;
                    }
                    else
                    {
                        return; // Không mở cửa sổ chọn sách nếu người dùng chọn No
                    }
                }

                // Lấy loại độc giả hiện tại từ ComboBox
                if (maDocGiatcb.SelectedItem != null)
                {
                    string selectedId = maDocGiatcb.SelectedItem.ToString();
                    var docGia = context.QuanLyDocGia.FirstOrDefault(dg => dg.Id == selectedId);

                    if (docGia != null)
                    {
                        string loaiDocGia = docGia.LoaiDocGia; // Lấy loại độc giả từ DB
                        int soLuongMuon = int.Parse(soSachMuoncb.Text);

                        // Truyền loại độc giả vào constructor của ChonSachMuon
                        ChonSachMuon chonSachMuon = new ChonSachMuon(this, loaiDocGia, soLuongMuon);
                        chonSachMuon.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin độc giả!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn độc giả trước khi chọn sách!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void dkInbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maPhieuMuontxt.Text) ||
                string.IsNullOrWhiteSpace(maDocGiatcb.Text) ||
                string.IsNullOrWhiteSpace(TenNguoiMuontxt.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var docGia = context.QuanLyDocGia.FirstOrDefault(dg => dg.Id == maDocGiatcb.Text);
            if (docGia == null)
            {
                MessageBox.Show("Mã độc giả không tồn tại trong hệ thống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (danhSachMuon == null || danhSachMuon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách trước khi đăng ký mượn!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int yearMuon = (int)namMuoncb.SelectedItem;
            int monthMuon = (int)thangMuoncb.SelectedItem;
            int dayMuon = (int)ngayMuoncb.SelectedItem;
            DateOnly ngayMuon = new DateOnly(yearMuon, monthMuon, dayMuon);

            int yearHenTra = (int)namHenTracb.SelectedItem;
            int monthHenTra = (int)thangHenTracb.SelectedItem;
            int dayHenTra = (int)ngayHenTracb.SelectedItem;
            DateOnly ngayHenTra = new DateOnly(yearHenTra, monthHenTra, dayHenTra);

            var dkMuon = new QuanLyMuonSach
            {
                Id = maPhieuMuontxt.Text,
                DocGiaId = maDocGiatcb.Text,
                TenDocGia = docGia.HoTen,
                SoLuongMuon = int.Parse(soSachMuoncb.Text),
                GhiChu = string.IsNullOrWhiteSpace(ghiChutxt.Text) ? "Không có ghi chú" : ghiChutxt.Text,
                NgayMuon = ngayMuon,
                NgayHenTra = ngayHenTra,
                TinhTrangMuonTra = "Đang mượn",

                IdsachMuon1 = danhSachMuon.Count > 0 ? danhSachMuon[0].Id : null,
                TenSach1 = danhSachMuon.Count > 0 ? danhSachMuon[0].TenSach : null,
                TinhTrangSach1 = danhSachMuon.Count > 0 ? danhSachMuon[0].TinhTrangSach : null,
                IdsachMuon2 = danhSachMuon.Count > 1 ? danhSachMuon[1].Id : null,
                TenSach2 = danhSachMuon.Count > 1 ? danhSachMuon[1].TenSach : null,
                TinhTrangSach2 = danhSachMuon.Count > 1 ? danhSachMuon[1].TinhTrangSach : null,
                IdsachMuon3 = danhSachMuon.Count > 2 ? danhSachMuon[2].Id : null,
                TenSach3 = danhSachMuon.Count > 2 ? danhSachMuon[2].TenSach : null,
                TinhTrangSach3 = danhSachMuon.Count > 2 ? danhSachMuon[2].TinhTrangSach : null,
            };

            context.QuanLyMuonSaches.Add(dkMuon);
            context.SaveChanges();

            MessageBox.Show("Đăng ký mượn sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            var inPhieuMuon = new InPhieuMuon(dkMuon, danhSachMuon);
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
                mainWindow.ShowWithOverlay(inPhieuMuon);
            else
                inPhieuMuon.ShowDialog();

            this.Close();
        }
        private string TaoMaPhieuMuon()
        {
            string namHienTai = DateTime.Now.Year.ToString();
            string prefix = $"PM-{namHienTai}-";

            // Tìm số thứ tự lớn nhất trong database
            var lastRecord = context.QuanLyMuonSaches
                .Where(m => m.Id.StartsWith(prefix))
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();

            int soThuTuMoi = 1; // Mặc định nếu không có dữ liệu
            if (lastRecord != null)
            {
                string lastId = lastRecord.Id; // VD: PM-2025-000123
                string soThuTuStr = lastId.Substring(lastId.LastIndexOf('-') + 1);
                if (int.TryParse(soThuTuStr, out int lastNumber))
                {
                    soThuTuMoi = lastNumber + 1;
                }
            }

            return $"{prefix}{soThuTuMoi:D6}"; // Tạo ID với số thứ tự 6 chữ số
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadComboBoxData()
        {
            int currentYear = DateTime.Now.Year;

            // Thêm danh sách năm (1900 - hiện tại)
            for (int i = currentYear; i >= 1900; i--)
            {
                namMuoncb.Items.Add(i);
                namHenTracb.Items.Add(i);
            }

            // Thêm danh sách tháng (1 - 12)
            for (int i = 1; i <= 12; i++)
            {
                thangMuoncb.Items.Add(i);
                thangHenTracb.Items.Add(i);
            }

            // Mặc định chọn năm, tháng hiện tại
            namMuoncb.SelectedItem = currentYear;
            thangMuoncb.SelectedItem = DateTime.Now.Month;
            namHenTracb.SelectedItem = currentYear;
            thangHenTracb.SelectedItem = DateTime.Now.Month;

            // Gán sự kiện cập nhật ngày
            namMuoncb.SelectionChanged += UpdateNgayMuonComboBox;
            thangMuoncb.SelectionChanged += UpdateNgayMuonComboBox;
            ngayMuoncb.SelectionChanged += (s, e) => SetDefaultNgayHenTra();

            // Cập nhật dữ liệu ban đầu
            UpdateNgayMuonComboBox(null, null);
        }

        // Cập nhật ngày mượn
        private void UpdateNgayMuonComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (namMuoncb.SelectedItem == null || thangMuoncb.SelectedItem == null)
                return;

            int year = (int)namMuoncb.SelectedItem;
            int month = (int)thangMuoncb.SelectedItem;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            ngayMuoncb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngayMuoncb.Items.Add(i);
            }

            ngayMuoncb.SelectedIndex = 0; // Mặc định chọn ngày đầu tháng
            SetDefaultNgayHenTra(); // Cập nhật ngày hẹn trả tự động
        }

        // Cập nhật ngày hẹn trả, đảm bảo hơn ngày mượn ít nhất 14 ngày
        private void UpdateNgayHenTraComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (namHenTracb.SelectedItem == null || thangHenTracb.SelectedItem == null ||
                namMuoncb.SelectedItem == null || thangMuoncb.SelectedItem == null || ngayMuoncb.SelectedItem == null)
                return;

            // Lấy ngày mượn
            int yearMuon = (int)namMuoncb.SelectedItem;
            int monthMuon = (int)thangMuoncb.SelectedItem;
            int dayMuon = (int)ngayMuoncb.SelectedItem;
            DateTime ngayMuon = new DateTime(yearMuon, monthMuon, dayMuon);

            // Tính ngày hẹn trả tối thiểu
            DateTime minHenTra = ngayMuon.AddDays(14);
            int yearHenTra = minHenTra.Year;
            int monthHenTra = minHenTra.Month;
            int dayHenTra = minHenTra.Day;

            // Cập nhật các ComboBox của ngày hẹn trả
            namHenTracb.SelectedItem = yearHenTra;
            thangHenTracb.SelectedItem = monthHenTra;

            int daysInMonth = DateTime.DaysInMonth(yearHenTra, monthHenTra);
            ngayHenTracb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngayHenTracb.Items.Add(i);
            }

            ngayHenTracb.SelectedItem = dayHenTra; // Chọn ngày hợp lệ
        }

        private void SetDefaultNgayHenTra()
        {
            if (namMuoncb.SelectedItem == null || thangMuoncb.SelectedItem == null || ngayMuoncb.SelectedItem == null)
                return;

            // Lấy ngày mượn
            int yearMuon = (int)namMuoncb.SelectedItem;
            int monthMuon = (int)thangMuoncb.SelectedItem;
            int dayMuon = (int)ngayMuoncb.SelectedItem;
            DateTime ngayMuon = new DateTime(yearMuon, monthMuon, dayMuon);

            // Tính ngày hẹn trả mặc định (14 ngày sau)
            DateTime ngayHenTra = ngayMuon.AddDays(14);

            // Cập nhật ComboBox ngày hẹn trả
            namHenTracb.SelectedItem = ngayHenTra.Year;
            thangHenTracb.SelectedItem = ngayHenTra.Month;

            int daysInMonth = DateTime.DaysInMonth(ngayHenTra.Year, ngayHenTra.Month);
            ngayHenTracb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngayHenTracb.Items.Add(i);
            }

            ngayHenTracb.SelectedItem = ngayHenTra.Day; // Chọn ngày tự động
        }
    }
}
