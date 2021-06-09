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
    /// Interaction logic for SplitRenovationCreation.xaml
    /// </summary>
    public partial class SplitRenovationCreation : Window
    {
        RoomController roomController = new RoomController();
        AdvancedRenovationController advancedRenovationController = new AdvancedRenovationController();
        public SplitRenovationCreation()
        {
            InitializeComponent();
            List<Room> rooms = roomController.roomService.roomRepository.GetAll();
            List<RoomType> types = new List<RoomType>();
            types.Add(RoomType.Checkup);
            types.Add(RoomType.Operating);
            types.Add(RoomType.Therapy);

            foreach (Room r in rooms)
            {
                toSplitRoomCombo.Items.Add(r.RoomNumber);
            }

            foreach (RoomType type in types)
            {
                newRoom1TypeCombo.Items.Add(type);
                newRoom2TypeCombo.Items.Add(type);
            }
        }

        public RoomType ParseType(string input)
        {
            RoomType newType = new RoomType();
            if (input == "Operating")
                newType = RoomType.Operating;
            else if (input == "Checkup")
                newType = RoomType.Checkup;
            else if (input == "Therapy")
                newType = RoomType.Therapy;

            return newType;
        }

        private void enscheduleSplit_Click(object sender, RoutedEventArgs e)
        {
            Room newRoom1 = new Room(newRoom1Number.Text, Convert.ToInt32(newRoom1Floor.Text), newRoom1Description.Text, ParseType(newRoom1TypeCombo.SelectedItem.ToString()));
            newRoom1.Status = RoomStatus.Reordering;
            roomController.Create(newRoom1);

            Room newRoom2 = new Room(newRoom2Number.Text, Convert.ToInt32(newRoom2Floor.Text), newRoom2Description.Text, ParseType(newRoom2TypeCombo.SelectedItem.ToString()));
            newRoom2.Status = RoomStatus.Reordering;
            roomController.Create(newRoom2);

            advancedRenovationController.advancedRenovationService.advancedSplitRenovationRepository.SplitRenovations = advancedRenovationController.GetAllSplit();
            SplitRenovation newSplitRenovation = new SplitRenovation(Convert.ToInt32(splitRenovationId.Text), Convert.ToDateTime(splitRenovationStartTime.Text), Convert.ToDateTime(splitRenovationEndTime.Text), roomController.GetById(toSplitRoomCombo.SelectedItem.ToString()), newRoom1, newRoom2);
            bool success = advancedRenovationController.CreateSplit(newSplitRenovation);

            if (!success)
                MessageBox.Show("Room is already busy at that time");

            this.Hide();
        }
    }
}
