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
    /// Interaction logic for DynamicUpdate.xaml
    /// </summary>
    public partial class DynamicUpdate : Window
    {
        DynamicEquipment toUpdate = new DynamicEquipment();
        EquipmentController equipmentController = new EquipmentController();

        public DynamicUpdate(String id)
        {
            InitializeComponent();
            equipmentController.equipmentService.dynamicEquipmentRepository.dynamicEquipmentRepository.DynamicEquipment = equipmentController.GetAllDynamic();
            toUpdate = equipmentController.GetDynamicById(id);
            dynamicId.Text = toUpdate.Id.ToString();
            dynamicName.Text = toUpdate.Name;
            dynamicAmount.Text = toUpdate.Amount;
        }

        private void dynamicUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(dynamicId.Text);
            String name = dynamicName.Text;
            String amount = dynamicAmount.Text;

            DynamicEquipment dynamic = new DynamicEquipment(id, name, amount);
            _ = equipmentController.UpdateDynamic(dynamic);
            equipmentController.UpdateAllDynamic(equipmentController.equipmentService.dynamicEquipmentRepository.dynamicEquipmentRepository.DynamicEquipment);
            this.Close();
        }
    }
}
