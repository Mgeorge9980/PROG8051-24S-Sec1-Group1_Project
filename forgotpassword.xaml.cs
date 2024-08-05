using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string email = EmailTextBox.Text;

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(email))
            {
                if (VerifyUser(email, firstName) != null)
                {
                    ProceedWindow prcd = new ProceedWindow();
                    prcd.Show();
                    this.Close(); // Close the forgot password window
                }
                else
                {
                    MessageBox.Show("Invalid email or first name.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both your first name and email.");
            }
        }

        private int? VerifyUser(string email, string name)
        {
            // Query to check the credentials
            string query = "SELECT top 1 CustomerID FROM CUSTOMER WHERE EmailID = @EmailId AND CustomerName = @name;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmailId", email);
                command.Parameters.AddWithValue("@name", name);
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
    }
}
