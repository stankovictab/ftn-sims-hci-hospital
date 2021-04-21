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

        public PatientService()
        {
            patientRepository = new PatientRepository();
            anamnesisRepository = new AnamnesisRepository();
            perscriptionRepository = new PerscriptionRepository();
            allergiesRepository = new AllergiesRepository();
        }

        public Boolean Create(Patient p)
        {
            // TODO: implement
            return false;
        }

        public Patient GetByID(String id)
        {
            return patientRepository.GetByID(id);
        }

        public List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        public Boolean addPrescription(Perscription per, String patientId)
        {
            perscriptionRepository.Create(per, patientId);
            return true;
        }

        public Boolean addAnamnesis(Anamnesis an, String patientId)
        {
            anamnesisRepository.Create(an, patientId);
            return true;
        }

        public Boolean removePrescription(String id)
        {
            return perscriptionRepository.Delete(id);
        }

        public Boolean removeAnamnesis(String id)
        {
            return anamnesisRepository.Delete(id);
        }

        public Boolean updatePrescription(Perscription per,String patientId)
        {
            perscriptionRepository.Update(per, patientId);
            return true;
        }

        public Boolean updateAnamnesis(Anamnesis an, String patientId)
        {
            anamnesisRepository.Update(an, patientId);
            return true;
        }

        public List<Perscription> getAllPrescription(String patientId)
        {
            return perscriptionRepository.GetAllByPatientId(patientId);
        }

        public List<Anamnesis> getAllAnamnesis(String patientId)
        {
            return anamnesisRepository.GetAllByPatientId(patientId);
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