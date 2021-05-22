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
            Main.Content = new AllAppointmentsPage();
        }

        private void CreateAppointmentButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateAppointmentPage();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NotificationsList(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotificationsPage();

        }

        private void CreateAppointmentSpecialistButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new createAppointmentSpecialist();
        }

        private void FillPoll(object sender, RoutedEventArgs e)
        {
            Main.Content = new PollPage();
        }

        private void ViewAccount(object sender, RoutedEventArgs e)
        {
            Main.Content = null; //TO DO - pregled profila
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.user = null;
            this.Close();
        }
    }
}
