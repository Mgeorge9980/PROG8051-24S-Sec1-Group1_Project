using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static StudioManagement.ViewAppointmentWindow;

namespace StudioManagement
{
    public partial class UserDashboardWindow : Window
    {

        public UserDashboardWindow()
        {
            InitializeComponent();
            LoadDashboardData();
            LoadStaffInShift();

        }
        private void LoadStaffInShift()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM STAFF_DETAILS SD JOIN STAFF_SCHEDULE SC on SD.StaffID = SC.StaffID WHERE DATENAME(weekday, GETDATE()) = SC.ScheduledDay";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        StaffName.Text = row["StaffName"].ToString();
                        StaffPhone.Text = "Phone: " + row["Phone"].ToString();
                        StaffEmail.Text = "Email: " + row["Email"].ToString();
                    }
                    else
                    {
                        StaffName.Text = "No staff on shift today.";
                        StaffPhone.Text = string.Empty;
                        StaffEmail.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        public class DataAccess
        {
            private string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            int CustID = Properties.Settings.Default.UserID;
            public DashboardData GetDashboardData()
            {
                DashboardData data = new DashboardData();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    data.AppointmentsToday = GetCount(connection, "SELECT COUNT(*) FROM APPOINTMENT WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE) And CustomerID=" + CustID);
                    data.PlacedOrders = GetCount(connection, "SELECT COUNT(*) FROM CUSTOMER_ORDER WHERE  CustomerID=" + CustID);
                    data.UpcomingAppointments = GetUpcomingAppointments(connection);
                }

                return data;
            }

            private int GetCount(SqlConnection connection, string query)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }

            private List<Appointment> GetUpcomingAppointments(SqlConnection connection)
            {
                List<Appointment> appointments = new List<Appointment>();

                string query = "SELECT s.ServiceName,a.AppointmentDate,cu.CustomerName,cu.MobileNumber,cu.EmailID FROM APPOINTMENT a inner join SERVICE s on a.ServiceID=s.ServiceID inner join CUSTOMER cu on a.CustomerID= cu.CustomerID where AppointmentDate >= GETDATE() And a.CustomerID="+ Properties.Settings.Default.UserID+" ORDER BY AppointmentDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            Type = reader.GetString(0),
                            Date = reader.GetDateTime(1),
                            CustomerName = reader.GetString(2),
                            CustomerPhone = reader.GetString(3),
                            CustomerEmail = reader.GetString(4)
                        });
                    }
                }

                return appointments;
            }
        }
        private void LoadDashboardData()
        {
            DataAccess dataAccess = new DataAccess();
            DashboardData dashboardData = dataAccess.GetDashboardData();

            // Bind counts
            AppointmentsToday.Text = dashboardData.AppointmentsToday.ToString();
            PlacedOrders.Text = dashboardData.PlacedOrders.ToString();

            // Bind upcoming appointments
            foreach (var appointment in dashboardData.UpcomingAppointments)
            {
                var appointmentBorder = new Border
                {
                    BorderBrush = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10)
                };

                var appointmentStackPanel = new StackPanel { Orientation = Orientation.Horizontal };

                var typeStackPanel = new StackPanel { Width = 300 };
                typeStackPanel.Children.Add(new TextBlock { Text = appointment.Type, FontSize = 16, FontWeight = FontWeights.Bold, Foreground = Brushes.White });
                typeStackPanel.Children.Add(new TextBlock { Text = $"{appointment.Date:MMMM d, h:mm tt} - {appointment.Date.AddMinutes(30):h:mm tt}", FontSize = 12, Foreground = Brushes.White });

                var customerStackPanel = new StackPanel { Width = 200 };
                customerStackPanel.Children.Add(new TextBlock { Text = appointment.CustomerName, FontSize = 16, Foreground = Brushes.White });
                customerStackPanel.Children.Add(new TextBlock { Text = $"Phone: {appointment.CustomerPhone}", FontSize = 12, Foreground = Brushes.White });
                customerStackPanel.Children.Add(new TextBlock { Text = $"Email: {appointment.CustomerEmail}", FontSize = 12, Foreground = Brushes.White });

                appointmentStackPanel.Children.Add(typeStackPanel);
                appointmentStackPanel.Children.Add(customerStackPanel);
                appointmentBorder.Child = appointmentStackPanel;

                UpcomingAppointmentsStackPanel.Children.Add(appointmentBorder);
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ListBoxItem selectedItem)
                {
                    string selectedContent = selectedItem.Content.ToString();

                    switch (selectedContent)
                    {
                        case "My Profile":
                            var myProfileWindow = new MyProfileWindow();
                            myProfileWindow.Show();
                            break;
                        case "Appointments":
                            var bookingAppointmentWindow = new BookingAppointmentWindow();
                            bookingAppointmentWindow.Show();
                            this.Close();
                            break;
                        case "Orders":
                            var placeOrderWindow = new AddOrderWindow();
                            placeOrderWindow.Show();
                            this.Close();
                            break;
                        case "Services":
                            var viewServicesWindow = new ViewServicesWindow();
                            viewServicesWindow.Show();
                            break;
                        case "Feedbacks":
                            var addFeedbackWindow = new FeedbackWindow();
                            addFeedbackWindow.Show();
                            break;
                        case "FAQs":
                            var fAQsWindow = new FAQsWindow();
                            fAQsWindow.Show();
                            break;
                        case "Contact Us":
                            var contactUsWindow = new ContactUsWindow();
                            contactUsWindow.Show();
                            break;
                        case "Logout":
                            var logoutWindow = new LogoutWindow();
                            logoutWindow.Show();
                            this.Close();
                            break;
                    }
                }
            }
        }
    }
    public class DashboardData
    {
        public int AppointmentsToday { get; set; }
        public int PlacedOrders { get; set; }
        public List<Appointment> UpcomingAppointments { get; set; }
    }

    public class Appointment
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}
