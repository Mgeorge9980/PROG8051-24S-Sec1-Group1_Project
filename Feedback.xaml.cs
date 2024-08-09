using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    public partial class FeedbackWindow : Window
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        private int CustomerID = Properties.Settings.Default.UserID;

        public FeedbackWindow()
        {
            InitializeComponent();
        }

        private void SubmitFeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            int feedbackRating;
            ComboBoxItem selectedRatingItem = FeedbackRatingComboBox.SelectedItem as ComboBoxItem;

            if (selectedRatingItem == null || !int.TryParse(selectedRatingItem.Tag.ToString(), out feedbackRating))
            {
                MessageBox.Show("Please select a valid feedback rating.");
                return;
            }

            string feedbackText = FeedbackTextBox.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO FEEDBACK (CustomerID, FeedbackText, FeedbackRating, ResponseStatus) VALUES (@CustomerID, @FeedbackText, @FeedbackRating, @ResponseStatus)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@FeedbackText", feedbackText);
                    cmd.Parameters.AddWithValue("@FeedbackRating", feedbackRating);
                    cmd.Parameters.AddWithValue("@ResponseStatus", "submitted");

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Feedback submitted successfully.");
                        FeedbackTextBox.Clear();
                        FeedbackRatingComboBox.SelectedIndex = -1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while submitting your feedback.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
