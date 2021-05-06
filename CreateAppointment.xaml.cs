using Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class CreateAppointment : Window
    {
        private AppointmentController appointmentController;
        public CreateAppointment()
        {
            appointmentController = new AppointmentController();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appointment app = (Appointment)availableAppointments.SelectedItem;
            app.patient.user.Jmbg1 = PatientWindow.user.Jmbg1;
            appointmentController.CreateAppointment(app.doctor.user.Jmbg1, PatientWindow.user.Jmbg1, app.StartTime, 1, "");

            //Appointment newApp = new Appointment("", app.doctor.user.Jmbg1, PatientWindow.user.Jmbg1, app.StartTime, new DateTime(app.StartTime.Year, app.StartTime.Month, app.StartTime.Day, app.StartTime.Hour + 1));
            /*Random rnd = new Random();
            int r = rnd.Next(1, 1000);

            string[] startTime = txtStart.Text.Split(':');
            string[] date = Dat.Text.Split('.');
            string endTxt = txtStart.Text;
            string[] endTime = endTxt.Split(':');

            DateTime start = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(startTime[0]), int.Parse(startTime[1]), int.Parse(startTime[2]));
            DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTime[0]), int.Parse(endTime[1]), int.Parse(endTime[2]));
            // Appointment a = new Appointment(num.ToString(), "Darko", txtP.Text, start, end);
            Appointment ap = new Appointment(r.ToString(), Doc.Text, "Pavle", start, end);
            afs.Create(ap);*/
        }

        private void showAvailableAppointments(object sender, RoutedEventArgs e)
        {
            DateTime sd = (DateTime)startDate.SelectedDate;
            DateTime ed = (DateTime)endDate.SelectedDate;
            String doctor = doctorCombo.Text;
            Priority p;
            if ((Boolean)doctorRadio.IsChecked)
            {
                p = Priority.Doctor;
            }
            else if ((Boolean)dateRadio.IsChecked)
            {
                p = Priority.Date;
            }
            else
            {
                p = Priority.None;
            }
            List<Appointment> app = appointmentController.ShowAvailableAppointments(p, doctor, sd, ed, AppointmentType.Regular);
            availableAppointments.ItemsSource = app;
        }
    }
}
