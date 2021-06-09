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
    /// Interaction logic for StaticSchedulePage.xaml
    /// </summary>
    public partial class StaticSchedulePage : Page
    {
        EnschedulementController enschedulementController = new EnschedulementController();

        public StaticSchedulePage()
        {
            InitializeComponent();
            //enschedulementController.UpdateTime(DateTime.Now);

            List<StaticEnschedulement> allEnschedulements = new List<StaticEnschedulement>();
            allEnschedulements = enschedulementController.GetAll();

            List<StaticEnschedulement> allFinishedEnschedulements = new List<StaticEnschedulement>();
            allFinishedEnschedulements = enschedulementController.GetAllFinished();

            scheduleDataList.Items.Clear();
            movedDataList.Items.Clear();
            //ciscenje fajla
        }

       
        private void staticMove_Click(object sender, RoutedEventArgs e)
        {
            Window staticMove = new StaticMove();
            staticMove.ShowDialog();
        }

        private void triggerMoveButton_Click(object sender, RoutedEventArgs e)
        {
            List<StaticEnschedulement> moved = new List<StaticEnschedulement>();

            movedDataList.Items.Clear();
            foreach (StaticEnschedulement s in moved)
            {
                movedDataList.Items.Add(new { time = s.Time.ToString(), fromRoom = s.FromRoom.RoomNumber, toRoom = s.ToRoom.RoomNumber, equipment = s.MovedEquipment.statName });
                scheduleDataList.Items.Remove(new { time = s.Time.ToString(), fromRoom = s.FromRoom.RoomNumber, toRoom = s.ToRoom.RoomNumber, equipment = s.MovedEquipment.statName });
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
