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
    /// Interaction logic for SecretaryUpdateAppointment.xaml
    /// </summary>
    public partial class SecretaryUpdateAppointment : Window
    {
        Appointment currentAppointment = new Appointment();
        public SecretaryUpdateAppointment(String Id)
        {
            InitializeComponent();
            currentAppointment = MainWindow.appointmentController.appointmentService.appointmentRepository.GetByID(Id);

        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            if(dpdate.SelectedDate==null)
            {
                MessageBox.Show("You have to choose a date!");
            }
            else
            {
                DateTime dt = (DateTime)dpdate.SelectedDate;
                DateTime beginDt = new DateTime(dt.Year, dt.Month, dt.Day, currentAppointment.StartTime.Hour, currentAppointment.StartTime.Minute, currentAppointment.StartTime.Second);
                DateTime endDt= new DateTime(dt.Year, dt.Month, dt.Day, currentAppointment.StartTime.Hour+1, currentAppointment.StartTime.Minute, currentAppointment.StartTime.Second);
                Doctor d = MainWindow.doctorController.ds.dr.GetByID(currentAppointment.doctor.user.Jmbg1);
                Patient p = MainWindow.patientController.GetByID(currentAppointment.patient.user.Jmbg1);
                d.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByDoctorID(currentAppointment.doctor.user.Jmbg1);
                p.notifications = MainWindow.notificationController.notificationService.notificationRepository.GetByPatientID(currentAppointment.patient.user.Jmbg1);
                String id = (MainWindow.notificationController.notificationService.notificationRepository.GetAll().Count() + 1).ToString();
                Notification notification = new Notification(id, "Alert", "Your appointment on  " + currentAppointment.StartTime.ToString() + " has been moved to "+ beginDt.ToString() + "!", DateTime.Now, false, currentAppointment.patient.user.Jmbg1, currentAppointment.doctor.user.Jmbg1);
                d.notifications.Add(notification);
                p.notifications.Add(notification);
                MainWindow.notificationController.notificationService.notificationRepository.Create(notification);
                MessageBox.Show("You have successfuly updated an appointment and all relevant parties have been notified!");
                currentAppointment.StartTime = beginDt;
                currentAppointment.EndTime = endDt;
                MainWindow.appointmentController.appointmentService.appointmentRepository.Update(currentAppointment);
                MessageBox.Show("You have successfully saved your changes!");
                this.Close();
            }
        }
    }
}
