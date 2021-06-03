using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminDoctorPanel : Window
    {
        public AdminDoctorPanel()
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
            Window window = new AdminDoctorProfile();
            this.Close();
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
