using System.Diagnostics;
using System.Windows;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for ContactUsWindow.xaml
    /// </summary>
    public partial class ContactUsWindow : Window
    {
        public ContactUsWindow()
        {
            InitializeComponent();
        }

        private void ViewMapButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Google Maps link in the default web browser
            string url = "https://www.google.com/maps/dir//200+Highland+Rd+W+%2388,+Kitchener,+ON+N2M+3C2/@43.4407745,-80.5887953,12z/data=!4m8!4m7!1m0!1m5!1m1!1s0x882bf44d9c445e21:0x2de5c61adcaf235a!2m2!1d-80.506395!2d43.4408038?entry=ttu";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
