   M S B A M L   `   `   `  ����C  ?Dobispro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DobisproDobispro  5          Dobispro.ogrenciNerede   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6W   "localclr-namespace:Dobispro  5      
�������  � 	Resources  5         DataGridStyle1 �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  ColumnHeaderStyle1 �� Value  	RowStyle1  
cellortala  	RowStyle2=  7System.Windows.Controls.Primitives.DataGridColumnHeader)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value:  4System.Windows.Controls.Primitives.DataGridRowHeader*  $System.Windows.Controls.DataGridCell # Body_Content_DataGrid_Centering �� 
TargetType��%  &	        &	 �     &	 W    &	 �    &	 �    &	     �� 5   
   "  6'   .�5      ��  �@ ColumnHeaderStyle# �  62   �� 5       �@ RowStyle# �  6*   �� 5       �@ 	CellStyle# �  6+   �� 5       �@ RowHeaderStyle# �  60   5      �� 5   
   "  6+   .�5      ��  � ��$ 30��6'   �� 5       � ��
 ��ح�6+   �� 5       � ��
 ��  �6+   �� 5       � ��$ Center=�6<   �� 5       � ��$ Center=�69   �� 5       � ��$ 18(�6)   �� 5       � ��
 ��ح�6,   �� 5       � ��$ 2q�60   �� 5       � ��$
 Bold"�6,   5      �� 5    
   "  6"   .�5"      ��  � ��
 �   �6+   �� 5#       � ��$ 25(�6)   �� 5$       � �� �	#EEEEEEEE6,   �� 5%       � ��$ 2q�60    5&      P� 5'       �@J�IsMouseOver . . �5)      ��  � �� �	#FFB7212164   5*      5,      �� 5-   
   "  6"   .�5.      ��  � ��
 �  ��6,   5/      �� 50   
   "  6#   .�51      ��  � ��$ Center=�6<   54      �� 55   
   "  56      .�57      ��  � �� 58      �� 59      "  6&   .R�5:      � #��z��6   .+�5;      �� $��Center=�6/   5<      5=      5?      5@      5A      .��5C      � 
�������.+�5D   
   '  !DevExpress.Xpf.LayoutControl.Tile  -   5          Name$
 geri��5D      $	��100��6"   $	��100��6.   $��	10,10,0,0q�6<   $
��Left=�6O   $	��Top=�6j   ��5E      �� 5F      	 �� ImageSource$	 images/back.png��6   5H      %  DevExpress.Xpf.Editors.TextEdit  5I   
   -   5        
  Name$
 txtarama��5I      $��5,5,5,5q�6)   $��
128,23,0,0q�6<   )  #DevExpress.Xpf.Editors.TextEditBase   TextWrapping$
 Wrap=�6P   $	��502��6d   $��80��6p   $��36(�6}   %	  DevExpress.Xpf.Editors.BaseEdit 	  NullText$ İsim, Okul No, T.C NO��6�   $	��Top=�6�   $��Center=�6�   $
��Left=�6  6.    5J   
   -   5        $ arama��5J         Size$ Small=�6#   $��18(�60   $��
635,23,0,0q�6>       HorizontalHeaderAlignment$ Stretch=�6R      VerticalHeaderAlignment$ Bottom=�6v   $
��Left=�6�   $	��Top=�6�   $��80��6�   $��86��6�   ��6�   Z� ,
  &DevExpress.Xpf.Core.ContentControlBase 
  Content. 5K      �� $��images/arama.png��6   $��75��6.   $��75��69   5L      �� 5N   
   -   5         ��Name$ lblAdi��5N      $��İsim:��6    $��
10,380,0,0q�60   $��24(�6D   $
��Left=�6R   $	��Top=�6m   �� 5O   
   -   5        $ 	lblokulNo��5O      $��Okul No:��6#   $��
10,514,0,0q�66   $��24(�6J   $
��Left=�6X   $	��Top=�6s   �� 5P   
   -   5        $ lblsinif��5P      $��Sınıf:��6"   $��
10,445,0,0q�63   $��24(�6G   $
��Left=�6U   $	��Top=�6p   �� 5Q   
   -   5         ��Name$ 	imgKimlik��5Q      $��
10,136,0,0q�6#   $
��Fill=�67   $	��229��6F   $	��212��6R   $��images/kim.png��6_   $
��Left=�6w   $	��Top=�6�     5S   
   -   5          Name$ dataGridView1��5S      $��272,136,0,58q�6*   $	��370��6@      FrozenColumnCount$ 1��6~      SelectionMode$ Single=�6�      CanUserResizeColumns .     
IsReadOnly .    CanUserReorderColumns .     CanUserAddRows .  ���	#FFE2E2E2#���   6l     RowBackground
 �����   EnableRowVirtualization .     	CellStyle# [ 6�  $��Center=�6  $��Center=�6*     AlternatingRowBackground �	#FF938E8E   GridLinesVisibility$
 None=�6s  $
��Left=�6�     HorizontalGridLinesBrush 6�   Z�     VerticalGridLinesBrush  6�   Z� 6�  �� 5T   
   -	   5        $ 
bolgeResim��5T      $��650,136,0,58q�6$   $
��Fill=�6;   $��images/bos.jpg��6J   $	��370��6b   $
��Left=�6n   �� 5V   
   -
   5        $ lblbilgi��5V      $��Bilgi :��6"   $��0,0,0,20q�64   $��24(�6F   $
��Bold"�6T   ���	#FF1E7BD8$
��Left=�6}   $��Bottom=�6�      Dobispro.Bildirim  5W   
   -   5        !  Name$! 	bildirim1��5W   *   $��0,3,4,0q�6   $	��Top=�6=   " J� Opacity$" 0Q�6U   $	��100��6a   $��Right=�6n   $	��290��6�   
���   �6�   5X      5Y      