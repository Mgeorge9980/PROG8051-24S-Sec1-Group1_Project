   M S B A M L   `   `   `  ����  StudioManagement*    $StudioManagement.StaffScheduleWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Set Staff Schedule��5   	   $	��450��6$   $	��800��61   .��5      � ���#2F465B.+�5   
   �� $��Center=�6   $	��Top=�61   $��0,26,0,0q�6I   $��36(�5      $
��Bold"�6"   
�������$��SET STAFF SCHEDULE��6G   �� 5   
   $��Choose Staff��6   $
��Left=�6'   $	��Top=�6B   $��
50,100,0,0q�5      $
��Bold"�6$   
�������$��Arial)�5      $��14(�6#   �� 5   
   -   5         ��Name$ staffNameComboBox��5      $
��Left=�6.   $	��Top=�6I   $	��150��5      $��180,100,0,0q�6    $��Arial)�65   
���   �$��30��5   '   5      �� 5   
   $��
Choose Day��6   $
��Left=�6%   $	��Top=�6@   $��
50,160,0,0q�5      $
��Bold"�6$   
�������$��Arial)�5      $��14(�6#   �� 5   
   -   5        $ dayComboBox��5      $
��Left=�6(   $	��Top=�6C   $	��150��5      $��180,160,0,0q�6    $��Arial)�65   
���   �$��30��5   '   .@�5      �� $��Monday��6   �� 5      $��Tuesday��6   �� 5      $��	Wednesday��6   �� 5      $��Thursday��6   �� 5      $��Friday��6   5       �� 5#   
   -   5        $��UPDATE��5#      $
��Left=�6"   $	��Top=�6=   $��70��5$      $��150,220,0,0q�6   ���#0097A7
�������$��Arial)�5%   $   $��14(�67   $
��Bold"�5&       � Cursor$
 Hand��6#   5'      &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ scheduleDataGrid��5*         AutoGenerateColumns$ False��6-      CanUserAddRows$ False��6I   $��400,100,20,0q�5+      $	��Top=�6)   $	��200��6A      Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$	 Day��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 62   �� *ScheduledDay+6S     5.      $ Staff��6%   $ * 6R   	 64   �� *	StaffName+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5/      $ Actions��6)   $
 Auto 6:   
   CellTemplate
 50      �� 51      .R�52      �� $��deleteSchedBtn��66   -   5        $��Delete��52   %   ���#FF6347
�������$��5,0,5,0q�54      
 � Tag 53   3   �� *
ScheduleID+54      55      57      59      �� 5<   
   -   5        $��_��5<      $��30��6   $��Right=�6(   $	��Top=�6D   $��	0,10,60,0q�5=      ���	#FF2C3E4F
�������5>   (   �� 5?   
   -   5        $	��□��5?      $��30��6   $��Right=�6(   $	��Top=�6D   $��
0,10,100,0q�5@      ���	#FF2C3E4F
�������5A   (   �� 5B   
   -   5        $��x��5B      $��30��6   $��Right=�6(   $	��Top=�6D   $��	0,10,20,0q�5C      
���  ��
�������5D   "   5E      5F      