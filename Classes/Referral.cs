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

        public Referral(String id, String doctorId, String patientId, String description, DateTime endDate, Boolean used)
        {
            this.id = id;
            this.doctor = new Doctor(doctorId);
            this.patient = new Patient(patientId);
            this.description = description;
            this.endDate = endDate;
            this.chosenDate = DateTime.Now; //nema ga u bazi
            this.used = used;
        }
    }
}
