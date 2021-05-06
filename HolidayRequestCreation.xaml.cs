using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestCreation : Window
    {
        public HolidayRequestCreation()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Kada se otvori prozor ucita se cela lista
        }

        // Biznis logika za dodavanje u listu i fajl
        private void btnHolidaySubmit_Click(object sender, RoutedEventArgs e)
        {
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate; // Mora cast jer vraca DateTime? iz nekog razloga
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;
            Classes.DoctorController dc = new Classes.DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Classes.Doctor doctor = dc.GetByID("0501");

            // Da bih saznao koji je poslednji id holidayRequest-ova da bih ovom inkrementovao, trebam da prolazim kroz sve i da cim nadje null da mi kaze koji je poslednji
            string currentID = "1"; // Mora da se postavi jer vristi
            for (int i = 1; i < 100; i++)
            {
                if (hrfs.GetByID(i.ToString()) == null)
                {
                    break;
                }
                currentID = (i + 1).ToString(); // Ok je ako je prazan string, odnosno ako nema nista u holidayrequests.txt
            }

            Classes.DoctorFileStorage dfs = new Classes.DoctorFileStorage();
            dfs.DoctorsInFile1 = dfs.GetAll();
            Classes.Doctor doctor = dfs.GetByID("0501"); // TODO: Ovde ce se ubacivati id lekara koji je ulogovan

            MainWindow.holidayRequestController.Create(desc, startDate, endDate, doctor); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully created a new holiday request!");
            this.Close(); // this.Hide(); ?
        }
    }
}
