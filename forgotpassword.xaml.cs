using System;
using System.Windows;

namespace StudioManagement
{
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            DateTime? dob = DOBPicker.SelectedDate;

            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Please enter your first name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dob == null)
            {
                MessageBox.Show("Please select your date of birth.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Perform password reset logic here
            // ...

            MessageBox.Show("Password reset instructions have been sent to your email.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
