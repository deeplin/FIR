   M S B A M L   `   `   `  ����>  :FIR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FIR.Views	FIR.Views  5      !    FIR.Views.SystemSettingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:FIR.Views     5      -   5        .��5
      � 
�������  � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��系统设置��6   $��0��6   $��Center=�6,   ]� 5   
   $��1��6   ���	#FFFBFBF4.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $��Bottom=�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 10 0 0 0q�63   �� 5       � ��$ 	15 0 15 0q�64   -   5        5      5      .+�5      �� -   5        $��buttonStart��5      $��保存设置��6,   5       �� 5!      $��Bottom=�6   �� 5#      $ 
Horizontal=�6   $��Center=�5$      $	��Top=�5%      .+�5&      �� $��线程刷新(秒):��6   $��Center=�6+   �� 5'      -   5        $��refreshRateTextBox��5'      $��80��60   $��Center=�6;   $��Center=�6V   $��Right=�6x   5(      �� 5)      $ 
Horizontal=�6   $��Center=�5*      $	��Top=�5+      .+�5,      �� $��新闻过时(小时):��6   $��Center=�6,   �� 5-      -   5        $��expireTimeTextBox��5-      $��80��63   $��Center=�6>   $��Center=�6Y   $��Right=�6{   5.      �� 5/      $ 
Horizontal=�6   $��Center=�50      $	��Top=�51      52      53      �� 55   
   $��2��6   .@�56      �� -   5        $��labelStatus��56      $�� ��6'   57      58      59      