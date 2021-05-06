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
    public partial class Medicine : Window
    {
        MedicineController medicineController = new MedicineController();

        public Medicine()
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
            List<Classes.Medicine> allMedicine = new List<Classes.Medicine>();
            allMedicine = medicineController.GetAllUnverified();
            medicineDataList.Items.Clear();
            foreach (Classes.Medicine m in allMedicine)
            {
                medicineDataList.Items.Add(new { Name = m.Name, Description = m.Description, Ingredients = m.Ingredients, Alternatives = m.Alternatives, Status = m.Status.ToString() });
            }
        }

        private void updatemedicine_Click(object sender, RoutedEventArgs e)
        {
            if (!medicineDataList.Items.IsEmpty)
            {
                if (medicineDataList.SelectedItem != null)
                {
                    string[] parts = medicineDataList.SelectedItem.ToString().Split(',');
                    string[] parts2 = parts[0].Split(' ');
                    String toUpdate = parts2[3];
                    Window medicineUpdate = new MedicineUpdate(toUpdate);
                    medicineUpdate.ShowDialog();
                    viewmedicine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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
                    string[] parts2 = parts[0].Split(' ');
                    String toDelete = parts2[3];
                    _ = medicineController.DeleteUnverified(toDelete);
                    medicineController.UpdateAllUnverified(medicineController.medicineService.medicineRepository.UnverifiedMedicine);
                    viewmedicine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
