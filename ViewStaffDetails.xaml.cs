using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class ViewStaffDetailsWindow : Window
    {
        public List<Staff> StaffList { get; set; }

        public ViewStaffDetailsWindow()
        {
            InitializeComponent();
            LoadStaffDetails();
        }

        private void LoadStaffDetails()
        {
            StaffList = new List<Staff>
            {
                new Staff { Name = "John Doe", PhoneNumber = "123-456-7890" },
                new Staff { Name = "Jane Smith", PhoneNumber = "098-765-4321" }
                // Add more staff details here
            };

            StaffDataGrid.ItemsSource = StaffList;
        }

        private void AddNewStaffButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle add new staff logic here
            //MessageBox.Show("Add New Staff button clicked");
            AddStaffWindow addStaffWindow = new AddStaffWindow();
            addStaffWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var staffName = button.Tag as string;
                var staffToDelete = StaffList.FirstOrDefault(s => s.Name == staffName);
                if (staffToDelete != null)
                {
                    StaffList.Remove(staffToDelete);
                    StaffDataGrid.ItemsSource = null; // Reset the ItemsSource to refresh the DataGrid
                    StaffDataGrid.ItemsSource = StaffList;
                }
            }
        }
    }

    public class Staff
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
