using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class ViewAppointmentWindow : Window
    {
        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<Appointment> FilteredAppointments { get; set; }

        public ViewAppointmentWindow()
        {
            InitializeComponent();
            LoadAppointments();
            FilteredAppointments = new ObservableCollection<Appointment>(Appointments);
            AppointmentsDataGrid.ItemsSource = FilteredAppointments;
        }

        private void LoadAppointments()
        {
            // Example data; in a real application, you would load this from a database or other data source
            Appointments = new ObservableCollection<Appointment>
            {
                new Appointment { Number = 1, Name = "John Doe", PhoneNumber = "1234567890", AppointmentType = "Consultation", Date = "2023-07-26", Time = "10:00 AM", Action = "Hold" },
                new Appointment { Number = 2, Name = "Jane Smith", PhoneNumber = "0987654321", AppointmentType = "Follow-up", Date = "2023-07-27", Time = "11:00 AM", Action = "Hold" }
            };
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
                    DateTime appointmentDate = DateTime.Parse(a.Date);
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
    }

    public class Appointment
    {
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AppointmentType { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? Action { get; set; }
    }
}
