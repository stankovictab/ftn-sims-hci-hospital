using System;
using System.Windows;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestCreation : Window
    {
        public HolidayRequestCreation()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Kada se otvori prozor ucita se cela lista
        }

        // Biznis logika za dodavanje u listu i fajl
        private void btnHolidaySubmit_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
