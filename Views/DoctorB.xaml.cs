using Classes;
using ftn_sims_hci_hospital;
using ftn_sims_hci_hospital.Views;
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
using Models;
using ViewModels;
using ftn_sims_hci_hospital.ViewModels;

namespace Views
{
    public partial class DoctorB : Window
    {
        AppointmentController appointmentController;
        PatientRepository patientController;
        MedicineCotroller medicineCotroller;
       

        public static RoutedCommand openMedicalRecordsCommand = new RoutedCommand();
        public static RoutedCommand openScheduleCommand = new RoutedCommand();
        public static RoutedCommand openMecineValidationCommand = new RoutedCommand();
        public static RoutedCommand openAnamnesisCommand = new RoutedCommand();
        public static RoutedCommand openTreatmentsCommand = new RoutedCommand();
        public static RoutedCommand openPrescriptionsCommand = new RoutedCommand();
        public static RoutedCommand openRefferalsCommand = new RoutedCommand();

        public DoctorB()
        {
            InitializeComponent();
            patientController = new PatientRepository();
            appointmentController = new AppointmentController();
            medicineCotroller = new MedicineCotroller();
            InitializeMenu();
            loadCommands();
 
            this.DataContext = new AppointmentViewModel(MainWindow.user.Jmbg1);
        }

        private void menuSelection(object sender, SelectionChangedEventArgs e)
        {

            int index = menu.SelectedIndex;
            switch (index)
            {
                case 0:
                    showMedRecCanvas(sender, e);
                    break;
                case 1:
                    showAppointmentsList(sender, e);
                    break;
                case 2:
                    showMedicineList(sender, e);
                    break;
                /*case 3:
                    showMedicalRecords(sender, e);
                    break;*/
            }
        }

        public void openAnamnesisWindow(Object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)lvUsers.SelectedItem;
            if (patient != null)
            {
                AnamnesisWindow anamnesisWindow = new AnamnesisWindow(patient);
                anamnesisWindow.Show();
            } else
            {
                MessageBoxResult message = MessageBox.Show(this, "Select patient to continue.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
        }

        private void openMain(Object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void showMedRecCanvas(Object sender, RoutedEventArgs e)
        {
            hideAll();

            List<Patient> patients = patientController.GetAll();
            lvUsers.ItemsSource = patients;
            canvasMedicalRecords.Visibility = Visibility.Visible;
        }

        public void showAppointmentsList(Object sender, RoutedEventArgs e)
        {
            hideAll();

            //List<Appointment> appointments = appointmentController.GetAllByDoctorId(MainWindow.user.Jmbg1);
            //appointmentsList.ItemsSource = appointments;
            //appointmentsList.SelectedItem = appointments[0];
            canvasSchedule.Visibility = Visibility.Visible;
        }

        private void showMedicineList(Object sender, RoutedEventArgs e)
        {
            hideAll();

            //List<Medicine> medicines = medicineCotroller.GetAll();
            //medicineList.ItemsSource = medicines;
            canvasMedicine.Visibility = Visibility.Visible;
        }

        private void showMedicalRecords(Object sender, RoutedEventArgs e)
        {
            MedicalRecords medicalRecords = new MedicalRecords();
            medicalRecords.Show();
        }
        private void openAppointmentsList(Object sender, RoutedEventArgs e)
        {
            AppointmentsListDoctorB a = new AppointmentsListDoctorB();
            a.Show();
        }

        private void openCreateAppointment(Object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)lvUsers.SelectedItem;
            if (patient != null)
            {
                CreateAppointmentDoctorB c = new CreateAppointmentDoctorB(patient);
                c.Show();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show(this, "Select patient to continue.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void openDeleteAppointment(Object sender, RoutedEventArgs e)
        {
            DeleteAppointmentDoctorB d = new DeleteAppointmentDoctorB();
            d.Show();
        }

        private void openMedicineList(Object sender, RoutedEventArgs e)
        {
            MedicineList medicineListWindow = new MedicineList();
            medicineListWindow.Show();
        }

        // ova metoda je samo privremeno ne daje mogucnost pisanja razloga odbijanja leka
        private void deleteMedicine(object sender, RoutedEventArgs e)
        {
            Medicine medicineForDelete = (Medicine)medicineList.SelectedItem;
            if (medicineForDelete.Status == MedicineStatus.OnHold)
                medicineCotroller.Decline(medicineForDelete);
            else
                MessageBox.Show("already verified!");
        }

        private void approveMedicine(object sender, RoutedEventArgs e)
        {
            Medicine medicineForApprove = (Medicine)medicineList.SelectedItem;
            if (medicineForApprove.Status == MedicineStatus.OnHold)
            {
                medicineCotroller.Approve(medicineForApprove);
            }
            else
                MessageBox.Show("already verified!");

        }

        private void openPrescriptions(object sender, RoutedEventArgs e)
        {
            
            Patient patient = (Patient) lvUsers.SelectedItem;
            if (patient != null)
            {
                Prescriptions prescriptions = new Prescriptions(patient);
                prescriptions.Show();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show(this, "Select patient to continue.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void openDiagnosis(object sender, RoutedEventArgs e)
        {
            if (lvUsers.SelectedItem != null)
            {
                Patient patinet = (Patient)lvUsers.SelectedItem;
                Diagnosis diagnosis = new Diagnosis(patinet);
                diagnosis.Show();
            }
        }

        private void openAddRefferal(object sender, RoutedEventArgs e)
        {   
          
            if (lvUsers.SelectedItem != null)
            {
                Patient patinet = (Patient)lvUsers.SelectedItem;
                
                    
                    AddReferral addReferral = new AddReferral(patinet);
                    addReferral.Show();
              
            }
        }

        private void openHospitalTreatments(object sender, RoutedEventArgs e)
        {
            
            Patient patient = (Patient)lvUsers.SelectedItem;

            if (patient != null)
            {
                Treatments treatments = new Treatments(patient);
                treatments.Show();
            }
            else
            {
                MessageBoxResult message = MessageBox.Show(this, "Select patient to continue.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void InitializeMenu()
        {
            menu.Items.Add("medical records (r)");
            menu.Items.Add("schedule (s)");
            menu.Items.Add("medicine validation (m)");
            //menu.Items.Add("sims");
        }

        private void hideAll()
        {
            canvasSchedule.Visibility = Visibility.Hidden;
            canvasMedicalRecords.Visibility = Visibility.Hidden;
            canvasHi.Visibility = Visibility.Hidden;
            canvasMedicine.Visibility = Visibility.Hidden;
        }

        private void loadCommands()
        {
            openMedicalRecordsCommand.InputGestures.Add(new KeyGesture(Key.R, ModifierKeys.Control));
            openScheduleCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            openMecineValidationCommand.InputGestures.Add(new KeyGesture(Key.M, ModifierKeys.Control));

            openAnamnesisCommand.InputGestures.Add(new KeyGesture(Key.Q, ModifierKeys.Control));
            openTreatmentsCommand.InputGestures.Add(new KeyGesture(Key.W, ModifierKeys.Control));
            openPrescriptionsCommand.InputGestures.Add(new KeyGesture(Key.E, ModifierKeys.Control));
            openRefferalsCommand.InputGestures.Add(new KeyGesture(Key.T, ModifierKeys.Control));

        }
    }
}
