using System.Windows;

namespace StudioManagement
{
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow()
        {
            InitializeComponent();
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the text boxes
            string staffName = StaffNameTextBox.Text;
            string email = MobileTextBox.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(staffName) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Implement the logic to save the staff details here
            // For demonstration, we'll just show a message box with the details
            MessageBox.Show($"Staff Added:\n\nName: {staffName}\nEmail: {email}",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, clear the input fields after saving
            StaffNameTextBox.Clear();
            MobileTextBox.Clear();
        }
    }
}
