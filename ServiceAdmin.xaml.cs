using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace StudioManagement
{
    /// <summary>
    /// Interaction logic for ServiceAdmin.xaml
    /// </summary>
    public partial class ServiceAdminWindow : Window
    {
        public ServiceAdminWindow()
        {
            InitializeComponent();
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            {
               AddServiceAdmin AddServ=new AddServiceAdmin();
                AddServ.Show();
            }
        }
        public class Service
        {
            public int Number { get; set; }
            public string ServiceName { get; set; }
        }
    }
}

