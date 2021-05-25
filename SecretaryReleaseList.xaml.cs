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
    /// <summary>
    /// Interaction logic for SecretaryReleaseList.xaml
    /// </summary>
    public partial class SecretaryReleaseList : Window
    {
        private List<HospitalizationReferal> referalsOnThisDay = new List<HospitalizationReferal>();
        private HospitalizationReferalRepository hospitalizationReferalRepository = new HospitalizationReferalRepository();
        public SecretaryReleaseList()
        {
            InitializeComponent();
            
            referalsOnThisDay = hospitalizationReferalRepository.getAllByEndDate(DateTime.Now);
            foreach(HospitalizationReferal hr in referalsOnThisDay)
            {
                patientData.Items.Add(new HospitalizedPatientDTO { name = hr.patient.user.Name1, lastname = hr.patient.user.LastName1,jmbg=hr.patient.user.Jmbg1, description = hr.description,  startDate = hr.startDate, endDate = hr.endDate });
            }
        }

        private void patientData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientData.SelectedItem != null)
            {
                tbconclusion.Text = ((HospitalizedPatientDTO)patientData.SelectedItem).description;
            }
        }

        private void btnconclude_Click(object sender, RoutedEventArgs e)
        {
            if(patientData.SelectedItem!=null&&tbconclusion.Text!="")
            {
                HospitalizedPatientDTO concludedPatient = (HospitalizedPatientDTO)patientData.SelectedItem;
                concludedPatient.description = tbconclusion.Text;
                patientData.Items.Clear();
                foreach (HospitalizationReferal hr in referalsOnThisDay)
                {
                    if(hr.patient.user.Jmbg1.Equals(concludedPatient.jmbg))
                    {
                        hr.description = concludedPatient.description;
                        patientData.Items.Add(concludedPatient);
                        hospitalizationReferalRepository.Update(hr);
                    }
                    else
                    {
                        patientData.Items.Add(new HospitalizedPatientDTO { name = hr.patient.user.Name1, lastname = hr.patient.user.LastName1, jmbg = hr.patient.user.Jmbg1, description = hr.description, startDate = hr.startDate, endDate = hr.endDate });
                    }
                }
            }
        
        }
    }
}
