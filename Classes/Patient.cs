using System;
using System.Collections;
using System.Collections.Generic;
using Models;
namespace Classes
{
    public class Patient
    {
        public List<Notification> notifications;
        public User user { get; set; }
        public MedicalRecord medicalRecord= new MedicalRecord();
        public List<Appointment> appointments;

		public Patient() { }

		public Patient(String id)
        {
            user = new User(id);
        }

        public Patient(User user, MedicalRecord medicalRecord, List<Appointment> appointments, List<Notification> notifications)
        {
            this.user = user;
            this.medicalRecord = medicalRecord;
            this.appointments = appointments;
            this.notifications = notifications;
        }

       
    }
}