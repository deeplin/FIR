   M S B A M L   `   `   `  ����>  :FIR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FIR.Views	FIR.Views  5          FIR.Views.SetupPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:FIR.Views     5      -   5          N� Title$  SystemConfig��5      .��5      � 
������� � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��查询设置��6   $��0��6   $��Center=�6,   ]� 5   
   $��1��6   ���	#FFFBFBF4.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $��Bottom=�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 10 0 0 0q�63   �� 5       � ��$ 	15 0 15 0q�64   -   5        5      5      .+�5      �� -   5        $��
buttonSave��5      $��保存查询��6+   5      �� 5      $��Bottom=�6   &   System.Windows.Controls.DataGrid  5       -   5        $��DataGridWebSite��5       $��5q�6.      AutoGenerateColumns .     CanUserAddRows .  	   Columns	 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn
   Header$
 网站ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6S      
IsReadOnly .    CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ��  �� Path$ Id�6p     5#      $
 网站名称��6)   $	 100 6Y    .  .   67   �� $ SiteName�6w     5$      $
 网站地址��6)   $	 250 6\    .  .   67   �� $ SiteAddress�6z     5%      $
 	关键字��6)   $ * 6W    .   66   �� $ Keyword�6a   5'      5(      �� 5*   
   $��2��6   .@�5+      �� -   5        $��labelStatus��5+      $�� ��6'   5,      5-      5.      