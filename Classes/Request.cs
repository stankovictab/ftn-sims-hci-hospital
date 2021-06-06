using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public abstract class Request : Demand
    {
        protected string Commentary;
        protected RequestStatus Status;

        public string Commentary1 { get => Commentary; set => Commentary = value; }
        public RequestStatus Status1 { get => Status; set => Status = value; }
    }
}
