   M S B A M L   `   `   `  ���� H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProyectoFinal.Views.QueuesProyectoFinal.Views.Queues  2    ,ProyectoFinal.Views.Queues.UserQueueTaskView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:ProyectoFinal.Views.Queues     .��� .+�&   System.Windows.Controls.DataGrid      
IsReadOnly  .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ���� *Queue+ � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value �� 
TargetType��%V   '        �� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Título��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Title+  $
 Fecha Entrega��$ *  �� *CompletionDate+ �� StringFormat$ {0:dd-MM-yyyy}��  $

 Peso��$ *  �� *Weight+$ {0:F2}��4  .System.Windows.Controls.DataGridTemplateColumn  $
 	Prioridad��$	 120    CellTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� 
���   �$��1q�$��5q�$��20��$��20��$
��Left=� �� CornerRadius$ 10������ *
PriorityBg+�� $��5q�$��Center=����� *PriorityDescription+  $
 Estado��$	 120  �� .R��� $ 
Horizontal=�.+��� 
���   �$��1q�$��5q�$��20��$��20��$
��Left=�$ 10������ *
StatusBg+�� $��5q�$��Center=����� *StatusDescription+