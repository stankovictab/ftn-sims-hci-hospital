using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for UrgentAppointmentCreation.xaml
    /// </summary>
    public partial class UrgentAppointmentCreation : Window
    {
        public UrgentAppointmentCreation()
        {
            InitializeComponent();
            getPatients();
            cbspecialization.Items.Add(DoctorSpecialization.GeneralPractice);
            cbspecialization.Items.Add(DoctorSpecialization.Specialist);
        }
        private void getPatients()
        {
            List<Patient> patients = new List<Patient>();
            patients = MainWindow.patientController.GetAll();
            cbpatient.Items.Clear();
            foreach (Patient patient in patients)
            {
                cbpatient.Items.Add(patient.user.Jmbg1);
            }
        }

        private void btnguest_Click(object sender, RoutedEventArgs e)
        {
            Window guestCreation = new GuestCreation();
            guestCreation.ShowDialog();
            getPatients();
        }


        private void viewappointmentsbtn_Click(object sender, RoutedEventArgs e)
        {
            if (cbspecialization.SelectedItem == null)
            {
                MessageBox.Show("You must choose a specialization!");
            }
            else
            {
                List<Doctor> neededDoctors = getNeededDoctors();
                bool isAppointmentMade = false;
                isAppointmentMade = makeAppointmentForSpecializedDoctors(neededDoctors, isAppointmentMade);
                if (isAppointmentMade)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There isn't any doctors available at the moment, but you can choose to reschedule someone else's appointment!");
                    List<Appointment> appointmentsForRescheduling = new List<Appointment>();
                    getReservedAppointmentsInNextHour(neededDoctors, appointmentsForRescheduling);
                    generateSortedAppointments(appointmentsForRescheduling);
                }

            }
        }

        private void generateSortedAppointments(List<Appointment> appointmentsForRescheduling)
        {
            ObservableCollection<Appointment> sortedReservedAppointments = getAllNextAvailibleAppointmentSlots(appointmentsForRescheduling);
            sortedReservedAppointments = new ObservableCollection<Appointment>(from i in sortedReservedAppointments orderby i.StartTime select i);
            foreach (Appointment sortedAppointment in sortedReservedAppointments)
            {
                foreach (Appointment reservedAppointment in appointmentsForRescheduling)
                {
                    if (reservedAppointment.doctor.user.Jmbg1.Equals(sortedAppointment.doctor.user.Jmbg1))
                    {
                        addSortedAppointmentToListView(reservedAppointment);
                        break;
                    }
                }

            }
        }

        private void addSortedAppointmentToListView(Appointment reservedAppointment)
        {
            string patientID, doctorID;
            Patient p = new Patient();
            patientID = reservedAppointment.patient.user.Jmbg1;
            p = MainWindow.patientController.GetByID(patientID);
            Doctor d = new Doctor();
            doctorID = reservedAppointment.doctor.user.Jmbg1;
            d = MainWindow.doctorController.ds.dr.GetByID(doctorID);
            reservedAppointments.Items.Add(new Appointment { AppointmentID = reservedAppointment.AppointmentID, doctor = d, patient = p, StartTime = reservedAppointment.StartTime });
        }

        private static ObservableCollection<Appointment> getAllNextAvailibleAppointmentSlots(List<Appointment> appointmentsForRescheduling)
        {
            ObservableCollection<Appointment> sortedReservedAppointments = new ObservableCollection<Appointment>();
            DateTime newCurrentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 0, 0, 0);
            DateTime newEndTime = new DateTime(newCurrentTime.Year, newCurrentTime.Month, newCurrentTime.Day + 2, 0, 0, 0);
            foreach (Appointment possibleAppointment in appointmentsForRescheduling)
            {
                List<Appointment> possibleAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(Priority.None, possibleAppointment.doctor.user.Jmbg1, newCurrentTime, newEndTime, AppointmentType.Regular);
                sortedReservedAppointments.Add(possibleAppointments[0]);
            }

            return sortedReservedAppointments;
        }

        private static void getReservedAppointmentsInNextHour(List<Doctor> neededDoctors, List<Appointment> appointmentsForRescheduling)
        {
            bool IsAdded = false;
            foreach (Doctor specializedDoctor in neededDoctors)
            {
                List<Appointment> doctorsAppointments = MainWindow.appointmentController.GetAllByDoctorId(specializedDoctor.user.Jmbg1);
                foreach (Appointment doctorsAppointment in doctorsAppointments)
                {
                    if (doctorsAppointment.StartTime.Equals(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0))&&!(doctorsAppointment.isUrgent))
                    {
                        appointmentsForRescheduling.Add(doctorsAppointment);
                        IsAdded = true;
                        break;
                    }
                }
            }
            if(!IsAdded)
            {
                MessageBox.Show("All doctors already have an urgent appointment in the next hour!");
            }
        }

        private List<Doctor> getNeededDoctors()
        {
            List<Doctor> allDoctors = MainWindow.doctorController.GetAll();
            List<Doctor> neededDoctors = new List<Doctor>();
            foreach (Doctor doctorChecker in allDoctors)
            {
                if (doctorChecker.specialization == (DoctorSpecialization)cbspecialization.SelectedItem)
                {
                    neededDoctors.Add(doctorChecker);
                }
            }

            return neededDoctors;
        }

        private bool makeAppointmentForSpecializedDoctors(List<Doctor> neededDoctors, bool isAppointmentMade)
        {
            foreach (Doctor specializedDoctor in neededDoctors)
            {
                DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime endTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day + 1, 0, 0, 0);
                List<Appointment> availableAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(Priority.None, specializedDoctor.user.Jmbg1, currentTime, endTime, AppointmentType.Regular);
                if (availableAppointments.Count() != 0)
                {
                    isAppointmentMade = createAppointments(isAppointmentMade, specializedDoctor, availableAppointments);
                    if (isAppointmentMade)
                        break;

                }
            }

            return isAppointmentMade;
        }

        private bool createAppointments(bool isAppointmentMade, Doctor specializedDoctor, List<Appointment> availableAppointments)
        {
            
            foreach (Appointment available in availableAppointments)
            {
                if((specializedDoctor.shift==Shift.MORNING && DateTime.Now.Hour+1<14)||(specializedDoctor.shift==Shift.AFTERNOON && DateTime.Now.Hour+1<20))
                {
                    if (available.StartTime.Equals(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0)))
                    {
                        Appointment currentApp = createAppointment(specializedDoctor, available);
                        notifyDoctor(specializedDoctor, currentApp);
                        isAppointmentMade = true;
                        break;
                    }
                }
            }

            return isAppointmentMade;
        }

        private static void notifyDoctor(Doctor specializedDoctor, Appointment currentApp)
        {
            specializedDoctor.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByDoctorID(specializedDoctor.user.Jmbg1);
            String id = (MainWindow.notificationController.notificationService.notificationRepository.GetAll().Count() + 1).ToString();
            Notification notification = new Notification(id, "Alert", "You have a new appointment on  " + currentApp.StartTime.ToString(), DateTime.Now, false, "", specializedDoctor.user.Jmbg1);
            specializedDoctor.notifications.Add(notification);
            MainWindow.notificationController.notificationService.notificationRepository.Create(notification);
            MessageBox.Show("You have successfuly created an appointment and all relevant parties have been notified!");
        }

        private Appointment createAppointment(Doctor specializedDoctor, Appointment available)
        {
            Appointment currentApp = new Appointment();
            currentApp.StartTime = available.StartTime;
            currentApp.EndTime = available.EndTime;
            currentApp.AppointmentID = (MainWindow.appointmentController.appointmentService.appointmentRepository.GetAll().Count() + 1).ToString();
            currentApp.patient = MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
            currentApp.doctor = specializedDoctor;
            currentApp.Room = new Room();
            currentApp.Room.RoomNumber = specializedDoctor.room.RoomNumber;
            currentApp.isUrgent = true;
            MainWindow.appointmentController.appointmentService.appointmentRepository.Create(currentApp);
            return currentApp;
        }

        private void makeappointmentbtn_Click(object sender, RoutedEventArgs e)
        {
            if(reservedAppointments.SelectedItem==null)
            {
                MessageBox.Show("You must select an appointment in order to reschedule it!");
            }
            else
            {
                Appointment currentAppointment = (Appointment)reservedAppointments.SelectedItem;
                Doctor adequateDoctor = MainWindow.doctorController.GetByID(currentAppointment.doctor.user.Jmbg1);
                Appointment rescheduledAppointment = getRescheduledAppointmentReady(currentAppointment, adequateDoctor);
                getCurrentAppointmentReady(currentAppointment, adequateDoctor);
                MainWindow.appointmentController.appointmentService.appointmentRepository.Update(currentAppointment);
                MainWindow.appointmentController.appointmentService.appointmentRepository.Create(rescheduledAppointment);
                adequateDoctor.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByDoctorID(adequateDoctor.user.Jmbg1);
                currentAppointment.patient.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByPatientID(currentAppointment.patient.user.Jmbg1);
                notifyRelevantParties(currentAppointment, adequateDoctor, rescheduledAppointment);
                this.Close();
            }
        }

        private void getCurrentAppointmentReady(Appointment currentAppointment, Doctor adequateDoctor)
        {
            currentAppointment.Room = new Room();
            currentAppointment.Room.RoomNumber = adequateDoctor.room.RoomNumber;
            Patient adequatePatient = MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
            currentAppointment.patient = adequatePatient;
        }

        private static void notifyRelevantParties(Appointment currentAppointment, Doctor adequateDoctor, Appointment rescheduledAppointment)
        {
            String id = (MainWindow.notificationController.notificationService.notificationRepository.GetAll().Count() + 1).ToString();
            Notification notificationForRescheduling = new Notification(id, "Alert", "Your appointment has been rescheduled to  " + rescheduledAppointment.StartTime.ToString(), DateTime.Now, false, currentAppointment.patient.user.Jmbg1, adequateDoctor.user.Jmbg1);
            adequateDoctor.notifications.Add(notificationForRescheduling);
            currentAppointment.patient.notifications.Add(notificationForRescheduling);
            MainWindow.notificationController.notificationService.notificationRepository.Create(notificationForRescheduling);
            Notification notificationForCreating = new Notification((Convert.ToInt32(id) + 1).ToString(), "Alert", "You have a new appointment on  " + currentAppointment.StartTime.ToString(), DateTime.Now, false, "", adequateDoctor.user.Jmbg1);
            adequateDoctor.notifications.Add(notificationForCreating);
            MainWindow.notificationController.notificationService.notificationRepository.Create(notificationForCreating);
            MessageBox.Show("You have successfuly created an appointment and all relevant parties have been notified!");
        }

        private static Appointment getRescheduledAppointmentReady(Appointment currentAppointment, Doctor adequateDoctor)
        {
            List<Appointment> availableAppointments = getDoctorsAvailableAppointments(adequateDoctor);
            Appointment rescheduledAppointment = availableAppointments[0];
            rescheduledAppointment.patient = currentAppointment.patient;
            rescheduledAppointment.doctor = adequateDoctor;
            rescheduledAppointment.Room = new Room();
            rescheduledAppointment.Room.RoomNumber = adequateDoctor.room.RoomNumber;
            return rescheduledAppointment;
        }

        private static List<Appointment> getDoctorsAvailableAppointments(Doctor adequateDoctor)
        {
            DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 0, 0, 0);
            DateTime endTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day + 2, 0, 0, 0);
            List<Appointment> availableAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(Priority.None, adequateDoctor.user.Jmbg1, currentTime, endTime, AppointmentType.Regular);
            return availableAppointments;
        }
    }
}
