using DoAnQLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for QLSach.xaml
    /// </summary>
    public partial class QLSach : UserControl
    {
        public QLSach()
        {
            InitializeComponent();

            DanhSachDauSach danhSachSach = new DanhSachDauSach();
            content.Content = danhSachSach;
        }

        private void danhSachSachbtn_Click(object sender, RoutedEventArgs e)
        {
            DanhSachDauSach danhSachSach = new DanhSachDauSach();
            content.Content = danhSachSach;
        }

        private void duLieuSachbtn_Click(object sender, RoutedEventArgs e)
        {
            DuLieuSach duLieuSach = new DuLieuSach();
            content.Content = duLieuSach;
        }
    }
}
