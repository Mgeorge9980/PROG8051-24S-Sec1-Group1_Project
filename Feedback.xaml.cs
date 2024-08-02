using System.Windows;
using System.Windows.Controls;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for AddFeedbackWindow.xaml
    /// </summary>
    public partial class AddFeedbackWindow : Window
    {
        public AddFeedbackWindow()
        {
            InitializeComponent();
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input values from the controls
            string rating = (RatingComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string comment = CommentTextBox.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(rating) || string.IsNullOrWhiteSpace(comment))
            {
                MessageBox.Show("Please provide a rating and a comment.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Implement the logic to save the feedback here
            // For demonstration, we'll just show a message box with the feedback details
            MessageBox.Show($"Feedback Posted:\n\nRating: {rating}\nComment: {comment}",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, clear the inputs after posting
            RatingComboBox.SelectedIndex = -1;
            CommentTextBox.Clear();
        }
    }
}
