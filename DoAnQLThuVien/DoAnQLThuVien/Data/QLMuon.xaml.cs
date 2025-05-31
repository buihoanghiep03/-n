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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for QLMuon.xaml
    /// </summary>
    public partial class QLMuon : UserControl
    {
        public DatnContext context = new DatnContext();
        private QuanLyMuonSach? selectedPhieuMuon;
        private List<QuanLyMuonSach> muonSaches;
        public QLMuon()
        {
            InitializeComponent();

            int NguoiMuon = context.QuanLyMuonSaches.Select(e => e.DocGiaId).Distinct().Count();
            int SachMuon = context.QuanLyMuonSaches.Sum(e => e.SoLuongMuon ?? 0);
            int SachChuaTra = context.QuanLyMuonSaches.Where(e => e.TinhTrangMuonTra == "Đang mượn" || e.TinhTrangMuonTra == "Quá hạn").Sum(e => e.SoLuongMuon ?? 0);
            int TongMat = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Mất");

            sachMuoncount.Text = SachMuon.ToString();
            sachMatcount.Text = TongMat.ToString();
            nguoiMuoncount.Text = NguoiMuon.ToString();
            sachChuaTracount.Text = SachChuaTra.ToString();

            load();
        }

        private void inPhieuMuonbtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPhieuMuon == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Lấy danh sách sách đã mượn
            List<ChiTietSach> danhSachMuon = new List<ChiTietSach>();
            if (!string.IsNullOrEmpty(selectedPhieuMuon.IdsachMuon1))
            {
                var sach1 = context.ChiTietSaches.FirstOrDefault(s => s.Id == selectedPhieuMuon.IdsachMuon1);
                if (sach1 != null)
                {
                    sach1.TenSach = selectedPhieuMuon.TenSach1;
                    sach1.TinhTrangSach = selectedPhieuMuon.TinhTrangSach1;
                    danhSachMuon.Add(sach1);
                }
            }
            if (!string.IsNullOrEmpty(selectedPhieuMuon.IdsachMuon2))
            {
                var sach2 = context.ChiTietSaches.FirstOrDefault(s => s.Id == selectedPhieuMuon.IdsachMuon2);
                if (sach2 != null)
                {
                    sach2.TenSach = selectedPhieuMuon.TenSach2;
                    sach2.TinhTrangSach = selectedPhieuMuon.TinhTrangSach2;
                    danhSachMuon.Add(sach2);
                }
            }
            if (!string.IsNullOrEmpty(selectedPhieuMuon.IdsachMuon3))
            {
                var sach3 = context.ChiTietSaches.FirstOrDefault(s => s.Id == selectedPhieuMuon.IdsachMuon3);
                if (sach3 != null)
                {
                    sach3.TenSach = selectedPhieuMuon.TenSach3;
                    sach3.TinhTrangSach = selectedPhieuMuon.TinhTrangSach3;
                    danhSachMuon.Add(sach3);
                }
            }

            // Tạo cửa sổ in phiếu mượn
            var inPhieuMuon = new InPhieuMuon(selectedPhieuMuon, danhSachMuon);

            // Mở với overlay nếu có MainWindow
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.ShowWithOverlay(inPhieuMuon);
            }
            else
            {
                inPhieuMuon.ShowDialog();
            }

            load();
        }       

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyMuonSach item)
            {
                selectedPhieuMuon = item;
            }
            else
            {
                selectedPhieuMuon = null;
            }
        }

        public void load()
        {
            using (var context = new DatnContext())
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Today); // Ngày hiện tại

                // Lấy danh sách mượn sách
                var quanLyMuonSaches = context.QuanLyMuonSaches.ToList();

                // Cập nhật trạng thái nếu quá hạn (chỉ khi chưa trả sách)
                foreach (var item in quanLyMuonSaches)
                {
                    if (item.TinhTrangMuonTra != "Đã trả" && item.NgayHenTra < today && item.TinhTrangMuonTra != "Quá hạn")
                    {
                        item.TinhTrangMuonTra = "Quá hạn";
                        context.QuanLyMuonSaches.Update(item);
                    }
                }

                // Lưu thay đổi vào database nếu có cập nhật
                context.SaveChanges();

                // Hiển thị dữ liệu trong DataGrid
                datagrid.ItemsSource = quanLyMuonSaches.OrderBy(e => e.Id).ToList();
            }
        }

        private void DKMuonbtn_Click(object sender, RoutedEventArgs e)
        {
            var dkmuonsach = new dkmuon();

            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.ShowWithOverlay(dkmuonsach);
            }
            else
            {
                dkmuonsach.ShowDialog();
            }

            load();
        }

        private void traSach_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = (sender as Button)?.DataContext as QuanLyMuonSach;
            if (selectedRow == null) return;

            var traSach = new TraSach(selectedRow);

            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.ShowWithOverlay(traSach);
            }
            else
            {
                traSach.ShowDialog();
            }

            load();
        }

        private void giaHan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = (sender as Button)?.DataContext as QuanLyMuonSach;
                if (selectedRow == null) return;

                var giaHanMuon = new GiaHanMuon(selectedRow);

                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.ShowWithOverlay(giaHanMuon);
                }
                else
                {
                    giaHanMuon.ShowDialog();
                }

                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở cửa sổ Gia Hạn: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            { 
                load(); 
            }
        }

        private void chiTiet_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = (sender as Button)?.DataContext as QuanLyMuonSach;
            if (selectedRow == null) return;

            var chiTietMuon = new ChiTietMuon(selectedRow);

            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.ShowWithOverlay(chiTietMuon);
            }
            else
            {
                chiTietMuon.ShowDialog();
            }

            load();
        }

        private void DeleteImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var MuonID = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn thông tin mượn mang Id: {MuonID}?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var quanLyMuonSach = context.QuanLyMuonSaches.SingleOrDefault(tl => tl.Id == MuonID);
                        if (quanLyMuonSach != null)
                        {
                            context.QuanLyMuonSaches.Remove(quanLyMuonSach);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sách để xóa.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                load();
            }
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = muonSaches; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    // Tải tất cả dữ liệu về bộ nhớ trước
                    var allData = db.QuanLyMuonSaches.ToList();

                    // Lọc dữ liệu trong bộ nhớ
                    var filteredList = allData.Where(cv =>
                        (cv.Id.ToString().Contains(keyword)) ||
                        (cv.TenDocGia != null && cv.TenDocGia.ToLower().Contains(keyword)) ||
                        (cv.TinhTrangMuonTra != null && cv.TinhTrangMuonTra.ToLower().Contains(keyword)) ||
                        (cv.TinhTrangBoiThuong != null && cv.TinhTrangBoiThuong.ToLower().Contains(keyword)) ||
                        (cv.DocGiaId.ToString().Contains(keyword)) ||
                        (cv.NgayMuon.HasValue && cv.NgayMuon.Value.ToString("dd/MM/yyyy").Contains(keyword)) // Đổi kiểu DateTime? thành chuỗi
                    ).ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }
    }
}
