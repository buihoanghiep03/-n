   M S B A M L   `   `   `  ����   DoAnQLThuVien#    DoAnQLThuVien.Data.SuaDauSach   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
SuaDauSach��$	��650��$
��1000�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � WindowStartupLocation$ CenterScreen=� � 	Resources    RoundedButton �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value��%a  &	        �� " ��.���  � ��
 �������  � �� �#2C7FB8��  � ��$	 6,2q���  � ��$ 14(���  � ��$
 Bold"���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��$	 6�����#1B5F8C$��1q�._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#1B5F8C.���� 
�������$	 10��
�������$��1q�._�� $��5q� � RowDefinitions �� $
��Auto ��� $��* �.+�]� ���#2C7FB8$��40��$��0��.+��� $ ��CHỈNH SỬA ĐẦU SÁCH��
�������$
��Bold"�$��18(�$��Center=�$��10,0,0,0q��� -   $��X��$��40��$��40��
������ 
�������$��16(�$
��Bold"�$��Right=���Z� � $��1��$��10q� � ColumnDefinitions �� $��3* ��� $��1* �.+��� $��0��$��0,0,10,0q�.+�� $��0,0,0,8q�.+��� $��
Mã sách:��$	��100���� -    ��Name$ sachNTLIDtxt��$��60���� -   $ sachTLIDtxt��$��60��$��5,0,0,0q��� -   $ 	sachIDtxt��$	��120��$��5,0,0,0q��� $��Tên sách:���� -   $ 
tenSachtxt��$��0,0,0,8q��� $��Nhóm sách:���� -    ��Name$ 
nhomSachcb��$��0,0,0,8q��� $��Thể loại:���� -   $ 	TheLoaicb��$��0,0,0,8q��� $��Tác giả:���� -   $ 	tacGiatxt��$��0,0,0,8q��� $��Nhà xuất bản:���� -	   $ nhaXuatBancb��$��0,0,0,8q� �� 
IsEditable$
 True���� $��Năm xuất bản:���� -
   $ namXuatBancb��$��0,0,0,8q��� $��ISBN:���� -   $ ISBNtxt��$��0,0,0,8q��� $��Ngôn ngữ:���� -   $ 	ngonNgucb��$��0,0,0,8q��� $��Ngày nhập sách:��(  "System.Windows.Controls.DatePicker  -     Name$ ngayNhapSachdp��$��0,0,0,8q��� $#��Giới hạn người đọc:���� -   $ gioiHanNguoiDoccb��� $��1��$	��Top=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��0��$��0��$��2��$	��150��$	��100��
�������$��1q�$	 5��$��0,0,0,8q�._��� -    ��Name$ anhSachImage���� -    ��Name$ 	browsebtn��$��1��$��0��$��2��$��Chọn ảnh��$	��100��#��[  $��0,0,0,12q��� $��2��$��0��$��Số lượng mới:��$��Center=��� -   $ soLuongSachMoitxt��$��2��$��1��$	��100��$��7,4,6,4q��� $��3��$��0��$$��Số lượng bình thường:��$��Center=��� -   $ soLuongSachBinhThuongtxt��$��3��$��1��$	��100��$��7,4,6,4q��� $��4��$��0��$��Số lượng cũ:��$��Center=��� -   $ soLuongSachCutxt��$��4��$��1��$	��100��$��7,4,6,4q��� $��5��$��0��$��Hỏng nhẹ:��$��Center=��� -   $ soLuongSachHongNhetxt��$��5��$��1��$	��100��$��7,4,6,4q��� $��6��$��0��$��Hỏng nặng:��$��Center=��� -   $ soLuongSachHongNangtxt��$��6��$��1��$	��100��$��7,8,6,8q��� $��7��$��0��$��2�� �� Orientation$ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -   $ Dongbtn��$��Đóng��$��80��$��30��$��0,0,10,0q�#��[  �� -   $ 
CapNhatbtn��$��Cập nhật��$��30��$	��100��#��[  