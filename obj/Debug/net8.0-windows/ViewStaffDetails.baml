   M S B A M L   `   `   `  ����  StudioManagement-    'StudioManagement.ViewStaffDetailsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  View Staff Details��5   	   $	��450��6$   $	��800��61   .��5      � ���#2F465B.+�5   
   �� $��Center=�6   $	��Top=�61   $��0,26,0,0q�6I   $��36(�5      $
��Bold"�6"   
�������$��STAFF DETAILS��6G   �� 5	   
   -   5        $��AddNewStaffButton��5	      $��Add New Staff��6*   $	��150��6B   $��40��6N   $��20q�6Z   $��Right=�5
      $	��Top=�6-   ���#1899D6
�������$��16(�5   9    � Cursor$
 Hand��5      
������ $��0q�69   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��StaffDataGrid��5         AutoGenerateColumns$ False��6(      CanUserAddRows$ False��5      $��20,100,20,20q�6*      HeadersVisibility$ Column=�6@   
�������
���   �   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	StaffName+6Q     5      $ Phone Number��6%   $ * 6a    6;   �� *StaffMobileNumber+6a     5      $ Email��6%   $ * 6U    64   �� *StaffEmailID+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6)   $
 Auto 6:   	   CellTemplate	 5      �� 5      .R�5      �� -   5        $��Delete��5   %   ���#FF6347
�������$��5,0,5,0q�5   %   

 � Tag
 5   @   �� *	StaffID+5   %   5      5      5       5!      5"      