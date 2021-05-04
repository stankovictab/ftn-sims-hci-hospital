using Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ftn_sims_hci_hospital.Classes
{
    public class PollRepository
    {
        private String FileLocation;
        private PatientRepository patientRepository;
        private DoctorRepository doctorRepository;
        public PollRepository()
        {
            FileLocation = "../../Text Files/poll.txt";
            patientRepository = new PatientRepository();
            doctorRepository = new DoctorRepository();
        }

        public Boolean Create(String patientId, String doctorId, int mark, String comment)
        {
            string newLine = patientId + ";" + doctorId + ";" + mark.ToString() + ";" + comment + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Boolean Update(String patientId, String doctorId, int mark, String comment)
        {
            Delete(patientId, doctorId);
            Create(patientId, doctorId, mark, comment);
            return true;
        }

        public Boolean Delete(String patientId, String doctorId)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Poll> polls = new List<Poll>();
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(patientId) || !data[1].Equals(doctorId))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
            return true;
        }

        public Poll GetPoll(String patientId, String doctorId)
        {
            Poll p = new Poll();
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                if (data[0].Equals(patientId) && data[1].Equals(doctorId))
                {
                    p = new Poll(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]),
                        int.Parse(data[2]), data[3]);
                    return p;
                }
            }
            return null;
        }

        public List<Poll> GetAllByDoctorId(String id)
        {
            List<Poll> polls = new List<Poll>();
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                if (data[1].Equals(id))
                {
                    Poll hp = new Poll(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]),
                        int.Parse(data[2]), data[3]);
                    polls.Add(hp);
                }
            }
            return polls;
        }

        public float GenerateDoctorAverageMark(String id)
        {
            float sum = 0;
            float average = 0;
            List<Poll> polls = GetAllByDoctorId(id);
            foreach (Poll p in polls)
            {
                sum += p.mark;
            }
            average = sum / polls.Count();
            return average;
        }
    }
}
