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
    /// Interaction logic for MedicineCreation.xaml
    /// </summary>
    public partial class MedicineCreation : Window
    {
        MedicineController medicineController = new MedicineController();

        public MedicineCreation()
        {
            InitializeComponent();
        }

        private void medicineAdd_Click(object sender, RoutedEventArgs e)
        {
            medicineController.medicineService.medicineRepository.OnHoldMedicine = medicineController.GetAllOnHold();
            Medicine newMedicine = new Medicine(medicineId.Text, medicineName.Text, medicineDescription.Text, medicineIngredients.Text, medicineAlternatives.Text, MedicineStatus.OnHold, "No reason");
            _ = medicineController.AddOnHold(newMedicine);
            this.Hide();
        }
    }
}
