using System;

namespace Classes
{
    public class Notification
    {
        private String Id;
        private String Title;
        private String Body;
        private DateTime Date;
        private Boolean Read;
        private String PatientId;
        private String DoctorId;
        public Patient patient;

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