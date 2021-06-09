using ftn_sims_hci_hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    class ManagerNewViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private MedicineViewModel medicineViewModel = new MedicineViewModel();
        private BindableBase currentViewModel;
        private HomeViewModel homeViewModel = new HomeViewModel();

        public ManagerNewViewModel()
        {
            //CurrentViewModel = homeViewModel;
            NavCommand = new MyICommand<string>(OnNav);
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "medicine":
                    CurrentViewModel = medicineViewModel;
                    break;
            }
        }


    }
}
