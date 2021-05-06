using Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public partial class UpdateAppointmentPatient : Window
    {
        private Appointment selectedAppointment;
        private AppointmentController appointmentController;
        private AppointmentRepository appointmentRepository;
        public UpdateAppointmentPatient(Appointment selectedAppointment)
        {
            this.selectedAppointment = selectedAppointment;
            appointmentController = new AppointmentController();
            appointmentRepository = new AppointmentRepository();
            InitializeComponent();
            SetDateRestrictions();
        }

        public void DateChange(object sender, SelectionChangedEventArgs e)
        {
            
            String chosenDateString = sender.ToString();
            String[] chosenDateParts = chosenDateString.Split('.');
            DateTime chosenDate = new DateTime(int.Parse(chosenDateParts[2]), int.Parse(chosenDateParts[1]), int.Parse(chosenDateParts[0]));
            DateTime endDate = chosenDate.AddDays(1);
            availableTimes.ItemsSource = appointmentController.ShowAvailableAppointments(Priority.None, this.selectedAppointment.doctor.user.Jmbg1, chosenDate, endDate, AppointmentType.Operation);
        }

        private void ConfirmDateChange(object sender, RoutedEventArgs e)
        {
            Appointment app = (Appointment)availableTimes.SelectedItem;
            DateTime novi = app.StartTime;
            Boolean provera = appointmentController.UpdateAppointment(this.selectedAppointment.AppointmentID, this.selectedAppointment.StartTime, novi, novi.AddHours(1), null, 0);
            appointmentRepository.updateDateStatus(this.selectedAppointment.AppointmentID);
        }

        private void SetDateRestrictions()
        {
            newDate.DisplayDateStart = this.selectedAppointment.StartTime;
            newDate.DisplayDateEnd = this.selectedAppointment.StartTime.AddDays(2);
            newDate.SelectedDate = this.selectedAppointment.StartTime;
        }
    }
}
