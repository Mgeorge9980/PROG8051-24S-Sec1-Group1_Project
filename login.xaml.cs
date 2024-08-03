using System.Windows;

namespace StudioManagement
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            // Check if both fields are filled out 
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // Check if the email and password are correct
                if (email.ToUpper() == "ADMIN" && password == "123") // For Unit Testing Kept demo login and password
                {
                    AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();
                    adminDashboardWindow.Show();
                    this.Close();
                }
                else if (email.Equals("Shilpa@gmail.com", StringComparison.OrdinalIgnoreCase) && password == "Gopi")
                {
                    UserDashboardWindow userDashboardWindow = new UserDashboardWindow();
                    userDashboardWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both email and password.");
            }
        }

        private void EmailTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            EmailPlaceholder.Visibility = string.IsNullOrEmpty(EmailTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
