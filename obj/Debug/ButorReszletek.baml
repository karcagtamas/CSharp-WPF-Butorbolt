   M S B A M L   `   `   `  ����O  K2019-01-03_Butorbolt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:_2019_01_03_Butorbolt_2019_01_03_Butorbolt  5   	   *    $_2019_01_03_Butorbolt.ButorReszletek   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:_2019_01_03_Butorbolt     5   	     � Title$  Butorok Adatai��5   	   $	��400��6    $	��600��6-   $��16(�69   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��Megnevezés:��6   $��Center=�63   $��Right=�6N   $��0 0 5 0q�6j   �� 5   
   $��1��6   $��
Alapanyag:��6   $��Center=�62   $��Right=�6M   $��0 0 5 0q�6i   �� 5   
   $��2��6   $��Szállítás:��6   $��Center=�62   $��Right=�6M   $��0 0 5 0q�6i   �� 5   
   $��3��6   $
��Ár:��6   $��Center=�6+   $��Right=�6F   $��0 0 5 0q�6b   �� 5   
   $��4��6   $��Szín:��6   $��Center=�6-   $��Right=�6H   $��0 0 5 0q�6d   �� 5   
   -   5         ��Name$ txtMegnevezes��5      $��1��6)   $��0��69   $��Center=�6F   $
��Left=�6a   $��25��6|   $	��200��6�   $��5 0 0 0q�6�   �� 5   
   -   5         ��Name$ cboAlapanyag��5      $��1��6)   $��1��69   $��Center=�6F   $
��Left=�6a   $��25��6|   $	��200��6�   $��5 0 0 0q�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpSzallitas��5      $��1��6*   $��2��6:   $��Center=�6G   $
��Left=�6b   $��25��6}   $	��200��6�   $��5 0 0 0q�6�   �� 5    
   -   5        $ txtAr��5       $��1��6!   $��3��61   $��Center=�6>   $
��Left=�6Y   $��25��6t   $	��200��6�   $��5 0 0 0q�6�   �� 5!   
   -   5        $ txtSzin��5!      $��1��6#   $��4��63   $��Center=�6@   $
��Left=�6[   $��25��6v   $	��200��6�   $��5 0 0 0q�6�   �� 5"   
   $��5��6   $��2��6"   $��Center=�66   $��Center=�6Q    �� Orientation$ 
Horizontal=�6n   .+�5#      �� -   5         ��Name$ btnOk��5#      $��OK��6$   $	��120��61   $��25��6=   $��	20 0 20 0q�6I   6\   �� 5$      -   5        $ 	btnMegsem��5$      $��Mégsem��6(   $	��120��69   $��25��6E   $��	20 0 20 0q�6Q   6d   5%      5'      5(      