   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   
    Pacman10   Pacman10.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ^ePclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
     � 
ResizeMode$  CanMinimize=�5   	    � Title$ 
MainWindow��5
   	   $	��670��6   $	��836��6)   .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 5      �� *Load+   CommandParameter 5      ��  �� ElementName$ canvas��5        5   
   $ PreviewKeyDown��6   . 5         5      �� *	KeyDown+ 5      �� $ canvas��5      .��5      � ��5   
   
� 5      .��5      �  � Color$ 	#FF080529��6   	 � Offset$	 1Q�61   � 5      $ 	#FF0A0552��6   5      .+�5    
   �� $
��Left=�6   $��	10,10,0,0q�6,   $	��Top=�6?   $	��140��6W   $��40��6c   $��16(�6o   $��MV Boli)�6}   $
��Bold"�6�   $��Italic$�6�   $��NewGame��6�   ��6�   �� *OpenNewGame+.��6�   
New game6�   �� 5!   
   $
��Left=�6   $��
196,10,0,0q�6,   $	��Top=�6@   $	��140��6X   $��40��6d   $��16(�6p   $��MV Boli)�6~   $
��Bold"�6�   $��Italic$�6�   $��Leaderboard��6�   ��6�   �� *OpenLeaderboard+.��6�   Leaderboard6  �� 5"   
   -   5        $��canvas��5"      $
��Left=�6   $��20,86,0,54.8q�6;   $	��500��6Q   $	��745��6^   
 J� RenderTransformOrigin$
 0.5,0.5&�6j   �� 5#   
   $
��Left=�67   $��
390,10,0,0q�6R   $	��Top=�6f   $	��130��6~   $��40��6�   ���	#FF22BD0B$��Segoe UI Semibold)�6�   $��22(�6�   ��6   �� *Score+ �� Mode$ TwoWay=�6�   5%      5&      