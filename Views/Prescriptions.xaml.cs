using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Classes;
using ftn_sims_hci_hospital;
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

        private void printPres(object sender, RoutedEventArgs e)
        {
            Perscription prescription = (Perscription)prescriptions.SelectedItem;

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("../../pdfGenerate/Recept.pdf", FileMode.Create));
            doc.Open();

            Font bold = new Font(FontFactory.GetFont(FontFactory.TIMES_BOLD, 11, Font.BOLD));
            Font small = FontFactory.GetFont("georgia", 7f);
            Font normal = FontFactory.GetFont("georgia", 11f);
            Font dateFont = FontFactory.GetFont("georgia", 9f);
            Paragraph e1 = new Paragraph("Bolica Zdravlje", small);
            Paragraph e2 = new Paragraph("Novi Sad Pavla Papa 24", small);
            iTextSharp.text.Paragraph e3 = new Paragraph("492-231", small);


            Paragraph p0 = new Paragraph("\n");
            Paragraph p00 = new Paragraph("\n");
            Paragraph p1 = new Paragraph("Ime: " + patient.user.Name1, bold);
            Paragraph p2 = new Paragraph("Prezime: " + patient.user.LastName1, bold);
            Paragraph p3 = new Paragraph("JMBG: " + patient.user.Jmbg1, bold);

            Paragraph p4 = new Paragraph("\n\n");
            Paragraph p5 = new Paragraph("Naziv leka: ", bold);
            Paragraph p6 = new Paragraph(prescription.Medicine.Name, normal);
            Paragraph p61 = new Paragraph("Kolicina :", bold);
            Paragraph p62 = new Paragraph(prescription.Amount.ToString(), normal);
            Paragraph p63 = new Paragraph("Opis za uzimanje leka: ", bold);
            Paragraph p64 = new Paragraph(prescription.Description, normal);
            Paragraph p65 = new Paragraph("Alternativni lekovi: ", bold);
            Paragraph p66 = new Paragraph(prescription.Medicine.Alternatives, normal);


            Paragraph p000 = new Paragraph("\n\n");

            Paragraph p7 = new Paragraph("Recept je  napisao doktor " + MainWindow.user.Name1 + " " + MainWindow.user.LastName1 + ".", normal);

            Paragraph p9 = new Paragraph("\n\n\n\n\n");


            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("../../Images/logoSmall.jpg");
            logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            doc.Add(logo);
            iTextSharp.text.Image text = iTextSharp.text.Image.GetInstance("../../Images/textSmall.png");
            text.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            doc.Add(text);

            doc.Add(p0);
            doc.Add(p00);
            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.Add(p5);
            doc.Add(p6);
            doc.Add(p61);
            doc.Add(p62);
            doc.Add(p63);
            doc.Add(p64);
            doc.Add(p65);
            doc.Add(p66);
            doc.Add(p000);
            doc.Add(p7);
            //doc.Add(p8);
            doc.Add(p9);

            iTextSharp.text.Image sig = iTextSharp.text.Image.GetInstance("../../Images/sigSmall.png");
            sig.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc.Add(sig);


            doc.Add(e1);
            doc.Add(e2);
            doc.Add(e3);
            doc.Close();
        }

        private void fillMedicines()
        {
            medicines = medicineController.GetAll();
            this.DataContext = this;
        }

        
    }
}
