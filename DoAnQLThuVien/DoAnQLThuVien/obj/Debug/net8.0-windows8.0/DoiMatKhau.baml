   M S B A M L   `   `   `  ����H  DDoAnQLThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DoAnQLThuVienDoAnQLThuVien  5   	       DoAnQLThuVien.DoiMatKhau   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DoAnQLThuVien     5   	     � AllowsTransparency$
  True��5   	   
������  � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Đổi mật khẩu��5   	   $	��600��6   $
��1024��6+    � Icon$% pack://application:,,,/logo.ico��5   	   .��5      ��  �� CornerRadius$ 30��6   ���	#FF215A9A._�5   
   � .+�5      �� $	��512��6   $ 	30,0,0,30��6!   ���	#FF1A4B8C._�5      �� $ ��/Images/Icons/backsite.jpg��6   $��UniformToFill=�6<    J� Opacity$	 0.8Q�6T   $��-257,0,257,0q�6b   5      �� 5      $	��512��6   $ 	0,30,30,0��6!   
�������$��	512,0,0,0q�6M   ._�5      � .+�5      �� $��Center=�6!   $��Center=�6<   $	��350��6Y   .+�5      �� $��ĐỔI MẬT KHẨU��6$   $��28(�5   $   $
��Bold"�5   $   ���	#FF215A9A$��Center=�5   $   $��0,0,0,40q�5    $   �� 5#      $ ��Mã Admin - Mã thủ thư��6$   $��14(�5$   $   ���#555555$��5,0,0,5q�5&   $   �� 5(      $ 5��6!   ���#F5F5F5���#DDDDDD$��1q�6]   ._�5)      �� -   5         ��Name$ maTTtxt��5)   &   $��14(�5*   &   $��40��5+   &   $��10q�5,   &   
������ $��0q�5.   &   ���#333333 �� 
CaretBrush �	#FF215A9A50   &   51      �� 54      $��Mật khẩu mới��6$   $��14(�55   $   ���#555555$��5,15,0,5q�57   $   �� 59      $ 5��6!   ���#F5F5F5���#DDDDDD$��1q�6]   ._�5:      G� -   5        	 G�Name$	 moipb��5:   *   $��14(�5;   )   $��40��5<   )   $��10q�5=   )   
������ $��0q�5?   )   ���#333333
 G� 
CaretBrush
 �	#FF215A9A5B   )   5C      �� 5F      $$��Xác nhận mật khẩu mới��6$   $��14(�5G   $   ���#555555$��5,15,0,5q�5I   $   �� 5K      $ 5��6!   ���#F5F5F5���#DDDDDD$��1q�6]   ._�5L      G� -   5        $	 	xacNhanpb��5L   *   $��14(�5M   )   $��40��5N   )   $��10q�5O   )   
������ $��0q�5Q   )   ���#333333
 �	#FF215A9A5T   )   5U      �� 5X      -   5         ��Name$ doiMatKhaubtn��5X   !   $��ĐỔI MẬT KHẨU��5Y       $��45��5Z       $��16(�5[       $
��Bold"�5\       
����������	#FF215A9A$��0q�5_        � Cursor$
 Hand��5`       $��	0,25,0,15q�5b       ��5c      �� 5d   "    �� 
TargetType" ��62   .R�5e   &   �� #��z��6-   $ 5��5f   -   ._�5g   *   �� $��Center=�6;   $��Center=�6X   5h   '   5i   #   ��5k      �� 5l   "    �� 
TargetType" ��6(   .�5m   &   ��  �� Property � �� �� Value �	#FF215A9A6C    �� Triggers 5n   &   P� 5o   *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �5p   .   ��  � �� �#1A4B8C6K   5q   +   5s   #   5u      �� 5x      -   5        $ closebtn��5x   !   $��
QUAY LẠI��5y   !   $	��120��5z   !   $��35��5{   !   $��13(�5|   !   
����������#F44336$��0q�5   !   $
 Hand��5�   !   $��Center=�5�   !   ��5�      �� 5�   "   " ��62   .R�5�   &   �� #��z��6-   $ 5��5�   -   ._�5�   *   �� $��Center=�6;   $��Center=�6X   5�   '   5�   #   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  � �� �#F443366C    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��6I   . �5�   .   ��  � �� �#D32F2F6K   5�   +   5�   #   5�      5�      �� 5�      $��/Images/Icons/logo.jpg��6   $��60��5�      $��73��6'   $��Center=�5�      $	��Top=�5�      $��0,10,0,0q�5�      5�      5�      5�      5�      5�      