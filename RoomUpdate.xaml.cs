using Classes;
using ftn_sims_hci_hospital.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for RoomUpdate.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        public Room toUpdate = new Room();
        public static RoomRepository storage = new RoomRepository();
        public RoomUpdate(String roomNumber)
        {
            InitializeComponent();
            storage.AccessRooms = storage.GetAll();
            toUpdate = storage.GetByNumber(roomNumber);
            numberTextbox.Text = toUpdate.RoomNumber;
            floorTextbox.Text = toUpdate.FloorNumber.ToString();
            descriptionTextbox.Text = toUpdate.Description;

            List<RoomType> types = new List<RoomType>();
            types.Add(RoomType.Checkup);
            types.Add(RoomType.Operating);
            types.Add(RoomType.Therapy);

            foreach (RoomType type in types)
            {
                roomTypeCombo.Items.Add(type);
            }

            List<RoomStatus> statuses = new List<RoomStatus>();
            statuses.Add(RoomStatus.Busy);
            statuses.Add(RoomStatus.Free);
            statuses.Add(RoomStatus.Renovating);
            statuses.Add(RoomStatus.Reordering);

            foreach (RoomStatus status in statuses)
            {
                roomStatusCombo.Items.Add(status);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String number = numberTextbox.Text;
            int floor = Convert.ToInt32(floorTextbox.Text);
            String description = descriptionTextbox.Text;
            RoomType newType = new RoomType();
            RoomStatus newStatus = new RoomStatus();

            if (roomTypeCombo.SelectedItem.ToString() == "Operating")
                newType = RoomType.Operating;
            else if (roomTypeCombo.SelectedItem.ToString() == "Checkup")
                newType = RoomType.Checkup;
            else if (roomTypeCombo.SelectedItem.ToString() == "Therapy")
                newType = RoomType.Therapy;

            if (roomStatusCombo.SelectedItem.ToString() == "Free")
                newStatus = RoomStatus.Free;
            else if (roomStatusCombo.SelectedItem.ToString() == "Busy")
                newStatus = RoomStatus.Busy;
            else if (roomStatusCombo.SelectedItem.ToString() == "Renovating")
                newStatus = RoomStatus.Renovating;
            else if (roomStatusCombo.SelectedItem.ToString() == "Reordering")
                newStatus = RoomStatus.Reordering;

            Room room = new Room(number, floor, description, newType, newStatus);

            UpdateRoomCommand updateCommand = new UpdateRoomCommand(room);
            Invoker invoked = new Invoker(updateCommand);
            invoked.Invoke();

            storage.Update(room);
            storage.UpdateFile(storage.AccessRooms);
            this.Close();
        }
    }
}
