using Classes;
using ftn_sims_hci_hospital.Admin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ftn_sims_hci_hospital.Classes
{
    public class DoctorPollRepository : UpdateItemTemplate
    {
        private String FileLocation;
        public DoctorPoll doctorPoll { get; set; }
        private PatientRepository patientRepository;
        private DoctorRepository doctorRepository;
        public DoctorPollRepository()
        {
            FileLocation = "../../Text Files/doctorPoll.txt";
            patientRepository = new PatientRepository();
            doctorRepository = new DoctorRepository();
        }

        public override Boolean Create()
        {
            string newLine = doctorPoll.patient.user.Jmbg1 + ";" + doctorPoll.doctor.user.Jmbg1 + ";" + doctorPoll.mark.ToString() + ";" + doctorPoll.comment + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public override Boolean Delete()
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<DoctorPoll> polls = new List<DoctorPoll>();
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(doctorPoll.patient.user.Jmbg1) || !data[1].Equals(doctorPoll.doctor.user.Jmbg1))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
            return true;
        }

        public List<DoctorPoll> GetAll()
        {
            List<DoctorPoll> polls = new List<DoctorPoll>();
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                // DoctorPoll dp = new DoctorPoll(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]), int.Parse(data[2]), data[3]);
                PollFactory pf = new PollFactory(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]), int.Parse(data[2]), data[3]);
                DoctorPoll dp = (DoctorPoll)pf.getConcreteObject(ConstructorType.DoctorPoll);
                polls.Add(dp);
            }
            return polls;
        }

        public DoctorPoll GetPoll(String patientId, String doctorId)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                if (data[0].Equals(patientId) && data[1].Equals(doctorId))
                {
                    // DoctorPoll dp = new DoctorPoll(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]), int.Parse(data[2]), data[3]);
                    PollFactory pf = new PollFactory(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]), int.Parse(data[2]), data[3]);
                    DoctorPoll dp = (DoctorPoll)pf.getConcreteObject(ConstructorType.DoctorPoll);
                    return dp;
                }
            }
            return null;
        }

        public List<DoctorPoll> GetAllByDoctorId(String id)
        {
            List<DoctorPoll> polls = new List<DoctorPoll>();
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (String line in lines)
            {
                String[] data = line.Split(';');
                if (data[1].Equals(id))
                {
                    // DoctorPoll dp = new DoctorPoll(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]), int.Parse(data[2]), data[3]);
                    PollFactory pf = new PollFactory(patientRepository.GetByID(data[0]), doctorRepository.GetByID(data[1]), int.Parse(data[2]), data[3]);
                    DoctorPoll dp = (DoctorPoll)pf.getConcreteObject(ConstructorType.DoctorPoll);
                    polls.Add(dp);
                }
            }
            return polls;
        }

    }
}
