using System.Data.SqlClient;
using System.Windows;

using System.Windows.Controls;

using System.Windows.Media;



namespace StudioManagement

{

    public partial class SignupService : Window

    {
        public SignupService()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {

            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string mobileNumber = MobileNumberTextBox.Text;
            string email = EmailTextBox.Text;
            DateTime? dateOfBirth = DOBPicker.SelectedDate;
            string password = PasswordTextBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string address = AddressTextBox.Text; // Optional field


            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
            !dateOfBirth.HasValue || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields !! ");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            //string insertQuery = "insert into CUSTOMER (customername)values(@customername)";
            String insertQuery = "INSERT INTO CUSTOMER (CustomerName, MobileNumber, EmailID, DOB, Password, Address) VALUES\r\n(@CustomerName, @MobileNumber, @EmailID ,@DOB, @Password, @Address)";

            // Create a new connection object
            using (SqlConnection connection = new SqlConnection("Server=MERLIN\\SQLEXPRESS19;Database=StudioManagement;User Id=sa;Password=Conestoga1;Trusted_Connection=True;"))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command object
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Define parameters and their values
                        //command.Parameters.AddWithValue("@customername", firstName + " "+lastName);
                        command.Parameters.AddWithValue("@CustomerName", firstName + " " + lastName);
                        command.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        command.Parameters.AddWithValue("@EmailID", email);
                        command.Parameters.AddWithValue("@DOB", dateOfBirth.Value);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Password", password); // Note: Passwords should be hashed and secured

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration done successfully. Kindly login with your credentials !!");
                                this.Close();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while registering the customer. Please try again !!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error: " + ex.Message);
                }

            }

        }
    }
}