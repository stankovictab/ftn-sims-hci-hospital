using Classes;
using ftn_sims_hci_hospital.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class PollPage : Page
    {
        private AppointmentRepository appointmentRepository;
        private DoctorPollRepository pollRepository;
        private HospitalPollRepository hospitalPollRepository;
        private HospitalPollController hospitalPollController;
        private DoctorPollController doctorPollController;
        public PollPage()
        {
            InitializeComponent();
            appointmentRepository = new AppointmentRepository();
            pollRepository = new DoctorPollRepository();
            hospitalPollRepository = new HospitalPollRepository();
            ShowHospitalResults();
            List<Doctor> doctors = appointmentRepository.GetAllPatientsDoctors(MainWindow.user.Jmbg1);
            doctorsCombo.ItemsSource = doctors;
            hospitalPollController = new HospitalPollController();
            doctorPollController = new DoctorPollController();
        }

        private void ShowDoctorsResults(object sender, SelectionChangedEventArgs e)
        {
            Doctor doc = (Doctor)doctorsCombo.SelectedItem;
            DoctorPoll p = pollRepository.GetPoll(MainWindow.user.Jmbg1, doc.user.Jmbg1);
            ShowDoctorControlls();
            doctorCommentTextBox.Text = "";
            if (p is null)
            {
                currentDoctorMark.Content = "Vasa trenutna ocena: Nije ocenjen";
                currentDoctorComment.Content = "Vas trenutni komentar: Nema komentara";
            }
            else
            {
                if (p.mark == 0)
                {
                    currentDoctorMark.Content = "Vasa trenutna ocena: Nije ocenjen";
                }
                else
                {
                    currentDoctorMark.Content = "Vasa trenutna ocena: " + p.mark;
                }
                currentDoctorComment.Content = "Vas trenutni komentar: " + p.comment;
            }
            averageDoctorMark.Content = "Prosecna ocena: " + doctorPollController.GenerateDoctorAverageMark(doc.user.Jmbg1);

        }

        private void SaveDoctorMark(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)markCombo.SelectedItem;
            int mark = int.Parse(typeItem.Content.ToString());
            Doctor doc = (Doctor)doctorsCombo.SelectedItem;
            Patient p = new Patient();
            p.user.Jmbg1 = MainWindow.user.Jmbg1;
            Doctor d = new Doctor();
            d.user.Jmbg1 = doc.user.Jmbg1;

            DoctorPoll dp = pollRepository.GetPoll(MainWindow.user.Jmbg1, doc.user.Jmbg1);
            if (dp is null)
            {
                pollRepository.doctorPoll = new DoctorPoll(p, d, mark, "");
                pollRepository.Create();
            }
            else
            {
                pollRepository.doctorPoll = new DoctorPoll(p, d, mark, dp.comment);
                pollRepository.UpdateSteps();
            }
        }

        private void SaveDoctorComment(object sender, RoutedEventArgs e)
        {
            String comment = (String)doctorCommentTextBox.Text;
            Doctor doc = (Doctor)doctorsCombo.SelectedItem;
            Patient p = new Patient();
            p.user.Jmbg1 = MainWindow.user.Jmbg1;
            Doctor d = new Doctor();
            d.user.Jmbg1 = doc.user.Jmbg1;

            DoctorPoll dp = pollRepository.GetPoll(MainWindow.user.Jmbg1, doc.user.Jmbg1);
            if (dp is null)
            {
                pollRepository.doctorPoll = new DoctorPoll(p, d, 0, comment);
                pollRepository.Create();
            }
            else
            {
                pollRepository.doctorPoll = new DoctorPoll(p, d, dp.mark, comment);
                pollRepository.UpdateSteps();
            }
        }

        private void ShowDoctorControlls()
        {
            currentDoctorMark.Visibility = Visibility.Visible;
            currentDoctorComment.Visibility = Visibility.Visible;
            doctorCommentTextBox.Visibility = Visibility.Visible;
            saveDoctorComment.Visibility = Visibility.Visible;
            markDoctorLabel.Visibility = Visibility.Visible;
            commentDoctorLabel.Visibility = Visibility.Visible;
            markCombo.Visibility = Visibility.Visible;
            averageDoctorMark.Visibility = Visibility.Visible;
        }

        private void ShowHospitalResults()
        {
            HospitalPoll hospitalPoll = hospitalPollRepository.GetByPatientId(MainWindow.user.Jmbg1);
            hospitalCommentTextBox.Text = "";
            if (hospitalPoll is null)
            {
                currentHostpitalMark.Content = "Vasa trenutna ocena: Nije ocenjen";
                currentHospitalComment.Content = "Vas trenutni komentar: Nema komentara";
            }
            else
            {
                if (hospitalPoll.mark == 0)
                {
                    currentHostpitalMark.Content = "Vasa trenutna ocena: Nije ocenjen";
                }
                else
                {
                    currentHostpitalMark.Content = "Vasa trenutna ocena: " + hospitalPoll.mark;
                }
                currentHospitalComment.Content = "Vas trenutni komentar: " + hospitalPoll.comment;
            }
            float average = hospitalPollController.GenerateAverageMark();
            averageHospitalMark.Content = "Prosecna ocena bolnice: " + average;

        }
        private void SaveHospitalMark(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)hospitalMarkCombo.SelectedItem;
            int mark = int.Parse(typeItem.Content.ToString());
            HospitalPoll hospitalPoll = hospitalPollRepository.GetByPatientId(MainWindow.user.Jmbg1);
            Patient p = new Patient();
            p.user.Jmbg1 = MainWindow.user.Jmbg1;

            if (hospitalPoll is null)
            {
                hospitalPollRepository.hospitalPoll = new HospitalPoll(p, mark, "");
                hospitalPollRepository.Create();
            }
            else
            {
                hospitalPollRepository.hospitalPoll = new HospitalPoll(p, mark, hospitalPoll.comment);
                hospitalPollRepository.UpdateSteps();
            }
        }

        private void SaveHospitalComment(object sender, RoutedEventArgs e)
        {
            String comment = (String)hospitalCommentTextBox.Text;
            HospitalPoll hospitalPoll = hospitalPollRepository.GetByPatientId(MainWindow.user.Jmbg1);
            Patient p = new Patient();
            p.user.Jmbg1 = MainWindow.user.Jmbg1;

            if (hospitalPoll is null)
            {
                hospitalPollRepository.hospitalPoll = new HospitalPoll(p, 0, comment);
                hospitalPollRepository.Create();
            }
            else
            {
                hospitalPollRepository.hospitalPoll = new HospitalPoll(p, hospitalPoll.mark, comment);
                hospitalPollRepository.UpdateSteps();
            }
        }
    }
}
