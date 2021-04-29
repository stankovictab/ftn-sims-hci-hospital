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
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
