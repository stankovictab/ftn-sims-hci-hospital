using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class DoctorPollService
    {
        private DoctorPollRepository doctorPollRepository;
        public DoctorPollService()
        {
            doctorPollRepository = new DoctorPollRepository();
        }

        public float GenerateDoctorAverageMark(String id)
        {
            float sum = 0;
            float average = 0;
            List<DoctorPoll> polls = doctorPollRepository.GetAllByDoctorId(id);
            foreach (DoctorPoll p in polls)
            {
                sum += p.mark;
            }
            average = sum / polls.Count();
            return average;
        }
    }
}
