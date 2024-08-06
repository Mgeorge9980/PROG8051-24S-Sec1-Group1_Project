using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class AddOrderCategoryWindow : Window
    {
        public AddOrderCategoryWindow()
        {
            InitializeComponent();
        }

       

        private void SaveOrderCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = CategoryNameTextBox.Text;
            string rateText = RateTextBox.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(rateText) || !decimal.TryParse(rateText, out decimal rate) || rate < 0)
            {
                MessageBox.Show("Please enter a valid rate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Insert into OrderCategory table
            string insertQuery = "INSERT INTO ORDER_CATEGORY (CategoryName, Rate) VALUES (@CategoryName, @Rate)";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                command.Parameters.AddWithValue("@Rate", rate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order category added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close(); // Close the window after saving
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while adding the order category. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
