   M S B A M L   `   `   `  ����   DoAnQLThuVien     DoAnQLThuVien.Data.TraSach   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Trả Sách�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True��$
��1000��$	��800�� � 
ResizeMode$ 	CanResize=� � 	Resources 3  -System.Windows.Media.Effects.DropShadowEffect   ShadowEffect   
BlurRadius   ShadowDepth   Opacity	   Color  PrimaryButton
 �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value  SecondaryButton  FormTextBox ��Name ��Name  FormComboBox  	FormLabel  ModernDataGrid&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell��%;  &	        &	 0     &	 �    &	 z    &	 �    &	 �    &	 ?      $ 20Q�$ 5Q�$	 0.2Q�$	 	#FF2196F3���� "
 ��.���  � �� �#2196F3��  � ��
 �������  � ��$ 0q���  � ��$ SemiBold"���  �@�Cursor$
 Hand����  � ��$ 36����  � ��$	 120����  � �� �� " ��.R��� #��z��$ 4��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#1976D2P�  � ��$
 True��. ���  � �� �#0D47A1�� "
 ��.���  � ��
 �������  � �� �#2196F3��  � �� �#2196F3��  � ��$ 1q���  � ��$ SemiBold"���  �@�Cursor$
 Hand����  � ��$ 36����  � ��$	 100����  � �� �� " ��.R��� #��z��#��z��#��z��$ 4��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FDP�  � ��$
 True��. ���  � �� �#BBDEFB�� "
 ��.���  � ��
 �������  � �� �#B0BEC5��  � ��$ 1q���  � �� �#263238��  � ��$ 14(���  � ��$ 32����  � ��$ 5q���  � ��$ 0,0,0,10q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 4��._��� $ PART_ContentHost�� P�  �@J�	IsFocused$
 True��. ���  � �� �#2196F3�� "
 ��.���  � ��
 �������  � �� �#B0BEC5��  � ��$ 1q���  � �� �#263238��  � ��$ 14(���  � ��$ 32����  � ��$ 0,0,0,10q���  � ��$ 5q��� "
 ��.���  � �� �#2196F3��  � ��$ SemiBold"���  � ��$ 0,0,0,5q���  � ��$ 14(��� "
  .���  � ��
 �������  � �� �#263238��  � �� �#B0BEC5��  � ��$ 1q���  �@ RowBackground
 �������   �@ AlternatingRowBackground �#F5F5F5��  �@ GridLinesVisibility$
 None=���  �@ HeadersVisibility$ Column=���  �@ AutoGenerateColumns$ False����  �@ CanUserAddRows$ False����  �@ CanUserDeleteRows$ False����  �@ CanUserResizeRows$ False����  �@ CanUserResizeColumns$
 True����  �@ CanUserSortColumns$
 True����  �@ ColumnHeaderHeight$ 35Q���  �@ 	RowHeight$ 30Q���  � ��$ 0,0,0,15q���  � ��$ 13(���  � ��$	 Top=���  � ��$ Stretch=���  �@ ColumnHeaderStyle �� "
  .���  � �� �#2196F3��  � ��
 �������  � ��$ SemiBold"���  � ��$ Center=���  � ��$ Center=���  � ��$
 10,0q���  �@ 	CellStyle �� "
  .���  � �� �#263238��  � ��$ 5q���  � �� �� "  .R��� #��z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@ 
IsSelected$
 True��. ���  � �� �#E3F2FD��  � �� �#263238.���� ���#2196F3$��1q�$ 10��
������� �� Padding$ 15q� J� Effect# [  ._�� .+�� $��40��$	��Top=� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��TRẢ SÁCH��$��18(�$
��Bold"����#2196F3$��Center=�$
��10,0q��� -    ��Name$ CloseButton��$��1��$	��✕��$��30��$��30�����#2196F3
������ $��0q�$��14(�$
��Bold"�� $��0,40,0,0q� �� $	��350 ��� $��* �.+��� $��0��$��10q�$ 15q����#F5F9FF$ 8��._��� .+��� $��THÔNG TIN MƯỢN��$
��Bold"�$��16(����#2196F3$��0,0,0,15q��� $��Mã phiếu mượn��#��[ �� -    ��Name$ maPhieuMuontxt��#��[ �� $��Mã độc giả��#��[ �� -   $ maDocGiatcb��#��[ �� $��Tên người mượn��#��[ �� -   $ TenNguoiMuontxt��#��[  �� 
IsReadOnly$
 True���� $��Ngày mượn��#��[ �� -   $ ngayMuonhdp��#��[ �� $��Ngày hẹn trả��#��[ �� -   $ ngayHenTradp��#��[ �� $��Ghi chú��#��[ �� -   $ 	ghiChutxt��$��80�� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�#��[ �� $��1��$��10q�$ 15q����#F5F9FF$ 8��._��� .+��� $��THÔNG TIN SÁCH��$
��Bold"�$��16(����#2196F3$��0,0,0,15q�  -     Name$ datagrid��#��[ $	��200��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã sách��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn    Binding  �� *IdSach+  $ 
Tên sách��$ *   �� *	TenSach+  $ Tình trạng sách��$	 150   �� *TinhTrangSach+� $��	0,15,0,15q�.+��� $	��220��$��0,0,15,0q�.+��� $��Ngày trả sách��#��[ �� -	   $ ngayTraThucThetxt��#��[ �� $	��220��$��0,0,15,0q�.+��� $#��Tình trạng bồi thường��#��[ �� -
   ! ��Name$! tinhTrangBoiThuongtxt��#��[ �� $	��220��.+��� $��Tiền bồi thường��#��[ �� -   $ tienBoiThuongtxt��#��[ �� $#��TÌNH TRẠNG SÁCH KHI TRẢ��$
��Bold"����#2196F3$��0,0,0,10q�� $��0,0,0,15q�.+��� $	��220��$��0,0,15,0q�.+��� $��Tình trạng sách 1��#��[ �� -   $! tinhTrangSach1cb��#��[ �� $	��220��$��0,0,15,0q�.+��� $��Tình trạng sách 2��#��[ �� -   $! tinhTrangSach2cb��#��[ �� $	��220��.+��� $��Tình trạng sách 3��#��[ �� -   $! tinhTrangSach3cb��#��[ �� " �� Orientation$" 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   # ��Name$# 
thongBaolb��$��14(�$
��Bold"�
���  ��$��Center=�$��0,0,20,0q��� -   $ dongbtn��$��Đóng��#��[ $��0,0,10,0q��� -   $ 
traSachbtn��$��Trả sách��#��[ 