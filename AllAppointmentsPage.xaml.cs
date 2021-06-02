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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    public partial class AllAppointmentsPage : Page
    {
        private AppointmentController appointmentController;
        public AllAppointmentsPage()
        {
            InitializeComponent();
            appointmentController = new AppointmentController();
            LoadAppointments();
        }
        public void CancelAppointment(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li sigurno zelite da otkazete pregled?", "My App", MessageBoxButton.YesNo);
            if (result.Equals(MessageBoxResult.Yes))
            {
                Appointment selected = (Appointment)(appointmentsTable.SelectedItem);
                appointmentController.DeleteAppointment(selected.AppointmentID);
                if (MainWindow.user.blocked)
                {
                    Application.Current.Shutdown();
                }
                LoadAppointments();
            }

        }
        public void UpdateAppointmentTime(object sender, RoutedEventArgs e)
        {
            String id;
            DateTime oldDate;
            Appointment appointment = (Appointment)appointmentsTable.SelectedItem;
            id = appointment.AppointmentID;
            oldDate = appointment.StartTime;
            var dani = (oldDate - DateTime.Now).Days;

            if (appointment.rescheduled == 1)
            {
                MessageBox.Show("Ne mozete da pomerate pregled koji ste vec pomerili");
            }
            else
            {

                if ((oldDate - DateTime.Now).Days <= 1)
                {
                    MessageBox.Show("Ne mozete da pomerate datum ako je ostalo manje od 24h do pregleda");
                }
                else
                {
                    UpdateAppointmentPatient uap = new UpdateAppointmentPatient(appointment);
                    uap.Show();
                }
            }
        }

        void LoadAppointments()
        {
            List<Appointment> appoinments = appointmentController.GetAllByPatientId(MainWindow.user.Jmbg1);
            appointmentsTable.ItemsSource = appoinments;
        }

    }
}
