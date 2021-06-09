using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class PatientAllergyRepository : IPatientAllergyRepository
    {
        private String FileLocation;
        private AllergiesRepository allergiesRepository;
        public List<PatientAllergy> PatientAllergiesInFile { get; set; }

        public PatientAllergyRepository()
        {
            FileLocation = "../../Text Files/patientallergies.txt";
            allergiesRepository = new AllergiesRepository();
        }
        public Boolean Create(PatientAllergy pa)
        {
            PatientAllergiesInFile = GetAll();
            foreach (PatientAllergy pall in PatientAllergiesInFile)
            {
                if (pall.allergy.Id1 == pa.allergy.Id1 && pall.patientID.Equals(pa.patientID))
                    return false;
            }

            PatientAllergiesInFile.Add(pa);
            UpdateAll(PatientAllergiesInFile);
            return true;
        }

        public List<PatientAllergy> GetAllByPatientID(String id)
        {
            PatientAllergiesInFile = GetAll();
            List<PatientAllergy> patientAllergies = new List<PatientAllergy>();
            foreach (PatientAllergy patientallergy in PatientAllergiesInFile)
            {
                if (patientallergy.patientID.Equals(id))
                {
                    patientAllergies.Add(patientallergy);
                }
            }
            return patientAllergies;
        }

        public List<PatientAllergy> GetAll()
        {
            List<PatientAllergy> patientallergies = new List<PatientAllergy>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            if (text == null || text == "")
                return new List<PatientAllergy>();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                int allergyID = Convert.ToInt32(components[0]);
                string patientID = components[1];
                Allergy a = allergiesRepository.GetByID(allergyID);
                PatientAllergy patientallergy = new PatientAllergy(patientID, a);
                patientallergies.Add(patientallergy);
                text = tr.ReadLine();
            }
            tr.Close();
            return patientallergies;
        }

        public Boolean Update(PatientAllergy pa)
        {
            PatientAllergiesInFile = GetAll();
            foreach (PatientAllergy patientallergy in PatientAllergiesInFile)
            {
                if (patientallergy.patientID.Equals(pa.patientID))
                {

                    UpdateAll(PatientAllergiesInFile);
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAll(List<PatientAllergy> paif)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (paif == null)
            {
                tw.Close();
                return false;

            }
            else
            {
                foreach (PatientAllergy pa in paif)
                {
                    tw.WriteLine(pa.allergy.Id1 + "," + pa.patientID);
                }
                tw.Close();
                return true;
            }
        }

        public Boolean DeleteByPatientID(String id)
        {
            PatientAllergiesInFile = GetAll();
            List<PatientAllergy> allergiesbyPatientID = new List<PatientAllergy>();
            allergiesbyPatientID = GetAllByPatientID(id);
            foreach (PatientAllergy patientallergy in allergiesbyPatientID)
            {
                if (patientallergy.patientID.Equals(id))
                {
                    PatientAllergiesInFile.Remove(patientallergy);
                }
            }
            return UpdateAll(PatientAllergiesInFile);
        }
    }
}
