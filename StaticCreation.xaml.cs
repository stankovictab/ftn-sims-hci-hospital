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
    /// Interaction logic for StaticCreation.xaml
    /// </summary>
    public partial class StaticCreation : Window
    {
        EquipmentController equipmentController = new EquipmentController();
        RoomController roomController = new RoomController();

        public StaticCreation()
        {
            InitializeComponent();
            List<Room> rooms = roomController.roomService.roomRepository.GetAll();
            foreach(Room r in rooms)
            {
                staticLocation.Items.Add(r.RoomNumber);
            }
        }

        private void staticAdd_Click(object sender, RoutedEventArgs e)
        {
            equipmentController.equipmentService.staticEquipmentRepository.staticEquipmentRepository.StaticEquipment = equipmentController.GetAllStatic();
            StaticEquipment newStatic = new StaticEquipment(Convert.ToInt32(staticId.Text), staticName.Text, staticLocation.SelectedItem.ToString());
            _ = equipmentController.AddStatic(newStatic);
            this.Hide();
        }
    }
}
