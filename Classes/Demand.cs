using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public abstract class Demand
    {
        protected String ID;
        protected DateTime CreationDate;

        public string ID1 { get => ID; set => ID = value; }
        public DateTime CreationDate1 { get => CreationDate; set => CreationDate = value; }
    }
}
