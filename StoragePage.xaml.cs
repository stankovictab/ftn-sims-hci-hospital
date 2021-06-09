using Classes;
using ftn_sims_hci_hospital.View;
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
    /// Interaction logic for StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        EquipmentController equipmentController = new EquipmentController();
        RoomController roomController = new RoomController();

        public StoragePage()
        {
            InitializeComponent();

            storageDataList.Items.Clear();

            List<DynamicEquipment> allDynamic = new List<DynamicEquipment>();
            List<Room> allRooms = new List<Room>();
            allDynamic = equipmentController.GetAllDynamic();
            allRooms = roomController.GetAll();

            foreach (DynamicEquipment d in allDynamic)
            {
                storageDataList.Items.Add(new { equipmentId = d.Id, equipmentName = d.Name, equipmentLocation = "Main Storage", equipmentType = "Dynamic" });
            }

            List<StaticEquipment> allStatic = equipmentController.GetAllStatic();
            foreach (StaticEquipment s in allStatic)
            {
                storageDataList.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentLocation = s.statLocation, equipmentType = "Static" });
            }

            foreach (Room r in allRooms)
            {
                locationCombo.Items.Add(r.RoomNumber);
            }
            locationCombo.Items.Add("Main Storage");

            typeCombo.Items.Add("Static");
            typeCombo.Items.Add("Dynamic");
        }

        private void loadStorageButton_Click(object sender, RoutedEventArgs e)
        {
            storageDataList.Items.Clear();

            List<DynamicEquipment> allDynamic = new List<DynamicEquipment>();
            List<Room> allRooms = new List<Room>();
            allDynamic = equipmentController.GetAllDynamic();
            allRooms = roomController.GetAll();

            foreach (DynamicEquipment d in allDynamic)
            {
                storageDataList.Items.Add(new { equipmentId = d.Id, equipmentName = d.Name, equipmentLocation = "Main Storage", equipmentType = "Dynamic" });
            }

            List<StaticEquipment> allStatic = equipmentController.GetAllStatic();
            foreach (StaticEquipment s in allStatic)
            {
                storageDataList.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentLocation = s.statLocation, equipmentType = "Static" });
            }

        }

        private void locationCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            storageDataList.Items.Clear();

            List<StaticEquipment> allStatic = new List<StaticEquipment>();
            allStatic = equipmentController.GetAllStatic();
            List<DynamicEquipment> allDynamic = new List<DynamicEquipment>();
            allDynamic = equipmentController.GetAllDynamic();

            foreach (StaticEquipment s in allStatic)
            {
                if (s.statLocation == locationCombo.SelectedItem.ToString())
                    storageDataList.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentLocation = s.statLocation, equipmentType = "Static" });
            }

            if (locationCombo.SelectedItem.ToString() == "Main Storage")
            {
                foreach (DynamicEquipment d in allDynamic)
                {
                    storageDataList.Items.Add(new { equipmentId = d.Id, equipmentName = d.Name, equipmentLocation = "Main Storage", equipmentType = "Dynamic" });
                }
            }
        }

        private void typeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            storageDataList.Items.Clear();

            List<StaticEquipment> allStatic = new List<StaticEquipment>();
            allStatic = equipmentController.GetAllStatic();
            List<DynamicEquipment> allDynamic = new List<DynamicEquipment>();
            allDynamic = equipmentController.GetAllDynamic();

            if (typeCombo.SelectedItem.ToString() == "Static")
            {
                foreach (StaticEquipment s in allStatic)
                {
                    storageDataList.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentLocation = s.statLocation, equipmentType = "Static" });
                }
            }

            if (typeCombo.SelectedItem.ToString() == "Dynamic")
            {
                foreach (DynamicEquipment d in allDynamic)
                {
                    storageDataList.Items.Add(new { equipmentId = d.Id, equipmentName = d.Name, equipmentLocation = "Main Storage", equipmentType = "Dynamic" });
                }
            }
        }

        private void nameSearchButton_Click(object sender, RoutedEventArgs e)
        {
            storageDataList.Items.Clear();

            List<StaticEquipment> allStatic = new List<StaticEquipment>();
            allStatic = equipmentController.GetAllStatic();
            List<DynamicEquipment> allDynamic = new List<DynamicEquipment>();
            allDynamic = equipmentController.GetAllDynamic();

            foreach (StaticEquipment s in allStatic)
            {
                if (s.statName == nameSearchTextBox.Text)
                    storageDataList.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentLocation = s.statLocation, equipmentType = "Static" });
            }

            foreach (DynamicEquipment d in allDynamic)
            {
                if (d.Name == nameSearchTextBox.Text)
                    storageDataList.Items.Add(new { equipmentId = d.Id, equipmentName = d.Name, equipmentLocation = "Main Storage", equipmentType = "Dynamic" });
            }
        }

        private void _static_Click(object sender, RoutedEventArgs e)
        {
            Window Static = new Static();
            Static.ShowDialog();
        }

        private void dynamic_Click(object sender, RoutedEventArgs e)
        {
            Window Dynamic = new Dynamic();
            Dynamic.ShowDialog();
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
