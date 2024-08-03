using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

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
            CustomerDataGrid.ItemsSource = GetCustomer();
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
        public List<Customer> GetCustomer()
        {
            List<Customer> Customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
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
                        Customers.Add(product);
                    }
                }
            }

            return Customers;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
