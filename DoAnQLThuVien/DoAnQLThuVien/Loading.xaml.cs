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

namespace DoAnQLThuVien
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
        }

        // Phương thức cập nhật progress
        public void UpdateProgress(int value)
        {
            if (progressBar != null)
            {
                // Tính toán giá trị width của progressBar theo tỷ lệ phần trăm
                double maxWidth = 570; // Giả sử thanh tiến trình có chiều rộng tối đa là 600 pixel
                double newWidth = (value / 100.0) * maxWidth;
                progressBar.Width = newWidth;
            }
            else
            {
                MessageBox.Show("progressBar is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Ví dụ phương thức khởi chạy tiến trình
        public async Task StartLoading()
        {
            for (int i = 0; i <= 100; i++)
            {
                UpdateProgress(i);  // Cập nhật giá trị của thanh tiến trình
                await Task.Delay(15 );  // Giả lập quá trình xử lý
            }
            // Đóng cửa sổ loading
            this.Close();
        }
    }
}
