using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestPanel : Window
    {
        private string selectedHRID; // ID izabranog Holiday Request-a iz List View-a

        public HolidayRequestPanel()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Ucitavanje liste u memoriji
            refreshListView();
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestCreation = new HolidayRequestCreation();
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
            Window holidayRequestUpdate = new HolidayRequestUpdate(selectedHRID); // U konstruktor za prozor se prosledjuje ID izabranog
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
            holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
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
    }
}
