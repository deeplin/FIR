   M S B A M L   `   `   `  ����>  :FIR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FIR.Views	FIR.Views  5          FIR.Views.ResultPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:FIR.Views     5      -   5        .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��查询结果��6   $��0��6   $��Center=�6,   ]� 5   
   $��1��6   ���	#FFFBFBF4.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      $��Bottom=�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 10 0 0 0q�63   �� 5       � ��$ 	15 0 15 0q�64   -   5        5      5      .+�5      �� -   5        $��buttonStart��5      $��启动查询��6X   {�6,   �� *
Disabled+ �� Mode$ TwoWay=�6X   �� 5      -   5        $��
buttonStop��5      $��停止查询��6V   {�6+   �� *	Enabled+$ TwoWay=�6V   5      �� 5       $��Bottom=�6   &   System.Windows.Controls.DataGrid  5"      -   5        $��DataGridWebSite��5"      $��5q�6.      AutoGenerateColumns .     
IsReadOnly . 	   CanUserAddRows	 .  
   Columns
 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6Q      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ��  �� Path$ Id�6\     5%      $ 网站��6)   $ 60 6W    .   65   �� $ SiteName�6b   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $ 时间��6-   $	 110 69    .     CellTemplate 5'      �� 5(      .R�5)   "   �� ��5*   &   �� 5+   *   $ PublishDate�62    �� StringFormat$ yyyy/MM/dd HH:mm��6E   5-   #   5.      50        51      $ 标题��6)   $	 160 6T    .   65   �� $ Title�   ElementStyle 52      �� 53      " ��6$   .�54   "   ��  � ��$
 Wrap=�6A   �� 55   "    � ��$
 auto��6;   56      58        59      $ 内容��6)   $ * 6V    .   65   �� $ Content� 5:      �� 5;      " ��6$   .�5<   "   ��  � ��$
 Wrap=�6A   �� 5=   "    � ��$
 auto��6;   5>      5@      5B      5C      �� 5E   
   $��2��6   .@�5F      �� -   5        $��labelStatus��5F      $�� ��6'   5G      5H      5I      