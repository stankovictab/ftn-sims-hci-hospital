using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    public partial class PatientWindow : Window
    {

        public PatientWindow()
        {
            InitializeComponent();
            pregledProfilaButton.Content = "Pregled profila " + MainWindow.user.Username1;
        }

        private void ShowAllAppointments(object sender, RoutedEventArgs e)
        {
            //AllAppointments allApp = new AllAppointments();
            Main.Content = new AllAppointmentsPage();
            //allApp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateAppointment c = new CreateAppointment();
            c.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NotificationsList(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotificationsPage();

        }

        private void createAppointmentSpecialist(object sender, RoutedEventArgs e)
        {
            Main.Content = new createAppointmentSpecialist();
        }
    }
}
