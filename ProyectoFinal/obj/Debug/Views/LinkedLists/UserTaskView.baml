   M S B A M L   `   `   `  ����H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProyectoFinal.Views.LinkedListsProyectoFinal.Views.LinkedLists  5      2    ,ProyectoFinal.Views.LinkedLists.UserTaskView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:ProyectoFinal.Views.LinkedLists     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      .��5      �   � RowDefinitions  5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   $
��Left=�6B   $��Bottom=�6]   .+�5      �� 
������ $��0q�6K    � ToolTip$ Deshacer��6_   ��6   �� *Undo+.��5      !  FontAwesome.WPF.FontAwesome     Icon$
 Undo=�6%   $��25(�61   5      �� 5      
������ $��0q�6K   $ Rehacer��6_   $	��5 0q�6q   ��6   �� *Redo+.��5        $ Repeat=�6%   $��25(�63   5      5      �� 5      $��1��6   $ 
Horizontal=�6)   $��Right=�6B   $��Bottom=�6^   .+�5      �� 
������ $��0q�6R   $	��5 0q�6f   $ Agregar��6t   ��6   �� *OpenNewTask+.��5         $ 
PlusCircle=�6%   
��� � �$��25(�6J   5!      �� 5"      
������ $��0q�6P   $	��5 0q�6d   $��5 0 0 0q�6r   $ Ver Cola de prioridad��6�   ��6   �� *	OpenQueue+.��5#        $
 List=�6%   $��25(�61   5$      �� 5%      
������ $��0q�6N   $	��5 0q�6b   $��5 0 0 0q�6p   $ Ver Arbol Binario��6�   ��6   �� *	OpenBST+.��5&        $ Sitemap=�6%   $��25(�64   5'      5(      5)      &   System.Windows.Controls.DataGrid  5+   
   $��1��6   $��0 5 0 0q�5-         
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  ��5,      �� *UserTasks.LinkList+	 � 	Resources	 52      *  $System.Windows.Controls.DataGridCell
 �� 
TargetType �� Property �� Value �� 
TargetType��%�   '        �� 53      "
  6   .�54      ��  � �� 55      �� 56      "  6.   .R�57   "   � #��z��6'   .+�58   &   �� $��Center=�67   59   #   5:      5<      5=      5>         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Título��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Title+6O     5A      $ Fecha Entrega��6%   $ * 6    6<   �� *CompletionDate+ �� StringFormat$ {0:dd-MM-yyyy}��6   4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ 	Prioridad��6)   $	 120 6<      CellTemplate 5C      �� 5D      .R�5E      �� $ 
Horizontal=�6)   .+�5F   "   �� 
���   �$��1q�6_   $��5q�6s   $��20��6~   $��20��6�   $
��Left=�6�    �� CornerRadius$ 10��6�   ��6)   �� *
PriorityBg+6�   �� 5G   "   $��5q�6P   $��Center=�6[   ��6(   �� *PriorityDescription+6[   5H      5I      5K        5L      $ Estado��6)   $	 120 69    5M      �� 5N      .R�5O      �� $ 
Horizontal=�6)   .+�5P   "   �� 
���   �$��1q�6]   $��5q�6q   $��20��6|   $��20��6�   $
��Left=�6�   $ 10��6�   ��6)   �� *
StatusBg+6�   �� 5Q   "   $��5q�6N   $��Center=�6Y   ��6(   �� *StatusDescription+6Y   5R      5S      5U        5W      $ 80 6)    5X      �� 5Y      .R�5Z      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5[   "   �� 
������ $��0q�5^   )   $��25��5_   )   ��5[   )   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType"   �� Path$ DataContext.OpenEditTask���5\   )   ��  5`   &   �� 5a   *   $��Editar��60   .��5c   &     $ Pencil=�65   $��20(�6C   
��� � �6Q   5d   #   �� 5e   "   $��25��5g   )   
������ $��0q�5i   )   $��5 0 0 0q�5j   )   ��5e   )   ��  �� *FindAncestor+"  $ DataContext.RemoveTask���5f   )   ��  5k   &   �� 5l   *   $��Borrar��60   .��5n   &     $ Trash=�65   $��20(�6B   
���  ��6P   5o   #   5p      5q      5s      5v      5w      5x      