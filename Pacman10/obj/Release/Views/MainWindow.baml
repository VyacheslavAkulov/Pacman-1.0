   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity   Pacman10   Pacman10.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     ^ePclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � 
ResizeMode$  CanMinimize=� � Title$ 
MainWindow��$	��670��$	��836��.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *Load+   CommandParameter ��  �� ElementName$ canvas��  $ PreviewKeyDown��.    �� *	KeyDown+ �� $ canvas��.��� ��
� .���  � Color$ 	#FF080529��	 � Offset$	 1Q�� $ 	#FF0A0552��.+��� $
��Left=�$��	10,10,0,0q�$	��Top=�$	��140��$��40��$��16(�$��MV Boli)�$
��Bold"�$��Italic$�$��NewGame������ *OpenNewGame+.��
New game�� $
��Left=�$��
196,10,0,0q�$	��Top=�$	��140��$��40��$��16(�$��MV Boli)�$
��Bold"�$��Italic$�$��Leaderboard������ *OpenLeaderboard+.��Leaderboard�� -   $��canvas��$
��Left=�$��20,86,0,54.8q�$	��500��$	��745��
 J� RenderTransformOrigin$
 0.5,0.5&��� $
��Left=�$��
390,10,0,0q�$	��Top=�$	��130��$��40�����	#FF22BD0B$��Segoe UI Semibold)�$��22(����� *Score+ �� Mode$ TwoWay=�