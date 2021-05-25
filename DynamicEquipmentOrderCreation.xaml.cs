using Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentOrderCreation : Window
    {
        string selectedDERID;
        string selectedDEREN;
        string selectedDEREA;

        public DynamicEquipmentOrderCreation()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.Approved && req.Ordered1 == false)
                {
                    loadIntoListView(req);
                }
            }
        }

        private void dynamicEquipmentOrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdateAmount.IsEnabled = true;
            if (dynamicEquipmentOrderListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentRequestListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ RequestID1 = 2, Status1..."
                string[] parts = dynamicEquipmentOrderListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                selectedDERID = parts2[3];

                string[] parts3 = parts[1].Split(' ');
                selectedDEREN = parts3[3];
            }
        }

        private void btnUpdateAmount_Click(object sender, RoutedEventArgs e)
        {
            selectedDEREA = dynamicEquipmentTextBox.Text;
            // Ovom request-u je doctor null jer ce se naci u servisu na osnovu id-a request-a
            DynamicEquipmentRequest req = new DynamicEquipmentRequest(selectedDERID, selectedDEREN, selectedDEREA);
            MainWindow.dynamicEquipmentRequestController.Update(req);
            refreshListView();
        }

        private void btnFinalizeOrder_Click(object sender, RoutedEventArgs e)
        {
            // Treba da uzme informacije iz celog listview i da time napravi order, nema potrebe za nekom novom klasom ili novim txt fajlom
            string equipmentNames = "";
            string equipmentAmounts = "";
            // MessageBox.Show(dynamicEquipmentOrderListView.Items[0].ToString());
            for (int i = 0; i < dynamicEquipmentOrderListView.Items.Count; i++)
            {
                string[] parts = dynamicEquipmentOrderListView.Items[i].ToString().Split(',');
                string[] parts2 = parts[1].Split(' ');
                equipmentNames += parts2[3] + ";";
                string[] parts3 = parts[2].Split(' ');
                equipmentAmounts += parts3[3] + ";";
            }
            // Brisanje poslednjeg karaktera ';'
            equipmentNames = equipmentNames.Remove(equipmentNames.Length - 1, 1);
            equipmentAmounts = equipmentAmounts.Remove(equipmentAmounts.Length - 1, 1);
            MessageBox.Show("Oprema : " + equipmentNames + "\n" + "Kolicina : " + equipmentAmounts);
            MainWindow.dynamicEquipmentOrderController.Create(equipmentNames, equipmentAmounts);
            // Request lista mora da se izbrise kada se finalizuje, mozda jos neki bool, kao ordered?
            MainWindow.dynamicEquipmentRequestController.SetAllApprovedToOrdered();
            refreshListView();
        }

        // Clean Code

        private void loadIntoListView(DynamicEquipmentRequest req)
        {
            dynamicEquipmentOrderListView.Items.Add(new { RequestID1 = req.RequestID1, EquipmentName1 = req.EquipmentName1, EquipmentAmount1 = req.EquipmentAmount1, RequestDate1 = req.RequestDate1 });
        }

        private List<DynamicEquipmentRequest> getDynamicEquipmentRequestList()
        {
            dynamicEquipmentOrderListView.Items.Clear();
            return MainWindow.dynamicEquipmentRequestController.GetAll();
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }
    }
}
