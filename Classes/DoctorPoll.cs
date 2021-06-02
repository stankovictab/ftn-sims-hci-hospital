using Classes;
using System;

namespace ftn_sims_hci_hospital.Classes
{
    public class DoctorPoll : Poll
    {
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }

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
