   M S B A M L   `   `   `  ����   DoAnQLThuVien$    DoAnQLThuVien.Data.InPhieuMuon   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � AllowsTransparency$
  True��
������  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�$	��400��$	��500��.��� 
�������.+��� -    ��Name$ print��$��10,10,10,60q�
���   �$��1q�._�� 
�������.+��� $��Center=�$��0,10,0,0q�$	��Top=�$��Tahoma)�$��14(�$
��Bold"�$	��350��.���� $9��3PHIẾU MƯỢN SÁCH THƯ VIỆN TỈNH BẮC NINH�� �� TextAlignment$ Center=�$��Center=�$	��350���� $��Mã phiếu mượn��$
��Left=�$��	15,56,0,0q�$	��Top=�$��Tahoma)�$��12(��� -    ��Name$ maPhieuMuontxt��$
��Left=�$��
122,61,0,0q�$	��Top=�$��91��$��Tahoma)�$��12(��� $��Mã Người mượn��$
��Left=�$��
228,53,0,0q�$	��Top=�$��Tahoma)�$��12(��� -   $ maNguoiMuontxt��$
��Left=�$��
328,57,0,0q�$	��Top=�$	��131��$��Tahoma)�$��12(��� $��Tên Người mượn��$
��Left=�$��	12,82,0,0q�$	��Top=�$��Tahoma)�$��12(��� -   $ tenNguoiMuontxt��$
��Left=�$��
119,86,0,0q�$	��Top=�$	��188��$��Tahoma)�$��12(��� $!��Số lượng sách mượn��$
��Left=�$��
312,81,0,0q�$	��Top=�$��Tahoma)�$��12(��� -   $ soLuongSachMuontxt��$
��Left=�$��
431,86,0,0q�$	��Top=�$��28��$��Tahoma)�$��12(��� $��Ngày mượn��$
��Left=�$��
17,107,0,0q�$	��Top=�$��Tahoma)�$��12(��� -   $ NgayMuon��$
��Left=�$��
93,111,0,0q�$	��Top=�$	��117��$��Tahoma)�$��12(��� $��Ngày hẹn trả��$
��Left=�$��222,107,0,0q�$	��Top=�$��Tahoma)�$��12(��� -   $ 
NgayHenTra��$
��Left=�$��306,111,0,0q�$	��Top=�$	��153��$��Tahoma)�$��12(�&   System.Windows.Controls.DataGrid  -     Name$ datagrid��   AutoGenerateColumns$ False��   HeadersVisibility$ Column=�	   GridLinesVisibility$		 All=�
���   �$��1q�
�������
   RowBackground

 �����   AlternatingRowBackground
 �����   CanUserAddRows$ False��   CanUserDeleteRows$ False��   
IsReadOnly$
 True��$��10,146,10,111q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã sách��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+   ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=�  $ 
Tên sách��$ *  �� *	TenSach+ �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=�  $ Tình trạng��$	 100  �� *TinhTrangSach+ �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell��%L  '        '  �     �� "  .���  � ��
 �������  � ��
 �   ���  � ��$ 1q���  � ��$ Tahoma)���  � ��$ 12(���  � ��$ Center=��� "  .���  � ��
 �   ���  � ��$ 1q���  � ��
 �������  � ��$ Tahoma)���  � ��$ 12(���  � ��$ Center=��� $��Thủ thư ký tên��$
��Left=�$��339,232,0,0q�$	��Top=��� $��/Images/Icons/logo.jpg��$
��Left=�$��74��$��
58,232,0,0q�$	��Top=�$��63���� -	    ��Name$ 
inPhieubtn��$��
In phiếu��$��Right=�$��
0,356,80,0q�$	��Top=�$��25��$��70���� -
   $ dongbtn��$��Đóng��$
��Left=�$��
80,356,0,0q�$	��Top=�$��25��$��70��