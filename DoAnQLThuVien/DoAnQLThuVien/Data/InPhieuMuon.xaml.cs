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
    /// Interaction logic for InPhieuMuon.xaml
    /// </summary>
    public partial class InPhieuMuon : Window
    {
        public DatnContext context = new DatnContext();
        private List<ChiTietSach> danhSachMuon;
        private QuanLyMuonSach phieuMuon;

        public InPhieuMuon(QuanLyMuonSach dkMuon, List<ChiTietSach> danhSach)
        {
            InitializeComponent();
            phieuMuon = dkMuon;
            danhSachMuon = danhSach;
            LoadData();
        }

        private void LoadData()
        {
            maPhieuMuontxt.Text = phieuMuon.Id;
            maNguoiMuontxt.Text = phieuMuon.DocGiaId;
            tenNguoiMuontxt.Text = phieuMuon.TenDocGia;
            soLuongSachMuontxt.Text = phieuMuon.SoLuongMuon.ToString();
            NgayMuon.Text = phieuMuon.NgayMuon.ToString();
            NgayHenTra.Text = phieuMuon.NgayHenTra.ToString();

            // Gán danh sách sách mượn vào DataGrid
            datagrid.ItemsSource = danhSachMuon;
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void inPhieubtn_Click(object sender, RoutedEventArgs e)
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
                    printDialog.PrintVisual(visual, "In Phiếu...");
                }
            }
            catch (Exception ex) 
            { 

            }
            finally
            {
                this.IsEnabled = true;
            }
            this.Close();
        }

    }
}
