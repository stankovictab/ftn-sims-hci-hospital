﻿using Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentRequestPanel : Window
    {
        private string selectedDERID;
        private int alternator = 0;

        public DynamicEquipmentRequestPanel()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll(); // Ucitavanje liste u memoriji
            refreshListView();
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentName = dynamicEquipmentTextBox.Text;
            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");

            // ID request-a je null jer ce se naci u servisu
            DynamicEquipmentRequest req = new DynamicEquipmentRequest(equipmentName, doctor); 
            MainWindow.dynamicEquipmentRequestController.Create(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully created a new holiday request!");
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                loadIntoListView(req);
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentRequestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteRequest.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (dynamicEquipmentRequestListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Status1..."
                string[] parts = dynamicEquipmentRequestListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                selectedDERID = parts2[3];

                string[] parts3 = parts[1].Split(' ');
                string status = parts3[3];
                if (status == "OnHold")
                    btnUpdateRequest.IsEnabled = true;
                else
                    btnUpdateRequest.IsEnabled = false;
            }
        }

        private void btnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentName = dynamicEquipmentTextBox.Text;
            // Ovom request-u je doctor null jer ce se naci u servisu na osnovu id-a request-a
            DynamicEquipmentRequest req = new DynamicEquipmentRequest(selectedDERID, equipmentName); 
            MainWindow.dynamicEquipmentRequestController.Update(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday request!");
            refreshListView();
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentRequestController.Delete(selectedDERID); // Update liste i fajla
            refreshListView();
        }

        private void btnSortByRequestDate_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();

            // Bubble sort - ne mora da se pravi posebna metoda za clean code jer se samo ovde koristi
            if (alternator == 0) // Ascending
            {
                for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (list[j].RequestDate1 > list[j + 1].RequestDate1)
                        {
                            // swap temp and arr[i]
                            DynamicEquipmentRequest temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                alternator = 1;
            }
            else // Descending
            {
                for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (list[j].RequestDate1 < list[j + 1].RequestDate1)
                        {
                            // swap temp and arr[i]
                            DynamicEquipmentRequest temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                alternator = 0;
            }

            foreach (DynamicEquipmentRequest req in list)
                loadIntoListView(req);
        }

        private void btnDynamicEquipmentSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = dynamicEquipmentSearch.Text;
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.EquipmentName1 == query)
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
        private void filterOnHold_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.OnHold)
                    loadIntoListView(req);
            }
        }
        private void filterApproved_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.Approved)
                    loadIntoListView(req);
            }
        }
        private void filterDenied_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.Denied)
                    loadIntoListView(req);
            }
        }

        // Clean Code

        private void loadIntoListView(DynamicEquipmentRequest req) {
            dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
        }

        private List<DynamicEquipmentRequest> getDynamicEquipmentRequestList()
        {
            // TODO: Doctor ID ce se dobiti pri logovanju, pa ce se proslediti u ovaj GetAllByDoctorID()
            // Za sad zamisli da je ulogovan lekar sa ID 0501
            // Takodje moze i da se napravi labela na prozoru da pokazuje koji je doktor ulogovan, ali to je HCI prica
            dynamicEquipmentRequestListView.Items.Clear();
            return MainWindow.dynamicEquipmentRequestController.GetAllByDoctorID("0501");
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }
    }
}
