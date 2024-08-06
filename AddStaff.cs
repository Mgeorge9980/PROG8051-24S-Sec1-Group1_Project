using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow()
        {
            InitializeComponent();
        }

        private void AddStaffButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the text boxes
            string staffName = StaffNameTextBox.Text;
            string mobileNumber = MobileTextBox.Text;
            string StaffEmail = EmailTextBox.Text;


            // Validate inputs
            if (string.IsNullOrWhiteSpace(staffName) || string.IsNullOrWhiteSpace(mobileNumber))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Implement the logic to save the staff details here
            // For demonstration, we'll just show a message box with the details
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO STAFF_DETAILS (StaffName, StaffEmailID, StaffMobileNumber)VALUES (@StaffName, @StaffEmailID, @StaffMobileNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StaffName", staffName);
                        command.Parameters.AddWithValue("@StaffEmailID", StaffEmail);
                        command.Parameters.AddWithValue("@StaffMobileNumber", mobileNumber);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Staff Added:\n\nName: {staffName}\nMobile Number: {mobileNumber}",
                             "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ViewStaffDetailsWindow vwstf=new ViewStaffDetailsWindow();
                            vwstf.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add staff details.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
           

            // Optionally, clear the input fields after saving
            StaffNameTextBox.Clear();
            MobileTextBox.Clear();
        }
    }
}
