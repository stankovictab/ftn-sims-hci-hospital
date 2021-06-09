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
using ftn_sims_hci_hospital;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for ManagerNew.xaml
    /// </summary>
    public partial class ManagerNew : Window
    {
        public ManagerNew()
        {
            InitializeComponent();
        }

        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            StoragePage inventoryPage = new StoragePage();
            this.Content = new Frame() { Content = inventoryPage };
        }

        private void roomsButton_Click(object sender, RoutedEventArgs e)
        {
            RoomsPage roomPage = new RoomsPage();
            this.Content = new Frame() { Content = roomPage };
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            StaticSchedulePage schedulePage = new StaticSchedulePage();
            this.Content = new Frame() { Content = schedulePage };
        }

        private void basicRenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            BasicRenovationsPage page = new BasicRenovationsPage();
            this.Content = new Frame() { Content = page };
        }

        private void advancedRenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            AdvancedRenovationsPage page = new AdvancedRenovationsPage();
            this.Content = new Frame() { Content = page };
        }

        private void profilButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage page = new ProfilePage();
            this.Content = new Frame() { Content = page };
        }

        private void changeColor_Click(object sender, RoutedEventArgs e)
        {
            if (managerNewGrid.Background == Brushes.White)
            {
                managerNewGrid.Background = Brushes.Black;
            }
            else
                managerNewGrid.Background = Brushes.White;
        }

        private void signoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
