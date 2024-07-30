using System.Collections.Generic;
using System.Windows;

namespace StudioManagement
{
    public partial class ViewRatingsWindow : Window
    {
        public ViewRatingsWindow()
        {
            InitializeComponent();
            LoadRatings();
        }

        private void LoadRatings()
        {
            List<CustomerRating> ratings = new List<CustomerRating>
            {
                new CustomerRating { CustomerName = "John Doe", Rating = 5, Comment = "Excellent service!" },
                new CustomerRating { CustomerName = "Jane Smith", Rating = 4, Comment = "Very good experience." },
                new CustomerRating { CustomerName = "Sam Brown", Rating = 3, Comment = "Average service." }
                // Add more sample data or load from a data source
            };

            RatingsDataGrid.ItemsSource = ratings;
        }
    }

    public class CustomerRating
    {
        public string CustomerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
