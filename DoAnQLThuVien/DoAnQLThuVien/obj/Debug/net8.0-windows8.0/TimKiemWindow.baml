   M S B A M L   `   `   `  ����H  DDoAnQLThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DoAnQLThuVienDoAnQLThuVien  5   	   !    DoAnQLThuVien.TimKiemWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DoAnQLThuVien     5   	     � AllowsTransparency$
  True��5   	   
������  � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   $
��1080��6.   $
��1920��6<    � Icon$% pack://application:,,,/logo.ico��5   	    � 	Resources 5         ModernLabelStyle �� 
TargetType �� Property �� Value  ModernTextBoxStyle  ModernComboBoxStyle  ModernButtonStyle  DetailButtonStyle��%f  &	        &	 �     &	 e    &	 �    &	 �    �� 5   
   " ��6)   .�5      ��  � �� �	#FF215A9A6+   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ 18(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 10q�6'   5      �� 5   
   " ��6+   .�5      ��  � ��
 �����6+   �� 5       � �� �	#FF215A9A6+   �� 5       � �� �	#FF215A9A6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 5q�6(   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�69   �� 5       � ��$ 30��6'   �� 5        � ��$	 200��6&   5!      �� 5#   
   " ��6,   .�5$      ��  � ��
 �����6+   �� 5%       � �� �	#FF215A9A6+   �� 5&       � �� �	#FF215A9A6,   �� 5'       � ��$ 1q�60   �� 5(       � ��$ 5q�6(   �� 5)       � ��$ 14(�6)   �� 5*       � ��$ Center=�69   �� 5+       � ��$ 30��6'   �� 5,       � ��$	 200��6&   5-      �� 5/   
   " ��6*   .�50      ��  � �� �	#FF215A9A6+   �� 51       � ��
 �����6+   �� 52       � �� �	#FF215A9A6,   �� 53       � ��$ 1q�60   �� 54       � ��$
 10,5q�6(   �� 55       � ��$ 14(�6)   �� 56       � ��$
 Bold"�6+   �� 57       �@�Cursor$
 Hand��6'   �� 58       � ��$	 200��6&   �� 59       � ��$ 40��6'   5:      �� 5=   
   " ��6*   .�5>      ��  � �� �	#FF215A9A6+   �� 5?       � ��
 �����6+   �� 5@       � �� �	#FF215A9A6,   �� 5A       � ��$ 1q�60   �� 5B       � ��$ 5q�6(   �� 5C       � ��$ 12(�6)   �� 5D       � ��$
 Bold"�6+   �� 5E       �@�Cursor$
 Hand��6'   �� 5F       � ��$ 70��6&   �� 5G       � ��$ 25��6'   5H      5I      .��5K      � ���	#FFE2E2E2.+�5N   
   �� ���	#FF215A9A$��1q�6)   $��
0,0,0,1015q�6=   ���	#FF215A9A6Q   �� 5Q   
   ���	#FF215A9A$��1q�6)   $��1640,75,10,70q�6=   
������� �� CornerRadius$ 10��6g   ._�5R      �� $��10q�6   .+�5S      �� $��Tìm kiếm sách��6   #��[  60   �� 5T      -   5        	 ��Name$	 
timKiemtxt��5T      #��[ 6.   �� 5V      $��Tìm tác giả��6   #��[  6.   �� 5W      -   5        $	 timTacGiatxt��5W      #��[ 60   �� 5Y      $#��Tìm kiếm nhà xuất bản��6   #��[  68   �� 5Z      -   5        
 ��Name$
 timNhaXuatBancb��5Z      #��[ 64   �� 5\      $��Nhóm thể loại sách��6   #��[  65   �� 5]      -   5        $
 timNhomTheLoaicb��5]      #��[ 65   6b   �� 5_      $��Thể loại sách��6   #��[  60   �� 5`      -   5        $
 timTheLoaicb��5`      #��[ 61   6^   �� 5b      $��Năm xuất bản��6   #��[  6/   �� 5c      -   5        $
 timNamXuatBancb��5c      #��[ 64   6a   �� 5e      $��Ngôn ngữ��6   #��[  6+   �� 5f      -   5        $
 	ngonNgucb��5f      #��[ 6.   6[   �� 5h      $��Tình trạng sách��6   #��[  62   �� 5i      -   5        $
 timTrangThaiSachcb��5i      #��[ 67   6d   �� 5l      -	   5         ��Name$ 
locSachbtn��5l      $��Lọc sách��6-   #��[ 6@   $��	0,20,0,10q�6k   6~   �� 5m      -
   5        $ resetbtn��5m      $��Reset��6+   #��[ 6;   $��0,0,0,10q�6f   6x   �� 5n      -   5        $ closebtn��5n      $��Đóng��6+   #��[ 6:   6e   5o      5p      �� 5t   
   $��25,75,300,70q�6   
����������	#FF215A9A$��1q�6R   $ 10��6f   ._�5u      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5u         AutoGenerateColumns$ False��5w      
�������
������ $��0q�5x   <      	RowHeight$ 40Q�5y         ColumnHeaderHeight$ 40Q�6    �� AlternationCount$ 2��5z         GridLinesVisibility$
 None=�5{         HorizontalGridLinesBrush �	#FFE0E0E0   VerticalGridLinesBrush �	#FFE0E0E0   EnableRowVirtualization$ False��5~       5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� TextAlignment*  $System.Windows.Controls.DataGridCell �� Color��%{  '        '  r    (�� �    5�   &   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(�� �    5�   &   * SystemColors.HighlightBrushKey+)�� 5�      "  6   .�5�      ��  � �� �	#FF215A9A67   �� 5�       � ��
 �����67   �� 5�       � ��$ Center=�6G   �� 5�       � ��$ Center=�6E   �� 5�       � ��$ 14(�65   �� 5�       � ��$
 Bold"�67   �� 5�       � ��$
 10,5q�64   �� 5�       � �� 5�      �� 5�   "   "  62   .R�5�   &   �� #��z��6-   ���	#FF215A9A$��1q�5�   =   $ 5��5�   %   ._�5�   *   �� #��z��64   $��Stretch=�5�   ,   $ Center=�5�   ,   $��Center=�5�   ,   $��14(�5�   ,   $
��Bold"�6:   $
��Wrap=�5�   ,   5�   '   5�   #   5�      5�      �� 5�      "  6   .�5�      ��  � ��$ 5q�64   �� 5�       � ��
 �   �67   �� 5�       � ��$ 13(�65   �� 5�       � ��$ Center=�6G   �� 5�       � ��$ Center=�6E   �� 5�       � ��$ 0q�6<   �� 5�       � �� �	#FFE0E0E068   5�      �� 5�      $ 	#FFE6F3FF��6i   �� 5�      $ 	#FF215A9A��6X   5�         RowStyle 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5�      P� 5�       P� Property �@��AlternationIndex P� Value$ 0��6O   . �5�   "   ��  � ��
 �����6?   5�      P� 5�       �@��AlternationIndex$ 1��6O   . �5�   "   ��  � �� �	#FFE6F3FF6?   5�      5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã sách��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Id+    ElementStyle  5�      �� 5�      " ��6$   .�5�   "   ��  �@��TextAlignment$ Center=�6B   �� 5�   "    � ��$ Stretch=�6H   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��$
 Bold"�6?   �� 5�   "    � ��
 �   �6?   5�      5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $ Ảnh bìa sách��6-   $	 120 6C   ! 	  CellTemplate! 5�      �� 5�      .R�5�   "   �� $��80��6)   $	��120��64   ���	#FFE0E0E0$��1q�6Y   
�������$ 3��5�   <   $��Center=�6M   ._�5�   6   �� $
��Fill=�5�   (   $��Center=�5�   (   $��Center=�5�   (   ��5�   <   �� *AnhBia+5�   (   5�   #   5�      5�        5�      $ 
Tên sách��6)   $ * 6W    6;   �� *	TenSach+  5�      �� 5�      " ��6$   .�5�   "   ��  �@��TextAlignment$ Center=�6B   �� 5�   "    � ��$ Stretch=�6H   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��
 �   �6?   5�      5�        5�      $ 
Tác giả��6)   $	 300 6U    6:   �� *TacGia+  5�      �� 5�      " ��6$   .�5�   "   ��  �@��TextAlignment$ Center=�6B   �� 5�   "    � ��$ Stretch=�6H   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��
 �   �6?   5�      5�        5�      $ Năm xuất bản��6)   $	 100 6^    6?   �� *
NamXuatBan+  5�      �� 5�      " ��6$   .�5�   "   ��  �@��TextAlignment$ Center=�6B   �� 5�   "    � ��$ Stretch=�6H   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��
 �   �6?   5�      5�        5�      $ Nhà xuất bản��6)   $	 200 6^    6?   �� *
NhaXuatBan+  5�      �� 5�      " ��6$   .�5�   "   ��  �@��TextAlignment$ Center=�6B   �� 5�   "    � ��$ Stretch=�6H   �� 5�   "    � ��$ Center=�6F   �� 5   "    � ��
 �   �6?   5     5       5     $ Vị trí hiện tại��6)   $	 150 6]    6B   �� *KeSach+  5     �� 5     " ��6$   .�5  "   ��  �@��TextAlignment$ Center=�6B   �� 5	  "    � ��$ Stretch=�6H   �� 5
  "    � ��$ Center=�6F   �� 5  "    � ��
 �   �6?   5     5     	  5     $ 
Chi tiết��6-   $	 100 6?   ! 5     �� 5     .R�5  "   �� -   5        $��
Chi tiết��5  )   #��[ 5  !   
" � Tag" 5  !   �� *Id+5  !   5     5     5     5     �� 5   
   # �� Orientation$# 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��1394,0,0,22q�6d   .+�5!     �� -   5        $ btnPreviousPage��5!     $��<��6.   #��[ 6=   $��50��6h   6s   �� 5"     -   5        $ ��Name$$ lblCurrentPage��5"     $��1��6,   #��[  68   $��Center=�6b   $��	10,0,10,0q�6}   �� 5#     -   5        $ btnNextPage��5#     $��>��6*   #��[ 69   $��50��6d   6o   5$     5&     5'     