using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerHolidayRequestApprovals : Window
    {
        public string selectedHRID;
        private int alternator = 0;

        public AdminManagerHolidayRequestApprovals()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll();
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = getHolidayRequestList();
            foreach (HolidayRequest req in list)
            {
                loadIntoListView(req);
            }
        }

        // SelectionChanged="holidayRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void holidayRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnApproveRequest.IsEnabled = true;
            btnDenyRequest.IsEnabled = true;
            commentaryBox.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (holidayRequestListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Desc..."
                string[] parts = holidayRequestListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                // MessageBox.Show(parts2[3]);
                selectedHRID = parts2[3];
            }
        }

        private void btnSortByRequestDate_Click(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = getHolidayRequestList();

            // Bubble sort - ne mora da se pravi posebna metoda za clean code jer se samo ovde koristi
            if (alternator == 0) // Ascending
            {
                for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (list[j].RequestDate1 > list[j + 1].RequestDate1)
                        {
                            // swap temp and arr[i]
                            HolidayRequest temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                alternator = 1;
            }
            else // Descending
            {
                for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (list[j].RequestDate1 < list[j + 1].RequestDate1)
                        {
                            // swap temp and arr[i]
                            HolidayRequest temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                alternator = 0;
            }

            foreach (HolidayRequest req in list)
                loadIntoListView(req);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = searchField.Text;
            List<HolidayRequest> list = getHolidayRequestList();
            foreach (HolidayRequest req in list)
            {
                if (req.doctor.user.Name1 == query || req.doctor.user.LastName1 == query || req.doctor.user.Name1 + " " + req.doctor.user.LastName1 == query)
                    loadIntoListView(req);
            }
            if (query == "")
                refreshListView();
        }

        private void btnApproveRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.holidayRequestController.Approve(selectedHRID, commentaryBox.Text); // GetAll() se radi u Approve(), tu se update-uju i lista i fajl
            refreshListView();
        }

        private void btnDenyRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.holidayRequestController.Deny(selectedHRID, commentaryBox.Text);  // GetAll() se radi u Approve(), tu se update-uju i lista i fajl
            refreshListView();
        }

        private void btnPast_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestPastApprovals = new AdminManagerHolidayPastRequestApprovals();
            holidayRequestPastApprovals.ShowDialog();
        }

        // Clean Code

        private void loadIntoListView(HolidayRequest req)
        {
            string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
            holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, DoctorFullName1 = doc, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1, RequestDate1 = req.RequestDate1 });
        }

        private List<HolidayRequest> getHolidayRequestList()
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            holidayRequestListView.Items.Clear();
            return MainWindow.holidayRequestController.GetAllOnHold();
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
            Window window = new AdminManagerDynamicEquipmentRequestApprovals();
            this.Close();
            window.ShowDialog();
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
    }
}
