   M S B A M L   `   `   `  ����D  @Panuon.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Panuon.UI;assembly=Panuon.UI	Panuon.UI  5       	Sugar.WPF'   !JOJO.UserControls.UserControlView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      3pu*clr-namespace:Panuon.UI;assembly=Panuon.UI  5      'cmhttp://www.caliburnproject.org  5      
�������$��0,0,0,20q�5
       $��10,10,10,10q�63   .��5      � ���#ffffff.+�5      � $��0,0,0,0q�6   .+�5      &   System.Windows.Controls.DataGrid  $	��521��6   $	��Top=�6K   ��6(   �� *	ItemsList+    Columns  5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   -   �� *ID+5        5      $ NUMBER��5      $ * 5       5   -   �� *Number+5        5      $
 NAME��5      $ * 5       5   -   �� *Name+5      4  .System.Windows.Controls.DataGridTemplateColumn  5         HoverToShowCell   	CellStyle# [  61   $ OPERATE��5      $ * 5         CellTemplate 5      �� 5   "   .R�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5   *   �� ���#2191f1$��0,0,0,0q�5    -    � Cursor$
 Hand��5!   -     Caliburn.Micro.Message   Attach$< 6[Event MouseLeftButtonDown]=[Action Delete($this.Tag)]��5#   -   $��删除��6x   
	 � Tag	 5"   -   �� *ID+5#   x   5$   '   5%   #   5(      5*      �� 5+      -   5        
 ��Name$
 label��5+      $��	上一页��6'   $
��Left=�65   $��	0,526,0,0q�6P   $	��Top=�6c   �� 5,      -   5        $
 label1��5,      $��	下一页��6(   $
��Left=�66   $��
69,526,0,0q�6Q   $	��Top=�6e   �� 5-      -   5        $
 label2��5-      $��每页10条��6(   $
��Left=�68   $��120,526,0,0q�6S   $	��Top=�6h   �� 5.      -   5        $
 label3��5.      $��共93条��6(   $
��Left=�67   $��185,526,0,0q�6R   $	��Top=�6g   �� 5/      -   5        $
 label4��5/      $��转到��6(   $
��Left=�65   $��261,526,0,0q�6P   $	��Top=�6e   �� 50      -   5         ��Name$ textBox��50      $
��Left=�6+   $��23��6F   $��300,526,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $��7��6{   $	��Top=�6�   $��32��6�   $��Center=�6�   $��Center=�6�   �� 51      -   5        $
 label5��51      $	��页��6(   $
��Left=�64   $��337,526,0,0q�6O   $	��Top=�6d   52      53      54      