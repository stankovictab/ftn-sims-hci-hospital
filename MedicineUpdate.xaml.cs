﻿using Classes;
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
        Medicine toUpdate = new Medicine();

        public MedicineUpdate(String name)
        {
            InitializeComponent();
            medicineController.medicineService.medicineRepository.OnHoldMedicine = medicineController.GetAllOnHold();
            toUpdate = medicineController.GetOnHoldByName(name);
            medicineId.Text = toUpdate.Id;
            medicineName.Text = toUpdate.Name;
            medicineDescription.Text = toUpdate.Description;
            medicineIngredients.Text = toUpdate.Alternatives;
            medicineAlternatives.Text = toUpdate.Ingredients;
        }

        private void medicineUpdate_Click(object sender, RoutedEventArgs e)
        {
            string id = medicineId.Text;
            string name = medicineName.Text;
            string description = medicineDescription.Text;
            string ingredients = medicineIngredients.Text;
            string alternatives = medicineAlternatives.Text;

            Medicine medicine = new Medicine(id, name, description, ingredients, alternatives, MedicineStatus.OnHold, "No reason");
            _ = medicineController.UpdateOnHold(medicine);
            medicineController.UpdateAllOnHold(medicineController.medicineService.medicineRepository.OnHoldMedicine);
            this.Close();
        }
    }
}
