   M S B A M L   `   `   `  ����C  ?Dobispro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DobisproDobispro  5          Dobispro.yazicigoruntule   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6W   f bDevExpress.Xpf.PdfViewer.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a=dxpdf1http://schemas.devexpress.com/winfx/2008/xaml/pdf  5      Ddxnav8http://schemas.devexpress.com/winfx/2008/xaml/navigation  6N   @dxp6http://schemas.devexpress.com/winfx/2008/xaml/printing  6�   "localclr-namespace:Dobispro  5      -   5        
�������.��5      � .+�5   
      Dobispro.Bildirim  -   5           Name$  	bildirim1��5   ,   $��	0,3,219,0q�6   $	��Top=�6?    J� Opacity$ 0Q�6W   $	��114��6c   $��Right=�6p   $	��290��6�   '  !DevExpress.Xpf.LayoutControl.Tile  5   
   -   5          Name$
 geri��5      $	��100��6"   $	��100��6.   $��	10,10,0,0q�6<   $
��Left=�6O   $	��Top=�6j   ��5      �� 5       �� ImageSource$ images/back.png��6   5      �� 5   
   -   5         ��Name$ lbladi��5      $��Dosya Adı :��6    $
��Left=�66   $��
194,42,0,0q�6Q   $	��Top=�6e   $��24(�6}   $
��Bold"�6�   ���	#FF2194D66�   �� 5   
   -   5        $ lbltip��5      $��Dosya Tür :��6    $
��Left=�66   $��
193,78,0,0q�6Q   $	��Top=�6e   $��24(�6}   $
��Bold"�6�   ���	#FF2194D66�   /  )DevExpress.Xpf.PdfViewer.PdfViewerControl  5   
   -   5          Name$ pdfGoruntule��5   !   $��10,120,10,0q�67   p lDevExpress.Xpf.DocumentViewer.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a9  3DevExpress.Xpf.DocumentViewer.DocumentViewerControl   CommandBarStyle$
 None=�6L      AllowCachePages . $��Center=�6z   6�     5   
   -   5        $ tilex��5      4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$ Yazdır��6#   $��	0,10,10,0q�63   ���	#FFB005CB 	   HorizontalHeaderAlignment$	 Stretch=�6p   $	��200��6�   $	��100��6�   $��Right=�6�   $	��Top=�6�   ,  &DevExpress.Xpf.Core.ContentControlBase
   Content.
 5      �� $��images/printing.png��6   $	��125��61   $	��100��6=   5      Z� 5   
   -   5         Z�Name$ 	docViewer��5      $
��Left=�6,   $��10,121,10,0q�6G   $	��Top=�6\    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5      -	   5           Command$ ApplicationCommands.Print��5   !   6E   5       �� 5!   
   -
   5        $ lblSayfaSayi��5!      $��Sayfa Sayısı :��6&   $
��Left=�6?   $��
193,10,0,0q�6Z   $	��Top=�6n   $��24(�6�   $
��Bold"�6�   ���	#FF2194D66�   5"      5#      