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
    /// Interaction logic for BasicRenovationCreation.xaml
    /// </summary>
    public partial class BasicRenovationCreation : Window
    {
        RoomController roomController = new RoomController();
        BasicRenovationController basicRenovationController = new BasicRenovationController();

        public BasicRenovationCreation()
        {
            InitializeComponent();

            List<Room> rooms = roomController.roomService.roomRepository.GetAll();
            foreach (Room r in rooms)
            {
                renovatedRoomCombo.Items.Add(r.RoomNumber);
            }
        }

        private void createBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            basicRenovationController.basicRenovationService.basicRenovationRepository.AccessBasicRenovations = basicRenovationController.GetAll();
            BasicRenovation newBasicRenovation = new BasicRenovation(Convert.ToInt32(renovationIdTextbox.Text), roomController.GetById(renovatedRoomCombo.SelectedItem.ToString()), Convert.ToDateTime(renovationTime.Text), Convert.ToInt32(durationTextbox.Text));
            bool success = basicRenovationController.Create(newBasicRenovation);
            
            if (!success)
                MessageBox.Show("Room is already busy at that time!");
            
            this.Hide();
        }
    }
}
