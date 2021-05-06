using Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentOrderCreation : Window
    {
        string selectedAmount = "";

        public DynamicEquipmentOrderCreation()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();

            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAll(); // Dobavlja prvo iz fajla pa iz liste
            dynamicEquipmentOrderListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == DynamicEquipmentRequestStatus.Approved)
                {
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    dynamicEquipmentOrderListView.Items.Add(new { RequestID1 = req.RequestID1, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1 });
                }
            }
        }

        private void dynamicEquipmentOrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdateAmount.IsEnabled = true;
        }

        private void btnUpdateAmount_Click(object sender, RoutedEventArgs e)
        {
            selectedAmount = dynamicEquipmentTextBox.Text;


            // TODO: Ako ovo nece, samo prekopiraj sve iz btnShowRequests_Click()
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void btnFinalizeOrder_Click(object sender, RoutedEventArgs e)
        {
            // Treba da uzme amount postavljen i da time napravi order, nema potrebe za nekom novom klasom ili novim txt fajlom
        }
    }
}
