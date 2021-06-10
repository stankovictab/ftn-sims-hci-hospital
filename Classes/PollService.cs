using ftn_sims_hci_hospital.Classes;
using System;
using System.Collections.Generic;

namespace Classes
{
    public class PollService
    {
        public HospitalPollRepository hpr = new HospitalPollRepository();
        public DoctorPollRepository dpr = new DoctorPollRepository();
        public HospitalPollService hps = new HospitalPollService();
        public DoctorPollService dps = new DoctorPollService();

        // Nema potrebe za template klasom ako mu se prosledjuje List<Poll>, zbog ovoga je i napravljena nadklasa
        public Tuple<double, int, int, int, int, int> calculatePollResults(List<Poll> polls)
        {
            double avg = 0.0;
            int num = 0, fives = 0, fours = 0, threes = 0, twos = 0, ones = 0;

            foreach (Poll p in polls)
            {
                avg += p.mark;
                num++;
                switch (p.mark)
                {
                    case 5: fives++; break;
                    case 4: fours++; break;
                    case 3: threes++; break;
                    case 2: twos++; break;
                    case 1: ones++; break;
                    default: throw new Exception("Invalid mark.");
                }
            }
            avg = Math.Round(avg / num, 2);
            var tuple = new Tuple<double, int, int, int, int, int>(avg, fives, fours, threes, twos, ones);
            return tuple;
        }

        // HospitalPollRepository Links

        /*public Boolean HospitalPollCreate(String patientId, int mark, String comment)
        {
            return hpr.Create(patientId, mark, comment);
        }

        public Boolean HospitalPollUpdate(String patientId, int mark, String comment)
        {
            return hpr.Update(patientId, mark, comment);
        }

        public Boolean HospitalPollDelete(String patientId)
        {
            return hpr.Delete(patientId);
        }*/

        public List<HospitalPoll> HospitalPollGetAll()
        {
            return hpr.GetAll();
        }

        public HospitalPoll HospitalPollGetByPatientId(String id)
        {
            return hpr.GetByPatientId(id);
        }

        public float HospitalPollGenerateAverageMark()
        {
            return hps.GenerateAverageMark();
        }

        // DoctorPollRepository Links

        /*public Boolean DoctorPollCreate(String patientId, String doctorId, int mark, String comment)
        {
            return dpr.Create(patientId, doctorId, mark, comment);
        }

        public Boolean DoctorPollUpdate(String patientId, String doctorId, int mark, String comment)
        {
            return dpr.Update(patientId, doctorId, mark, comment);
        }

        public Boolean DoctorPollDelete(String patientId, String doctorId)
        {
            return dpr.Delete(patientId, doctorId);
        }*/

        public List<DoctorPoll> DoctorPollGetAll()
        {
            return dpr.GetAll();
        }

        public DoctorPoll DoctorPollGetPoll(String patientId, String doctorId)
        {
            return dpr.GetPoll(patientId, doctorId);
        }

        public List<DoctorPoll> DoctorPollGetAllByDoctorId(String id)
        {
            return dpr.GetAllByDoctorId(id);
        }

        public float DoctorPollGenerateDoctorAverageMark(String id)
        {
            return dps.GenerateDoctorAverageMark(id);
        }
    }
}
