﻿using Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentOrderUpdate : Window
    {
        private string selectedDEOID;
        public DynamicEquipmentOrderUpdate(string selectedDEOID)
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();
            this.selectedDEOID = selectedDEOID;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAll(); // Dobavlja prvo iz fajla pa iz liste
            dynamicEquipmentOrderListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                dynamicEquipmentOrderListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentNames1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
            }
        }

        // SelectionChanged="dynamicEquipmentRequestListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentOrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdateAmount.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (dynamicEquipmentOrderListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Status1..."
                string[] parts = dynamicEquipmentOrderListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                selectedDEOID = parts2[3];

                string[] parts3 = parts[1].Split(' ');
                string status = parts3[3];
            }
        }

        private void btnUpdateAmount_Click(object sender, RoutedEventArgs e)
        {/*
            MainWindow.dynamicEquipmentRequestController.GetAll();
            string equipmentAmount = dynamicEquipmentTextBox.Text;
            MainWindow.dynamicEquipmentRequestController.Update(selectedDERID, equipmentName, doctor); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday Request!");

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnShowRequests.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
            */
        }

        private void btnFinalizeOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
