using Classes;
using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestCreation : Window
    {
        public HolidayRequestCreation()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll(); // Ucitavanje liste u memoriji
        }

        // Biznis logika za dodavanje u listu i fajl
        private void btnHolidaySubmit_Click(object sender, RoutedEventArgs e)
        {
            string desc = holidayDescription.Text;
            DateTime startDate = (DateTime)holidayStartDate.SelectedDate; // Mora cast jer vraca DateTime? iz nekog razloga
            DateTime endDate = (DateTime)holidayEndDate.SelectedDate;
            
            DoctorController dc = new DoctorController();
            dc.GetAll(); // Punjenje liste doktora u memoriji
            // TODO: Ovde ce se ubacivati id lekara koji je ulogovan
            Doctor doctor = dc.GetByID("0501");

            // ID request-a je null jer ce se naci u servisu
            HolidayRequest req = new HolidayRequest(desc, startDate, endDate, doctor);
            MainWindow.holidayRequestController.Create(req); // Update-uje se i lista i fajl
            MessageBox.Show("You have successfully created a new holiday request!");
            this.Close(); // this.Hide(); ?
        }
    }
}
