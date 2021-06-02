using Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentRequestPanel : Window
    {
        private string selectedDERID;
        private int alternator = 0;
        public DynamicEquipmentRequestPanel()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentName = dynamicEquipmentTextBox.Text;
            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");
            MainWindow.dynamicEquipmentRequestController.Create(equipmentName, doctor); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully created a new holiday request!");

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnShowRequests_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501"); // Dobavlja prvo iz fajla pa iz liste
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteRequest.IsEnabled = true;
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
                    btnUpdateRequest.IsEnabled = true;
                else
                    btnUpdateRequest.IsEnabled = false;
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentName = dynamicEquipmentTextBox.Text;
            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");
            MainWindow.dynamicEquipmentRequestController.Update(selectedDERID, equipmentName, doctor); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday request!");

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.Delete(selectedDERID); // Update liste i fajla

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnSortByRequestDate_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501"); // Dobavlja prvo iz fajla pa iz liste

            // Bubble sort
            if (alternator == 0) // Ascending
            {
                for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (list[j].RequestDate1 > list[j + 1].RequestDate1)
                        {
                            // swap temp and arr[i]
                            DynamicEquipmentRequest temp = list[j];
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
                            DynamicEquipmentRequest temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                alternator = 0;
            }

            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
        }

        private void btnDynamicEquipmentSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = dynamicEquipmentSearch.Text;
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501");
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.EquipmentName1 == query)
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
            if (query == "")
                // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
                btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void filterNone_Checked(object sender, RoutedEventArgs e)
        {
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }
        private void filterOnHold_Checked(object sender, RoutedEventArgs e)
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501");
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.OnHold)
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
        }
        private void filterApproved_Checked(object sender, RoutedEventArgs e)
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501");
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.Approved)
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
        }
        private void filterDenied_Checked(object sender, RoutedEventArgs e)
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501");
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.Denied)
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
        }
    }
}
