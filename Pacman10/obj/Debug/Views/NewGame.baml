   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   
    Pacman10   Pacman10.NewGame   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ^ePclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   
     � Title$  NewGame��5	   	   $��418.527��6   $	��300��6*   .   (System.Windows.Interactivity.Interaction   Triggers 5
      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 5      �� *Loaded+   CommandParameter 5      ��  �� ElementName$ ListBox��5      ��5      
� 5   
   .��5      �  � Color$ Black��6    � Offset$ 1Q�6)   � 5      $ 	#FF0A0552��6   5      .��5      � .+�5   
   �� $��15(�6   $
��Left=�6   $��Ваше имя:��6@   $	��Top=�6T   $��31��6l   ���	#FF5AE404$
��Bold"�6�   ���	#FF04021A$��10,10,201.6,0q�6�   �� 5   
   $
��Left=�6(   $��31��6C   $��	97,10,0,0q�6O   	 �� TextWrapping$
	 Wrap=�6b   $��Center=�6v   $	��Top=�6�   $	��106��6�   $��16(�6�   $��Italic$�6�   $��SimSun)�6�   ��6   �� *Name+6�   �� 5   
   -   5        $��ListBox��5      $��Stretch=�6!   $��0��6?   $��0,87,-0.4,41.8q�6t   
 �� SelectedItem
 6O   �� *SelectedAsm+��5      
� 5      .��5      � $ 	#FF0A0552��6#   � 5      $ 	#FF04021A��6#   $ 1Q�65   5       ��5"      �� 5#      .R�5$      �� $��5q�6!   .+�5%      �� $��18(�6%   $��Italic$�6[   $
��Bold"�6n   ���	#FFEBFF03��63   ��  �� Path$
 Name� �� Mode$ OneWay=�6�   5&      5'      5)      �� 5*   
   $��15(�6   $��Center=�6   $
��Left=�6;   $��Выберите игру��6]   $	��Top=�6u   $��31��6�   ���	#FF5AE404$
��Bold"�6�   ���	#FF04021A$��0,51,0,0q�6�   �� 5+   
   $��
MainWindow��6/   $��Start��6M   $��Center=�6]   $��109,352,109.6,0q�6z   $	��Top=�6�   $��75��6�   $��27��6�   $��16(�6�   ���	#FF5AE404$
��Bold"�6�   ��6   �� *	StartGame+��5,      
� 5-      .��5.      � $ 	#FF060000��6#   $ 1Q�65   � 5/      $ 	#FF0A0774��6#   $ 0.597Q�65   50      52      53      54      