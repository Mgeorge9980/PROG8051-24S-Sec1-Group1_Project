using StudioManagement;
using System.Windows;

namespace StudioManagement
{
    public partial class SetUpNewPasswordWindow : Window
    {
        public SetUpNewPasswordWindow()
        {
            InitializeComponent();
        }

        private void SetUpPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter a new password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please confirm your new password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Perform password setup logic here
            // ...

            MessageBox.Show("Your password has been reset successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoginTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Navigate to the login page
            // For example:
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
