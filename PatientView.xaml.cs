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
    public partial class PatientView : Window
    {
        public Classes.Patient currentPatient = new Classes.Patient();
        public static Classes.PatientFileStorage pfs = new Classes.PatientFileStorage();
        public PatientView(String id)
        {
            InitializeComponent();
            pfs.PatientsInFile1 = pfs.GetAll();
            currentPatient = pfs.GetByID(id);
            tbfirstname.Text = currentPatient.user.Name1;
            tblastname.Text = currentPatient.user.LastName1;
            tbusername.Text = currentPatient.user.Username1;
            tbpassword.Text = currentPatient.user.Password1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name = tbfirstname.Text;
            String lastname = tblastname.Text;
            String username = tbusername.Text;
            String password = tbpassword.Text;
            Classes.User user = new Classes.User(name, lastname, username, password, currentPatient.user.Email1, currentPatient.user.Jmbg1, currentPatient.user.Address1, currentPatient.user.Gender1, currentPatient.user.Active1, currentPatient.user.Role1);
            Classes.Patient patient = new Classes.Patient(user, null, null);
            pfs.Update(patient);
            pfs.UpdateAll(pfs.PatientsInFile1);
            MessageBox.Show("You have successfully updated this patients' data!");
            this.Close();
        }
    }
}
