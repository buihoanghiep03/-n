   M S B A M L   `   `   `  ����   DoAnQLThuVien+    %DoAnQLThuVien.Data.TimKiemChiTietSach   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$!  Thông tin chi tiết sách�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�$	��700��$	��900��
������ .���� 
����������#2196F3$��2q� �� CornerRadius$ 12��._�� .+��� ���#2196F3$��50��$ 	10,10,0,0��$	��Top=�$��2��._��� $!��THÔNG TIN CHI TIẾT SÁCH��
�������$��18(�$��SemiBold"�$��Center=�$��Center=�� $��20,60,20,20q� � ColumnDefinitions �� $	��220 ��� $��* � � RowDefinitions �� �� $
��Auto �$��42��.+��� $��0��$��0�����#E0E0E0$��1q�$ 8��$��12,0,0,0q�$	��180��$	��240��$
��Left=�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�	   ShadowDepth$	 3Q�
   Color$
 	#40000000��._��� -    ��Name$ anhSachImage��$��UniformToFill=��� $��1��$��0��$
��Auto=�.����  �� Orientation$ Vertical=�$��0,0,0,20q� � 	Resources  �� 
TargetType �� Property �� Value��%I  '��       '�� �     '�� T    �� " ��.���  � �� �#333333��  � ��$ Tahoma)���  � ��$ 15(���  � ��$	 130����  � ��$ Center=���  � ��$ 0,0,10,0q���  � ��$ Right=��� " ��.���  � ��
 �������  � �� �#BBDEFB��  � ��$ 1q���  �@��CornerRadius$ 4����  �@��Padding$ 2q��� " ��.���  � ��$ Tahoma)���  � ��$ 15(���  � ��$	 500����  � ��$	 5,3q���  � ��$ 0q���  �@��
IsReadOnly$
 True����  � �� �#333333��  � ��
 ���� .+��� $ 
Horizontal=�$	��0,8q�.+��� $��
Mã sách:���� ._��� -    ��Name$ 	sachIDtxt���� $ 
Horizontal=�$	��0,8q�.+��� $��Tên sách:���� ._��� -   $ 
tenSachtxt���� $ 
Horizontal=�$	��0,8q�.+��� $��Nhóm sách:���� ._��� -   $ 
nhomSachcb���� $ 
Horizontal=�$	��0,8q�.+��� $��Thể loại:���� ._��� -   $ 	TheLoaicb���� $ 
Horizontal=�$	��0,8q�.+��� $��Tác giả:���� ._��� -   $ 	tacGiatxt���� $ 
Horizontal=�$	��0,8q�.+��� $��Nhà xuất bản:���� ._��� -   $ nhaXuatBancb���� $ 
Horizontal=�$	��0,8q�.+��� $��Năm xuất bản:���� ._��� -   $ namXuatBancb���� $ 
Horizontal=�$	��0,8q�.+��� $��Ngôn ngữ:���� ._��� -	   $ 	ngonNgucb���� $ 
Horizontal=�$	��0,8q�.+��� $��Ngày nhập sách:���� ._��� -
   $ ngayNhapSachdp���� $ 
Horizontal=�$	��0,8q�.+��� $��ISBN:���� ._��� -   $ ISBNtxt���� $ 
Horizontal=�$	��0,8q�.+��� $��Trạng thái:���� ._��� -   $ trangThaicb���� $ 
Horizontal=�$	��0,8q�.+��� $��Kệ sách:���� ._��� -   $ keSachcb���� -    ��Name$ Dongbtn��$��1��$��1��$��
QUAY LẠI��$��	148,0,0,0q�$
��Left=�$��Center=�$	��120��$��36��$��14(�$��Tahoma)����#2196F3
����������#1976D2$��1q� � Cursor$
 Hand������ " ��.���  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z��$ 4��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#1976D2��  � ��
 �����