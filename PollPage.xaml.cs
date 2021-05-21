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
        public PollPage()
        {
            InitializeComponent();
            appointmentRepository = new AppointmentRepository();
            pollRepository = new DoctorPollRepository();
            hospitalPollRepository = new HospitalPollRepository();
            ShowHospitalResults();
            List<Doctor> doctors = appointmentRepository.GetAllPatientsDoctors(MainWindow.user.Jmbg1);
            doctorsCombo.ItemsSource = doctors;
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
            averageDoctorMark.Content = "Prosecna ocena: " + pollRepository.GenerateDoctorAverageMark(doc.user.Jmbg1);

        }

        private void SaveDoctorMark(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)markCombo.SelectedItem;
            int mark = int.Parse(typeItem.Content.ToString());
            Doctor doc = (Doctor)doctorsCombo.SelectedItem;
            DoctorPoll p = pollRepository.GetPoll(MainWindow.user.Jmbg1, doc.user.Jmbg1);
            if (p is null)
            {
                pollRepository.Create(MainWindow.user.Jmbg1, doc.user.Jmbg1, mark, "");
            }
            else
            {
                pollRepository.Update(MainWindow.user.Jmbg1, doc.user.Jmbg1, mark, p.comment);
            }
        }

        private void SaveDoctorComment(object sender, RoutedEventArgs e)
        {
            String comment = (String)doctorCommentTextBox.Text;
            Doctor doc = (Doctor)doctorsCombo.SelectedItem;
            DoctorPoll p = pollRepository.GetPoll(MainWindow.user.Jmbg1, doc.user.Jmbg1);
            if (p is null)
            {
                pollRepository.Create(MainWindow.user.Jmbg1, doc.user.Jmbg1, 0, comment);
            }
            else
            {
                pollRepository.Update(MainWindow.user.Jmbg1, doc.user.Jmbg1, p.mark, comment);
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
            float average = hospitalPollRepository.GenerateAverageMark();
            averageHospitalMark.Content = "Prosecna ocena bolnice: " + average;

        }
        private void SaveHospitalMark(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)hospitalMarkCombo.SelectedItem;
            int mark = int.Parse(typeItem.Content.ToString());
            HospitalPoll hospitalPoll = hospitalPollRepository.GetByPatientId(MainWindow.user.Jmbg1);
            if (hospitalPoll is null)
            {
                hospitalPollRepository.Create(MainWindow.user.Jmbg1, mark, "");
            }
            else
            {
                hospitalPollRepository.Update(MainWindow.user.Jmbg1, mark, hospitalPoll.comment);
            }
        }

        private void SaveHospitalComment(object sender, RoutedEventArgs e)
        {
            String comment = (String)hospitalCommentTextBox.Text;
            HospitalPoll hospitalPoll = hospitalPollRepository.GetByPatientId(MainWindow.user.Jmbg1);
            if (hospitalPoll is null)
            {
                hospitalPollRepository.Create(MainWindow.user.Jmbg1, 0, comment);
            }
            else
            {
                hospitalPollRepository.Update(MainWindow.user.Jmbg1, hospitalPoll.mark, comment);
            }
        }
    }
}
