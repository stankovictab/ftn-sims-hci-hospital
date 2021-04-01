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

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for DeleteAppointmentDoctorB.xaml
    /// </summary>
    public partial class DeleteAppointmentDoctorB : Window
    {
        Appointment a;

        public DeleteAppointmentDoctorB()
        {
            InitializeComponent();
            txtS.Visibility = Visibility.Hidden;
            txtE.Visibility = Visibility.Hidden;
            btnU.Visibility = Visibility.Hidden;
            bs.Visibility = Visibility.Hidden;
            be.Visibility = Visibility.Hidden;
        }

        private void deleteAppointment(Object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage f = new AppointmentFileStorage();
            f.Delete(txtDel.Text);

        }

        private void findAp(Object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage f = new AppointmentFileStorage();
            a = f.GetByID(txtDel.Text);

            txtS.Text = a.StartTime.ToString("hh:mm:ss dd.MM.yyyy");
            txtS.Visibility = Visibility.Visible;

            txtE.Text = a.EndTime.ToString("hh:mm:ss dd.MM.yyyy");
            txtE.Visibility = Visibility.Visible;

            btnU.Visibility = Visibility.Visible;
            bs.Visibility = Visibility.Visible;
            be.Visibility = Visibility.Visible;
        }

        private void updateAp(Object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage f = new AppointmentFileStorage();
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime start = DateTime.ParseExact(txtS.Text, "hh:mm:ss dd.MM.yyyy",provider);
            DateTime end = DateTime.ParseExact(txtE.Text, "hh:mm:ss dd.MM.yyyy", provider);
            a.StartTime = start;
            a.EndTime = end;
            f.Update(a);
        }
    }
}
