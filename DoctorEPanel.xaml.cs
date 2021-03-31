using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital {
    /// <summary>
    /// Interaction logic for DoctorEPanel.xaml
    /// </summary>
    public partial class DoctorEPanel : Window {
        public static Classes.HolidayRequestFileStorage hrfs = new Classes.HolidayRequestFileStorage();

        public DoctorEPanel() {
            InitializeComponent();
            hrfs.HolidayRequestsInFile1 = hrfs.GetAll(); // Ovo mora
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e) {
            Window holidayRequestCreation = new HolidayRequestCreation();
            holidayRequestCreation.ShowDialog();
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e) {
            Window holidayRequestUpdate = new HolidayRequestUpdate();
            holidayRequestUpdate.ShowDialog();
        }

        private void btnShowRequests_Click(object sender, RoutedEventArgs e) {
            List<Classes.HolidayRequest> filtredhrfs = hrfs.GetAllByDoctorID("0501");
            holidayRequestListView.Items.Clear(); // Reset
            foreach (Classes.HolidayRequest req in filtredhrfs) {
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}?
                holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1, doctor = req.doctor.user.Jmbg1 });
            }
        }
    }
}
