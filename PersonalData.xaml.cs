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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class PersonalData : Page
    {
        PatientRepository patientRepository;
        public PersonalData()
        {
            patientRepository = new PatientRepository();
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Patient patient = patientRepository.GetByID(MainWindow.user.Jmbg1);
            nameLabel.Content = "Ime: " + patient.user.Name1;
            lastNameLabel.Content = "Prezime: " + patient.user.LastName1;
            genderLabel.Content = "Pol: " + patient.user.Gender1;
            jmbgLabel.Content = "JMBG: " + patient.user.Jmbg1;
            mailLabel.Content = "Mejl: " + patient.user.Email1;
        }
    }
}
