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
    public partial class DoctorB : Window
    {
        public DoctorB()
        {
            InitializeComponent();
        }

        private void openMedicalRecords(Object sender, RoutedEventArgs e)
        {
            MedicalRecords medicalRecords = new MedicalRecords();
            medicalRecords.Show();
        }
        private void openAppointmentsList(Object sender, RoutedEventArgs e)
        {
            AppointmentsListDoctorB a = new AppointmentsListDoctorB();
            a.Show();
        }

        private void openCreateAppointment(Object sender, RoutedEventArgs e)
        {
            CreateAppointmentDoctorB c = new CreateAppointmentDoctorB();
            c.Show();
        }

        private void openDeleteAppointment(Object sender, RoutedEventArgs e)
        {
            DeleteAppointmentDoctorB d = new DeleteAppointmentDoctorB();
            d.Show();
        }
    }
}
