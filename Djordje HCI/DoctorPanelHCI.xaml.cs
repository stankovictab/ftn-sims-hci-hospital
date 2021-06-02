using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.HCI
{
    public partial class DoctorPanelHCI : Window
    {
        public DoctorPanelHCI()
        {
            InitializeComponent();
        }

        private void Notif_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NotificationPanelHCI();
            this.Close();
            window.ShowDialog();
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AppointmentPanelHCI();
            this.Close();
            window.ShowDialog();
        }

        private void QuickAppointment_Click(object sender, RoutedEventArgs e)
        {
            Window window = new QuickAppointmentHCI();
            this.Close();
            window.ShowDialog();
        }

        private void Holidays_Click(object sender, RoutedEventArgs e)
        {
            Window window = new HolidayRequestPanelHCI();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipment_Click(object sender, RoutedEventArgs e)
        {
            Window window = new DynamicEquipmentPanelHCI();
            this.Close();
            window.ShowDialog();
        }

        private void MedicalRecords_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MedicalRecordsHCI();
            this.Close();
            window.ShowDialog();
        }

        private void PerscValid_Click(object sender, RoutedEventArgs e)
        {
            Window window = new PerscriptionValidationHCI();
            this.Close();
            window.ShowDialog();
        }

        private void PerscReport_Click(object sender, RoutedEventArgs e)
        {
            Window window = new PerscriptionReportHCI();
            this.Close();
            window.ShowDialog();
        }

        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ProfileHCI();
            this.Close();
            window.ShowDialog();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
