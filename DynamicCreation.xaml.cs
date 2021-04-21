using Manager;
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

namespace ManagerKT3
{
    /// <summary>
    /// Interaction logic for DynamicCreation.xaml
    /// </summary>
    public partial class DynamicCreation : Window
    {
        EquipmentController equipmentController = new EquipmentController();
        RoomRepository roomRepository = new RoomRepository();

        public DynamicCreation()
        {
            InitializeComponent();
            List<Room> rooms = roomRepository.GetAll();
        }

        private void dynamicAdd_Click(object sender, RoutedEventArgs e)
        {
            equipmentController.equipmentService.dynamicEquipmentRepository.DynamicInFile = equipmentController.GetAllDynamic();
            DynamicEquipment newDynamic = new DynamicEquipment(Convert.ToInt32(dynamicId.Text), dynamicName.Text, dynamicAmount.Text);
            _ = equipmentController.AddDynamic(newDynamic);
            this.Hide();
        }
    }
}
