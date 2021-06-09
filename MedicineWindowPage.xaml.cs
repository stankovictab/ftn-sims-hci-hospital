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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for MedicineWindowPage.xaml
    /// </summary>
    public partial class MedicineWindowPage : Page
    {
        MedicineController medicineController = new MedicineController();

        public MedicineWindowPage()
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

        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            StoragePage inventoryPage = new StoragePage();
            this.Content = new Frame() { Content = inventoryPage };
        }

        private void roomsButton_Click(object sender, RoutedEventArgs e)
        {
            RoomsPage roomPage = new RoomsPage();
            this.Content = new Frame() { Content = roomPage };
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            StaticSchedulePage schedulePage = new StaticSchedulePage();
            this.Content = new Frame() { Content = schedulePage };
        }

        private void basicRenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            BasicRenovationsPage page = new BasicRenovationsPage();
            this.Content = new Frame() { Content = page };
        }

        private void advancedRenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            AdvancedRenovationsPage page = new AdvancedRenovationsPage();
            this.Content = new Frame() { Content = page };
        }

        private void profilButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage page = new ProfilePage();
            this.Content = new Frame() { Content = page };
        }

        private void medicineMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MedicineWindowPage page = new MedicineWindowPage();
            this.Content = new Frame() { Content = page };
        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            string[] parts = medicineDataList.SelectedItem.ToString().Split(',');
            string[] forStatus = parts[5].Split(' ');
            string[] parts2 = parts[1].Split(' ');
            string status = forStatus[3];
            String toGenerate = parts2[3];

            Medicine med;
            if (status == "OnHold")
                med = medicineController.GetOnHoldByName(toGenerate);
            else
                med = medicineController.GetUnverifiedByName(toGenerate);

            Window Report = new ReportWindow(med);
            Report.ShowDialog();
        }

        private void signoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
