using Manager;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ManagerKT3
{
    /// <summary>
    /// Interaction logic for RoomCreation.xaml
    /// </summary>
    public partial class RoomCreation : Window
    {
        public RoomCreation()
        {
            InitializeComponent();
        }

        private void btnCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomType newType = new RoomType();
            if ((bool)operating.IsChecked)
                newType = RoomType.Operating;
            else if ((bool)checkup.IsChecked)
                newType = RoomType.Checkup;
            else if ((bool)therapy.IsChecked)
                newType = RoomType.Therapy;

            Room newRoom = new Room(roomNumber.Text, Convert.ToInt32(roomFloor.Text), roomDescription.Text, newType, RoomStatus.Free);

            _ = RoomRepository.getRoomStorage().Create(newRoom);

            this.Hide();
        }
    }
}
