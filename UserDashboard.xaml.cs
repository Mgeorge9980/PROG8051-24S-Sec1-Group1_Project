using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class UserDashboardWindow : Window
    {
        public UserDashboardWindow()
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
                        case "My Profile":
                            var myProfileWindow = new MyProfileWindow();
                            myProfileWindow.Show();
                            this.Close();
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
