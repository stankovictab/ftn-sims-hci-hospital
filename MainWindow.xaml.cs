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

        public static int guestCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btde_Click(object sender, RoutedEventArgs e)
        {
            Window doctorEpanel = new DoctorPanel();
            doctorEpanel.ShowDialog();
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
            PatientWindow win1 = new PatientWindow();
            win1.Show();
        }
        private void openDoctorB(Object sender, RoutedEventArgs e)
        {
            DoctorB doctorB = new DoctorB();
            doctorB.Show();
        }

        private void btm_Click(object sender, RoutedEventArgs e)
        {
            Window ManagerWindow = new ManagerWindow();
            ManagerWindow.ShowDialog();
        }
    }
}
