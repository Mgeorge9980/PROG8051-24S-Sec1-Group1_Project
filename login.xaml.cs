using System.Linq.Expressions;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;

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


                // Verify credentials against the database
                if (email.ToUpper() == "ADMIN" && password == "123")
                {
                    AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();
                    adminDashboardWindow.Show();
                    this.Close(); // Close the login window
                }
                    
                    else if (VerifyCredentials(email, password))
                {
                    // Credentials are correct, proceed to the user dashboard
                    UserDashboardWindow userDashboardWindow = new UserDashboardWindow();
                    userDashboardWindow.Show();
                    this.Close(); // Close the login window
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

        private bool VerifyCredentials(string email, string password)
        {
            // Connection string to your database
            string connectionString = "Server=MERLIN\\SQLEXPRESS19;Database=StudioManagement;User Id=sa;Password=Conestoga1;Trusted_Connection=True;";

            // Query to check the credentials
            string query = "SELECT COUNT(1) FROM CUSTOMER WHERE EmailID = @EmailId AND Password = @Password;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmailId", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int result = (int)command.ExecuteScalar();
                    return result == 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                    return false;
                }
            }
        }

        private void SignUpTextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            SignupService signup=new SignupService();
            signup.Show();
                
        }
    }
}
