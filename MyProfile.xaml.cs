using System.Windows;

namespace StudioManagement
{
    public partial class MyProfileWindow : Window
    {
        public MyProfileWindow()
        {
            InitializeComponent();
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            // Replace these values with actual data retrieval logic
            string userName = "John Doe";
            string phoneNumber = "123-456-7890";
            string emailAddress = "john.doe@example.com";
            string orderDetails = "Order #1234: Camera Lens\nOrder #5678: Tripod Stand";

            UserNameText.Text = userName;
            PhoneNumberText.Text = phoneNumber;
            EmailAddressText.Text = emailAddress;
            OrderDetailsText.Text = orderDetails;
        }
    }
}
