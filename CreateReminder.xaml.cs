using Classes;
using ftn_sims_hci_hospital.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class CreateReminder : Window
    {
        private ReminderController reminderController;
        private PatientController patientController;
        private Reminder reminderForUpdate;
        public CreateReminder(Reminder reminder)
        {
            reminderController = new ReminderController();
            patientController = new PatientController();
            reminderForUpdate = reminder;
            InitializeComponent();
            fillFreqCombo();
        }

        private void fillFreqCombo()
        {
            for (int i = 0; i < 13; i++)
            {
                frequencyCombo.Items.Add(i);
            }
            frequencyCombo.Items.Add(24);
            frequencyCombo.Items.Add(48);
            frequencyCombo.Items.Add(72);
        }

        private void SaveReminder(object sender, RoutedEventArgs e)
        {
            String name = nameTextBox.Text;
            String description = descriptionTextBox.Text;
            DateTime date = (DateTime)datePicker.SelectedDate;
            String time = timeTextBox.Text;
            DateTime exactTime = new DateTime(date.Year, date.Month, date.Day, int.Parse(time.Split(':')[0]), int .Parse(time.Split(':')[1]), 0);
            int freq = (int)frequencyCombo.SelectedItem;
            Patient p = patientController.GetByID(MainWindow.user.Jmbg1);
            Reminder r = new Reminder(p, name, description, exactTime, false, false, freq);
            if(this.reminderForUpdate is null)
            {
                reminderController.Create(r);
                cleanAfterCreation("Uspešno ste kreirali podsetnik");
            }
            else
            {
                r.Id = reminderForUpdate.Id;
                reminderController.Update(r);
                cleanAfterCreation("Uspešno ste ažurirali podsetnik");
            }

        }

        private void cleanAfterCreation(String messageText)
        {
            message.Content = messageText;
            message.Visibility = Visibility.Visible;
            nameTextBox.Text = "";
            descriptionTextBox.Text = "";
            timeTextBox.Text = "";
            datePicker.SelectedDate = DateTime.Now;
            frequencyCombo.SelectedItem = 0;
        }
    }
}
