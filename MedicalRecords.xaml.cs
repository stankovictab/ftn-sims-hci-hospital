using Classes;
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
    /// Interaction logic for MedicalRecords.xaml
    /// </summary>
    public partial class MedicalRecords : Window
    {
        PatientController patientController;
        Perscription prescriptionUpdate;
        Anamnesis anamnesisUpdate;
        Patient p;
        public MedicalRecords()
        {
            InitializeComponent();
            patientController = new PatientController();

            prescriptionList.Visibility = Visibility.Hidden;
            anamnesisList.Visibility = Visibility.Hidden;
            CanvasPers.Visibility = Visibility.Hidden;

            PatientRepository p = new PatientRepository();

            List<Patient> patients = p.GetAll();
            lvUsers.ItemsSource = patients;
        }

        private void create(object sender, RoutedEventArgs e)
        {
            if (radioA.IsChecked == true || radioP.IsChecked == true)
            {
                if (radioP.IsChecked == true)
                {
                    Random rnd = new Random();
                    int r = rnd.Next(1, 1000);

                    Patient patient = (Patient)lvUsers.SelectedItem;
                    Perscription p = new Perscription(r.ToString(), txtM.Text, int.Parse(txtA.Text), txtD.Text);

                    patientController.addPrescription(p, patient.user.Jmbg1);
                }

                if(radioA.IsChecked == true)
                {

                }
            }
            else
            {
                MessageBox.Show("select anamnesis or prescription!");
            }
        }

        private void show(object sender, RoutedEventArgs e)
        {
            if (radioA.IsChecked == true || radioP.IsChecked == true)
            {
                if (radioP.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    p = (Patient)lvUsers.SelectedItem;
                    lvUsers.Visibility = Visibility.Hidden;

                    List<Perscription> prescriptions = patientController.getAllPrescription(p.user.Jmbg1);
                    prescriptionList.ItemsSource = prescriptions;

                    prescriptionList.Visibility = Visibility.Visible;
                }

                if (radioA.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    p = (Patient)lvUsers.SelectedItem;
                    p = (Patient)lvUsers.SelectedItem;

                    List<Anamnesis> anamneses = patientController.getAllAnamnesis(p.user.Jmbg1);
                    anamnesisList.ItemsSource = anamneses;

                    anamnesisList.Visibility = Visibility.Visible;

                }
            }
            else
            {
                MessageBox.Show("select anamnesis or prescription!");
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if (radioA.IsChecked == true || radioP.IsChecked == true)
            {
                if (radioP.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    Perscription prescription = (Perscription)prescriptionList.SelectedItem;

                    patientController.removePrescription(prescription.Id);
                }

                if (radioA.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    Anamnesis anamnesis = (Anamnesis)anamnesisList.SelectedItem;

                    patientController.removeAnamnesis(anamnesis.Id);
                }
            }
            else
            {
                MessageBox.Show("select anamnesis or prescription!");
            }
        }

        private void update(object sender, RoutedEventArgs e)
        {
            if (radioA.IsChecked == true || radioP.IsChecked == true)
            {
                if (radioP.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    prescriptionUpdate = (Perscription)prescriptionList.SelectedItem;

                    txtMU.Text = prescriptionUpdate.Medicine;
                    txtAU.Text = prescriptionUpdate.Amount.ToString();
                    txtDU.Text = prescriptionUpdate.Description;

                    CanvasPersUpdate.Visibility = Visibility.Visible;
                }

                if (radioA.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    anamnesisUpdate = (Anamnesis)anamnesisList.SelectedItem;

                    txtDA.Text = anamnesisUpdate.Date.ToString("hh:mm:ss dd.MM.yyyy");
                    txtDE.Text = anamnesisUpdate.Description;

                    CanvasAnamUpdate.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("select anamnesis or prescription!");
            }
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (radioA.IsChecked == true || radioP.IsChecked == true)
            {
                if (radioP.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    Perscription per = new Perscription(prescriptionUpdate.Id, txtMU.Text, int.Parse(txtAU.Text), txtDU.Text); ;

                    patientController.updatePrescription(per, p.user.Jmbg1);

                    CanvasPersUpdate.Visibility = Visibility.Hidden;
                }

                if (radioA.IsChecked == true)
                {
                    PatientController patientController = new PatientController();
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime date = DateTime.ParseExact(txtDA.Text, "hh:mm:ss dd.MM.yyyy", provider);
                    Anamnesis an = new Anamnesis(anamnesisUpdate.Id, txtDE.Text, date);

                    patientController.updateAnamnesis(an, p.user.Jmbg1);

                    CanvasPersUpdate.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                MessageBox.Show("select anamnesis or prescription!");
            }
        }

        private void radioA_Checked(object sender, RoutedEventArgs e)
        {
            CanvasPers.Visibility = Visibility.Hidden;
        }

        private void radioP_Checked(object sender, RoutedEventArgs e)
        {
            CanvasPers.Visibility = Visibility.Visible;
        }

        
    }
}
    