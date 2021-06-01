using Classes;
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

namespace ftn_sims_hci_hospital.HCI
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public Manager()
        {
            InitializeComponent();
        }

 
        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            Inventory inventoryPage = new Inventory();
            this.Content = new Frame() { Content = inventoryPage};
        }

        private void roomsButton_Click(object sender, RoutedEventArgs e)
        {
            Rooms roomPage = new Rooms();
            this.Content = new Frame() { Content = roomPage };
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedulePage = new Schedule();
            this.Content = new Frame() { Content = schedulePage };
        }

        private void orderingButton_Click(object sender, RoutedEventArgs e)
        {
            Orders ordersPage = new Orders();
            this.Content = new Frame() { Content = ordersPage };
        }
    }
}
