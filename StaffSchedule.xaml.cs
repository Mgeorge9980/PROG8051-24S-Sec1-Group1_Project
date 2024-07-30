using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class StaffScheduleWindow : Window
    {
        // A list to hold the schedule
        private List<ScheduleItem> schedule;

        public StaffScheduleWindow()
        {
            InitializeComponent();
            InitializeSchedule();
        }

        private void InitializeSchedule()
        {
            // Initialize the schedule with days of the week
            schedule = new List<ScheduleItem>
            {
                new ScheduleItem { Day = "Monday", Staff = "Not Assigned" },
                new ScheduleItem { Day = "Tuesday", Staff = "Not Assigned" },
                new ScheduleItem { Day = "Wednesday", Staff = "Not Assigned" },
                new ScheduleItem { Day = "Thursday", Staff = "Not Assigned" },
                new ScheduleItem { Day = "Friday", Staff = "Not Assigned" }
            };

            scheduleDataGrid.ItemsSource = schedule; // Bind the DataGrid to the schedule list
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
            // Get selected staff name
            var selectedStaff = staffNameComboBox.SelectedItem as ComboBoxItem;

            if (selectedStaff != null)
            {
                string staffName = selectedStaff.Content.ToString();

                // Update the schedule for the selected day
                foreach (var item in schedule)
                {
                    if (item.Staff == "Not Assigned") // Check for the first unassigned day
                    {
                        item.Staff = staffName; // Assign the selected staff
                        break; // Exit after assigning
                    }
                }

                scheduleDataGrid.Items.Refresh(); // Refresh the DataGrid to show the updated schedule

                // Display confirmation message
                MessageBox.Show($"Schedule set for {staffName}.", "Schedule Set", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a staff member.", "Error", MessageBoxButton.OK);
            }
        }

        // Class to represent a schedule item
        public class ScheduleItem
        {
            public string? Day { get; set; }
            public string? Staff { get; set; }
        }
    }
}
