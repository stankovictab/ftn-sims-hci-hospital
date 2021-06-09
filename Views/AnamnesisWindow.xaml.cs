using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows;
using Classes;
using ftn_sims_hci_hospital;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ViewModels;
using Font = iTextSharp.text.Font;

namespace Views
{
    /// <summary>
    /// Interaction logic for AnamnesisWindow.xaml
    /// </summary>
    public partial class AnamnesisWindow : Window
    {
        PatientController patientController = new PatientController();
        Patient patient;
        Anamnesis anamnesisUpdate;
        public AnamnesisWindow(Patient patient)
        {

            InitializeComponent();
            //pdf.Image = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
            this.patient = patient;

            //List<Anamnesis> anamneses = patientController.getAllAnamnesis(patient.user.Jmbg1);
            //anamnesisList.ItemsSource = anamneses;

            this.DataContext = new AnamnesisWindowViewModel(patient.user.Jmbg1);
        }

        private void create(object sender, RoutedEventArgs e)
        {

            Random rnd = new Random();
            int r = rnd.Next(1, 1000);
            CultureInfo provider = CultureInfo.InvariantCulture;
            if (!txtDAS.Text.Equals(""))
            {
                DateTime date = DateTime.ParseExact(txtDAS.Text, "hh:mm:ss dd.MM.yyyy", provider);

                Anamnesis a = new Anamnesis(r.ToString(), txtDES.Text, date);

                patientController.addAnamnesis(a, patient.user.Jmbg1);
            } else
            {
                MessageBoxResult message = MessageBox.Show(this, "Fill empty fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            Anamnesis anamnesis = (Anamnesis)anamnesisList.SelectedItem;

            if (anamnesis != null)
            {
                patientController.removeAnamnesis(anamnesis.Id);
            } else
            {
                MessageBoxResult message = MessageBox.Show(this, "Select anamnesis to continue.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void displayAnamnesisForUpdate(object sender, RoutedEventArgs e)
        {
            PatientController patientController = new PatientController();
            anamnesisUpdate = (Anamnesis)anamnesisList.SelectedItem;

            txtDA.Text = anamnesisUpdate.Date.ToString("hh:mm:ss dd.MM.yyyy");
            txtDE.Text = anamnesisUpdate.Description;

            CanvasAnamUpdate.Visibility = Visibility.Visible;
            CanvasAnas.Visibility = Visibility.Hidden;
        }
        private void update(object sender, RoutedEventArgs e)
        {
            if (!txtDA.Text.Equals(""))
            {
                PatientController patientController = new PatientController();
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime date = DateTime.ParseExact(txtDA.Text, "hh:mm:ss dd.MM.yyyy", provider);
                Anamnesis an = new Anamnesis(anamnesisUpdate.Id, txtDE.Text, date);

                patientController.updateAnamnesis(an, patient.user.Jmbg1);

                CanvasAnamUpdate.Visibility = Visibility.Hidden;
                CanvasAnas.Visibility = Visibility.Visible;
            } else
            {
                MessageBoxResult message = MessageBox.Show(this, "Fill empty fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void pdf_Click(object sender, RoutedEventArgs e)
        {
            Anamnesis anamnesis = (Anamnesis)anamnesisList.SelectedItem;

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("../../pdfGenerate/Anamneza.pdf", FileMode.Create));
            doc.Open();

            Font bold = new Font(FontFactory.GetFont(FontFactory.TIMES_BOLD, 11, Font.BOLD));
            Font small = FontFactory.GetFont("georgia", 7f);
            Font normal = FontFactory.GetFont("georgia", 11f);
            Font dateFont = FontFactory.GetFont("georgia", 9f);
            Paragraph e1 = new Paragraph("Bolica Zdravlje", small);
            Paragraph e2 = new Paragraph("Novi Sad Pavla Papa 24", small);
            Paragraph e3 = new Paragraph("492-231", small);
           

            Paragraph p0 = new Paragraph("\n");
            Paragraph p00 = new Paragraph("\n");
            Paragraph p1 = new Paragraph("Ime: " + patient.user.Name1,bold);
            Paragraph p2 = new Paragraph("Prezime: " + patient.user.LastName1, bold);
            Paragraph p3 = new Paragraph("JMBG: " + patient.user.Jmbg1, bold);

            Paragraph p4 = new Paragraph("\n\n");
            Paragraph p5 = new Paragraph("Anamneza: ", bold);
            Paragraph p6 = new Paragraph(anamnesis.Description, normal);
            Paragraph p000 = new Paragraph("\n\n");

            Paragraph p8 = new Paragraph("Datum: " + anamnesis.Date, dateFont);

            Paragraph p7 = new Paragraph("Izveštaj je  napisao doktor " + MainWindow.user.Name1 + " "  + MainWindow.user.LastName1 + ".", normal);

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
            doc.Add(p000);
            doc.Add(p7);
            doc.Add(p8);
            doc.Add(p9);

            iTextSharp.text.Image sig = iTextSharp.text.Image.GetInstance("../../Images/sigSmall.png");
            sig.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc.Add(sig);


            doc.Add(e1);
            doc.Add(e2);
            doc.Add(e3);
            doc.Close();
        }


        

    }
}
