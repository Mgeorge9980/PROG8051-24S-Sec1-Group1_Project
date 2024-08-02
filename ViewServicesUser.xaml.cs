using System.Collections.Generic;
using System.Windows;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for ViewServicesWindow.xaml
    /// </summary>
    public partial class ViewServicesWindow : Window
    {
        public ViewServicesWindow(List<ServiceAdminWindow.Service> services) //Comment
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = services;
        }
    }
}
