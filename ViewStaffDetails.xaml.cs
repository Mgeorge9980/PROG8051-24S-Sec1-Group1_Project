using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class ViewStaffDetailsWindow : Window
    {

        public ViewStaffDetailsWindow()
        {
            InitializeComponent();
            LoadStaffDetails();
        }

        private void LoadStaffDetails()
        {
            List<StaffDetails> staffList = new List<StaffDetails>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT StaffID, StaffName, StaffEmailID, StaffMobileNumber FROM STAFF_DETAILS";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StaffDetails staff = new StaffDetails
                                {
                                    StaffID = reader.GetInt32(0),
                                    StaffName = reader.GetString(1),
                                    StaffEmailID = reader.GetString(2),
                                    StaffMobileNumber = reader.GetString(3)
                                };
                                staffList.Add(staff);
                            }
                        }
                    }
                }

                StaffDataGrid.ItemsSource = staffList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void AddNewStaffButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle add new staff logic here
            //MessageBox.Show("Add New Staff button clicked");
            AddStaffWindow addStaffWindow = new AddStaffWindow();
            addStaffWindow.Show();
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int staffID)
            {


                try
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
                    {
                        connection.Open();

                        // Start a transaction
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Delete from Staff_Schedule table
                                string deleteScheduleQuery = "DELETE FROM Staff_Schedule WHERE StaffID = @StaffID";
                                using (SqlCommand deleteScheduleCommand = new SqlCommand(deleteScheduleQuery, connection, transaction))
                                {
                                    deleteScheduleCommand.Parameters.AddWithValue("@StaffID", staffID);
                                    deleteScheduleCommand.ExecuteNonQuery();
                                }

                                // Delete from Staff table
                                string deleteStaffQuery = "DELETE FROM STAFF_DETAILS WHERE StaffID = @StaffID";
                                using (SqlCommand deleteStaffCommand = new SqlCommand(deleteStaffQuery, connection, transaction))
                                {
                                    deleteStaffCommand.Parameters.AddWithValue("@StaffID", staffID);
                                    deleteStaffCommand.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();
                                MessageBox.Show("Staff and their schedule deleted successfully.");
                                LoadStaffDetails();
                            }
                            catch (Exception ex)
                            {
                                // Rollback the transaction if there was an error
                                transaction.Rollback();
                                MessageBox.Show("An error occurred while deleting the staff and their schedule: " + ex.Message);
                            }
                        }
                    }

                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid staff ID.");
            }
        }
    }
    public class StaffDetails
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffEmailID { get; set; }
        public string StaffMobileNumber { get; set; }
    }
}





