using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestCreation : Window
    {

        public static Classes.HolidayRequestFileStorage hrfs = new Classes.HolidayRequestFileStorage();
        public HolidayRequestCreation()
        {
            InitializeComponent();
            hrfs.HolidayRequestsInFile1 = hrfs.GetAll(); // Kada se otvori prozor ucita se cela lista u ovo lokalno polje hrfs, ovo mora
        }

        // Biznis logika za dodavanje u listu, a i u fajl
        private void btnHolidaySubmit_Click(object sender, RoutedEventArgs e)
        {
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate; // Mora cast jer vraca DateTime? iz nekog razloga
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;

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

            Classes.HolidayRequest hr = new Classes.HolidayRequest(currentID, desc, startDate, endDate, doctor);
            hrfs.Create(hr); // Da update-uje listu u memoriji
            hrfs.UpdateAll(hrfs.HolidayRequestsInFile1); // Da update-uje i sam fajl, preko update-ovane liste u memoriji
            MessageBox.Show("You have successfully created a new holiday request!");

            this.Close();
            // this.Hide(); ?
        }
    }
}
