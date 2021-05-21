using Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentRequestApproval : Window
    {
        private string selectedDERID;

        public DynamicEquipmentRequestApproval()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnRefresh_Click()
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllOnHold();
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, DoctorFullName1 = doc, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1});
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnApproveRequest.IsEnabled = true;
            btnDenyRequest.IsEnabled = true;
            commentaryBoxDynamicEquipmentRequest.IsEnabled = true;
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
            MainWindow.dynamicEquipmentRequestController.Approve(selectedDERID, commentaryBoxDynamicEquipmentRequest.Text); // GetAll() se radi u Approve(), tu se update-uju i lista i fajl

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnRefresh_Click()
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnDenyRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.Deny(selectedDERID, commentaryBoxDynamicEquipmentRequest.Text);  // GetAll() se radi u Approve(), tu se update-uju i lista i fajl

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnRefresh_Click()
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnPast_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicEquipmentPastRequestApprovals = new DynamicEquipmentPastRequestApprovals();
            dynamicEquipmentPastRequestApprovals.ShowDialog();
        }
    }
}
