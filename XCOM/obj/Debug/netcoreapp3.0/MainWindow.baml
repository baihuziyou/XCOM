   M S B A M L   `   `   `  ����?  ;XCOM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XCOMXCOM  5   	       XCOM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:XCOM     5   	   -   5          �Name$
  XCOM��5   	    � Title$ 串口调试��5
   	   $	��700��6   $	��900��6#    � SizeToContent$ Manual=�6/    � Topmost$
 True��6G    � 
ResizeMode$ CanResizeWithGrip=�6V   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��49* �6   6.   �� 5      $
��311* �6   �� 5      $	��180 �6   6-    � RowDefinitions 5   
   �� 5      6   �� 5      $	��160 �6   6+   �� 5      $��30 �6   6*   .+�5   
   �� -   5        $��Button_Send��5   .   $��1��6   $��2��6   $	��120��6A   $��30��6M   $��-40 -30 0 0q�6Y   $��16(�6n   $��发送��6|   6�   �� 5   
   -   5        $��1��5      $��2��6   $��16(�6.   $	��120��6<   $��30��6H   $��-40 100 0 0q�6T   $��清空发送��6i   6x   �� 5!   
   $��1��6   $��0��6"   $��2��62   .@�5"      �� $��单条发送��6   $��16(�6$   .��5#      �� -   5        $��TextBox_SendData��5#   #   $��1��6   6=   5$      �� 5%      $��帮助文档��6   $��16(�6$   .��5&      �� $)��#有问题请联系1031512314@qq.com��6    �� 
IsReadOnly$
 True��69   6M   5'      5(      �� 5,   
   -   5        $ ��ScrollViewer_DispalyWindow��5,   5   $��0��6   $��0��6%   
���   �$��16(�6j   
���2�2�$��2,2,2,2q�6�   $��2��6�   6�   � 55   
   $��0��6   $��2��6   $��0,0,0,30q�6,   $��2��6>    56      �� 57      $��80 �6#   61   �� 58      6%    5;      �� 5<      $��50 �6    6.   �� 5=      $��50 �6    6.   �� 5>      $��50 �6    6.   �� 5?      $��50 �6    6.   �� 5@      $��50 �6    6.   �� 5A      $��50 �6    6.   �� 5B      $��45 �6    6.   �� 5C      $��45 �6    6.   �� 5D      $��45 �6    6.   �� 5E      $��45 �6    6.   .+�5K      �� $��0��6   $��串口选择:��6$   $
��Left=�64   $��Center=�6P   $��16(�6k   �� 5L      $��1��6   $��0��6!   $��
波特率:��61   $
��Left=�6@   $��Center=�6\   $��16(�6w   6�   �� 5M      $��2��6   $��0��6!   $��
停止位:��61   $
��Left=�6@   $��Center=�6\   $��16(�6w   6�   �� 5N      $��3��6   $��0��6!   $��
数据位:��61   $
��Left=�6@   $��Center=�6\   $��16(�6w   6�   �� 5O      $��4��6   $��0��6!   $��奇偶校验:��61   $
��Left=�6A   $��Center=�6]   $��16(�6x   6�   �� 5P      $��5��6   $��0��6!   $��串口操作:��61   $
��Left=�6A   $��Center=�6]   $��16(�6x   6�   �� 5Q      -   5        $��Button_ClearData��5Q   F   $��6��6   $��2��6"   $��0��66   $��清  除  数  据��6^   $
��Left=�6s   $��Center=�6�   $��6,3,0,0q�6�   $	��170��6�   $��16(�6�   6�   �� 5R      -   5        $��ChcekBox_WhiteBlack��5R   I   $��7��6   $��2��6%   $��0��69   $��白底黑字��6d   $
��Left=�6s   $	��Top=�6�   $��16(�6�   $��	10,26,0,0q�6�   �� 5S      -   5        $��CheckBox_ChangeDispay��5S   H   $��9��6   $��2��6$   $��0��68   $��16进制显示��6e   $
��Left=�6v   $	��Top=�6�   $��16(�6�   $��10,7,0,0q�6�   6�   �� 5U      -	   5        $��ComBox_XCOMChioce��5U   4   $��0��6   $��1��6$   $��85��6M   $��25��6X   $��16(�6d   6�   �� 5W      -
   5        $��ComBox_BoadRate��5W   F   $��1��6    �� SelectedIndex$ 3��6$   $��1��66   $��85��6^   $��25��6i   $��16(�6u   .@�5X      �� $
��1200��6   60   �� 5Y      $
��2400��6   60   �� 5Z      $
��4800��6   60   �� 5[      $
��9600��6   60   �� 5\      $��14400��6   61   �� 5]      $��19200��6   61   �� 5^      $��38400��6   61   �� 5_      $��43000��6   61   �� 5`      $��57600��6   61   �� 5a      $��76800��6   61   �� 5b      $��115200��6   62   �� 5c      $��128000��6   62   �� 5d      $��230400��6   62   �� 5e      $��256000��6   62   �� 5f      $��460800��6   62   5g      �� 5i      -   5        $��ComBox_StopBits��5i   F   $��2��6   $��1��6$   $ 0��64   $��85��6^   $��25��6i   $��16(�6u   .@�5j      �� $��1��6   6-   �� 5k      $	��1.5��6   6/   �� 5l      $��2��6   6-   5m      �� 5o      -   5        $��ComBox_DataBits��5o   F   $��3��6   $��1��6$   $ 0��64   $��85��6^   $��25��6i   $��16(�6u   .@�5p      �� $��8��6   6-   �� 5q      $��7��6   6-   �� 5r      $��6��6   6-   �� 5s      $��5��6   6-   5t      �� 5v      -   5        $��ComBox_Parity��5v   F   $��4��6   $��1��6$   $ 0��64   $��85��6\   $��25��6g   $��16(�6s   .@�5w      �� $	��无��6   6-   �� 5x      $��	奇校验��6   6/   �� 5y      $��	偶校验��6   6/   5z      �� 5|      -   5        $��Button_OpenXCOM��5|   3   $��5��6   $��1��6#   $��85��6J   $��25��6U   $��打开串口��6a   $��16(�6q   6�   5~      � 5�   
   $��3��6   $��3��6    5�      �� 5�      $��30 �6#   60   �� 5�      $	��230 �6#   61   �� 5�      6%   .+�5�      �� -   5        
���   �$��1q�5�   C   .��5�      �� $��F:\c#\XCOM\XCOM\close.jpg��6   6=   5�      �� 5�      
���   �$��1��6(   $+��%制作:李叙兵（参考xcom2制作)��68   $��1q�6T   $
��Left=�6h   $��16(�6�   6�   �� 5�      
���   �$��2��6(   $	��639��68   $t��n源码见：                                                                                                  ��6D   $��1q�5�   d   $
��Left=�6x   $��16(�6�   6�   5�      5�      5�      