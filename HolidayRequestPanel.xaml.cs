using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestPanel : Window
    {
        private string selectedHRID; // ID izabranog Holiday Request-a iz List View-a

        public HolidayRequestPanel()
        {
            InitializeComponent();

            // Kada se otvori SVAKI prozor, ucitace se cela lista u listu u memoriji, to mora da se radi
            MainWindow.holidayRequestController.GetAll(); // hrc.GetAll(); // Bilo kod mene, u merge-u vise nije

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestCreation = new HolidayRequestCreation();
            holidayRequestCreation.ShowDialog();
            // Ne pravi se ovde logika, nego u novom prozoru koji se otvara
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
                selectedHRID = parts2[3];
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(selectedHRID);
            Window holidayRequestUpdate = new HolidayRequestUpdate(selectedHRID); // U konstruktor za prozor se prosledjuje ID izabranog
            holidayRequestUpdate.ShowDialog();
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.holidayRequestController.Delete(selectedHRID); // Update liste i fajla

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }
    }
}
