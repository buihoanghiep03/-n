   M S B A M L   `   `   `  ����  DoAnQLThuVien"    DoAnQLThuVien.Data.SuaDocGia   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � AllowsTransparency$
  True��5   	   
������  � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��600��5   	   $
��1000��6   $��Segoe UI)�5   	   .��5      �� ���#E3F2FD �� CornerRadius$ 12��6"   ���#2196F3$��1q�6J    �� Padding$ 10q�6^   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��160 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��10q�6)   .+�5      �� $	��120��6   $	��160��6%   $ 8��62   ���#2196F3$��2q�6Y   
�������._�5      �� -   5         ��Name$ anhDocGiaImage��5      5      �� 5      -   5         ��Name$ 	Browerbtn��5      $��Ảnh độc giả��6,   $	��120��6B   $��30��6N   $��0,10,0,0q�5      ���#2196F3
�������5      5      � 5       $��1��6   $��	20,0,10,0q�6#    � RowDefinitions 5!      �� 5"      $
��Auto �6$   �� 5$      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5(      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5,      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 50      $
��Auto �6$   �� 52      $
��Auto �6$   .+�57      �� $��Họ tên độc giả��6   $
��Bold"�62   �� 58      $��0��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�59      �� -   5        	 ��Name$	 tenDGtxt��59      
������ $��0q�6I   $��14(�6]   $��6q�6k   5:      �� 5=      $��1��6   $��
Ngày sinh��6)   $
��Bold"�6:   �� 5>      $��1��6   
 �� Orientation$
 
Horizontal=�6*   $��	0,25,0,10q�6C   .+�5?      �� -   5         ��Name$ namcb��5?      $��80��6.   $��0,0,10,0q�69   $��25��6K   �� 5@      -   5        $ thangcb��5@      $��70��60   $��0,0,10,0q�6;   �� 5A      -   5        $ ngaycb��5A      $��70��6/   5B      �� 5E      $��2��6   $��	Số CCCD��6)   $
��Bold"�68   �� 5F      $��2��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�5G      �� -   5        $	 CCCDtxt��5G      
������ $��0q�6H   $��14(�6\   $��6q�6j    �� 
IsReadOnly$
 True��6v   5H      �� 5K      $��3��6   $��Loại độc giả��6)   $
��Bold"�6=   �� 5L      $��3��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�5M      �� -   5        $ 
loaiDocGia��5M      
������ $��0q�6L   $��14(�6`   $��4q�6n   5N      �� 5Q      $��4��6   $��Số điện thoại��6)   $
��Bold"�6>   �� 5R      $��4��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�5S      �� -	   5        $	 SDTtxt��5S      
������ $��0q�6G   $��14(�6[   $��6q�6i   5T      �� 5W      $��5��6   $��Địa chỉ��6)   $
��Bold"�68   �� 5X      $��5��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�5Y      �� -
   5        $	 	diaChitxt��5Y      
������ $��0q�6J   $��14(�6^   $��6q�6l   5Z      �� 5]      $��6��6   $��Mã độc giả��6)   $
��Bold"�6;   �� 5^      $��6��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�5_      �� -   5        $	 maDGtxt��5_      
������ $��0q�6H   $��14(�6\   $��6q�6j   $
 True��6v   5`      �� 5c      $��7��6   $��Ngày đăng ký��6)   $
��Bold"�6=   �� 5d      $��7��6   $��	0,25,0,10q�6&   
�������$ 6��6L   ���#2196F3$��1q�6s   ._�5e      �� -   5        $	 	ngayDKtxt��5e      
������ $��0q�6J   $��14(�6^   $��6q�6l   $
 True��6x   5f      �� 5i      $��8��6   $
 
Horizontal=�6*   $��Right=�6C   $��0,10,0,0q�6_   .+�5j      �� -   5        $ dongbtn��5j      $��Đóng��6.   $��90��6=   $��30��6H   $��14(�6T   ���#B0BEC5
���   �$��0,0,10,0q�5k   E   5l      �� 5m      -   5        $ suabtn��5m      $��Cập nhật��6-   $	��140��6@   $��30��6L   $��14(�6X   ���#2196F3
�������5n   E   5o      5p      5q      5r      5s      