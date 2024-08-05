using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Windows;

namespace StudioManagement
{
    public partial class ProceedWindow : Window
    {
        public ProceedWindow()
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

            //string insertQuery = "insert into CUSTOMER (customername)values(@customername)";
            string updateQuery = "Update CUSTOMER set Password= @Password where CustomerID=@CustID";

            // Create a new connection object
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command object
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Define parameters and their values
                        command.Parameters.AddWithValue("@Password", newPassword);
                        command.Parameters.AddWithValue("@CustID", Properties.Settings.Default.UserID);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your password has been reset successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoginWindow loginWindow = new LoginWindow();
                            loginWindow.Show();
                            this.Close();
                        }   
                        else
                        {
                            MessageBox.Show("An error occurred. Please try again !!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error: " + ex.Message);
                }



            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Navigate to the login page
            // For example:
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
