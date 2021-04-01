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

            Room newRoom = new Room(roomNumber.Text, Convert.ToInt32(roomFloor.Text), roomDescription.Text, newType);

            _ = RoomFileStorage.getRoomStorage().Create(newRoom);

            this.Hide();
        }
    }
}
