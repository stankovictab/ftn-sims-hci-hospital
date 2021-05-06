using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class HospitalPoll
    {
        public Patient patient { get; set; }
        public int mark { get; set; }
        public String comment { get; set; }
        public HospitalPoll()
        {

        }
        public HospitalPoll(Patient patient, int mark, String comment)
        {
            this.patient = patient;
            this.mark = mark;
            this.comment = comment;
        }
    }
}
