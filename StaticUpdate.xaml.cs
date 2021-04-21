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
    /// Interaction logic for StaticUpdate.xaml
    /// </summary>
    public partial class StaticUpdate : Window
    {
        StaticEquipment toUpdate = new StaticEquipment();
        EquipmentController equipmentController = new EquipmentController();
        public StaticUpdate(String id)
        {
            InitializeComponent();
            equipmentController.equipmentService.staticEquipmentRepository.StaticInFile = equipmentController.GetAllStatic();
            toUpdate = equipmentController.GetStaticById(id);
            staticId.Text = toUpdate.statId.ToString();
            staticName.Text = toUpdate.statName;
        }

        private void staticUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(staticId.Text);
            String name = staticName.Text;

            StaticEquipment staticc = new StaticEquipment(id, name, toUpdate.statLocation);
            _ = equipmentController.UpdateStatic(staticc);
            equipmentController.UpdateAllStatic(equipmentController.equipmentService.staticEquipmentRepository.StaticInFile);
            this.Close();
        }
    }
}
