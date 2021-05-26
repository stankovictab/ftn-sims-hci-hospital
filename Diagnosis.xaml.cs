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
    /// Interaction logic for Diagnosis.xaml
    /// </summary>
    public partial class Diagnosis : Window
    {

        MedicineCotroller medicineCotroller;
        public List<Medicine> medicines { get; set; }
        Patient patient;
        PrescriptionService perscriptionService;
        public Diagnosis(Patient patient)
        {
            perscriptionService = new PrescriptionService();
            this.patient = patient;
            medicineCotroller = new MedicineCotroller();
            fillMedicines();
            InitializeComponent();
        }

        private void addPrescription(object sender, RoutedEventArgs e)
        {
            String medicineString = medicinesComboBox.SelectedItem.ToString();
            String[] components = medicineString.Split('-');
            Medicine medicine = medicineCotroller.GetByID(components[0]);
            
            Perscription prescription = new Perscription(null, medicine, int.Parse(txtA.Text), txtD.Text);
            if(!perscriptionService.Create(prescription, patient.user.Jmbg1))
            {
                MessageBox.Show("Patient is allergic to that medicine!");
            }
        }

        private void fillMedicines()
        {
            medicines = medicineCotroller.GetAll();
            this.DataContext = this;
        }

        
    }
}
