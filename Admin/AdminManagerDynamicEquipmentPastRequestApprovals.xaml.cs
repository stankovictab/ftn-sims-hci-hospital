using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerDynamicEquipmentPastRequestApprovals : Window
    {
        public AdminManagerDynamicEquipmentPastRequestApprovals()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();

            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAll();
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 != DynamicEquipmentRequestStatus.OnHold)
                {
                    string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
                    dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, DoctorFullName1 = doc, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
                }
            }
        }

        // HCI

        private void HolidayRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerHolidayRequestApprovals();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentRequestApprovals();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentOrderPanel_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentOrderPanel();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentOrderCreation_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentOrderCreation();
            this.Close();
            window.ShowDialog();
        }

        private void PollResults_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerPollResults();
            this.Close();
            window.ShowDialog();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerReport();
            this.Close();
            window.ShowDialog();
        }

        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerProfile();
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
