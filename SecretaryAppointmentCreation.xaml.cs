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
using Classes;
using Models;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for SecretaryAppointmentCreation.xaml
    /// </summary>
    public partial class SecretaryAppointmentCreation : Window
    {
        public SecretaryAppointmentCreation()
        {
            InitializeComponent();
            List<Doctor> doctors = new List<Doctor>();
            doctors = MainWindow.doctorController.ds.dr.GetAll();
            List<Patient> patients = new List<Patient>();
            patients = MainWindow.patientController.GetAll();
            foreach(Doctor doctor in doctors)
            {
                cbdoctor.Items.Add(doctor.user.Jmbg1);
            }
            foreach(Patient patient in patients)
            {
                cbpatient.Items.Add(patient.user.Jmbg1);
            }
            cbtype.Items.Add(AppointmentType.Operation);
            cbtype.Items.Add(AppointmentType.Regular);

        }

        private void btnguest_Click(object sender, RoutedEventArgs e)
        {
            Window guestCreation = new GuestCreation();
            guestCreation.ShowDialog();
            List<Patient> patients = new List<Patient>();
            patients = MainWindow.patientController.GetAll();
            cbpatient.Items.Clear();
            foreach (Patient patient in patients)
            {
                cbpatient.Items.Add(patient.user.Jmbg1);
            }
        }

        private void viewappointmentsbtn_Click(object sender, RoutedEventArgs e)
        {
            if (cbdoctor.SelectedItem == null)
            {
                MessageBox.Show("You have to choose a doctor to view possible appointments!");
            }
            else if (cbpatient.SelectedItem == null)
            {
                MessageBox.Show("You have to choose a patient to view possible appointments!");
            }
            else if (cbtype.SelectedItem == null)
            {
                MessageBox.Show("You have to choose the type of the appointment!");
            }
            else
            {
                if (rbdoctor.IsChecked==false&&rbtime.IsChecked==false)
                {
                    Priority priority = Priority.None;
                    Doctor doctor = (Doctor)MainWindow.doctorController.ds.dr.GetByID(cbdoctor.SelectedItem.ToString());
                    DateTime begin = (DateTime)dpbegin.SelectedDate;
                    DateTime end = (DateTime)dpend.SelectedDate;
                    Patient patient = (Patient)MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
                    AppointmentType type = (AppointmentType)cbtype.SelectedItem;
                    List<Appointment> possibleAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(priority, doctor.user.Jmbg1, begin, end, type);
                    foreach(Appointment a in possibleAppointments)
                    {
                        a.patient = patient;
                    }
                    Window pickAppointments = new PossibleAppointments(possibleAppointments);
                    pickAppointments.ShowDialog();
                }
                else if (rbdoctor.IsChecked == true && rbtime.IsChecked == false)
                {
                    Priority priority = Priority.Doctor;
                    Doctor doctor = (Doctor)MainWindow.doctorController.ds.dr.GetByID(cbdoctor.SelectedItem.ToString());
                    DateTime begin = (DateTime)dpbegin.SelectedDate;
                    DateTime end = (DateTime)dpend.SelectedDate;
                    Patient patient = (Patient)MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
                    AppointmentType type = (AppointmentType)cbtype.SelectedItem;
                    List<Appointment> possibleAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(priority, doctor.user.Jmbg1, begin, end, type);
                    foreach (Appointment a in possibleAppointments)
                    {
                        a.patient = patient;
                    }
                    Window pickAppointments = new PossibleAppointments(possibleAppointments);
                    pickAppointments.ShowDialog();
                }
                else
                {
                    Priority priority = Priority.Date;
                    Doctor doctor = (Doctor)MainWindow.doctorController.ds.dr.GetByID(cbdoctor.SelectedItem.ToString());
                    DateTime begin = (DateTime)dpbegin.SelectedDate;
                    DateTime end = (DateTime)dpend.SelectedDate;
                    Patient patient = (Patient)MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
                    AppointmentType type = (AppointmentType)cbtype.SelectedItem;
                    List<Appointment> possibleAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(priority, doctor.user.Jmbg1, begin, end, type);
                    foreach (Appointment a in possibleAppointments)
                    {
                        a.patient = patient;
                    }
                    Window pickAppointments = new PossibleAppointments(possibleAppointments);
                    pickAppointments.ShowDialog();
                }
            }
        }
    }
}
