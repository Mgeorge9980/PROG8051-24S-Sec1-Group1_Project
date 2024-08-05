using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudioManagement
{
    public partial class ViewAppointmentWindow : Window
    {
        public List<Appointment> Appointments { get; set; }
        public List<Appointment> FilteredAppointments { get; set; }

        public ViewAppointmentWindow()
        {
            InitializeComponent();
            LoadAppointments();
            FilteredAppointments = new List<Appointment>(Appointments);
            AppointmentsDataGrid.ItemsSource = FilteredAppointments;
        }

        private void LoadAppointments()
        {
            // Example data; in a real application, you would load this from a database or other data source



            List<Appointment> appmnts = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                connection.Open();
                string query = "select ap.AppointmentID,cu.CustomerName,cu.MobileNumber,ap.AppointmentDate,se.ServiceName,ap.AppointmentStatus from APPOINTMENT ap inner join CUSTOMER cu on ap.CustomerID=cu.CustomerID inner join SERVICE se on ap.ServiceID=se.ServiceID;";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Appointment Appnt = new Appointment
                        {
                            Number = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            PhoneNumber = reader.GetString(2),
                            Date = reader.GetDateTime(3),
                            ServiceType = reader.GetString(4),
                            AppointmentStatus = reader.GetString(5),

                        };
                        appmnts.Add(Appnt);
                    }
                }
            }

            Appointments = appmnts;

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAppointments();
        }

        private void SearchCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            FilterAppointments();
        }

        private void FilterAppointments()
        {
            DateTime? fromDate = FromDatePicker.SelectedDate;
            DateTime? toDate = ToDatePicker.SelectedDate;
            string customerName = SearchCustomerTextBox.Text.ToLower();

            var filtered = Appointments.Where(a =>
            {
                bool dateMatch = true;
                bool nameMatch = true;

                if (fromDate.HasValue && toDate.HasValue)
                {
                    DateTime? appointmentDate = a.Date;
                    dateMatch = appointmentDate >= fromDate.Value && appointmentDate <= toDate.Value;
                }

                if (!string.IsNullOrWhiteSpace(customerName))
                {
                    nameMatch = a.Name.ToLower().Contains(customerName);
                }

                return dateMatch && nameMatch;
            }).ToList();

            FilteredAppointments.Clear();
            foreach (var appointment in filtered)
            {
                FilteredAppointments.Add(appointment);
            }

            AppointmentsDataGrid.ItemsSource = FilteredAppointments;
        }

        private void ActionCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public class Appointment
        {
            public int Number { get; set; }
            public string? ServiceType { get; set; }
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; }
            public DateTime? Date { get; set; }
            public TimeSpan? Time { get; set; }
            public string? Action { get; set; }
            public string? AppointmentStatus { get; set; }
        }
    }
}
