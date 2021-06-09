using ftn_sims_hci_hospital.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital
{
    public class Invoker
    {
        Command theCommand;

        public Invoker(Command newCommand)
        {
            theCommand = newCommand;
        }

        public void Invoke()
        {
            theCommand.Execute();
        }
    }
}
