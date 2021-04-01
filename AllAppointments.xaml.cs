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
    public partial class AllAppointments : Window
    {
        private AppointmentFileStorage afs;
        public AllAppointments()
        {
            InitializeComponent();
            afs = new AppointmentFileStorage();
            List<Appointment> appoinments = afs.GetAllByPatientID("Pavle");
            lvUsers.ItemsSource = appoinments;
        }

        private void submitDeletion(object sender, RoutedEventArgs e)
        {
            String id = Deletion.Text;
            if (!afs.Delete(id))
            {
                MessageBox.Show("Id doesn't exist");
            }
            else
            {
                MessageBox.Show("Successfully deleted");
            }
        }
    }
}
