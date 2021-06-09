using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ftn_sims_hci_hospital.ViewModel
{
    class AddMedicineViewModel : BindableBase
    {
        private Medicine med;
        MedicineController medicineController = new MedicineController();

        public Medicine Med
        {
            get { return med; }
            set
            {
                med = value;
                OnPropertyChanged();
            }
        }

        public MyICommand addMedicineCommand { get; set; }
        private Window thisWindow;

        public void Executed_AddMedicineCommand()
        {
            medicineController.AddOnHold(Med);
            thisWindow.Close();
        }

        public bool CanExecute_AddMedicineCommand()
        {
            return true;
        }

        public AddMedicineViewModel(Window w)
        {
            this.Med = new Medicine();
            this.thisWindow = w;
            addMedicineCommand = new MyICommand(Executed_AddMedicineCommand, CanExecute_AddMedicineCommand);
        }
    }
}
