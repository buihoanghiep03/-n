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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Media; 

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for DuLieuSach.xaml
    /// </summary>
    public partial class DuLieuSach : UserControl
    {
        public DatnContext context = new DatnContext();
        private Dictionary<string, bool> selectedBooks = new Dictionary<string, bool>();
        public DuLieuSach()
        {
            InitializeComponent();

            // Mặc định hiển thị 0
            tongSachMoi.Text = "0";
            tongSachbth.Text = "0";
            tongSachCu.Text = "0";
            tongSachHongNhe.Text = "0";
            sachHongNangtxt.Text = "0";

            // Lấy tổng số sách theo tình trạng
            int TongSachMoi = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Mới");
            int TongSachBinhThuong = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Bình thường");
            int TongSachCu = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Cũ");
            int TongSachHongNhe = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Hỏng nhẹ");
            int TongSachHongNang = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Hỏng nặng");
            int TongMat = context.ChiTietSaches.Count(e => e.TinhTrangSach == "Mất");

            // Gán vào TextBox
            tongSachMoi.Text = TongSachMoi.ToString();
            tongSachbth.Text = TongSachBinhThuong.ToString();
            tongSachCu.Text = TongSachCu.ToString();
            tongSachHongNhe.Text = TongSachHongNhe.ToString();
            sachHongNangtxt.Text = TongSachHongNang.ToString();
            sachMattxt.Text = TongMat.ToString();

            var tongSach = TongSachMoi + TongSachBinhThuong + TongSachCu + TongSachHongNhe + TongSachHongNang + TongMat;
            tongSoSachlb.Content = $"Tổng số {tongSach} bản in";

            load();
        }

        public void load()
        {
            allBooks = context.ChiTietSaches.OrderBy(e => e.Id).ToList(); // Lưu toàn bộ dữ liệu
            LoadPagination(); // Cập nhật số trang
            LoadPage(1); // Hiển thị trang đầu tiên
        }

        private List<ChiTietSach> allBooks;
        private int totalPages;
        private int currentPage = 1;
        private int pageSize = 20; // Số sách mỗi trang

        private void LoadPage(int page)
        {
            currentPage = page;

            if (allBooks == null || allBooks.Count == 0)
            {
                datagrid.ItemsSource = null;
                tranglb.Content = "Trang 0";
                tongTranglb.Content = "trên tổng số 0 trang";
                return;
            }

            var data = allBooks
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            datagrid.ItemsSource = data;

            // Cập nhật số trang hiển thị
            tranglb.Content = $"Trang {currentPage}";
            tongTranglb.Content = $"trên tổng số {totalPages} trang";
        }

        private void LoadPagination()
        {
            if (allBooks == null || allBooks.Count == 0)
            {
                totalPages = 0;
                trangcb.Items.Clear();
                return;
            }

            totalPages = (int)Math.Ceiling((double)allBooks.Count / pageSize);
            trangcb.Items.Clear();

            for (int i = 1; i <= totalPages; i++)
            {
                trangcb.Items.Add(i);
            }

            trangcb.SelectedIndex = 0; // Mặc định chọn trang đầu tiên
        }

        private void trangcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trangcb.SelectedItem != null)
            {
                LoadPage((int)trangcb.SelectedItem);
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void EditImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string sachId = button.Tag.ToString();

                    var selectedBook = context.ChiTietSaches.SingleOrDefault(s => s.Id == sachId);

                    if (selectedBook != null)
                    {
                        SuaDuLieuSach editBookWindow = new SuaDuLieuSach(selectedBook);

                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                        {
                            mainWindow.ShowWithOverlay(editBookWindow);
                        }
                        else
                        {
                            editBookWindow.ShowDialog();
                        }

                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void chiTietbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null && button.Tag != null)
                {
                    string sachId = button.Tag.ToString();

                    var selectedBook = context.ChiTietSaches.SingleOrDefault(s => s.Id == sachId);

                    if (selectedBook != null)
                    {
                        TimKiemChiTietSach timKiemChiTietSach = new TimKiemChiTietSach(selectedBook);

                        var mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                        {
                            mainWindow.ShowWithOverlay(timKiemChiTietSach);
                        }
                        else
                        {
                            timKiemChiTietSach.ShowDialog();
                        }

                        load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách để sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var SachID = button.Tag.ToString();
                    var result = MessageBox.Show($"Bạn có muốn xóa sách mang ID: {SachID}?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    using (var context = new DatnContext())
                    {
                        var chiTietSach = context.ChiTietSaches.SingleOrDefault(tl => tl.Id == SachID);
                        if (chiTietSach != null)
                        {
                            context.ChiTietSaches.Remove(chiTietSach);
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
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                selectedBooks[bookId] = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string bookId)
            {
                selectedBooks.Remove(bookId);
            }
        }

        private void inTembtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBookIds = selectedBooks.Where(kv => kv.Value).Select(kv => kv.Key).ToList();

            if (selectedBookIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một cuốn sách để in tem.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedBooksList = context.ChiTietSaches
                .Where(s => selectedBookIds.Contains(s.Id))
                .Select(s => s.Id)
                .ToList();

            InTemDanSach printer = new InTemDanSach(selectedBooksList);
            printer.GeneratePdf();

            UncheckAllCheckboxes();
            selectedBooks.Clear();
        }

        /// <summary>
        /// Bỏ chọn tất cả các CheckBox trong DataGrid
        /// </summary>
        private void UncheckAllCheckboxes()
        {
            foreach (var item in datagrid.Items)
            {
                if (datagrid.ItemContainerGenerator.ContainerFromItem(item) is DataGridRow row)
                {
                    var checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox != null)
                    {
                        checkBox.IsChecked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Hàm tìm CheckBox bên trong DataGridRow
        /// </summary>
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild)
                {
                    return tChild;
                }
                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                SearchBooks(keyword);
            }
            else
            {
                load(); // Nếu ô tìm kiếm trống, tải lại toàn bộ sách
            }
        }

        // Hàm tìm kiếm sách theo từ khóa
        public void SearchBooks(string keyword)
        {
            keyword = keyword.ToLower().Trim(); // Chuẩn hóa từ khóa tìm kiếm
            var searchResult = context.ChiTietSaches
                .Where(e => e.TenSach.ToLower().Contains(keyword) || e.TacGia.ToLower().Contains(keyword) || e.Id.ToLower().Contains(keyword))
                .OrderBy(e => e.Id)
                .ToList();

            allBooks = searchResult;
            LoadPagination();
            LoadPage(1); // Hiển thị kết quả tìm kiếm từ trang đầu tiên
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            load();
        }
    }
}
