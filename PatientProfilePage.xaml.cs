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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    public partial class PatientProfilePage : Page
    {
        private ReminderController reminderController;
        public PatientProfilePage()
        {
            reminderController = new ReminderController();
            InitializeComponent();
            LoadReminders();
        }

        private void LoadReminders()
        {
            List<Reminder> notHighlightedReminders = reminderController.GetAllByPatientID(MainWindow.user.Jmbg1, false);
            foreach(Reminder r in notHighlightedReminders)
            {
                if(r.Date < DateTime.Now)
                {
                    r.Highlighted = true;
                    reminderController.Update(r);
                }
            }
            List<Reminder> highlightedReminders = setHighlightedToSeen();
            highlightedRemindersTable.ItemsSource = highlightedReminders;
            remindersTable.ItemsSource = reminderController.GetAllByPatientID(MainWindow.user.Jmbg1, false);
        }
        private List<Reminder> setHighlightedToSeen()
        {
            List<Reminder> reminders = reminderController.GetAllByPatientID(MainWindow.user.Jmbg1, true);
            foreach (Reminder r in reminders)
            {
                if (r.Seen)
                {
                    reminderController.Delete(r.Id);
                }
                else
                {
                    r.Seen = true;
                    reminderController.Delete(r.Id);
                }
            }
            return reminders;
        }

        private void CancelReminder(object render, RoutedEventArgs e)
        {
            Reminder selected = (Reminder)(remindersTable.SelectedItem);
            reminderController.Delete(selected.Id);
            LoadReminders();
        }

        private void UpdateReminder(object render, RoutedEventArgs e)
        {
            Reminder selected = (Reminder)(remindersTable.SelectedItem);
            CreateReminder cr = new CreateReminder(selected);
            cr.Show();
        }

        private void CreateReminder(object sender, RoutedEventArgs e)
        {
            CreateReminder cr = new CreateReminder(null);
            cr.Show();
        }
    }
}
