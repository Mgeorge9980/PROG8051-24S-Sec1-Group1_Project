   M S B A M L   `   `   `  ����  StudioManagement(    "StudioManagement.ViewRatingsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  View Ratings��5   	   $	��450��6   $	��800��6+   .��5      � ���#2F465B.+�5   
   �� $��Center=�6   $	��Top=�61   $��0,26,0,0q�6I   $��36(�5      $
��Bold"�6"   
�������$��Customer Ratings��6G   &   System.Windows.Controls.DataGrid  5   
   -   5        $��RatingsDataGrid��5         AutoGenerateColumns$ False��6*      CanUserAddRows$ False��6F   $��20,100,20,20q�6]   
�������
���   �   
IsReadOnly$
 True��5	   9      Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *CustomerName+6]     5      $ Rating��6%   $ * 6X    65   �� *FeedbackRating+6X     5      $ Comment��6%   $ * 6W    66   �� *FeedbackText+6W   5      5      5      