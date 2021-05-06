using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class DoctorPoll
    {
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
        public int mark { get; set; }
        public String comment { get; set; }

        public DoctorPoll()
        {

        }
        public DoctorPoll(Patient patient, Doctor doctor, int mark, String comment)
        {
            this.patient = patient;
            this.doctor = doctor;
            this.mark = mark;
            this.comment = comment;
        }
    }
}
