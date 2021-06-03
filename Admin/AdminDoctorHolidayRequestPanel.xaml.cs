using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminDoctorHolidayRequestPanel : Window
    {
        private string selectedHRID; // ID izabranog Holiday Request-a iz List View-a

        public AdminDoctorHolidayRequestPanel()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Ucitavanje liste u memoriji
            refreshListView();
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestCreation = new AdminDoctorHolidayRequestCreation();
            holidayRequestCreation.ShowDialog();
            // Ne pravi se ovde logika, nego u novom prozoru koji se otvara
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
            btnUpdateRequest.IsEnabled = true;
            btnDeleteRequest.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (holidayRequestListView.SelectedItem != null)
            {
                // MessageBox.Show(holidayRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Desc..."
                string[] parts = holidayRequestListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                selectedHRID = parts2[3];

                string[] parts3 = parts[1].Split(' ');
                string status = parts3[3];
                if (status == "OnHold")
                    btnUpdateRequest.IsEnabled = true;
                else
                    btnUpdateRequest.IsEnabled = false;
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestUpdate = new AdminDoctorHolidayRequestUpdate(selectedHRID); // U konstruktor za prozor se prosledjuje ID izabranog
            holidayRequestUpdate.ShowDialog();
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.holidayRequestController.Delete(selectedHRID); // Update liste i fajla
            refreshListView();
        }

        // Clean Code

        private void loadIntoListView(HolidayRequest req)
        {
            string sd = req.StartDate1.Day.ToString() + "/" + req.StartDate1.Month.ToString() + "/" + req.StartDate1.Year.ToString();
            string ed = req.EndDate1.Day.ToString() + "/" + req.EndDate1.Month.ToString() + "/" + req.EndDate1.Year.ToString();
            string rd = req.RequestDate1.Day.ToString() + "/" + req.RequestDate1.Month.ToString() + "/" + req.RequestDate1.Year.ToString();

            holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, Description1 = req.Description1, StartDate1 = sd, EndDate1 = ed, RequestDate1 = rd, Commentary1 = req.Commentary1 });
        }

        private List<HolidayRequest> getHolidayRequestList()
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            holidayRequestListView.Items.Clear();
            return MainWindow.holidayRequestController.GetAllByDoctorID("0501"); // Dobavlja prvo iz fajla pa iz liste
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        // HCI

        private void HolidayRequests_Click(object sender, RoutedEventArgs e)
        {
            // Ostaje na istoj stranici
        }

        private void DynamicEquipmentRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminDoctorDynamicEquipmentRequestPanel();
            this.Close();
            window.ShowDialog();
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
    }
}