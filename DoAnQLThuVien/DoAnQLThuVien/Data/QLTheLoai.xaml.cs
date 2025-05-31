using DoAnQLThuVien.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for TheLoaiSach.xaml
    /// </summary>
    public partial class QLTheLoai : UserControl
    {
        public DatnContext context = new DatnContext();
        private List<TheLoaiSach> danhSachTheLoaiSach;
        public QLTheLoai()
        {
            InitializeComponent();

            var nhomLoaiSaches = context.NhomLoaiSaches.ToList();
            nhomTLcb.ItemsSource = nhomLoaiSaches;
            nhomTLcb.DisplayMemberPath = "TenNhomSach";
            nhomTLcb.SelectedIndex = 0;
            load();
        }

        public void load()
        {
            var theLoaiSaches = context.TheLoaiSaches.AsQueryable();
            datagrid.ItemsSource = theLoaiSaches.OrderBy(e => e.Id).ToList();
        }

        private void EditImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            load();
        }
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem is TheLoaiSach selectedTheLoai)
            {
                maTLtxt.Text = selectedTheLoai.Id;
                nhomTLcb.Text = selectedTheLoai.NhomLoaiSach;
                tenTLtxt.Text = selectedTheLoai.TheLoai;
                maTattxt.Text = selectedTheLoai.MaTat;
            }
        }

        private void thembtn_click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTLtxt.Text) ||
                    string.IsNullOrWhiteSpace(nhomTLcb.Text) ||
                    string.IsNullOrWhiteSpace(tenTLtxt.Text) ||
                    string.IsNullOrWhiteSpace(maTattxt.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; // Dừng lại nếu có ô trống
                }

                var theLoaimoi = new TheLoaiSach
                {
                    Id = maTLtxt.Text,
                    NhomLoaiSach = nhomTLcb.Text,
                    TheLoai = tenTLtxt.Text,
                    MaTat = maTattxt.Text,
                    SoLuongSach = 0

                };
                context.TheLoaiSaches.Add(theLoaimoi);
                context.SaveChanges();

                load();
                MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void suabtn_click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem is TheLoaiSach selectedTheLoai)
            {
                try
                {
                    var theLoaiSach = context.TheLoaiSaches.SingleOrDefault(tl => tl.Id == selectedTheLoai.Id);
                    if (theLoaiSach != null)
                    {
                        // Cập nhật dữ liệu từ TextBox vào đối tượng
                        theLoaiSach.NhomLoaiSach = nhomTLcb.Text;
                        theLoaiSach.TheLoai = tenTLtxt.Text;
                        theLoaiSach.MaTat = maTattxt.Text;

                        // Lưu vào database
                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        nhomTLcb.SelectedItem = 0;
                        maTLtxt.Text = "";
                        tenTLtxt.Text = "";
                        maTattxt.Text = "";

                        load(); // Cập nhật lại giao diện
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thể loại sách để sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    var theLoaiId = button.Tag.ToString();
                    var result = MessageBox.Show($"Are you sure you want to delete Employee ID: {theLoaiId}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var theLoaiSach = context.TheLoaiSaches.SingleOrDefault(tl => tl.Id == theLoaiId);
                        if (theLoaiSach != null)
                        {
                            context.TheLoaiSaches.Remove(theLoaiSach);
                            context.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = danhSachTheLoaiSach; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.TheLoaiSaches
                        .Where(cv => (cv.Id != null && cv.Id.ToLower().Contains(keyword)) ||
                                     (cv.NhomLoaiSach != null && cv.NhomLoaiSach.ToLower().Contains(keyword)) ||
                                     (cv.TheLoai != null && cv.TheLoai.ToLower().Contains(keyword)) ||
                                     (cv.MaTat != null && cv.MaTat.ToLower().Contains(keyword)))
                        .ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }
    }
}
