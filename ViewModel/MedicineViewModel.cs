using Classes;
using ftn_sims_hci_hospital.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ftn_sims_hci_hospital.ViewModel
{
    class MedicineViewModel : BindableBase
    {
        public ObservableCollection<Medicine> Medicine { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand addMedicineCommand { get; set; }
        public MyICommand deleteMedicineCommand { get; set; }
        private Medicine selectedMedicine;
        
        MedicineController medicineController = new MedicineController();

        public MedicineViewModel()
        {
            LoadMedicine();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            addMedicineCommand = new MyICommand(OnAdd);
        }

        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                selectedMedicine = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public void LoadMedicine()
        {
            ObservableCollection<Medicine> medicine =
                new ObservableCollection<Medicine>();

            List<Medicine> allMedicineOnHold = medicineController.GetAllOnHold();

            foreach(Medicine m in allMedicineOnHold)
            {
                medicine.Add(m);
            }

            List<Medicine> allMedicineUnverified = medicineController.GetAllUnverified();

            foreach (Medicine m in allMedicineUnverified)
            {
                medicine.Add(m);
            }

            Medicine = medicine;
        }

        private bool CanDelete()
        {
            return SelectedMedicine != null;
        }

        private void OnDelete()
        {
            if(selectedMedicine.Status == MedicineStatus.Unverified)
                medicineController.DeleteUnverified(SelectedMedicine.Name);
            else if(selectedMedicine.Status == MedicineStatus.OnHold)
                medicineController.DeleteOnHold(SelectedMedicine.Name);
        }

        private void OnAdd()
        {
            Window w = new AddMedicineView();
            w.ShowDialog();
        }
    }
}
