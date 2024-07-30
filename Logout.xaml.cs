using System.Windows;

namespace StudioManagement
{
    public partial class LogoutWindow : Window
    {
        public LogoutWindow()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle logout logic here
            Application.Current.Shutdown(); // Example: Close the application
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the logout confirmation window
        }
    }
}
