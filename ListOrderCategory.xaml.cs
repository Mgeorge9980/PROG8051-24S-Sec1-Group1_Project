using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class ListCategoriesWindow : Window
    {
        public ListCategoriesWindow()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            List<OrderCategory> categories = new List<OrderCategory>();

            string query = "SELECT OrderCategoryID, CategoryName, Rate FROM ORDER_CATEGORY";

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
                            OrderCategory category = new OrderCategory
                            {
                                OrderCategoryID = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                Rate = reader.GetDecimal(2)
                            };
                            categories.Add(category);
                        }
                    }
                    CategoriesDataGrid.ItemsSource = categories;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading categories: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddNewCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Add Order Category window
            AddOrderCategoryWindow addCategoryWindow = new AddOrderCategoryWindow();
            addCategoryWindow.ShowDialog();
            LoadCategories(); // Refresh the category list after adding
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected category ID from the button's tag
            var button = sender as System.Windows.Controls.Button;
            int categoryId = (int)button.Tag;

            // Confirmation before deletion
            if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string deleteQuery = "DELETE FROM ORDER_CATEGORY WHERE OrderCategoryID = @OrderCategoryID";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@OrderCategoryID", categoryId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadCategories(); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while deleting the category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

    public class OrderCategory
    {
        public int OrderCategoryID { get; set; }
        public string CategoryName { get; set; }
        public decimal Rate { get; set; }
    }
}
