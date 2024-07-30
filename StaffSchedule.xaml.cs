using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class StaffScheduleWindow : Window
    {
        public StaffScheduleWindow()
        {
            InitializeComponent();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected staff name and day
            var selectedStaff = staffNameComboBox.SelectedItem as ComboBoxItem;
            var selectedDay = dayComboBox.SelectedItem as ComboBoxItem;

            if (selectedStaff != null && selectedDay != null)
            {
                string staffName = selectedStaff.Content.ToString();
                string dayName = selectedDay.Content.ToString();

                // Here you can implement the logic for setting the staff schedule
                MessageBox.Show($"Schedule set for {staffName} on {dayName}.", "Schedule Set", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select both staff and day.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
