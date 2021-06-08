using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Classes;
using ftn_sims_hci_hospital.Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerPollResults : Window
    {
        public static PollService service = new PollService();
        Dictionary<string, List<DoctorPoll>> doctorsByPolls = new Dictionary<string, List<DoctorPoll>>(); // doctorID <-> lista njegovih poll-ova

        public AdminManagerPollResults()
        {
            InitializeComponent();
            fillHospitalPollResults(service.hpr.GetAll());
            fillDoctorPollResults(service.dpr.GetAll());
            this.DataContext = this;
        }

        private void fillHospitalPollResults(List<HospitalPoll> hospitalPolls)
        {
            List<Poll> pollList = hospitalPolls.ConvertAll(x => (Poll)x); // Prebacivanje liste podklasa u listu nadklasa
            var results = service.calculatePollResults(pollList);
            int[] resultsArray = { results.Item2, results.Item3, results.Item4, results.Item5, results.Item6 };
            int max = resultsArray.Max();
            
            hospitalAverageScore.Content = results.Item1;
            hospitalFives.Content = results.Item2;
            hospitalFours.Content = results.Item3;
            hospitalThrees.Content = results.Item4;
            hospitalTwos.Content = results.Item5;
            hospitalOnes.Content = results.Item6;

            fivesBar.Value = (Double)results.Item2;
            foursBar.Value = (Double)results.Item3;
            threesBar.Value = (Double)results.Item4;
            twosBar.Value = (Double)results.Item5;
            onesBar.Value = (Double)results.Item6;

            MaxValueLabel.Content = max.ToString();
            fivesBar.MaxValue = max;
            foursBar.MaxValue = max;
            threesBar.MaxValue = max;
            twosBar.MaxValue = max;
            onesBar.MaxValue = max;
        }

        private void fillDoctorPollResults(List<DoctorPoll> doctorPolls)
        {
            // Punjenje recnika
            foreach (DoctorPoll poll in doctorPolls)
            {
                string doctorName = poll.doctor.user.Name1 + " " + poll.doctor.user.LastName1;
                if (doctorsByPolls.ContainsKey(doctorName) == false)
                    doctorsByPolls.Add(doctorName, new List<DoctorPoll>()); // Za svaki entry se ubacuje prazna lista, jer .Add() ne moze na null da dodaje
                doctorsByPolls[doctorName].Add(poll);
            }
            // U recniku su sada svi poll-ovi za svakog doktora, pa sada moze da se puni ListView
            foreach (KeyValuePair<string, List<DoctorPoll>> entry in doctorsByPolls)
                insertIntoListView(entry.Key, entry.Value);
        }

        private void insertIntoListView(string doctorName, List<DoctorPoll> doctorsPolls)
        {
            List<Poll> pollList = doctorsPolls.ConvertAll(x => (Poll)x); // Prebacivanje liste podklasa u listu nadklasa
            var results = service.calculatePollResults(pollList); // U calculatePollResults() ide pollList-a samo jednog doktora

            doctorPollResultsListView.Items.Add(new { Doctor = doctorName, AverageScore = results.Item1, Fives = results.Item2, Fours = results.Item3, Threes = results.Item4, Twos = results.Item5, Ones = results.Item6 });
        }

        // HCI

        private void HolidayRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerHolidayRequestApprovals();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentRequests_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentRequestApprovals();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentOrderPanel_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentOrderPanel();
            this.Close();
            window.ShowDialog();
        }

        private void DynamicEquipmentOrderCreation_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerDynamicEquipmentOrderCreation();
            this.Close();
            window.ShowDialog();
        }

        private void PollResults_Click(object sender, RoutedEventArgs e)
        {
            // Ostaje na istoj stranici
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerReport();
            this.Close();
            window.ShowDialog();
        }

        private void ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerProfile();
            this.Close();
            window.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SwitchAccounts_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel window = new AdminPanel();
            this.Close();
            window.ShowDialog();
        }
    }
}
