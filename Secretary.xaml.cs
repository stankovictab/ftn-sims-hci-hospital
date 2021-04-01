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
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class Secretary : Window
    {
        public static Classes.PatientFileStorage pfs = new Classes.PatientFileStorage();
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
            pfs.PatientsInFile1 = pfs.GetAll();
            patientData.Items.Clear();
            foreach(Classes.Patient p in pfs.PatientsInFile1)
            {
                patientData.Items.Add(new Classes.User { Name1 = p.user.Name1, LastName1 = p.user.LastName1, Jmbg1 = p.user.Jmbg1 });
            }
        }

        private void btnviewpatient_Click(object sender, RoutedEventArgs e)
        {
           if(!patientData.Items.IsEmpty)
           {
                if(patientData.SelectedItem!=null)
                {
                    Classes.User user = (Classes.User)patientData.SelectedItem;
                    String id = user.Jmbg1;
                    Window patientView = new PatientView(id);
                    patientView.ShowDialog();
                    btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
           }
        }

        private void btndeletepatient_Click(object sender, RoutedEventArgs e)
        {
            if (!patientData.Items.IsEmpty)
            {
                if (patientData.SelectedItem != null)
                {
                    Classes.User user = (Classes.User)patientData.SelectedItem;
                    pfs.Delete(user.Jmbg1);
                    pfs.UpdateAll(pfs.PatientsInFile1);
                    btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
