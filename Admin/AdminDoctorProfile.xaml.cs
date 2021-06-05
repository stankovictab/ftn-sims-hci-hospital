using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminDoctorProfile : Window
    {
        public AdminDoctorProfile()
        {
            InitializeComponent();
        }

        private void HolidayRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminDoctorHolidayRequestPanel();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminDoctorDynamicEquipmentRequestPanel();
            this.Close();
            window.ShowDialog();
        }

        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            // Ostaje na istoj stranici
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SwitchAccounts_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel window = new AdminPanel();
            this.Close();
            window.ShowDialog();
        }
    }
}
