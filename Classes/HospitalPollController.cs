using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class HospitalPollController
    {
        private HospitalPollService hospitalPollService;
        public HospitalPollController()
        {
            hospitalPollService = new HospitalPollService();
        }

        public float GenerateAverageMark()
        {
            return hospitalPollService.GenerateAverageMark();
        }
    }
}
