using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public abstract class Order : Demand
    {
        // Sluzi da bi se u buducnosti mozda napravio neki StaticEquipmentOrder iz njega
        // Na istom je nivou kao Request klasa

        private OrderStatus Status;

        public OrderStatus Status1 { get => Status; set => Status = value; }
    }
}
