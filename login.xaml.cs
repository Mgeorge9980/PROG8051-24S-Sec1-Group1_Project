using System.Linq.Expressions;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls.Primitives;
using System.Configuration;
using static StudioManagement.MyProfileWindow;

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
            string password = PasswordTextBox.Password;

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
                    
                    else if (VerifyCredentials(email, password)!=null)
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
            PasswordPlaceholder.Visibility = string.IsNullOrEmpty(PasswordTextBox.Password) ? Visibility.Visible : Visibility.Hidden;
        }

        private int? VerifyCredentials(string email, string password)
        {
            // Query to check the credentials
            string query = "SELECT top 1 CustomerID FROM CUSTOMER WHERE EmailID = @EmailId AND Password = @Password;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmailId", email);
                command.Parameters.AddWithValue("@Password", password);
                int? CustID = null;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustID = reader.GetInt32(0);   
                        }
                    }
                    if (CustID.HasValue)
                    {
                        Properties.Settings.Default.UserID = CustID.Value;
                        Properties.Settings.Default.Save();
                    }
                    return CustID;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                    return null;
                }
            }
        }

        private void SignUpTextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            SignupService signup=new SignupService();
            signup.Show();
                
        }
        private void ForgotPasswordTextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.Show();
            this.Close(); // Close the login window
        }
    }
}
