   M S B A M L   `   `   `  ����   StudioManagement"    StudioManagement.OrderWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Order List��$	��450��$	��800��.��� ���#2F465B.+��� $��Center=�$	��Top=�$��0,20,0,0q�$��36(�$
��Bold"�
�������$��
Order List���� $	��Top=�$��20,80,20,20q�.+��  � ColumnDefinitions �� $��2* ��� $��2* ��� $��2* ��� $��2* �.+��� $
��Date��$��16(�$
��Bold"�
�������$��0���� $��Customer Name��$��16(�$
��Bold"�
�������$��1���� $��
Order Type��$��16(�$
��Bold"�
�������$��2���� $��Status��$��16(�$
��Bold"�
�������$��3���� -   $��OrderListView��$��0,10,0,0q� �� View �� .P��� $
��Date�� �� Width$	 150�� �� DisplayMemberBinding �� *Date+�� $��Customer Name��$	 200�� �� *CustomerName+�� $��
Order Type��$	 150�� �� *	OrderType+�� $��Status��$	 150�� �� *Status+