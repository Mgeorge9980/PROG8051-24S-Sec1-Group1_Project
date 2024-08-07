using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace StudioManagement
{
    public partial class ViewRatingsWindow : Window
    {
        public ViewRatingsWindow()
        {
            InitializeComponent();
            LoadFeedbackData();
        }

        private void LoadFeedbackData()
        {
            List<Feedback> feedbackList = new List<Feedback>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString))
            {
                connection.Open();
                string query = "select CustomerName,FeedbackText,FeedbackRating from FEEDBACK fd JOIN CUSTOMER cu on fd.CustomerID=cu.CustomerID"; // Adjust the query if needed
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            feedbackList.Add(new Feedback
                            {
                                CustomerName = reader["CustomerName"].ToString(), // Assuming CustomerID is used as CustomerName
                                FeedbackRating = (int)reader["FeedbackRating"],
                                FeedbackText = reader["FeedbackText"].ToString()
                            });
                        }
                    }
                }
            }

            RatingsDataGrid.ItemsSource = feedbackList; // Bind the data to the DataGrid
        }
    }

    public class Feedback
    {
        public string CustomerName { get; set; }
        public int FeedbackRating { get; set; }
        public string FeedbackText { get; set; }
    }
}
