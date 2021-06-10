using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class HospitalPollService
    {
        private HospitalPollRepository hospitalPollRepository;
        public HospitalPollService()
        {
            hospitalPollRepository = new HospitalPollRepository();
        }

        public float GenerateAverageMark()
        {
            float sum = 0;
            float average = 0;
            List<HospitalPoll> hospitalPolls = hospitalPollRepository.GetAll();
            foreach (HospitalPoll hp in hospitalPolls)
            {
                sum += hp.mark;
            }
            average = sum / hospitalPolls.Count();
            return average;
        }
    }
}
