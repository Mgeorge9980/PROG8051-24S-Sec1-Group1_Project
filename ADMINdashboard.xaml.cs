using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class AdminDashboardWindow : Window
    {
        public AdminDashboardWindow()
        {
            InitializeComponent();
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
                      
                        case "My Customers":
                            var myCustomerWindow = new MyCustomerWindow();
                            myCustomerWindow.Show();
                            break;
                        case "Appointments":
                            var ViewAppointmentWindow = new ViewAppointmentWindow();
                            ViewAppointmentWindow.Show();
                            break;
                        case "Orders":
                            var OrderWind = new ListOrdersWindow();
                            OrderWind.Show();
                            break;
                        case "Order Category":
                            var ListCategories = new ListCategoriesWindow();
                            ListCategories.Show();
                            break;
                        case "Services":
                            var ServiceAdminWindow = new ServiceAdminWindow();
                            ServiceAdminWindow.Show();
                            break;
                        case "Staff Schedule":
                            var StaffScheduleWindow = new StaffScheduleWindow();
                            StaffScheduleWindow.Show();
                            break;
                        case "Staff Details":
                            var ViewStaffDetailsWindow = new ViewStaffDetailsWindow();
                            ViewStaffDetailsWindow.Show();
                            break;
                        case "Feedbacks":
                            var ViewRatingsWindow = new ViewRatingsWindow();
                            ViewRatingsWindow.Show();
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
