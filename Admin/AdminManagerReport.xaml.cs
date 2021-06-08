using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;
using ftn_sims_hci_hospital.Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerReport : Window
    {
        public AdminManagerReport()
        {
            InitializeComponent();
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
            // Ostaje na istoj stranici
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

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            DateTime? sd = startDate.SelectedDate;
            DateTime? ed = endDate.SelectedDate;

            if(check.IsChecked == true)
            {
                List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAll();
                AdminManagerReportPDF window = new AdminManagerReportPDF(DateTime.MinValue, DateTime.MaxValue, list);
                window.ShowDialog();
                check.IsChecked = false;
                startDate.IsEnabled = true;
                endDate.IsEnabled = true;
                return;
            }

            if ((sd == null || ed == null ) || (sd > ed))
            {
                MessageBox.Show("Please enter correct dates.");
            }
            else
            {
                List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAll();
                List<DynamicEquipmentRequest> passedList = new List<DynamicEquipmentRequest>();
                foreach (DynamicEquipmentRequest req in list)
                {
                    if (req.CreationDate1 > (DateTime)sd && req.CreationDate1 < (DateTime)ed)
                    {
                        passedList.Add(req);
                    }
                }
                if (passedList.Count == 0)
                    MessageBox.Show("There are no requests for the selected time period, please select a different one.");

                AdminManagerReportPDF window = new AdminManagerReportPDF((DateTime) sd, (DateTime) ed, passedList);
                window.ShowDialog();
                return;
            }
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            startDate.IsEnabled = false;
            endDate.IsEnabled = false;
        }
        
        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            startDate.IsEnabled = true;
            endDate.IsEnabled = true;
        }
    }
}
