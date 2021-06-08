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

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for Storage.xaml
    /// </summary>
    public partial class Storage : Window
    {
        EquipmentController equipmentController = new EquipmentController();
        RoomController roomController = new RoomController();

        public Storage()
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
    }
}
