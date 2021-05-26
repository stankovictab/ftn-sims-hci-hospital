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
    /// <summary>
    /// Interaction logic for Treatments.xaml
    /// </summary>
    public partial class Treatments : Window
    {
        Patient choosedPatient;
        HospitalizationReferalRepository hospitalizationReferalRepository;
        public Treatments(Patient patient)
        {
            InitializeComponent();
            choosedPatient = patient;
            hospitalizationReferalRepository = new HospitalizationReferalRepository();

            List<HospitalizationReferal> hospitalizationReferals = hospitalizationReferalRepository.GetAllByPatientId(patient.user.Jmbg1);
            Table.ItemsSource = hospitalizationReferals;
        }

        private void extend(Object sender, RoutedEventArgs e)
        {
            HospitalizationReferal hospitalizationReferal = (HospitalizationReferal) Table.SelectedItem;
            hospitalizationReferal.endDate = hospitalizationReferal.endDate.AddDays(int.Parse(txtDays.Text));
            hospitalizationReferalRepository.Update(hospitalizationReferal);
        }
    }
}
