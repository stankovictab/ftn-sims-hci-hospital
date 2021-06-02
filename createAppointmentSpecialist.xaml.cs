using Classes;
using ftn_sims_hci_hospital.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class createAppointmentSpecialist : Page
    {
        private ReferralRepository referralRepository;
        private AppointmentController appointmentController;
        private String selectedReferralId;
        public createAppointmentSpecialist()

        {
            referralRepository = new ReferralRepository();
            appointmentController = new AppointmentController();
            selectedReferralId = "";
            InitializeComponent();
            List<Referral> rs = referralRepository.GetAllByPatientId(MainWindow.user.Jmbg1);
            referrals.ItemsSource = rs;
        }

        public void ChosenDateChange(object sender, SelectionChangedEventArgs e)
        {
            Referral referral = (Referral)referrals.SelectedItem;
            if (referral != null)
            {
                this.selectedReferralId = referral.id;
                String doctorId = referral.doctor.user.Jmbg1;
                String chosenDateString = sender.ToString();
                String[] chosenDateParts = chosenDateString.Split('.');
                DateTime chosenDate = new DateTime(int.Parse(chosenDateParts[2]), int.Parse(chosenDateParts[1]), int.Parse(chosenDateParts[0]));
                DateTime endDate = chosenDate.AddDays(1);
                List<Appointment> a = appointmentController.ShowAvailableAppointments(Priority.None, doctorId, chosenDate, endDate, AppointmentType.Operation);
                availableTime.Visibility = Visibility.Visible;
                ConfirmButton.Visibility = Visibility.Visible;
                availableTime.ItemsSource = a;
            }
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            Appointment app = (Appointment)availableTime.SelectedItem;
            app.patient.user.Jmbg1 = MainWindow.user.Jmbg1;
            DateTime end = new DateTime(app.StartTime.Year, app.StartTime.Month, app.StartTime.Day, app.StartTime.Hour + 1, app.StartTime.Minute, app.StartTime.Second);
            appointmentController.CreateAppointment(app.doctor.user.Jmbg1, MainWindow.user.Jmbg1, app.StartTime, end, 1, "");
            Referral r = referralRepository.GetById(this.selectedReferralId);
            r.used = true;
            referralRepository.Update(r);
        }

        private void CalendarOpenedRestrictions(object sender, RoutedEventArgs e)
        {
            Referral referral = (Referral)referrals.SelectedItem;
            var picker = sender as DatePicker;
            picker.DisplayDateStart = DateTime.Now;
            picker.DisplayDateEnd = referral.endDate;
        }

        private void TimeIsSelected(object sender, SelectionChangedEventArgs e)
        {
            ConfirmButton.IsEnabled = true;
            ToolTip tooltip = new ToolTip { };
            ConfirmButton.ToolTip = tooltip;
            tooltip.Visibility = Visibility.Hidden;
        }
    }
}
