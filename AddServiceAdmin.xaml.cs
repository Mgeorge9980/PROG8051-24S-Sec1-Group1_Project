using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace StudioManagement
{
    public partial class AddServiceAdminWindow : Window
    {
        public AddServiceAdminWindow()
        {
            InitializeComponent();
        }

        private void SaveServiceButton_Click(object sender, RoutedEventArgs e)
        {
            string serviceName = ServiceNameTextBox.Text;
            string rateText = RateTextBox.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(serviceName) || string.IsNullOrWhiteSpace(rateText))
            {
                MessageBox.Show("Please enter both service name and rate.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(rateText, out decimal rate))
            {
                MessageBox.Show("Please enter a valid rate.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string insertQuery = "Insert into Service(ServiceName,ImageCount,ServiceDescription,PhotoSize, ServicePrice)values(@ServiceName,@ImageCount,@ServiceDescription,@PhotoSize,@ServicePrice)";

            // Create a new connection object
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command object
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Define parameters and their values
                        command.Parameters.AddWithValue("@ServiceName", serviceName);
                        command.Parameters.AddWithValue("@ImageCount", 0);
                        command.Parameters.AddWithValue("@ServiceDescription", "");
                        command.Parameters.AddWithValue("@PhotoSize", "");
                        command.Parameters.AddWithValue("@ServicePrice", rateText);


                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Service '{serviceName}' with rate {rate:C} added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                            ServiceAdminWindow servAdd=new ServiceAdminWindow();
                            servAdd.Show();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while adding service. Please try again !!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error: " + ex.Message);
                }
                // Logic to save the new service


                // Clear the text fields
                ServiceNameTextBox.Clear();
                RateTextBox.Clear();
            }
        }

        private void ServiceNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ServiceNamePlaceholder.Visibility = string.IsNullOrWhiteSpace(ServiceNameTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void RateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RatePlaceholder.Visibility = string.IsNullOrWhiteSpace(RateTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
