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
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        private AppointmentFileStorage afs;
        public CreateAppointment()
        {
            afs = new AppointmentFileStorage();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 1000);

            string[] startTxt = txtStart.Text.Split(':');
            string[] date = Dat.Text.Split('.');
            string endTxt = txtStart.Text;
            string [] endTime = endTxt.Split(':');



            DateTime start = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(startTxt[0]), int.Parse(startTxt[1]), int.Parse(startTxt[2]));
            DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTime[0]), int.Parse(endTime[1]), int.Parse(endTime[2]));
            //Appointment a = new Appointment(num.ToString(), "Darko", txtP.Text, start, end);
            Appointment ap = new Appointment(r.ToString(), Doc.Text, "Pavle", start, end);
            afs.Create(ap);
        }
    }
}
