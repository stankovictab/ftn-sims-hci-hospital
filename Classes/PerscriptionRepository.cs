using System;
using System.Collections.Generic;

namespace Classes
{
    public class PerscriptionRepository
    {
        private String FileLocation;
        private List<Perscription> PerscriptionsInFile;

        public PerscriptionRepository()
        {
            FileLocation = "../../Text Files/presciptions.txt";
        }

        public Boolean Create(Perscription per,String patientId)
        {
            string newLine = per.Id + ";" + patientId + ";" + per.Medicine + ";" + per.Amount + ";" + per.Description + "\n";
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
                    Perscription p = new Perscription(parts[0], parts[2], int.Parse(parts[3]), parts[4]);
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