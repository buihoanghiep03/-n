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
using static DoAnQLThuVien.Data.TraSach;

    namespace DoAnQLThuVien.Data
    {
        /// <summary>
        /// Interaction logic for ChiTietMuon.xaml
        /// </summary>
        public partial class ChiTietMuon : Window
        {
            private QuanLyMuonSach _muonSach;
            private List<SachMuonViewModel> _sachMuonList;

            public ChiTietMuon(QuanLyMuonSach muonSach)
            {
                InitializeComponent();
                _muonSach = muonSach;
                LoadData();
            }

            private void LoadData()
            {
                maPhieuMuontxt.Text = _muonSach.Id;
                maDocGiatcb.Text = _muonSach.DocGiaId;
                TenNguoiMuontxt.Text = _muonSach.TenDocGia;
                ghiChutxt.Text = _muonSach.GhiChu;
                ngayMuon.Text = _muonSach.NgayMuon?.ToString("dd/MM/yyyy");
                ngayHenTra.Text = _muonSach.NgayHenTra?.ToString("dd/MM/yyyy");
                ngayGiaHan1txt.Text = _muonSach.NgayGiaHanTra1?.ToString("dd/MM/yyyy");
                ngayGiaHan2txt.Text = _muonSach.NgayGiaHanTra2?.ToString("dd/MM/yyyy");
                phiGiaHantxt.Text = _muonSach.PhiGiaHan?.ToString() ?? "";
                _sachMuonList = new List<SachMuonViewModel>();

                if (!string.IsNullOrEmpty(_muonSach.IdsachMuon1))
                    _sachMuonList.Add(new SachMuonViewModel
                    {
                        IdSach = _muonSach.IdsachMuon1,
                        TenSach = _muonSach.TenSach1,
                        TinhTrangSach = _muonSach.TinhTrangSach1,
                        TinhTrangKhiTra = _muonSach.TinhTrangKhiTra1
                    });

                if (!string.IsNullOrEmpty(_muonSach.IdsachMuon2))
                    _sachMuonList.Add(new SachMuonViewModel
                    {
                        IdSach = _muonSach.IdsachMuon2,
                        TenSach = _muonSach.TenSach2,
                        TinhTrangSach = _muonSach.TinhTrangSach2,
                        TinhTrangKhiTra = _muonSach.TinhTrangKhiTra2
                    });

                if (!string.IsNullOrEmpty(_muonSach.IdsachMuon3))
                    _sachMuonList.Add(new SachMuonViewModel
                    {
                        IdSach = _muonSach.IdsachMuon3,
                        TenSach = _muonSach.TenSach3,
                        TinhTrangSach = _muonSach.TinhTrangSach3,
                        TinhTrangKhiTra = _muonSach.TinhTrangKhiTra3
                    });

                datagrid.ItemsSource = _sachMuonList;
            }

        private void dongbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
