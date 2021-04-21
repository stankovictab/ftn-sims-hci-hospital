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
    /// Interaction logic for DynamicUse.xaml
    /// </summary>
    public partial class DynamicUse : Window
    {
        DynamicEquipment toAssign = new DynamicEquipment();
        AssignmentController assignmentController = new AssignmentController();
        EquipmentController equipmentController = new EquipmentController();

        public DynamicUse(string id)
        {
            InitializeComponent();
            toAssign = equipmentController.GetDynamicById(id);
            availableTextbox.Text = toAssign.dynamicAmount;
        }

        private void outOfStorage_Click(object sender, RoutedEventArgs e)
        {
            var amount = Convert.ToInt32(amountTextbox.Text);
            bool success = assignmentController.CreateAssignment(amount, toAssign);
            if (!success)
                MessageBox.Show("Nedovoljna kolicina u magacinu.");
            this.Close();
        }
    }
}
