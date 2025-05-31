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
    /// Interaction logic for QLPhongDoc.xaml
    /// </summary>
    public partial class QLPhongDoc : UserControl
    {
        public DatnContext context = new DatnContext();
        private List<QuanLyPhongDoc> danhSachPhongDoc;
        public QLPhongDoc()
        {
            InitializeComponent();
            load();

            loaiPhongDoccb.ItemsSource = new string[] { "Phòng đọc Tổng hợp", "Phòng đọc Tra cứu", "Phòng đọc báo, tạp chí", "Phòng đọc Điện tử", "Phòng mượn", "Phòng kho" };
            loaiPhongDoccb.SelectedIndex = 0;

            gioiHanDocGiacb.ItemsSource = new string[] { "Không giới hạn", "Thiếu niên", "Người trưởng thành", "Nhà nghiên cứu", "Đối tượng đặc biệt" };
            gioiHanDocGiacb.SelectedIndex = 0;
        }

        public void load()
        {
            var quanLyPhongDocs = context.QuanLyPhongDocs.AsQueryable();
            datagrid.ItemsSource = quanLyPhongDocs.OrderBy(e => e.Id).ToList();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyPhongDoc selectedPD)
            {
                maPDtxt.Text = selectedPD.Id;
                tenPDtxt.Text = selectedPD.TenPhongDoc;
                loaiPhongDoccb.Text = selectedPD.LoaiPhongDoc;
                gioiHanDocGiacb.Text = selectedPD.GioiHanDocGia;
                viTriPhongDoctxt.Text = selectedPD.ViTriPhongDoc;
            }
        }

        private void thembtn_click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DatnContext()) // Đảm bảo bạn có DbContext phù hợp
                {

                    // Kiểm tra dữ liệu hợp lệ
                    if (string.IsNullOrEmpty(maPDtxt.Text) ||
                        string.IsNullOrEmpty(tenPDtxt.Text) ||
                        string.IsNullOrEmpty(loaiPhongDoccb.Text) ||
                        string.IsNullOrEmpty(gioiHanDocGiacb.Text) ||
                        string.IsNullOrEmpty(viTriPhongDoctxt.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Kiểm tra xem nhà xuất bản đã tồn tại chưa
                    var tonTaiPD = context.QuanLyPhongDocs.FirstOrDefault(pd => pd.TenPhongDoc == tenPDtxt.Text);
                    if (tonTaiPD != null)
                    {
                        MessageBox.Show("Phòng đọc này đã tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Tạo một đối tượng mới
                    var quanLyPhongDoc = new QuanLyPhongDoc
                    {
                        TenPhongDoc = tenPDtxt.Text,
                        Id = maPDtxt.Text,
                        LoaiPhongDoc = loaiPhongDoccb.Text,
                        GioiHanDocGia = gioiHanDocGiacb.Text,
                        ViTriPhongDoc = viTriPhongDoctxt.Text,
                        SoLuongKeSach = 0
                    };

                    // Thêm vào database
                    context.QuanLyPhongDocs.Add(quanLyPhongDoc);
                    context.SaveChanges();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm phòng Đọc thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    tenPDtxt.Text = "";
                    maPDtxt.Text = "";
                    loaiPhongDoccb.SelectedIndex = 0;
                    gioiHanDocGiacb.SelectedIndex = 0;
                    viTriPhongDoctxt.Text = "";

                    load();
                }
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                load();
            }
        }

        private void suabtn_click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyPhongDoc selectedPD)
            {
                try
                {
                    if (string.IsNullOrEmpty(maPDtxt.Text) ||
                        string.IsNullOrEmpty(tenPDtxt.Text) ||
                        string.IsNullOrEmpty(loaiPhongDoccb.Text) ||
                        string.IsNullOrEmpty(gioiHanDocGiacb.Text) ||
                        string.IsNullOrEmpty(viTriPhongDoctxt.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    var quanLyPhongDoc = context.QuanLyPhongDocs.SingleOrDefault(pd => pd.Id == selectedPD.Id);
                    if (quanLyPhongDoc != null)
                    {
                        // Cập nhật dữ liệu từ TextBox vào đối tượng
                        quanLyPhongDoc.TenPhongDoc = tenPDtxt.Text;
                        quanLyPhongDoc.LoaiPhongDoc = loaiPhongDoccb.Text;
                        quanLyPhongDoc.GioiHanDocGia = gioiHanDocGiacb.Text;
                        quanLyPhongDoc.ViTriPhongDoc = viTriPhongDoctxt.Text;

                        // Lưu vào database
                        context.SaveChanges();
                        MessageBox.Show("Cập nhật phòng đọc thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        tenPDtxt.Text = "";
                        maPDtxt.Text = "";
                        loaiPhongDoccb.Text = "";
                        gioiHanDocGiacb.Text = "";
                        viTriPhongDoctxt.Text = "";

                        load(); // Cập nhật lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng đọc để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    load();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = danhSachPhongDoc; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.QuanLyPhongDocs
                        .Where(cv => (cv.Id != null && cv.Id.ToLower().Contains(keyword)) ||
                                     (cv.TenPhongDoc != null && cv.TenPhongDoc.ToLower().Contains(keyword)) ||
                                     (cv.LoaiPhongDoc != null && cv.LoaiPhongDoc.ToLower().Contains(keyword)) ||
                                     (cv.GioiHanDocGia != null && cv.GioiHanDocGia.ToLower().Contains(keyword)) ||
                                     (cv.ViTriPhongDoc != null && cv.ViTriPhongDoc.ToLower().Contains(keyword)))
                        .ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var phongDocId = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn có chắc muốn xóa phòng đọc này không: {phongDocId}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var quanLyPhongDoc = context.QuanLyPhongDocs.SingleOrDefault(tl => tl.Id == phongDocId);
                        if (quanLyPhongDoc != null)
                        {
                            context.QuanLyPhongDocs.Remove(quanLyPhongDoc);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thể loại để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
