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
    /// Interaction logic for MedicineUpdate.xaml
    /// </summary>
    public partial class MedicineUpdate : Window
    {
        MedicineController medicineController = new MedicineController();
        Classes.Medicine toUpdate = new Classes.Medicine();

        public MedicineUpdate(String name)
        {
            InitializeComponent();
            medicineController.medicineService.medicineRepository.UnverifiedMedicine = medicineController.GetAllUnverified();
            toUpdate = medicineController.GetUnverifiedByName(name);
            medicineName.Text = toUpdate.Name;
            medicineDescription.Text = toUpdate.Description;
            medicineIngredients.Text = toUpdate.Alternatives;
            medicineAlternatives.Text = toUpdate.Ingredients;
        }

        private void medicineUpdate_Click(object sender, RoutedEventArgs e)
        {
            string name = medicineName.Text;
            string description = medicineDescription.Text;
            string ingredients = medicineIngredients.Text;
            string alternatives = medicineAlternatives.Text;

            Classes.Medicine medicine = new Classes.Medicine(name, description, ingredients, alternatives, MedicineStatus.Unverified); ;
            _ = medicineController.UpdateUnverified(medicine);
            medicineController.UpdateAllUnverified(medicineController.medicineService.medicineRepository.UnverifiedMedicine);
            this.Close();
        }
    }
}
