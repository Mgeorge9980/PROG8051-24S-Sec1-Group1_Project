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
            ViewServicesWindow vs=new ViewServicesWindow();

            ServiceTypeComboBox.ItemsSource = vs.GetService();
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            int serviceID = 0;
            if (ServiceTypeComboBox.SelectedValue is int selectedServiceId)
            {
                serviceID = selectedServiceId;
            }

          
            string appointmentDate = DatePicker.SelectedDate.HasValue ? DatePicker.SelectedDate.Value.ToShortDateString() : "";

            // Validate inputs
            if (serviceID==0 || string.IsNullOrWhiteSpace(appointmentDate))
            {
                MessageBox.Show("Please select a service type and date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Implement the logic to book the appointment here
            // For demonstration, we'll just show a message box with the details
            MessageBox.Show($"Appointment Booked:\n\nService Type: {serviceID}\nDate: {appointmentDate}",
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
