using Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Views;
using Models;
namespace ftn_sims_hci_hospital
{
    public partial class AppointmentsListDoctorB : Window
    {
        AppointmentController f;
        PatientController patientController;
        Appointment aUpdate;

        public AppointmentsListDoctorB()
        {
            InitializeComponent();
            f = new AppointmentController();
            patientController = new PatientController();
            List<Appointment> appointments = f.GetAllByDoctorId(MainWindow.user.Jmbg1);
            lvUsers.ItemsSource = appointments;
        }
        private void showOperations(object sender, RoutedEventArgs e)
        {
            AppointmentController f = new AppointmentController();
            List<Appointment> appointments = f.GetAllByDoctorId(MainWindow.user.Jmbg1);
            
            foreach (Appointment app in appointments.ToList())
            {
                if (app.Type == AppointmentType.Regular)
                {
                    appointments.Remove(app);
                }
            }

            lvUsers.ItemsSource = appointments;
        }

        private void showRegular(object sender, RoutedEventArgs e)
        {
            AppointmentController f = new AppointmentController();
            List<Appointment> appointments = f.GetAllByDoctorId(MainWindow.user.Jmbg1);

            foreach (Appointment app in appointments.ToList())
            {
                if (app.Type == AppointmentType.Operation)
                {
                    appointments.Remove(app);
                }
            }

            lvUsers.ItemsSource = appointments;
        }

        private void showPatient(object sender, RoutedEventArgs e)
        {
            //var item = (ListBox)sender;
            PatientRepository p = new PatientRepository( );

            Appointment appointment = (Appointment)lvUsers.SelectedItem;
           
            //Patient patient = patientController.GetByID(appointment.patient.user.Jmbg);
            Patient patient = p.GetByID(appointment.patient.user.Jmbg1);

            String message = "Name: " + patient.user.Name1 + "\nLast name:" + patient.user.LastName1 + "\nUsername: " + patient.user.Username1;
            message += "\nAddress: " + patient.user.Address1 + "\nEmail: " + patient.user.Email1 + "\nGender: " + patient.user.Gender1;
            MessageBox.Show(message);
        }

        private void deleteAppointent(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)lvUsers.SelectedItem;
            AppointmentController f = new AppointmentController();
            if (!f.DeleteAppointment(appointment.AppointmentID))
            {
                MessageBox.Show("Id doesn't exist");
            }
            else
            {
                MessageBox.Show("Appointment deleted");
            }
        }


        private void updateApp(object sender, RoutedEventArgs e)
        {
            canMain.Visibility = Visibility.Hidden;
            canUpdate.Visibility = Visibility.Visible;

            RoomController roomController = new RoomController();
            List<Room> roomList = roomController.GetAll();

            rooms.ItemsSource = roomList;

            aUpdate = (Appointment)lvUsers.SelectedItem;

            txtS.Text = aUpdate.StartTime.ToString("hh:mm:ss dd.MM.yyyy");
            txtE.Text = aUpdate.EndTime.ToString("hh:mm:ss dd.MM.yyyy");

        }

        private void save(Object sender, RoutedEventArgs e)
        {
            AppointmentController f = new AppointmentController();
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime start = DateTime.ParseExact(txtS.Text, "hh:mm:ss dd.MM.yyyy", provider);
            DateTime end = DateTime.ParseExact(txtE.Text, "hh:mm:ss dd.MM.yyyy", provider);
            aUpdate.StartTime = start;
            aUpdate.EndTime = end;

            Room room = (Room)rooms.SelectedItem;

            f.UpdateAppointment(aUpdate.AppointmentID, new DateTime() ,start, end, room.RoomNumber1,(int) aUpdate.Type);
        }

    }
}
