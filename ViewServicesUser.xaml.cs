using System.Collections.Generic;
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

            using (SqlConnection connection = new SqlConnection("Server=SHILPA-PC\\SQLEXPRESS19;Database=StudioManagement;User Id=sa;Password=Conestoga1;Trusted_Connection=True;"))
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
                            Number =Convert.ToInt32( reader.GetString(0)),
                            ServiceName = reader.GetString(1),
                            ServicePrice = reader.GetString(2),

                        };
                        ServicesList.Add(product);
                    }
                }
            }

            return ServicesList;
        }
    }
}
