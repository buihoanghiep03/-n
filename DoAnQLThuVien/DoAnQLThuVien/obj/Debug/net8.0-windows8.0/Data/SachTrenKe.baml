   M S B A M L   `   `   `  ����H  DDoAnQLThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DoAnQLThuVien.DataDoAnQLThuVien.Data  5   	   #    DoAnQLThuVien.Data.SachTrenKe   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DoAnQLThuVien.Data     5   	   
������   � WindowStyle$
  None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��500��6.   $	��800��6;   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ 	#FFF0F8FF��6    � Offset$ 0Q�61   � 5      $ 	#FFE6F2FF��6   $ 1Q�61   5      .+�5   
   �� ���	#FF4A90E2$��1q�6)    �� CornerRadius$ 5��6=   $��10q�6N    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#   	   Color$	 	#FF4A90E2��63   
   Opacity$	
 0.2Q�6E   ._�5      � .+�5      �� ���	#FF4A90E2$��30��60   $	��Top=�6<   ._�5      �� $!��QUẢN LÝ SÁCH TRÊN KỆ��6    
�������$
��Bold"�5       $��Center=�5        $��Center=�5!       5"      � 5%      $��10,40,10,10q�6    � RowDefinitions 5&      �� 5'      $��* �6(   �� 5(      $
��Auto �6(   �� 5)      $
��Auto �6(   �� 5*      $
��Auto �6(   �� 5+      $
��Auto �6(   .+�5/      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5/      $��0��61      AutoGenerateColumns$ False��50         FrozenColumnCount$ 2��6;   
����������	#FF4A90E2$��1q�51   J      RowBackground
 �����   AlternatingRowBackground �	#FFF5F9FF   ColumnHeaderStyle 53      �� 54       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�55   "   ��  �� Property � �� �� Value �	#FF4A90E26?   �� 56   "    � ��
 �����6?   �� 57   "    � �� �	#FF4A90E26@   �� 58   "    � ��$ 1q�6D   �� 59   "    � ��$ Center=�6O   �� 5:   "    � ��$ Center=�6M   �� 5;   "    � ��$ 5q�6<   �� 5<   "    � ��$ SemiBold"�6?   �� 5=   "    � �� 5>   &   �� 5?   *   .R�5@   .   �� $
��Wrap=�5A   1    �� TextAlignment$ Center=�5B   1   $��Center=�5C   1   ��5@   8   �� 5C   1   5D   +   5F   #   5G         	CellStyle 5J      �� 5K      *  $System.Windows.Controls.DataGridCell"  6$   .�5L   "   ��  � ��$ 5q�6<   �� 5M   "    � �� �#3333336?   �� 5N   "    � �� �	#FFE0E0E06@    �� Triggers 5O   "   P� 5P   &    P� Property �@ 
IsSelected P� Value$
 True��6D   . �5Q   *   ��  � �� �	#FFD8EBFF6G   �� 5R   *    � �� �#0000006G   5S   '   5U         Columns 5Y      4  .System.Windows.Controls.DataGridTemplateColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ Chọn��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6C      CellTemplate 5\   "   �� 5]   &   .R�5^   *   �� -   5        $��Center=�5a   -   
 � Tag 5^   3   �� *Id+5a   -   5b   '   5d      0  *System.Windows.Controls.DataGridTextColumn  5f      $ 
Tên sách��61   $ * 6_   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6C   �� *	TenSach+  	  ElementStyle  5g   "   �� 5h   &   " ��6,   .�5i   *   ��  � ��$ Center=�6P   �� 5j   *    � ��$ Center=�6N   5k   '   5m        5o      $ 
Tác giả��61   $	 200 6]    6B   �� *TacGia+  5p   "   �� 5q   &   " ��6,   .�5r   *   ��  � ��$ Center=�6P   �� 5s   *    � ��$ Center=�6N   5t   '   5v        5x      $ Năm xuât bản��61   $	 100 6f    6G   �� *
NamXuatBan+  5y   "   �� 5z   &   " ��6,   .�5{   *   ��  � ��$ Center=�6P   �� 5|   *    � ��$ Center=�6N   5}   '   5        5�      $ Tình trạng��61   $	 100 6g    6E   �� *TinhTrangSach+  5�   "   �� 5�   &   " ��6,   .�5�   *   ��  � ��$ Center=�6P   �� 5�   *    � ��$ Center=�6N   5�   '   5�      5�      �� 5�      $��1��6!   ! �� Orientation$! 
Horizontal=�6.   $��0,10,0,5q�6G   $��Center=�6Y   .+�5�      �� $��Mã kệ sách:��6    ���	#FF0066CC$��Center=�6M   �� 5�      -   5        " ��Name$" keSachIdtxt��5�   "   $	��120��67   $��5,0,20,0q�6C   ���	#FF4A90E2$��1q�5�   :   �� 5�      $$��Lọc theo nhóm thể loại:��6    ���	#FF0066CC$��Center=�6Y   �� 5�      -   5        # ��Name$# nhomTheLoaicb��5�   #   $	��200��6:   $��5,0,0,0q�6F   ���	#FF4A90E2$��1q�5�   ;   5�   #   5�      �� 5�      $��2��6!   $! 
Horizontal=�6.   $��0,0,0,10q�6G   $��Center=�6Y   .+�5�      �� $��Lọc theo thể loại:��6    ���	#FF0066CC$��Center=�6T   �� 5�      -   5        $# 	theLoaicb��5�   #   $	��200��66   $��5,0,20,0q�6B   ���	#FF4A90E2$��1q�5�   ;   5�   #   5�      �� 5�      $��3��6!   $! 
Horizontal=�6.   $��0,10,0,0q�6G   $��Center=�6Y   .+�5�      �� -   5        $" timKiemMatxt��5�   "   $	��200��68   $��0,0,5,0q�6D   ���	#FF4A90E2$��1q�5�   :   $ �� TextWrapping$
$ Wrap=�5�   "   $��Center=�66   $��25��6Q   �� 5�      -   5        % ��Name$% timKiemMabtn��5�   !   $��Tìm kiếm��67   $��80��6J   ���	#FF4A90E2
�������$��0q�5�   K   $��0,0,5,0q�5�   <   �� 5�      -   5        $% resetbtn��5�   !   $��Reset��63   $��80��6C   ���	#FF4A90E2
�������$��0q�5�   K   5�   !   5�      �� 5�      $��4��6!   $! 
Horizontal=�6.   $��Right=�6G   $��0,15,0,0q�6c   .+�5�      �� -	   5        $% dongbtn��5�   !   $��Đóng��62   $��80��6A   $��30��6L   ���	#FF4A90E2
�������$��0q�5�   K   $��0,0,10,0q�5�   7   �� 5�      -
   5        $% 
catSachbtn��5�   !   $��Cất sách��65   $��80��6H   $��30��6S   ���	#FF4A90E2
�������$��0q�5�   K   $��0,0,10,0q�5�   :   �� 5�      -   5        $% themSachbtn��5�   !   $��Thêm sách��66   $��80��6J   $��30��6U   ���	#FF4A90E2
�������$��0q�5�   K   5�   !   5�      5�      5�      5�      5�      5�      