using System.Windows;
using System.Windows.Controls;

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

            // Logic to save the new service
            MessageBox.Show($"Service '{serviceName}' with rate {rate:C} added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the text fields
            ServiceNameTextBox.Clear();
            RateTextBox.Clear();
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
