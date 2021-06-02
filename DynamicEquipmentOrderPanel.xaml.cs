using Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentOrderPanel : Window
    {
        private string selectedDEOID;
        private int alternator = 0;

        public DynamicEquipmentOrderPanel()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentOrderController.GetAll(); // Ucitavanje liste u memoriji
            refreshListView();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentOrder> list = getDynamicEquipmentOrderList();
            foreach (DynamicEquipmentOrder ord in list)
            {
                loadIntoListView(ord);
            }
        }

        // SelectionChanged="dynamicEquipmentOrderListView_SelectionChanged" dodat u XAML ListView kao atribut
        private void dynamicEquipmentOrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteOrder.IsEnabled = true;
            // Posto izbrise SelectedItem, on je null, a ova metoda se automatski poziva, pa ovako izbegavamo exception
            if (dynamicEquipmentOrderListView.SelectedItem != null)
            {
                // MessageBox.Show(dynamicEquipmentOrderListView.SelectedItem.ToString());
                // Ovo izgleda kao "{ OrderID1 = 2, Status1..."
                string[] parts = dynamicEquipmentOrderListView.SelectedItem.ToString().Split(','); // Ne ""
                string[] parts2 = parts[0].Split(' ');
                selectedDEOID = parts2[3];

                string[] parts3 = parts[1].Split(' ');
                string status = parts3[3];
                activateButtonsByStatus(status);
            }
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            // Treba da otvara novi prozor, slican creation-u
            Window dynamicEquipmentOrderUpdate = new DynamicEquipmentOrderUpdate(selectedDEOID); // U konstruktor za prozor se prosledjuje ID izabranog
            dynamicEquipmentOrderUpdate.ShowDialog();
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentOrderController.Delete(selectedDEOID); // Update liste i fajla
            refreshListView();
        }

        private void btnSortByOrderDate_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentOrder> list = getDynamicEquipmentOrderList();

            // Bubble sort - ne mora da se pravi posebna metoda za clean code jer se samo ovde koristi
            if (alternator == 0) // Ascending
            {
                for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (list[j].OrderDate1 > list[j + 1].OrderDate1)
                        {
                            // swap temp and arr[i]
                            DynamicEquipmentOrder temp = list[j];
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
                        if (list[j].OrderDate1 < list[j + 1].OrderDate1)
                        {
                            // swap temp and arr[i]
                            DynamicEquipmentOrder temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
                alternator = 0;
            }

            foreach (DynamicEquipmentOrder ord in list)
                loadIntoListView(ord);
        }

        private void btnDynamicEquipmentSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = dynamicEquipmentSearch.Text;
            List<DynamicEquipmentOrder> list = getDynamicEquipmentOrderList();
            foreach (DynamicEquipmentOrder ord in list)
            {
                if (ord.EquipmentNames1 == query)
                    loadIntoListView(ord);
            }
            if (query == "")
                refreshListView();
        }

        // Filteri

        private void filterNone_Checked(object sender, RoutedEventArgs e)
        {
            refreshListView();
        }
        private void filterSent_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentOrder> list = MainWindow.dynamicEquipmentOrderController.GetAll();
            dynamicEquipmentOrderListView.Items.Clear();
            foreach (DynamicEquipmentOrder ord in list)
            {
                if (ord.Status1 == DynamicEquipmentOrderStatus.Sent)
                    loadIntoListView(ord);
            }
        }
        private void filterWaiting_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentOrder> list = MainWindow.dynamicEquipmentOrderController.GetAll();
            dynamicEquipmentOrderListView.Items.Clear();
            foreach (DynamicEquipmentOrder ord in list)
            {
                if (ord.Status1 == DynamicEquipmentOrderStatus.Waiting)
                    loadIntoListView(ord);
            }
        }
        private void filterCompleted_Checked(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentOrder> list = MainWindow.dynamicEquipmentOrderController.GetAll();
            dynamicEquipmentOrderListView.Items.Clear();
            foreach (DynamicEquipmentOrder ord in list)
            {
                if (ord.Status1 == DynamicEquipmentOrderStatus.Completed)
                    loadIntoListView(ord);
            }
        }

        private void btnSimulateConfirmation_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentOrderController.SetToWaiting(selectedDEOID); // Update-uje se i lista i fajl
            MessageBox.Show("Confirmation has been simulated. The shipment will arrive at {DD-MM-YY}");
            refreshListView();
        }
        private void btnSimulateShipment_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.dynamicEquipmentOrderController.SetToCompleted(selectedDEOID); // Update-uje se i lista i fajl
            MessageBox.Show("Shipment has arrived.");
            refreshListView();
        }

        // Clean Code

        private void loadIntoListView(DynamicEquipmentOrder ord)
        {
            dynamicEquipmentOrderListView.Items.Add(new { OrderID1 = ord.OrderID1, Status1 = ord.Status1, EquipmentNames1 = ord.EquipmentNames1, EquipmentAmounts1 = ord.EquipmentAmounts1, OrderDate1 = ord.OrderDate1 });
        }

        private List<DynamicEquipmentOrder> getDynamicEquipmentOrderList()
        {
            dynamicEquipmentOrderListView.Items.Clear();
            return MainWindow.dynamicEquipmentOrderController.GetAll();
        }

        private void refreshListView()
        {
            btnRefresh.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); // Klik na dugme, odnosno refresh liste
        }

        private void activateButtonsByStatus(string status)
        {
            if (status == DynamicEquipmentOrderStatus.Sent.ToString())
            {
                btnUpdateOrder.IsEnabled = true;
                btnSimulateConfirmation.IsEnabled = true;
                btnSimulateShipment.IsEnabled = false;
            }
            else if (status == DynamicEquipmentOrderStatus.Waiting.ToString())
            {
                btnUpdateOrder.IsEnabled = false;
                btnSimulateConfirmation.IsEnabled = false;
                btnSimulateShipment.IsEnabled = true;
            }
            else
            {
                btnUpdateOrder.IsEnabled = false;
                btnSimulateConfirmation.IsEnabled = false;
                btnSimulateShipment.IsEnabled = false;
            }
        }
    }
}
