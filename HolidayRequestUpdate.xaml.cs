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
            MainWindow.holidayRequestController.GetAll();
            this.selectedHRID = selectedHRID;
        }

        private void btnHolidayUpdate_Click(object sender, RoutedEventArgs e)
        {
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate;
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;

            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");

            MainWindow.holidayRequestController.Update(selectedHRID, desc, startDate, endDate, doctor); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday request!");
            this.Close(); // this.Hide(); ?
        }
    }
}
