   M S B A M L   `   `   `  ���� D  @BlackRose, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BlackRose	BlackRose  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity     BlackRose.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:BlackRose     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � Title$  
Black Rose��$	��600��$	��450�� � 
ResizeMode$ CanMinimize=� � ShowInTaskbar .  � Topmost .  � WindowStartupLocation$ CenterScreen=� � Icon$ Image/play.png��   WindowBackground#���    � 	Resources #  BlackRose.PathToNameConverter  pathConverter  BlackRose.TrackConverter  trackConverter  BlackRose.ConvertPosition  positionConverter!  BlackRose.DurationConverter  durationConverter  StyleForFontSize �� Property �� Value	 �� ElementName
 �� Path��%�   &	       &	      &	 
     &	      &	              �� .���  � �� �� $	 SliderForFontSize��$
 Value�.���  � RowDefinitions �� $��30 ��� $	��100 ��� $��* �.+�o� $��0��  	MenuColor#���  .@�m� $��Файл��.@�m� $��Открыть файл��  MenuItemColor#���   m� Command �� *
AddTrack+m� $��Открыть папку��#���   �� *AddDirectory+m� $��
Выход��#���   �� *Exit+m� $��Настройки��.@�m� $��Выбор Темы��#���  .@��� .+��� $��	15 15 0 0q�
���   �$
��Left=�$9��3Выберите тему для программы���� -    ��Name$ StyleBox��$��
15 10 0 20q�m� $��Размер шрифта��#���  .@��� .+��� $��	15 15 0 0q�
���   �$
��Left=�$0��*Выберите размер шрифта���� -    ��Name$ SliderForFontSize��$��
15 10 0 15q� � Minimum$ 12Q� � Maximum$ 18Q� � Value$ 12Q� � ToolTip$ Размер шрифта�� �� TickFrequency$ 1Q� �� IsSelectionRangeEnabled .  �� TickPlacement$ TopLeft=�� $��1�� �� $
��1.2* ��� $��* ��� $��* � � ColumnDefinitions �� $��10 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��10 �.+��� $��1��$��0��$
��Stop�����	#FF8E8F9F���� *	StopTrack+�� $��2��$��0��$��Pause�����	#FF8E8F9F���� *
PauseTrack+�� $��3��$��0��$��>�����	#FF8E8F9F���� *ContinueTrack+�� $��4��$��0��$��►►�����	#FF8E8F9F���� *	Forward+�� $��5��$��0��$��◄◄�����	#FF8E8F9F���� *Back+�� -   $ 	sliderPos��$��1��$��1��$��3��$ 0Q� .  �� SelectionStart$ 0Q�$��	10 10 0 0q�$3 -Позиция воспроизведения�� �� *
Position+ �� *DurationCurrentTrack+ �� SelectionEnd �� *
Position+�� -   $ 	sliderVol��$��1��$��4��$��2��$ 0Q�$ 1Q� . $ 0Q�$ Громкость��$��	10 10 0 0q� �� *Volume+ �� Mode$ TwoWay=� �� *Volume+� $��2��.+��� -   $��Tracks��$��
15 10 15 0q� J� 	AllowDrop . ���� *	Records+ �� SelectedItem �� *SelectedRecord+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *
StartTrack+    CommandParameter  �� *SelectedRecord+���� .R��� ! �� Orientation$! 
Horizontal=�.+��� $��15��$��15��$��Image/note.jpg���� $��  · ��#��[ �� #��[ ���� *
Track.Name+" �� 	Converter#" [ # � ContextMenu# �� .@�m� $��Открыть файл�� �� *
AddTrack+m� $��Открыть папку�� �� *AddDirectory+m� $��Удалить�� �� *Delete+