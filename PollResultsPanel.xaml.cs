using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;
using ftn_sims_hci_hospital.Classes;

namespace ftn_sims_hci_hospital
{
    public partial class PollResultsPanel : Window
    {
        public static HospitalPollRepository hpr = new HospitalPollRepository();
        public static DoctorPollRepository dpr = new DoctorPollRepository();
        Dictionary<string, List<DoctorPoll>> doctorsByPolls = new Dictionary<string, List<DoctorPoll>>(); // doctorID <-> lista njegovih poll-ova

        public PollResultsPanel()
        {
            InitializeComponent();
            fillHospitalPollResults(hpr.GetAll());
            fillDoctorPollResults(dpr.GetAll());
        }

        private void fillHospitalPollResults(List<HospitalPoll> hospitalPolls)
        {
            List<Poll> pollList = hospitalPolls.ConvertAll(x => (Poll)x); // Prebacivanje liste podklasa u listu nadklasa

            // TODO: Template funkcija za convertToPollList? Jos bi bolje bilo da je calculatePollResults() template funkcija koja radi i sa doctorPolls i sa hospitalPolls
            List<Poll> pollList = new List<Poll>();
            foreach (Poll p in hospitalPolls)
            {
                pollList.Add(p);
            }
            var results = calculatePollResults(pollList);

            hospitalAverageScore.Content = results.Item1;
            hospitalFives.Content = results.Item2;
            hospitalFours.Content = results.Item3;
            hospitalThrees.Content = results.Item4;
            hospitalTwos.Content = results.Item5;
            hospitalOnes.Content = results.Item6;
        }

        private void fillDoctorPollResults(List<DoctorPoll> doctorPolls)
        {
            /*List<Poll> pollList = new List<Poll>();
            foreach (Poll p in doctorPolls)
            {
                pollList.Add(p);
            }
            var results = calculatePollResults(pollList);*/




            // u calculatePollResults treba da ide pollLista ali samo za jednog doktora, filtrirano
            // to se radi u foreach-u, a pre toga mora da se izfiltrira pocetni doctorPolls na vise pollList-i

            // Punjenje recnika
            foreach (DoctorPoll poll in doctorPolls)
            {
                string doctorName = poll.doctor.user.Name1 + " " + poll.doctor.user.LastName1;
                if(doctorsByPolls.ContainsKey(doctorName) == false)
                    doctorsByPolls.Add(doctorName, new List<DoctorPoll>());
            }
            foreach (DoctorPoll poll in doctorPolls)
            {
                string doctorName = poll.doctor.user.Name1 + " " + poll.doctor.user.LastName1;

                List<DoctorPoll> temp = doctorsByPolls[doctorName];
                temp.Add(poll);
                doctorsByPolls[doctorName] = temp; // Nece bez inicijalizacije kljuca
            }

            // U recniku su sada svi poll-ovi za svakog doktora, sada se puni
            foreach (KeyValuePair<string, List<DoctorPoll>> entry in doctorsByPolls)
            {
                insertIntoListView(entry.Key, entry.Value);
            }
        }

        private void insertIntoListView(string doctorName, List<DoctorPoll> doctorsPolls)
        {
            List<Poll> pollList = new List<Poll>();
            foreach (Poll p in doctorsPolls)
            {
                pollList.Add(p);
            }
            var results = calculatePollResults(pollList);

            doctorPollResultsListView.Items.Add(new { Doctor = doctorName, AverageScore = results.Item1, Fives = results.Item2, Fours = results.Item3, Threes = results.Item4, Twos = results.Item5, Ones = results.Item6});
        }

        private Tuple<double, int, int, int, int, int> calculatePollResults(List<Poll> polls)
        {
            double avg = 0.0;
            int num = 0, fives = 0, fours = 0, threes = 0, twos = 0, ones = 0;
            
            foreach (Poll p in polls)
            {
                avg += p.mark;
                num++;
                switch (p.mark)
                {
                    case 5: fives++; break;
                    case 4: fours++; break;
                    case 3: threes++; break;
                    case 2: twos++; break;
                    case 1: ones++; break;
                    default: throw new Exception("Invalid mark.");
                }
            }
            avg = Math.Round(avg / num, 2);
            var tuple = new Tuple<double, int, int, int, int, int>(avg, fives, fours, threes, twos, ones);
            return tuple;
        }

        /*private Tuple<double, int, int, int, int, int> calculateDoctorPollResults(List<DoctorPoll> doctorPolls) // TODO: Template da nema dve skoro identicne funkcije
        {
            double avg = 0.0;
            int num = 0, fives = 0, fours = 0, threes = 0, twos = 0, ones = 0;
            foreach (DoctorPoll p in doctorPolls)
            {
                avg += p.mark;
                num++;
                switch (p.mark)
                {
                    case 5: fives++; break;
                    case 4: fours++; break;
                    case 3: threes++; break;
                    case 2: twos++; break;
                    case 1: ones++; break;
                    default: throw new Exception("Invalid mark.");
                }
            }
            avg = avg / num;
            var tuple = new Tuple<double, int, int, int, int, int>(avg, fives, fours, threes, twos, ones);
            return tuple;
        }

        private Tuple<double, int, int, int, int, int> calculateHospitalPollResults<T>(List<T> polls)
        {
            double avg = 0.0;
            int num = 0, fives = 0, fours = 0, threes = 0, twos = 0, ones = 0;
            foreach (T p in polls)
            {
                avg += p.mark;
                num++;
                switch (p.mark)
                {
                    case 5: fives++; break;
                    case 4: fours++; break;
                    case 3: threes++; break;
                    case 2: twos++; break;
                    case 1: ones++; break;
                    default: throw new Exception("Invalid mark.");
                }

            }
            avg = avg / num;
            var tuple = new Tuple<double, int, int, int, int, int>(avg, fives, fours, threes, twos, ones);
            return tuple;
        }*/
    }
}
