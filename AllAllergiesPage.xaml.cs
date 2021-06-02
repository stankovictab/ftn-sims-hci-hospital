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
    public partial class AllAllergiesPage : Page
    {
        private PatientAllergyRepository patientAllergiesRepository;
        public AllAllergiesPage()
        {
            patientAllergiesRepository = new PatientAllergyRepository();
            InitializeComponent();
            allergiesTable.ItemsSource = patientAllergiesRepository.GetAllByPatientID(MainWindow.user.Jmbg1);
        }
    }
}
