using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ftn_sims_hci_hospital.Classes
{
    class HospitalizationReferal
    {
        public String id { get; set; }
        public Patient patient { get; set; }
        public String description { get; set; }
        public Room room { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startDate { get; set; }

        public HospitalizationReferal(string id, Patient patient, string description, DateTime endDate, DateTime startDate)
        {
            this.id = id;
            this.patient = patient;
            this.description = description;
            this.endDate = endDate;
            this.startDate = startDate;
        }
    }
}
