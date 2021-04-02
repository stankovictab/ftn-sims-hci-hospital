using Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        RoomFileStorage storage = RoomFileStorage.getRoomStorage();
        public ManagerWindow()
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
            

            storage.AccessRoomsInFile = storage.GetAll();
            roomDataList.Items.Clear();
            foreach (Room r in storage.AccessRoomsInFile)
            {
                roomDataList.Items.Add(new { RoomNumber = r.RoomNumber1, FloorNumber = r.FloorNumber1, Description = r.Description1, Type = r.Type1, Status = r.Status1});
            }
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (!roomDataList.Items.IsEmpty)
            {
                if(roomDataList.SelectedItem != null)
                {
                    string[] parts = roomDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toDelete = parts2[3];
                    storage.Delete(toDelete);
                    storage.UpdateAll(storage.AccessRoomsInFile);
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
                    Window roomEdit = new RoomEdit(toUpdate);
                    roomEdit.ShowDialog();
                    viewrooms.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
