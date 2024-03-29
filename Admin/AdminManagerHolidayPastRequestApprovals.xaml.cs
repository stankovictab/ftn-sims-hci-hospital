﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;
using ftn_sims_hci_hospital.Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerHolidayPastRequestApprovals : Window
    {
        Sort sort = new Sort();

        public AdminManagerHolidayPastRequestApprovals()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll();
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = getHolidayRequestListNotOnHold();
            foreach (HolidayRequest req in list)
            {
                loadIntoListView(req);
            }
        }

        private void btnSortByRequestDate_Click(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = getHolidayRequestListNotOnHold();
            List<Demand> demandList = list.ConvertAll(x => (Demand)x);
            demandList = sort.sort(demandList);
            foreach (HolidayRequest req in demandList)
                loadIntoListView(req);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = searchField.Text;
            List<HolidayRequest> list = getHolidayRequestListNotOnHold();
            foreach (HolidayRequest req in list)
            {
                if (req.doctor.user.Name1 == query || req.doctor.user.LastName1 == query || req.doctor.user.Name1 + " " + req.doctor.user.LastName1 == query)
                    loadIntoListView(req);
            }
            if (query == "")
                refreshListView();
        }

        // Filteri

        private void filterNone_Checked(object sender, RoutedEventArgs e)
        {
            refreshListView();
        }
        private void filterApproved_Checked(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = getHolidayRequestListNotOnHold();
            foreach (HolidayRequest req in list)
            {
                if (req.Status1 == RequestStatus.Approved)
                    loadIntoListView(req);
            }
        }
        private void filterDenied_Checked(object sender, RoutedEventArgs e)
        {
            List<HolidayRequest> list = getHolidayRequestListNotOnHold();
            foreach (HolidayRequest req in list)
            {
                if (req.Status1 == RequestStatus.Denied)
                    loadIntoListView(req);
            }
        }

        // Clean Code

        private void loadIntoListView(HolidayRequest req)
        {
            string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
            holidayRequestListView.Items.Add(new { RequestID1 = req.ID1, DoctorFullName1 = doc, Status1 = req.Status1, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1, RequestDate1 = req.CreationDate1, Commentary1 = req.Commentary1 });
        }

        private List<HolidayRequest> getHolidayRequestListNotOnHold()
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            holidayRequestListView.Items.Clear();
            return MainWindow.holidayRequestController.GetAllNotOnHold();
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
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
