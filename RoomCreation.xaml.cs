using Classes;
using ftn_sims_hci_hospital.Classes;
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
    public partial class RoomCreation : Window
    {
        RoomController roomController = new RoomController();
        public RoomCreation()
        {
            InitializeComponent();
            List<RoomType> types = new List<RoomType>();
            types.Add(RoomType.Checkup);
            types.Add(RoomType.Operating);
            types.Add(RoomType.Therapy);

            foreach (RoomType type in types)
            {
                roomTypeCombo.Items.Add(type);
            }
        }

        private void btnCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomType newType = new RoomType();
            if (roomTypeCombo.SelectedItem.ToString() == "Operating")
                newType = RoomType.Operating;
            else if (roomTypeCombo.SelectedItem.ToString() == "Checkup")
                newType = RoomType.Checkup;
            else if (roomTypeCombo.SelectedItem.ToString() == "Therapy")
                newType = RoomType.Therapy;

            Room newRoom = new Room(roomNumber.Text, Convert.ToInt32(roomFloor.Text), roomDescription.Text, newType);

            AddRoomCommand addCommand = new AddRoomCommand(newRoom);
            Invoker invoked = new Invoker(addCommand);
            invoked.Invoke();

            this.Hide();
            MessageBox.Show("Success. Press View to Refresh.");
        }
    }
}
