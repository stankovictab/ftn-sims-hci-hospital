using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class TrollingLogService
    {
        private TrollingLogRepository trollingLogRepository;
        private PatientRepository patientRepository;

        public TrollingLogService()
        {
            trollingLogRepository = new TrollingLogRepository();
            patientRepository = new PatientRepository();
        }
        public int TrollCounter(String patientId)
        {
            List<TrollingLog> tlgs = trollingLogRepository.GetLastWeekScheduledAppointmentsByPatientId(patientId);
            int counter = 0;
            foreach (TrollingLog tlg in tlgs)
            {
                if (tlg.canceled) counter++;
                Console.WriteLine(tlg.canceled.ToString(), tlg.appointmentId);
            }
            return counter;
        }

        public void BlockUser(String id)
        {
            Patient p = patientRepository.GetByID(id);
            p.user.blocked = true;
            patientRepository.Update(p);
            MainWindow.user.blocked = true;
        }
    }
}
