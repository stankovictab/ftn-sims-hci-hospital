﻿using Classes;
using System;

namespace ftn_sims_hci_hospital.Classes
{
    public class HospitalPoll : Poll
    {
        public Patient patient { get; set; }

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
