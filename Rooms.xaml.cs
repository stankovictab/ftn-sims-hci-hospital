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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        RoomRepository storage = RoomRepository.getRoomStorage();
        public Rooms()
        {
            InitializeComponent();
        }


        private void addroom_Click(object sender, RoutedEventArgs e)
        {
            Window RoomCreationWindow = new RoomCreation();
            RoomCreationWindow.ShowDialog();
        }

        private void viewrooms_Click(object sender, RoutedEventArgs e)
        {
            storage.Rooms = storage.GetAll();
            roomDataList.Items.Clear();
            foreach (Room r in storage.AccessRooms)
            {
                roomDataList.Items.Add(new { RoomNumber = r.RoomNumber, FloorNumber = r.FloorNumber, Description = r.Description, Type = r.Type, Status = r.Status });
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (!roomDataList.Items.IsEmpty)
            {
                if (roomDataList.SelectedItem != null)
                {
                    string[] parts = roomDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toDelete = parts2[3];
                    storage.Delete(toDelete);
                    storage.UpdateFile(storage.AccessRooms);
                    viewrooms.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (!roomDataList.Items.IsEmpty)
            {
                if (roomDataList.SelectedItem != null)
                {
                    string[] parts = roomDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toUpdate = parts2[3];
                    Window roomUpdate = new RoomUpdate(toUpdate);
                    roomUpdate.ShowDialog();
                    viewrooms.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
