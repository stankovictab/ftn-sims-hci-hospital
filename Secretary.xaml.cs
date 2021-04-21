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
    public partial class Secretary : Window
    {
        //nemoj da prihvatis ovaj
        public Secretary()
        {
            InitializeComponent();
        }

        private void btncreatepatient_Click(object sender, RoutedEventArgs e)
        {
            Window patientCreation = new PatientCreation();
            patientCreation.ShowDialog();
            btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void btnlistallpatients_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnviewpatient_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btndeletepatient_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
