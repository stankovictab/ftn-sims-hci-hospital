using System;
using System.Collections.Generic;

namespace Classes
{
    public class PatientController
    {
        public PatientService patientService;

        public PatientController()
        {
            patientService = new PatientService();
        }

        public Boolean Create(Patient p)
        {
            // TODO: implement
            return false;
        }

        public Boolean addPrescription(Perscription per,String patientId)
        {
            patientService.addPrescription(per, patientId);
            return true;
        }

        public Boolean addAnamnesis(Anamnesis an, String patientId)
        {
            patientService.addAnamnesis(an, patientId);
            return true;
        }

        public Boolean removePrescription(String id)
        {
            return patientService.removePrescription(id);
        }

        public Boolean removeAnamnesis(String id)
        {
            return patientService.removeAnamnesis(id);
        }

        public Boolean updatePrescription(Perscription per, String patientId)
        {
            patientService.updatePrescription(per, patientId);
            return true;
        }
        public Boolean updateAnamnesis(Anamnesis an, String patientId)
        {
            patientService.updateAnamnesis(an, patientId);
            return true;
        }


        public List<Perscription> getAllPrescription(String patientId)
        {
            return patientService.getAllPrescription(patientId);
        }

        public List<Anamnesis> getAllAnamnesis(String patientId)
        {
            return patientService.getAllAnamnesis(patientId);
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