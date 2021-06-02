using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class TrollingLog
    {
        public String patientId { get; set; }
        public String appointmentId { get; set; }
        public DateTime dateOfScheduling { get; set; }
        public Boolean canceled { get; set; }
        public TrollingLog()
        {

        }
        public TrollingLog(String patientId, String appointmentId, DateTime dateOfScheduling, Boolean canceled)
        {
            this.patientId = patientId;
            this.appointmentId = appointmentId;
            this.dateOfScheduling = dateOfScheduling;
            this.canceled = canceled;
        }
    }
}
