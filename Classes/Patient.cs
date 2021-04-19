using System;
using System.Collections;
namespace Classes
{
    public class Patient
    {
        public System.Collections.ArrayList notifications;
        public User user { get; set; }
        public MedicalRecord medicalRecord;
        public System.Collections.ArrayList appointments;

		public Patient() { }

		public Patient(String id)
        {
            user = new User(id);
        }

        public Patient(User user, MedicalRecord medicalRecord, ArrayList appointments)
        {
            this.user = user;
            this.medicalRecord = medicalRecord;
            this.appointments = appointments;
        }

        public System.Collections.ArrayList GetNotifications()
        {
            if (notifications == null)
                notifications = new System.Collections.ArrayList();
            return notifications;
        }

        public void SetNotifications(System.Collections.ArrayList newNotifications)
        {
            RemoveAllNotifications();
            foreach (Notification oNotification in newNotifications)
                AddNotifications(oNotification);
        }

        public void AddNotifications(Notification newNotification)
        {
            if (newNotification == null)
                return;
            if (this.notifications == null)
                this.notifications = new System.Collections.ArrayList();
            if (!this.notifications.Contains(newNotification))
            {
                this.notifications.Add(newNotification);
                newNotification.SetPatient(this);
            }
        }

        public void RemoveNotifications(Notification oldNotification)
        {
            if (oldNotification == null)
                return;
            if (this.notifications != null)
                if (this.notifications.Contains(oldNotification))
                {
                    this.notifications.Remove(oldNotification);
                    oldNotification.SetPatient((Patient)null);
                }
        }

        public void RemoveAllNotifications()
        {
            if (notifications != null)
            {
                System.Collections.ArrayList tmpNotifications = new System.Collections.ArrayList();
                foreach (Notification oldNotification in notifications)
                    tmpNotifications.Add(oldNotification);
                notifications.Clear();
                foreach (Notification oldNotification in tmpNotifications)
                    oldNotification.SetPatient((Patient)null);
                tmpNotifications.Clear();
            }
        }

        public System.Collections.ArrayList GetAppointments()
        {
            if (appointments == null)
                appointments = new System.Collections.ArrayList();
            return appointments;
        }

        public void SetAppointments(System.Collections.ArrayList newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

        public void AddAppointments(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointments == null)
                this.appointments = new System.Collections.ArrayList();
            if (!this.appointments.Contains(newAppointment))
            {
                this.appointments.Add(newAppointment);
                newAppointment.SetPatient(this);
            }
        }

        public void RemoveAppointments(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointments != null)
                if (this.appointments.Contains(oldAppointment))
                {
                    this.appointments.Remove(oldAppointment);
                    oldAppointment.SetPatient((Patient)null);
                }
        }

        public void RemoveAllAppointments()
        {
            if (appointments != null)
            {
                System.Collections.ArrayList tmpAppointments = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointments)
                    tmpAppointments.Add(oldAppointment);
                appointments.Clear();
                foreach (Appointment oldAppointment in tmpAppointments)
                    oldAppointment.SetPatient((Patient)null);
                tmpAppointments.Clear();
            }
        }
    }
}