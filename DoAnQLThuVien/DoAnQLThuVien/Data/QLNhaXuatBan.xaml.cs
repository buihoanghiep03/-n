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
    /// Interaction logic for NhaXuatBan.xaml
    /// </summary>
    public partial class QLNhaXuatBan : UserControl
    {
        public DatnContext context = new DatnContext();
        private List<QuanLyNhaXuatBan> danhSachNhaXuatBan;
        public QLNhaXuatBan()
        {
            InitializeComponent();

            load();
        }

        public void load()
        {
            var quanLyNhaXuatBans = context.QuanLyNhaXuatBans.AsQueryable();
            datagrid.ItemsSource = quanLyNhaXuatBans.OrderBy(e => e.Id).ToList();
        }
        private void thembtn_click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DatnContext()) // Đảm bảo bạn có DbContext phù hợp
                {

                    // Kiểm tra dữ liệu hợp lệ
                    if (string.IsNullOrEmpty(tenNXBtxt.Text) ||
                        string.IsNullOrEmpty(maNXBxt.Text) ||
                        string.IsNullOrEmpty(diaChitxt.Text) ||
                        string.IsNullOrEmpty(SDTtxt.Text) ||
                        string.IsNullOrEmpty(gmailtxt.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên nhà xuất bản.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Kiểm tra xem nhà xuất bản đã tồn tại chưa
                    var tonTaiNXB = context.QuanLyNhaXuatBans.FirstOrDefault(x => x.TenNhaXuatBan == tenNXBtxt.Text);
                    if (tonTaiNXB != null)
                    {
                        MessageBox.Show("Nhà xuất bản này đã tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Tạo một đối tượng mới
                    var newPublisher = new QuanLyNhaXuatBan
                    {
                        TenNhaXuatBan = tenNXBtxt.Text,
                        Id = maNXBxt.Text,
                        DiaChi = diaChitxt.Text,
                        Sdt = SDTtxt.Text,
                        Gmail = gmailtxt.Text
                    };

                    // Thêm vào database
                    context.QuanLyNhaXuatBans.Add(newPublisher);
                    context.SaveChanges();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm nhà xuất bản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    tenNXBtxt.Text = "";
                    maNXBxt.Text = "";
                    diaChitxt.Text = "";
                    SDTtxt.Text = "";
                    gmailtxt.Text = "";

                    load();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyNhaXuatBan selectedNXB)
            {
                maNXBxt.Text = selectedNXB.Id;
                tenNXBtxt.Text = selectedNXB.TenNhaXuatBan;
                diaChitxt.Text = selectedNXB.DiaChi;
                SDTtxt.Text = selectedNXB.Sdt;
                gmailtxt.Text = selectedNXB.Gmail;
            }
        }

        private void suabtn_click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is QuanLyNhaXuatBan selectedNXB)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(maNXBxt.Text) ||
                        string.IsNullOrWhiteSpace(tenNXBtxt.Text) ||
                        string.IsNullOrWhiteSpace(SDTtxt.Text) ||
                        string.IsNullOrWhiteSpace(gmailtxt.Text) ||
                        string.IsNullOrWhiteSpace(diaChitxt.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    var nhaXuatBan = context.QuanLyNhaXuatBans.SingleOrDefault(nxb => nxb.Id == selectedNXB.Id);
                    if (nhaXuatBan != null)
                    {
                        // Cập nhật dữ liệu từ TextBox vào đối tượng
                        nhaXuatBan.TenNhaXuatBan = tenNXBtxt.Text;
                        nhaXuatBan.DiaChi = diaChitxt.Text;
                        nhaXuatBan.Sdt = SDTtxt.Text;
                        nhaXuatBan.Gmail = gmailtxt.Text;

                        // Lưu vào database
                        context.SaveChanges();
                        MessageBox.Show("Cập nhật nhà xuất bản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        tenNXBtxt.Text = "";
                        maNXBxt.Text = "";
                        diaChitxt.Text = "";
                        SDTtxt.Text = "";
                        gmailtxt.Text = "";

                        load(); // Cập nhật lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà xuất bản để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var nhaSanXuatId = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn có chắc muốn xóa nhà xuất bản này không: {nhaSanXuatId}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var quanLyNhaXuatBan = context.QuanLyNhaXuatBans.SingleOrDefault(tl => tl.Id == nhaSanXuatId);
                        if (quanLyNhaXuatBan != null)
                        {
                            context.QuanLyNhaXuatBans.Remove(quanLyNhaXuatBan);
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

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = danhSachNhaXuatBan; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.QuanLyNhaXuatBans
                        .Where(cv => (cv.TenNhaXuatBan != null && cv.TenNhaXuatBan.ToLower().Contains(keyword)) ||
                                     (cv.Sdt != null && cv.Sdt.ToLower().Contains(keyword)) ||
                                     (cv.Gmail != null && cv.Gmail.ToLower().Contains(keyword)))
                        .ToList();

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
