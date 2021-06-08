using Classes;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for StaticMove.xaml
    /// </summary>
    public partial class StaticMove : Window
    {
        static RoomController roomController = new RoomController();
        EquipmentController equipmentController = new EquipmentController();
        EnschedulementController enschedulementController = new EnschedulementController();
        List<Room> rooms = roomController.roomService.roomRepository.GetAll();

        public StaticMove()
        {
            InitializeComponent();
            foreach (Room r in rooms)
            {
                fromRoomCombo.Items.Add(r.RoomNumber);
            }
        }

        private void fromRoomCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<StaticEquipment> allStatic = new List<StaticEquipment>();
            allStatic = equipmentController.GetAllStatic();
            chooseItemDataList.Items.Clear();
            foreach (StaticEquipment s in allStatic)
            {
                if (s.statLocation == fromRoomCombo.SelectedItem.ToString())
                    chooseItemDataList.Items.Add(new { staticId = s.statId, staticName = s.statName });
            }

            toRoomCombo.Items.Clear();
            foreach (Room r in rooms)
            {
                if (r.RoomNumber != fromRoomCombo.SelectedItem.ToString())
                    toRoomCombo.Items.Add(r.RoomNumber);
            }
        }

        private void createEnschedulement_Click(object sender, RoutedEventArgs e)
        {
            //id je hard code-ovan
            enschedulementController.enschedulementService.enschedulementRepository.enschedulementRepository.Enschedulements = enschedulementController.GetAll();
            Room fromRoom = new Room();
            fromRoom = roomController.GetById(fromRoomCombo.SelectedItem.ToString());
            Room toRoom = new Room();
            toRoom = roomController.GetById(toRoomCombo.SelectedItem.ToString());
            
            string[] parts = chooseItemDataList.SelectedItem.ToString().Split(',');
            string[] parts2 = parts[0].Split(' ');
            String toCreate = parts2[3];
            StaticEquipment equipment = equipmentController.GetStaticById(toCreate);
            DateTime date = DateTime.Parse(moveItemDate.Text);
            StaticEnschedulement newEnschedulement = new StaticEnschedulement(date, fromRoom, toRoom, equipment, 1);
            bool success = enschedulementController.CreateEnschedulement(newEnschedulement);
            if (!success)
                MessageBox.Show("Date Already Taken!");
            this.Hide();
        }
    }
}
