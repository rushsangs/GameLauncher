   M S B A M L   `   `   `  ����G  CGameLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GameLauncherGameLauncher  5   	   A%clr-namespace:GameLauncher.ViewModelsGameLauncher.ViewModels  5   	   7 clr-namespace:GameLauncher.ViewsGameLauncher.Views  5   	       GameLauncher.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GameLauncher     5   	   <
viewmodels%clr-namespace:GameLauncher.ViewModels     5   	   2views clr-namespace:GameLauncher.Views     5   	   -   5          �Name$  EAELauncher��5   	    � Title$ EAE Game Launcher��5
   	   $
��1000��6#   $
��1000��61    � 	Resources 5       �� DataType+   %GameLauncher.ViewModels.ListViewModel!   GameLauncher.Views.ListView+   %GameLauncher.ViewModels.GameViewModel!   GameLauncher.Views.GameView��%�   (��       5      *, +)(�� 2     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       .+�5#   
   ]� $��0��6   $��0��6!   $��2��61   
�������.+�5$      �� -   5         ��Name$ MainTitleLabel��5$      $$��Welcome to EAE! Choose a game!��6,   $��24(�6U   $
��Bold"�6c   5%      �� 5&   
   -   5         ��Name$ Pages��5&      $��1��6(   $��0��65   $��6��6E   $��2��6V   ��6j   �� *SelectedViewModel+5(      5*      