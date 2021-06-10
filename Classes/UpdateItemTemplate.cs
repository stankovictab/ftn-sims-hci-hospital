using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public abstract class UpdateItemTemplate
    {
        public void UpdateSteps()
        {
            if (Delete())
            {
                Create();
            }
        }

        public abstract Boolean Create();

        public abstract Boolean Delete();
    }
}
