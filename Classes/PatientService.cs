using System;
using System.Collections.Generic;

namespace Classes
{
    public class PatientService
    {
        public PatientRepository patientRepository;
        public AnamnesisRepository anamnesisRepository;
        public PerscriptionRepository perscriptionRepository;
        public AllergiesRepository allergiesRepository;

        public Boolean Create(Patient p)
        {
            // TODO: implement
            return false;
        }

        public Patient GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public List<Patient> GetAll()
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(Patient p)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<Patient> pif)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            // TODO: implement
            return false;
        }
    }
}