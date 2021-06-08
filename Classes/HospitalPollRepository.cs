using Classes;
using ftn_sims_hci_hospital.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class HospitalPollRepository
    {
        private String FileLocation;
        private PatientRepository patientRepository;
        public HospitalPollRepository()
        {
            FileLocation = "../../Text Files/hospitalPoll.txt";
            patientRepository = new PatientRepository();
        }

        public Boolean Create(String patientId, int mark, String comment)
        {
            string newLine = patientId + ";" + mark.ToString() + ";" + comment + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Boolean Update(String patientId, int mark, String comment)
        {
            Delete(patientId);
            Create(patientId, mark, comment);
            return true;
        }

        public Boolean Delete(String patientId)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<HospitalPoll> polls = new List<HospitalPoll>();
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(patientId))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
            return true;
        }

        public List<HospitalPoll> GetAll()
        {
            List<HospitalPoll> hospitalPolls = new List<HospitalPoll>();
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                // HospitalPoll hp = new HospitalPoll(patientRepository.GetByID(data[0]), int.Parse(data[1]), data[2]);
                PollFactory pf = new PollFactory(patientRepository.GetByID(data[0]), int.Parse(data[1]), data[2]);
                HospitalPoll hp = (HospitalPoll)pf.getConcreteObject(ConstructorType.HospitalPoll);
                hospitalPolls.Add(hp);
            }
            return hospitalPolls;
        }

        public HospitalPoll GetByPatientId(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                if (data[0].Equals(id))
                {
                    // HospitalPoll hp = new HospitalPoll(patientRepository.GetByID(id), int.Parse(data[1]), data[2]);
                    PollFactory pf = new PollFactory(patientRepository.GetByID(id), int.Parse(data[1]), data[2]);
                    HospitalPoll hp = (HospitalPoll)pf.getConcreteObject(ConstructorType.HospitalPoll);
                    return hp;
                }
            }
            return null;
        }

        public float GenerateAverageMark()
        {
            float sum = 0;
            float average = 0;
            List<HospitalPoll> hospitalPolls = GetAll();
            foreach(HospitalPoll hp in hospitalPolls)
            {
                sum += hp.mark;
            }
            average = sum / hospitalPolls.Count();
            return average;
        }
    }
}
