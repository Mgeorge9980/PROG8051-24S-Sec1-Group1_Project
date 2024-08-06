using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class StaffScheduleWindow : Window
    {
        public StaffScheduleWindow()
        {
            InitializeComponent();
            LoadScheduleData();
            LoadStaffNames();
        }
        private void LoadStaffNames()
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT StaffID, StaffName FROM STAFF_DETAILS"; // Adjust your query as needed
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<StaffDetails> staffList = new List<StaffDetails>();
                            while (reader.Read())
                            {
                                StaffDetails staff = new StaffDetails
                                {
                                    StaffID = reader.GetInt32(0),
                                    StaffName = reader.GetString(1)
                                };
                                staffList.Add(staff);
                            }

                            staffNameComboBox.ItemsSource = staffList;
                            staffNameComboBox.DisplayMemberPath = "StaffName";
                            staffNameComboBox.SelectedValuePath = "StaffID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading staff names: " + ex.Message);
            }
        }
        private void LoadScheduleData()
        {
            // Initialize the schedule with days of the week
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT s.ScheduleID, s.ScheduledDay, st.StaffName FROM Staff_Schedule s JOIN Staff_Details st ON s.StaffID = st.StaffID"; // Adjust your query as needed
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<ScheduleItem> scheduleList = new List<ScheduleItem>();
                            while (reader.Read())
                            {
                                ScheduleItem schedule = new ScheduleItem
                                {
                                    ScheduleID = reader.GetInt32(0),
                                    ScheduledDay = reader.GetString(1),
                                    StaffName = reader.GetString(2)
                                };
                                scheduleList.Add(schedule);
                            }

                            scheduleDataGrid.ItemsSource = scheduleList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading schedules: " + ex.Message);
            }
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
            if (staffNameComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a staff member.");
                return;
            }

            if (dayComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a day.");
                return;
            }

            int staffID = (int)staffNameComboBox.SelectedValue;
            string scheduledDay = (dayComboBox.SelectedItem as ComboBoxItem).Content.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Staff_Schedule (StaffID, ScheduledDay) VALUES (@StaffID, @ScheduledDay)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@StaffID", staffID);
                        insertCommand.Parameters.AddWithValue("@ScheduledDay", scheduledDay);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Schedule added successfully.");
                            LoadScheduleData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add schedule.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void deleteSchedBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int scheduleID = (int)button.Tag;


            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Staff_Schedule WHERE ScheduleID = @ScheduleID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ScheduleID", scheduleID);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Schedule deleted successfully.");
                            LoadScheduleData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete schedule.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Class to represent a schedule item
        public class ScheduleItem
        {
            public int? ScheduleID {get;set;}
            public string? ScheduledDay { get; set; }
            public string? StaffName { get; set; }
        }

        
    }
}
