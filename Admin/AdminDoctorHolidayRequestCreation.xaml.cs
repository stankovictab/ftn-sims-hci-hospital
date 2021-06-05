using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminDoctorHolidayRequestCreation : Window
    {
        public AdminDoctorHolidayRequestCreation()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Ucitavanje liste u memoriji
        }

        // Biznis logika za dodavanje u listu i fajl
        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate; // Mora cast jer vraca DateTime? iz nekog razloga
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;

            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");

            // ID request-a je null jer ce se naci u servisu
            HolidayRequest req = new HolidayRequest(desc, startDate, endDate, doctor);
            MainWindow.holidayRequestController.Create(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully created a new holiday request!");
            this.Close(); // this.Hide(); ?
        }

        // HCI

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

        private void SwitchAccounts_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel window = new AdminPanel();
            this.Close();
            window.ShowDialog();
        }
    }
}
