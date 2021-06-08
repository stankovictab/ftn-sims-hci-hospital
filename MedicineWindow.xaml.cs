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
    /// Interaction logic for Medicine.xaml
    /// </summary>
    public partial class MedicineWindow : Window
    {
        MedicineController medicineController = new MedicineController();

        public MedicineWindow()
        {
            InitializeComponent();
        }

        private void addmedicine_Click(object sender, RoutedEventArgs e)
        {
            Window MedicineCreationWindow = new MedicineCreation();
            MedicineCreationWindow.ShowDialog();
        }

        private void viewmedicine_Click(object sender, RoutedEventArgs e)
        {
            List<Medicine> allOnHoldMedicine = new List<Medicine>();
            List<Medicine> allUnverifiedMedicine = new List<Medicine>();
            allOnHoldMedicine = medicineController.GetAllOnHold();
            allUnverifiedMedicine = medicineController.GetAllUnverified();
            medicineDataList.Items.Clear();
            foreach (Medicine m in allOnHoldMedicine)
            {
                medicineDataList.Items.Add(new { Id = m.Id, Name = m.Name, Description = m.Description, Ingredients = m.Ingredients, Alternatives = m.Alternatives, Status = m.Status.ToString() });
            }
            foreach (Medicine m in allUnverifiedMedicine)
            {
                medicineDataList.Items.Add(new { Id = m.Id, Name = m.Name, Description = m.Description, Ingredients = m.Ingredients, Alternatives = m.Alternatives, Status = m.Status.ToString() });
            }
        }

        private void updatemedicine_Click(object sender, RoutedEventArgs e)
        {
            if (!medicineDataList.Items.IsEmpty)
            {
                string[] parts = medicineDataList.SelectedItem.ToString().Split(',');
                string[] parts2 = parts[1].Split(' ');
                string toUpdate = parts2[3];

                string[] partsCheck = parts[5].Split(' ');
                string checkOnHold = partsCheck[3];
                if (medicineDataList.SelectedItem != null && checkOnHold == "OnHold")
                {
                    Window medicineUpdate = new MedicineUpdate(toUpdate);
                    medicineUpdate.ShowDialog();
                    viewmedicine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    MessageBox.Show("You can only update on hold medicine!");
                }
            }
        }

        private void deletemedicine_Click(object sender, RoutedEventArgs e)
        {
            if (!medicineDataList.Items.IsEmpty)
            {
                if (medicineDataList.SelectedItem != null)
                {
                    string[] parts = medicineDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[1].Split(' ');
                    String toDelete = parts2[3];
                    _ = medicineController.DeleteOnHold(toDelete);
                    medicineController.UpdateAllOnHold(medicineController.medicineService.medicineRepository.OnHoldMedicine);
                    viewmedicine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void resubmitmedicine_Click(object sender, RoutedEventArgs e)
        {
            if (!medicineDataList.Items.IsEmpty)
            {
                string[] parts = medicineDataList.SelectedItem.ToString().Split(',');
                string[] parts2 = parts[1].Split(' ');
                string toResubmit = parts2[3];

                string[] partsCheck = parts[5].Split(' ');
                string checkUnverified = partsCheck[3];
                if (medicineDataList.SelectedItem != null && checkUnverified == "Unverified")
                {
                    Window medicineResubmit = new MedicineResubmit(toResubmit);
                    medicineResubmit.ShowDialog();
                    viewmedicine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    MessageBox.Show("You can only resubmit unverified medicine!");
                }
            }
        }
    }
}
