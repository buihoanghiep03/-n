using System;
using System.Linq;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using DoAnQLThuVien.Models;
using System.ComponentModel;
using System.Windows.Media;

namespace DoAnQLThuVien.Data
{
    public partial class ThongKe : UserControl, INotifyPropertyChanged
    {
        public DatnContext context = new DatnContext();

        public ThongKe()
        {
            InitializeComponent();

            // Tải các số liệu cơ bản
            int tongSach = context.ChiTietSaches.Select(e => e.Id).Distinct().Count();
            int DocGia = context.QuanLyDocGia.Select(e => e.Id).Distinct().Count();
            int NhanSu = context.QuanLyNhanSus.Select(e => e.Id).Distinct().Count();
            tongSachCount.Text = tongSach.ToString();
            docGiaCount.Text = DocGia.ToString();
            nhanSuCount.Text = NhanSu.ToString();

            LoadPieChartData();    // Tải dữ liệu biểu đồ tròn
            LoadChartData();      // Tải dữ liệu biểu đồ cột và đường
        }

        // Bộ sưu tập series cho biểu đồ mượn sách
        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection)); // Thông báo thay đổi cho binding
            }
        }

        // Bộ sưu tập series cho biểu đồ thu chi
        private SeriesCollection _revenueSeriesCollection;
        public SeriesCollection RevenueSeriesCollection
        {
            get => _revenueSeriesCollection;
            set
            {
                _revenueSeriesCollection = value;
                OnPropertyChanged(nameof(RevenueSeriesCollection)); // Thông báo thay đổi cho binding
            }
        }

        // Nhãn cho các trục tháng năm
        private string[] _labels;
        public string[] Labels
        {
            get => _labels;
            set
            {
                _labels = value;
                OnPropertyChanged(nameof(Labels)); // Thông báo thay đổi cho binding
            }
        }

        private void LoadChartData()
        {
            // Lấy tất cả giao dịch đã hoàn thành (sách đã được trả)
            var completedTransactions = context.QuanLyMuonSaches
                .Where(m => m.NgayTraThucTe.HasValue && m.TienBoiThuong.HasValue)
                .ToList();

            // Nhóm dữ liệu theo tháng-năm cho cả 2 biểu đồ
            var monthlyData = completedTransactions
                .GroupBy(m => new { m.NgayMuon.Value.Year, m.NgayMuon.Value.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    // Tổng số sách mượn (cho biểu đồ cột)
                    TotalBooksBorrowed = g.Sum(m => m.SoLuongMuon ?? 0),
                    // Tổng tiền bồi thường (cho biểu đồ đường)
                    TotalRevenue = g.Sum(m => m.TienBoiThuong ?? 0)
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            // Tạo nhãn trục X (định dạng Tháng/Năm)
            Labels = monthlyData.Select(d => $"{d.Month}/{d.Year}").ToArray();

            // Dữ liệu cho Biểu đồ Mượn sách (dạng cột)
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Số sách mượn",
                    Values = new ChartValues<int>(monthlyData.Select(d => d.TotalBooksBorrowed)),
                    Fill = new SolidColorBrush(Color.FromRgb(33, 150, 243)), // Màu xanh dương
                    Stroke = new SolidColorBrush(Color.FromRgb(33, 150, 243)),
                    DataLabels = true // Hiển thị số liệu trên cột
                }
            };

            // Dữ liệu cho Biểu đồ Thu chi (dạng đường)
            RevenueSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Doanh thu bồi thường",
                    Values = new ChartValues<decimal>(monthlyData.Select(d => d.TotalRevenue)),
                    PointGeometry = DefaultGeometries.Circle, // Hình dạng điểm là hình tròn
                    PointGeometrySize = 10, // Kích thước điểm
                    StrokeThickness = 3, // Độ dày đường
                    Fill = Brushes.Transparent, // Không tô màu bên trong
                    Stroke = new SolidColorBrush(Color.FromRgb(76, 175, 80)), // Màu xanh lá
                    DataLabels = true, // Hiển thị số liệu
                    LabelPoint = point => $"{point.Y:N0} VND" // Định dạng hiển thị tiền VND
                }
            };
        }

        // Sự kiện thay đổi property (dùng cho binding dữ liệu)
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Tải dữ liệu cho biểu đồ tròn (tình trạng sách)
        private void LoadPieChartData()
        {
            MyPieChart.Series.Clear(); // Xóa dữ liệu cũ

            var danhSachSach = context.ChiTietSaches.ToList();

            // Nhóm sách theo tình trạng và đếm số lượng
            var tinhTrangCounts = danhSachSach
                .GroupBy(sach => sach.TinhTrangSach)
                .Select(group => new { TinhTrang = group.Key, SoLuong = group.Count() })
                .ToList();

            // Thêm dữ liệu vào biểu đồ tròn
            foreach (var item in tinhTrangCounts)
            {
                MyPieChart.Series.Add(new PieSeries
                {
                    Title = item.TinhTrang, // Tiêu đề = tình trạng sách
                    Values = new ChartValues<int> { item.SoLuong }, // Giá trị = số lượng
                    DataLabels = true, // Hiển thị nhãn
                    Fill = new SolidColorBrush(GetColorForTinhTrang(item.TinhTrang)), // Màu sắc tương ứng
                    LabelPoint = point => $"{point.Participation:P1}" // Hiển thị tỷ lệ phần trăm
                });
            }
        }

        // Hàm trả về màu sắc tương ứng với từng tình trạng sách
        private Color GetColorForTinhTrang(string tinhTrang)
        {
            return tinhTrang switch
            {
                "Mới" => Color.FromRgb(76, 175, 80),       // Xanh lá
                "Bình thường" => Color.FromRgb(33, 150, 243),  // Xanh dương
                "Cũ" => Color.FromRgb(255, 152, 0),       // Cam
                "Hỏng nhẹ" => Color.FromRgb(255, 235, 59),  // Vàng
                "Hỏng nặng" => Color.FromRgb(244, 67, 54),  // Đỏ
                "Mất" => Color.FromRgb(158, 158, 158),    // Xám
                _ => Color.FromRgb(0, 0, 0)               // Đen (mặc định)
            };
        }
    }
}