using System;
using System.Collections.Generic;

namespace Classes
{
    public class AnamnesisRepository : IAnamnesisRepository
    {
        private String FileLocation;

        public AnamnesisRepository()
        {
            FileLocation = "../../Text Files/anamnesis.txt";
        }

        public Boolean Create(Anamnesis a,String patientId)
        {
            string newLine = a.Id + ";" + patientId + ";" + a.Description + ";" + a.Date.ToString("yyyy,MM,dd,hh,mm,ss") + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Anamnesis GetByID(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[0].Equals(id))
                {
                    
                    string[] dateParts = parts[3].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));
                    Anamnesis a = new Anamnesis(parts[0],parts[2],date);

                    return a;
                }
            }
            return null;
        }

        public List<Anamnesis> GetAllByPatientId(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            List<Anamnesis> ret = new List<Anamnesis>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[1].Equals(id))
                {
                    string[] dateParts = parts[3].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));

                    Anamnesis a = new Anamnesis(parts[0],parts[2],date);
                    ret.Add(a);
                }
            }
            return ret;
        }

        public List<Anamnesis> GetAll()
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(Anamnesis a,String patientId)
        {
            if (Delete(a.Id))
            {
                Create(a, patientId);
                return true;
            }

            return false;
        }

        public Boolean UpdateAll(List<Anamnesis> anamnesesInFile)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Anamnesis> anamnesis = new List<Anamnesis>();
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