   M S B A M L   `   `   `  ����   DoAnQLThuVien#    DoAnQLThuVien.Data.ThemDocGia   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Thêm Độc Giả��$	��600��$
��1000�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � WindowStartupLocation$ CenterScreen=�.���� ���#E3F2FD �� CornerRadius$ 12�����#2196F3$��1q� �� Padding$ 10q�._��  � ColumnDefinitions �� $	��160 ��� $��* �.+��� $��0��$��10q�.+��� $	��120��$	��160��$ 8�����#2196F3$��2q�
�������._��� -    ��Name$ anhDocGiaImage��$��UniformToFill=��� -    ��Name$ 	Browerbtn��$��Ảnh độc giả��$	��120��$��30��$��0,10,0,0q����#2196F3
�������� $��1��$��	20,0,10,0q�	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��Họ tên độc giả��$
��Bold"��� $��0��$��	0,25,0,10q�
�������$ 6�����#2196F3$��1q�._��� -   
 ��Name$
 tenDGtxt��
������ $��0q�$��14(�$��6q��� $��1��$��
Ngày sinh��$
��Bold"��� $��1�� �� Orientation$ 
Horizontal=�$��	0,25,0,10q�.+��� -    ��Name$ namcb��$��80��$��0,0,10,0q��� -   $ thangcb��$��70��$��0,0,10,0q��� -   $ ngaycb��$��70���� $��2��$��	Số CCCD��$
��Bold"��� $��2��$��	0,25,0,10q�
�������$ 6�����#2196F3$��1q�._��� -   $
 CCCDtxt��
������ $��0q�$��14(�$��6q��� $��3��$��Loại độc giả��$
��Bold"��� $��3��$��	0,25,0,10q�
�������$ 6�����#2196F3$��1q�._��� -   $ 
loaiDocGia��
������ $��0q�$��14(�$��4q��� $��4��$��Số điện thoại��$
��Bold"��� $��4��$��	0,25,0,10q�
�������$ 6�����#2196F3$��1q�._��� -	   $
 SDTtxt��
������ $��0q�$��14(�$��6q��� $��5��$��Địa chỉ��$
��Bold"��� $��5��$��	0,25,0,10q�
�������$ 6�����#2196F3$��1q�._��� -
   $
 	diaChitxt��
������ $��0q�$��14(�$��6q��� $��6��$��Mã độc giả��$
��Bold"��� $��6��$��	0,25,0,10q�
�������$ 6�����#2196F3$��1q�._��� -   $
 maDGtxt��
������ $��0q�$��14(�$��6q��� $��7��$��Ngày đăng ký��$
��Bold"�(  "System.Windows.Controls.DatePicker  -     Name$ ngayDKdp��$��7��$��	0,25,0,10q�$��14(����#2196F3�� $��8��$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $ dongbtn��$��Đóng��$��90��$��30��$��14(����#B0BEC5
���   �$��0,0,10,0q��� -   $ 	dangkybtn��$��Đăng ký & In thẻ��$	��140��$��30��$��14(����#2196F3
�������