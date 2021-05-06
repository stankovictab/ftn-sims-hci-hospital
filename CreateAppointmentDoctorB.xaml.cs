using Classes;
using System;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class CreateAppointmentDoctorB : Window
    {
        public CreateAppointmentDoctorB()
        {
            InitializeComponent();
        }

        public void createAppointment(Object sender, RoutedEventArgs e)
        {
            //AppointmentFileStorage f = new AppointmentFileStorage();
            string[] startTxt = txtS.Text.Split(':');
            string[] date = txtD.Text.Split('.');
            string[] endTxt = txtE.Text.Split(':');
            Random random = new Random();

            DateTime start = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(startTxt[0]), int.Parse(startTxt[1]), int.Parse(startTxt[2]));
            DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTxt[0]), int.Parse(endTxt[1]), int.Parse(endTxt[2]));
            Appointment a = new Appointment(random.Next(1, 100).ToString(), "Darko", txtP.Text, start, end);

           // if (f.Create(a) == true)
           // { }
           // else
          //  { }
        }
    }
}
