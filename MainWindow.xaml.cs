using Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class MainWindow : Window
    {
        public static PatientController patientController = new PatientController();
        public static RoomController roomController = new RoomController();
        public static DoctorController doctorController = new DoctorController();
        public static AppointmentController appointmentController = new AppointmentController();
        public static HolidayRequestController holidayRequestController = new HolidayRequestController();
        public static DynamicEquipmentRequestController dynamicEquipmentRequestController = new DynamicEquipmentRequestController();
        public static NotificationController notificationController = new NotificationController();

        public static User user;

        public static int guestCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
            user = new User();
        }

        private void btde_Click(object sender, RoutedEventArgs e)
        {
            Window doctorpanel = new DoctorPanel();
            doctorpanel.ShowDialog();
        }
        private void bts_Click(object sender, RoutedEventArgs e)
        {
            Window secretaryWindow = new HomeWindow();
            this.Hide();
            secretaryWindow.ShowDialog();
            this.Show();
        }
        private void patientClick(object sender, RoutedEventArgs e)
        {
            user.Role1 = Roles.Patient;
            user.Jmbg1 = "1243999081010";
            user.Name1 = "Igor";
            PatientWindow win1 = new PatientWindow();
            win1.Show();
        }
        private void openDoctorB(Object sender, RoutedEventArgs e)
        {
            user.Jmbg1 = "0501";
            user.Role1 = Roles.Doctor;
            user.Name1 = "Dakaz";
            DoctorB doctorB = new DoctorB();
            doctorB.Show();
        }

        private void btm_Click(object sender, RoutedEventArgs e)
        {
            Window Manager = new Manager();
            Manager.ShowDialog();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            List<Patient> patientsInFile = patientController.GetAll();
            foreach (Patient p in patientsInFile)
            {
                if (CredentialsMatch(p.user))
                {
                    if (p.user.blocked)
                    {
                        showError("Blokirani ste");
                        return;
                    }
                    else
                    {
                        preparePatientWindow(p);
                        return;
                    }
                }
            }
            showError("Korisnicko ime ili lozinka nisu ispravni");
        }
        private Boolean CredentialsMatch(User user)
        {
            return user.Username1.Equals(usernameTextBox.Text) && user.Password1.Equals(passwordTextBox.Password);
        }

        private void showError(String message)
        {
            errorMessage.Content = message;
            errorMessage.Visibility = Visibility.Visible;
        }

        private void preparePatientWindow(Patient p)
        {
            user = p.user;
            errorMessage.Visibility = Visibility.Hidden;
            PatientWindow win1 = new PatientWindow();
            win1.Show();
        }
    }
}
