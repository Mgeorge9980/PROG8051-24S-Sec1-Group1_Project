using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for BookingAppointmentWindow.xaml
    /// </summary>
    public partial class BookingAppointmentWindow : Window
    {
        public BookingAppointmentWindow()
        {
            InitializeComponent();
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the controls
            string serviceType = (ServiceTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string appointmentDate = DatePicker.SelectedDate.HasValue ? DatePicker.SelectedDate.Value.ToShortDateString() : "";

            // Validate inputs
            if (string.IsNullOrWhiteSpace(serviceType) || string.IsNullOrWhiteSpace(appointmentDate))
            {
                MessageBox.Show("Please select a service type and date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Implement the logic to book the appointment here
            // For demonstration, we'll just show a message box with the details
            MessageBox.Show($"Appointment Booked:\n\nService Type: {serviceType}\nDate: {appointmentDate}",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, clear the inputs after booking
            ServiceTypeComboBox.SelectedIndex = -1;
            DatePicker.SelectedDate = null;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
