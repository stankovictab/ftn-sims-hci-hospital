using System;
using System.Collections.Generic;

namespace Classes
{
    public class PatientService
    {
        public PatientRepository patientRepository = new PatientRepository();
        public AnamnesisRepository anamnesisRepository= new AnamnesisRepository();
        public PerscriptionRepository perscriptionRepository = new PerscriptionRepository();
        public AllergiesRepository allergiesRepository = new AllergiesRepository();
        private PatientAllergyRepository patientallergyRepository = new PatientAllergyRepository();

        internal PatientAllergyRepository PatientallergyRepository { get => patientallergyRepository; set => patientallergyRepository = value; }

        public Boolean Create(Patient p)
        {
            if (patientRepository.GetByID(p.user.Jmbg1)!=null)
                return false;
            return patientRepository.Create(p);
        }

        public Patient GetByID(String id)
        {
            return patientRepository.GetByID(id);
        }

        public List<Patient> GetAll()
        {
            List<Patient> patients=patientRepository.GetAll();
            foreach(Patient patient in patients)
            {
                List<PatientAllergy> patientAllergies = new List<PatientAllergy>();
                patientAllergies = PatientallergyRepository.GetAllByPatientID(patient.user.Jmbg1);
                List<Allergy> allergies = new List<Allergy>();
                allergies = allergiesRepository.GetAll();
                foreach(PatientAllergy patientAllergy in patientAllergies)
                {
                    foreach(Allergy allergy in allergies)
                    {
                        if(patientAllergy.allergyID==allergy.Id1)
                        {
                            patient.medicalRecord.allergies.Add(allergy);
                        }
                    }
                }
               
            }
            return patients;
        }

        public Boolean Update(Patient p)
        {
            return patientRepository.Update(p);
        }

        public Boolean UpdateAll(List<Patient> pif)
        {
            return patientRepository.UpdateAll(pif);
        }

        public Boolean Delete(String id)
        {
            return patientallergyRepository.DeleteByPatientID(id) &&
             patientRepository.Delete(id);
        }
    }
}