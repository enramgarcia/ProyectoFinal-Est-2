   M S B A M L   `   `   `  ����H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProyectoFinal.Views.QueuesProyectoFinal.Views.Queues  5      2    ,ProyectoFinal.Views.Queues.UserQueueTaskView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ProyectoFinal.Views.Queues     5      .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid      
IsReadOnly  .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ��6   �� *Queue+ � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� 
TargetType��%�   '        �� 5      "  6   .�5      ��  � �� 5      �� 5      "  6.   .R�5   "   � #��z��6'   .+�5   &   �� $��Center=�67   5   #   5      5      5      5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Título��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Title+6O     5      $
 Fecha Entrega��6%   $ * 6    6<   �� *CompletionDate+ �� StringFormat$ {0:dd-MM-yyyy}��6     5       $

 Peso��6%   $ * 6e    63   �� *Weight+$ {0:F2}��6e   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $
 	Prioridad��6)   $	 120 6<      CellTemplate 5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6)   .+�5%   "   �� 
���   �$��1q�6_   $��5q�6s   $��20��6~   $��20��6�   $
��Left=�6�    �� CornerRadius$ 10��6�   ��6)   �� *
PriorityBg+6�   �� 5&   "   $��5q�6P   $��Center=�6[   ��6(   �� *PriorityDescription+6[   5'      5(      5*        5+      $
 Estado��6)   $	 120 69    5,      �� 5-      .R�5.      �� $ 
Horizontal=�6)   .+�5/   "   �� 
���   �$��1q�6]   $��5q�6q   $��20��6|   $��20��6�   $
��Left=�6�   $ 10��6�   ��6)   �� *
StatusBg+6�   �� 50   "   $��5q�6N   $��Center=�6Y   ��6(   �� *StatusDescription+6Y   51      52      54      56      57      58      