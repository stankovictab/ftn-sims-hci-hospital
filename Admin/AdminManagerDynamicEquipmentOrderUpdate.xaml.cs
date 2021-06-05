using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerDynamicEquipmentOrderUpdate : Window, INotifyPropertyChanged // HCI
    {


        // OVO NIJE URADJENO


        private string selectedDEOID;
        public AdminManagerDynamicEquipmentOrderUpdate(string selectedDEOID)
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();
            this.selectedDEOID = selectedDEOID;
            this.DataContext = this; // HCI
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
            // if (int.TryParse(dynamicEquipmentTextBox.Text, out int result) == true && result > 0 && result < 101) // HCI
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
        {
            // Ovaj if je backup validacija dok ne skapiram kako da onemogucim dugme dok validacija text polja ne prolazi
            if (int.TryParse(dynamicEquipmentTextBox.Text, out int result) == true && result > 0 && result < 101) // HCI
                {
                /*
                TODO
                MainWindow.dynamicEquipmentRequestController.GetAll();
                string equipmentAmount = dynamicEquipmentTextBox.Text;
                MainWindow.dynamicEquipmentRequestController.Update(selectedDERID, equipmentName, doctor); // Update-uje se i lista i fajl
                MessageBox.Show("You have successfully updated a Dynamic Equipment Request!");
                refreshListView();
                */
            }
            else
            {
                MessageBox.Show("Please enter a correct value.");
            }
        }

        private void btnFinalizeOrder_Click(object sender, RoutedEventArgs e)
        {
            // TODO
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
