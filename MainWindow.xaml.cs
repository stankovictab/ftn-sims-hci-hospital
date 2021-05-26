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
using Classes;

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
    }
}
