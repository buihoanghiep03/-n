   M S B A M L   `   `   `  ����H  DDoAnQLThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DoAnQLThuVien.DataDoAnQLThuVien.Data  5      U QLiveCharts.Wpf, Version=0.9.8.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5           DoAnQLThuVien.Data.ThongKe   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:DoAnQLThuVien.Data     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5
      � ���	#FFF5F9FF  � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   ���	#FF2196F3 �� CornerRadius$ 5,5,0,0��69    �� Padding$ 10q�6P   ._�5      �� $&�� BIỂU ĐỒ THỐNG KÊ THU CHI��6   
�������$��20(�5      $��SemiBold"�5      $��Center=�5       5!      �� 5$      $��1��6   ���	#FFBBDEFB$��1q�6:   $ 0,0,5,5��6N   ._�5%      #  LiveCharts.Wpf.CartesianChart  -   5          Name$ ChartThuChi��5%   %   
�������$��5q�5(   !   &   LiveCharts.Wpf.Charts.Base.Chart   Series 5&   !   �� *RevenueSeriesCollection+   AxisX 5*        LiveCharts.Wpf.Axis     Title$ Tháng��6#      
Foreground �	#FF333333	   FontSize$	 12Q�5,   !   
   Labels
 5*   1   �� *Labels+5,   !      AxisY 5/        $ Doanh thu (VND)��6#    �	#FF333333$	 12Q�51   !   53      54      �� 57      $��2��6   ���	#FF2196F3$ 5,5,0,0��69   $ 10q�6P   $��0,10,0,0q�6]   ._�58      �� $,��&BIỂU ĐỒ THỐNG KÊ MƯỢN TRẢ��6   
�������$��20(�5:      $��SemiBold"�5;      $��Center=�5<      5=      �� 5@      $��3��6   ���	#FFBBDEFB$��1q�6:   $ 0,0,5,5��6N   ._�5A        -   5        $ ChartMuonSach��5A   %   
�������$��5q�5D   !    5B   !   �� *SeriesCollection+ 5F        $ Tháng��6#    �	#FF333333$	 12Q�5H   !   
 5F   1   �� *Labels+5H   !    5K        $ Số sách mượn��6#    �	#FF333333$	 12Q�5M   !   5O      5P      5Q      � 5T   
   $��1��6   $��10q�6    5U      �� 5V      $
��Auto �6    �� 5W      $
��Auto �6    �� 5X      $
��Auto �6    �� 5Y      $��* �6    .+�5]      �� $��0��6   
�������$ 5��65   ���	#FFBBDEFB$��1q�6^   $��0,0,0,10q�6r   ._�5^      ��  �� Orientation$ 
Horizontal=�6   $��15q�66   .+�5_      �� $��/Images/Icons/book.png��6   $��60��6<   $��60��6G   $��Center=�6S   �� 5`      $��15,0,0,0q�6!   $��Center=�63   .+�5a      �� $��TỔNG SỐ SÁCH��6$   ���	#FF2196F3$��16(�5c   $   $
��Bold"�5d   $   �� 5e      -   5         ��Name$ tongSachCount��5e   $   ���	#FF333333$��24(�5g   $   $
��Bold"�5h   $   $��0,5,0,0q�5i   $   5j      5k      5l      �� 5o      $��1��6   
�������$ 5��65   ���	#FFBBDEFB$��1q�6^   $��0,0,0,10q�6r   ._�5p      �� $ 
Horizontal=�6   $��15q�66   .+�5q      �� $��/Images/Icons/reader.png��6   $��60��6>   $��60��6I   $��Center=�6U   �� 5r      $��15,0,0,0q�6!   $��Center=�63   .+�5s      �� $ ��SỐ LƯỢNG ĐỘC GIẢ��6$   ���	#FF2196F3$��16(�5u   $   $
��Bold"�5v   $   �� 5w      -   5        $ docGiaCount��5w   $   ���	#FF333333$��24(�5y   $   $
��Bold"�5z   $   $��0,5,0,0q�5{   $   5|      5}      5~      �� 5�      $��2��6   
�������$ 5��65   ���	#FFBBDEFB$��1q�6^   $��0,0,0,10q�6r   ._�5�      �� $ 
Horizontal=�6   $��15q�66   .+�5�      �� $��/Images/Icons/people.png��6   $��60��6>   $��60��6I   $��Center=�6U   �� 5�      $��15,0,0,0q�6!   $��Center=�63   .+�5�      �� $��SỐ LƯỢNG NHÂN SỰ��6$   ���	#FF2196F3$��16(�5�   $   $
��Bold"�5�   $   �� 5�      -   5        $ nhanSuCount��5�   $   ���	#FF333333$��24(�5�   $   $
��Bold"�5�   $   $��0,5,0,0q�5�   $   5�      5�      5�      �� 5�      $��3��6   
�������$ 5��65   ���	#FFBBDEFB$��1q�6^   $��-10,10,10,-10q�6r   ._�5�      �� .+�5�      �� ���	#FF2196F3$ 5,5,0,0��64   $ 10q�6K   ._�5�      �� $��TÌNH TRẠNG SÁCH��6$   
�������$��16(�5�   $   $��SemiBold"�5�   $   $��Center=�5�   $   5�        LiveCharts.Wpf.PieChart  5�      -   5          Name$ 
MyPieChart��5�   #      LegendLocation$ Bottom=�5�   #   $��10, 70, 10, 10q�5�   #      InnerRadius$ 70Q�5�   #   ���	#FF333333$��12(�5�   #   $	��334��61    5�        LiveCharts.Wpf.PieSeries    LiveCharts.Wpf.Series   Title$ Mượn��6,      Values;  5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 5 69      
DataLabels$
 True��6D      Fill �	#FF2196F36V     5�      $ 	Có sẵn��6,   $ 8 6;   $
 True��6F    �	#FF4CAF506X     5�      $ 
Hư hỏng��6,   $ 2 6<   $
 True��6G    �	#FFF443366Y   5�      5�      5�      5�      5�      5�      