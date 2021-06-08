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
    /// Interaction logic for Static.xaml
    /// </summary>
    public partial class Static : Window
    {
        EquipmentController equipmentController = new EquipmentController();

        public Static()
        {
            InitializeComponent();
        }

        private void addStat_Click(object sender, RoutedEventArgs e)
        {
            Window staticCreation = new StaticCreation();
            staticCreation.ShowDialog();
        }

        private void viewStat_Click(object sender, RoutedEventArgs e)
        {
            List<StaticEquipment> allStatic = equipmentController.GetAllStatic();
            staticDataList.Items.Clear();
            foreach (StaticEquipment s in allStatic)
            {
                staticDataList.Items.Add(new { statId = s.statId, statName = s.statName, statLocation = s.statLocation });
            }
        }

        private void updateStat_Click(object sender, RoutedEventArgs e)
        {
            if (!staticDataList.Items.IsEmpty)
            {
                if (staticDataList.SelectedItem != null)
                {
                    string[] parts = staticDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toUpdate = parts2[3];
                    Window staticUpdate = new StaticUpdate(toUpdate);
                    staticUpdate.ShowDialog();
                    viewStat.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void deleteStat_Click(object sender, RoutedEventArgs e)
        {
            if (!staticDataList.Items.IsEmpty)
            {
                if (staticDataList.SelectedItem != null)
                {
                    string[] parts = staticDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toDelete = parts2[3];
                    _ = equipmentController.DeleteStatic(toDelete);
                    equipmentController.UpdateAllStatic(equipmentController.equipmentService.staticEquipmentRepository.staticEquipmentRepository.StaticEquipment);
                    viewStat.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
