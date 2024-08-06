using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class ListOrdersWindow : Window
    {
        public ListOrdersWindow()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            List<Order> orders = new List<Order>();

            string query = "SELECT OrderID, CustomerName, CategoryName, Rate, OrderDate FROM Orders";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderID = reader.GetInt32(0),
                                CustomerName = reader.GetString(1),
                                CategoryName = reader.GetString(2),
                                Rate = reader.GetDecimal(3),
                                OrderDate = reader.GetDateTime(4)
                            };
                            orders.Add(order);
                        }
                    }
                    OrdersDataGrid.ItemsSource = orders;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading orders: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

      

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected order ID from the button's tag
            var button = sender as System.Windows.Controls.Button;
            int orderId = (int)button.Tag;

            // Confirmation before deletion
            if (MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string deleteQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@OrderID", orderId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadOrders(); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while deleting the order.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CategoryName { get; set; }
        public decimal Rate { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
