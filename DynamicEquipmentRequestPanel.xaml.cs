using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentRequestPanel : Window
    {
        private string selectedDERID;

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
                dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Status1 = req.Status1 });
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdateRequest.IsEnabled = true;
            btnDeleteRequest.IsEnabled = true;
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
    }
}
