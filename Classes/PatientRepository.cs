using System;
using System.Collections.Generic;

namespace Classes
{
    public class PatientRepository
    {
        private String FileLocation;
        private List<Patient> PatientsInFile;

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