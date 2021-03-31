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
    /// Interaction logic for CreateAppointmentDoctorB.xaml
    /// </summary>
    public partial class CreateAppointmentDoctorB : Window
    {
        public CreateAppointmentDoctorB()
        {
            InitializeComponent();
        }

        public void createAppointment(Object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage f = new AppointmentFileStorage();
            string[] startTxt = txtS.Text.Split(':');
            string[] date = txtD.Text.Split('.');
            string[] endTxt = txtE.Text.Split(':');

            DateTime start = new DateTime(int.Parse(date[2]),int.Parse(date[1]),int.Parse(date[0]),int.Parse(startTxt[0]),int.Parse(startTxt[1]), int.Parse(startTxt[2]));
            DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTxt[0]), int.Parse(endTxt[1]), int.Parse(endTxt[2]));
            Appointment a = new Appointment("za sad ovo","dr. Zile",txtP.Text,start,end);

            if(f.Create(a) == true) 
            {

            }
            else { }
        }
    }
}
