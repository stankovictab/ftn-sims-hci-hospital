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
    public partial class DoctorB : Window
    {
        AppointmentController appointmentController;
        PatientRepository patientController;
        MedicineCotroller medicineCotroller;
        HospitalizationReferalRepository hospitalizationReferalRepository;

        public static RoutedCommand openMedicalRecordsCommand = new RoutedCommand();

        public DoctorB()
        {
            InitializeComponent();
            patientController = new PatientRepository();
            appointmentController = new AppointmentController();
            medicineCotroller = new MedicineCotroller();
            InitializeMenu();

            openMedicalRecordsCommand.InputGestures.Add(new KeyGesture(Key.R, ModifierKeys.Control));
            openMedicalRecordsCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            openMedicalRecordsCommand.InputGestures.Add(new KeyGesture(Key.M, ModifierKeys.Control));
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
                case 3:
                    showMedicalRecords(sender, e);
                    break;
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

        private void showAppointmentsList(Object sender, RoutedEventArgs e)
        {
            hideAll();

            List<Appointment> appointments = appointmentController.GetAllByDoctorId(MainWindow.user.Jmbg1);
            appointmentsList.ItemsSource = appointments;
            appointmentsList.SelectedItem = appointments[0];
            canvasSchedule.Visibility = Visibility.Visible;
        }

        private void showMedicineList(Object sender, RoutedEventArgs e)
        {
            hideAll();

            List<Medicine> medicines = medicineCotroller.GetAll();
            medicineList.ItemsSource = medicines;
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
            CreateAppointmentDoctorB c = new CreateAppointmentDoctorB();
            c.Show();
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
            if (lvUsers.SelectedItem != null)
            {
                Patient patinet = (Patient)lvUsers.SelectedItem;
                Treatments treatments = new Treatments(patinet);
                treatments.Show();
            }
        }

        private void InitializeMenu()
        {
            menu.Items.Add("medical records (r)");
            menu.Items.Add("schedule (s)");
            menu.Items.Add("medicine validation (m)");
            menu.Items.Add("sims");
        }

        private void hideAll()
        {
            canvasSchedule.Visibility = Visibility.Hidden;
            canvasMedicalRecords.Visibility = Visibility.Hidden;
            canvasHi.Visibility = Visibility.Hidden;
            canvasMedicine.Visibility = Visibility.Hidden;
        }
    }
}
