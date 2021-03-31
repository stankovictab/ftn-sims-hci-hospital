using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class Patient
    {
        public User user { get; set; }
        public MedicalRecord medicalRecord;
        public System.Collections.ArrayList appointments;

        public Patient(String id)
        {
            User user1 = new User(id);
            user = user1;
        }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetAppointments()
        {
            if (appointments == null)
                appointments = new System.Collections.ArrayList();
            return appointments;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointments(System.Collections.ArrayList newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
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

        /// <pdGenerated>default Remove</pdGenerated>
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

        /// <pdGenerated>default removeAll</pdGenerated>
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

        public Patient(User user, MedicalRecord medicalRecord, ArrayList appointments)
        {
            this.user = user;
            this.medicalRecord = medicalRecord;
            this.appointments = appointments;
        }
        public Patient() { }
    }
}