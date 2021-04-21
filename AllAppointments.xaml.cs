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
        private String patientName;
        public AllAppointments()
        {
            InitializeComponent();
            patientName = "Pavle";
            List<Appointment> appointments = MainWindow.appointmentController.appointmentService.appointmentRepository.GetAllByPatientID(patientName);
            lvUsers.ItemsSource = appointments;
        }

        private void submitDeletion(object sender, RoutedEventArgs e)
        {
            String id = Deletion.Text;
            if (!MainWindow.appointmentController.appointmentService.appointmentRepository.Delete(id))
            {
                MessageBox.Show("Id doesn't exist");
            }
            else
            {
                MessageBox.Show("Successfully deleted");
            }
        }

        private void submitUpdate(object sender, RoutedEventArgs e)
        {
            string id = UpdateID.Text;
            string doc = UpdateDoc.Text;
            string[] startTime = UpdateTime.Text.Split(':');
            string[] date = UpdateDate.Text.Split('.');
            string endTxt = UpdateTime.Text;
            string[] endTime = endTxt.Split(':');

            DateTime start = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(startTime[0]), int.Parse(startTime[1]), int.Parse(startTime[2]));
            DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTime[0]), int.Parse(endTime[1]), int.Parse(endTime[2]));
            Appointment ap = new Appointment(id, doc, patientName, start, end);
            if (!MainWindow.appointmentController.appointmentService.appointmentRepository.Update(ap))
            {
                MessageBox.Show("Id doesn't exist");
            }
            else
            {
                MessageBox.Show("Successfully updated");
            }
        }

    }
}
