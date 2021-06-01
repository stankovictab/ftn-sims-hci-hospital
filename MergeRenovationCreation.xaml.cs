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
    /// Interaction logic for MergeRenovationCreation.xaml
    /// </summary>
    public partial class MergeRenovationCreation : Window
    {
        RoomController roomController = new RoomController();
        AdvancedRenovationController advancedRenovationController = new AdvancedRenovationController();
        public MergeRenovationCreation()
        {
            InitializeComponent();
            List<Room> rooms = roomController.roomService.roomRepository.GetAll();
            foreach (Room r in rooms)
            {
                toMergeRoomCombo1.Items.Add(r.RoomNumber);
            }
        }

        private void toMergeRoomCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toMergeRoomCombo2.Items.Clear();
            List<Room> rooms = roomController.roomService.roomRepository.GetAll();
            foreach (Room r in rooms)
            {
                if (r.RoomNumber != toMergeRoomCombo1.SelectedItem.ToString())
                    toMergeRoomCombo2.Items.Add(r.RoomNumber);
            }
        }

        private void enscheduleMerge_Click(object sender, RoutedEventArgs e)
        {
            RoomType newType = new RoomType();
            if ((bool)operating.IsChecked)
                newType = RoomType.Operating;
            else if ((bool)checkup.IsChecked)
                newType = RoomType.Checkup;
            else if ((bool)therapy.IsChecked)
                newType = RoomType.Therapy;

            Room newRoom = new Room(roomNumber.Text, Convert.ToInt32(roomFloor.Text), roomDescription.Text, newType);
            newRoom.Status = RoomStatus.Reordering;
            roomController.Create(newRoom);

            advancedRenovationController.advancedRenovationService.advancedMergeRenovationRepository.MergeRenovations = advancedRenovationController.GetAllMerge();
            MergeRenovation newMergeRenovation = new MergeRenovation(Convert.ToInt32(mergeRenovationId.Text), Convert.ToDateTime(mergeRenovationStartTime.Text), Convert.ToDateTime(mergeRenovationEndTime.Text), roomController.GetById(toMergeRoomCombo1.SelectedItem.ToString()), roomController.GetById(toMergeRoomCombo2.SelectedItem.ToString()), newRoom);
            bool success = advancedRenovationController.CreateMerge(newMergeRenovation);

            if (!success)
                MessageBox.Show("Room is already busy at that time");

            this.Hide();
        }
    }
}
