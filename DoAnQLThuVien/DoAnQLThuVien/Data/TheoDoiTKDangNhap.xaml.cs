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
    /// Interaction logic for TheoDoiTKDangNhap.xaml
    /// </summary>
    public partial class TheoDoiTKDangNhap : Window
    {
        public DatnContext context = new DatnContext();
        private List<TheoDoiDangNhap> theoDoiDangNhaps;
        public TheoDoiTKDangNhap()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            var theoDoiDangNhaps = context.TheoDoiDangNhaps.AsQueryable();
            datagrid.ItemsSource = theoDoiDangNhaps.OrderBy(e => e.Stt).ToList();
        }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void timKiembtn_Click(object sender, RoutedEventArgs e)
        {
            string keyword = timKiemTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                datagrid.ItemsSource = theoDoiDangNhaps; // Nếu rỗng, hiển thị tất cả
            }
            else
            {
                using (var db = new DatnContext())
                {
                    var filteredList = db.TheoDoiDangNhaps
                        .Where(cv => (cv.TkdangNhap != null && cv.TkdangNhap.ToLower().Contains(keyword)) ||
                                     (cv.LoaiTk != null && cv.LoaiTk.ToLower().Contains(keyword)) ||
                                     (cv.NgayDangNhap != null && cv.NgayDangNhap.Value.ToString("dd/MM/yyyy").Contains(keyword)))
                        .ToList();

                    datagrid.ItemsSource = filteredList;
                }
            }
        }
    }
}
