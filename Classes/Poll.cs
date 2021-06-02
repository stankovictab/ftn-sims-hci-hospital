using System;

namespace ftn_sims_hci_hospital.Classes
{
    public class Poll
    {
        public int mark { get; set; }

        public String comment { get; set; }

        public Poll()
        {

        }

        public Poll(int mark, String comment)
        {
            this.mark = mark;
            this.comment = comment;
        }
    }
}
