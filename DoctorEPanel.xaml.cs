using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{

    // nemoj da prihvatis ovaj
    public partial class DoctorEPanel : Window
    {
       // public static Classes.HolidayRequestFileStorage hrfs = new Classes.HolidayRequestFileStorage();
        private string selectedRHID;

        public DoctorEPanel()
        {
            InitializeComponent();
             // Kada se otvori prozor ucita se cela lista u ovo lokalno polje hrfs, ovo mora
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestCreation = new HolidayRequestCreation();
            holidayRequestCreation.ShowDialog();
            // Ne pravi se ovde logika nego u novom prozoru koji se otvara
        }

        private void btnShowRequests_Click(object sender, RoutedEventArgs e)
        {
           
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
                // MessageBox.Show(parts2[3]);
                selectedRHID = parts2[3];
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(selectedRHID);
            Window holidayRequestUpdate = new HolidayRequestUpdate(selectedRHID);
            holidayRequestUpdate.ShowDialog();
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
