using System;
using System.Windows;

namespace ftn_sims_hci_hospital {
    public partial class HolidayRequestUpdate : Window {
        public static Classes.HolidayRequestFileStorage hrfs = new Classes.HolidayRequestFileStorage();
        private string selectedRHID;
        public HolidayRequestUpdate(string selectedRHID) {
            InitializeComponent();
            hrfs.HolidayRequestsInFile1 = hrfs.GetAll();
            this.selectedRHID = selectedRHID;
        }

        private void btnHolidayUpdate_Click(object sender, RoutedEventArgs e) {
            // Ne moze samo da se kopira ista metoda kao na creation, jer ID Request-a mora da ostane isti, pa se koristi Update() metoda iz FileStorage-a
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate;
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;

            Classes.DoctorFileStorage dfs = new Classes.DoctorFileStorage();
            dfs.DoctorsInFile1 = dfs.GetAll();
            Classes.Doctor doctor = dfs.GetByID("0501"); // TODO: Ovde ce se ubacivati id lekara koji je ulogovan

            Classes.HolidayRequest hr = new Classes.HolidayRequest(selectedRHID, desc, startDate, endDate, doctor);
            hrfs.Update(hr); // Da update-uje listu u memoriji
            hrfs.UpdateAll(hrfs.HolidayRequestsInFile1); // Da update-uje i sam fajl, preko update-ovane liste u memoriji
            MessageBox.Show("You have successfully updated a holiday request!");

            this.Close();
        }
    }
}
