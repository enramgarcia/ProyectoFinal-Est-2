   M S B A M L   `   `   `  ���� H  DProyectoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProyectoFinal.Views.LinkedListsProyectoFinal.Views.LinkedLists  7 clr-namespace:ProyectoFinal.MiscProyectoFinal.Misc  6    0ProyectoFinal.Views.LinkedLists.UserTaskFormView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:ProyectoFinal.Views.LinkedLists     1misc clr-namespace:ProyectoFinal.Misc     .��� $��5q�.+��� .+���   �� Orientation$  
Horizontal=�.+��� .+��� $��Título���� $	��200������ *Title+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��20 0 0 0q�.+��� $��Fecha Entrega��(  "System.Windows.Controls.DatePicker  $	��200��   SelectedDate �� *CompletionDate+$ TwoWay=�$ PropertyChanged=��� $  
Horizontal=�.+��� .+��� $��	Prioridad����  �� DisplayMemberPath$
 Text�� �� SelectedValuePath$ Value��$	��200������ *
Priorities+$ PropertyChanged=� �� SelectedValue �� *
Priority+�� $��20 0 0 0q�.+��� $��Estado���� $
 Text��$ Value��$	��200������ *
StatusList+$ PropertyChanged=� �� *Status+�� $  
Horizontal=�.+��� .+��� $��Descripción���� $	��420��$	��200�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . ���� *Description+$ TwoWay=�$ PropertyChanged=��� $  
Horizontal=�$��Right=�$��0 20 5 0q�.+��� $��Guardar��$��30��$
��10 0q����� *Save+