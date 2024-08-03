using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using static StudioManagement.MyProfileWindow;

namespace StudioManagement
{
    public partial class MyProfileWindow : Window
    {
        public MyProfileWindow()
        {
            InitializeComponent();
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {

            CustomerDetails customer = GetCustomer();
            UserNameText.Text = customer.Name;
            PhoneNumberText.Text = customer.PhoneNumber;
            EmailAddressText.Text = customer.EmailAddress;
            ;
        }
        public CustomerDetails GetCustomer()
        {
            CustomerDetails Cust = new CustomerDetails();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                connection.Open();
                string query = "select CustomerName,MobileNumber,EmailID from CUSTOMER where CustomerID=@CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", Properties.Settings.Default.UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cust = new CustomerDetails
                        {
                            Name = reader.GetString(0),
                            PhoneNumber = reader.GetString(1),

                        };

                    }

                }
            }
            return Cust;
        }
    }
    public class CustomerDetails
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
