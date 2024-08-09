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
            // Close the main window (if applicable)
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Close();
            }

            // Create and show the LoginWindow
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close the current LogoutWindow
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the logout confirmation window
        }
    }
}
