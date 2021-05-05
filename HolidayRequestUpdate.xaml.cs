using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{

    //nemoj da prihvatis ovaj!!!
    public partial class HolidayRequestUpdate : Window
    {
        private string selectedHRID;

        public HolidayRequestUpdate(string selectedHRID)
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll();
            this.selectedHRID = selectedHRID;
        }

        private void btnHolidayUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
