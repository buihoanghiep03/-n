   M S B A M L   `   `   `  ����  DoAnQLThuVien$    DoAnQLThuVien.Data.InPhieuMuon   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � AllowsTransparency$
  True��5   	   
������  � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��400��5   	   $	��500��6   .��5      � 
�������.+�5   
   �� -   5         ��Name$ print��5      $��10,10,10,60q�6    
���   �$��1q�6I   ._�5      � 
�������.+�5      �� $��Center=�6   $��0,10,0,0q�65   $	��Top=�6G   $��Tahoma)�6_   $��14(�6s   $
��Bold"�6�   $	��350��6�   .��5      �� $9��3PHIẾU MƯỢN SÁCH THƯ VIỆN TỈNH BẮC NINH��6     �� TextAlignment$ Center=�6O   $��Center=�6f   $	��350��6�   5      �� 5      $��Mã phiếu mượn��6   $
��Left=�60   $��	15,56,0,0q�6K   $	��Top=�6^   $��Tahoma)�6v   $��12(�6�   �� 5      -   5         ��Name$ maPhieuMuontxt��5      $
��Left=�62   $��
122,61,0,0q�6M   $	��Top=�6a   $��91��6y   $��Tahoma)�6�   $��12(�6�   �� 5      $��Mã Người mượn��6   $
��Left=�60   $��
228,53,0,0q�6K   $	��Top=�6_   $��Tahoma)�6w   $��12(�6�   �� 5      -   5        $ maNguoiMuontxt��5      $
��Left=�62   $��
328,57,0,0q�6M   $	��Top=�6a   $	��131��6y   $��Tahoma)�6�   $��12(�6�   �� 5      $��Tên Người mượn��6   $
��Left=�61   $��	12,82,0,0q�6L   $	��Top=�6_   $��Tahoma)�6w   $��12(�6�   �� 5      -   5        $ tenNguoiMuontxt��5      $
��Left=�63   $��
119,86,0,0q�6N   $	��Top=�6b   $	��188��6z   $��Tahoma)�6�   $��12(�6�   �� 5      $!��Số lượng sách mượn��6   $
��Left=�65   $��
312,81,0,0q�6P   $	��Top=�6d   $��Tahoma)�6|   $��12(�6�   �� 5      -   5        $ soLuongSachMuontxt��5      $
��Left=�66   $��
431,86,0,0q�6Q   $	��Top=�6e   $��28��6}   $��Tahoma)�6�   $��12(�6�   �� 5      $��Ngày mượn��6   $
��Left=�6,   $��
17,107,0,0q�6G   $	��Top=�6[   $��Tahoma)�6s   $��12(�6�   �� 5      -   5        $ NgayMuon��5      $
��Left=�6,   $��
93,111,0,0q�6G   $	��Top=�6[   $	��117��6s   $��Tahoma)�6   $��12(�6�   �� 5!      $��Ngày hẹn trả��6   $
��Left=�6/   $��222,107,0,0q�6J   $	��Top=�6_   $��Tahoma)�6w   $��12(�6�   �� 5"      -   5        $ 
NgayHenTra��5"      $
��Left=�6.   $��306,111,0,0q�6I   $	��Top=�6^   $	��153��6v   $��Tahoma)�6�   $��12(�6�   &   System.Windows.Controls.DataGrid  5$      -   5          Name$ datagrid��5$         AutoGenerateColumns$ False��5%         HeadersVisibility$ Column=�5&      	   GridLinesVisibility$		 All=�5'      
���   �$��1q�5)      
�������
   RowBackground

 �����   AlternatingRowBackground
 �����   CanUserAddRows$ False��5-         CanUserDeleteRows$ False��5.         
IsReadOnly$
 True��5/      $��10,146,10,111q�50         Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã sách��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Id+   ElementStyle 53      �� 54   "    �� 
TargetType" ��6(   .�55   &   ��  �� Property � �� �� Value$ Center=�6L   �� 56   &    � ��$ Center=�6J   �� 57   &    �@��TextAlignment$ Center=�6F   58   #   5:        5<      $ 
Tên sách��6-   $ * 6[    6?   �� *	TenSach+ 5=      �� 5>   "   " ��6(   .�5?   &   ��  � ��$ Center=�6L   �� 5@   &    � ��$ Center=�6J   �� 5A   &    �@��TextAlignment$ Center=�6F   5B   #   5D        5F      $ Tình trạng��6-   $	 100 6c    6A   �� *TinhTrangSach+ 5G      �� 5H   "   " ��6(   .�5I   &   ��  � ��$ Center=�6L   �� 5J   &    � ��$ Center=�6J   �� 5K   &    �@��TextAlignment$ Center=�6F   5L   #   5N       � 	Resources 5Q      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell��%"  '        '      �� 5S      "  6    .�5T      ��  � ��
 �����6;   �� 5U       � ��
 �   �6<   �� 5V       � ��$ 1q�6@   �� 5W       � ��$ Tahoma)�6;   �� 5X       � ��$ 12(�69   �� 5Y       � ��$ Center=�6K   5Z      �� 5\      "  6    .�5]      ��  � ��
 �   �6<   �� 5^       � ��$ 1q�6@   �� 5_       � ��
 �����6;   �� 5`       � ��$ Tahoma)�6;   �� 5a       � ��$ 12(�69   �� 5b       � ��$ Center=�6K   5c      5d      5e      �� 5g      $��Thủ thư ký tên��6   $
��Left=�61   $��339,232,0,0q�6L   $	��Top=�6a   �� 5h      $��/Images/Icons/logo.jpg��6   $
��Left=�68   $��74��6S   $��
58,232,0,0q�6_   $	��Top=�6s   $��63��6�   5i      5j      �� 5k   
   -	   5         ��Name$ 
inPhieubtn��5k      $��
In phiếu��6%   $��Right=�68   $��
0,356,80,0q�6T   $	��Top=�6h   $��25��6�   $��70��6�   6�   �� 5l   
   -
   5        $ dongbtn��5l      $��Đóng��6"   $
��Left=�61   $��
80,356,0,0q�6L   $	��Top=�6`   $��25��6x   $��70��6�   6�   5m      5n      