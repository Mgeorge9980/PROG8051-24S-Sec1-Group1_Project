   M S B A M L   `   `   `  ����   StudioManagement,    &StudioManagement.ViewAppointmentWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  View Appointments��$	��500��$	��800��.��� ���#2F465B.+��� $��Center=�$	��Top=�$��0,20,0,0q�$��36(�$
��Bold"�
�������$��View Appointments����  �� Orientation$ Vertical=�$��Center=�$��0,70,0,0q�.+��� $��Filter by date��
�������$��16(�$��0,0,0,10q�$��Center=��� $ 
Horizontal=�$��Center=�.+��� $��From:��
�������$��Center=�$��0,0,10,0q�(  "System.Windows.Controls.DatePicker  -   $��FromDatePicker��$��0,0,10,0q��� $	��To:��
�������$��Center=�$��0,0,10,0q�  -   $��ToDatePicker��$��0,0,10,0q��� $��Search a customer��
�������$��16(�$��
20,20,0,10q�$��Center=��� $ 
Horizontal=�$��Center=�.+��� -   $��SearchCustomerTextBox��$	��200��$��0,0,10,0q��� -   $��Search��$	��100��&   System.Windows.Controls.DataGrid  -   $��AppointmentsDataGrid��   AutoGenerateColumns$ False��   CanUserAddRows$ False��$��20,200,20,20q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Number��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Number+  $
 Name��$ *  �� *Name+  $ Phone Number��$ *  �� *PhoneNumber+  $ Appointment Type��$ *  �� *AppointmentType+  $
 Date��$ *  �� *Date+  $
 Time��$ *  �� *Time+4  .System.Windows.Controls.DataGridTemplateColumn  $ Action��$ *    CellTemplate �� .R��� $	��120������ *ActionOptions+	 �� SelectedItem	 �� *Action+.@��� $
��Done���� $��	Cancelled���� $
��Hold��