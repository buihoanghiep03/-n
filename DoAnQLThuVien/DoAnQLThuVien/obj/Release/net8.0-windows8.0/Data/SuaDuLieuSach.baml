   M S B A M L   `   `   `  ����   DoAnQLThuVien&     DoAnQLThuVien.Data.SuaDuLieuSach   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � AllowsTransparency$
  True��
������  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�$	��600��$	��900��$��Segoe UI)� � 	Resources 3  -System.Windows.Media.Effects.DropShadowEffect   DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   Color  PrimaryButton �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value(  "System.Windows.Controls.DatePicker��%�  &	        &	 ,     '�� �    '�� �    '�� �    '  8      $ 10Q�$ 3Q�$	 0.2Q�$ Black���� " ��.��� 	 � ��
 �#2C7FB8�� 	 � ��

 ������� 	 � ��
 �#1B5F8C�� 	 � ��$
 1q��� 	 � ��$

 10,5q��� 	 � ��$
 SemiBold"��� 	 �@�Cursor$

 Hand���� 	 � ��
 �� " ��.R��� #��z��$ 5��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��
 �#1B5F8C�� " ��.��� 	 � ��$
 14(��� 	 � ��$	
 8,5q��� 	 � ��$
 0,0,0,10q��� 	 � ��
 �#DDDDDD�� 	 � ��$
 1q��� 	 � ��$
 Center=� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��
 �#2C7FB8P�  �@J�	IsFocused$
 True��. ��� 	 � ��
 �#2C7FB8�� 	 � ��$	
 1.5q��� " ��.��� 	 � ��$
 14(��� 	 � ��$	
 8,5q��� 	 � ��$
 0,0,0,10q��� 	 � ��
 �#DDDDDD�� 	 � ��$
 1q� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��
 �#2C7FB8�� " ��.��� 	 � ��$
 14(��� 	 � ��$
 SemiBold"��� 	 � ��
 �#333333�� 	 � ��$
 0,0,0,5q��� 	 � ��$
 Center=��� "  .��� 	 � ��$
 14(��� 	 � ��$
 0,0,0,10q�.���� 
�������$ 10�����#CCCCCC$��1q� J� Effect# [  ._��  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0�����#2C7FB8$ 	10,10,0,0��$��45��._�� .+��� $$��CHỈNH SỬA THÔNG TIN SÁCH��
�������$��16(�$
��Bold"�$��Center=�$
��15,0q��� -    ��Name$ btnClose��$	��✕��$��40��$��40��
������ 
�������$��0q�$��16(�$��Right=�� $��1��$��15q� � ColumnDefinitions �� $��2* ��� $��* �.+��� $��0��$��0,0,15,0q�.+��  �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� $��
Mã sách:��$��0���� -    ��Name$ 	sachIDtxt�� �� 
IsReadOnly$
 True�����#F5F5F5$��1���� $��ISBN:��$��2��$��15,0,0,0q��� -   $ ISBNtxt��$
 True�����#F5F5F5$��3���� $��Tên sách:���� -   $ 
tenSachtxt��$
 True�����#F5F5F5�  �� $��* ��� $��* �.+��� $��0��$��0,0,7,0q�.+��� $��Nhóm sách:���� -    ��Name$ 
nhomSachcb�� �� 
IsReadOnly$
 True���� $��1��$��7,0,0,0q�.+��� $��Thể loại:���� -   $ 	TheLoaicb��$
 True���� $��Tác giả:���� -   $ 	tacGiatxt���� $��Nhà xuất bản:���� -   $ nhaXuatBancb�� �� 
IsEditable$
 True���  �� $��* ��� $��* �.+��� $��0��$��0,0,7,0q�.+��� $��Năm xuất bản:���� -	   $ namXuatBancb���� $��1��$��7,0,0,0q�.+��� $��Ngôn ngữ:���� -
   $ 	ngonNgucb���� $��Ngày nhập sách:��  -     Name$ ngayNhapSachdp���� $��1��.+��� ���#DDDDDD$��1q�$ 5��$	��240��$	��160��$��Center=�$��0,0,0,15q�._��� -    ��Name$ anhSachImage��$��Uniform=��� -   $ 	browsebtn��$��Chọn ảnh��#��[ $	��120��$��Center=�$��0,0,0,20q�$��29���� $��Trạng thái:���� -   $ trangThaicb��$��0,0,0,15q��� $��Kệ sách:���� -   $ keSachcb��$��0,0,0,25q���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $ Dongbtn��$��Đóng��#��[ $	��100��$��0,0,10,0q�$��30���� -   $ 
SuaSachbtn��$��Cập nhật��#��[ $	��110��$��30��