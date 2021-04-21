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
    /// Interaction logic for Dynamic.xaml
    /// </summary>
    public partial class Dynamic : Window
    {
        EquipmentController equipmentController = new EquipmentController();
        AssignmentController assignmentController = new AssignmentController();

        public Dynamic()
        {
            InitializeComponent();
        }

        private void addDynamic_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicCreation = new DynamicCreation();
            dynamicCreation.ShowDialog();
        }

        private void viewDynamic_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipment> allDynamic = new List<DynamicEquipment>();
            allDynamic = equipmentController.GetAllDynamic();
            dynamicDataList.Items.Clear();
            foreach (DynamicEquipment d in allDynamic)
            {
                dynamicDataList.Items.Add(new { dynamicId = d.dynamicId, dynamicName = d.dynamicName, dynamicAmount = d.dynamicAmount });
            }

            List<DynamicAssignment> allAssignments = new List<DynamicAssignment>();
            allAssignments = assignmentController.GetAll();
            dynamicDataListUsed.Items.Clear();
            foreach (DynamicAssignment a in allAssignments)
            {
                dynamicDataListUsed.Items.Add(new { dynamicNameUsed = a.EquipmentAssigned.dynamicName, dynamicAmountUsed = a.AmountAssigned});
            }
        }

        private void updateDynamic_Click(object sender, RoutedEventArgs e)
        {
            if (!dynamicDataList.Items.IsEmpty)
            {
                if (dynamicDataList.SelectedItem != null)
                {
                    string[] parts = dynamicDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toUpdate = parts2[3];
                    Window dynamicUpdate = new DynamicUpdate(toUpdate);
                    dynamicUpdate.ShowDialog();
                    viewDynamic.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void deleteDynamic_Click(object sender, RoutedEventArgs e)
        {
            if (!dynamicDataList.Items.IsEmpty)
            {
                if (dynamicDataList.SelectedItem != null)
                {
                    string[] parts = dynamicDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toDelete = parts2[3];
                    _ = equipmentController.DeleteDynamic(toDelete);
                    equipmentController.UpdateAllDynamic(equipmentController.equipmentService.dynamicEquipmentRepository.DynamicInFile);
                    viewDynamic.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void assignDynamic_Click(object sender, RoutedEventArgs e)
        {
            if (!dynamicDataList.Items.IsEmpty)
            {
                if(dynamicDataList.SelectedItem != null)
                {
                    string[] parts = dynamicDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toAssign = parts2[3];
                    Window dynamicUse = new DynamicUse(toAssign);
                    dynamicUse.ShowDialog();
                }
            }
        }
    }
}
