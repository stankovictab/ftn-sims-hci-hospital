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
    /// Interaction logic for SecretaryAppointments.xaml
    /// </summary>
    public partial class SecretaryAppointments : Window
    {
        public SecretaryAppointments()
        {
            InitializeComponent();
            MainWindow.patientController.patientService.patientRepository.PatientsInFile1 = MainWindow.patientController.GetAll();
            menu.Items.Add("Home");
            menu.Items.Add("Your Profile");
            menu.Items.Add("Patients");
            menu.Items.Add("Appointments");
            menu.Items.Add("Notifications");
            menu.Items.Add("Exchange Patient Info");
            menu.SelectedItem = menu.Items[3];
            List<Appointment> appointments = new List<Appointment>();
            appointments= MainWindow.appointmentController.appointmentService.appointmentRepository.GetAll();
            foreach(Appointment appointment in appointments)
            {
                Patient p = new Patient();
                p=MainWindow.patientController.GetByID(appointment.patient.user.Jmbg1);
                Doctor d = new Doctor();
                d = MainWindow.doctorController.ds.dr.GetByID(appointment.doctor.user.Jmbg1);
                allAppointments.Items.Add(new Appointment { AppointmentID=appointment.AppointmentID,doctor = d,patient=p,StartTime=appointment.StartTime });
            }
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = menu.SelectedIndex;
            switch (index)
            {
                case 0:
                    Window home = new HomeWindow();
                    this.Hide();
                    home.ShowDialog();
                    this.Close();
                    break;
                case 1:
                    Window profile = new ProfileWindow();
                    this.Hide();
                    profile.ShowDialog();
                    this.Close();
                    break;
                case 2:
                    Window patients = new SecretaryPatients();
                    this.Hide();
                    patients.ShowDialog();
                    this.Close();
                    break;
                case 3:
                    break;


            }
        }

        private void btncancelappointment_Click(object sender, RoutedEventArgs e)
        {
            if (!allAppointments.Items.IsEmpty)
            {
                if (allAppointments.SelectedItem != null)
                {
                    Appointment appointment = (Appointment)allAppointments.SelectedItem;
                    MainWindow.appointmentController.appointmentService.appointmentRepository.Delete(appointment.AppointmentID);
                    Doctor d = MainWindow.doctorController.ds.dr.GetByID(appointment.doctor.user.Jmbg1);
                    Patient p = MainWindow.patientController.GetByID(appointment.patient.user.Jmbg1);
                    d.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByDoctorID(appointment.doctor.user.Jmbg1);
                    p.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByPatientID(appointment.patient.user.Jmbg1);
                    String id = (MainWindow.notificationController.notificationService.notificationRepository.GetAll().Count() + 1).ToString();
                    Notification notification = new Notification(id, "Alert", "Your appointment on  " + appointment.StartTime.ToString() + " has been canceled!", DateTime.Now, false, appointment.patient.user.Jmbg1, appointment.doctor.user.Jmbg1);
                    d.notifications.Add(notification);
                    p.notifications.Add(notification);
                    MainWindow.notificationController.notificationService.notificationRepository.Create(notification);
                    MessageBox.Show("You have successfuly canceled an appointment and all relevant parties have been notified!");
                    allAppointments.Items.Clear();
                    List<Appointment> appointments = new List<Appointment>();
                    appointments = MainWindow.appointmentController.appointmentService.appointmentRepository.GetAll();
                    foreach (Appointment app in appointments)
                    {
                        Patient patient = new Patient();
                        patient = MainWindow.patientController.GetByID(app.patient.user.Jmbg1);
                        Doctor doctor = new Doctor();
                        doctor = MainWindow.doctorController.GetByID(app.doctor.user.Jmbg1);
                        allAppointments.Items.Add(new Appointment { AppointmentID = app.AppointmentID, doctor = doctor, patient = patient, StartTime = app.StartTime });
                    }
                }
            }
        }

        private void btncreateappointment_Click(object sender, RoutedEventArgs e)
        {
            Window appointmentCreation = new SecretaryAppointmentCreation();
            appointmentCreation.ShowDialog();
            allAppointments.Items.Clear();
            List<Appointment> appointments = new List<Appointment>();
            appointments = MainWindow.appointmentController.appointmentService.appointmentRepository.GetAll();
            foreach (Appointment app in appointments)
            {
                Patient p = new Patient();
                p = MainWindow.patientController.GetByID(app.patient.user.Jmbg1);
                Doctor d = new Doctor();
                d = MainWindow.doctorController.GetByID(app.doctor.user.Jmbg1);
                allAppointments.Items.Add(new Appointment { AppointmentID = app.AppointmentID, doctor = d, patient = p, StartTime = app.StartTime });
            }
        }

        private void btnupdateappointment_Click(object sender, RoutedEventArgs e)
        {
            if (allAppointments.SelectedItem != null)
            {
                Appointment a = (Appointment)allAppointments.SelectedItem;
                Window updateAppointment = new SecretaryUpdateAppointment(a.AppointmentID);
                updateAppointment.ShowDialog();
                allAppointments.Items.Clear();
                List<Appointment> appointments = new List<Appointment>();
                appointments = MainWindow.appointmentController.appointmentService.appointmentRepository.GetAll();
                foreach (Appointment app in appointments)
                {
                    Patient p = new Patient();
                    p = MainWindow.patientController.GetByID(app.patient.user.Jmbg1);
                    Doctor d = new Doctor();
                    d = MainWindow.doctorController.GetByID(app.doctor.user.Jmbg1);
                    allAppointments.Items.Add(new Appointment { AppointmentID = app.AppointmentID, doctor = d, patient = p, StartTime = app.StartTime });
                }
            }
        }
    }
}
