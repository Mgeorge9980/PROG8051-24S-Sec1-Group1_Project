using System.Configuration;
using System.Data.SqlClient;
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
            ViewServicesWindow vs = new ViewServicesWindow();

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
            if (serviceID == 0 || string.IsNullOrWhiteSpace(appointmentDate))
            {
                MessageBox.Show("Please select a service type and date.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string InsertQuery = "Insert into APPOINTMENT (CustomerID,AppointmentDate,ServiceID,AppointmentStatus)values(@CustomerID,@AppointmentDate,@ServiceID,@AppointmentStatus)";

            // Create a new connection object
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command object
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        // Define parameters and their values
                        command.Parameters.AddWithValue("@CustomerID", Properties.Settings.Default.UserID);
                        command.Parameters.AddWithValue("@AppointmentDate", Convert.ToDateTime(appointmentDate));
                        command.Parameters.AddWithValue("@ServiceID", serviceID);
                        command.Parameters.AddWithValue("@AppointmentStatus", "CONFIRMED");

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Appointment Booked:\nDate: {appointmentDate}",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            UserDashboardWindow usrdsh = new UserDashboardWindow();
                            usrdsh.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred. Please try again !!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error: " + ex.Message);
                }
               

                // Optionally, clear the inputs after booking
                ServiceTypeComboBox.SelectedIndex = -1;
                DatePicker.SelectedDate = null;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
