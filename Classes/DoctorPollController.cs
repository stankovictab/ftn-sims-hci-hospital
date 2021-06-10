using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    class DoctorPollController
    {
        private DoctorPollService doctorPollService;
        public DoctorPollController()
        {
            doctorPollService = new DoctorPollService();
        }

        public float GenerateDoctorAverageMark(String id)
        {
            return doctorPollService.GenerateDoctorAverageMark(id);
        }
    }
}
