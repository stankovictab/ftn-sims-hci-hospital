using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital {
    /// <summary>
    /// Interaction logic for DoctorEPanel.xaml
    /// </summary>
    public partial class DoctorEPanel : Window {
        public static Classes.HolidayRequestFileStorage hrfs = new Classes.HolidayRequestFileStorage();
        private string selectedRHID;

        public DoctorEPanel() {
            InitializeComponent();
            hrfs.HolidayRequestsInFile1 = hrfs.GetAll(); // Kada se otvori prozor ucita se cela lista u ovo lokalno polje hrfs, ovo mora
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e) {
            Window holidayRequestCreation = new HolidayRequestCreation();
            holidayRequestCreation.ShowDialog();
            // Ne pravi se ovde logika nego u novom prozoru koji se otvara
        }

        private void btnShowRequests_Click(object sender, RoutedEventArgs e) {
            // Zbog ovog GetAll sam izgubio sat vremena zivota, mora da se ucita ceo fajl ponovo pri refresh-u a ne samo ByDoctorID, jer on cita iz liste, a ta lista nije update-ovana!
            // Takodje proveri da li je fajl popunjen
            hrfs.HolidayRequestsInFile1 = hrfs.GetAll();
            // TODO:
            // Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<Classes.HolidayRequest> filteredhrfs = hrfs.GetAllByDoctorID("0501"); // Ovo dobavlja iz vec napunjene liste u memoriji, ne uzima iz fajla
            holidayRequestListView.Items.Clear(); // Reset (ne .Refresh())
            foreach (Classes.HolidayRequest req in filteredhrfs) {
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}?
                holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1 });
            }
        }

        // SelectionChanged="holidayRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void holidayRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnUpdateRequest.IsEnabled = true;
            btnDeleteRequest.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (holidayRequestListView.SelectedItem != null) {
                // MessageBox.Show(holidayRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Desc..."
                string[] parts = holidayRequestListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                // MessageBox.Show(parts2[3]);
                selectedRHID = parts2[3];
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e) {
            // MessageBox.Show(selectedRHID);
            Window holidayRequestUpdate = new HolidayRequestUpdate(selectedRHID);
            holidayRequestUpdate.ShowDialog();
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e) {
            hrfs.Delete(selectedRHID); // Update liste
            hrfs.UpdateAll(hrfs.HolidayRequestsInFile1); // Update fajla
            // To je to, ovo radi ok
        }
    }
}
