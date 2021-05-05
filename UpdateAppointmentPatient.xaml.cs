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
    public partial class UpdateAppointmentPatient : Window
    {
        private DateTime currentDate;
        private String appointmentId;
        private AppointmentController appointmentController;
        public UpdateAppointmentPatient(String appointmentId, DateTime newDate)
        {
            this.appointmentId = appointmentId;
            currentDate = newDate;
            appointmentController = new AppointmentController();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
