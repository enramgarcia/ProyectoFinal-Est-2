   M S B A M L   `   `   `  ���� H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProyectoFinal.Views.LinkedListsProyectoFinal.Views.LinkedLists  2    ,ProyectoFinal.Views.LinkedLists.UserTaskView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:ProyectoFinal.Views.LinkedLists     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  .���   � RowDefinitions  �� $��30 ��� $��* �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$
��Left=�$��Bottom=�.+��� 
������ $��0q� � ToolTip$ Deshacer������ *Undo+.��!  FontAwesome.WPF.FontAwesome     Icon$
 Undo=�$��25(��� 
������ $��0q�$ Rehacer��$	��5 0q����� *Redo+.��  $ Repeat=�$��25(��� $��1��$ 
Horizontal=�$��Right=�$��Bottom=�.+��� 
������ $��0q�$	��5 0q�$ Agregar������ *OpenNewTask+.��  $ 
PlusCircle=�
��� � �$��25(��� 
������ $��0q�$	��5 0q�$��5 0 0 0q�$ Ver Cola de prioridad������ *	OpenQueue+.��  $
 List=�$��25(��� 
������ $��0q�$	��5 0q�$��5 0 0 0q�$ Ver Arbol Binario������ *	OpenBST+.��  $ Sitemap=�$��25(�&   System.Windows.Controls.DataGrid  $��1��$��0 5 0 0q�   
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ���� *UserTasks.LinkList+	 � 	Resources	 *  $System.Windows.Controls.DataGridCell
 �� 
TargetType �� Property �� Value �� 
TargetType��%V   '        �� "
  .���  � �� �� "  .R�� #��z��.+��� $��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Título��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Title+  $ Fecha Entrega��$ *  �� *CompletionDate+ �� StringFormat$ {0:dd-MM-yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  $ 	Prioridad��$	 120    CellTemplate �� .R��� $ 
Horizontal=�.+��� 
���   �$��1q�$��5q�$��20��$��20��$
��Left=� �� CornerRadius$ 10������ *
PriorityBg+�� $��5q�$��Center=����� *PriorityDescription+  $ Estado��$	 120  �� .R��� $ 
Horizontal=�.+��� 
���   �$��1q�$��5q�$��20��$��20��$
��Left=�$ 10������ *
StatusBg+�� $��5q�$��Center=����� *StatusDescription+  $ 80  �� .R��� $ 
Horizontal=�$��Center=�.+��� 
������ $��0q�$��25������  �� RelativeSource �� *FindAncestor+ �� AncestorType"   �� Path$ DataContext.OpenEditTask�����  �� $��Editar��.��  $ Pencil=�$��20(�
��� � ��� $��25��
������ $��0q�$��5 0 0 0q�����  �� *FindAncestor+"  $ DataContext.RemoveTask�����  �� $��Borrar��.��  $ Trash=�$��20(�
���  ��