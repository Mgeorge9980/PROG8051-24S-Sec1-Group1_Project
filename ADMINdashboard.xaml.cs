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
                        case "Appointments":
                            var viewAppointmentWindow = new ViewAppointmentWindow();
                            viewAppointmentWindow.Show();
                            this.Close();
                            break;
                        case "My Customers":
                            var myCustomerWindow = new MyCustomerWindow();
                            myCustomerWindow.Show();
                            this.Close();
                            break;
                            
                    }
                }
            }
        }
    }
}
