   M S B A M L   `   `   `  ���� H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProyectoFinal.Views.GraphsProyectoFinal.Views.Graphs  *    $ProyectoFinal.Views.Graphs.GraphView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:ProyectoFinal.Views.Graphs     .���   � 	Resources     EdgeLineStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value��%�   &	        �� " ��.���  � ��
 �������  � ��$ 2�� ��  �� *IsHighLighted+ True.a���  � ��
 � � ���  � ��$ 4�� � RowDefinitions �� $��50 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�$��Bottom=�.+��� $ Vertical=�$��Center=�.+��� $��
Ubicación���� $��25��$	��250��$	��0 3q����� *Name+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� $ 
Horizontal=�$��Bottom=�.+��� $��Agregar��$��5 0 0 0q�$��25��$
��20 0q����� *	AddNode+�� $��Buscar Ruta��$��5 0 0 0q�$��25��$
��20 0q����� *FindDistance+�� $��1��$��0 5 0 0q�$
��Auto=�$
��Auto=�.���� -    ��Name$ GraphCanvas�����#eeeeee.+��� ���� *Edges+���� .R��� ���� .R��� #��[  	 �� X1 �� *From.X+  OffsetConverter �� 	Converter# [ 	 �� Y1 �� *From.Y+# [ 	 �� X2 �� *To.X+# [ 	 �� Y2 �� *To.Y+# [ 
 � Tag ��  �� RelativeSource ��  �� AncestorType" � �� Path$ DataContext� � ContextMenu �� .@�m� $��Editar�� m� Command ��  ��  �� Mode$ FindAncestor=�" ��$* $PlacementTarget.Tag.GraphVm.EditEdge� m� CommandParameter �� m� $��Eliminar�� ��  �� $ FindAncestor=�" ��$, &PlacementTarget.Tag.GraphVm.DeleteEdge� �� �� ���� *Nodes+���� .R��� ���� " ��.���  �@��Left �� *X+��  �@��Top �� *Y+���� .R�� .+�A� -   $��40��$��40��
���   �$��2������ *Color+ ��  �� " �$ DataContext� � ToolTip �� ���� *Id+ �� .@�m� $��Agregar�� ��  �� $ FindAncestor=�" ��$) #PlacementTarget.Tag.GraphVm.AddEdge� �� m� $��Eliminar�� ��  �� $ FindAncestor=�" ��$, &PlacementTarget.Tag.GraphVm.DeleteNode� �� �� $��Center=�$��Center=�$
��Bold"�
����������� *Text+