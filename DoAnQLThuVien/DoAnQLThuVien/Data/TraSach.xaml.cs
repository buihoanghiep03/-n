using DoAnQLThuVien.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for TraSach.xaml
    /// </summary>
    public partial class TraSach : Window
    {
        public DatnContext context = new DatnContext();
        private QuanLyMuonSach _muonSach;
        private List<SachMuonViewModel> _sachMuonList;

        public class SachMuonViewModel
        {
            public string IdSach { get; set; }
            public string TenSach { get; set; }
            public string TinhTrangSach { get; set; }
            public string TinhTrangKhiTra { get; set; }
        }

        public TraSach(QuanLyMuonSach muonSach)
        {
            InitializeComponent();
            _muonSach = muonSach;

            ngayTraThucThetxt.Text = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            tinhTrangSach3cb.ItemsSource = tinhTrangSach2cb.ItemsSource = tinhTrangSach1cb.ItemsSource 
                = new string[]{"Mới", "Bình thường", "Cũ", "Hỏng nhẹ", "Hỏng nặng", "Mất"};

            tinhTrangBoiThuongtxt.ItemsSource = new string[] { "Không cần bồi thường", "Cần bồi thường", "Đã bồi thường"};
            tinhTrangBoiThuongtxt.SelectedIndex = 0;

            // Kiểm tra tình trạng mượn/trả sách và cập nhật thông báo
            thongBaolb.Content = _muonSach.TinhTrangMuonTra == "Đã trả" ? "Sách đã trả" : "Sách chưa trả";
            LoadData();
        }

        private void traSachbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy phiếu mượn từ database
                var muonSachDb = context.QuanLyMuonSaches.FirstOrDefault(m => m.Id == _muonSach.Id);
                if (muonSachDb == null)
                {
                    MessageBox.Show("Phiếu mượn không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Kiểm tra nếu sách đã được trả
                if (muonSachDb.TinhTrangMuonTra == "Đã trả")
                {
                    MessageBox.Show("Sách đã được trả!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                // Kiểm tra tình trạng bồi thường
                string tinhTrangBoiThuong = tinhTrangBoiThuongtxt.SelectedItem?.ToString();
                decimal tienBoiThuong = 0;

                if (tinhTrangBoiThuong == "Cần bồi thường" || tinhTrangBoiThuong == "Đã bồi thường")
                {
                    if (!decimal.TryParse(tienBoiThuongtxt.Text, out tienBoiThuong) || tienBoiThuong < 0)
                    {
                        MessageBox.Show("Giá trị tiền bồi thường không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                muonSachDb.TinhTrangKhiTra1 = tinhTrangSach1cb.Text;
                muonSachDb.TinhTrangKhiTra2 = tinhTrangSach2cb.Text;
                muonSachDb.TinhTrangKhiTra3 = tinhTrangSach3cb.Text;

                muonSachDb.NgayTraThucTe = DateOnly.FromDateTime(DateTime.Now);
                muonSachDb.TinhTrangMuonTra = "Đã trả";
                muonSachDb.TinhTrangBoiThuong = tinhTrangBoiThuong;
                muonSachDb.TienBoiThuong = tienBoiThuong;

                // Đánh dấu object là đã thay đổi
                context.Entry(muonSachDb).State = EntityState.Modified;

                // Lưu thay đổi vào database
                context.SaveChanges();

                MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData()
        {
            // Gán dữ liệu vào TextBox
            maPhieuMuontxt.Text = _muonSach.Id;
            maDocGiatcb.Text = _muonSach.DocGiaId;
            TenNguoiMuontxt.Text = _muonSach.TenDocGia;
            ngayMuonhdp.Text = _muonSach.NgayMuon?.ToString("dd/MM/yyyy");
            ngayHenTradp.Text = _muonSach.NgayHenTra?.ToString("dd/MM/yyyy");
            ghiChutxt.Text = _muonSach.GhiChu;
            tinhTrangSach1cb.Text = _muonSach.TinhTrangSach1;
            tinhTrangSach2cb.Text = _muonSach.TinhTrangSach2;
            tinhTrangSach3cb.Text = _muonSach.TinhTrangSach3;
            // Lấy danh sách sách mượn
            _sachMuonList = new List<SachMuonViewModel>();

            if (!string.IsNullOrEmpty(_muonSach.IdsachMuon1))
                _sachMuonList.Add(new SachMuonViewModel
                {
                    IdSach = _muonSach.IdsachMuon1,  // Đúng với thuộc tính của ViewModel
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

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TinhTrangSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tinhTrangSach1cb.SelectedItem?.ToString() == "Hỏng nhẹ" || tinhTrangSach1cb.SelectedItem?.ToString() == "Hỏng nặng" ||
                tinhTrangSach2cb.SelectedItem?.ToString() == "Hỏng nhẹ" || tinhTrangSach2cb.SelectedItem?.ToString() == "Hỏng nặng" ||
                tinhTrangSach3cb.SelectedItem?.ToString() == "Hỏng nhẹ" || tinhTrangSach3cb.SelectedItem?.ToString() == "Hỏng nặng")
            {
                tinhTrangBoiThuongtxt.SelectedItem = "Cần bồi thường";
            }
        }
    }
}
