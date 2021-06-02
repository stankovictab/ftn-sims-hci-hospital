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
    public partial class AllAppointments : Window
    {
        private AppointmentController appointmentController;
        private String patientName;
        public AllAppointments()
        {
            InitializeComponent();
            appointmentController = new AppointmentController();
            List<Appointment> appoinments = appointmentController.GetAllByPatientId(MainWindow.user.Jmbg1);
            lvUsers.ItemsSource = appoinments;
        }

        private void submitDeletion(object sender, RoutedEventArgs e)
        {
            Appointment selected = (Appointment)(lvUsers.SelectedItem);
            String id = selected.AppointmentID;
            appointmentController.DeleteAppointment(id);
        }

        private void submitUpdate(object sender, RoutedEventArgs e)
        {
            String id;
            DateTime oldDate;
            Appointment appointment = (Appointment)lvUsers.SelectedItem;
            id = appointment.AppointmentID;
            oldDate = appointment.StartTime;
            var dani = (oldDate - DateTime.Now).Days;

            //DateTime currentDate = DateTime.Now;
            if ((oldDate - DateTime.Now).Days <= 1)
            {
                MessageBox.Show("Ne mozete da pomerate datum ako je ostalo manje od 24h do pregleda");
            }
            else
            {
                UpdateAppointmentPatient uap = new UpdateAppointmentPatient(id, oldDate);
                uap.Show();
            }

            /*string id = UpdateID.Text;
            string doc = UpdateDoc.Text;
            string[] startTime = UpdateTime.Text.Split(':');
            string[] date = UpdateDate.Text.Split('.');
            string endTxt = UpdateTime.Text;
            string[] endTime = endTxt.Split(':');

            DateTime start = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(startTime[0]), int.Parse(startTime[1]), int.Parse(startTime[2]));
            DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTime[0]), int.Parse(endTime[1]), int.Parse(endTime[2]));
            Appointment ap = new Appointment(id, doc, patientName, start, end);
            if (!afs.UpdateAppointment(ap))
            {
                MessageBox.Show("Id doesn't exist");
            }
            else
            {
                MessageBox.Show("Successfully updated");
            }*/
        }
    }
}
