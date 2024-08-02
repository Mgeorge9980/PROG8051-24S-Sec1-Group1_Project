using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace StudioManagement
{
    public partial class MyCustomerWindow : Window
    {
        public MyCustomerWindow()
        {
            InitializeComponent();
            // Set the DataContext to this window
            this.DataContext = this;

            // Bind an empty list to the DataGrid
            CustomerDataGrid.ItemsSource = GetProducts();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem as ListBoxItem;

            if (selectedItem != null)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Home":
                        var adminDashboardWindow = new AdminDashboardWindow();
                        adminDashboardWindow.Show();
                        this.Close();
                        break;
                        // Handle other cases similarly
                }
            }
        }
        public List<Customer> GetProducts()
        {
            List<Customer> products = new List<Customer>();

            using (SqlConnection connection = new SqlConnection("Server=SHILPA-PC\\SQLEXPRESS19;Database=StudioManagement;User Id=sa;Password=Conestoga1;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "select CustomerName,MobileNumber from CUSTOMER";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer product = new Customer
                        {
                            Name = reader.GetString(0),
                            PhoneNumber = reader.GetString(1),
                            
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
