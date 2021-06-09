using System;
using System.Collections.Generic;

namespace Classes
{
    public class PerscriptionRepository : IPerscriptionRepository
    {
        private String FileLocation;
        private MedicineRepository medicineRepository;

        public PerscriptionRepository()
        {
            FileLocation = "../../Text Files/presciptions.txt";
            medicineRepository = new MedicineRepository();
        }

        public Boolean Create(Perscription per,String patientId)
        {
            Random random = new Random();
            String id = random.Next(1, 1000).ToString();

            string newLine = id + ";" + patientId + ";" + per.Medicine.Id + ";" + per.Amount + ";" + per.Description + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Perscription GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public List<Perscription> GetAllByPatientId(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            List<Perscription> ret = new List<Perscription>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[1].Equals(id))
                {
                    Medicine medicine = medicineRepository.GetById(parts[2]);
                    Perscription p = new Perscription(parts[0], medicine, int.Parse(parts[3]), parts[4]);
                    ret.Add(p);
                }
            }
            return ret;
        }

        public List<Perscription> GetAll()
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(Perscription per,String patientId)
        {

            if (Delete(per.Id))
            {
                Create(per,patientId);
                return true;
            }

            return false;
        }

        public Boolean UpdateAll(List<Perscription> perscriptionsInFile)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {

            
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Perscription> prescriptions = new List<Perscription>();
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(id))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
            return true;
        }

        
    }
}