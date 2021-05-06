using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestUpdate : Window
    {
        public static Classes.HolidayRequestFileStorage hrfs = new Classes.HolidayRequestFileStorage();
        private string selectedRHID;
        public HolidayRequestUpdate(string selectedRHID)
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll();
            this.selectedHRID = selectedHRID;
        }

        private void btnHolidayUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Ne moze samo da se kopira ista metoda kao na creation, jer ID Request-a mora da ostane isti, pa se koristi Update() metoda iz FileStorage-a
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate;
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;

            Classes.DoctorController dc = new Classes.DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Classes.Doctor doctor = dc.GetByID("0501");

            MainWindow.holidayRequestController.Update(selectedHRID, desc, startDate, endDate, doctor); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully updated a holiday request!");
            this.Close(); // this.Hide(); ?
        }
    }
}
