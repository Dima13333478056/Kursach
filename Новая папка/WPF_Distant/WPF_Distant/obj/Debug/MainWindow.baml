   M S B A M L   `   `   `  ����F  BWPF_Distant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_DistantWPF_Distant  5   	       WPF_Distant.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_Distant     5   	     � WindowState$  	Maximized=�5   	   $
��1080��5	   	   $
��1920��5
   	    � Title$ 
MainWindow��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   � ���#404060$��60��6$   $��0��60   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      �� -   5        $��Профиль��5         HeaderLabelStyle#��[  6*   
 � Tag$ ProfilePage��6k   �� 5      -   5        $��
Уроки��5      #��[  6(   $ LessonsPage��6i   �� 5      -   5        $%��Домашние задания��5      #��[  63   $ HomeworkPage��6t   5      5      �� 5   
   -   5        $��MainContent��5   &   $��1��6   ���#303040$��Stretch=�6N   $��Stretch=�6l   5       5!      