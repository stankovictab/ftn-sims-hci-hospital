using Classes;
using ftn_sims_hci_hospital.Classes;
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
    /// Interaction logic for AddReferral.xaml
    /// </summary>
    public partial class AddReferral : Window
    {
        private Patient choosedPatient;
        private ReferralRepository referralRepository;

        public AddReferral(Patient patient)
        {
            InitializeComponent();
            referralRepository = new ReferralRepository();
            choosedPatient = patient;
        }

        private void createReferral(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 1000);

            Referral newReferral = new Referral(id.ToString(),MainWindow.user.Jmbg1,choosedPatient.user.Jmbg1,txtDescription.Text,(DateTime)durationDate.SelectedDate, false);
            referralRepository.Create(newReferral);
        }
    }
}
