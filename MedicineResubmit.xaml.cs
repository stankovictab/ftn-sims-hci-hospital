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
    /// Interaction logic for MedicineResubmit.xaml
    /// </summary>
    public partial class MedicineResubmit : Window
    {
        MedicineController medicineController = new MedicineController();
        Classes.Medicine toResubmit = new Classes.Medicine();

        public MedicineResubmit(string name)
        {
            InitializeComponent();
            medicineController.medicineService.medicineRepository.UnverifiedMedicine = medicineController.GetAllUnverified();
            toResubmit = medicineController.GetUnverifiedByName(name);
            medicineId.Text = toResubmit.Id;
            medicineName.Text = toResubmit.Name;
            medicineDescription.Text = toResubmit.Description;
            medicineIngredients.Text = toResubmit.Alternatives;
            medicineAlternatives.Text = toResubmit.Ingredients;
            medicineDenialReason.Text = toResubmit.DenialReason;
        }

        private void medicineResubmit_Click(object sender, RoutedEventArgs e)
        {
            string id = medicineId.Text;
            string name = medicineName.Text;
            string description = medicineDescription.Text;
            string ingredients = medicineIngredients.Text;
            string alternatives = medicineAlternatives.Text;

            Classes.Medicine medicine = new Classes.Medicine(id, name, description, ingredients, alternatives, MedicineStatus.OnHold, "No reason");
            medicineController.DeleteUnverified(id);
            medicineController.UpdateAllUnverified(medicineController.medicineService.medicineRepository.UnverifiedMedicine);
            medicineController.AddOnHold(medicine);
            medicineController.UpdateAllOnHold(medicineController.medicineService.medicineRepository.OnHoldMedicine);
            this.Close();
        }
    }
}
