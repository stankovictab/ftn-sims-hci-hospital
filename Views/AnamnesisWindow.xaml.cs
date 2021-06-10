using System;
using System.Globalization;
using System.Windows;
using Classes;
using ViewModels;
using ftn_sims_hci_hospital.pdfGenerate;
using ftn_sims_hci_hospital;

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

        private void printAnamnesis(object sender, RoutedEventArgs e)
        {

            ExportReport exportReport = new ExportReport();
            exportReport.addPatient(patient.user);
            Anamnesis anamnesis = (Anamnesis)anamnesisList.SelectedItem;
            exportReport.addAnamesis(anamnesis);
            exportReport.addDoctor(MainWindow.user);
            if (exportReport.generate())
            {
                MessageBox.Show("Report successfully generated");
            }
        }


        

    }
}
