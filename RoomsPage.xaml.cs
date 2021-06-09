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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        RoomController roomController = new RoomController();

        public RoomsPage()
        {
            InitializeComponent();
        }

        RoomRepository storage = RoomRepository.getRoomStorage();

        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            Page inventoryPage = new StoragePage();
            this.Content = new Frame() { Content = inventoryPage };
        }

        private void roomsButton_Click(object sender, RoutedEventArgs e)
        {
            RoomsPage roomPage = new RoomsPage();
            this.Content = new Frame() { Content = roomPage };
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            Page schedulePage = new StaticSchedulePage();
            this.Content = new Frame() { Content = schedulePage };
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
                    String roomId = parts2[3];
                    Room toDelete = roomController.GetById(roomId);

                    DeleteRoomCommand deleteCommand = new DeleteRoomCommand(toDelete);
                    Invoker invoked = new Invoker(deleteCommand);
                    invoked.Invoke();

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

        }
    }
}
