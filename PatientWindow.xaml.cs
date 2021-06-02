using Classes;
using ftn_sims_hci_hospital.Classes;
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
using System.Windows.Threading;

namespace ftn_sims_hci_hospital
{
    public partial class PatientWindow : Window
    {
        private ReminderController reminderController;
        public PatientWindow()
        {
            reminderController = new ReminderController();
            InitializeComponent();
            pregledProfilaButton.Content = "Pregled profila " + MainWindow.user.Username1;
            Main.Content = new PatientProfilePage();
            InitTimer();
        }

        private void InitTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }

        private void ShowAllAppointments(object sender, RoutedEventArgs e)
        {
            Main.Content = new AllAppointmentsPage();
        }

        private void CreateAppointmentButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateAppointmentPage();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NotificationsList(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotificationsPage();
        }

        private void CreateAppointmentSpecialistButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new createAppointmentSpecialist();
        }

        private void FillPoll(object sender, RoutedEventArgs e)
        {
            Main.Content = new PollPage();
        }

        private void ViewAccount(object sender, RoutedEventArgs e)
        {
            reminderCounter.Content = "0";
            reminderCounter.Visibility = Visibility.Hidden;
            reminderCounterBorder.Visibility = Visibility.Hidden;
            Main.Content = new PatientProfilePage(); 
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow.user = null;
            this.Close();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            List<Reminder> reminders = reminderController.GetAllByPatientID(MainWindow.user.Jmbg1, false);
            foreach (Reminder r in reminders)
            {
                if(r.Date.Year.Equals(DateTime.Now.Year) && r.Date.Month.Equals(DateTime.Now.Month) && r.Date.Day.Equals(DateTime.Now.Day) && r.Date.Hour.Equals(DateTime.Now.Hour) && r.Date.Minute.Equals(DateTime.Now.Minute))
                {
                    r.Highlighted = true;
                    reminderController.Update(r);
                    UpdateReminderCounter();
                    if (r.FrequencyInHours > 0)
                    {
                        r.Highlighted = false;
                        r.Date = r.Date.AddHours(r.FrequencyInHours);
                        reminderController.Create(r);
                    }
                }
            }
        }
        private void UpdateReminderCounter()
        {
            if(reminderCounterBorder.Visibility == Visibility.Hidden)
            {
                reminderCounterBorder.Visibility = Visibility.Visible;
                reminderCounter.Visibility = Visibility.Visible;
            }
            int broj = int.Parse(reminderCounter.Content.ToString());
            reminderCounter.Content = (++broj).ToString();
        }

        private void ShowAnamnesis(object sender, RoutedEventArgs e)
        {
            Main.Content = new AllAnamnesisPage(); ;
        }

        private void ShowHospitalizationReferrals(object sender, RoutedEventArgs e)
        {
            Main.Content = new AllHospitalizationReferralsPage();
        }

        private void ShowAlergies(object sender, RoutedEventArgs e)
        {
            Main.Content = new AllAllergiesPage();
        }

        private void ShowPersriptions(object sender, RoutedEventArgs e)
        {
            Main.Content = new AllPerscriptionsPage();
        }

        private void ShowPersonalData(object sender, RoutedEventArgs e)
        {
            Main.Content = new PersonalData();
        }
    }
}
