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
            MessageBox.Show($"Staff Added:\n\nName: {staffName}\nMobile Number: {mobileNumber}",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, clear the input fields after saving
            StaffNameTextBox.Clear();
            MobileTextBox.Clear();
        }
    }
}
