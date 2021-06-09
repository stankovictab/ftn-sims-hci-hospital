using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Models;
using System.Collections.ObjectModel;
using Classes;
namespace ftn_sims_hci_hospital.ViewModels
{
    class AppointmentViewModel : ViewModel
    {
        private ObservableCollection<Appointment> apps;
        private ObservableCollection<Medicine> meds;
        private ObservableCollection<Patient> pats;

        public ObservableCollection<Patient> Pats
        {
            get { return pats; }
            set
            {
                pats = value;
            }
        }
        public ObservableCollection<Appointment> Apps
        {
            get { return apps; }
            set
            {
                apps = value;
            }
        }
        public ObservableCollection<Medicine> Meds
        {
            get { return meds; }
            set
            {
                meds = value;
            }
        }

        public AppointmentViewModel(String doctorId)
        {
            LoadApps(doctorId);
            LoadMeds();
            //LoadPats();
        }

        private void LoadPats()
        {
            PatientController patientController = new PatientController();
            pats = new ObservableCollection<Patient>(patientController.GetAll());
        }

        private void LoadMeds()
        {
            MedicineCotroller medicineCotroller = new MedicineCotroller();
            meds = new ObservableCollection<Medicine>(medicineCotroller.GetAll());
        }

        private void LoadApps(String doctorId)
        {
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            apps = new ObservableCollection<Appointment>(appointmentRepository.GetAllByDoctorID(doctorId));
        }
    }
}
