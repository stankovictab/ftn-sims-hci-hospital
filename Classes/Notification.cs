using System;

namespace Classes
{
    public class Notification
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public DateTime Date { get; set; }
        public Boolean Read { get; set; }
        public String PatientId { get; set; }
        public String DoctorId { get; set; }
        public Patient patient;

        public Notification(String id, String title, String body, DateTime date, Boolean read, String patientId, String doctorId)
        {
            this.Id = id;
            this.Title = title;
            this.Body = body;
            this.Date = date;
            this.Read = read;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
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
                    oldPatient.RemoveNotifications(this);
                }
                if (newPatient != null)
                {
                    this.patient = newPatient;
                    this.patient.AddNotifications(this);
                }
            }
        }
    }
}