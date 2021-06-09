using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Models;
using System.Collections.ObjectModel;
using Classes;
using ftn_sims_hci_hospital.Commands;
using System.Windows.Input;

namespace ftn_sims_hci_hospital.ViewModels
{
    class TreatmentsViewModel : ViewModel
    {
        private ObservableCollection<HospitalizationReferal> hos;
        private String daysText;
        private HospitalizationReferal selectedHos;
        public ICommand Extend_Command { get; set; }
        public ObservableCollection<HospitalizationReferal> Hos
        {
            get { return hos; }
            set
            {
                hos = value;
            }
        }

        public HospitalizationReferal SelectedHos
        {
            get { return selectedHos; }
            set
            {
                selectedHos = value;
            }
        }

        public String DaysText
        {
            get { return daysText; }
            set
            {
                daysText = value;
            }
        }


        public TreatmentsViewModel(String patientId)
        {
            LoadHos(patientId);
        }

        private void LoadHos(String patientId)
        {
            HospitalizationReferalRepository hospitalizationReferalRepository = new HospitalizationReferalRepository();
            hos = new ObservableCollection<HospitalizationReferal>(hospitalizationReferalRepository.GetAllByPatientId(patientId));
        }

        public RelayCommand extendCommand;

        public RelayCommand ExtendCommand
        {
            get { return extendCommand; }
            set
            {
                extendCommand = value;
            }
        }

        public void extend()
        {
            HospitalizationReferalRepository hospitalizationReferalRepository = new HospitalizationReferalRepository();
            selectedHos.endDate = selectedHos.endDate.AddDays(int.Parse(daysText));
            hospitalizationReferalRepository.Update(SelectedHos);
        } 
    }
}
