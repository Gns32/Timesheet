   M S B A M L   `   `   `  ����G  CTimesheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TimesheetApp.ValidationRulesTimesheetApp.ValidationRules  5      $    TimesheetApp.Views.WorklogView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      A
validation*clr-namespace:TimesheetApp.ValidationRules     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5"   
   � $��0��6   $��0��6   $	��Top=�6,     5$      �� 5&      $��* �6#   �� 5(      $
��Auto �6#   .+�5,      �� $��0��6   $��Worklog Management��6$   6D   �� 5.      -   5         ��Name$ refresh_button��5.      $��1��6-   $��Refresh��6>   6P   50      &   System.Windows.Controls.DataGrid  54   
   -   5        $��activityList��54   0   $��0��6   $��1��6#      AlternatingRowBackground
 �����   CanUserReorderColumns .    CanUserResizeColumns .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  	   HeadersVisibility$	 Column=�6	  
   
IsReadOnly
 .    CanUserResizeRows .     CanUserSortColumns . $��1q�56   ?   ��54   D   ��    Columns 58      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ W/C Date��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *WeekCommencingDate+4  .System.Windows.Controls.DataGridTemplateColumn  5<      $
 Team��6)      SortMemberPath$
 Team��67      CanUserSort .    CellTemplate 5>      �� 5@      .R�5B      �� $
��Wrap=�6>   ��6(   �� *Team+6>   5D      5H        5J      $ Shift��6)   $ Shift��68    .  5L      �� 5N      .R�5P      �� $
��Wrap=�6?   ��6(   �� *Shift+6?   5R      5V        5X      $
 Name��6)   $
 User��67    .  5Z      �� 5\      .R�5^      �� $
��Wrap=�6B   ��6(   �� *
Employee+6B   5`      5d        5f      $ Application��6)   $ Application��6>    .  5h      �� 5j      .R�5l      �� $
��Wrap=�6E   ��6(   �� *Application+6E   5n      5r        5t      $ Activity��6)   $ Activity��6;    .  5v      �� 5x      .R�5z      �� $
��Wrap=�6B   ��6(   �� *
Activity+6B   5|      5�        5�      $ Ref. No.��6)   $ 	Reference��6;    .  5�      �� 5�      .R�5�      �� $
��Wrap=�6E   ��6(   �� *ReferenceNo+6E   5�      5�        5�      $ Release��6%    66   �� *	Release+  5�      $ Priority��6%    67   �� *
Priority+  5�      $ 
Start Date��6%    69   �� *	StartDate+  5�      $ Description��6)   $ Description��6>    .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6n    5�      �� 5�      .R�5�      �� $
��Wrap=�6E   ��6(   �� *Description+6E   5�      5�        5�      $ Duration��6%    67   �� *
SpentHrs+5�      �� 5�   
   $��1��6   $��2��6%   .+�5�      �� $��New Worklog Item��6   �� 5�      $��W/C Date��6   (  "System.Windows.Controls.DatePicker  5�      -   5          Name$ WeekCommencingDate��5�      $
��Left=�65   $��	10,10,0,0q�6R   $	��Top=�5�         SelectedDateFormat$
 Long=�6b   ���	#000000006|   �� 5�      $��Application��6   �� 5�      -   5         ��Name$ applications��5�       �� DisplayMemberPath$ Title��6�   ��6-   �� *ApplicationList+ �� SelectedItem 6U   �� *SelectedApplication+6�   �� 5�      $��Shift��6   �� 5�      $ Title��6`   ��6   �� *	ShiftList+ 69   �� *SelectedShift+6`   �� 5�      $��Activity��6   �� 5�      $ Title��6f   ��6   �� *ActivityList+ 6<   �� *SelectedActivity+6f   �� 5�      $��Priority��6   �� 5�      $ Title��6f   ��6   �� *PriorityList+ 6<   �� *SelectedPriority+6f   �� 5�      $��Release��6   �� 5�      -   5         ��Name$ NewUserActivityRelease��5�       �� AcceptsReturn . .��6N   .��5�      ��  �� Path$  UserActivityEntity.Release�6    �� UpdateSourceTrigger$ PropertyChanged=�6<    �� ValidationRules 5�      3   -TimesheetApp.ValidationRules.GeneralInputRule  5�         	MinLength$ 0��66      	MaxLength$	 255��6D   ,	  &System.Windows.Controls.ValidationRule  	  ValidatesOnTargetUpdated  . 6T   5�      5�      �� 5�      $��Reference No.��6   �� 5�      -   5        $ NewUserActivityReference��5�       . .��6P   .��5�      �� $" UserActivityEntity.Reference�6   $ PropertyChanged=�6>    5�        5�      $ 0��66   $	 255��6D     . 6T   5�      5�      �� 5�      $��Duration (Hour : Minutes)��6   �� 5�      ! �� Orientation$! 
Horizontal=�6   .+�5�      �� -   5        $ HoursSelector��5�      " �� 
IsEditable" . ��62   �� *HoursSelector+$ 	LostFocus=� 6w   �� *" UserActivityEntity.DurationHours+6�   �� 5�      $��:��6   $	��Top=�6$   $��
0, 0, 0, 0q�6<   �� 5�      -   5        $ MinutesSelector��5�      " . ��64   �� *Team+$ 	LostFocus=� 6p   �� *$"UserActivityEntity.DurationMinutes+6�   5�      �� 5�      $��Description��6   �� 5�      -	   5        $  NewUserActivityDescription��5�      $	��100��6:    . .��6^   .��5�      �� $$ UserActivityEntity.Description�6   $ PropertyChanged=�6@    5�        5�      $ 0��66   $	 255��6D     . 6T   5     5     �� 5     $��
Start Date��6     5     -
   5        $ 	StartDate��5     $
��Left=�6,   $��	10,10,0,0q�6I   $	��Top=�5     $
 Long=�6a   ���	#000000006{   �� 5     -   5        $	��Add��5     # �� 	IsDefault# . ��6#   �� *AddUserActivityItemCommand+��5     �� 5     $ �� 
TargetType"$ ��6   .�5     �� % �� Property% � {�& �� Value& . 66   �� 5     % � ��$& 28��63   �� 5     % � ��$& 75��62   �� 5     % � ��$& 3.5,7,3.5,7q�63   ' �� Triggers' 5      ^� 5"     ( ^� 
Conditions( 5$  "   �� 5&  &   ) �� Binding) 60   �� * �� ElementName$* NewUserActivityComment��$ (Validation.HasError)�+ �� Value	+ false6�   �� 5(  &   ) 60   �� $* HoursSelector��$ (Validation.HasError)�	+ false6z   �� 5*  &   ) 60   �� $* MinutesSelector��$ (Validation.HasError)�	+ false6|   .0�5.  "   �� % � {�& . 6>   50     54     58     5:     �� 5>  
   $��2��6   , �� ContentStringFormat$, Current user: {0}��6G   ��6   �� *CurrentUser.Username+6G   5@     5A     