   M S B A M L   `   `   `  ����>  :FIR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FIR.Views	FIR.Views  5   	       FIR.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:FIR.Views     5   	   -   5          � Title$O  I金融信息收集者(Financial Information Retrieval) V1.2 作者:林凌��5   	   $	��600��6E   $
��1000��6R   ���	#FFF0F9D8 � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��5q�6   ���	#FFF0F9D8
����  � �� StrokeDashArray$ 3R�5      9� 5   
    9� ExpandDirection$ Right=�6   $��10q�5       9� 
IsExpanded . .��5      �� .��5      �� 
������� � 	Resources 5       �� 
TargetType �� Property	 �� Value��%�  '��       '9� �     �� 5      " ��6    .�5      ��  � ��$	 	10 5 10 0q�67   �� 5       � ��$	 	10 0 10 0q�68   �� 5       � ��	 6<   Z� �� 5       � ��
	 ��  �6;   �� 5       � ��
	 ���� 6;   -   5        5      �� 5      " 9�6    .�5       ��  � ��
	 �����6;   �� 5!       �@9�
IsExpanded	 . 6;   5"      5#      .+�5$      9� $��查询��6   .��5%      �� .+�5&      �� -   5        
 ��Name$
 ButtonSystemSetting��5&   %   $��系统设置��6B   
 � Tag$# /Views/SystemSettingPage.xaml��6Q   �� 5'      -   5        $
 ButtonSearchSetting��5'   %   $��查询设置��6B   $ /Views/SetupPage.xaml��6Q   �� 5(      -   5        $
 ButtonSearchResult��5(   %   $��查询结果��6A   $ /Views/ResultPage.xaml��6P   5)      5*      5+      5,      5-       � 5.   
   -   5        $��detailFrame��5.      $��1��6#   $��5q�63     � NavigationUIVisibility$ Hidden=�5/      $��1q�50      
����  �6$   51      52      