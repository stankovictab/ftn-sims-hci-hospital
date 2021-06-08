using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerDynamicEquipmentRequestApprovals : Window
    {
        private string selectedDERID;

        public AdminManagerDynamicEquipmentRequestApprovals()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentOrderList();
            foreach (DynamicEquipmentRequest req in list)
            {
                loadIntoListView(req);
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnApproveRequest.IsEnabled = true;
            btnDenyRequest.IsEnabled = true;
            commentaryBox.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (dynamicEquipmentRequestListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Desc..."
                string[] parts = dynamicEquipmentRequestListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                // MessageBox.Show(parts2[3]);
                selectedDERID = parts2[3];
            }
        }

        private void btnApproveRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.Approve(selectedDERID, commentaryBox.Text); // GetAll() se radi u Approve(), tu se update-uju i lista i fajl
            refreshListView();
        }

        private void btnDenyRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.Deny(selectedDERID, commentaryBox.Text); // GetAll() se radi u Approve(), tu se update-uju i lista i fajl
            refreshListView();
        }

        private void btnPast_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicEquipmentPastRequestApprovals = new AdminManagerDynamicEquipmentPastRequestApprovals();
            this.Close();
            dynamicEquipmentPastRequestApprovals.ShowDialog();
        }

        // Clean Code

        private void loadIntoListView(DynamicEquipmentRequest req)
        {
            string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
            dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.ID1, DoctorFullName1 = doc, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.CreationDate1 });
        }

        private List<DynamicEquipmentRequest> getDynamicEquipmentOrderList()
        {
            dynamicEquipmentRequestListView.Items.Clear();
            return MainWindow.dynamicEquipmentRequestController.GetAllOnHold();
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        // HCI

        private void HolidayRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerHolidayRequestApprovals();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentRequests_Click(object sender, RoutedEventArgs e)
        {
            // Ostaje na istoj stranici
        }

        private void DynamicEquipmentOrderPanel_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentOrderPanel();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentOrderCreation_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentOrderCreation();
            this.Close();
            window.ShowDialog();
        }

        private void PollResults_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerPollResults();
            this.Close();
            window.ShowDialog();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerReport();
            this.Close();
            window.ShowDialog();
        }

        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerProfile();
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
