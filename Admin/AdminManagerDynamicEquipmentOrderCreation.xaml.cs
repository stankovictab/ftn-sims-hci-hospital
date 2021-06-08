using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerDynamicEquipmentOrderCreation : Window, INotifyPropertyChanged // HCI
    {
        string selectedDERID;
        string selectedDEREN;
        string selectedDEREA;

        public AdminManagerDynamicEquipmentOrderCreation()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();
            refreshListView();
            this.DataContext = this; // HCI
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<DynamicEquipmentRequest> list = getDynamicEquipmentRequestList();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 == RequestStatus.Approved && req.Ordered1 == false)
                {
                    loadIntoListView(req);
                }
            }
        }

        private void dynamicEquipmentOrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // if (int.TryParse(dynamicEquipmentTextBox.Text, out int result) == true && result > 0 && result < 101) // HCI
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
            // Ovaj if je backup validacija dok ne skapiram kako da onemogucim dugme dok validacija text polja ne prolazi
            if (int.TryParse(dynamicEquipmentTextBox.Text, out int result) == true && result > 0 && result < 101) // HCI
            {
                selectedDEREA = dynamicEquipmentTextBox.Text;
                // Ovom request-u je doctor null jer ce se naci u servisu na osnovu id-a request-a
                // DynamicEquipmentRequest req = new DynamicEquipmentRequest(selectedDERID, selectedDEREN, selectedDEREA);
                RequestFactory rf = new RequestFactory(selectedDERID, selectedDEREN, selectedDEREA);
                DynamicEquipmentRequest req = (DynamicEquipmentRequest)rf.getConcreteObject(ConstructorType.DynamicEquipmentRequestUpdate);

                MainWindow.dynamicEquipmentRequestController.Update(req);
                refreshListView();
            }
            else
            {
                MessageBox.Show("Please enter a correct value.");
            }
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
            // DynamicEquipmentOrder ord = new DynamicEquipmentOrder(equipmentNames, equipmentAmounts);
            OrderFactory rf = new OrderFactory(equipmentNames, equipmentAmounts);
            DynamicEquipmentOrder order = (DynamicEquipmentOrder)rf.getConcreteObject(ConstructorType.DynamicEquipmentOrderCreation);

            MainWindow.dynamicEquipmentOrderController.Create(order);
            // Request lista mora da se izbrise kada se finalizuje, mozda jos neki bool, kao ordered?
            MainWindow.dynamicEquipmentRequestController.SetAllApprovedToOrdered();
            refreshListView();
        }

        // Clean Code

        private void loadIntoListView(DynamicEquipmentRequest req)
        {
            dynamicEquipmentOrderListView.Items.Add(new { RequestID1 = req.ID1, EquipmentName1 = req.EquipmentName1, EquipmentAmount1 = req.EquipmentAmount1, RequestDate1 = req.CreationDate1 });
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
            // Ostaje na istoj stranici
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _amountValue;
        public int AmountValue
        {
            get
            {
                return _amountValue;
            }
            set
            {
                if (value != _amountValue)
                {
                    _amountValue = value;
                    OnPropertyChanged("AmountValue");
                }
            }
        }
    }
}
