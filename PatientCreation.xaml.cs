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
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class PatientCreation : Window
    {
        
        public PatientCreation()
        {
            InitializeComponent();
            MainWindow.patientController.patientService.patientRepository.PatientsInFile1 = MainWindow.patientController.GetAll();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            string name = tbfirstname.Text;
            string lastname = tblastname.Text;
            string email = tbemail.Text;
            string password = tbpassword.Text;
            string jmbg = tbjmbg.Text;
            User user = new User(name, lastname, email, password, email, jmbg, "", 'N', false, Roles.Patient);
            Patient patient = new Patient(user, null, null,null);
            MainWindow.patientController.Create(patient);
            MainWindow.patientController.UpdateAll(MainWindow.patientController.patientService.patientRepository.PatientsInFile1);
            MessageBox.Show("You have successfully created a new account!");
            this.Close();
        }
    }
}
