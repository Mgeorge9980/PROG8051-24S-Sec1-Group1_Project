using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            LoadCustomers(); // Load customers when the window initializes
            LoadCategories(); // Load categories when the window initializes
        }

        private void LoadCustomers()
        {
            string query = "SELECT CustomerID, CustomerName FROM Customer";
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerID = reader.GetInt32(0),
                            CustomerName = reader.GetString(1)
                        };
                        customers.Add(customer);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching customers: " + ex.Message);
                }
            }

          
        }

        private void LoadCategories()
        {
            string query = "SELECT OrderCategoryID, CategoryName, Rate FROM ORDER_CATEGORY"; // Include Rate in the SELECT
            List<OrderCategory> categories = new List<OrderCategory>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderCategory category = new OrderCategory
                        {
                            OrderCategoryID = reader.GetInt32(0),
                            CategoryName = reader.GetString(1),
                            Rate = reader.GetDecimal(2) // Retrieve Rate
                        };
                        categories.Add(category);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching categories: " + ex.Message);
                }
            }

            // Bind the list to the ComboBox
            CategoryComboBox.ItemsSource = categories;
            CategoryComboBox.DisplayMemberPath = "CategoryName"; // Shows the name in the ComboBox
            CategoryComboBox.SelectedValuePath = "OrderCategoryID"; // The value to be used for the selected item
        }
        private void CategoryComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected category
            var selectedCategory = CategoryComboBox.SelectedItem as OrderCategory;

            // Check if a category is selected
            if (selectedCategory != null)
            {
                // Fill the RateTextBox based on the selected category's rate
                RateTextBox.Text = selectedCategory.Rate.ToString("0.00"); // Format to 2 decimal places
            }
        }


        private void SaveOrderButton_Click(object sender, RoutedEventArgs e)
        {
            
            var selectedCategory = CategoryComboBox.SelectedItem as OrderCategory;
            string qtyText = QuantityTextBox.Text; // Assuming rate is entered as a text

            if ( selectedCategory != null &&
                !string.IsNullOrEmpty(qtyText) && DateTime.TryParse(OrderDatePicker.Text, out DateTime orderDate))
            {
                int categoryId = selectedCategory.OrderCategoryID;
                decimal rate;

                // Validate rate
                if (!decimal.TryParse(qtyText, out rate) || rate < 0)
                {
                    MessageBox.Show("Please enter a valid rate.");
                    return;
                }

                // Insert order into the database
                string insertQuery = "INSERT INTO CUSTOMER_ORDER (CustomerID, OrderCategoryID, OrderCount, OrderDate) VALUES (@CustomerID, @OrderCategoryID, @OrderCount, @OrderDate)";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@CustomerID", Properties.Settings.Default.UserID);
                    command.Parameters.AddWithValue("@OrderCategoryID", categoryId);
                    command.Parameters.AddWithValue("@OrderCount", qtyText);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order placed successfully.");
                            this.Close(); // Close the window after saving the order
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while placing the order. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select both a customer and a category, and enter a valid rate and order date.");
            }
        }
    }

   
}
