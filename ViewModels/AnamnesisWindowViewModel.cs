using Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ViewModels
{
    public class AnamnesisWindowViewModel : ViewModel {

        private ObservableCollection<Anamnesis> anas;

        public AnamnesisWindowViewModel(String  patientId)
        {
            LoadAnas(patientId);
        }

        public ObservableCollection<Anamnesis> Anas
        {
            get { return anas; }
            set
            {
                anas = value;
            }
        }

        private void LoadAnas(String patientId)
        {
            AnamnesisRepository anamnesisRepository = new AnamnesisRepository();
            anas = new ObservableCollection<Anamnesis>(anamnesisRepository.GetAllByPatientId(patientId));
        }
    }
}
