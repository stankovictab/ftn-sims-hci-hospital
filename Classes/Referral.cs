using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    class Referral
    {
        public String id { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public String description { get; set; }
        public DateTime endDate { get; set; }
        public DateTime chosenDate { get; set; }
        public Boolean used { get; set; }

        public Referral(String id, Doctor doctor, Patient patient, String description, DateTime endDate, Boolean used)
        {
            this.id = id;
            this.doctor = doctor;
            this.patient = patient;
            this.description = description;
            this.endDate = endDate;
            this.chosenDate = DateTime.Now; //nema ga u bazi
            this.used = used;
        }

        public Referral(String id, String doctordId, String patientId, String description, DateTime endDate, Boolean used)
        {
            this.id = id;
            this.doctor = new Doctor(doctordId);
            this.patient = new Patient(patientId);
            this.description = description;
            this.endDate = endDate;
            this.chosenDate = DateTime.Now; //nema ga u bazi
            this.used = used;
        }
    }
}
