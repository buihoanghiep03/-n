   M S B A M L   `   `   `  ����H  DDoAnQLThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DoAnQLThuVien.DataDoAnQLThuVien.Data  5   	   U QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5   	   #    DoAnQLThuVien.Data.ThemNhanSu   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DoAnQLThuVien.Data     5   	   ?System,clr-namespace:System;assembly=System.Runtime     5   	     � AllowsTransparency$
  True��5	   	   
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��700��5      $
��1100��6   .��5      � 
�������.+�5   
   �� $��790,110,160,394q�6   $	��150��5      $	��200��5      
���   �$��1q�5      ._�5      �� -   5         ��Name$ imagiPicture��5      5      �� 5   
   $��790,315,160,354q�6   ���	#FF21519E �� CornerRadius$ 10��6A   ._�5      �� -   5         ��Name$ 	browsebtn��5      $��Browse��5      
�������$��Tahoma)�5   h   $��16(�6|   ��6(   Z� ��6>   Z� 6|   5      �� 5   
   $��Mã nhân sự��6   $
��Left=�5      $��	82,86,0,0q�5      $	��Top=�5      $��Tahoma)�5       $��16(�6!   ���	#FF0E0E0E6/   �� 5!   
   -   5         ��Name$ 
maTatCVtxt��5!      $
��Left=�5"   	   $��
212,86,0,0q�5#   	   $	��Top=�5$   	   $��60��5%   	   $��Tahoma)�5&   	   $��16(�6   $��36��5'   	   
���   �6   �� 5(   
   -   5        $ maNhanSutxt��5(      $
��Left=�5)      $��
277,86,0,0q�5*      $	��Top=�5+      $	��110��5,      $��Tahoma)�5-      $��16(�6!   $��36��5.      
���   �6   �� 50   
   $��Họ và tên��6   $
��Left=�51      $��
82,136,0,0q�52      $	��Top=�53      $��Tahoma)�54      $��16(�6!   ���	#FF0E0E0E6/   �� 55   
   -   5        $ tenNhanSutxt��55      $
��Left=�56   	   $��212,136,0,0q�57   	   $	��Top=�58   	   $	��350��59   	   $��Tahoma)�5:   	   $��16(�6   $��36��5;   	   
���   �6   �� 5<   
   $��Giới tính��6   $
��Left=�5=      $��
82,186,0,0q�5>      $	��Top=�5?      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5@   
   -   5         ��Name$ 
gioiTinhcb��5@       �� 
IsReadOnly$
 True��5A   	   $
��Left=�5B   	   $��212,186,0,0q�5C   	   $	��Top=�5D   	   $	��200��5E   	   $��36��6   $��Tahoma)�5F   	   $��16(�6   
���   �6+   �� 5G   
   $��
Ngày sinh��6   $
��Left=�5H      $��
82,236,0,0q�5I      $	��Top=�5J      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5K   
   $��	Số CCCD��6   $
��Left=�5L      $��
82,286,0,0q�5M      $	��Top=�5N      $��Tahoma)�5O      $��16(�6!   ���	#FF0E0E0E6/   �� 5P   
   -   5        $ 	soCCCDtxt��5P      $
��Left=�5Q   	   $��212,284,0,0q�5R   	   $	��Top=�5S   	   $	��350��5T   	   $��Tahoma)�5U   	   $��16(�6   $��36��5V   	   
���   �6   �� 5W   
   $��Nơi ở hiện tại��6   $
��Left=�5X      $��77,0,0,0q�5Y      $��Center=�5Z      $��Tahoma)�5[      $��16(�6!   ���	#FF0E0E0E6/   �� 5\   
   -   5        $ noiOtxt��5\      $
��Left=�5]   	   $��212,333,0,0q�5^   	   $	��Top=�5_   	   	 �� TextWrapping$
	 Wrap=�5`   	   $	��345��5a   	   $��Tahoma)�5b   	   $��16(�6   $	��132��5c   	   
���   �6   �� 5d   
   $��Số điện thoại��6   $
��Left=�5e      $��
77,479,0,0q�5f      $	��Top=�5g      $��Tahoma)�5h      $��16(�6!   ���	#FF0E0E0E6/   �� 5i   
   -	   5        $ soDienThoaitxt��5i      $
��Left=�5j   	   $��212,477,0,0q�5k   	   $	��Top=�5l   	   $	��200��5m   	   $��Tahoma)�5n   	   $��16(�6   $��34��5o   	   
���   �6   �� 5p   
   $��Email��6   $
��Left=�5q      $��
77,529,0,0q�5r      $	��Top=�5s      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5t   
   -
   5        $ emailtxt��5t      $
��Left=�5u   	   $��212,525,0,0q�5v   	   $	��Top=�5w   	   $	��200��5x   	   $��34��5y   	   $��Tahoma)�5z   	   $��16(�6   
���   �6+   �� 5{   
   $��Ngày bắt đầu��6   $
��Left=�5|      $��682,399,0,0q�5}      $	��Top=�5~      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5�   
   $��Lương cơ bản��6   $
��Left=�5�      $��685,494,0,0q�5�      $	��Top=�5�      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5�   
   -   5        $ luongCoBantxt��5�      $
��Left=�5�      $��845,494,0,0q�5�      $	��Top=�5�      $	��200��5�      $��34��5�      $��Tahoma)�5�      $��16(�6!   
���   �6/   �� 5�   
   $��Loại nhân sự��6   $
��Left=�5�      $��686,540,0,0q�5�      $	��Top=�5�      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5�   
   -   5        $ loaiNhanSutxt��5�      ${�False��5�      $
��Left=�5�      $��846,540,0,0q�5�      $	��Top=�5�      $	��200��5�      $��34��5�      $��Tahoma)�5�      $��16(�6!   
���   �6/   �� 5�   
   $��480,610,430,44q�6   $ 20��6)   ���	#FF3B27C8._�5�      �� -   5        $ savebtn��5�      $��Lưu nhân sự��5�      $��Center=�5�      $��Center=�5�      $��Tahoma)�5�      $��16(�6%   
�������$��50��5�   :   $	��190��6F   ��5�      Z� ��5�   $   Z� 6F   5�      �� 5�   
   $��Enter New Employee Info��6   $��357,15,0,634q�5�      $
��Left=�5�      $��Tahoma)�5�      
�������$��34(�5�       $
��Bold"�6.   �� 5�   
   $��27,635,883,19q�6   $ 20��6(   ���	#FF3B27C8._�5�      �� -   5        $ backbtn��5�      $��
Quay lại��5�      $��Center=�5�      $��Center=�5�      $��Tahoma)�5�      $��16(�6%   
�������$	��190��5�   :   $��50��6F   ��5�      Z� ��5�   $   Z� 6F   5�      �� 5�   
   $��Công việc��6   $
��Left=�5�      $��683,446,0,0q�5�      $	��Top=�5�      $��Tahoma)�6%   $��16(�69   ���	#FF0E0E0E6G   �� 5�   
   -   5        $ 
congVieccb��5�      $
��Left=�5�      $��843,446,0,0q�5�      $	��Top=�5�      $	��200��5�      $��34��5�      $��Tahoma)�5�      $��16(�6!   
���   �6C   �� 5�   
   -   5        $ namcb��5�      $
��Left=�6"   $��212,238,0,0q�6=   $	��Top=�6R   $��70��6j   $��Tahoma)�6u   $��16(�6�   �� 5�   
   -   5        $ thangcb��5�      $
��Left=�6$   $��287,238,0,0q�6?   $	��Top=�6T   $��60��6l   $��Tahoma)�6w   $��16(�6�   �� 5�   
   -   5        $ ngaycb��5�      $
��Left=�6#   $��352,238,0,0q�6>   $	��Top=�6S   $��60��6k   $��Tahoma)�6v   $��16(�6�   �� 5�   
   -   5        $ nambatdaucb��5�      $
��Left=�6(   $��845,401,0,0q�6C   $	��Top=�6X   $��70��6p   $��Tahoma)�6{   $��16(�6�   �� 5�   
   -   5        $ thangbatdaucb��5�      $
��Left=�6*   $��920,401,0,0q�6E   $	��Top=�6Z   $��60��6r   $��Tahoma)�6}   $��16(�6�   �� 5�   
   -   5        $ ngaybatdaucb��5�      $
��Left=�6)   $��985,401,0,0q�6D   $	��Top=�6Y   $��60��6q   $��Tahoma)�6|   $��16(�6�   5�      5�      