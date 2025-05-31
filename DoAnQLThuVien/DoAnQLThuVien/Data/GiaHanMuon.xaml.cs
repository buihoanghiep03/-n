using DoAnQLThuVien.Models;
using Microsoft.IdentityModel.Tokens;
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
using static DoAnQLThuVien.Data.TraSach;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for GiaHanMuon.xaml
    /// </summary>
    public partial class GiaHanMuon : Window
    {
        private QuanLyMuonSach _muonSach;
        private List<SachMuonViewModel> _sachMuonList;
        public GiaHanMuon(QuanLyMuonSach muonSach)
        {
            InitializeComponent();
            _muonSach = muonSach;

            LoadComboBoxData();
            LoadData();

            // Tính số lần gia hạn đã sử dụng
            int giaHanCount = 0;
            if (_muonSach.NgayGiaHanTra1 != null) giaHanCount++;
            if (_muonSach.NgayGiaHanTra2 != null) giaHanCount++;

            // Hiển thị thông báo số lần gia hạn còn lại
            thongBaolb.Content = giaHanCount switch
            {
                0 => "Được phép gia hạn 2 lần",
                1 => "Được phép gia hạn 1 lần",
                _ => "Số lần gia hạn đã dùng hết"
            };
        }

        private void LoadComboBoxData()
        {
            // Lấy ngày, tháng, năm hiện tại
            DateTime today = DateTime.Today;
            int currentYear = today.Year;
            int currentMonth = today.Month;
            int currentDay = today.Day;

            // Thêm năm từ năm hiện tại đến 2040
            for (int i = currentYear; i <= 2040; i++)
            {
                namHanTracb.Items.Add(i);
            }
            namHanTracb.SelectedItem = currentYear; // Chọn năm hiện tại

            // Thêm tháng từ 1 đến 12
            for (int i = 1; i <= 12; i++)
            {
                thangHanTracb.Items.Add(i);
            }
            thangHanTracb.SelectedItem = currentMonth; // Chọn tháng hiện tại

            // Cập nhật số ngày trong tháng theo năm & tháng hiện tại
            UpdateNgayHanTra();

            // Chọn ngày hiện tại
            if (ngayHanTracb.Items.Contains(currentDay))
            {
                ngayHanTracb.SelectedItem = currentDay;
            }
        }

        private void NamHanTracb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Khi chọn năm, cập nhật số ngày nếu tháng đã chọn
            if (thangHanTracb.SelectedItem != null)
            {
                UpdateNgayHanTra();
            }
        }

        private void ThangHanTracb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Khi chọn tháng, cập nhật số ngày
            UpdateNgayHanTra();
        }

        private void UpdateNgayHanTra()
        {
            if (namHanTracb.SelectedItem == null || thangHanTracb.SelectedItem == null)
                return;

            int year = (int)namHanTracb.SelectedItem;
            int month = (int)thangHanTracb.SelectedItem;

            // Lấy số ngày trong tháng
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Lưu ngày đã chọn trước đó (nếu có)
            int selectedDay = ngayHanTracb.SelectedItem != null ? (int)ngayHanTracb.SelectedItem : 1;

            // Cập nhật danh sách ngày
            ngayHanTracb.Items.Clear();
            for (int i = 1; i <= daysInMonth; i++)
            {
                ngayHanTracb.Items.Add(i);
            }

            // Chọn lại ngày trước đó, nếu không khả dụng thì chọn ngày cuối tháng
            ngayHanTracb.SelectedItem = ngayHanTracb.Items.Contains(selectedDay) ? selectedDay : daysInMonth;
        }

        private void LoadData()
        {

            maPhieuMuontxt.Text = _muonSach.Id;
            maDocGiattxt.Text = _muonSach.DocGiaId;
            TenNguoiMuontxt.Text = _muonSach.TenDocGia;
            ghiChutxt.Text = _muonSach.GhiChu;
            ngayMuonhdp.Text = _muonSach.NgayMuon?.ToString("dd/MM/yyyy");
            ngayHenTradp.Text = _muonSach.NgayHenTra?.ToString("dd/MM/yyyy");
            ngayGiaHanLan1.Text = _muonSach.NgayGiaHanTra1?.ToString("dd/MM/yyyy");
            ngayGiaHanLan2.Text = _muonSach.NgayGiaHanTra2?.ToString("dd/MM/yyyy");

            _sachMuonList = new List<SachMuonViewModel>();

            if (!string.IsNullOrEmpty(_muonSach.IdsachMuon1))
                _sachMuonList.Add(new SachMuonViewModel
                {
                    IdSach = _muonSach.IdsachMuon1,
                    TenSach = _muonSach.TenSach1,
                    TinhTrangSach = _muonSach.TinhTrangSach1,
                    TinhTrangKhiTra = _muonSach.TinhTrangKhiTra1
                });

            if (!string.IsNullOrEmpty(_muonSach.IdsachMuon2))
                _sachMuonList.Add(new SachMuonViewModel
                {
                    IdSach = _muonSach.IdsachMuon2,
                    TenSach = _muonSach.TenSach2,
                    TinhTrangSach = _muonSach.TinhTrangSach2,
                    TinhTrangKhiTra = _muonSach.TinhTrangKhiTra2
                });

            if (!string.IsNullOrEmpty(_muonSach.IdsachMuon3))
                _sachMuonList.Add(new SachMuonViewModel
                {
                    IdSach = _muonSach.IdsachMuon3,
                    TenSach = _muonSach.TenSach3,
                    TinhTrangSach = _muonSach.TinhTrangSach3,
                    TinhTrangKhiTra = _muonSach.TinhTrangKhiTra3
                });

            datagrid.ItemsSource = _sachMuonList;   
        }

        private void giaHanbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra nếu không chọn đủ ngày tháng năm thì báo lỗi
                if (namHanTracb.SelectedItem == null || thangHanTracb.SelectedItem == null || ngayHanTracb.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ ngày tháng năm để gia hạn.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Lấy ngày gia hạn mới
                int year = (int)namHanTracb.SelectedItem;
                int month = (int)thangHanTracb.SelectedItem;
                int day = (int)ngayHanTracb.SelectedItem;
                DateOnly ngayGiaHanMoi = new DateOnly(year, month, day);

                // Kiểm tra số lần gia hạn
                if (_muonSach.NgayGiaHanTra1 == null)
                {
                    _muonSach.NgayGiaHanTra1 = ngayGiaHanMoi;
                }
                else if (_muonSach.NgayGiaHanTra2 == null)
                {
                    _muonSach.NgayGiaHanTra2 = ngayGiaHanMoi;
                }
                else
                {
                    MessageBox.Show("Số lần gia hạn đã hết. Không thể gia hạn thêm.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Kiểm tra và cộng dồn phí gia hạn
                if (decimal.TryParse(phiGiaHantxt.Text, out decimal phiGiaHanMoi) && phiGiaHanMoi >= 0)
                {
                    _muonSach.PhiGiaHan = (_muonSach.PhiGiaHan ?? 0) + phiGiaHanMoi; // Cộng dồn phí gia hạn
                }
                else
                {
                    MessageBox.Show("Phí gia hạn phải là số hợp lệ và không âm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Cập nhật ngày hẹn trả mới
                _muonSach.NgayHenTra = ngayGiaHanMoi;
                _muonSach.TinhTrangMuonTra = "Đang mượn";

                // Cập nhật vào database
                using (var context = new DatnContext())
                {
                    context.QuanLyMuonSaches.Update(_muonSach);
                    context.SaveChanges();
                }

                MessageBox.Show("Gia hạn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Đóng cửa sổ sau khi gia hạn thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gia hạn: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void datagrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void maDocGiatcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
