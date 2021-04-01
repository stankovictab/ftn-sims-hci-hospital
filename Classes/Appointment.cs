/***********************************************************************
 * Module:  Appointment.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Appointment
 ***********************************************************************/

using System;

namespace Classes
{
    public class Appointment
    {
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public String AppointmentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        private AppointmentType Type;

        public Appointment(String id, String doctorName, String patientName, DateTime start, DateTime end)
        {
            doctor = new Doctor(doctorName);
            patient = new Patient(patientName);
            AppointmentID = id;
            StartTime = start;
            EndTime = end;
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Doctor GetDoctor()
        {
            return doctor;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoctor</param>
        public void SetDoctor(Doctor newDoctor)
        {
            if (this.doctor != newDoctor)
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveAppointments(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddAppointments(this);
                }
            }
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Patient GetPatient()
        {
            return patient;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newPatient</param>
        public void SetPatient(Patient newPatient)
        {
            if (this.patient != newPatient)
            {
                if (this.patient != null)
                {
                    Patient oldPatient = this.patient;
                    this.patient = null;
                    oldPatient.RemoveAppointments(this);
                }
                if (newPatient != null)
                {
                    this.patient = newPatient;
                    this.patient.AddAppointments(this);
                }
            }
        }


    }
}