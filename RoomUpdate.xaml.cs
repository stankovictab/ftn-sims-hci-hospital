using Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for RoomUpdate.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        public Room toUpdate = new Room();
        public static RoomRepository storage = new RoomRepository();
        public RoomUpdate(String id)
        {
            InitializeComponent();
            storage.AccessRoomsInFile = storage.GetAll();
            toUpdate = storage.GetById(id);
            numberTextbox.Text = toUpdate.RoomNumber;
            floorTextbox.Text = toUpdate.FloorNumber.ToString();
            descriptionTextbox.Text = toUpdate.Description;

            if (toUpdate.Type == RoomType.Operating)
                operatingRadio.IsChecked = true;
            else if (toUpdate.Type == RoomType.Therapy)
                therapyRadio.IsChecked = true;
            else if (toUpdate.Type == RoomType.Checkup)
                checkupRadio.IsChecked = true;

            //if (toUpdate.Status == RoomStatus.Free)
            //    freeRadio.IsChecked = true;
            //else if (toUpdate.Status == RoomStatus.Busy)
            //    busyRadio.IsChecked = true;
            //else if (toUpdate.Status == RoomStatus.Renovating)
            //    renovatingRadio.IsChecked = true;
            //else if (toUpdate.Status == RoomStatus.Reordering)
            //    reorderingRadio.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String number = numberTextbox.Text;
            int floor = Convert.ToInt32(floorTextbox.Text);
            String description = descriptionTextbox.Text;
            RoomType newType = new RoomType();
            RoomStatus newStatus = new RoomStatus();

            if ((bool)operatingRadio.IsChecked)
                newType = RoomType.Operating;
            else if ((bool)checkupRadio.IsChecked)
                newType = RoomType.Checkup;
            else if ((bool)therapyRadio.IsChecked)
                newType = RoomType.Therapy;

            //if ((bool)freeRadio.IsChecked)
            //    newStatus = RoomStatus.Free;
            //else if ((bool)busyRadio.IsChecked)
            //    newStatus = RoomStatus.Busy;
            //else if ((bool)renovatingRadio.IsChecked)
            //    newStatus = RoomStatus.Renovating;
            //else if ((bool)reorderingRadio.IsChecked)
            //    newStatus = RoomStatus.Reordering;

            Room room = new Room(number, floor, description, newType, newStatus);
            storage.Update(room);
            storage.UpdateAll(storage.AccessRoomsInFile);
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
