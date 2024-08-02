﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class UserDashboardWindow : Window
    {
        private List<ServiceAdminWindow.Service> services;

        public UserDashboardWindow()
        {
            InitializeComponent();
            // Initialize your list of services here or load from a data source
            services = new List<ServiceAdminWindow.Service>
            {
                new ServiceAdminWindow.Service { Number = 1, ServiceName = "Photography" },
                new ServiceAdminWindow.Service { Number = 2, ServiceName = "Videography" }
                // Add more services as needed
            };
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ListBoxItem selectedItem)
                {
                    string selectedContent = selectedItem.Content.ToString();

                    switch (selectedContent)
                    {
                        case "My Profile":
                            var myProfileWindow = new MyProfileWindow();
                            myProfileWindow.Show();
                            break;
                        case "Appointments":
                            var bookingAppointmentWindow = new BookingAppointmentWindow();
                            bookingAppointmentWindow.Show();
                            break;
                        case "Orders":
                            var placeOrderWindow = new PlaceOrderWindow();
                            placeOrderWindow.Show();
                            break;
                        case "Services":
                            var viewServicesWindow = new ViewServicesWindow(services);
                            viewServicesWindow.Show();
                            break;
                        case "Feedbacks":
                            var addFeedbackWindow = new AddFeedbackWindow();
                            addFeedbackWindow.Show();
                            break;
                        case "FAQs":
                            var fAQsWindow = new FAQsWindow();
                            fAQsWindow.Show();
                            break;
                        case "Contact Us":
                            var contactUsWindow = new ContactUsWindow();
                            contactUsWindow.Show();
                            break;
                        case "Logout":
                            var logoutWindow = new LogoutWindow();
                            logoutWindow.Show();
                            this.Close();
                            break;
                    }
                }
            }
        }
    }
}
