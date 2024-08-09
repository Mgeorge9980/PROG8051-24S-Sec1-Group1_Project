using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Configuration;

namespace StudioManagement
{
    public partial class AdminDashboardWindow : Window
    {
        public AdminDashboardWindow()
        {
            InitializeComponent();
            LoadAdminDashboardData();
        }
        private void LoadAdminDashboardData()
        {
            DataAccess dataAccess = new DataAccess();
            AdminDashboardData dashboardData = dataAccess.GetAdminDashboardData();

            // Bind counts
            AppointmentsToday.Text = dashboardData.AppointmentsToday.ToString();
            OrdersToday.Text = dashboardData.OrdersToday.ToString();
            TotalCustomers.Text = dashboardData.TotalCustomers.ToString();

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
        public class DataAccess
        {
            private string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;

            public AdminDashboardData GetAdminDashboardData()
            {
                AdminDashboardData data = new AdminDashboardData();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    data.AppointmentsToday = GetCount(connection, "SELECT COUNT(*) FROM APPOINTMENT WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)");
                    data.OrdersToday = GetCount(connection, "SELECT COUNT(*) FROM CUSTOMER_ORDER WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)");
                    data.TotalCustomers = GetCount(connection, "SELECT COUNT(*) FROM Customer");
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

                string query = "SELECT s.ServiceName,a.AppointmentDate,cu.CustomerName,cu.MobileNumber,cu.EmailID FROM APPOINTMENT a inner join SERVICE s on a.ServiceID=s.ServiceID inner join CUSTOMER cu on a.CustomerID= cu.CustomerID where AppointmentDate >= GETDATE() ORDER BY AppointmentDate";


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
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ListBoxItem selectedItem)
                {
                    string selectedContent = selectedItem.Content.ToString();

                    switch (selectedContent)
                    {
                      
                        case "My Customers":
                            var myCustomerWindow = new MyCustomerWindow();
                            myCustomerWindow.Show();
                            break;
                        case "Appointments":
                            var ViewAppointmentWindow = new ViewAppointmentWindow();
                            ViewAppointmentWindow.Show();
                            break;
                        case "Orders":
                            var OrderWind = new ListOrdersWindow();
                            OrderWind.Show();
                            break;
                        case "Order Category":
                            var ListCategories = new ListCategoriesWindow();
                            ListCategories.Show();
                            break;
                        case "Services":
                            var ServiceAdminWindow = new ServiceAdminWindow();
                            ServiceAdminWindow.Show();
                            break;
                        case "Staff Schedule":
                            var StaffScheduleWindow = new StaffScheduleWindow();
                            StaffScheduleWindow.Show();
                            break;
                        case "Staff Details":
                            var ViewStaffDetailsWindow = new ViewStaffDetailsWindow();
                            ViewStaffDetailsWindow.Show();
                            break;
                        case "Feedbacks":
                            var ViewRatingsWindow = new ViewRatingsWindow();
                            ViewRatingsWindow.Show();
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
    public class AdminDashboardData
    {
        public int AppointmentsToday { get; set; }
        public int OrdersToday { get; set; }
        public int TotalCustomers { get; set; }
        public List<Appointment> UpcomingAppointments { get; set; }
    }

    
}
