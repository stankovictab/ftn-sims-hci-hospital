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
    public partial class RoomEdit : Window
    {
        public Room toUpdate = new Room();
        //public static RoomFileStorage storage = new RoomFileStorage();
        public RoomEdit(String id)
        {
            InitializeComponent();
           // storage.AccessRoomsInFile = storage.GetAll();
           // toUpdate = storage.GetById(id);
            numberTextbox.Text = toUpdate.RoomNumber1;
            floorTextbox.Text = toUpdate.FloorNumber1.ToString();
            descriptionTextbox.Text = toUpdate.Description1;

            if (toUpdate.Type1 == RoomType.Operating)
                operatingRadio.IsChecked = true;
            else if (toUpdate.Type1 == RoomType.Therapy)
                therapyRadio.IsChecked = true;
            else if (toUpdate.Type1 == RoomType.Checkup)
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
            //storage.Update(room);
           // storage.UpdateAll(storage.AccessRoomsInFile);
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
