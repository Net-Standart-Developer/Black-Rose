   M S B A M L   `   `   `  ����D  @BlackRose, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BlackRose	BlackRose  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       BlackRose.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BlackRose     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  
Black Rose��5	   	   $	��600��6   $	��450��6)    � 
ResizeMode$ CanMinimize=�65    � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=�5
   	    � Icon$ Image/play.png��6.      WindowBackground#���   6D    � 	Resources 5      #  BlackRose.PathToNameConverter  pathConverter  BlackRose.TrackConverter  trackConverter  BlackRose.ConvertPosition  positionConverter!  BlackRose.DurationConverter  durationConverter  StyleForFontSize �� Property �� Value �� ElementName	 �� Path��%�   &	       &	      &	 &     &	 9     &	 L       5   
   6$     5   
   6     5   
   6      5   
   6"   �� 5   
   .�5      ��  � �� 63   �� $ SliderForFontSize��$	 Value�5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $��30 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   o� $��0��6     	MenuColor#���  6   .@�5      m� $��Файл��6   .@�5      m� $��Открыть файл��6     MenuItemColor#���  6N    m� Command 61   �� *
AddTrack+6N   m� 5      $��Открыть папку��6   #���  6S    62   �� *AddDirectory+6S   m� 5      $��
Выход��6   #���  6C    6*   �� *Exit+6C   5       m� 5!      $��Настройки��6   .@�5"      m� $��Выбор Темы��6   #���  6/   .@�5#      �� .+�5$      �� $��	15 15 0 0q�6$   
���   �$
��Left=�6J   $9��3Выберите тему для программы��6e   �� 5%      -   5         ��Name$ StyleBox��5%   #   $��
15 10 0 20q�65   5&      5'      m� 5(      $��Размер шрифта��6   #���  62   .@�5)      �� .+�5*      �� $��	15 15 0 0q�6$   
���   �$
��Left=�6J   $0��*Выберите размер шрифта��6e   �� 5+      -   5         ��Name$ SliderForFontSize��5+   !   $��
15 10 0 15q�6<    � Minimum$ 12Q�6P    � Maximum$ 18Q�6]    � Value$ 12Q�6j    � ToolTip$ Размер шрифта��6u    �� TickFrequency$ 1Q�6�    �� IsSelectionRangeEnabled .  �� TickPlacement$ TopLeft=�5,   @   5-      5.      5/      50      � 51   
   $��1��6   
 52      �� 53      $
��1.2* �6    �� 54      $��* �6    �� 55      $��* �6     � ColumnDefinitions 57      �� 58      $��10 �6#   �� 59      $��* �6#   �� 5:      $��* �6#   �� 5;      $��* �6#   �� 5<      $��* �6#   �� 5=      $��* �6#   �� 5>      $��10 �6#   .+�5@      �� $��1��6   $��0��6%   $
��Stop��6P   ���	#FF8E8F9F��62   �� *	StopTrack+6_   �� 5A      -   5         ��Name$ Pause��5A      $��2��6$   $��0��64   $��Pause��6`   ���	#FF8E8F9F��6A   �� *
PauseTrack+6p   �� 5B      -   5        $ Continue��5B      $��3��6'   $��0��67   $��>��6f   ���	#FF8E8F9F��6D   �� *ContinueTrack+6r   �� 5C      $��4��6   $��0��6%   $��►►��6N   ���	#FF8E8F9F��62   �� *	Forward+6[   �� 5D      $��5��6   $��0��6%   $��◄◄��6K   ���	#FF8E8F9F��62   �� *Back+6Y   �� 5F      -   5        $ 	sliderPos��5F      $��1��6(   $��1��65   $��3��6E   $ 0Q�6t    .  �� SelectionStart$ 0Q�5H   4   $��	10 10 0 0q�6i   $3 -Позиция воспроизведения��6|    5F   Y   �� *
Position+ 5G      �� *DurationCurrentTrack+ �� SelectionEnd 5H   G   �� *
Position+5S      �� 5T      -   5        $ 	sliderVol��5T      $��1��6(   $��4��65   $��2��6E   $ 0Q�6Y   $ 1Q�6e    . $ 0Q�5U   4   $ Громкость��6g   $��	10 10 0 0q�6{    5T   q   �� *Volume+ �� Mode$ TwoWay=� 5U   G   �� *Volume+6{   5V      � 5W   
   $��2��6   .+�5X      �� -   5        $��Tracks��5X      $��
15 10 15 0q�6$    J� 	AllowDrop . ��69   �� *	Records+ �� SelectedItem 6Y   �� *SelectedRecord+.  (System.Windows.Interactivity.Interaction   Triggers 5Y      /  )System.Windows.Interactivity.EventTrigger  5Z         	EventName$ MouseDoubleClick��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5[      6  0System.Windows.Interactivity.InvokeCommandAction     Command 5\      �� *
StartTrack+    CommandParameter  5]      �� *SelectedRecord+5^      ��5`      �� 5a      .R�5b      �� ! �� Orientation$! 
Horizontal=�6%   .+�5c      �� $��15��6$   $��15��6/   $��Image/note.jpg��6;   �� 5d      $��  · ��6(   #��[ 64   �� 5e      #��[ 6n   ��6(   �� *
Track.Name+" �� 	Converter#" [ 6n   5f      5g      # � ContextMenu# 5i      �� 5j      .@�5k      m� $��Открыть файл��6#    69   �� *
AddTrack+m� 5l      $��Открыть папку��6#    6:   �� *AddDirectory+m� 5m      $��Удалить��6#    64   �� *Delete+5n      5p      5q      5r      5s      