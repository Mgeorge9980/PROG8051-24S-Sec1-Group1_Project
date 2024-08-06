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
            string url = "https://www.google.com/maps/dir//Conestoga+College+Waterloo+Campus,+University+Avenue,+Waterloo,+ON/@43.4793751,-80.6004098,12z/data=!3m1!5s0x882bf38c63ed2699:0x86c1820d5770c7ba!4m8!4m7!1m0!1m5!1m1!1s0x882bf31d0cec9491:0x8bf5f60c306d2207!2m2!1d-80.5180089!2d43.4794047?entry=ttu";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
