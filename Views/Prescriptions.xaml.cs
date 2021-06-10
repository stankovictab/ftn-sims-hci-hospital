using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Classes;
using ftn_sims_hci_hospital;
using ftn_sims_hci_hospital.pdfGenerate;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace Views
{
    /// <summary>
    /// Interaction logic for Prescriptions.xaml
    /// </summary>
    public partial class Prescriptions : Window
    {
        PatientController patientController = new PatientController();
        Patient patient;
        PerscriptionRepository perscriptionRepository = new PerscriptionRepository();
        Perscription prescriptionUpdate;
        public List<Medicine> medicines { get; set; }
        MedicineCotroller medicineController = new MedicineCotroller();
        public Prescriptions(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            List<Perscription> perscriptions = perscriptionRepository.GetAllByPatientId(patient.user.Jmbg1);
            prescriptions.ItemsSource = perscriptions;
            fillMedicines();

        }

        
        private void create(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 1000);

            Medicine medicine = (Medicine) medicinesComboBox.SelectedItem;
            Perscription p = new Perscription(r.ToString(), medicine, int.Parse(txtA.Text), txtD.Text);

            patientController.addPrescription(p, patient.user.Jmbg1);
                
        }

        

        private void delete(object sender, RoutedEventArgs e)
        {
            
            PatientController patientController = new PatientController();
            Perscription prescription = (Perscription)prescriptions.SelectedItem;

            patientController.removePrescription(prescription.Id);
            
        }

        private void update(object sender, RoutedEventArgs e)
        {

            PatientController patientController = new PatientController();
            Perscription per = new Perscription(prescriptionUpdate.Id, new Medicine(), int.Parse(txtAU.Text), txtDU.Text); ;

            patientController.updatePrescription(per, patient.user.Jmbg);

            CanvasPers.Visibility = Visibility.Visible;
            CanvasPersUpdate.Visibility = Visibility.Hidden;

        }

        private void displayPrescriptionUpdate(object sender, RoutedEventArgs e)
        {
            PatientController patientController = new PatientController();
            prescriptionUpdate = (Perscription)prescriptions.SelectedItem;

            
            txtAU.Text = prescriptionUpdate.Amount.ToString();
            txtDU.Text = prescriptionUpdate.Description;

            CanvasPers.Visibility = Visibility.Hidden;
            CanvasPersUpdate.Visibility = Visibility.Visible;
        }

        private void printPresription(object sender, RoutedEventArgs e)
        {
            ExportReport exportReport = new ExportReport();
            exportReport.addPatient(patient.user);
            Perscription prescription = (Perscription)prescriptions.SelectedItem;
            exportReport.addPrescription(prescription);
            exportReport.addDoctor(MainWindow.user);
            if (exportReport.generate())
            {
                MessageBox.Show("Report successfully generated");
            }
        }

        private void fillMedicines()
        {
            medicines = medicineController.GetAll();
            this.DataContext = this;
        }

        
    }
}
