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
    public partial class CreateAppointmentPage : Page
    {
        private AppointmentController appointmentController;
        private DoctorController doctorController;
        public CreateAppointmentPage()
        {
            appointmentController = new AppointmentController();
            doctorController = new DoctorController();
            InitializeComponent();
            List<Doctor> doctorsInFile = doctorController.GetAll();
            doctorCombo.ItemsSource = doctorsInFile;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment app = (Appointment)availableAppointments.SelectedItem;
            app.patient.user.Jmbg1 = MainWindow.user.Jmbg1;
            DateTime end = new DateTime(app.StartTime.Year, app.StartTime.Month, app.StartTime.Day, app.StartTime.Hour + 1, app.StartTime.Minute, app.StartTime.Second);

            appointmentController.CreateAppointment(app.doctor.user.Jmbg1, MainWindow.user.Jmbg1, app.StartTime, end, 1, "");
            MessageBox.Show("Pregled je kreiran");

        }

        private void showAvailableAppointments(object sender, RoutedEventArgs e)
        {
            DateTime sd = (DateTime)startDate.SelectedDate;
            DateTime ed = (DateTime)endDate.SelectedDate;
            String doctor = doctorCombo.Text;
            Priority p = Priority.None;
            if ((Boolean)doctorRadio.IsChecked)
            {
                p = Priority.Doctor;
            }
            if ((Boolean)dateRadio.IsChecked)
            {
                p = Priority.Date;
            }

            if ((ed - sd).Days > 7)
            {
                MessageBox.Show("Maksimalan opseg koji mozete zadati je 7 dana");
            }
            else
            {
                List<Appointment> app = appointmentController.ShowAvailableAppointments(p, doctor, sd, ed, AppointmentType.Regular);
                availableAppointments.ItemsSource = app;
            }
        }

        private void DatesAreSelected(object sender, SelectionChangedEventArgs e)
        {
            if(startDate.SelectedDate is null || endDate.SelectedDate is null)
            {
                return;
            }
            showAvailableAppointmentsButton.IsEnabled = true;
            ToolTip tooltip = new ToolTip { };
            showAvailableAppointmentsButton.ToolTip = tooltip;
            tooltip.Visibility = Visibility.Hidden;
        }

        private void TimeIsSelected(object sender, SelectionChangedEventArgs e)
        {
            Submit.IsEnabled = true;
            ToolTip tooltip = new ToolTip { };
            Submit.ToolTip = tooltip;
            tooltip.Visibility = Visibility.Hidden;
        }

        private void StartCalendarOpenedRestrictions(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            picker.DisplayDateStart = DateTime.Now;
            if(!(endDate.SelectedDate is null))
            {
                picker.DisplayDateEnd = (DateTime)endDate.SelectedDate;
            }
        }

        private void EndCalendarOpenedRestrictions(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            if (startDate.SelectedDate is null)
            {
                picker.DisplayDateStart = DateTime.Now;
            }
            else
            {
                picker.DisplayDateStart = (DateTime)startDate.SelectedDate;
            }
        }
    }
}
