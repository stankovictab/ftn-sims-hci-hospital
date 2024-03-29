﻿using System;
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
using Classes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for PossibleAppointments.xaml
    /// </summary>
    public partial class PossibleAppointments : Window
    {
        String patientID, doctorID;
        public PossibleAppointments(List<Appointment> appointments)
        {
            InitializeComponent();
            foreach (Appointment appointment in appointments)
            {
                Patient p = new Patient();
                patientID = appointment.patient.user.Jmbg1;
                p = MainWindow.patientController.GetByID(patientID);
                Doctor d = new Doctor();
                doctorID = appointment.doctor.user.Jmbg1;
                d = MainWindow.doctorController.ds.dr.GetByID(doctorID);
                if (d.shift == Shift.MORNING)
                {
                    if (appointment.StartTime.Hour >= 8 && appointment.StartTime.Hour < 14)
                    {
                        
                        possibleAppointments.Items.Add(new Appointment { AppointmentID = appointment.AppointmentID, doctor = d, patient = p, StartTime = appointment.StartTime });
                    }
                    else
                        continue;
                }
                else
                {
                    if (appointment.StartTime.Hour >= 14 && appointment.StartTime.Hour < 20)
                    {
                        possibleAppointments.Items.Add(new Appointment { AppointmentID = appointment.AppointmentID, doctor = d, patient = p, StartTime = appointment.StartTime });
                    }
                    else
                        continue;
                }
            }
        }

        private void btnmakeappointment_Click(object sender, RoutedEventArgs e)
        {
            if(possibleAppointments.SelectedItem==null)
            {
                MessageBox.Show("You have to choose an appointment in order to make one!");
            }
            else
            {
                Appointment app = (Appointment)possibleAppointments.SelectedItem;
                app.AppointmentID = (MainWindow.appointmentController.appointmentService.appointmentRepository.GetAll().Count()+1).ToString();
                app.Room = new Room();
                app.Room.RoomNumber = "123";
                MainWindow.appointmentController.appointmentService.appointmentRepository.Create(app);
                SecretaryNotifyStrategy secretaryNotifyStrategy=new SecretaryNotifyStrategy();
                GlobalNotifier globalNotifier = new GlobalNotifier(secretaryNotifyStrategy);
                globalNotifier.Notify(app);
                MessageBox.Show("You have successfuly created an appointment and all relevant parties have been notified!");
                this.Close();
            }
        }
    }
}
