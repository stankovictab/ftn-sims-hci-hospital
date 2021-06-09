using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MedicineCreation.xaml
    /// </summary>
    public partial class MedicineCreation : Window, INotifyPropertyChanged
    {
        MedicineController medicineController = new MedicineController();
        public event PropertyChangedEventHandler PropertyChanged;

        public MedicineCreation()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void medicineAdd_Click(object sender, RoutedEventArgs e)
        {
            medicineController.medicineService.medicineRepository.OnHoldMedicine = medicineController.GetAllOnHold();
            Medicine newMedicine = new Medicine(medicineId.Text, medicineName.Text, medicineDescription.Text, medicineIngredients.Text, medicineAlternatives.Text, MedicineStatus.OnHold, "No reason");
            _ = medicineController.AddOnHold(newMedicine);
            this.Hide();
            MessageBox.Show("Success. Press View to Refresh.");
        }
    }
}
