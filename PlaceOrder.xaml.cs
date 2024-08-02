using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for PlaceOrderWindow.xaml
    /// </summary>
    public partial class PlaceOrderWindow : Window
    {
        public PlaceOrderWindow()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // Handle file upload logic here
                string filePath = openFileDialog.FileName;
                MessageBox.Show($"Image uploaded: {filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the controls
            string type = (TypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string number = NumberTextBox.Text;
            string dueDate = DueDatePicker.SelectedDate.HasValue ? DueDatePicker.SelectedDate.Value.ToShortDateString() : "";

            // Validate inputs
            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(dueDate))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Save the order logic here
            // For demonstration, we'll just calculate an amount based on the number and show a message box
            if (int.TryParse(number, out int num))
            {
                double amount = num * 10; // Example calculation, $10 per unit
                AmountTextBlock.Text = $"Amount: ${amount}";
                MessageBox.Show($"Order placed:\n\nType: {type}\nNumber: {number}\nDue Date: {dueDate}\nAmount: ${amount}",
                                "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
