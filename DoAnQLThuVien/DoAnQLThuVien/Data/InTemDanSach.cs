using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using QRCoder;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Windows;


namespace DoAnQLThuVien.Data
{
    class InTemDanSach
    {
        private List<string> bookCodes;

        public InTemDanSach(List<string> bookCodes)
        {
            this.bookCodes = bookCodes;
        }

        public void GeneratePdf()
        {
            // 🛠 Mở hộp thoại chọn đường dẫn lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Chọn nơi lưu file PDF",
                FileName = "TemSach.pdf"
            };

            bool? result = saveFileDialog.ShowDialog();
            if (result != true)
            {
                MessageBox.Show("Bạn chưa chọn nơi lưu file.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string outputPath = saveFileDialog.FileName;

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            int pageWidth = (int)page.Width;

            // 🛠 Điều chỉnh kích thước tem
            int labelWidth = pageWidth / 5;  // 5 tem mỗi hàng
            int labelHeight = 80;  // Giảm chiều cao tem một chút
            int x = 0, y = 20;
            int padding = 3;
            int itemsPerRow = 5;  // 5 tem trên mỗi hàng
            int index = 0;

            // 🛠 Giảm cỡ chữ tiêu đề xuống 2/3
            XFont titleFont = new XFont("Arial", 7, XFontStyleEx.Bold);  // Giảm từ 10 xuống 7
            XFont codeFont = new XFont("Arial", 6, XFontStyleEx.Regular); // Mã sách nhỏ hơn một chút

            foreach (var bookCode in bookCodes)
            {
                if (index % itemsPerRow == 0 && index != 0)
                {
                    x = 0;
                    y += labelHeight + padding;
                }

                // 🖼 Vẽ khung viền
                gfx.DrawRectangle(XPens.Black, x, y, labelWidth, labelHeight);

                // 🖋 Tiêu đề thư viện (cỡ chữ nhỏ hơn)
                gfx.DrawString("Thư viện Tỉnh Bắc Ninh", titleFont, XBrushes.Black,
                               new XPoint(x + labelWidth / 2, y + 12), XStringFormats.Center);

                // 📷 Tạo mã QR (thu nhỏ hơn)
                Bitmap qrBitmap = GenerateQRCode(bookCode);
                using (MemoryStream stream = new MemoryStream())
                {
                    qrBitmap.Save(stream, ImageFormat.Png);
                    XImage qrImage = XImage.FromStream(stream);
                    gfx.DrawImage(qrImage, x + (labelWidth - 40) / 2, y + 18, 40, 40); // QR code nhỏ hơn
                }

                // 🔢 Hiển thị mã sách (gần QR code hơn)
                gfx.DrawString(bookCode, codeFont, XBrushes.Black,
                               new XPoint(x + labelWidth / 2, y + 65), XStringFormats.Center);

                x += labelWidth;
                index++;
            }

            // 📁 Lưu file PDF
            document.Save(outputPath);
            MessageBox.Show("File PDF đã được lưu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // 🛠 Mở thư mục chứa file PDF
            string folderPath = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }


        private Bitmap GenerateQRCode(string bookCode)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(bookCode, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                return qrCode.GetGraphic(10);
            }
        }
    }
}
