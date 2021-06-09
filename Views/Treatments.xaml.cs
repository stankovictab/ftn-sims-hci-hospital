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
using Models;
using ftn_sims_hci_hospital.ViewModels;

namespace ftn_sims_hci_hospital.Views
{
    /// <summary>
    /// Interaction logic for Treatments.xaml
    /// </summary>
    public partial class Treatments : Window
    {

        Patient choosedPatient;
        public Treatments(Patient patient)
        {
            InitializeComponent();
            this.DataContext = new TreatmentsViewModel(patient.user.Jmbg1);
        
        }

        

        /* HospitalizationReferalRepository hospitalizationReferalRepository;
        public Treatments(Patient patient)
        {
            InitializeComponent();
            choosedPatient = patient;
            hospitalizationReferalRepository = new HospitalizationReferalRepository();

            List<HospitalizationReferal> hospitalizationReferals = hospitalizationReferalRepository.GetAllByPatientId(patient.user.Jmbg);
            Table.ItemsSource = hospitalizationReferals;
        }
        */
        // dodaj ga na click
        private void extend(Object sender, RoutedEventArgs e)
        {
            if (txtDays.Text.Equals(""))
            {
                HospitalizationReferalRepository hospitalizationReferalRepository = new HospitalizationReferalRepository();
                HospitalizationReferal hospitalizationReferal = (HospitalizationReferal)Table.SelectedItem;
                hospitalizationReferal.endDate = hospitalizationReferal.endDate.AddDays(int.Parse(txtDays.Text));
                hospitalizationReferalRepository.Update(hospitalizationReferal);
            }
            else
            {
                MessageBoxResult message = MessageBox.Show(this, "Fill empty fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            }
    }
}
