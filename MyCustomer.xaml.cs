using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            CustomerDataGrid.ItemsSource = new List<Customer>();
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
    }

    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
