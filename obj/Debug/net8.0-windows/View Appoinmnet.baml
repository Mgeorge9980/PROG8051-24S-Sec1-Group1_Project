   M S B A M L   `   `   `  ����  Studio Management*    $AppointmentsApp.ViewAppointmentsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  View Appointments��5      $	��500��6!   $	��800��6.   .��5      � ���#2F465B.+�5   
   �� $��Center=�6   $	��Top=�61   $��0,20,0,0q�6I   $��36(�5      $
��Bold"�6"   
�������$��View Appointments��6G   �� 5	   
    �� Orientation$ Vertical=�6   $��Center=�6,   $��0,70,0,0q�6I   .+�5
      �� $��Filter by date��6   
�������$��16(�6A   $��0,0,0,10q�6O   $��Center=�6a   �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��From:��6   
�������$��Center=�6<   $��0,0,10,0q�6W   (  "System.Windows.Controls.DatePicker  5      -   5        $��FromDatePicker��5      $��0,0,10,0q�6h   �� 5      $	��To:��6   
�������$��Center=�6:   $��0,0,10,0q�6U     5      -   5        $��ToDatePicker��5      $��0,0,10,0q�6f   5      �� 5      $��Search a customer��6   
�������$��16(�6D   $��
20,20,0,10q�6R   $��Center=�6f   �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��SearchCustomerTextBox��5      $	��200��67   $��0,0,10,0q�6C   �� 5      -   5        $��Search��5      $	��100��6M   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��AppointmentsDataGrid��5         AutoGenerateColumns$ False��6/      CanUserAddRows$ False��6K   $��20,200,20,20q�6b      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Number+6P     5      $
 Name��6%   $ * 6L    63   �� *Name+6L     5      $ Phone Number��6%   $ * 6[    6;   �� *PhoneNumber+6[     5      $ Appointment Type��6%   $ * 6c    6?   �� *AppointmentType+6c     5      $
 Date��6%   $ * 6L    63   �� *Date+6L     5       $
 Time��6%   $ * 6L    63   �� *Time+6L   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ Action��6)   $ * 69      CellTemplate 5"      �� 5#      .R�5$      �� $	��120��6m   ��6'   �� *ActionOptions+	 �� SelectedItem	 6M   �� *Action+.@�5%   "   �� $
��Done��6/   �� 5&   "   $��	Cancelled��6/   �� 5'   "   $
��Hold��6/   5(      5)      5+      5-      5.      5/      