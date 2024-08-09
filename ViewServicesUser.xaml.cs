using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for ViewServicesWindow.xaml
    /// </summary>
    public partial class ViewServicesWindow : Window
    {
        public ViewServicesWindow() //Comment
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = GetService();
        }
        public List<ServiceAdminWindow.Service> GetService()
        {
            List<ServiceAdminWindow.Service> ServicesList = new List<ServiceAdminWindow.Service>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                connection.Open();
                string query = "select ServiceID,ServiceName,ServicePrice from Service";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ServiceAdminWindow.Service product = new ServiceAdminWindow.Service
                        {
                            Number = reader.GetInt32(0),
                            ServiceName = reader.GetString(1),
                            ServicePrice = reader.GetDecimal(2).ToString(),

                        };
                        ServicesList.Add(product);
                    }
                }
            }

            return ServicesList;
        }

        private void ServicesDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
