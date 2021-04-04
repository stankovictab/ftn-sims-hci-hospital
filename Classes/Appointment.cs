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

        public Appointment(String id, String doctorId, String patientId, DateTime start, DateTime end)
        {
            AppointmentID = id;
            doctor = new Doctor(doctorId);
            patient = new Patient(patientId);
            StartTime = start;
            EndTime = end;
        }

        public Appointment(String id, DateTime start, DateTime end)
        {
            AppointmentID = id;
            StartTime = start;
            EndTime = end;
        }

        public Doctor GetDoctor()
        {
            return doctor;
        }

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

        public Patient GetPatient()
        {
            return patient;
        }

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