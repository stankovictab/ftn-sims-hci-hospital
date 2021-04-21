using System;
using System.Collections.Generic;

namespace Classes
{
    public class PatientController
    {
        public PatientService patientService = new PatientService();

        public Boolean Create(Patient p)
        {
            return patientService.Create(p);
        }

        public Patient GetByID(String id)
        {
            return patientService.GetByID(id);
        }

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }

        public Boolean Update(Patient p)
        {
            return patientService.Update(p);
        }

        public Boolean UpdateAll(List<Patient> pif)
        {
            return patientService.UpdateAll(pif);
        }

        public Boolean Delete(String id)
        {
            return patientService.Delete(id);
        }
    }
}