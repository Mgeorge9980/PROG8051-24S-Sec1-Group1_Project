   M S B A M L   `   `   `  ����   StudioManagement%    LoginApp.ViewStaffDetailsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  View Staff Details��$	��450��$	��800��.��� ���#2F465B.+��� $��Center=�$	��Top=�$��0,26,0,0q�$��36(�$
��Bold"�
�������$��STAFF DETAILS���� -   $��AddNewStaffButton��$��Add New Staff��$	��150��$��40��$��20q�$��Right=�$	��Top=����#1899D6
�������$��16(� � Cursor$
 Hand��
������ $��0q�&   System.Windows.Controls.DataGrid  -   $��StaffDataGrid��   AutoGenerateColumns$ False��   CanUserAddRows$ False��$��20,100,20,20q�   HeadersVisibility$ Column=�
�������
���   �   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Phone Number��$ *  �� *PhoneNumber+4  .System.Windows.Controls.DataGridTemplateColumn  $ Actions��$
 Auto 	   CellTemplate	 �� .R��� -   $��Delete�����#FF6347
�������$��5,0,5,0q�

 � Tag
 �� *Name+