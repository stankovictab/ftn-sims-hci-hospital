using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestApproval : Window
    {
        private string selectedHRID;

        public HolidayRequestApproval()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll();

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnShowRequests_Click(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = MainWindow.holidayRequestController.GetAllOnHold();
            holidayRequestListView.Items.Clear();
            foreach (HolidayRequest req in list)
            {
                string doc = req.doctor.user.Name1 + req.doctor.user.LastName1;
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1, RequestDate1 = req.RequestDate1, DoctorFullName1 = doc });
            }
        }

        // SelectionChanged="holidayRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void holidayRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnApproveRequest.IsEnabled = true;
            btnDenyRequest.IsEnabled = true;
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

        private void btnApproveRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.holidayRequestController.Approve(selectedHRID); // GetAll() se radi u Approve(), tu se update-uju i lista i fajl

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnDenyRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.holidayRequestController.Deny(selectedHRID);  // GetAll() se radi u Approve(), tu se update-uju i lista i fajl

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }
    }
}
