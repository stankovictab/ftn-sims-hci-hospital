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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for BasicRenovationsPage.xaml
    /// </summary>
    public partial class BasicRenovationsPage : Page
    {
        BasicRenovationController basicRenovationController = new BasicRenovationController();

        public BasicRenovationsPage()
        {
            InitializeComponent();
            //basicRenovationController.UpdateTime(DateTime.Now);
            List<BasicRenovation> allRenovations = basicRenovationController.GetAll();
        }

        private void addBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            Window basicRenovationCreation = new BasicRenovationCreation();
            basicRenovationCreation.ShowDialog();
        }

        private void viewBasicRenovations_Click(object sender, RoutedEventArgs e)
        {
            List<BasicRenovation> allBasicRenovations = new List<BasicRenovation>();
            allBasicRenovations = basicRenovationController.GetAll();
            basicRenovationDataList.Items.Clear();
            foreach (BasicRenovation r in allBasicRenovations)
            {
                basicRenovationDataList.Items.Add(new { renovationId = r.Id.ToString(), renovationRoom = r.Room.RoomNumber, renovationTime = r.DateTime.ToString(), renovationDuration = r.Duration.ToString() });
            }
        }

        private void deleteBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            if (!basicRenovationDataList.Items.IsEmpty && basicRenovationDataList.SelectedItem != null)
            {
                string[] parts = basicRenovationDataList.SelectedItem.ToString().Split(',');
                string[] parts2 = parts[0].Split(' ');
                int toDelete = Convert.ToInt32(parts2[3]);
                _ = basicRenovationController.Delete(toDelete);
                basicRenovationController.UpdateFile(basicRenovationController.basicRenovationService.basicRenovationRepository.BasicRenovations);
                viewBasicRenovations.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            }
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

        private void medicineMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MedicineWindowPage page = new MedicineWindowPage();
            this.Content = new Frame() { Content = page };
        }

        private void signoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
