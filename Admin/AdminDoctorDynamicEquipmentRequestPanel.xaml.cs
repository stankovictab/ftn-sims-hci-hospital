using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;
using ftn_sims_hci_hospital.Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminDoctorDynamicEquipmentRequestPanel : Window
    {
        private string selectedDERID;
        Sort sort = new Sort();

        public AdminDoctorDynamicEquipmentRequestPanel()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll(); // Ucitavanje liste u memoriji
            refreshListView();
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentName = dynamicEquipmentTextBox.Text;
            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");

            // ID request-a je null jer ce se naci u servisu
            DynamicEquipmentRequest req = new DynamicEquipmentRequest(equipmentName, doctor);
            MainWindow.dynamicEquipmentRequestController.Create(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully created a new holiday request!");
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                loadIntoListView(req);
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (dynamicEquipmentRequestListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Status1..."
                string[] parts = dynamicEquipmentRequestListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                selectedDERID = parts2[3];

                string[] parts3 = parts[1].Split(' ');
                string status = parts3[3];
                if (status == "OnHold")
                {
                    btnUpdateRequest.IsEnabled = true;
                    btnDeleteRequest.IsEnabled = true;
                }
                else
                {
                    btnUpdateRequest.IsEnabled = false;
                    btnDeleteRequest.IsEnabled = false;
                }
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentName = dynamicEquipmentTextBox.Text;
            // Ovom request-u je doctor null jer ce se naci u servisu na osnovu id-a request-a
            DynamicEquipmentRequest req = new DynamicEquipmentRequest(selectedDERID, equipmentName);
            MainWindow.dynamicEquipmentRequestController.Update(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday request!");
            refreshListView();
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this request?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.dynamicEquipmentRequestController.Delete(selectedDERID); // Update liste i fajla
                refreshListView();
            }
        }

        private void btnSortByRequestDate_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            List<Demand> demandList = list.ConvertAll(x => (Demand)x);
            demandList = sort.sort(demandList);
            foreach (DynamicEquipmentRequest req in demandList)
                loadIntoListView(req);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = searchField.Text;
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.EquipmentName1 == query)
                    loadIntoListView(req);
            }
            if (query == "")
                refreshListView();
        }

        // Filteri

        private void filterNone_Checked(object sender, RoutedEventArgs e)
        {
            refreshListView();
        }
        private void filterOnHold_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == RequestStatus.OnHold)
                    loadIntoListView(req);
            }
        }
        private void filterApproved_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == RequestStatus.Approved)
                    loadIntoListView(req);
            }
        }
        private void filterDenied_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == RequestStatus.Denied)
                    loadIntoListView(req);
            }
        }

        // Clean Code

        private void loadIntoListView(DynamicEquipmentRequest req)
        {
            dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.ID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.CreationDate1, Commentary1 = req.Commentary1 });
        }

        private List<DynamicEquipmentRequest> getDynamicEquipmentRequestList()
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            dynamicEquipmentRequestListView.Items.Clear();
            return MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501");
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        // HCI

        private void HolidayRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminDoctorHolidayRequestPanel();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentRequests_Click(object sender, RoutedEventArgs e)
        {
            // Ostaje na istoj stranici
        }

        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminDoctorProfile();
            this.Close();
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SwitchAccounts_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel window = new AdminPanel();
            this.Close();
            window.ShowDialog();
        }
    }
}
