using Classes;
using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestUpdate : Window
    {
        private string selectedHRID;

        public HolidayRequestUpdate(string selectedHRID)
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Ucitavanje liste u memoriji
            this.selectedHRID = selectedHRID;
        }

        private void btnHolidayUpdate_Click(object sender, RoutedEventArgs e)
        {
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate;
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;
            
            // Ovom request-u je doctor null jer ce se naci u servisu na osnovu id-a request-a
            HolidayRequest req = new HolidayRequest(selectedHRID, desc, startDate, endDate);
            MainWindow.holidayRequestController.Update(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday request!");
            this.Close(); // this.Hide(); ?
        }
    }
}
