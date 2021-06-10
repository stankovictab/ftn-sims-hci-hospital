using Classes;
using ftn_sims_hci_hospital.pdfGenerate;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AnamnesisWindow.xaml
    /// </summary>
    public partial class AnamnesisWindow : Window
    {
        PatientController patientController = new PatientController();
        Patient patient;
        Anamnesis anamnesisUpdate;
        public AnamnesisWindow(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();

            List<Anamnesis> anamneses = patientController.getAllAnamnesis(patient.user.Jmbg1);
            anamnesisList.ItemsSource = anamneses;
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
            }
            else
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
            }
            else
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
            }
            else
            {
                MessageBoxResult message = MessageBox.Show(this, "Fill empty fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void printAnamnesis(object sender, RoutedEventArgs e)
        {

            ExportReport exportReport = new ExportReport();
            exportReport.addPatient(patient.user);
            Anamnesis anamnesis = (Anamnesis)anamnesisList.SelectedItem;
            exportReport.addAnamnesis(anamnesis);
            exportReport.addDoctor(MainWindow.user);
            if (exportReport.generate())
            {
                MessageBox.Show("Report successfully generated");
            }
        }
    }
}
