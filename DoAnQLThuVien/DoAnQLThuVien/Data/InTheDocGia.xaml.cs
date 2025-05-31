using DoAnQLThuVien.Models;
using NPOI.SS.Formula.Functions;
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
using QRCoder;
using System.IO;

namespace DoAnQLThuVien.Data
{
    /// <summary>
    /// Interaction logic for InTheDocGia.xaml
    /// </summary>
    public partial class InTheDocGia : Window
    {
        public DatnContext context = new DatnContext();
        public InTheDocGia(string hoTen, string NgayLamThe, string ngayHetHan, string maDocGia, string loaiDocGia, string anhDG)
        {
            InitializeComponent();

            // Gán dữ liệu vào TextBox
            TenDGtxt.Text = hoTen;
            ngayLamThetxt.Text = NgayLamThe;
            ngayHetHantxt.Text = ngayHetHan;
            MaDocGiatxt.Text = maDocGia;
            loaiDocGiatxt.Text = loaiDocGia;
            // Xử lý ảnh nếu có
            try
            {
                if (!string.IsNullOrWhiteSpace(anhDG) && File.Exists(anhDG))
                {
                    DocGiaImage.Source = new BitmapImage(new Uri(anhDG, UriKind.Absolute));
                }
                else
                {
                    DocGiaImage.Source = null; // Không có ảnh
                }
            }
            catch
            {
                DocGiaImage.Source = null; // Lỗi khi tạo ảnh => bỏ qua
            }
        }

        private void printbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    // Tạo một Visual độc lập cho Border
                    var visual = new DrawingVisual();
                    using (var context = visual.RenderOpen())
                    {
                        // Render Border vào Visual
                        var brush = new VisualBrush(print);
                        context.DrawRectangle(brush, null, new Rect(new Point(0, 0), new Size(print.ActualWidth, print.ActualHeight)));
                    }

                    // In Visual
                    printDialog.PrintVisual(visual, "In Thẻ...");
                    MessageBox.Show("Thẻ đã được in thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                string docGiaId = MaDocGiatxt.Text;

                using (var dbContext = new DatnContext())
                {
                    var docGia = dbContext.QuanLyDocGia.SingleOrDefault(dg => dg.Id == docGiaId); // Id là string
                    if (docGia != null)
                    {
                        // Chuyển đổi ngày từ string sang DateOnly?
                        docGia.NgayLamThe = DateOnly.TryParse(ngayLamThetxt.Text, out DateOnly ngayLamThe) ? ngayLamThe : null;
                        docGia.NgayHetHanThe = DateOnly.TryParse(ngayHetHantxt.Text, out DateOnly ngayHetHanThe) ? ngayHetHanThe : null;

                        dbContext.SaveChanges(); // Lưu dữ liệu vào DB
                        MessageBox.Show("Dữ liệu thẻ độc giả đã được cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy độc giả trong hệ thống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.IsEnabled = true;
            }
            this.Close();
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
